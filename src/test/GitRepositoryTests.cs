using System.Text;
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
        using var response = await client.SendAsync(request, TestContext.CancellationToken);
        var payload = await response.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            response.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)response.StatusCode} {response.ReasonPhrase}: {Encoding.UTF8.GetString(payload)}");

        var deserializationResult = APISerializer.DeserializeGitRepositoriesResponse(payload);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);
        Assert.IsNotNull(deserializationResult.Value.Value);

        using var document = JsonDocument.Parse(payload);
        GitPullRequestTests.AssertDeserializedValue(
            document.RootElement,
            deserializationResult.Value,
            "repositories");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchRepositoryAsync()
    {
        var repository = Environment.GetEnvironmentVariable("AZURE_DEVOPS_REPOSITORY");
        if (string.IsNullOrWhiteSpace(repository))
        {
            Assert.Inconclusive("Set AZURE_DEVOPS_REPOSITORY to a repository name or ID to run this integration test.");
            return;
        }

        using var request = HttpRequestFactory.GetRepositoryRequest(Organization, repository, Project);
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        using var response = await client.SendAsync(request, TestContext.CancellationToken);
        var payload = await response.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            response.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)response.StatusCode} {response.ReasonPhrase}: {Encoding.UTF8.GetString(payload)}");

        var deserializationResult = APISerializer.DeserializeGitRepository(payload);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);
        Assert.IsNotNull(deserializationResult.Value);

        using var document = JsonDocument.Parse(payload);
        GitPullRequestTests.AssertDeserializedValue(
            document.RootElement,
            deserializationResult.Value,
            "repository");
    }
}