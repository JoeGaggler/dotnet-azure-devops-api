using System.Text.Json;

namespace Pingmint.AzureDevOps;

partial class APISerializer
{
    private static Boolean TryGetUtf8ByteArrayFromString(String json, out Byte[] bytes, out Int32 bytesWritten)
    {
        bytes = new byte[System.Text.Encoding.UTF8.GetMaxByteCount(json.Length)];
        return System.Text.Encoding.UTF8.TryGetBytes(json.AsSpan(), bytes, out bytesWritten);
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

        try
        {
            using var document = JsonDocument.Parse(json.ToArray());
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                status = DeserializationStatus.Failure;
            }
            else
            {
                var reader = new Utf8JsonReader(json);
                if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                {
                    status = DeserializationStatus.Failure;
                }
                else
                {
                    Deserialize(ref reader, result);
                    if (result.Value is null)
                    {
                        status = DeserializationStatus.ModelValidationFailure;
                    }
                    else
                    {
                        if (document.RootElement.TryGetProperty("value", out var statuses)
                            && statuses.ValueKind == JsonValueKind.Array)
                        {
                            for (var index = 0; index < Math.Min(statuses.GetArrayLength(), result.Value.Count); index++)
                            {
                                if (statuses[index].TryGetProperty("properties", out var properties)
                                    && properties.ValueKind == JsonValueKind.Object
                                    && properties.TryGetProperty("item", out var item))
                                {
                                    var statusModel = result.Value[index];
                                    if (statusModel.Properties is not null)
                                        statusModel.Properties.Item = item.Clone();
                                }
                            }
                        }

                        status = DeserializationStatus.Success;
                    }
                }
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
}

public record struct DeserializationResult<T>
{
    public DeserializationStatus Status { get; init; }
    public T Value { get; init; }
}

public sealed partial record class PropertiesCollection
{
    public JsonElement? Item { get; set; }
}

public enum DeserializationStatus
{
    None,
    Success,
    Failure,
    ModelValidationFailure
}