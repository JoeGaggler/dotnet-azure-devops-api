using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class GitPullRequestTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchPullRequestByIdAsync()
    {
        using var client = new HttpClient();
        using var listRequest = HttpRequestFactory.GetPullRequestsByProjectRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(listRequest);

        var listResult = await Client.ListGitPullRequestsAsync(client, listRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, listResult.Status);
        Assert.IsNotNull(listResult.Value.Value);

        var pullRequestId = listResult.Value.Value
            .Select(pullRequest => pullRequest.PullRequestId)
            .FirstOrDefault(id => id is not null);
        if (pullRequestId is null)
        {
            Assert.Inconclusive("The configured project has no pull requests to retrieve by ID.");
            return;
        }

        using var request = HttpRequestFactory.GetPullRequestByIdRequest(Organization, pullRequestId.Value, Project);
        AddAuthorizationForAzureDevOps(request);

        var response = await Client.GetGitPullRequestAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);
        Assert.AreEqual(pullRequestId.Value, response.Value.PullRequestId);
        AssertPullRequestModel(response.Value);
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchPullRequestsForProjectAsync()
    {
        using var request = HttpRequestFactory.GetPullRequestsByProjectRequest(Organization, Project, top: 2);
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        var response = await Client.ListGitPullRequestsAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);

        var result = response.Value;
        Assert.IsNotNull(result.Value);
        Assert.IsNotNull(result.Count);
        Assert.IsGreaterThanOrEqualTo(result.Value.Count, result.Count.Value);

        foreach (var pullRequest in result.Value)
            AssertPullRequestModel(pullRequest);
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchPullRequestStatusesAsync()
    {
        using var client = new HttpClient();
        using var listRequest = HttpRequestFactory.GetPullRequestsByProjectRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(listRequest);

        var pullRequests = await Client.ListGitPullRequestsAsync(client, listRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, pullRequests.Status);
        Assert.IsNotNull(pullRequests.Value.Value);

        var pullRequest = pullRequests.Value.Value.FirstOrDefault(
            item => item.PullRequestId is not null && item.Repository?.Id is not null);
        if (pullRequest is null)
        {
            Assert.Inconclusive("The configured project has no pull request with a repository ID to query statuses for.");
            return;
        }

        using var request = HttpRequestFactory.GetPullRequestStatusesRequest(
            Organization,
            pullRequest.Repository!.Id!,
            pullRequest.PullRequestId!.Value,
            Project);
        AddAuthorizationForAzureDevOps(request);

        var response = await Client.GetGitPullRequestStatusesAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);
        Assert.IsNotNull(response.Value.Value);
        Assert.IsNotNull(response.Value.Count);
        Assert.AreEqual(response.Value.Value.Count, response.Value.Count.Value);

        foreach (var status in response.Value.Value)
        {
            Assert.IsNotNull(status.Id);
            if (status.State is not null)
                Assert.IsFalse(string.IsNullOrWhiteSpace(status.State));
            if (status.Context is not null)
                Assert.IsNotNull(status.Context.Name);
            if (status.CreatedBy is not null)
                Assert.IsNotNull(status.CreatedBy.Id);
            if (status.CreationDate is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(status.CreationDate, out _));
            if (status.UpdatedDate is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(status.UpdatedDate, out _));
            if (status.Properties?.Keys is not null)
                Assert.HasCount(status.Properties.Count!.Value, status.Properties.Keys);
        }
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task CreatePullRequestStatusAsync()
    {
        using var request = HttpRequestFactory.CreatePullRequestStatusRequest(
            Organization,
            "repository-id",
            1,
            new GitPullRequestStatus
            {
                Context = new GitStatusContext { Name = "local-status-check" },
                State = "succeeded",
                Description = "Local request validation",
            },
            Project);

        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            $"https://dev.azure.com/{Uri.EscapeDataString(Organization)}/{Uri.EscapeDataString(Project)}/_apis/git/repositories/repository-id/pullRequests/1/statuses?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);

        using var requestBody = await request.Content!.ReadAsStreamAsync(TestContext.CancellationToken);
        using var document = await JsonDocument.ParseAsync(requestBody, cancellationToken: TestContext.CancellationToken);
        Assert.AreEqual(
            "local-status-check",
            document.RootElement.GetProperty("context").GetProperty("name").GetString());

        var response = APISerializer.DeserializeGitPullRequestStatus(
            """{"id":3,"state":"succeeded","context":{"name":"local-status-check"}}"""u8);
        Assert.AreEqual(DeserializationStatus.Success, response.Status);
        Assert.AreEqual(3, response.Value.Id);
        Assert.AreEqual("local-status-check", response.Value.Context!.Name);

        Assert.Inconclusive("Create Pull Request Status changes Azure DevOps resources; the POST request is not sent.");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public void DeletePullRequestStatusAsync()
    {
        using var request = HttpRequestFactory.DeletePullRequestStatusRequest(
            Organization,
            "repository-id",
            1,
            1,
            Project);

        Assert.AreEqual(HttpMethod.Delete, request.Method);
        Assert.AreEqual(
            $"https://dev.azure.com/{Uri.EscapeDataString(Organization)}/{Uri.EscapeDataString(Project)}/_apis/git/repositories/repository-id/pullRequests/1/statuses/1?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
        Assert.IsNull(request.Content);

        Assert.Inconclusive("Delete Pull Request Status changes Azure DevOps resources; the DELETE request is not sent.");
    }

    private static void AssertPullRequestModel(GitPullRequest pullRequest)
    {
        Assert.IsNotNull(pullRequest.PullRequestId);
        Assert.IsNotNull(pullRequest.Title);
        Assert.IsNotNull(pullRequest.Status);
        Assert.IsNotNull(pullRequest.Repository);
        Assert.IsNotNull(pullRequest.Repository.Id);
        Assert.IsNotNull(pullRequest.Repository.Name);

        if (pullRequest.CreationDate is not null)
            Assert.IsTrue(DateTimeOffset.TryParse(pullRequest.CreationDate, out _));
        if (pullRequest.CreatedBy is not null)
            Assert.IsNotNull(pullRequest.CreatedBy.Id);
        if (pullRequest.LastMergeCommit is not null)
            Assert.IsNotNull(pullRequest.LastMergeCommit.CommitId);
        if (pullRequest.Reviewers is not null)
        {
            foreach (var reviewer in pullRequest.Reviewers)
            {
                Assert.IsNotNull(reviewer.Id);
                Assert.IsNotNull(reviewer.Vote);
            }
        }
        if (pullRequest.Labels is not null)
        {
            foreach (var label in pullRequest.Labels)
                Assert.IsNotNull(label.Name);
        }
        if (pullRequest.WorkItemRefs is not null)
        {
            foreach (var workItem in pullRequest.WorkItemRefs)
                Assert.IsNotNull(workItem.Id);
        }
        if (pullRequest.Links?.Links is not null)
        {
            foreach (var link in pullRequest.Links.Links.Values)
                Assert.IsNotNull(link.Href);
        }
    }
}
