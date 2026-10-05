using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class GitRepositoryTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchRepositoriesAsync()
    {
        using var request = HttpRequestFactory.ListRepositoriesRequest(
            Organization,
            Project,
            includeAllUrls: true,
            includeLinks: true);
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        var response = await Client.ListGitRepositoriesAsync(client, request, TestContext.CancellationToken);

        Assert.AreEqual(ClientStatus.Success, response.Status);

        var model = response.Value;
        Assert.IsNotNull(model.Value);

        Assert.IsNotNull(model.Count);
        Assert.IsNotNull(model.Value);
        Assert.HasCount(model.Count.Value, model.Value);

        foreach (var repository in model.Value)
        {
            Assert.IsNotNull(repository.Id);
            Assert.IsNotNull(repository.Name);
            Assert.IsNotNull(repository.Url);
            Assert.IsNotNull(repository.Project);
            Assert.IsNotNull(repository.Project.Id);
            Assert.IsNotNull(repository.Project.Name);

            if (repository.CreationDate is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(repository.CreationDate, out _));
            if (repository.DefaultBranch is not null)
                Assert.IsFalse(string.IsNullOrWhiteSpace(repository.DefaultBranch));
            if (repository.Size is not null)
                Assert.IsGreaterThanOrEqualTo(0L, repository.Size.Value);
            if (repository.RemoteUrl is not null)
                Assert.IsTrue(Uri.TryCreate(repository.RemoteUrl, UriKind.Absolute, out _));
            if (repository.SshUrl is not null)
                Assert.IsFalse(string.IsNullOrWhiteSpace(repository.SshUrl));
            if (repository.WebUrl is not null)
                Assert.IsTrue(Uri.TryCreate(repository.WebUrl, UriKind.Absolute, out _));

            if (repository.ValidRemoteUrls is not null)
            {
                foreach (var remoteUrl in repository.ValidRemoteUrls)
                    Assert.IsFalse(string.IsNullOrWhiteSpace(remoteUrl));
            }

            if (repository.Links?.Links is not null)
            {
                foreach (var link in repository.Links.Links.Values)
                    Assert.IsNotNull(link.Href);
            }
        }
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchRepositoryAsync()
    {
        using var client = new HttpClient();
        using var listRequest = HttpRequestFactory.ListRepositoriesRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(listRequest);

        var listResponse = await Client.ListGitRepositoriesAsync(client, listRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, listResponse.Status);
        Assert.IsNotNull(listResponse.Value.Value);

        var repositoryId = listResponse.Value.Value
            .Select(repository => repository.Id)
            .FirstOrDefault(id => id is not null);
        if (repositoryId is null)
        {
            Assert.Inconclusive("The configured project has no repositories to retrieve by ID.");
            return;
        }

        using var request = HttpRequestFactory.GetRepositoryRequest(Organization, repositoryId, Project);
        AddAuthorizationForAzureDevOps(request);

        var response = await Client.GetGitRepositoryAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);

        var repository = response.Value;
        Assert.IsNotNull(repository.Id);
        Assert.IsNotNull(repository.Name);
        Assert.IsNotNull(repository.Url);
        Assert.IsNotNull(repository.Project);
        Assert.IsNotNull(repository.Project.Id);
        Assert.IsNotNull(repository.Project.Name);

        if (repository.CreationDate is not null)
            Assert.IsTrue(DateTimeOffset.TryParse(repository.CreationDate, out _));
        if (repository.Size is not null)
            Assert.IsGreaterThanOrEqualTo(0L, repository.Size.Value);
        if (repository.RemoteUrl is not null)
            Assert.IsTrue(Uri.TryCreate(repository.RemoteUrl, UriKind.Absolute, out _));
        if (repository.SshUrl is not null)
            Assert.IsFalse(string.IsNullOrWhiteSpace(repository.SshUrl));
        if (repository.WebUrl is not null)
            Assert.IsTrue(Uri.TryCreate(repository.WebUrl, UriKind.Absolute, out _));
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchRefsAsync()
    {
        using var client = new HttpClient();
        using var listRepositoriesRequest = HttpRequestFactory.ListRepositoriesRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(listRepositoriesRequest);

        var repositories = await Client.ListGitRepositoriesAsync(
            client,
            listRepositoriesRequest,
            TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, repositories.Status);
        Assert.IsNotNull(repositories.Value.Value);

        var repositoryId = repositories.Value.Value
            .Select(repository => repository.Id)
            .FirstOrDefault(id => id is not null);
        if (repositoryId is null)
        {
            Assert.Inconclusive("The configured project has no repositories whose refs can be listed.");
            return;
        }

        using var request = HttpRequestFactory.ListRefsRequest(
            Organization,
            repositoryId,
            Project,
            filter: "heads/",
            includeLinks: true,
            includeStatuses: true,
            top: 20);
        AddAuthorizationForAzureDevOps(request);

        var response = await Client.ListGitRefsAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);
        Assert.IsNotNull(response.Value.Count);
        Assert.IsNotNull(response.Value.Value);
        Assert.IsGreaterThanOrEqualTo(response.Value.Value.Count, response.Value.Count.Value);

        foreach (var reference in response.Value.Value)
        {
            Assert.IsNotNull(reference.Name);
            Assert.IsNotNull(reference.ObjectId);
            Assert.IsNotNull(reference.Url);

            if (reference.Creator is not null)
                Assert.IsNotNull(reference.Creator.Id);
            if (reference.Links?.Links is not null)
            {
                foreach (var link in reference.Links.Links.Values)
                    Assert.IsNotNull(link.Href);
            }
            if (reference.Statuses is not null)
            {
                foreach (var status in reference.Statuses)
                {
                    Assert.IsNotNull(status.Context);
                    Assert.IsNotNull(status.Context.Name);
                    if (status.CreationDate is not null)
                        Assert.IsTrue(DateTimeOffset.TryParse(status.CreationDate, out _));
                }
            }
        }
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task UpdateRefAsync()
    {
        using var request = HttpRequestFactory.UpdateRefRequest(
            Organization,
            "repository-id",
            "refs/heads/example",
            new GitRefUpdate { IsLocked = true },
            Project);

        Assert.AreEqual(HttpMethod.Patch, request.Method);
        Assert.AreEqual(
            $"https://dev.azure.com/{Uri.EscapeDataString(Organization)}/{Uri.EscapeDataString(Project)}/_apis/git/repositories/repository-id/refs?filter=refs%2Fheads%2Fexample&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);

        using var body = JsonDocument.Parse(await request.Content!.ReadAsByteArrayAsync(TestContext.CancellationToken));
        Assert.IsTrue(body.RootElement.GetProperty("isLocked").GetBoolean());

        var response = APISerializer.DeserializeGitRef(
            """{"name":"refs/heads/example","objectId":"commit-id","isLocked":true}"""u8);
        Assert.AreEqual(DeserializationStatus.Success, response.Status);
        Assert.AreEqual("refs/heads/example", response.Value.Name);
        Assert.AreEqual("commit-id", response.Value.ObjectId);

        Assert.Inconclusive("Update Ref changes Azure DevOps repository state; the PATCH request is not sent.");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task UpdateRefsAsync()
    {
        using var request = HttpRequestFactory.UpdateRefsRequest(
            Organization,
            "repository-id",
            [new GitRefUpdate
            {
                Name = "refs/heads/example",
                OldObjectId = "old-object-id",
                NewObjectId = "new-object-id",
            }],
            Project);

        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            $"https://dev.azure.com/{Uri.EscapeDataString(Organization)}/{Uri.EscapeDataString(Project)}/_apis/git/repositories/repository-id/refs?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);

        using var body = JsonDocument.Parse(await request.Content!.ReadAsByteArrayAsync(TestContext.CancellationToken));
        Assert.AreEqual(JsonValueKind.Array, body.RootElement.ValueKind);
        Assert.AreEqual("refs/heads/example", body.RootElement[0].GetProperty("name").GetString());

        var response = APISerializer.DeserializeGitRefUpdateResultsResponse(
            """{"count":1,"value":[{"name":"refs/heads/example","newObjectId":"new-object-id","oldObjectId":"old-object-id","repositoryId":"repository-id","success":true,"updateStatus":"succeeded"}]}"""u8);
        Assert.AreEqual(DeserializationStatus.Success, response.Status);
        Assert.IsTrue(response.Value.Value![0].Success);

        Assert.Inconclusive("Update Refs changes Azure DevOps repository state; the POST request is not sent.");
    }
}