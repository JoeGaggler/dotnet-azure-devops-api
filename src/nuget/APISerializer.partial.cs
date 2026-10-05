using System.Buffers;
using System.Text.Json;

namespace Pingmint.AzureDevOps;

partial class APISerializer
{
    private static Boolean TryGetUtf8ByteArrayFromString(String json, out Byte[] bytes, out Int32 bytesWritten)
    {
        bytes = new byte[System.Text.Encoding.UTF8.GetMaxByteCount(json.Length)];
        return System.Text.Encoding.UTF8.TryGetBytes(json.AsSpan(), bytes, out bytesWritten);
    }

    public static DeserializationResult<BuildsResponse> DeserializeBuildsResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<BuildsResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new BuildsResponse(),
            };
        }

        return DeserializeBuildsResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<BuildsResponse> DeserializeBuildsResponse(ReadOnlySpan<Byte> json)
    {
        var result = new BuildsResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<BuildsResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<Build> DeserializeBuild(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<Build>
            {
                Status = DeserializationStatus.Failure,
                Value = new Build(),
            };
        }

        return DeserializeBuild(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<Build> DeserializeBuild(ReadOnlySpan<Byte> json)
    {
        var result = new Build();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Id is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<Build>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitRef> DeserializeGitRef(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitRef>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitRef(),
            };
        }

        return DeserializeGitRef(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitRef> DeserializeGitRef(ReadOnlySpan<Byte> json)
    {
        var result = new GitRef();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Name is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitRef>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitRefsResponse> DeserializeGitRefsResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitRefsResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitRefsResponse(),
            };
        }

        return DeserializeGitRefsResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitRefsResponse> DeserializeGitRefsResponse(ReadOnlySpan<Byte> json)
    {
        var result = new GitRefsResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitRefsResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitRefUpdateResultsResponse> DeserializeGitRefUpdateResultsResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitRefUpdateResultsResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitRefUpdateResultsResponse(),
            };
        }

        return DeserializeGitRefUpdateResultsResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitRefUpdateResultsResponse> DeserializeGitRefUpdateResultsResponse(ReadOnlySpan<Byte> json)
    {
        var result = new GitRefUpdateResultsResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitRefUpdateResultsResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitRepositoriesResponse> DeserializeGitRepositoriesResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitRepositoriesResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitRepositoriesResponse(),
            };
        }

        return DeserializeGitRepositoriesResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitRepositoriesResponse> DeserializeGitRepositoriesResponse(ReadOnlySpan<Byte> json)
    {
        var result = new GitRepositoriesResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitRepositoriesResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitRepository> DeserializeGitRepository(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitRepository>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitRepository(),
            };
        }

        return DeserializeGitRepository(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitRepository> DeserializeGitRepository(ReadOnlySpan<Byte> json)
    {
        var result = new GitRepository();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Id is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitRepository>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitPullRequest> DeserializeGitPullRequest(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitPullRequest>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitPullRequest(),
            };
        }

        return DeserializeGitPullRequest(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitPullRequest> DeserializeGitPullRequest(ReadOnlySpan<Byte> json)
    {
        var result = new GitPullRequest();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.PullRequestId is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitPullRequest>
        {
            Status = status,
            Value = result,
        };
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

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitPullRequestsResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitPullRequestStatusesResponse> DeserializeGitPullRequestStatusesResponse(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitPullRequestStatusesResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitPullRequestStatusesResponse(),
            };
        }

        return DeserializeGitPullRequestStatusesResponse(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitPullRequestStatusesResponse> DeserializeGitPullRequestStatusesResponse(ReadOnlySpan<Byte> json)
    {
        var result = new GitPullRequestStatusesResponse();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Value is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitPullRequestStatusesResponse>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitPullRequestStatus> DeserializeGitPullRequestStatus(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitPullRequestStatus>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitPullRequestStatus(),
            };
        }

        return DeserializeGitPullRequestStatus(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitPullRequestStatus> DeserializeGitPullRequestStatus(ReadOnlySpan<Byte> json)
    {
        var result = new GitPullRequestStatus();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.Context?.Name is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitPullRequestStatus>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<GitMerge> DeserializeGitMerge(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<GitMerge>
            {
                Status = DeserializationStatus.Failure,
                Value = new GitMerge(),
            };
        }

        return DeserializeGitMerge(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<GitMerge> DeserializeGitMerge(ReadOnlySpan<Byte> json)
    {
        var result = new GitMerge();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                status = result.MergeOperationId is null
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<GitMerge>
        {
            Status = status,
            Value = result,
        };
    }

    public static DeserializationResult<ExtensionDataDocumentResponse> DeserializeExtensionDataDocument(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<ExtensionDataDocumentResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new ExtensionDataDocumentResponse(new ExtensionDataDocument(), String.Empty),
            };
        }

        return DeserializeExtensionDataDocument(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<ExtensionDataDocumentResponse> DeserializeExtensionDataDocument(ReadOnlySpan<Byte> json)
    {
        var result = new ExtensionDataDocument();
        var status = DeserializationStatus.None;
        var reader = new Utf8JsonReader(json);

        try
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, result);
                if (result.Id is null || result.ETag is null)
                {
                    status = DeserializationStatus.ModelValidationFailure;
                }
                else
                {
                    status = DeserializationStatus.Success;
                }
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<ExtensionDataDocumentResponse>
        {
            Status = status,
            Value = new ExtensionDataDocumentResponse(result, System.Text.Encoding.UTF8.GetString(json)),
        };
    }

    public static DeserializationResult<ExtensionDataDocumentsResponse> DeserializeExtensionDataDocuments(String json)
    {
        if (!TryGetUtf8ByteArrayFromString(json, out var bytes, out var bytesWritten))
        {
            return new DeserializationResult<ExtensionDataDocumentsResponse>
            {
                Status = DeserializationStatus.Failure,
                Value = new ExtensionDataDocumentsResponse([], String.Empty),
            };
        }

        return DeserializeExtensionDataDocuments(bytes.AsSpan(0, bytesWritten));
    }

    public static DeserializationResult<ExtensionDataDocumentsResponse> DeserializeExtensionDataDocuments(ReadOnlySpan<Byte> json)
    {
        var envelope = new ExtensionDataDocumentsEnvelope();
        var status = DeserializationStatus.None;

        try
        {
            ReadOnlySpan<Byte> prefix = "{\"documents\":"u8;
            ReadOnlySpan<Byte> suffix = "}"u8;
            var wrappedJson = new Byte[prefix.Length + json.Length + suffix.Length];
            prefix.CopyTo(wrappedJson);
            json.CopyTo(wrappedJson.AsSpan(prefix.Length));
            suffix.CopyTo(wrappedJson.AsSpan(prefix.Length + json.Length));

            var reader = new Utf8JsonReader(wrappedJson);
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                Deserialize(ref reader, envelope);
                status = envelope.Documents is null || envelope.Documents.Any(document => document.Id is null || document.ETag is null)
                    ? DeserializationStatus.ModelValidationFailure
                    : DeserializationStatus.Success;
            }
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException or FormatException)
        {
            status = DeserializationStatus.Failure;
        }

        return new DeserializationResult<ExtensionDataDocumentsResponse>
        {
            Status = status,
            Value = new ExtensionDataDocumentsResponse(
                envelope.Documents ?? [],
                System.Text.Encoding.UTF8.GetString(json)),
        };
    }
}

public readonly record struct ExtensionDataDocumentResponse(ExtensionDataDocument Response, String Json);
public readonly record struct ExtensionDataDocumentsResponse(List<ExtensionDataDocument> Documents, String Json);

public record struct DeserializationResult<T>
{
    public DeserializationStatus Status { get; init; }
    public T Value { get; init; }
}

public enum DeserializationStatus
{
    None,
    Success,
    Failure,
    ModelValidationFailure
}