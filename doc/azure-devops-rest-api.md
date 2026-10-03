# Azure DevOps REST API

https://learn.microsoft.com/en-us/rest/api/azure/devops

## Supported APIs

This section contains the list of APIs which this library supports.

### Git

#### Pull Requests

##### Get Pull Requests By Project

Documentation: https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-request-threads/list?view=azure-devops-rest-7.2
Endpoint:      https://dev.azure.com/{organization}/{project}/_apis/git/pullrequests
Version:       7.2-preview.2

Request Method: GetPullRequestsByProjectRequest
Response Model: Pingmint.AzureDevOps.GitPullRequestsResponse
