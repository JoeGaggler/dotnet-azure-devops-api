namespace Pingmint.AzureDevOps;

public static class HttpRequestFactory
{
    public static HttpRequestMessage GetPullRequestsByProjectRequest(string organization, string project)
    {
        var url = $"https://dev.azure.com/{organization}/{project}/_apis/git/pullrequests?api-version=7.2-preview.2";
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url, UriKind.Absolute));
        return request;
    }
}