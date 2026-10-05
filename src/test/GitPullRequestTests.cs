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
