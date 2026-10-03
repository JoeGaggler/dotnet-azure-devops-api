# Azure DevOps REST API

https://learn.microsoft.com/en-us/rest/api/azure/devops

## Supported APIs

This section contains the list of APIs which this library supports.

### Git

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

#### Merges

##### Create

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/merges/create?view=azure-devops-rest-7.2&tabs=HTTP
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/repositories/{repositoryNameOrId}/merges
Version:       7.2-preview.1

Request Method: CreateMergeRequest
Response Model: Pingmint.AzureDevOps.GitMerge
