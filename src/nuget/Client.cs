namespace Pingmint.AzureDevOps;

public static class Client
{
    public static async Task<ClientResult<GitRef>> UpdateGitRefAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRef>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRef(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitRefsResponse>> ListGitRefsAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRefsResponse>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRefsResponse(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitRepository>> GetGitRepositoryAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRepository>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRepository(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitRepositoriesResponse>> ListGitRepositoriesAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRepositoriesResponse>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRepositoriesResponse(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitPullRequest>> GetGitPullRequestAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequest>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequest(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitPullRequestsResponse>> ListGitPullRequestsAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequestsResponse>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequestsResponse(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitPullRequestStatusesResponse>> GetGitPullRequestStatusesAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequestStatusesResponse>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequestStatusesResponse(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitPullRequestStatus>> CreateGitPullRequestStatusAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequestStatus>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequestStatus(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitMerge>> GetGitMergeAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitMerge>(
            client,
            request,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitMerge(bytes),
            cancellationToken);
    }

    public static async Task<ClientResult<GitMerge>> CreateGitMergeAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitMerge>(
            client,
            request,
            System.Net.HttpStatusCode.Created,
            static bytes => APISerializer.DeserializeGitMerge(bytes),
            cancellationToken);
    }

    private static async Task<ClientResult<T>> SendAndDeserializeAsync<T>(
        HttpClient client,
        HttpRequestMessage request,
        System.Net.HttpStatusCode successStatusCode,
        Func<Byte[], DeserializationResult<T>> deserialize,
        CancellationToken cancellationToken
        )
    {
        try
        {
            using var response = await client.SendAsync(request, cancellationToken);
            if (response.StatusCode != successStatusCode)
            {
                return new ClientResult<T>
                {
                    Status = ClientStatus.Failed,
                };
            }

            var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
            var deserialization = deserialize(bytes);
            return deserialization.Status == DeserializationStatus.Success
                ? new ClientResult<T>
                {
                    Status = ClientStatus.Success,
                    Value = deserialization.Value,
                }
                : new ClientResult<T>
                {
                    Status = ClientStatus.Exception,
                    Exception = new InvalidOperationException("Deserialization failed"),
                };
        }
        catch (OperationCanceledException)
        {
            return new ClientResult<T>
            {
                Status = ClientStatus.Cancelled,
            };
        }
        catch (Exception exception)
        {
            return new ClientResult<T>
            {
                Status = ClientStatus.Exception,
                Exception = exception,
            };
        }
    }
}

public struct ClientResult<T>
{
    public ClientStatus Status { get; init; }
    public T Value { get; init; }
    public Exception Exception { get; init; }

}

public enum ClientStatus
{
    None,
    Success,
    Failed,
    Cancelled,
    Exception,
}