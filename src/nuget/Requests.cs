using System.Globalization;

namespace Pingmint.AzureDevOps;

public static class Requests
{
    private const string ExtensionDataApiVersion = "7.2-preview.1";

    /// <summary>
    /// Retrieves a document from an extension data collection by its ID.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection containing the document.</param>
    /// <param name="documentId">The ID of the document to retrieve.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Get a document by ID operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops">the official Azure DevOps data storage documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetExtensionDataDocumentRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string documentId,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue, documentId);
        return CreateExtensionDataRequest(HttpMethod.Get, url);
    }

    /// <summary>
    /// Creates a document in an extension data collection.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="documentJson">The JSON document to create. If it omits <c>id</c>, the service generates an ID.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Create a document operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#create-a-document">the official Azure DevOps data storage documentation</see>.
    /// The document body, including any supplied <c>__etag</c>, is sent unchanged.
    /// </remarks>
    public static HttpRequestMessage CreateExtensionDataDocumentRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string documentJson,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue);
        return CreateExtensionDataRequest(HttpMethod.Post, url, documentJson);
    }

    /// <summary>
    /// Creates or replaces a document in an extension data collection.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="documentJson">The JSON document to set, including its <c>id</c> and any <c>__etag</c>.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Set a document operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#set-a-document-update-or-create">the official Azure DevOps data storage documentation</see>.
    /// The body is sent unchanged so the service can apply the supplied <c>__etag</c> concurrency behavior, including <c>-1</c> for last-write-wins.
    /// </remarks>
    public static HttpRequestMessage SetExtensionDataDocumentRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string documentJson,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue);
        return CreateExtensionDataRequest(HttpMethod.Put, url, documentJson);
    }

    /// <summary>
    /// Updates an existing document in an extension data collection.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="documentJson">The existing JSON document to update, including its <c>id</c> and current <c>__etag</c>.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Update a document operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#update-a-document">the official Azure DevOps data storage documentation</see>.
    /// The body is sent unchanged. The service compares <c>__etag</c> with the stored version; <c>-1</c> requests last-write-wins behavior.
    /// </remarks>
    public static HttpRequestMessage UpdateExtensionDataDocumentRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string documentJson,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue);
        return CreateExtensionDataRequest(HttpMethod.Patch, url, documentJson);
    }

    /// <summary>
    /// Deletes a document from an extension data collection by its ID.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="documentId">The ID of the document to delete.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Delete a document operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#delete-a-document">the official Azure DevOps data storage documentation</see>.
    /// This operation has no document body or <c>__etag</c> parameter.
    /// </remarks>
    public static HttpRequestMessage DeleteExtensionDataDocumentRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string documentId,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue, documentId);
        return CreateExtensionDataRequest(HttpMethod.Delete, url);
    }

    /// <summary>
    /// Retrieves all documents in an extension data collection.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="publisherName">The name of the publisher that owns the extension.</param>
    /// <param name="extensionName">The name of the extension.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="scopeType">The scope type. Defaults to the extension-wide scope.</param>
    /// <param name="scopeValue">The scope value. Defaults to the current extension scope.</param>
    /// <returns>An HTTP request message for the Get all documents in a collection operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#get-all-documents-in-a-collection">the official Azure DevOps data storage documentation</see>.
    /// Each returned document retains its own <c>__etag</c>.
    /// </remarks>
    public static HttpRequestMessage GetExtensionDataDocumentsRequest(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string scopeType = "Default",
        string scopeValue = "Current")
    {
        var url = GetExtensionDataDocumentsUrl(organization, publisherName, extensionName, collectionName, scopeType, scopeValue);
        return CreateExtensionDataRequest(HttpMethod.Get, url);
    }

    private static string GetExtensionDataDocumentsUrl(
        string organization,
        string publisherName,
        string extensionName,
        string collectionName,
        string scopeType,
        string scopeValue,
        string? documentId = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var publisherSegment = Uri.EscapeDataString(publisherName);
        var extensionSegment = Uri.EscapeDataString(extensionName);
        var scopeTypeSegment = Uri.EscapeDataString(scopeType);
        var scopeValueSegment = Uri.EscapeDataString(scopeValue);
        var collectionSegment = Uri.EscapeDataString(collectionName);
        var documentSegment = documentId is null ? string.Empty : $"/{Uri.EscapeDataString(documentId)}";
        return $"https://extmgmt.dev.azure.com/{organizationSegment}/_apis/ExtensionManagement/InstalledExtensions/{publisherSegment}/{extensionSegment}/Data/Scopes/{scopeTypeSegment}/{scopeValueSegment}/Collections/{collectionSegment}/Documents{documentSegment}?api-version={ExtensionDataApiVersion}";
    }

    private static HttpRequestMessage CreateExtensionDataRequest(HttpMethod method, string url, string? documentJson = null)
    {
        var request = new HttpRequestMessage(method, new Uri(url, UriKind.Absolute));
        if (documentJson is not null)
            request.Content = new StringContent(documentJson, System.Text.Encoding.UTF8, "application/json");

        return request;
    }

    /// <summary>
    /// Gets a list of builds.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">The project ID or project name.</param>
    /// <param name="top">The optional maximum number of builds to return.</param>
    /// <param name="branchName">The optional branch name to filter builds by.</param>
    /// <param name="buildIds">The optional comma-delimited list of build IDs to retrieve.</param>
    /// <param name="buildNumber">The optional build number filter. Append an asterisk for a prefix search.</param>
    /// <param name="continuationToken">The optional token from a previous call used to retrieve the next set of builds.</param>
    /// <param name="definitions">The optional comma-delimited list of definition IDs.</param>
    /// <param name="deletedFilter">The optional filter for deleted builds.</param>
    /// <param name="maxBuildsPerDefinition">The optional maximum number of builds to return per definition.</param>
    /// <param name="maxTime">The optional upper time bound, interpreted according to <paramref name="queryOrder"/>.</param>
    /// <param name="minTime">The optional lower time bound, interpreted according to <paramref name="queryOrder"/>.</param>
    /// <param name="properties">The optional comma-delimited list of build properties to retrieve.</param>
    /// <param name="queryOrder">The optional ordering used for builds and time filters.</param>
    /// <param name="queues">The optional comma-delimited list of queue IDs.</param>
    /// <param name="reasonFilter">The optional build reason filter.</param>
    /// <param name="repositoryId">The optional repository ID filter.</param>
    /// <param name="repositoryType">The optional repository type filter.</param>
    /// <param name="requestedFor">The optional user to filter builds by.</param>
    /// <param name="resultFilter">The optional build result filter.</param>
    /// <param name="statusFilter">The optional build status filter.</param>
    /// <param name="tagFilters">The optional comma-delimited list of build tags.</param>
    /// <returns>An HTTP request message for the Builds - List operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.8.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.2">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage ListBuildsRequest(
        string organization,
        string project,
        int? top = null,
        string? branchName = null,
        IEnumerable<int>? buildIds = null,
        string? buildNumber = null,
        string? continuationToken = null,
        IEnumerable<int>? definitions = null,
        string? deletedFilter = null,
        int? maxBuildsPerDefinition = null,
        DateTimeOffset? maxTime = null,
        DateTimeOffset? minTime = null,
        IEnumerable<string>? properties = null,
        string? queryOrder = null,
        IEnumerable<int>? queues = null,
        string? reasonFilter = null,
        string? repositoryId = null,
        string? repositoryType = null,
        string? requestedFor = null,
        string? resultFilter = null,
        string? statusFilter = null,
        IEnumerable<string>? tagFilters = null)
    {
        var queryParameters = new List<string>();

        void AddQueryParameter(string name, string value)
        {
            queryParameters.Add($"{name}={Uri.EscapeDataString(value)}");
        }

        if (top is not null)
            AddQueryParameter("$top", top.Value.ToString(CultureInfo.InvariantCulture));
        if (branchName is not null)
            AddQueryParameter("branchName", branchName);
        if (buildIds is not null)
            AddQueryParameter("buildIds", string.Join(',', buildIds));
        if (buildNumber is not null)
            AddQueryParameter("buildNumber", buildNumber);
        if (continuationToken is not null)
            AddQueryParameter("continuationToken", continuationToken);
        if (definitions is not null)
            AddQueryParameter("definitions", string.Join(',', definitions));
        if (deletedFilter is not null)
            AddQueryParameter("deletedFilter", deletedFilter);
        if (maxBuildsPerDefinition is not null)
            AddQueryParameter("maxBuildsPerDefinition", maxBuildsPerDefinition.Value.ToString(CultureInfo.InvariantCulture));
        if (maxTime is not null)
            AddQueryParameter("maxTime", maxTime.Value.ToString("O", CultureInfo.InvariantCulture));
        if (minTime is not null)
            AddQueryParameter("minTime", minTime.Value.ToString("O", CultureInfo.InvariantCulture));
        if (properties is not null)
            AddQueryParameter("properties", string.Join(',', properties));
        if (queryOrder is not null)
            AddQueryParameter("queryOrder", queryOrder);
        if (queues is not null)
            AddQueryParameter("queues", string.Join(',', queues));
        if (reasonFilter is not null)
            AddQueryParameter("reasonFilter", reasonFilter);
        if (repositoryId is not null)
            AddQueryParameter("repositoryId", repositoryId);
        if (repositoryType is not null)
            AddQueryParameter("repositoryType", repositoryType);
        if (requestedFor is not null)
            AddQueryParameter("requestedFor", requestedFor);
        if (resultFilter is not null)
            AddQueryParameter("resultFilter", resultFilter);
        if (statusFilter is not null)
            AddQueryParameter("statusFilter", statusFilter);
        if (tagFilters is not null)
            AddQueryParameter("tagFilters", string.Join(',', tagFilters));

        queryParameters.Add("api-version=7.2-preview.8");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = Uri.EscapeDataString(project);
        var url = $"https://dev.azure.com/{organizationSegment}/{projectSegment}/_apis/build/builds?{string.Join('&', queryParameters)}";
        return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
    }

    /// <summary>
    /// Gets a build.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">The project ID or project name.</param>
    /// <param name="buildId">The ID of the build to retrieve.</param>
    /// <param name="propertyFilters">The optional property filters.</param>
    /// <returns>An HTTP request message for the Builds - Get operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.8.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.2">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetBuildRequest(
        string organization,
        string project,
        int buildId,
        string? propertyFilters = null)
    {
        var queryParameters = new List<string>();

        if (propertyFilters is not null)
            queryParameters.Add($"propertyFilters={Uri.EscapeDataString(propertyFilters)}");

        queryParameters.Add("api-version=7.2-preview.8");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = Uri.EscapeDataString(project);
        var url = $"https://dev.azure.com/{organizationSegment}/{projectSegment}/_apis/build/builds/{buildId.ToString(CultureInfo.InvariantCulture)}?{string.Join('&', queryParameters)}";
        return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
    }

    /// <summary>
    /// Queries the specified repository for its refs.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The name or ID of the repository.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <param name="top">The optional maximum number of refs to return. It cannot be greater than 1000; when omitted with a continuation token, it defaults to 100.</param>
    /// <param name="continuationToken">The optional continuation token used for pagination.</param>
    /// <param name="filter">The optional filter to apply to refs by prefix.</param>
    /// <param name="filterContains">The optional filter to apply to refs by substring.</param>
    /// <param name="includeLinks">Whether to include reference links. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <param name="includeMyBranches">Whether to include only branches owned or favorited by the user and the default branch. This parameter is optional, defaults to <see langword="false"/>, and cannot be combined with <paramref name="filter"/>.</param>
    /// <param name="includeStatuses">Whether to include up to the first 1000 commit statuses for each ref. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <param name="includeTargetBranches">Whether to include target branches defined by pull_request_targets.yml. This parameter is optional.</param>
    /// <param name="latestStatusesOnly">Whether to include only the tip commit status for each ref. This parameter is optional, requires <paramref name="includeStatuses"/>, and defaults to <see langword="false"/>.</param>
    /// <param name="peelTags">Whether to populate PeeledObjectId for annotated tags. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <returns>An HTTP request message for the List Refs operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/list?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage ListRefsRequest(
        string organization,
        string repositoryId,
        string? project = null,
        int? top = null,
        string? continuationToken = null,
        string? filter = null,
        string? filterContains = null,
        bool? includeLinks = null,
        bool? includeMyBranches = null,
        bool? includeStatuses = null,
        bool? includeTargetBranches = null,
        bool? latestStatusesOnly = null,
        bool? peelTags = null)
    {
        var queryParameters = new List<string>();

        void AddQueryParameter(string name, string value)
        {
            queryParameters.Add($"{name}={Uri.EscapeDataString(value)}");
        }

        if (filter is not null)
            AddQueryParameter("filter", filter);
        if (includeLinks is not null)
            AddQueryParameter("includeLinks", includeLinks.Value ? "true" : "false");
        if (includeStatuses is not null)
            AddQueryParameter("includeStatuses", includeStatuses.Value ? "true" : "false");
        if (includeMyBranches is not null)
            AddQueryParameter("includeMyBranches", includeMyBranches.Value ? "true" : "false");
        if (latestStatusesOnly is not null)
            AddQueryParameter("latestStatusesOnly", latestStatusesOnly.Value ? "true" : "false");
        if (peelTags is not null)
            AddQueryParameter("peelTags", peelTags.Value ? "true" : "false");
        if (filterContains is not null)
            AddQueryParameter("filterContains", filterContains);
        if (top is not null)
            AddQueryParameter("$top", top.Value.ToString(CultureInfo.InvariantCulture));
        if (continuationToken is not null)
            AddQueryParameter("continuationToken", continuationToken);
        if (includeTargetBranches is not null)
            AddQueryParameter("includeTargetBranches", includeTargetBranches.Value ? "true" : "false");

        queryParameters.Add("api-version=7.2-preview.2");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/refs?{string.Join('&', queryParameters)}";
        return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
    }

    /// <summary>
    /// Locks or unlocks a branch.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The name or ID of the repository.</param>
    /// <param name="filter">The name of the branch to lock or unlock.</param>
    /// <param name="update">The Git ref update properties.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <param name="projectId">The ID or name of the team project. This parameter is optional when the repository ID is specified.</param>
    /// <returns>An HTTP request message for the Update Ref operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/update-ref?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage UpdateRefRequest(
        string organization,
        string repositoryId,
        string filter,
        GitRefUpdate update,
        string? project = null,
        string? projectId = null)
    {
        var queryParameters = new List<string>
        {
            $"filter={Uri.EscapeDataString(filter)}",
        };

        if (projectId is not null)
            queryParameters.Add($"projectId={Uri.EscapeDataString(projectId)}");

        queryParameters.Add("api-version=7.2-preview.2");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/refs?{string.Join('&', queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Patch, new Uri(url, UriKind.Absolute));

        using var bodyStream = new MemoryStream();
        using (var writer = new System.Text.Json.Utf8JsonWriter(bodyStream))
            APISerializer.Serialize(writer, update);

        request.Content = new ByteArrayContent(bodyStream.ToArray());
        request.Content.Headers.ContentType = new("application/json");
        return request;
    }

    /// <summary>
    /// Creates, updates, or deletes refs (branches) in a repository. Updating a ref requires both the old and new commit IDs to avoid race conditions.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The name or ID of the repository.</param>
    /// <param name="updates">The list of ref updates to attempt to perform.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <param name="projectId">The ID or name of the team project. This parameter is optional if a repository ID is specified.</param>
    /// <returns>An HTTP request message for the Update Refs operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/update-refs?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage UpdateRefsRequest(
        string organization,
        string repositoryId,
        IEnumerable<GitRefUpdate> updates,
        string? project = null,
        string? projectId = null)
    {
        var queryParameters = new List<string>();

        if (projectId is not null)
            queryParameters.Add($"projectId={Uri.EscapeDataString(projectId)}");

        queryParameters.Add("api-version=7.2-preview.2");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/refs?{string.Join('&', queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url, UriKind.Absolute));

        using var bodyStream = new MemoryStream();
        using (var writer = new System.Text.Json.Utf8JsonWriter(bodyStream))
        {
            writer.WriteStartArray();
            foreach (var update in updates)
                APISerializer.Serialize(writer, update);
            writer.WriteEndArray();
        }

        request.Content = new ByteArrayContent(bodyStream.ToArray());
        request.Content.Headers.ContentType = new("application/json");
        return request;
    }

    /// <summary>
    /// Retrieves Git repositories.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <param name="includeAllUrls">Whether to include all remote URLs. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <param name="includeHidden">Whether to include hidden repositories. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <param name="includeLinks">Whether to include reference links. This parameter is optional and defaults to <see langword="false"/>.</param>
    /// <returns>An HTTP request message for the List Repositories operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/repositories/list?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage ListRepositoriesRequest(
        string organization,
        string? project = null,
        bool? includeAllUrls = null,
        bool? includeHidden = null,
        bool? includeLinks = null)
    {
        var queryParameters = new List<string>();

        if (includeAllUrls is not null)
            queryParameters.Add($"includeAllUrls={(includeAllUrls.Value ? "true" : "false")}");
        if (includeHidden is not null)
            queryParameters.Add($"includeHidden={(includeHidden.Value ? "true" : "false")}");
        if (includeLinks is not null)
            queryParameters.Add($"includeLinks={(includeLinks.Value ? "true" : "false")}");

        queryParameters.Add("api-version=7.2-preview.2");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories?{string.Join('&', queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
        return request;
    }

    /// <summary>
    /// Retrieves a Git repository.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The name or ID of the repository.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Get Repository operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/repositories/get-repository?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetRepositoryRequest(
        string organization,
        string repositoryId,
        string? project = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}?api-version=7.2-preview.2";
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
        return request;
    }

    /// <summary>
    /// Retrieves a pull request.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="pullRequestId">The ID of the pull request to retrieve.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Get Pull Request By Id operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-requests/get-pull-request-by-id?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetPullRequestByIdRequest(
        string organization,
        int pullRequestId,
        string? project = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/pullrequests/{pullRequestId}?api-version=7.2-preview.2";
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
        return request;
    }

    /// <summary>
    /// Gets all statuses associated with a pull request.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">The ID of the pull request.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <returns>An HTTP request message for the List Pull Request Statuses operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/list?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetPullRequestStatusesRequest(
        string organization,
        string repositoryId,
        int pullRequestId,
        string? project = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/pullRequests/{pullRequestId}/statuses?api-version=7.2-preview.2";
        return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
    }

    /// <summary>
    /// Creates a pull request status.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">The ID of the pull request.</param>
    /// <param name="status">The status to create. The only required field is <c>Context.Name</c>.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Create Pull Request Status operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/create?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage CreatePullRequestStatusRequest(
        string organization,
        string repositoryId,
        int pullRequestId,
        GitPullRequestStatus status,
        string? project = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/pullRequests/{pullRequestId}/statuses?api-version=7.2-preview.2";
        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url, UriKind.Absolute));

        using var bodyStream = new MemoryStream();
        using (var writer = new System.Text.Json.Utf8JsonWriter(bodyStream))
            APISerializer.Serialize(writer, status);

        request.Content = new ByteArrayContent(bodyStream.ToArray());
        request.Content.Headers.ContentType = new("application/json");
        return request;
    }

    /// <summary>
    /// Deletes a pull request status.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="repositoryId">The repository ID of the pull request's target branch.</param>
    /// <param name="pullRequestId">The ID of the pull request.</param>
    /// <param name="statusId">The ID of the pull request status.</param>
    /// <param name="project">The project ID or project name. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Delete Pull Request Status operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/delete?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage DeletePullRequestStatusRequest(
        string organization,
        string repositoryId,
        int pullRequestId,
        int statusId,
        string? project = null)
    {
        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = project is null ? null : $"/{Uri.EscapeDataString(project)}";
        var repositorySegment = Uri.EscapeDataString(repositoryId);
        var url = $"https://dev.azure.com/{organizationSegment}{projectSegment}/_apis/git/repositories/{repositorySegment}/pullRequests/{pullRequestId}/statuses/{statusId}?api-version=7.2-preview.2";
        return new HttpRequestMessage(HttpMethod.Delete, new Uri(url, UriKind.Absolute));
    }

    /// <summary>
    /// Retrieves pull requests that match the specified criteria. Descriptions in the results are truncated to 400 characters.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">The project ID or project name.</param>
    /// <param name="creatorId">The optional ID of the identity that created the pull requests.</param>
    /// <param name="includeLinks">Whether to include the <c>_links</c> field on shallow references.</param>
    /// <param name="labels">The optional label names that pull requests must match.</param>
    /// <param name="maxTime">The optional upper creation or closure time bound, interpreted according to <paramref name="queryTimeRangeType"/>.</param>
    /// <param name="minTime">The optional lower creation or closure time bound, interpreted according to <paramref name="queryTimeRangeType"/>.</param>
    /// <param name="queryTimeRangeType">The optional time-range type for <paramref name="minTime"/> and <paramref name="maxTime"/>. The service defaults to <c>created</c>.</param>
    /// <param name="repositoryId">The optional ID of the target repository.</param>
    /// <param name="reviewerId">The optional ID of an identity assigned as a reviewer.</param>
    /// <param name="sourceRefName">The optional source branch name.</param>
    /// <param name="sourceRepositoryId">The optional ID of the source repository.</param>
    /// <param name="status">The optional pull request status. The service defaults to <c>active</c>.</param>
    /// <param name="tagsFilterOperator">The optional operator for label filtering. The service defaults to <c>and</c>.</param>
    /// <param name="targetRefName">The optional target branch name.</param>
    /// <param name="title">The optional text that pull request titles must contain.</param>
    /// <param name="maxCommentLength">An optional parameter that is not used by the service.</param>
    /// <param name="skip">The optional number of pull requests to ignore.</param>
    /// <param name="top">The optional number of pull requests to retrieve.</param>
    /// <returns>An HTTP request message for the Get Pull Requests By Project operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.2.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-requests/get-pull-requests-by-project?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetPullRequestsByProjectRequest(
        string organization,
        string project,
        Guid? creatorId = null,
        bool? includeLinks = null,
        IEnumerable<string>? labels = null,
        DateTimeOffset? maxTime = null,
        DateTimeOffset? minTime = null,
        string? queryTimeRangeType = null,
        Guid? repositoryId = null,
        Guid? reviewerId = null,
        string? sourceRefName = null,
        Guid? sourceRepositoryId = null,
        string? status = null,
        string? tagsFilterOperator = null,
        string? targetRefName = null,
        string? title = null,
        int? maxCommentLength = null,
        int? skip = null,
        int? top = null)
    {
        var queryParameters = new List<string>();

        void AddQueryParameter(string name, string value)
        {
            queryParameters.Add($"{name}={Uri.EscapeDataString(value)}");
        }

        if (creatorId is not null)
            AddQueryParameter("searchCriteria.creatorId", creatorId.Value.ToString());
        if (includeLinks is not null)
            AddQueryParameter("searchCriteria.includeLinks", includeLinks.Value ? "true" : "false");
        if (labels is not null)
            AddQueryParameter("searchCriteria.labels", string.Join(',', labels));
        if (maxTime is not null)
            AddQueryParameter("searchCriteria.maxTime", maxTime.Value.ToString("O", CultureInfo.InvariantCulture));
        if (minTime is not null)
            AddQueryParameter("searchCriteria.minTime", minTime.Value.ToString("O", CultureInfo.InvariantCulture));
        if (queryTimeRangeType is not null)
            AddQueryParameter("searchCriteria.queryTimeRangeType", queryTimeRangeType);
        if (repositoryId is not null)
            AddQueryParameter("searchCriteria.repositoryId", repositoryId.Value.ToString());
        if (reviewerId is not null)
            AddQueryParameter("searchCriteria.reviewerId", reviewerId.Value.ToString());
        if (sourceRefName is not null)
            AddQueryParameter("searchCriteria.sourceRefName", sourceRefName);
        if (sourceRepositoryId is not null)
            AddQueryParameter("searchCriteria.sourceRepositoryId", sourceRepositoryId.Value.ToString());
        if (status is not null)
            AddQueryParameter("searchCriteria.status", status);
        if (tagsFilterOperator is not null)
            AddQueryParameter("searchCriteria.tagsFilterOperator", tagsFilterOperator);
        if (targetRefName is not null)
            AddQueryParameter("searchCriteria.targetRefName", targetRefName);
        if (title is not null)
            AddQueryParameter("searchCriteria.title", title);
        if (maxCommentLength is not null)
            AddQueryParameter("maxCommentLength", maxCommentLength.Value.ToString(CultureInfo.InvariantCulture));
        if (skip is not null)
            AddQueryParameter("$skip", skip.Value.ToString(CultureInfo.InvariantCulture));
        if (top is not null)
            AddQueryParameter("$top", top.Value.ToString(CultureInfo.InvariantCulture));

        queryParameters.Add("api-version=7.2-preview.2");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = Uri.EscapeDataString(project);
        var url = $"https://dev.azure.com/{organizationSegment}/{projectSegment}/_apis/git/pullrequests?{string.Join('&', queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
        return request;
    }

    /// <summary>
    /// Requests a Git merge operation for two commits.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">Project ID or project name.</param>
    /// <param name="repositoryNameOrId">The name or ID of the repository.</param>
    /// <param name="parents">An enumeration of the parent commit IDs for the merge commit.</param>
    /// <param name="comment">Comment or message of the commit. This parameter is optional.</param>
    /// <param name="includeLinks">True to include links. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Create Merge operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/merges/create?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage CreateMergeRequest(
        string organization,
        string project,
        string repositoryNameOrId,
        IEnumerable<string> parents,
        string? comment = null,
        bool? includeLinks = null)
    {
        var queryParameters = new List<string>();

        if (includeLinks is not null)
            queryParameters.Add($"includeLinks={(includeLinks.Value ? "true" : "false")}");

        queryParameters.Add("api-version=7.2-preview.1");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = Uri.EscapeDataString(project);
        var repositorySegment = Uri.EscapeDataString(repositoryNameOrId);
        var url = $"https://dev.azure.com/{organizationSegment}/{projectSegment}/_apis/git/repositories/{repositorySegment}/merges?{string.Join('&', queryParameters)}";
        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url, UriKind.Absolute));

        var mergeParameters = new GitMergeParameters
        {
            Comment = comment,
            Parents = parents.ToList(),
        };
        using var bodyStream = new MemoryStream();
        using (var writer = new System.Text.Json.Utf8JsonWriter(bodyStream))
            APISerializer.Serialize(writer, mergeParameters);

        request.Content = new ByteArrayContent(bodyStream.ToArray());
        request.Content.Headers.ContentType = new("application/json");
        return request;
    }

    /// <summary>
    /// Gets the details of a specific merge operation.
    /// </summary>
    /// <param name="organization">The name of the Azure DevOps organization.</param>
    /// <param name="project">Project ID or project name.</param>
    /// <param name="repositoryNameOrId">The name or ID of the repository.</param>
    /// <param name="mergeOperationId">OperationId of the merge request.</param>
    /// <param name="includeLinks">True to include links. This parameter is optional.</param>
    /// <returns>An HTTP request message for the Get Merge operation.</returns>
    /// <remarks>
    /// Uses Azure DevOps REST API version 7.2-preview.1.
    /// See <see href="https://learn.microsoft.com/en-us/rest/api/azure/devops/git/merges/get?view=azure-devops-rest-7.2&amp;tabs=HTTP">the official Azure DevOps REST API documentation</see>.
    /// </remarks>
    public static HttpRequestMessage GetMergeRequest(
        string organization,
        string project,
        string repositoryNameOrId,
        int mergeOperationId,
        bool? includeLinks = null)
    {
        var queryParameters = new List<string>();

        if (includeLinks is not null)
            queryParameters.Add($"includeLinks={(includeLinks.Value ? "true" : "false")}");

        queryParameters.Add("api-version=7.2-preview.1");

        var organizationSegment = Uri.EscapeDataString(organization);
        var projectSegment = Uri.EscapeDataString(project);
        var repositorySegment = Uri.EscapeDataString(repositoryNameOrId);
        var url = $"https://dev.azure.com/{organizationSegment}/{projectSegment}/_apis/git/repositories/{repositorySegment}/merges/{mergeOperationId}?{string.Join('&', queryParameters)}";
        return new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
    }
}