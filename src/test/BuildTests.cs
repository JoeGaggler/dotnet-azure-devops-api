namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class BuildTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchBuildsAsync()
    {
        using var request = HttpRequestFactory.ListBuildsRequest(
            Organization,
            Project,
            top: 5,
            queryOrder: "finishTimeDescending");
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        var response = await Client.ListBuildsAsync(client, request, TestContext.CancellationToken);

        Assert.AreEqual(ClientStatus.Success, response.Status);
        Assert.IsNotNull(response.Value.Response.Value);

        var builds = response.Value.Response.Value;
        if (response.Value.Response.Count is not null)
            Assert.IsGreaterThanOrEqualTo(builds.Count, response.Value.Response.Count.Value);

        foreach (var build in builds)
        {
            Assert.IsNotNull(build.Id);

            if (build.BuildNumber is not null)
                Assert.IsFalse(string.IsNullOrWhiteSpace(build.BuildNumber));
            if (build.Project is not null)
                Assert.IsNotNull(build.Project.Id);
            if (build.Definition is not null)
                Assert.IsNotNull(build.Definition.Id);
            if (build.Repository is not null)
                Assert.IsNotNull(build.Repository.Id);
            if (build.Queue is not null)
                Assert.IsNotNull(build.Queue.Id);
            if (build.Tags is not null)
            {
                foreach (var tag in build.Tags)
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tag));
            }
            if (build.QueueTime is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(build.QueueTime, out _));
            if (build.StartTime is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(build.StartTime, out _));
            if (build.FinishTime is not null)
                Assert.IsTrue(DateTimeOffset.TryParse(build.FinishTime, out _));
        }
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchNextPageOfCompletedBuildsAsync()
    {
        using var client = new HttpClient();
        using var firstRequest = HttpRequestFactory.ListBuildsRequest(
            Organization,
            Project,
            top: 1,
            queryOrder: "finishTimeDescending",
            statusFilter: "completed");
        AddAuthorizationForAzureDevOps(firstRequest);

        var firstResponse = await Client.ListBuildsAsync(client, firstRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, firstResponse.Status);
        Assert.IsNotNull(firstResponse.Value.Response.Value);
        if (firstResponse.Value.Response.Value.Count == 0)
        {
            Assert.Inconclusive("The configured project has no completed builds to paginate.");
            return;
        }

        var firstBuild = firstResponse.Value.Response.Value[0];
        Assert.IsNotNull(firstBuild.Id);
        Assert.AreEqual("completed", firstBuild.Status);
        Assert.IsFalse(string.IsNullOrEmpty(firstResponse.Value.ContinuationToken));

        using var nextRequest = HttpRequestFactory.ListBuildsRequest(
            Organization,
            Project,
            top: 1,
            queryOrder: "finishTimeDescending",
            statusFilter: "completed",
            continuationToken: firstResponse.Value.ContinuationToken);
        AddAuthorizationForAzureDevOps(nextRequest);

        var nextResponse = await Client.ListBuildsAsync(client, nextRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, nextResponse.Status);
        Assert.IsNotNull(nextResponse.Value.Response.Value);
        Assert.HasCount(1, nextResponse.Value.Response.Value);

        var nextBuild = nextResponse.Value.Response.Value[0];
        Assert.IsNotNull(nextBuild.Id);
        Assert.AreEqual("completed", nextBuild.Status);
        Assert.AreNotEqual(firstBuild.Id, nextBuild.Id);
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchBuildAsync()
    {
        using var client = new HttpClient();
        using var listRequest = HttpRequestFactory.ListBuildsRequest(
            Organization,
            Project,
            top: 5,
            queryOrder: "finishTimeDescending");
        AddAuthorizationForAzureDevOps(listRequest);

        var listResponse = await Client.ListBuildsAsync(client, listRequest, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, listResponse.Status);
        Assert.IsNotNull(listResponse.Value.Response.Value);

        var buildId = listResponse.Value.Response.Value
            .Select(build => build.Id)
            .FirstOrDefault(id => id is not null);
        if (buildId is null)
        {
            Assert.Inconclusive("The configured project has no builds to retrieve by ID.");
            return;
        }

        using var request = HttpRequestFactory.GetBuildRequest(Organization, Project, buildId.Value);
        AddAuthorizationForAzureDevOps(request);

        var response = await Client.GetBuildAsync(client, request, TestContext.CancellationToken);
        Assert.AreEqual(ClientStatus.Success, response.Status);

        var build = response.Value;
        Assert.AreEqual(buildId.Value, build.Id);
        if (build.BuildNumber is not null)
            Assert.IsFalse(string.IsNullOrWhiteSpace(build.BuildNumber));
        if (build.Project is not null)
            Assert.IsNotNull(build.Project.Id);
        if (build.Definition is not null)
            Assert.IsNotNull(build.Definition.Id);
        if (build.Repository is not null)
            Assert.IsNotNull(build.Repository.Id);
        if (build.Tags is not null)
        {
            foreach (var tag in build.Tags)
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag));
        }
        if (build.QueueTime is not null)
            Assert.IsTrue(DateTimeOffset.TryParse(build.QueueTime, out _));
        if (build.StartTime is not null)
            Assert.IsTrue(DateTimeOffset.TryParse(build.StartTime, out _));
        if (build.FinishTime is not null)
            Assert.IsTrue(DateTimeOffset.TryParse(build.FinishTime, out _));
    }
}