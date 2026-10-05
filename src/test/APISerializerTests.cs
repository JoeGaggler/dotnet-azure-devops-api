using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class APISerializerTests
{
    [TestMethod]
    public void DeserializeGitRepositoriesResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRepositoriesResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRefsResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRefsResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRefsResponseWithInvalidOrMalformedPayloadReturnsFailure()
    {
        var invalidRoot = APISerializer.DeserializeGitRefsResponse("[]"u8);
        var malformed = APISerializer.DeserializeGitRefsResponse("{\"value\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
    }

    [TestMethod]
    public void DeserializeGitRefsResponseWithDocumentedFieldsReturnsSuccess()
    {
        var result = APISerializer.DeserializeGitRefsResponse(
            """{"value":[{"name":"refs/heads/main","objectId":"commit-id","creator":{"displayName":"Dev","id":"identity-id"},"isLocked":true,"isLockedBy":{"id":"lock-owner"},"statuses":[{"id":7,"state":"succeeded","context":{"genre":"ci","name":"build"},"createdBy":{"id":"status-owner"}}],"url":"https://dev.azure.com/org/project/_apis/git/refs"}],"count":1}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(1, result.Value.Count);
        var references = result.Value.Value!;
        Assert.HasCount(1, references);
        Assert.AreEqual("refs/heads/main", references[0].Name);
        Assert.AreEqual("commit-id", references[0].ObjectId);
        Assert.AreEqual("Dev", references[0].Creator!.DisplayName);
        Assert.IsTrue(references[0].IsLocked);
        Assert.AreEqual("lock-owner", references[0].IsLockedBy!.Id);
        var status = references[0].Statuses![0];
        Assert.AreEqual(7, status.Id);
        Assert.AreEqual("ci", status.Context!.Genre);
    }

    [TestMethod]
    public void ListRefsRequestIncludesDocumentedOptionalParametersAndEscapesValues()
    {
        using var request = HttpRequestFactory.ListRefsRequest(
            "org name",
            "repo/id",
            "project name",
            top: 5,
            continuationToken: "token +/",
            filter: "heads/",
            filterContains: "feature & fix",
            includeLinks: true,
            includeStatuses: true,
            includeTargetBranches: true,
            latestStatusesOnly: true,
            peelTags: true);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/refs?filter=heads%2F&includeLinks=true&includeStatuses=true&latestStatusesOnly=true&peelTags=true&filterContains=feature%20%26%20fix&$top=5&continuationToken=token%20%2B%2F&includeTargetBranches=true&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void ListRefsRequestIncludesIncludeMyBranchesAndOmitsUnsetParameters()
    {
        using var request = HttpRequestFactory.ListRefsRequest(
            "organization",
            "repository",
            includeMyBranches: true);

        Assert.AreEqual(
            "https://dev.azure.com/organization/_apis/git/repositories/repository/refs?includeMyBranches=true&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitRepositoriesResponseWithInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepositoriesResponse("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoriesResponseWithMalformedPayloadReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepositoriesResponse("{\"value\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void ListRepositoriesRequestIncludesDocumentedOptionalParameters()
    {
        using var request = HttpRequestFactory.ListRepositoriesRequest(
            "org name",
            "project name",
            includeAllUrls: true,
            includeHidden: false,
            includeLinks: true);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories?includeAllUrls=true&includeHidden=false&includeLinks=true&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void ListRepositoriesRequestOmitsUnsetOptionalParametersAndProject()
    {
        using var request = HttpRequestFactory.ListRepositoriesRequest("organization");

        Assert.AreEqual(
            "https://dev.azure.com/organization/_apis/git/repositories?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitRepositoryWithoutIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRepository("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoryWithInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepository("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoryWithMalformedPayloadReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepository("{\"id\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void GetRepositoryRequestIncludesDocumentedUriAndOptionalProject()
    {
        using var request = HttpRequestFactory.GetRepositoryRequest("org name", "repo/id", "project name");

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitPullRequestWithoutIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitPullRequest("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestWithMalformedPayloadReturnsFailure()
    {
        var result = APISerializer.DeserializeGitPullRequest("{\"pullRequestId\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void GetPullRequestByIdRequestIncludesDocumentedUriAndOptionalProject()
    {
        using var request = HttpRequestFactory.GetPullRequestByIdRequest("org name", 42, "project name");

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/pullrequests/42?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitPullRequestsResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitPullRequestsResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestsResponseWithMalformedPayloadReturnsFailure()
    {
        var result = APISerializer.DeserializeGitPullRequestsResponse("{\"value\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestsResponseWithInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitPullRequestsResponse("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void GetPullRequestsByProjectRequestEscapesOptionalQueryValues()
    {
        using var request = HttpRequestFactory.GetPullRequestsByProjectRequest(
            "org name",
            "project name",
            includeLinks: true,
            title: "fix & test",
            top: 2);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/pullrequests?searchCriteria.includeLinks=true&searchCriteria.title=fix%20%26%20test&$top=2&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitPullRequest("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitMergeWithoutMergeOperationIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitMerge("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitMergeWithInvalidPayloadReturnsFailure()
    {
        var invalidRoot = APISerializer.DeserializeGitMerge("[]"u8);
        var invalidProperty = APISerializer.DeserializeGitMerge("{\"mergeOperationId\":\"invalid\"}"u8);
        var malformed = APISerializer.DeserializeGitMerge("{\"mergeOperationId\":"u8);
        var malformedRoot = APISerializer.DeserializeGitMerge("{"u8);

        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidProperty.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformedRoot.Status);
    }

    [TestMethod]
    public void DeserializeGitMergeWithValidResponseReturnsSuccess()
    {
        var result = APISerializer.DeserializeGitMerge(
            """{"mergeOperationId":2,"status":"queued","detailedStatus":{"mergeCommitId":"merge-commit"},"parents":["source","target"],"comment":"merge comment"}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(2, result.Value.MergeOperationId);
        Assert.AreEqual("queued", result.Value.Status);
        Assert.AreEqual("merge-commit", result.Value.DetailedStatus!.MergeCommitId);
        CollectionAssert.AreEqual(new[] { "source", "target" }, result.Value.Parents);
        Assert.AreEqual("merge comment", result.Value.Comment);
    }

    [TestMethod]
    public async Task CreateMergeRequestIncludesDocumentedUriAndBody()
    {
        using var request = HttpRequestFactory.CreateMergeRequest(
            "org name",
            "project name",
            "repo/id",
            ["source", "target"],
            "merge comment",
            includeLinks: true);

        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/merges?includeLinks=true&api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);
        Assert.AreEqual("application/json", request.Content!.Headers.ContentType!.MediaType);

        using var body = JsonDocument.Parse(await request.Content.ReadAsByteArrayAsync());
        Assert.AreEqual("merge comment", body.RootElement.GetProperty("comment").GetString());
        Assert.AreEqual("source", body.RootElement.GetProperty("parents")[0].GetString());
        Assert.AreEqual("target", body.RootElement.GetProperty("parents")[1].GetString());
    }

    [TestMethod]
    public void GetMergeRequestIncludesDocumentedUriAndOptionalQueryParameter()
    {
        using var request = HttpRequestFactory.GetMergeRequest(
            "org name",
            "project name",
            "repo/id",
            42,
            includeLinks: true);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/merges/42?includeLinks=true&api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void GetMergeRequestOmitsUnsetOptionalQueryParameter()
    {
        using var request = HttpRequestFactory.GetMergeRequest("organization", "project", "repository", 42);

        Assert.AreEqual(
            "https://dev.azure.com/organization/project/_apis/git/repositories/repository/merges/42?api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);
    }
}