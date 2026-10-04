namespace Pingmint.AzureDevOps;

public static class Client
{
    public static async Task<ClientResult<GitRepository>> GetGitRepositoryAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            using var response = await client.SendAsync(request, cancellationToken);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new ClientResult<GitRepository>
                {
                    Status = ClientStatus.Failed,
                };
            }

            var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
            var deserialization = APISerializer.DeserializeGitRepository(bytes);
            return deserialization.Status == DeserializationStatus.Success
                ? new ClientResult<GitRepository>
                {
                    Status = ClientStatus.Success,
                    Value = deserialization.Value,
                }
                : new ClientResult<GitRepository>
                {
                    Status = ClientStatus.Exception,
                    Exception = new InvalidOperationException("Deserialization failed"),
                };
        }
        catch (Exception exception)
        {
            return new ClientResult<GitRepository>
            {
                Status = ClientStatus.Exception,
                Exception = exception,
            };
        }
    }

    public static async Task<ClientResult<GitRepositoriesResponse>> ListGitRepositoriesAsync(
        HttpClient client,
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            using var response = await client.SendAsync(request, cancellationToken);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new ClientResult<GitRepositoriesResponse>
                {
                    Status = ClientStatus.Failed,
                };
            }

            var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
            var deserialization = APISerializer.DeserializeGitRepositoriesResponse(bytes);
            return deserialization.Status == DeserializationStatus.Success
                ? new ClientResult<GitRepositoriesResponse>
                {
                    Status = ClientStatus.Success,
                    Value = deserialization.Value,
                }
                : new ClientResult<GitRepositoriesResponse>
                {
                    Status = ClientStatus.Exception,
                    Exception = new InvalidOperationException("Deserialization failed"),
                };
        }
        catch (Exception exception)
        {
            return new ClientResult<GitRepositoriesResponse>
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