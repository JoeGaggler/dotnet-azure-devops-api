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
        using var client = new HttpClient();
        using var listRequest = HttpRequestFactory.ListRepositoriesRequest(Organization, Project);
        AddAuthorizationForAzureDevOps(listRequest);

        using var listResponse = await client.SendAsync(listRequest, TestContext.CancellationToken);
        var listPayload = await listResponse.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            listResponse.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)listResponse.StatusCode} {listResponse.ReasonPhrase}: {Encoding.UTF8.GetString(listPayload)}");

        var listResult = APISerializer.DeserializeGitRepositoriesResponse(listPayload);
        Assert.AreEqual(DeserializationStatus.Success, listResult.Status);
        Assert.IsNotNull(listResult.Value.Value);

        var repositoryId = listResult.Value.Value
            .Select(repository => repository.Id)
            .FirstOrDefault(id => id is not null);
        if (repositoryId is null)
        {
            Assert.Inconclusive("The configured project has no repositories to retrieve by ID.");
            return;
        }

        using var request = HttpRequestFactory.GetRepositoryRequest(Organization, repositoryId, Project);
        AddAuthorizationForAzureDevOps(request);

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