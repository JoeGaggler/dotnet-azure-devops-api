using System.Text;
using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class GitPullRequestTests : AzureDevOpsIntegrationTestBase
{
    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchPullRequestsForProjectAsync()
    {
        using var request = HttpRequestFactory.GetPullRequestsByProjectRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        using var response = await client.SendAsync(request, TestContext.CancellationToken);
        var payload = await response.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            response.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)response.StatusCode} {response.ReasonPhrase}: {Encoding.UTF8.GetString(payload)}");

        var reader = new Utf8JsonReader(payload);
        Assert.IsTrue(reader.Read(), "Azure DevOps returned an empty response.");
        Assert.AreEqual(JsonTokenType.StartObject, reader.TokenType);

        var result = new GitPullRequestsResponse();
        APISerializer.Deserialize(ref reader, result);

        Assert.IsNotNull(result.Value);
    }
}
