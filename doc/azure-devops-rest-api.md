# Azure DevOps REST API

https://learn.microsoft.com/en-us/rest/api/azure/devops

## Supported APIs

This section contains the list of APIs which this library supports.

### Git

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
