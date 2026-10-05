using System.Text.Json;

namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class APISerializerTests
{
    [TestMethod]
    public void DeserializeBuildsResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeBuildsResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void GetExtensionDataDocumentRequestEscapesRouteValuesAndUsesDocumentedVersion()
    {
        using var request = HttpRequestFactory.GetExtensionDataDocumentRequest(
            "org name",
            "publisher name",
            "extension/name",
            "collection & name",
            "document/id");

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://extmgmt.dev.azure.com/org%20name/_apis/ExtensionManagement/InstalledExtensions/publisher%20name/extension%2Fname/Data/Scopes/Default/Current/Collections/collection%20%26%20name/Documents/document%2Fid?api-version=7.2-preview.1",
            request.RequestUri!.AbsoluteUri);

        using var userScopedRequest = HttpRequestFactory.GetExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "document-id", "User", "Me");
        StringAssert.Contains(userScopedRequest.RequestUri!.AbsoluteUri, "/Scopes/User/Me/");
    }

    [TestMethod]
    public async Task ExtensionDataDocumentMutationRequestsPreserveEtagAndUseDocumentedMethods()
    {
        using var createRequest = HttpRequestFactory.CreateExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"new-document\",\"name\":\"created\"}");
        using var setRequest = HttpRequestFactory.SetExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"set-document\",\"__etag\":-1,\"name\":\"set\"}");
        using var updateRequest = HttpRequestFactory.UpdateExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"update-document\",\"__etag\":17,\"name\":\"updated\"}",
            scopeType: "User", scopeValue: "Me");

        Assert.AreEqual(HttpMethod.Post, createRequest.Method);
        Assert.AreEqual(HttpMethod.Put, setRequest.Method);
        Assert.AreEqual(HttpMethod.Patch, updateRequest.Method);
        Assert.AreEqual(
            "https://extmgmt.dev.azure.com/organization/_apis/ExtensionManagement/InstalledExtensions/publisher/extension/Data/Scopes/Default/Current/Collections/collection/Documents?api-version=7.2-preview.1",
            createRequest.RequestUri!.AbsoluteUri);
        Assert.AreEqual(createRequest.RequestUri.AbsoluteUri, setRequest.RequestUri!.AbsoluteUri);
        Assert.AreEqual(
            "https://extmgmt.dev.azure.com/organization/_apis/ExtensionManagement/InstalledExtensions/publisher/extension/Data/Scopes/User/Me/Collections/collection/Documents?api-version=7.2-preview.1",
            updateRequest.RequestUri!.AbsoluteUri);

        using var createBody = JsonDocument.Parse(await createRequest.Content!.ReadAsByteArrayAsync());
        using var setBody = JsonDocument.Parse(await setRequest.Content!.ReadAsByteArrayAsync());
        using var updateBody = JsonDocument.Parse(await updateRequest.Content!.ReadAsByteArrayAsync());
        Assert.IsFalse(createBody.RootElement.TryGetProperty("__etag", out _));
        Assert.AreEqual(-1, setBody.RootElement.GetProperty("__etag").GetInt32());
        Assert.AreEqual(17, updateBody.RootElement.GetProperty("__etag").GetInt32());
    }

    [TestMethod]
    public void ExtensionDataDocumentDeleteAndGetAllRequestsUseCollectionRoutes()
    {
        using var deleteRequest = HttpRequestFactory.DeleteExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "document-id");
        using var getAllRequest = HttpRequestFactory.GetExtensionDataDocumentsRequest(
            "organization", "publisher", "extension", "collection");

        Assert.AreEqual(HttpMethod.Delete, deleteRequest.Method);
        Assert.IsNull(deleteRequest.Content);
        Assert.AreEqual(HttpMethod.Get, getAllRequest.Method);
        Assert.AreEqual(
            "https://extmgmt.dev.azure.com/organization/_apis/ExtensionManagement/InstalledExtensions/publisher/extension/Data/Scopes/Default/Current/Collections/collection/Documents/document-id?api-version=7.2-preview.1",
            deleteRequest.RequestUri!.AbsoluteUri);
        Assert.AreEqual(
            "https://extmgmt.dev.azure.com/organization/_apis/ExtensionManagement/InstalledExtensions/publisher/extension/Data/Scopes/Default/Current/Collections/collection/Documents?api-version=7.2-preview.1",
            getAllRequest.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeExtensionDataDocumentPreservesCustomProperties()
    {
        var result = APISerializer.DeserializeExtensionDataDocument(
            """{"id":"document-id","__etag":3,"name":"sample","settings":{"enabled":true}}"""u8);
        var stringResult = APISerializer.DeserializeExtensionDataDocument(
            """{"id":"string-document","__etag":4,"value":"text"}""");
        using var documentJson = JsonDocument.Parse(result.Value.Json);
        using var stringDocumentJson = JsonDocument.Parse(stringResult.Value.Json);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual("document-id", result.Value.Response.Id);
        Assert.AreEqual(3, result.Value.Response.ETag);
        Assert.AreEqual("sample", documentJson.RootElement.GetProperty("name").GetString());
        Assert.IsTrue(documentJson.RootElement.GetProperty("settings").GetProperty("enabled").GetBoolean());
        Assert.AreEqual(DeserializationStatus.Success, stringResult.Status);
        Assert.AreEqual("string-document", stringResult.Value.Response.Id);
        Assert.AreEqual("string-document", stringDocumentJson.RootElement.GetProperty("id").GetString());
        Assert.AreEqual("text", stringDocumentJson.RootElement.GetProperty("value").GetString());
    }

    [TestMethod]
    public void DeserializeExtensionDataDocumentDistinguishesInvalidAndIncompletePayloads()
    {
        var empty = APISerializer.DeserializeExtensionDataDocument(ReadOnlySpan<Byte>.Empty);
        var invalidRoot = APISerializer.DeserializeExtensionDataDocument("[]"u8);
        var malformed = APISerializer.DeserializeExtensionDataDocument("{\"id\":"u8);
        var missingId = APISerializer.DeserializeExtensionDataDocument("{\"__etag\":1}"u8);
        var missingETag = APISerializer.DeserializeExtensionDataDocument("{\"id\":\"document-id\"}"u8);

        Assert.AreEqual(DeserializationStatus.Failure, empty.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, missingId.Status);
        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, missingETag.Status);
    }

    [TestMethod]
    public async Task GetExtensionDataDocumentAsyncReturnsDeserializedDocument()
    {
        using var client = new HttpClient(new ExtensionDataDocumentResponseHandler(
            "{\"id\":\"document-id\",\"__etag\":1,\"kind\":\"document\"}"));
        using var request = HttpRequestFactory.GetExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "document-id");

        var result = await Client.GetExtensionDataDocumentAsync(client, request, CancellationToken.None);
        using var documentJson = JsonDocument.Parse(result.Value.Json);

        Assert.AreEqual(ClientStatus.Success, result.Status);
        Assert.AreEqual("document-id", documentJson.RootElement.GetProperty("id").GetString());
        Assert.AreEqual("document", documentJson.RootElement.GetProperty("kind").GetString());
        Assert.AreEqual(1, result.Value.Response.ETag);
    }

    [TestMethod]
    public void DeserializeExtensionDataDocumentsPreservesEachDocumentAndEtag()
    {
        var envelopeJson = """{"documents":[{"id":"one","__etag":2},{"id":"two","__etag":-1}]}"""u8;
        var envelopeReader = new Utf8JsonReader(envelopeJson);
        Assert.IsTrue(envelopeReader.Read());
        var envelope = new ExtensionDataDocumentsEnvelope();
        APISerializer.Deserialize(ref envelopeReader, envelope);
        Assert.HasCount(2, envelope.Documents!);

        var result = APISerializer.DeserializeExtensionDataDocuments(
            """[{"id":"one","__etag":2,"value":1},{"id":"two","__etag":-1,"value":{"ok":true}}]"""u8);
        using var documentsJson = JsonDocument.Parse(result.Value.Json);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.HasCount(2, result.Value.Documents);
        Assert.AreEqual("one", result.Value.Documents[0].Id);
        Assert.AreEqual(2, result.Value.Documents[0].ETag);
        Assert.AreEqual(-1, result.Value.Documents[1].ETag);
        Assert.IsTrue(documentsJson.RootElement[1].GetProperty("value").GetProperty("ok").GetBoolean());

        var missingDocumentFields = APISerializer.DeserializeExtensionDataDocuments("[{}]"u8);
        var malformed = APISerializer.DeserializeExtensionDataDocuments("[{]"u8);
        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, missingDocumentFields.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
    }

    [TestMethod]
    public async Task ExtensionDataDocumentClientMethodsReturnDocumentAndCollectionResults()
    {
        const string singleDocument = "{\"id\":\"document-id\",\"__etag\":8,\"kind\":\"document\"}";
        using var createdClient = new HttpClient(new ExtensionDataDocumentResponseHandler(
            singleDocument,
            System.Net.HttpStatusCode.Created));
        using var client = new HttpClient(new ExtensionDataDocumentResponseHandler(singleDocument));
        using var createRequest = HttpRequestFactory.CreateExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"document-id\",\"__etag\":-1}");
        using var setRequest = HttpRequestFactory.SetExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"document-id\",\"__etag\":-1}");
        using var updateRequest = HttpRequestFactory.UpdateExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "{\"id\":\"document-id\",\"__etag\":-1}");
        using var deleteRequest = HttpRequestFactory.DeleteExtensionDataDocumentRequest(
            "organization", "publisher", "extension", "collection", "document-id");

        var created = await Client.CreateExtensionDataDocumentAsync(createdClient, createRequest, CancellationToken.None);
        var set = await Client.SetExtensionDataDocumentAsync(client, setRequest, CancellationToken.None);
        var updated = await Client.UpdateExtensionDataDocumentAsync(client, updateRequest, CancellationToken.None);
        var deleted = await Client.DeleteExtensionDataDocumentAsync(client, deleteRequest, CancellationToken.None);

        Assert.AreEqual(ClientStatus.Success, created.Status);
        Assert.AreEqual(8, created.Value.Response.ETag);
        Assert.AreEqual(ClientStatus.Success, set.Status);
        Assert.AreEqual(ClientStatus.Success, updated.Status);
        Assert.AreEqual(ClientStatus.Success, deleted.Status);
        Assert.IsTrue(deleted.Value);

        using var listClient = new HttpClient(new ExtensionDataDocumentResponseHandler(
            "[{\"id\":\"document-id\",\"__etag\":8,\"kind\":\"document\"}]"));
        using var getAllRequest = HttpRequestFactory.GetExtensionDataDocumentsRequest(
            "organization", "publisher", "extension", "collection");
        var documents = await Client.GetExtensionDataDocumentsAsync(listClient, getAllRequest, CancellationToken.None);

        Assert.AreEqual(ClientStatus.Success, documents.Status);
        Assert.HasCount(1, documents.Value.Documents);
        Assert.AreEqual(8, documents.Value.Documents[0].ETag);
    }

    private sealed class ExtensionDataDocumentResponseHandler(
        string content,
        System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content),
            });
        }
    }

    [TestMethod]
    public void DeserializeBuildsResponseWithInvalidOrMalformedPayloadReturnsFailure()
    {
        var invalidRoot = APISerializer.DeserializeBuildsResponse("[]"u8);
        var malformed = APISerializer.DeserializeBuildsResponse("{\"value\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
    }

    [TestMethod]
    public void DeserializeBuildsResponseWithDocumentedFieldsReturnsSuccess()
    {
        var result = APISerializer.DeserializeBuildsResponse(
            """{"count":1,"value":[{"id":17,"buildNumber":"2026.10.05.1","status":"completed","result":"succeeded","sourceBranch":"refs/heads/main","project":{"id":"project-id","name":"Project"},"definition":{"id":4,"name":"CI"},"repository":{"id":"repository-id","type":"TfsGit","url":"https://dev.azure.com/org/project/_git/repo"},"tags":["release"]}]}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(1, result.Value.Count);
        var build = result.Value.Value![0];
        Assert.AreEqual(17, build.Id);
        Assert.AreEqual("2026.10.05.1", build.BuildNumber);
        Assert.AreEqual("completed", build.Status);
        Assert.AreEqual("succeeded", build.Result);
        Assert.AreEqual("Project", build.Project!.Name);
        Assert.AreEqual(4, build.Definition!.Id);
        Assert.AreEqual("repository-id", build.Repository!.Id);
        CollectionAssert.AreEqual(new[] { "release" }, build.Tags);
    }

    [TestMethod]
    public void DeserializeBuildWithoutIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeBuild("{\"buildNumber\":\"1\"}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeBuildWithMalformedPayloadReturnsFailure()
    {
        var empty = APISerializer.DeserializeBuild(ReadOnlySpan<Byte>.Empty);
        var invalidRoot = APISerializer.DeserializeBuild("[]"u8);
        var malformed = APISerializer.DeserializeBuild("{\"id\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, empty.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
    }

    [TestMethod]
    public void DeserializeBuildWithDocumentedFieldsReturnsSuccess()
    {
        var result = APISerializer.DeserializeBuild(
            """{"id":42,"buildNumber":"2026.10.05.1","status":"completed","result":"succeeded","project":{"id":"project-id","name":"Project"},"definition":{"id":4,"name":"CI"},"repository":{"id":"repository-id"},"tags":["release"]}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(42, result.Value.Id);
        Assert.AreEqual("2026.10.05.1", result.Value.BuildNumber);
        Assert.AreEqual("Project", result.Value.Project!.Name);
        Assert.AreEqual(4, result.Value.Definition!.Id);
        Assert.AreEqual("repository-id", result.Value.Repository!.Id);
        Assert.AreEqual("completed", result.Value.Status);
        Assert.AreEqual("succeeded", result.Value.Result);
        CollectionAssert.AreEqual(new[] { "release" }, result.Value.Tags);
    }

    [TestMethod]
    public void ListBuildsRequestIncludesDocumentedFiltersAndEscapesValues()
    {
        var maxTime = new DateTimeOffset(2026, 10, 5, 12, 30, 0, TimeSpan.Zero);
        var minTime = new DateTimeOffset(2026, 10, 4, 12, 30, 0, TimeSpan.Zero);
        using var request = HttpRequestFactory.ListBuildsRequest(
            "org name",
            "project name",
            top: 25,
            branchName: "refs/heads/feature & test",
            buildIds: [10, 11],
            buildNumber: "build 42",
            continuationToken: "next +token",
            definitions: [2, 3],
            deletedFilter: "excludeDeleted",
            maxBuildsPerDefinition: 4,
            maxTime: maxTime,
            minTime: minTime,
            properties: ["buildOption", "requestedFor"],
            queryOrder: "finishTimeDescending",
            queues: [5, 6],
            reasonFilter: "manual",
            repositoryId: "repo/id",
            repositoryType: "TfsGit",
            requestedFor: "user@example.com",
            resultFilter: "succeeded",
            statusFilter: "completed",
            tagFilters: ["tag one", "tag&two"]);

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/build/builds?$top=25&branchName=refs%2Fheads%2Ffeature%20%26%20test&buildIds=10%2C11&buildNumber=build%2042&continuationToken=next%20%2Btoken&definitions=2%2C3&deletedFilter=excludeDeleted&maxBuildsPerDefinition=4&maxTime=2026-10-05T12%3A30%3A00.0000000%2B00%3A00&minTime=2026-10-04T12%3A30%3A00.0000000%2B00%3A00&properties=buildOption%2CrequestedFor&queryOrder=finishTimeDescending&queues=5%2C6&reasonFilter=manual&repositoryId=repo%2Fid&repositoryType=TfsGit&requestedFor=user%40example.com&resultFilter=succeeded&statusFilter=completed&tagFilters=tag%20one%2Ctag%26two&api-version=7.2-preview.8",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void ListBuildsRequestOmitsUnsetOptionalFilters()
    {
        using var request = HttpRequestFactory.ListBuildsRequest("organization", "project");

        Assert.AreEqual(
            "https://dev.azure.com/organization/project/_apis/build/builds?api-version=7.2-preview.8",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public async Task ListBuildsAsyncReturnsContinuationHeaderForNextRequest()
    {
        using var client = new HttpClient(new BuildResponseHandler("next +page"));
        using var request = HttpRequestFactory.ListBuildsRequest("organization", "project", top: 1);

        var result = await Client.ListBuildsAsync(client, request, CancellationToken.None);

        Assert.AreEqual(ClientStatus.Success, result.Status);
        Assert.IsNotNull(result.Value.Response.Value);
        Assert.AreEqual("next +page", result.Value.ContinuationToken);
        using var nextRequest = HttpRequestFactory.ListBuildsRequest("organization", "project", top: 1, continuationToken: result.Value.ContinuationToken);
        StringAssert.Contains(nextRequest.RequestUri!.Query, "continuationToken=next%20%2Bpage");
    }

    [TestMethod]
    public async Task ListBuildsAsyncWithoutContinuationHeaderReturnsNullToken()
    {
        using var client = new HttpClient(new BuildResponseHandler(null));
        using var request = HttpRequestFactory.ListBuildsRequest("organization", "project");

        var result = await Client.ListBuildsAsync(client, request, CancellationToken.None);

        Assert.AreEqual(ClientStatus.Success, result.Status);
        Assert.IsNotNull(result.Value.Response.Value);
        Assert.IsNull(result.Value.ContinuationToken);
    }

    private sealed class BuildResponseHandler(string? continuationToken) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("{\"count\":0,\"value\":[]}"),
            };
            if (continuationToken is not null)
                response.Headers.Add("x-ms-continuationtoken", continuationToken);
            return Task.FromResult(response);
        }
    }

    [TestMethod]
    public void GetBuildRequestIncludesDocumentedRouteAndEscapesOptionalPropertyFilters()
    {
        using var request = HttpRequestFactory.GetBuildRequest(
            "org name",
            "project name",
            42,
            "tag one&tag/two");

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/build/builds/42?propertyFilters=tag%20one%26tag%2Ftwo&api-version=7.2-preview.8",
            request.RequestUri!.AbsoluteUri);

        using var minimalRequest = HttpRequestFactory.GetBuildRequest("organization", "project", 7);
        Assert.AreEqual(
            "https://dev.azure.com/organization/project/_apis/build/builds/7?api-version=7.2-preview.8",
            minimalRequest.RequestUri!.AbsoluteUri);
    }

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
    public void DeserializeGitRefWithoutNameReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRef("{\"isLocked\":true}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRefWithMalformedPayloadReturnsFailure()
    {
        var malformed = APISerializer.DeserializeGitRef("{\"name\":"u8);
        var invalidRoot = APISerializer.DeserializeGitRef("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
    }

    [TestMethod]
    public void DeserializeGitRefWithDocumentedResponseReturnsSuccess()
    {
        var result = APISerializer.DeserializeGitRef(
            """{"name":"refs/heads/master","objectId":"commit-id","isLocked":true,"isLockedBy":{"id":"identity-id"},"creator":{"displayName":"Dev"},"url":"https://dev.azure.com/org/project/_apis/git/refs"}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual("refs/heads/master", result.Value.Name);
        Assert.AreEqual("commit-id", result.Value.ObjectId);
        Assert.IsTrue(result.Value.IsLocked);
        Assert.AreEqual("identity-id", result.Value.IsLockedBy!.Id);
    }

    [TestMethod]
    public async Task UpdateRefRequestIncludesDocumentedMethodUriAndBody()
    {
        using var request = HttpRequestFactory.UpdateRefRequest(
            "org name",
            "repo/id",
            "heads/main",
            new GitRefUpdate
            {
                IsLocked = true,
                Name = "refs/heads/main",
                NewObjectId = "new-object-id",
                OldObjectId = "old-object-id",
                RepositoryId = "repository-id",
            },
            "project name",
            "project/id");

        Assert.AreEqual(HttpMethod.Patch, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/refs?filter=heads%2Fmain&projectId=project%2Fid&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
        Assert.AreEqual("application/json", request.Content!.Headers.ContentType!.MediaType);

        using var body = JsonDocument.Parse(await request.Content.ReadAsByteArrayAsync());
        Assert.IsTrue(body.RootElement.GetProperty("isLocked").GetBoolean());
        Assert.AreEqual("refs/heads/main", body.RootElement.GetProperty("name").GetString());
        Assert.AreEqual("new-object-id", body.RootElement.GetProperty("newObjectId").GetString());
        Assert.AreEqual("old-object-id", body.RootElement.GetProperty("oldObjectId").GetString());
        Assert.AreEqual("repository-id", body.RootElement.GetProperty("repositoryId").GetString());
        Assert.AreEqual(5, body.RootElement.EnumerateObject().Count());

        using var minimalRequest = HttpRequestFactory.UpdateRefRequest(
            "organization",
            "repository",
            "heads/main",
            new GitRefUpdate { IsLocked = false });
        Assert.AreEqual(
            "https://dev.azure.com/organization/_apis/git/repositories/repository/refs?filter=heads%2Fmain&api-version=7.2-preview.2",
            minimalRequest.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public async Task UpdateRefsRequestIncludesDocumentedMethodUriAndArrayBody()
    {
        using var request = HttpRequestFactory.UpdateRefsRequest(
            "org name",
            "repo/id",
            [new GitRefUpdate
            {
                Name = "refs/heads/main",
                OldObjectId = "old-object-id",
                NewObjectId = "new-object-id",
            }],
            "project name",
            "project/id");

        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/refs?projectId=project%2Fid&api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
        Assert.AreEqual("application/json", request.Content!.Headers.ContentType!.MediaType);

        using var body = JsonDocument.Parse(await request.Content.ReadAsByteArrayAsync());
        Assert.AreEqual(JsonValueKind.Array, body.RootElement.ValueKind);
        Assert.HasCount(1, body.RootElement.EnumerateArray());
        var update = body.RootElement[0];
        Assert.AreEqual("refs/heads/main", update.GetProperty("name").GetString());
        Assert.AreEqual("old-object-id", update.GetProperty("oldObjectId").GetString());
        Assert.AreEqual("new-object-id", update.GetProperty("newObjectId").GetString());
        Assert.AreEqual(3, update.EnumerateObject().Count());

        using var minimalRequest = HttpRequestFactory.UpdateRefsRequest(
            "organization",
            "repository",
            [new GitRefUpdate { Name = "refs/heads/main" }]);
        Assert.AreEqual(
            "https://dev.azure.com/organization/_apis/git/repositories/repository/refs?api-version=7.2-preview.2",
            minimalRequest.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitRefUpdateResultsResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRefUpdateResultsResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRefUpdateResultsResponseWithMalformedPayloadReturnsFailure()
    {
        var empty = APISerializer.DeserializeGitRefUpdateResultsResponse(ReadOnlySpan<Byte>.Empty);
        var invalidRoot = APISerializer.DeserializeGitRefUpdateResultsResponse("[]"u8);
        var malformed = APISerializer.DeserializeGitRefUpdateResultsResponse("{\"value\":"u8);

        Assert.AreEqual(DeserializationStatus.Failure, empty.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
    }

    [TestMethod]
    public void DeserializeGitRefUpdateResultsResponseWithDocumentedFieldsReturnsSuccess()
    {
        var result = APISerializer.DeserializeGitRefUpdateResultsResponse(
            """{"count":1,"value":[{"customMessage":"Updated","isLocked":false,"name":"refs/heads/main","newObjectId":"new-object-id","oldObjectId":"old-object-id","rejectedBy":"policy","repositoryId":"repository-id","success":true,"updateStatus":"succeeded"}]}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(1, result.Value.Count);
        Assert.HasCount(1, result.Value.Value!);
        var update = result.Value.Value![0];
        Assert.AreEqual("Updated", update.CustomMessage);
        Assert.IsFalse(update.IsLocked);
        Assert.AreEqual("refs/heads/main", update.Name);
        Assert.AreEqual("new-object-id", update.NewObjectId);
        Assert.AreEqual("old-object-id", update.OldObjectId);
        Assert.AreEqual("policy", update.RejectedBy);
        Assert.AreEqual("repository-id", update.RepositoryId);
        Assert.IsTrue(update.Success);
        Assert.AreEqual("succeeded", update.UpdateStatus);
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
    public void DeserializeGitPullRequestStatusesResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitPullRequestStatusesResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestStatusesResponseWithMalformedOrInvalidRootReturnsFailure()
    {
        var malformed = APISerializer.DeserializeGitPullRequestStatusesResponse("{\"value\":"u8);
        var invalidRoot = APISerializer.DeserializeGitPullRequestStatusesResponse("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestStatusesResponseDeserializesSupportedProperties()
    {
        var result = APISerializer.DeserializeGitPullRequestStatusesResponse(
            """{"value":[{"id":1,"state":"succeeded","context":{"name":"build","genre":"ci"},"creationDate":"2017-09-19T14:50:27.064405Z","createdBy":{"id":"identity-id"},"properties":{"count":2,"keys":["score","label"],"values":["7","ci"]}}],"count":1}"""u8);

        Assert.AreEqual(DeserializationStatus.Success, result.Status);
        Assert.AreEqual(1, result.Value.Count);
        var status = result.Value.Value![0];
        Assert.AreEqual(1, status.Id);
        Assert.AreEqual("succeeded", status.State);
        Assert.AreEqual("build", status.Context!.Name);
        Assert.AreEqual("identity-id", status.CreatedBy!.Id);
        Assert.AreEqual(2, status.Properties!.Count);
        var keys = status.Properties.Keys!;
        Assert.HasCount(2, keys);
        CollectionAssert.AreEqual(new[] { "7", "ci" }, status.Properties.Values);
    }

    [TestMethod]
    public void GetPullRequestStatusesRequestIncludesDocumentedRoute()
    {
        using var request = HttpRequestFactory.GetPullRequestStatusesRequest(
            "org name",
            "repo/id",
            42,
            "project name");

        Assert.AreEqual(HttpMethod.Get, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/pullRequests/42/statuses?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
    }

    [TestMethod]
    public void DeserializeGitPullRequestStatusRequiresContextName()
    {
        var missingContext = APISerializer.DeserializeGitPullRequestStatus("{\"state\":\"succeeded\"}"u8);
        var missingName = APISerializer.DeserializeGitPullRequestStatus("{\"context\":{}}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, missingContext.Status);
        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, missingName.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestStatusRejectsMalformedOrInvalidRoot()
    {
        var malformed = APISerializer.DeserializeGitPullRequestStatus("{\"context\":{\"name\":"u8);
        var invalidRoot = APISerializer.DeserializeGitPullRequestStatus("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, malformed.Status);
        Assert.AreEqual(DeserializationStatus.Failure, invalidRoot.Status);
    }

    [TestMethod]
    public async Task CreatePullRequestStatusRequestIncludesDocumentedRouteAndBody()
    {
        using var request = HttpRequestFactory.CreatePullRequestStatusRequest(
            "org name",
            "repo/id",
            42,
            new GitPullRequestStatus
            {
                Context = new GitStatusContext { Name = "build", Genre = "ci" },
                State = "succeeded",
                Description = "Build passed",
                IterationId = 1,
                TargetUrl = "https://ci.example/build/7",
            },
            "project name");

        Assert.AreEqual(HttpMethod.Post, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/pullRequests/42/statuses?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
        Assert.AreEqual("application/json", request.Content!.Headers.ContentType!.MediaType);

        using var body = JsonDocument.Parse(await request.Content.ReadAsByteArrayAsync());
        Assert.AreEqual("build", body.RootElement.GetProperty("context").GetProperty("name").GetString());
        Assert.AreEqual("succeeded", body.RootElement.GetProperty("state").GetString());
        Assert.AreEqual("Build passed", body.RootElement.GetProperty("description").GetString());
        Assert.AreEqual(1, body.RootElement.GetProperty("iterationId").GetInt32());
        Assert.AreEqual("https://ci.example/build/7", body.RootElement.GetProperty("targetUrl").GetString());
    }

    [TestMethod]
    public void DeletePullRequestStatusRequestIncludesDocumentedMethodAndRoute()
    {
        using var request = HttpRequestFactory.DeletePullRequestStatusRequest(
            "org name",
            "repo/id",
            42,
            7,
            "project name");

        Assert.AreEqual(HttpMethod.Delete, request.Method);
        Assert.AreEqual(
            "https://dev.azure.com/org%20name/project%20name/_apis/git/repositories/repo%2Fid/pullRequests/42/statuses/7?api-version=7.2-preview.2",
            request.RequestUri!.AbsoluteUri);
        Assert.IsNull(request.Content);
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