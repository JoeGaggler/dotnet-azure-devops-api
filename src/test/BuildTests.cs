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
        Assert.IsNotNull(response.Value.Value);

        var builds = response.Value.Value;
        if (response.Value.Count is not null)
            Assert.IsGreaterThanOrEqualTo(builds.Count, response.Value.Count.Value);

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
        Assert.IsNotNull(listResponse.Value.Value);

        var buildId = listResponse.Value.Value
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