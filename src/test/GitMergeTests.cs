using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class GitMergeTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task CreateMergeAsync()
    {
        using var request = HttpRequestFactory.CreateMergeRequest(
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