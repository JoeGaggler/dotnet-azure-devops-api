using System.Text.Json;

namespace Pingmint.AzureDevOps;

partial class APISerializer
{
    private static Boolean TryGetUtf8ByteArrayFromString(String json, out Byte[] bytes, out Int32 bytesWritten)
    {
        bytes = new byte[System.Text.Encoding.UTF8.GetMaxByteCount(json.Length)];
        return System.Text.Encoding.UTF8.TryGetBytes(json.AsSpan(), bytes, out bytesWritten);
    }

    public static DeserializationResult<GitPullRequestsResponse> DeserializeGitPullRequestsResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitPullRequestsResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitPullRequestsResponse(),
            };
        }

        return DeserializeGitPullRequestsResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitPullRequestsResponse> DeserializeGitPullRequestsResponse(ReadOnlySpan<Byte> json)
    {
        var result = new GitPullRequestsResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        if (!reader.Read())
        {
            status = DeserializationStatus.Failure;
        }
        else if (reader.TokenType != JsonTokenType.StartObject)
        {
            status = DeserializationStatus.Failure;
        }
        else
        {
            Deserialize(ref reader, result);
            status = DeserializationStatus.Success;
        }

        return new DeserializationResult<GitPullRequestsResponse>
        {
            Status = status,
            Value = result,
        };
    }
}

public record struct DeserializationResult<T>
{
    public DeserializationStatus Status { get; init; }
    public T Value { get; init; }
}

public enum DeserializationStatus
{
    None,
    Success,
    Failure
}