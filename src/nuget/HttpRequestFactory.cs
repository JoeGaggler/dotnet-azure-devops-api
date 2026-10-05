using System.Globalization;

namespace Pingmint.AzureDevOps;

public static class HttpRequestFactory
{
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