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
}