# Azure DevOps REST API

https://learn.microsoft.com/en-us/rest/api/azure/devops

## Supported APIs

This section contains the list of APIs which this library supports.

### Extension Management

#### Extension Data

##### Get a document by ID

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#get-a-document-by-id
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       GET https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/Default/Current/Collections/{collectionName}/Documents/{documentId}
Version:        7.2-preview.1

Request Method: GetExtensionDataDocumentRequest
Response Model: Pingmint.AzureDevOps.ExtensionDataDocumentResponse

The operation route and version are confirmed by Microsoft's [Azure DevOps extension API client](https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts). The response wrapper retains the complete document payload as JSON text.

##### Create a document

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#create-a-document
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       POST https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/{scopeType}/{scopeValue}/Collections/{collectionName}/Documents
Version:        7.2-preview.1

Request Method: CreateExtensionDataDocumentRequest
Response Model: Pingmint.AzureDevOps.ExtensionDataDocumentResponse

The JSON request body string is sent unchanged. A supplied `__etag` is preserved; the response wrapper retains the resulting document payload and its current `__etag`.

##### Set a document (update or create)

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#set-a-document-update-or-create
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       PUT https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/{scopeType}/{scopeValue}/Collections/{collectionName}/Documents
Version:        7.2-preview.1

Request Method: SetExtensionDataDocumentRequest
Response Model: Pingmint.AzureDevOps.ExtensionDataDocumentResponse

The request document JSON string, including `id` and `__etag`, is sent unchanged. The service performs the documented upsert and applies the supplied ETag concurrency behavior.

##### Update a document

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#update-a-document
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       PATCH https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/{scopeType}/{scopeValue}/Collections/{collectionName}/Documents
Version:        7.2-preview.1

Request Method: UpdateExtensionDataDocumentRequest
Response Model: Pingmint.AzureDevOps.ExtensionDataDocumentResponse

The request document JSON string and its `__etag` are sent unchanged. The service compares the ETag with the stored version; `-1` requests last-write-wins behavior.

##### Delete a document

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#delete-a-document
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       DELETE https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/{scopeType}/{scopeValue}/Collections/{collectionName}/Documents/{documentId}
Version:        7.2-preview.1

Request Method: DeleteExtensionDataDocumentRequest
Response Model: None

The documented delete operation does not take a document body or `__etag`.

##### Get all documents in a collection

Documentation:  https://learn.microsoft.com/en-us/azure/devops/extend/develop/data-storage?view=azure-devops#get-all-documents-in-a-collection
Reference Code: https://github.com/microsoft/azure-devops-extension-api/blob/master/src/ExtensionManagement/ExtensionManagementClient.ts
Endpoint:       GET https://extmgmt.dev.azure.com/{organization}/_apis/ExtensionManagement/InstalledExtensions/{publisherName}/{extensionName}/Data/Scopes/{scopeType}/{scopeValue}/Collections/{collectionName}/Documents
Version:        7.2-preview.1

Request Method: GetExtensionDataDocumentsRequest
Response Model: Pingmint.AzureDevOps.ExtensionDataDocumentsResponse

The generated `ExtensionDataDocumentsEnvelope` model deserializes the array. `ExtensionDataDocumentsResponse.Documents` exposes the typed documents and their `__etag` values, while `Json` retains the original array payload.

### Build

#### Builds

##### List Builds

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.2
Endpoint:      GET https://dev.azure.com/{organization}/{project}/_apis/build/builds
Version:       7.2-preview.8

Request Method: ListBuildsRequest
Response Model: Pingmint.AzureDevOps.BuildsResponse

Pagination: `Client.ListBuildsAsync` returns `ClientResult<BuildsResponsePaginated>`. Its `Value.Response` contains the JSON model, and `Value.ContinuationToken` contains the next page token or `null` when the response has no `x-ms-continuationtoken` header. Pass a non-null token to `HttpRequestFactory.ListBuildsRequest` as `continuationToken` with the same filters to fetch the next page. The token is an HTTP response header, not a field in `BuildsResponse`.

The [Builds - List reference](https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.2) says the token comes from a previous call but does not name the header. Microsoft's [Azure DevOps extension API `getBuilds` implementation](https://github.com/microsoft/azure-devops-extension-api/blob/master/src/Build/BuildClient.ts) reads `x-ms-continuationtoken` from the response headers for the same `7.2-preview.8` operation.

##### Get Build

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.2
Endpoint:      GET https://dev.azure.com/{organization}/{project}/_apis/build/builds/{buildId}
Version:       7.2-preview.8

Request Method: GetBuildRequest
Response Model: Pingmint.AzureDevOps.Build

### Git

#### Refs

##### List Refs

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/list?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      GET https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/refs
Version:       7.2-preview.2

Request Method: ListRefsRequest
Response Model: Pingmint.AzureDevOps.GitRefsResponse

##### Update Ref

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/update-ref?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      PATCH https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/refs?filter={filter}
Version:       7.2-preview.2

Request Method: UpdateRefRequest
Response Model: Pingmint.AzureDevOps.GitRef

##### Update Refs

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/refs/update-refs?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      POST https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/refs
Version:       7.2-preview.2

Request Method: UpdateRefsRequest
Response Model: Pingmint.AzureDevOps.GitRefUpdateResultsResponse

#### Repositories

##### Get Repository

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/repositories/get-repository?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}
Version:       7.2-preview.2

Request Method: GetRepositoryRequest
Response Model: Pingmint.AzureDevOps.GitRepository

##### List Repositories

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/repositories/list?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/repositories
Version:       7.2-preview.2

Request Method: ListRepositoriesRequest
Response Model: Pingmint.AzureDevOps.GitRepositoriesResponse

#### Pull Requests

##### Get Pull Request By Id

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-requests/get-pull-request-by-id?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/pullrequests/{pullRequestId}
Version:       7.2-preview.2

Request Method: GetPullRequestByIdRequest
Response Model: Pingmint.AzureDevOps.GitPullRequest

##### Get Pull Requests By Project

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-requests/get-pull-requests-by-project?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/pullrequests
Version:       7.2-preview.2

Request Method: GetPullRequestsByProjectRequest
Response Model: Pingmint.AzureDevOps.GitPullRequestsResponse

#### Pull Requests Statuses

##### Get Pull Request Statuses

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/list?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      GET https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/pullRequests/{pullRequestId}/statuses
Version:       7.2-preview.2

Request Method: GetPullRequestStatusesRequest
Response Model: Pingmint.AzureDevOps.GitPullRequestStatusesResponse

##### Create Pull Request Status

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/create?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      POST https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/pullRequests/{pullRequestId}/statuses
Version:       7.2-preview.2

Request Method: CreatePullRequestStatusRequest
Response Model: Pingmint.AzureDevOps.GitPullRequestStatus

##### Delete Pull Request Status

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-statuses/delete?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      DELETE https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryId}/pullRequests/{pullRequestId}/statuses/{statusId}
Version:       7.2-preview.2

Request Method: DeletePullRequestStatusRequest
Response Model: None

#### Merges

##### Get

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/merges/get?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryNameOrId}/merges/{mergeOperationId}
Version:       7.2-preview.1

Request Method: GetMergeRequest
Response Model: Pingmint.AzureDevOps.GitMerge

##### Create

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/merges/create?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryNameOrId}/merges
Version:       7.2-preview.1

Request Method: CreateMergeRequest
Response Model: Pingmint.AzureDevOps.GitMerge
