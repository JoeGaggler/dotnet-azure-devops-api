using System.Text;
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

        using var listResponse = await client.SendAsync(listRequest, TestContext.CancellationToken);
        var listPayload = await listResponse.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            listResponse.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)listResponse.StatusCode} {listResponse.ReasonPhrase}: {Encoding.UTF8.GetString(listPayload)}");

        var listResult = APISerializer.DeserializeGitPullRequestsResponse(listPayload);
        Assert.AreEqual(DeserializationStatus.Success, listResult.Status);
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

        using var response = await client.SendAsync(request, TestContext.CancellationToken);
        var payload = await response.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            response.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)response.StatusCode} {response.ReasonPhrase}: {Encoding.UTF8.GetString(payload)}");

        var deserializationResult = APISerializer.DeserializeGitPullRequest(payload);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);
        Assert.IsNotNull(deserializationResult.Value);
        Assert.AreEqual(pullRequestId.Value, deserializationResult.Value.PullRequestId);

        using var document = JsonDocument.Parse(payload);
        AssertDeserializedValue(document.RootElement, deserializationResult.Value, "pullRequest");
    }

    [TestMethod]
    [TestCategory("Integration")]
    public async Task FetchPullRequestsForProjectAsync()
    {
        using var request = HttpRequestFactory.GetPullRequestsByProjectRequest(Organization, Project, top: 2);
        AddAuthorizationForAzureDevOps(request);

        using var client = new HttpClient();
        using var response = await client.SendAsync(request, TestContext.CancellationToken);
        var payload = await response.Content.ReadAsByteArrayAsync(TestContext.CancellationToken);

        Assert.IsTrue(
            response.IsSuccessStatusCode,
            $"Azure DevOps returned {(int)response.StatusCode} {response.ReasonPhrase}: {Encoding.UTF8.GetString(payload)}");

        var deserializationResult = APISerializer.DeserializeGitPullRequestsResponse(payload);
        Assert.AreEqual(DeserializationStatus.Success, deserializationResult.Status);
        Assert.IsNotNull(deserializationResult.Value);
        Assert.IsNotNull(deserializationResult.Value.Value);

        var result = deserializationResult.Value;

        using var document = JsonDocument.Parse(payload);
        var expectedPullRequests = document.RootElement.GetProperty("value");
        Assert.HasCount(expectedPullRequests.GetArrayLength(), result.Value);
        Assert.AreEqual(document.RootElement.GetProperty("count").GetInt32(), result.Count);

        for (var index = 0; index < result.Value.Count; index++)
        {
            AssertDeserializedValue(
                expectedPullRequests[index],
                result.Value[index],
                $"value[{index}]");
        }
    }

    private static void AssertDeserializedValue(JsonElement expected, object? actual, string path)
    {
        if (expected.ValueKind == JsonValueKind.Null)
        {
            Assert.IsNull(actual, path);
            return;
        }

        Assert.IsNotNull(actual, path);

        switch (expected.ValueKind)
        {
            case JsonValueKind.Object when actual is ReferenceLinks links:
                AssertReferenceLinks(expected, links, path);
                break;
            case JsonValueKind.Object:
                AssertObject(expected, actual, path);
                break;
            case JsonValueKind.Array:
                AssertArray(expected, actual, path);
                break;
            case JsonValueKind.String:
                Assert.AreEqual(expected.GetString(), actual, path);
                break;
            case JsonValueKind.Number:
                Assert.AreEqual(expected.GetInt64(), Convert.ToInt64(actual), path);
                break;
            case JsonValueKind.True:
            case JsonValueKind.False:
                Assert.AreEqual(expected.GetBoolean(), actual, path);
                break;
            default:
                Assert.Fail($"Unsupported JSON token at {path}: {expected.ValueKind}");
                break;
        }
    }

    private static void AssertObject(JsonElement expected, object actual, string path)
    {
        foreach (var property in actual.GetType().GetProperties())
        {
            var jsonName = property.Name == nameof(GitPullRequest.Links)
                ? "_links"
                : JsonNamingPolicy.CamelCase.ConvertName(property.Name);
            var propertyPath = $"{path}.{jsonName}";
            var propertyValue = property.GetValue(actual);

            if (expected.TryGetProperty(jsonName, out var expectedProperty))
            {
                AssertDeserializedValue(expectedProperty, propertyValue, propertyPath);
            }
            else
            {
                Assert.IsNull(propertyValue, $"{propertyPath} was not present in the response.");
            }
        }
    }

    private static void AssertArray(JsonElement expected, object actual, string path)
    {
        var actualItems = ((System.Collections.IEnumerable)actual).Cast<object?>().ToList();
        Assert.HasCount(expected.GetArrayLength(), actualItems, path);

        for (var index = 0; index < actualItems.Count; index++)
        {
            AssertDeserializedValue(expected[index], actualItems[index], $"{path}[{index}]");
        }
    }

    private static void AssertReferenceLinks(JsonElement expected, ReferenceLinks actual, string path)
    {
        Assert.IsNotNull(actual.Links, path);
        Assert.HasCount(expected.EnumerateObject().Count(), actual.Links, path);

        foreach (var property in expected.EnumerateObject())
        {
            Assert.IsTrue(actual.Links.TryGetValue(property.Name, out var link), $"Missing {path}.{property.Name}.");
            AssertDeserializedValue(property.Value, link, $"{path}.{property.Name}");
        }
    }
}
