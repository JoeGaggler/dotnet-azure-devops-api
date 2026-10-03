#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pingmint.AzureDevOps;

public static partial class APISerializer
{
	private static readonly JsonEncodedText JsonEncText_pullRequestId = JsonEncodedText.Encode("pullRequestId");
	private static readonly JsonEncodedText JsonEncText_value = JsonEncodedText.Encode("value");

	private static void SkipUnknownPropertyName(ref Utf8JsonReader reader)
	{
		if (!reader.Read()) { throw new InvalidOperationException("Unable to skip unknown property key from Utf8JsonReader"); }
		reader.Skip();
	}

	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitPullRequestsResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName(JsonEncText_value);
			Serialize0(writer, localValue);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitPullRequestsResponse obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("value"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Value = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Value = new(); Deserialize0(ref reader, obj.Value); break; }
						throw new InvalidOperationException($"unexpected token type for Value: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitPullRequest? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.PullRequestId is { } localPullRequestId)
		{
			writer.WritePropertyName(JsonEncText_pullRequestId);
			writer.WriteNumberValue(localPullRequestId);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitPullRequest obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("pullRequestId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.PullRequestId = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.PullRequestId = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for PullRequestId: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize0(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitPullRequest>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize0(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitPullRequest> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.GitPullRequest item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
}
public sealed partial record class GitPullRequestsResponse
{
	public List<Pingmint.AzureDevOps.GitPullRequest>? Value { get; set; }
}
public sealed partial record class GitPullRequest
{
	public int? PullRequestId { get; set; }
}
