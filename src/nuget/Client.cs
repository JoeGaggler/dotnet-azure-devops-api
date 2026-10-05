namespace Pingmint.AzureDevOps;

public static class Client
{
    public static async Task<ClientResult<GitRefsResponse>> ListGitRefsAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRefsResponse>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRefsResponse(bytes));
    }

    public static async Task<ClientResult<GitRepository>> GetGitRepositoryAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRepository>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRepository(bytes));
    }

    public static async Task<ClientResult<GitRepositoriesResponse>> ListGitRepositoriesAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitRepositoriesResponse>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitRepositoriesResponse(bytes));
    }

    public static async Task<ClientResult<GitPullRequest>> GetGitPullRequestAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequest>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequest(bytes));
    }

    public static async Task<ClientResult<GitPullRequestsResponse>> ListGitPullRequestsAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitPullRequestsResponse>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitPullRequestsResponse(bytes));
    }

    public static async Task<ClientResult<GitMerge>> GetGitMergeAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitMerge>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.OK,
            static bytes => APISerializer.DeserializeGitMerge(bytes));
    }

    public static async Task<ClientResult<GitMerge>> CreateGitMergeAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await SendAndDeserializeAsync<GitMerge>(
            client,
            request,
            cancellationToken,
            System.Net.HttpStatusCode.Created,
            static bytes => APISerializer.DeserializeGitMerge(bytes));
    }

    private static async Task<ClientResult<T>> SendAndDeserializeAsync<T>(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken,
        System.Net.HttpStatusCode successStatusCode,
        Func<Byte[], DeserializationResult<T>> deserialize)
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
    Exception
}