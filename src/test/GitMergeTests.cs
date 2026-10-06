using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class GitMergeTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public void GetMergeAsync()
    {
        using var request = Requests.GetMergeRequest(
            Organization,
            Project,
            "repository",
            1,
            includeLinks: true);
        AddAuthorizationForAzureDevOps(request);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            $"https://dev.azure.com/{Uri.EscapeDataString(Organization)}/{Uri.EscapeDataString(Project)}/_apis/git/repositories/repository/merges/1?includeLinks=true&api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);

        var payload = """{"mergeOperationId":1,"status":"completed","detailedStatus":{"mergeCommitId":"7e7460f6b61bbaa7cc2b52e4c33c0fb44d65ef9a"},"parents":["source","target"],"comment":"merge comment"}"""u8.ToArray();
        var deserializationResult = APISerializer.DeserializeGitMerge(payload);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);

        Assert.AreEqual(1, deserializationResult.Value.MergeOperationId);
        Assert.AreEqual("completed", deserializationResult.Value.Status);
        Assert.IsNotNull(deserializationResult.Value.DetailedStatus);
        Assert.AreEqual(
            "7e7460f6b61bbaa7cc2b52e4c33c0fb44d65ef9a",
            deserializationResult.Value.DetailedStatus.MergeCommitId);
        CollectionAssert.AreEqual(
            new[] { "source", "target" },
            deserializationResult.Value.Parents);

        Assert.Inconclusive(
            "A merge operation ID cannot be obtained through the available read-only APIs; the create operation is not invoked to obtain test data.");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task CreateMergeAsync()
    {
        using var request = Requests.CreateMergeRequest(
            "organization",
            "project",
            "repository",
            ["source", "target"],
            "merge comment",
            includeLinks: true);
        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/organization/project/_apis/git/repositories/repository/merges?includeLinks=true&api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);
        Assert.AreEqual("application/json", request.Content!.Headers.ContentType!.MediaType);

        using var requestBody = JsonDocument.Parse(await request.Content.ReadAsByteArrayAsync(TestContext.CancellationToken));
        Assert.AreEqual("merge comment", requestBody.RootElement.GetProperty("comment").GetString());
        CollectionAssert.AreEqual(
            new[] { "source", "target" },
            requestBody.RootElement.GetProperty("parents").EnumerateArray().Select(parent => parent.GetString()).ToArray());

        var deserializationResult = APISerializer.DeserializeGitMerge(
            "{\"mergeOperationId\":2,\"status\":\"queued\",\"detailedStatus\":{},\"parents\":[\"source\",\"target\"],\"comment\":\"merge comment\"}"u8);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);
        Assert.AreEqual(2, deserializationResult.Value.MergeOperationId);
        Assert.AreEqual("queued", deserializationResult.Value.Status);
        Assert.AreEqual("merge comment", deserializationResult.Value.Comment);

        Assert.Inconclusive("Merges - Create changes Azure DevOps resources and is not sent by this integration test.");
    }
}