#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pingmint.AzureDevOps;

public static partial class APISerializer
{
	private static readonly JsonEncodedText JsonEncText__links = JsonEncodedText.Encode("_links");
	private static readonly JsonEncodedText JsonEncText_abbreviation = JsonEncodedText.Encode("abbreviation");
	private static readonly JsonEncodedText JsonEncText_active = JsonEncodedText.Encode("active");
	private static readonly JsonEncodedText JsonEncText_artifactId = JsonEncodedText.Encode("artifactId");
	private static readonly JsonEncodedText JsonEncText_author = JsonEncodedText.Encode("author");
	private static readonly JsonEncodedText JsonEncText_autoCompleteIgnoreConfigIds = JsonEncodedText.Encode("autoCompleteIgnoreConfigIds");
	private static readonly JsonEncodedText JsonEncText_autoCompleteSetBy = JsonEncodedText.Encode("autoCompleteSetBy");
	private static readonly JsonEncodedText JsonEncText_avatarUrl = JsonEncodedText.Encode("avatarUrl");
	private static readonly JsonEncodedText JsonEncText_bypassPolicy = JsonEncodedText.Encode("bypassPolicy");
	private static readonly JsonEncodedText JsonEncText_bypassReason = JsonEncodedText.Encode("bypassReason");
	private static readonly JsonEncodedText JsonEncText_closedBy = JsonEncodedText.Encode("closedBy");
	private static readonly JsonEncodedText JsonEncText_closedDate = JsonEncodedText.Encode("closedDate");
	private static readonly JsonEncodedText JsonEncText_codeReviewId = JsonEncodedText.Encode("codeReviewId");
	private static readonly JsonEncodedText JsonEncText_collection = JsonEncodedText.Encode("collection");
	private static readonly JsonEncodedText JsonEncText_comment = JsonEncodedText.Encode("comment");
	private static readonly JsonEncodedText JsonEncText_commitId = JsonEncodedText.Encode("commitId");
	private static readonly JsonEncodedText JsonEncText_commits = JsonEncodedText.Encode("commits");
	private static readonly JsonEncodedText JsonEncText_committer = JsonEncodedText.Encode("committer");
	private static readonly JsonEncodedText JsonEncText_completionOptions = JsonEncodedText.Encode("completionOptions");
	private static readonly JsonEncodedText JsonEncText_completionQueueTime = JsonEncodedText.Encode("completionQueueTime");
	private static readonly JsonEncodedText JsonEncText_conflictAuthorshipCommits = JsonEncodedText.Encode("conflictAuthorshipCommits");
	private static readonly JsonEncodedText JsonEncText_context = JsonEncodedText.Encode("context");
	private static readonly JsonEncodedText JsonEncText_count = JsonEncodedText.Encode("count");
	private static readonly JsonEncodedText JsonEncText_createdBy = JsonEncodedText.Encode("createdBy");
	private static readonly JsonEncodedText JsonEncText_creationDate = JsonEncodedText.Encode("creationDate");
	private static readonly JsonEncodedText JsonEncText_creator = JsonEncodedText.Encode("creator");
	private static readonly JsonEncodedText JsonEncText_date = JsonEncodedText.Encode("date");
	private static readonly JsonEncodedText JsonEncText_defaultBranch = JsonEncodedText.Encode("defaultBranch");
	private static readonly JsonEncodedText JsonEncText_defaultTeamImageUrl = JsonEncodedText.Encode("defaultTeamImageUrl");
	private static readonly JsonEncodedText JsonEncText_deleteSourceBranch = JsonEncodedText.Encode("deleteSourceBranch");
	private static readonly JsonEncodedText JsonEncText_description = JsonEncodedText.Encode("description");
	private static readonly JsonEncodedText JsonEncText_descriptor = JsonEncodedText.Encode("descriptor");
	private static readonly JsonEncodedText JsonEncText_detailedStatus = JsonEncodedText.Encode("detailedStatus");
	private static readonly JsonEncodedText JsonEncText_detectRenameFalsePositives = JsonEncodedText.Encode("detectRenameFalsePositives");
	private static readonly JsonEncodedText JsonEncText_directoryAlias = JsonEncodedText.Encode("directoryAlias");
	private static readonly JsonEncodedText JsonEncText_disableRenames = JsonEncodedText.Encode("disableRenames");
	private static readonly JsonEncodedText JsonEncText_displayName = JsonEncodedText.Encode("displayName");
	private static readonly JsonEncodedText JsonEncText_email = JsonEncodedText.Encode("email");
	private static readonly JsonEncodedText JsonEncText_failureMessage = JsonEncodedText.Encode("failureMessage");
	private static readonly JsonEncodedText JsonEncText_forkSource = JsonEncodedText.Encode("forkSource");
	private static readonly JsonEncodedText JsonEncText_genre = JsonEncodedText.Encode("genre");
	private static readonly JsonEncodedText JsonEncText_hasDeclined = JsonEncodedText.Encode("hasDeclined");
	private static readonly JsonEncodedText JsonEncText_hasMultipleMergeBases = JsonEncodedText.Encode("hasMultipleMergeBases");
	private static readonly JsonEncodedText JsonEncText_href = JsonEncodedText.Encode("href");
	private static readonly JsonEncodedText JsonEncText_id = JsonEncodedText.Encode("id");
	private static readonly JsonEncodedText JsonEncText_ignoreTargetRefAndChooseDynamically = JsonEncodedText.Encode("ignoreTargetRefAndChooseDynamically");
	private static readonly JsonEncodedText JsonEncText_imageUrl = JsonEncodedText.Encode("imageUrl");
	private static readonly JsonEncodedText JsonEncText_inactive = JsonEncodedText.Encode("inactive");
	private static readonly JsonEncodedText JsonEncText_isAadIdentity = JsonEncodedText.Encode("isAadIdentity");
	private static readonly JsonEncodedText JsonEncText_isContainer = JsonEncodedText.Encode("isContainer");
	private static readonly JsonEncodedText JsonEncText_isDeletedInOrigin = JsonEncodedText.Encode("isDeletedInOrigin");
	private static readonly JsonEncodedText JsonEncText_isDisabled = JsonEncodedText.Encode("isDisabled");
	private static readonly JsonEncodedText JsonEncText_isDraft = JsonEncodedText.Encode("isDraft");
	private static readonly JsonEncodedText JsonEncText_isFlagged = JsonEncodedText.Encode("isFlagged");
	private static readonly JsonEncodedText JsonEncText_isFork = JsonEncodedText.Encode("isFork");
	private static readonly JsonEncodedText JsonEncText_isInMaintenance = JsonEncodedText.Encode("isInMaintenance");
	private static readonly JsonEncodedText JsonEncText_isLocked = JsonEncodedText.Encode("isLocked");
	private static readonly JsonEncodedText JsonEncText_isLockedBy = JsonEncodedText.Encode("isLockedBy");
	private static readonly JsonEncodedText JsonEncText_isReapprove = JsonEncodedText.Encode("isReapprove");
	private static readonly JsonEncodedText JsonEncText_isRequired = JsonEncodedText.Encode("isRequired");
	private static readonly JsonEncodedText JsonEncText_labels = JsonEncodedText.Encode("labels");
	private static readonly JsonEncodedText JsonEncText_lastMergeCommit = JsonEncodedText.Encode("lastMergeCommit");
	private static readonly JsonEncodedText JsonEncText_lastMergeSourceCommit = JsonEncodedText.Encode("lastMergeSourceCommit");
	private static readonly JsonEncodedText JsonEncText_lastMergeTargetCommit = JsonEncodedText.Encode("lastMergeTargetCommit");
	private static readonly JsonEncodedText JsonEncText_lastUpdateTime = JsonEncodedText.Encode("lastUpdateTime");
	private static readonly JsonEncodedText JsonEncText_mergeCommitId = JsonEncodedText.Encode("mergeCommitId");
	private static readonly JsonEncodedText JsonEncText_mergeCommitMessage = JsonEncodedText.Encode("mergeCommitMessage");
	private static readonly JsonEncodedText JsonEncText_mergeFailureMessage = JsonEncodedText.Encode("mergeFailureMessage");
	private static readonly JsonEncodedText JsonEncText_mergeFailureType = JsonEncodedText.Encode("mergeFailureType");
	private static readonly JsonEncodedText JsonEncText_mergeId = JsonEncodedText.Encode("mergeId");
	private static readonly JsonEncodedText JsonEncText_mergeOperationId = JsonEncodedText.Encode("mergeOperationId");
	private static readonly JsonEncodedText JsonEncText_mergeOptions = JsonEncodedText.Encode("mergeOptions");
	private static readonly JsonEncodedText JsonEncText_mergeStatus = JsonEncodedText.Encode("mergeStatus");
	private static readonly JsonEncodedText JsonEncText_mergeStrategy = JsonEncodedText.Encode("mergeStrategy");
	private static readonly JsonEncodedText JsonEncText_name = JsonEncodedText.Encode("name");
	private static readonly JsonEncodedText JsonEncText_newObjectId = JsonEncodedText.Encode("newObjectId");
	private static readonly JsonEncodedText JsonEncText_objectId = JsonEncodedText.Encode("objectId");
	private static readonly JsonEncodedText JsonEncText_oldObjectId = JsonEncodedText.Encode("oldObjectId");
	private static readonly JsonEncodedText JsonEncText_parentRepository = JsonEncodedText.Encode("parentRepository");
	private static readonly JsonEncodedText JsonEncText_parents = JsonEncodedText.Encode("parents");
	private static readonly JsonEncodedText JsonEncText_peeledObjectId = JsonEncodedText.Encode("peeledObjectId");
	private static readonly JsonEncodedText JsonEncText_profileUrl = JsonEncodedText.Encode("profileUrl");
	private static readonly JsonEncodedText JsonEncText_project = JsonEncodedText.Encode("project");
	private static readonly JsonEncodedText JsonEncText_pullRequestId = JsonEncodedText.Encode("pullRequestId");
	private static readonly JsonEncodedText JsonEncText_remoteUrl = JsonEncodedText.Encode("remoteUrl");
	private static readonly JsonEncodedText JsonEncText_repository = JsonEncodedText.Encode("repository");
	private static readonly JsonEncodedText JsonEncText_repositoryId = JsonEncodedText.Encode("repositoryId");
	private static readonly JsonEncodedText JsonEncText_reviewers = JsonEncodedText.Encode("reviewers");
	private static readonly JsonEncodedText JsonEncText_reviewerUrl = JsonEncodedText.Encode("reviewerUrl");
	private static readonly JsonEncodedText JsonEncText_revision = JsonEncodedText.Encode("revision");
	private static readonly JsonEncodedText JsonEncText_size = JsonEncodedText.Encode("size");
	private static readonly JsonEncodedText JsonEncText_sourceRefName = JsonEncodedText.Encode("sourceRefName");
	private static readonly JsonEncodedText JsonEncText_squashMerge = JsonEncodedText.Encode("squashMerge");
	private static readonly JsonEncodedText JsonEncText_sshUrl = JsonEncodedText.Encode("sshUrl");
	private static readonly JsonEncodedText JsonEncText_state = JsonEncodedText.Encode("state");
	private static readonly JsonEncodedText JsonEncText_status = JsonEncodedText.Encode("status");
	private static readonly JsonEncodedText JsonEncText_statuses = JsonEncodedText.Encode("statuses");
	private static readonly JsonEncodedText JsonEncText_supportsIterations = JsonEncodedText.Encode("supportsIterations");
	private static readonly JsonEncodedText JsonEncText_targetRefName = JsonEncodedText.Encode("targetRefName");
	private static readonly JsonEncodedText JsonEncText_targetUrl = JsonEncodedText.Encode("targetUrl");
	private static readonly JsonEncodedText JsonEncText_title = JsonEncodedText.Encode("title");
	private static readonly JsonEncodedText JsonEncText_transitionWorkItems = JsonEncodedText.Encode("transitionWorkItems");
	private static readonly JsonEncodedText JsonEncText_triggeredByAutoComplete = JsonEncodedText.Encode("triggeredByAutoComplete");
	private static readonly JsonEncodedText JsonEncText_uniqueName = JsonEncodedText.Encode("uniqueName");
	private static readonly JsonEncodedText JsonEncText_updatedDate = JsonEncodedText.Encode("updatedDate");
	private static readonly JsonEncodedText JsonEncText_url = JsonEncodedText.Encode("url");
	private static readonly JsonEncodedText JsonEncText_validRemoteUrls = JsonEncodedText.Encode("validRemoteUrls");
	private static readonly JsonEncodedText JsonEncText_value = JsonEncodedText.Encode("value");
	private static readonly JsonEncodedText JsonEncText_visibility = JsonEncodedText.Encode("visibility");
	private static readonly JsonEncodedText JsonEncText_vote = JsonEncodedText.Encode("vote");
	private static readonly JsonEncodedText JsonEncText_votedFor = JsonEncodedText.Encode("votedFor");
	private static readonly JsonEncodedText JsonEncText_webUrl = JsonEncodedText.Encode("webUrl");
	private static readonly JsonEncodedText JsonEncText_workItemRefs = JsonEncodedText.Encode("workItemRefs");

	private static void SkipUnknownPropertyName(ref Utf8JsonReader reader)
	{
		if (!reader.Read()) { throw new InvalidOperationException("Unable to skip unknown property key from Utf8JsonReader"); }
		reader.Skip();
	}

	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitCommitRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Author is { } localAuthor)
		{
			writer.WritePropertyName(JsonEncText_author);
			Serialize(writer, localAuthor);
		}
		if (value.Comment is { } localComment)
		{
			writer.WritePropertyName(JsonEncText_comment);
			writer.WriteStringValue(localComment);
		}
		if (value.CommitId is { } localCommitId)
		{
			writer.WritePropertyName(JsonEncText_commitId);
			writer.WriteStringValue(localCommitId);
		}
		if (value.Committer is { } localCommitter)
		{
			writer.WritePropertyName(JsonEncText_committer);
			Serialize(writer, localCommitter);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitCommitRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("author"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Author = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Author = new(); Deserialize(ref reader, obj.Author); break; }
						throw new InvalidOperationException($"unexpected token type for Author: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("comment"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Comment = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Comment = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Comment: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("commitId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CommitId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.CommitId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for CommitId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("committer"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Committer = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Committer = new(); Deserialize(ref reader, obj.Committer); break; }
						throw new InvalidOperationException($"unexpected token type for Committer: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitForkRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Creator is { } localCreator)
		{
			writer.WritePropertyName(JsonEncText_creator);
			Serialize(writer, localCreator);
		}
		if (value.IsLocked is { } localIsLocked)
		{
			writer.WritePropertyName(JsonEncText_isLocked);
			writer.WriteBooleanValue(localIsLocked);
		}
		if (value.IsLockedBy is { } localIsLockedBy)
		{
			writer.WritePropertyName(JsonEncText_isLockedBy);
			Serialize(writer, localIsLockedBy);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.ObjectId is { } localObjectId)
		{
			writer.WritePropertyName(JsonEncText_objectId);
			writer.WriteStringValue(localObjectId);
		}
		if (value.PeeledObjectId is { } localPeeledObjectId)
		{
			writer.WritePropertyName(JsonEncText_peeledObjectId);
			writer.WriteStringValue(localPeeledObjectId);
		}
		if (value.Repository is { } localRepository)
		{
			writer.WritePropertyName(JsonEncText_repository);
			Serialize(writer, localRepository);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitForkRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("creator"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Creator = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Creator = new(); Deserialize(ref reader, obj.Creator); break; }
						throw new InvalidOperationException($"unexpected token type for Creator: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isLocked"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsLocked = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsLocked = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsLocked = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsLocked: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isLockedBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsLockedBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.IsLockedBy = new(); Deserialize(ref reader, obj.IsLockedBy); break; }
						throw new InvalidOperationException($"unexpected token type for IsLockedBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("objectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("peeledObjectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.PeeledObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.PeeledObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for PeeledObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("repository"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Repository = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Repository = new(); Deserialize(ref reader, obj.Repository); break; }
						throw new InvalidOperationException($"unexpected token type for Repository: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Creator is { } localCreator)
		{
			writer.WritePropertyName(JsonEncText_creator);
			Serialize(writer, localCreator);
		}
		if (value.IsLocked is { } localIsLocked)
		{
			writer.WritePropertyName(JsonEncText_isLocked);
			writer.WriteBooleanValue(localIsLocked);
		}
		if (value.IsLockedBy is { } localIsLockedBy)
		{
			writer.WritePropertyName(JsonEncText_isLockedBy);
			Serialize(writer, localIsLockedBy);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.ObjectId is { } localObjectId)
		{
			writer.WritePropertyName(JsonEncText_objectId);
			writer.WriteStringValue(localObjectId);
		}
		if (value.PeeledObjectId is { } localPeeledObjectId)
		{
			writer.WritePropertyName(JsonEncText_peeledObjectId);
			writer.WriteStringValue(localPeeledObjectId);
		}
		if (value.Statuses is { } localStatuses)
		{
			writer.WritePropertyName(JsonEncText_statuses);
			Serialize0(writer, localStatuses);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("creator"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Creator = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Creator = new(); Deserialize(ref reader, obj.Creator); break; }
						throw new InvalidOperationException($"unexpected token type for Creator: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isLocked"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsLocked = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsLocked = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsLocked = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsLocked: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isLockedBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsLockedBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.IsLockedBy = new(); Deserialize(ref reader, obj.IsLockedBy); break; }
						throw new InvalidOperationException($"unexpected token type for IsLockedBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("objectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("peeledObjectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.PeeledObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.PeeledObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for PeeledObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("statuses"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Statuses = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Statuses = new(); Deserialize0(ref reader, obj.Statuses); break; }
						throw new InvalidOperationException($"unexpected token type for Statuses: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRefsResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName(JsonEncText_value);
			Serialize1(writer, localValue);
		}
		if (value.Count is { } localCount)
		{
			writer.WritePropertyName(JsonEncText_count);
			writer.WriteNumberValue(localCount);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRefsResponse obj)
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
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Value = new(); Deserialize1(ref reader, obj.Value); break; }
						throw new InvalidOperationException($"unexpected token type for Value: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("count"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Count = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Count = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Count: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRefUpdate? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.IsLocked is { } localIsLocked)
		{
			writer.WritePropertyName(JsonEncText_isLocked);
			writer.WriteBooleanValue(localIsLocked);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.NewObjectId is { } localNewObjectId)
		{
			writer.WritePropertyName(JsonEncText_newObjectId);
			writer.WriteStringValue(localNewObjectId);
		}
		if (value.OldObjectId is { } localOldObjectId)
		{
			writer.WritePropertyName(JsonEncText_oldObjectId);
			writer.WriteStringValue(localOldObjectId);
		}
		if (value.RepositoryId is { } localRepositoryId)
		{
			writer.WritePropertyName(JsonEncText_repositoryId);
			writer.WriteStringValue(localRepositoryId);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRefUpdate obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("isLocked"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsLocked = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsLocked = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsLocked = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsLocked: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("newObjectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.NewObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.NewObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for NewObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("oldObjectId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.OldObjectId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.OldObjectId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for OldObjectId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("repositoryId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.RepositoryId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.RepositoryId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for RepositoryId: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRepositoriesResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Count is { } localCount)
		{
			writer.WritePropertyName(JsonEncText_count);
			writer.WriteNumberValue(localCount);
		}
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName(JsonEncText_value);
			Serialize2(writer, localValue);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRepositoriesResponse obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("count"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Count = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Count = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Count: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("value"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Value = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Value = new(); Deserialize2(ref reader, obj.Value); break; }
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
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRepository? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.CreationDate is { } localCreationDate)
		{
			writer.WritePropertyName(JsonEncText_creationDate);
			writer.WriteStringValue(localCreationDate);
		}
		if (value.DefaultBranch is { } localDefaultBranch)
		{
			writer.WritePropertyName(JsonEncText_defaultBranch);
			writer.WriteStringValue(localDefaultBranch);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.IsDisabled is { } localIsDisabled)
		{
			writer.WritePropertyName(JsonEncText_isDisabled);
			writer.WriteBooleanValue(localIsDisabled);
		}
		if (value.IsFork is { } localIsFork)
		{
			writer.WritePropertyName(JsonEncText_isFork);
			writer.WriteBooleanValue(localIsFork);
		}
		if (value.IsInMaintenance is { } localIsInMaintenance)
		{
			writer.WritePropertyName(JsonEncText_isInMaintenance);
			writer.WriteBooleanValue(localIsInMaintenance);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.ParentRepository is { } localParentRepository)
		{
			writer.WritePropertyName(JsonEncText_parentRepository);
			Serialize(writer, localParentRepository);
		}
		if (value.Project is { } localProject)
		{
			writer.WritePropertyName(JsonEncText_project);
			Serialize(writer, localProject);
		}
		if (value.RemoteUrl is { } localRemoteUrl)
		{
			writer.WritePropertyName(JsonEncText_remoteUrl);
			writer.WriteStringValue(localRemoteUrl);
		}
		if (value.Size is { } localSize)
		{
			writer.WritePropertyName(JsonEncText_size);
			writer.WriteNumberValue(localSize);
		}
		if (value.SshUrl is { } localSshUrl)
		{
			writer.WritePropertyName(JsonEncText_sshUrl);
			writer.WriteStringValue(localSshUrl);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		if (value.ValidRemoteUrls is { } localValidRemoteUrls)
		{
			writer.WritePropertyName(JsonEncText_validRemoteUrls);
			Serialize3(writer, localValidRemoteUrls);
		}
		if (value.WebUrl is { } localWebUrl)
		{
			writer.WritePropertyName(JsonEncText_webUrl);
			writer.WriteStringValue(localWebUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRepository obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("creationDate"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CreationDate = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.CreationDate = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for CreationDate: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("defaultBranch"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DefaultBranch = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DefaultBranch = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DefaultBranch: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isDisabled"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsDisabled = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsDisabled = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsDisabled = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsDisabled: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isFork"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsFork = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsFork = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsFork = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsFork: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isInMaintenance"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsInMaintenance = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsInMaintenance = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsInMaintenance = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsInMaintenance: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("parentRepository"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ParentRepository = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.ParentRepository = new(); Deserialize(ref reader, obj.ParentRepository); break; }
						throw new InvalidOperationException($"unexpected token type for ParentRepository: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("project"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Project = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Project = new(); Deserialize(ref reader, obj.Project); break; }
						throw new InvalidOperationException($"unexpected token type for Project: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("remoteUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.RemoteUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.RemoteUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for RemoteUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("size"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Size = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Size = reader.GetInt64(); break; }
						throw new InvalidOperationException($"unexpected token type for Size: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("sshUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.SshUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.SshUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for SshUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("validRemoteUrls"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ValidRemoteUrls = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.ValidRemoteUrls = new(); Deserialize3(ref reader, obj.ValidRemoteUrls); break; }
						throw new InvalidOperationException($"unexpected token type for ValidRemoteUrls: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("webUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.WebUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.WebUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for WebUrl: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitRepositoryRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Collection is { } localCollection)
		{
			writer.WritePropertyName(JsonEncText_collection);
			Serialize(writer, localCollection);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.IsFork is { } localIsFork)
		{
			writer.WritePropertyName(JsonEncText_isFork);
			writer.WriteBooleanValue(localIsFork);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.Project is { } localProject)
		{
			writer.WritePropertyName(JsonEncText_project);
			Serialize(writer, localProject);
		}
		if (value.RemoteUrl is { } localRemoteUrl)
		{
			writer.WritePropertyName(JsonEncText_remoteUrl);
			writer.WriteStringValue(localRemoteUrl);
		}
		if (value.SshUrl is { } localSshUrl)
		{
			writer.WritePropertyName(JsonEncText_sshUrl);
			writer.WriteStringValue(localSshUrl);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitRepositoryRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("collection"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Collection = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Collection = new(); Deserialize(ref reader, obj.Collection); break; }
						throw new InvalidOperationException($"unexpected token type for Collection: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isFork"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsFork = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsFork = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsFork = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsFork: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("project"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Project = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Project = new(); Deserialize(ref reader, obj.Project); break; }
						throw new InvalidOperationException($"unexpected token type for Project: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("remoteUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.RemoteUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.RemoteUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for RemoteUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("sshUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.SshUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.SshUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for SshUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitStatus? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Context is { } localContext)
		{
			writer.WritePropertyName(JsonEncText_context);
			Serialize(writer, localContext);
		}
		if (value.CreatedBy is { } localCreatedBy)
		{
			writer.WritePropertyName(JsonEncText_createdBy);
			Serialize(writer, localCreatedBy);
		}
		if (value.CreationDate is { } localCreationDate)
		{
			writer.WritePropertyName(JsonEncText_creationDate);
			writer.WriteStringValue(localCreationDate);
		}
		if (value.Description is { } localDescription)
		{
			writer.WritePropertyName(JsonEncText_description);
			writer.WriteStringValue(localDescription);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteNumberValue(localId);
		}
		if (value.State is { } localState)
		{
			writer.WritePropertyName(JsonEncText_state);
			writer.WriteStringValue(localState);
		}
		if (value.TargetUrl is { } localTargetUrl)
		{
			writer.WritePropertyName(JsonEncText_targetUrl);
			writer.WriteStringValue(localTargetUrl);
		}
		if (value.UpdatedDate is { } localUpdatedDate)
		{
			writer.WritePropertyName(JsonEncText_updatedDate);
			writer.WriteStringValue(localUpdatedDate);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitStatus obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("context"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Context = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Context = new(); Deserialize(ref reader, obj.Context); break; }
						throw new InvalidOperationException($"unexpected token type for Context: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("createdBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CreatedBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.CreatedBy = new(); Deserialize(ref reader, obj.CreatedBy); break; }
						throw new InvalidOperationException($"unexpected token type for CreatedBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("creationDate"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CreationDate = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.CreationDate = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for CreationDate: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("description"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Description = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Description = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Description: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Id = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("state"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.State = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.State = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for State: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("targetUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.TargetUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.TargetUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for TargetUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("updatedDate"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.UpdatedDate = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.UpdatedDate = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for UpdatedDate: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitStatusContext? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Genre is { } localGenre)
		{
			writer.WritePropertyName(JsonEncText_genre);
			writer.WriteStringValue(localGenre);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitStatusContext obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("genre"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Genre = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Genre = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Genre: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitUserDate? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Date is { } localDate)
		{
			writer.WritePropertyName(JsonEncText_date);
			writer.WriteStringValue(localDate);
		}
		if (value.Email is { } localEmail)
		{
			writer.WritePropertyName(JsonEncText_email);
			writer.WriteStringValue(localEmail);
		}
		if (value.ImageUrl is { } localImageUrl)
		{
			writer.WritePropertyName(JsonEncText_imageUrl);
			writer.WriteStringValue(localImageUrl);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitUserDate obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("date"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Date = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Date = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Date: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("email"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Email = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Email = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Email: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("imageUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ImageUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ImageUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ImageUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitMerge? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Comment is { } localComment)
		{
			writer.WritePropertyName(JsonEncText_comment);
			writer.WriteStringValue(localComment);
		}
		if (value.DetailedStatus is { } localDetailedStatus)
		{
			writer.WritePropertyName(JsonEncText_detailedStatus);
			Serialize(writer, localDetailedStatus);
		}
		if (value.MergeOperationId is { } localMergeOperationId)
		{
			writer.WritePropertyName(JsonEncText_mergeOperationId);
			writer.WriteNumberValue(localMergeOperationId);
		}
		if (value.Parents is { } localParents)
		{
			writer.WritePropertyName(JsonEncText_parents);
			Serialize3(writer, localParents);
		}
		if (value.Status is { } localStatus)
		{
			writer.WritePropertyName(JsonEncText_status);
			writer.WriteStringValue(localStatus);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitMerge obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("comment"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Comment = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Comment = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Comment: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("detailedStatus"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DetailedStatus = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.DetailedStatus = new(); Deserialize(ref reader, obj.DetailedStatus); break; }
						throw new InvalidOperationException($"unexpected token type for DetailedStatus: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeOperationId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeOperationId = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.MergeOperationId = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for MergeOperationId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("parents"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Parents = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Parents = new(); Deserialize3(ref reader, obj.Parents); break; }
						throw new InvalidOperationException($"unexpected token type for Parents: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("status"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Status = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Status = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Status: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitMergeOperationStatusDetail? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.FailureMessage is { } localFailureMessage)
		{
			writer.WritePropertyName(JsonEncText_failureMessage);
			writer.WriteStringValue(localFailureMessage);
		}
		if (value.MergeCommitId is { } localMergeCommitId)
		{
			writer.WritePropertyName(JsonEncText_mergeCommitId);
			writer.WriteStringValue(localMergeCommitId);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitMergeOperationStatusDetail obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("failureMessage"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.FailureMessage = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.FailureMessage = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for FailureMessage: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeCommitId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeCommitId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeCommitId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeCommitId: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitMergeParameters? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Comment is { } localComment)
		{
			writer.WritePropertyName(JsonEncText_comment);
			writer.WriteStringValue(localComment);
		}
		if (value.Parents is { } localParents)
		{
			writer.WritePropertyName(JsonEncText_parents);
			Serialize3(writer, localParents);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitMergeParameters obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("comment"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Comment = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Comment = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Comment: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("parents"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Parents = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Parents = new(); Deserialize3(ref reader, obj.Parents); break; }
						throw new InvalidOperationException($"unexpected token type for Parents: {reader.TokenType} ");
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
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.ArtifactId is { } localArtifactId)
		{
			writer.WritePropertyName(JsonEncText_artifactId);
			writer.WriteStringValue(localArtifactId);
		}
		if (value.AutoCompleteSetBy is { } localAutoCompleteSetBy)
		{
			writer.WritePropertyName(JsonEncText_autoCompleteSetBy);
			Serialize(writer, localAutoCompleteSetBy);
		}
		if (value.ClosedBy is { } localClosedBy)
		{
			writer.WritePropertyName(JsonEncText_closedBy);
			Serialize(writer, localClosedBy);
		}
		if (value.ClosedDate is { } localClosedDate)
		{
			writer.WritePropertyName(JsonEncText_closedDate);
			writer.WriteStringValue(localClosedDate);
		}
		if (value.CodeReviewId is { } localCodeReviewId)
		{
			writer.WritePropertyName(JsonEncText_codeReviewId);
			writer.WriteNumberValue(localCodeReviewId);
		}
		if (value.Commits is { } localCommits)
		{
			writer.WritePropertyName(JsonEncText_commits);
			Serialize4(writer, localCommits);
		}
		if (value.CompletionOptions is { } localCompletionOptions)
		{
			writer.WritePropertyName(JsonEncText_completionOptions);
			Serialize(writer, localCompletionOptions);
		}
		if (value.CompletionQueueTime is { } localCompletionQueueTime)
		{
			writer.WritePropertyName(JsonEncText_completionQueueTime);
			writer.WriteStringValue(localCompletionQueueTime);
		}
		if (value.CreatedBy is { } localCreatedBy)
		{
			writer.WritePropertyName(JsonEncText_createdBy);
			Serialize(writer, localCreatedBy);
		}
		if (value.CreationDate is { } localCreationDate)
		{
			writer.WritePropertyName(JsonEncText_creationDate);
			writer.WriteStringValue(localCreationDate);
		}
		if (value.Description is { } localDescription)
		{
			writer.WritePropertyName(JsonEncText_description);
			writer.WriteStringValue(localDescription);
		}
		if (value.ForkSource is { } localForkSource)
		{
			writer.WritePropertyName(JsonEncText_forkSource);
			Serialize(writer, localForkSource);
		}
		if (value.HasMultipleMergeBases is { } localHasMultipleMergeBases)
		{
			writer.WritePropertyName(JsonEncText_hasMultipleMergeBases);
			writer.WriteBooleanValue(localHasMultipleMergeBases);
		}
		if (value.IgnoreTargetRefAndChooseDynamically is { } localIgnoreTargetRefAndChooseDynamically)
		{
			writer.WritePropertyName(JsonEncText_ignoreTargetRefAndChooseDynamically);
			writer.WriteBooleanValue(localIgnoreTargetRefAndChooseDynamically);
		}
		if (value.IsDraft is { } localIsDraft)
		{
			writer.WritePropertyName(JsonEncText_isDraft);
			writer.WriteBooleanValue(localIsDraft);
		}
		if (value.Labels is { } localLabels)
		{
			writer.WritePropertyName(JsonEncText_labels);
			Serialize5(writer, localLabels);
		}
		if (value.LastMergeCommit is { } localLastMergeCommit)
		{
			writer.WritePropertyName(JsonEncText_lastMergeCommit);
			Serialize(writer, localLastMergeCommit);
		}
		if (value.LastMergeSourceCommit is { } localLastMergeSourceCommit)
		{
			writer.WritePropertyName(JsonEncText_lastMergeSourceCommit);
			Serialize(writer, localLastMergeSourceCommit);
		}
		if (value.LastMergeTargetCommit is { } localLastMergeTargetCommit)
		{
			writer.WritePropertyName(JsonEncText_lastMergeTargetCommit);
			Serialize(writer, localLastMergeTargetCommit);
		}
		if (value.MergeFailureMessage is { } localMergeFailureMessage)
		{
			writer.WritePropertyName(JsonEncText_mergeFailureMessage);
			writer.WriteStringValue(localMergeFailureMessage);
		}
		if (value.MergeFailureType is { } localMergeFailureType)
		{
			writer.WritePropertyName(JsonEncText_mergeFailureType);
			writer.WriteStringValue(localMergeFailureType);
		}
		if (value.MergeId is { } localMergeId)
		{
			writer.WritePropertyName(JsonEncText_mergeId);
			writer.WriteStringValue(localMergeId);
		}
		if (value.MergeOptions is { } localMergeOptions)
		{
			writer.WritePropertyName(JsonEncText_mergeOptions);
			Serialize(writer, localMergeOptions);
		}
		if (value.MergeStatus is { } localMergeStatus)
		{
			writer.WritePropertyName(JsonEncText_mergeStatus);
			writer.WriteStringValue(localMergeStatus);
		}
		if (value.PullRequestId is { } localPullRequestId)
		{
			writer.WritePropertyName(JsonEncText_pullRequestId);
			writer.WriteNumberValue(localPullRequestId);
		}
		if (value.RemoteUrl is { } localRemoteUrl)
		{
			writer.WritePropertyName(JsonEncText_remoteUrl);
			writer.WriteStringValue(localRemoteUrl);
		}
		if (value.Repository is { } localRepository)
		{
			writer.WritePropertyName(JsonEncText_repository);
			Serialize(writer, localRepository);
		}
		if (value.Reviewers is { } localReviewers)
		{
			writer.WritePropertyName(JsonEncText_reviewers);
			Serialize6(writer, localReviewers);
		}
		if (value.SourceRefName is { } localSourceRefName)
		{
			writer.WritePropertyName(JsonEncText_sourceRefName);
			writer.WriteStringValue(localSourceRefName);
		}
		if (value.Status is { } localStatus)
		{
			writer.WritePropertyName(JsonEncText_status);
			writer.WriteStringValue(localStatus);
		}
		if (value.SupportsIterations is { } localSupportsIterations)
		{
			writer.WritePropertyName(JsonEncText_supportsIterations);
			writer.WriteBooleanValue(localSupportsIterations);
		}
		if (value.TargetRefName is { } localTargetRefName)
		{
			writer.WritePropertyName(JsonEncText_targetRefName);
			writer.WriteStringValue(localTargetRefName);
		}
		if (value.Title is { } localTitle)
		{
			writer.WritePropertyName(JsonEncText_title);
			writer.WriteStringValue(localTitle);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		if (value.WorkItemRefs is { } localWorkItemRefs)
		{
			writer.WritePropertyName(JsonEncText_workItemRefs);
			Serialize7(writer, localWorkItemRefs);
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
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("artifactId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ArtifactId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ArtifactId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ArtifactId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("autoCompleteSetBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.AutoCompleteSetBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.AutoCompleteSetBy = new(); Deserialize(ref reader, obj.AutoCompleteSetBy); break; }
						throw new InvalidOperationException($"unexpected token type for AutoCompleteSetBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("closedBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ClosedBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.ClosedBy = new(); Deserialize(ref reader, obj.ClosedBy); break; }
						throw new InvalidOperationException($"unexpected token type for ClosedBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("closedDate"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ClosedDate = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ClosedDate = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ClosedDate: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("codeReviewId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CodeReviewId = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.CodeReviewId = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for CodeReviewId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("commits"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Commits = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Commits = new(); Deserialize4(ref reader, obj.Commits); break; }
						throw new InvalidOperationException($"unexpected token type for Commits: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("completionOptions"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CompletionOptions = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.CompletionOptions = new(); Deserialize(ref reader, obj.CompletionOptions); break; }
						throw new InvalidOperationException($"unexpected token type for CompletionOptions: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("completionQueueTime"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CompletionQueueTime = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.CompletionQueueTime = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for CompletionQueueTime: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("createdBy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CreatedBy = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.CreatedBy = new(); Deserialize(ref reader, obj.CreatedBy); break; }
						throw new InvalidOperationException($"unexpected token type for CreatedBy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("creationDate"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.CreationDate = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.CreationDate = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for CreationDate: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("description"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Description = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Description = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Description: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("forkSource"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ForkSource = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.ForkSource = new(); Deserialize(ref reader, obj.ForkSource); break; }
						throw new InvalidOperationException($"unexpected token type for ForkSource: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("hasMultipleMergeBases"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.HasMultipleMergeBases = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.HasMultipleMergeBases = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.HasMultipleMergeBases = false; break; }
						throw new InvalidOperationException($"unexpected token type for HasMultipleMergeBases: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("ignoreTargetRefAndChooseDynamically"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IgnoreTargetRefAndChooseDynamically = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IgnoreTargetRefAndChooseDynamically = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IgnoreTargetRefAndChooseDynamically = false; break; }
						throw new InvalidOperationException($"unexpected token type for IgnoreTargetRefAndChooseDynamically: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isDraft"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsDraft = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsDraft = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsDraft = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsDraft: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("labels"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Labels = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Labels = new(); Deserialize5(ref reader, obj.Labels); break; }
						throw new InvalidOperationException($"unexpected token type for Labels: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("lastMergeCommit"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.LastMergeCommit = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.LastMergeCommit = new(); Deserialize(ref reader, obj.LastMergeCommit); break; }
						throw new InvalidOperationException($"unexpected token type for LastMergeCommit: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("lastMergeSourceCommit"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.LastMergeSourceCommit = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.LastMergeSourceCommit = new(); Deserialize(ref reader, obj.LastMergeSourceCommit); break; }
						throw new InvalidOperationException($"unexpected token type for LastMergeSourceCommit: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("lastMergeTargetCommit"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.LastMergeTargetCommit = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.LastMergeTargetCommit = new(); Deserialize(ref reader, obj.LastMergeTargetCommit); break; }
						throw new InvalidOperationException($"unexpected token type for LastMergeTargetCommit: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeFailureMessage"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeFailureMessage = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeFailureMessage = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeFailureMessage: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeFailureType"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeFailureType = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeFailureType = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeFailureType: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeId = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeId = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeOptions"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeOptions = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.MergeOptions = new(); Deserialize(ref reader, obj.MergeOptions); break; }
						throw new InvalidOperationException($"unexpected token type for MergeOptions: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeStatus"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeStatus = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeStatus = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeStatus: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("pullRequestId"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.PullRequestId = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.PullRequestId = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for PullRequestId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("remoteUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.RemoteUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.RemoteUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for RemoteUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("repository"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Repository = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Repository = new(); Deserialize(ref reader, obj.Repository); break; }
						throw new InvalidOperationException($"unexpected token type for Repository: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("reviewers"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Reviewers = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Reviewers = new(); Deserialize6(ref reader, obj.Reviewers); break; }
						throw new InvalidOperationException($"unexpected token type for Reviewers: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("sourceRefName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.SourceRefName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.SourceRefName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for SourceRefName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("status"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Status = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Status = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Status: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("supportsIterations"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.SupportsIterations = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.SupportsIterations = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.SupportsIterations = false; break; }
						throw new InvalidOperationException($"unexpected token type for SupportsIterations: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("targetRefName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.TargetRefName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.TargetRefName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for TargetRefName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("title"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Title = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Title = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Title: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("workItemRefs"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.WorkItemRefs = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.WorkItemRefs = new(); Deserialize7(ref reader, obj.WorkItemRefs); break; }
						throw new InvalidOperationException($"unexpected token type for WorkItemRefs: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitPullRequestCompletionOptions? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.AutoCompleteIgnoreConfigIds is { } localAutoCompleteIgnoreConfigIds)
		{
			writer.WritePropertyName(JsonEncText_autoCompleteIgnoreConfigIds);
			Serialize8(writer, localAutoCompleteIgnoreConfigIds);
		}
		if (value.BypassPolicy is { } localBypassPolicy)
		{
			writer.WritePropertyName(JsonEncText_bypassPolicy);
			writer.WriteBooleanValue(localBypassPolicy);
		}
		if (value.BypassReason is { } localBypassReason)
		{
			writer.WritePropertyName(JsonEncText_bypassReason);
			writer.WriteStringValue(localBypassReason);
		}
		if (value.DeleteSourceBranch is { } localDeleteSourceBranch)
		{
			writer.WritePropertyName(JsonEncText_deleteSourceBranch);
			writer.WriteBooleanValue(localDeleteSourceBranch);
		}
		if (value.MergeCommitMessage is { } localMergeCommitMessage)
		{
			writer.WritePropertyName(JsonEncText_mergeCommitMessage);
			writer.WriteStringValue(localMergeCommitMessage);
		}
		if (value.MergeStrategy is { } localMergeStrategy)
		{
			writer.WritePropertyName(JsonEncText_mergeStrategy);
			writer.WriteStringValue(localMergeStrategy);
		}
		if (value.SquashMerge is { } localSquashMerge)
		{
			writer.WritePropertyName(JsonEncText_squashMerge);
			writer.WriteBooleanValue(localSquashMerge);
		}
		if (value.TransitionWorkItems is { } localTransitionWorkItems)
		{
			writer.WritePropertyName(JsonEncText_transitionWorkItems);
			writer.WriteBooleanValue(localTransitionWorkItems);
		}
		if (value.TriggeredByAutoComplete is { } localTriggeredByAutoComplete)
		{
			writer.WritePropertyName(JsonEncText_triggeredByAutoComplete);
			writer.WriteBooleanValue(localTriggeredByAutoComplete);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitPullRequestCompletionOptions obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("autoCompleteIgnoreConfigIds"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.AutoCompleteIgnoreConfigIds = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.AutoCompleteIgnoreConfigIds = new(); Deserialize8(ref reader, obj.AutoCompleteIgnoreConfigIds); break; }
						throw new InvalidOperationException($"unexpected token type for AutoCompleteIgnoreConfigIds: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("bypassPolicy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.BypassPolicy = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.BypassPolicy = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.BypassPolicy = false; break; }
						throw new InvalidOperationException($"unexpected token type for BypassPolicy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("bypassReason"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.BypassReason = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.BypassReason = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for BypassReason: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("deleteSourceBranch"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DeleteSourceBranch = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.DeleteSourceBranch = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.DeleteSourceBranch = false; break; }
						throw new InvalidOperationException($"unexpected token type for DeleteSourceBranch: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeCommitMessage"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeCommitMessage = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeCommitMessage = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeCommitMessage: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("mergeStrategy"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.MergeStrategy = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.MergeStrategy = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for MergeStrategy: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("squashMerge"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.SquashMerge = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.SquashMerge = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.SquashMerge = false; break; }
						throw new InvalidOperationException($"unexpected token type for SquashMerge: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("transitionWorkItems"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.TransitionWorkItems = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.TransitionWorkItems = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.TransitionWorkItems = false; break; }
						throw new InvalidOperationException($"unexpected token type for TransitionWorkItems: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("triggeredByAutoComplete"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.TriggeredByAutoComplete = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.TriggeredByAutoComplete = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.TriggeredByAutoComplete = false; break; }
						throw new InvalidOperationException($"unexpected token type for TriggeredByAutoComplete: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitPullRequestMergeOptions? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.ConflictAuthorshipCommits is { } localConflictAuthorshipCommits)
		{
			writer.WritePropertyName(JsonEncText_conflictAuthorshipCommits);
			writer.WriteBooleanValue(localConflictAuthorshipCommits);
		}
		if (value.DetectRenameFalsePositives is { } localDetectRenameFalsePositives)
		{
			writer.WritePropertyName(JsonEncText_detectRenameFalsePositives);
			writer.WriteBooleanValue(localDetectRenameFalsePositives);
		}
		if (value.DisableRenames is { } localDisableRenames)
		{
			writer.WritePropertyName(JsonEncText_disableRenames);
			writer.WriteBooleanValue(localDisableRenames);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.GitPullRequestMergeOptions obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("conflictAuthorshipCommits"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ConflictAuthorshipCommits = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.ConflictAuthorshipCommits = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.ConflictAuthorshipCommits = false; break; }
						throw new InvalidOperationException($"unexpected token type for ConflictAuthorshipCommits: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("detectRenameFalsePositives"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DetectRenameFalsePositives = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.DetectRenameFalsePositives = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.DetectRenameFalsePositives = false; break; }
						throw new InvalidOperationException($"unexpected token type for DetectRenameFalsePositives: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("disableRenames"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DisableRenames = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.DisableRenames = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.DisableRenames = false; break; }
						throw new InvalidOperationException($"unexpected token type for DisableRenames: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.GitPullRequestsResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName(JsonEncText_value);
			Serialize9(writer, localValue);
		}
		if (value.Count is { } localCount)
		{
			writer.WritePropertyName(JsonEncText_count);
			writer.WriteNumberValue(localCount);
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
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Value = new(); Deserialize9(ref reader, obj.Value); break; }
						throw new InvalidOperationException($"unexpected token type for Value: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("count"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Count = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Count = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Count: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.IdentityRefWithVote? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Descriptor is { } localDescriptor)
		{
			writer.WritePropertyName(JsonEncText_descriptor);
			writer.WriteStringValue(localDescriptor);
		}
		if (value.DirectoryAlias is { } localDirectoryAlias)
		{
			writer.WritePropertyName(JsonEncText_directoryAlias);
			writer.WriteStringValue(localDirectoryAlias);
		}
		if (value.DisplayName is { } localDisplayName)
		{
			writer.WritePropertyName(JsonEncText_displayName);
			writer.WriteStringValue(localDisplayName);
		}
		if (value.HasDeclined is { } localHasDeclined)
		{
			writer.WritePropertyName(JsonEncText_hasDeclined);
			writer.WriteBooleanValue(localHasDeclined);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.ImageUrl is { } localImageUrl)
		{
			writer.WritePropertyName(JsonEncText_imageUrl);
			writer.WriteStringValue(localImageUrl);
		}
		if (value.Inactive is { } localInactive)
		{
			writer.WritePropertyName(JsonEncText_inactive);
			writer.WriteBooleanValue(localInactive);
		}
		if (value.IsAadIdentity is { } localIsAadIdentity)
		{
			writer.WritePropertyName(JsonEncText_isAadIdentity);
			writer.WriteBooleanValue(localIsAadIdentity);
		}
		if (value.IsContainer is { } localIsContainer)
		{
			writer.WritePropertyName(JsonEncText_isContainer);
			writer.WriteBooleanValue(localIsContainer);
		}
		if (value.IsDeletedInOrigin is { } localIsDeletedInOrigin)
		{
			writer.WritePropertyName(JsonEncText_isDeletedInOrigin);
			writer.WriteBooleanValue(localIsDeletedInOrigin);
		}
		if (value.IsFlagged is { } localIsFlagged)
		{
			writer.WritePropertyName(JsonEncText_isFlagged);
			writer.WriteBooleanValue(localIsFlagged);
		}
		if (value.IsReapprove is { } localIsReapprove)
		{
			writer.WritePropertyName(JsonEncText_isReapprove);
			writer.WriteBooleanValue(localIsReapprove);
		}
		if (value.IsRequired is { } localIsRequired)
		{
			writer.WritePropertyName(JsonEncText_isRequired);
			writer.WriteBooleanValue(localIsRequired);
		}
		if (value.ProfileUrl is { } localProfileUrl)
		{
			writer.WritePropertyName(JsonEncText_profileUrl);
			writer.WriteStringValue(localProfileUrl);
		}
		if (value.ReviewerUrl is { } localReviewerUrl)
		{
			writer.WritePropertyName(JsonEncText_reviewerUrl);
			writer.WriteStringValue(localReviewerUrl);
		}
		if (value.UniqueName is { } localUniqueName)
		{
			writer.WritePropertyName(JsonEncText_uniqueName);
			writer.WriteStringValue(localUniqueName);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		if (value.Vote is { } localVote)
		{
			writer.WritePropertyName(JsonEncText_vote);
			writer.WriteNumberValue(localVote);
		}
		if (value.VotedFor is { } localVotedFor)
		{
			writer.WritePropertyName(JsonEncText_votedFor);
			Serialize6(writer, localVotedFor);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.IdentityRefWithVote obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("descriptor"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Descriptor = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Descriptor = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Descriptor: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("directoryAlias"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DirectoryAlias = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DirectoryAlias = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DirectoryAlias: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("displayName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DisplayName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DisplayName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DisplayName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("hasDeclined"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.HasDeclined = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.HasDeclined = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.HasDeclined = false; break; }
						throw new InvalidOperationException($"unexpected token type for HasDeclined: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("imageUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ImageUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ImageUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ImageUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("inactive"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Inactive = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.Inactive = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.Inactive = false; break; }
						throw new InvalidOperationException($"unexpected token type for Inactive: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isAadIdentity"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsAadIdentity = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsAadIdentity = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsAadIdentity = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsAadIdentity: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isContainer"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsContainer = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsContainer = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsContainer = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsContainer: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isDeletedInOrigin"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsDeletedInOrigin = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsDeletedInOrigin = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsDeletedInOrigin = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsDeletedInOrigin: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isFlagged"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsFlagged = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsFlagged = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsFlagged = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsFlagged: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isReapprove"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsReapprove = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsReapprove = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsReapprove = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsReapprove: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isRequired"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsRequired = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsRequired = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsRequired = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsRequired: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("profileUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ProfileUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ProfileUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ProfileUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("reviewerUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ReviewerUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ReviewerUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ReviewerUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("uniqueName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.UniqueName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.UniqueName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for UniqueName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("vote"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Vote = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Vote = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Vote: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("votedFor"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.VotedFor = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.VotedFor = new(); Deserialize6(ref reader, obj.VotedFor); break; }
						throw new InvalidOperationException($"unexpected token type for VotedFor: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.IdentityRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			writer.WritePropertyName(JsonEncText__links);
			Serialize(writer, localLinks);
		}
		if (value.Descriptor is { } localDescriptor)
		{
			writer.WritePropertyName(JsonEncText_descriptor);
			writer.WriteStringValue(localDescriptor);
		}
		if (value.DirectoryAlias is { } localDirectoryAlias)
		{
			writer.WritePropertyName(JsonEncText_directoryAlias);
			writer.WriteStringValue(localDirectoryAlias);
		}
		if (value.DisplayName is { } localDisplayName)
		{
			writer.WritePropertyName(JsonEncText_displayName);
			writer.WriteStringValue(localDisplayName);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.ImageUrl is { } localImageUrl)
		{
			writer.WritePropertyName(JsonEncText_imageUrl);
			writer.WriteStringValue(localImageUrl);
		}
		if (value.Inactive is { } localInactive)
		{
			writer.WritePropertyName(JsonEncText_inactive);
			writer.WriteBooleanValue(localInactive);
		}
		if (value.IsAadIdentity is { } localIsAadIdentity)
		{
			writer.WritePropertyName(JsonEncText_isAadIdentity);
			writer.WriteBooleanValue(localIsAadIdentity);
		}
		if (value.IsContainer is { } localIsContainer)
		{
			writer.WritePropertyName(JsonEncText_isContainer);
			writer.WriteBooleanValue(localIsContainer);
		}
		if (value.IsDeletedInOrigin is { } localIsDeletedInOrigin)
		{
			writer.WritePropertyName(JsonEncText_isDeletedInOrigin);
			writer.WriteBooleanValue(localIsDeletedInOrigin);
		}
		if (value.ProfileUrl is { } localProfileUrl)
		{
			writer.WritePropertyName(JsonEncText_profileUrl);
			writer.WriteStringValue(localProfileUrl);
		}
		if (value.UniqueName is { } localUniqueName)
		{
			writer.WritePropertyName(JsonEncText_uniqueName);
			writer.WriteStringValue(localUniqueName);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.IdentityRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("_links"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Links = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Links = new(); Deserialize(ref reader, obj.Links); break; }
						throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("descriptor"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Descriptor = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Descriptor = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Descriptor: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("directoryAlias"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DirectoryAlias = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DirectoryAlias = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DirectoryAlias: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("displayName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DisplayName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DisplayName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DisplayName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("imageUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ImageUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ImageUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ImageUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("inactive"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Inactive = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.Inactive = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.Inactive = false; break; }
						throw new InvalidOperationException($"unexpected token type for Inactive: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isAadIdentity"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsAadIdentity = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsAadIdentity = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsAadIdentity = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsAadIdentity: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isContainer"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsContainer = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsContainer = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsContainer = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsContainer: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("isDeletedInOrigin"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.IsDeletedInOrigin = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.IsDeletedInOrigin = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.IsDeletedInOrigin = false; break; }
						throw new InvalidOperationException($"unexpected token type for IsDeletedInOrigin: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("profileUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.ProfileUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.ProfileUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for ProfileUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("uniqueName"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.UniqueName = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.UniqueName = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for UniqueName: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.ReferenceLink? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Href is { } localHref)
		{
			writer.WritePropertyName(JsonEncText_href);
			writer.WriteStringValue(localHref);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.ReferenceLink obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("href"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Href = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Href = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Href: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.ReferenceLinks? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Links is { } localLinks)
		{
			foreach (var (localLinksKey, localLinksValue) in localLinks)
			{
				writer.WritePropertyName(localLinksKey);
				Serialize(writer, localLinksValue);
			}
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.ReferenceLinks obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{

					obj.Links ??= new();
					var lhs = reader.GetString() ?? throw new NullReferenceException();
					if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
					Pingmint.AzureDevOps.ReferenceLink rhs;
					if (reader.TokenType == JsonTokenType.Null) { break; }
					else if (reader.TokenType == JsonTokenType.StartObject) { rhs = new(); Deserialize(ref reader, rhs); }
					else throw new InvalidOperationException($"unexpected token type for Links: {reader.TokenType} ");
					obj.Links.Add(lhs, rhs);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.ResourceRef? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.ResourceRef obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.TeamProjectCollectionReference? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.AvatarUrl is { } localAvatarUrl)
		{
			writer.WritePropertyName(JsonEncText_avatarUrl);
			writer.WriteStringValue(localAvatarUrl);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.TeamProjectCollectionReference obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("avatarUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.AvatarUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.AvatarUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for AvatarUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.TeamProjectReference? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Abbreviation is { } localAbbreviation)
		{
			writer.WritePropertyName(JsonEncText_abbreviation);
			writer.WriteStringValue(localAbbreviation);
		}
		if (value.DefaultTeamImageUrl is { } localDefaultTeamImageUrl)
		{
			writer.WritePropertyName(JsonEncText_defaultTeamImageUrl);
			writer.WriteStringValue(localDefaultTeamImageUrl);
		}
		if (value.Description is { } localDescription)
		{
			writer.WritePropertyName(JsonEncText_description);
			writer.WriteStringValue(localDescription);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.LastUpdateTime is { } localLastUpdateTime)
		{
			writer.WritePropertyName(JsonEncText_lastUpdateTime);
			writer.WriteStringValue(localLastUpdateTime);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.Revision is { } localRevision)
		{
			writer.WritePropertyName(JsonEncText_revision);
			writer.WriteNumberValue(localRevision);
		}
		if (value.State is { } localState)
		{
			writer.WritePropertyName(JsonEncText_state);
			writer.WriteStringValue(localState);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		if (value.Visibility is { } localVisibility)
		{
			writer.WritePropertyName(JsonEncText_visibility);
			writer.WriteStringValue(localVisibility);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.TeamProjectReference obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("abbreviation"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Abbreviation = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Abbreviation = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Abbreviation: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("defaultTeamImageUrl"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.DefaultTeamImageUrl = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.DefaultTeamImageUrl = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for DefaultTeamImageUrl: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("description"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Description = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Description = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Description: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("lastUpdateTime"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.LastUpdateTime = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.LastUpdateTime = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for LastUpdateTime: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("revision"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Revision = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Revision = reader.GetInt64(); break; }
						throw new InvalidOperationException($"unexpected token type for Revision: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("state"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.State = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.State = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for State: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("visibility"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Visibility = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Visibility = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Visibility: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Pingmint.AzureDevOps.WebApiTagDefinition? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Active is { } localActive)
		{
			writer.WritePropertyName(JsonEncText_active);
			writer.WriteBooleanValue(localActive);
		}
		if (value.Id is { } localId)
		{
			writer.WritePropertyName(JsonEncText_id);
			writer.WriteStringValue(localId);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName(JsonEncText_name);
			writer.WriteStringValue(localName);
		}
		if (value.Url is { } localUrl)
		{
			writer.WritePropertyName(JsonEncText_url);
			writer.WriteStringValue(localUrl);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, Pingmint.AzureDevOps.WebApiTagDefinition obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("active"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Active = null; break; }
						if (reader.TokenType == JsonTokenType.True) { obj.Active = true; break; }
						if (reader.TokenType == JsonTokenType.False) { obj.Active = false; break; }
						throw new InvalidOperationException($"unexpected token type for Active: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("id"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("url"u8))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Url = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Url = reader.GetString()!; break; }
						throw new InvalidOperationException($"unexpected token type for Url: {reader.TokenType} ");
					}

					SkipUnknownPropertyName(ref reader);
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize0(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitStatus>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize0(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitStatus> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.GitStatus item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize1(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitRef>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize1(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitRef> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.GitRef item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize2(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitRepository>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize2(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitRepository> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.GitRepository item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize3(Utf8JsonWriter writer, List<string>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			writer.WriteStringValue(item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize3(ref Utf8JsonReader reader, List<string> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.String:
				{
					var item = reader.GetString();
					array.Add(item!);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize4(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitCommitRef>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize4(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitCommitRef> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.GitCommitRef item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize5(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.WebApiTagDefinition>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize5(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.WebApiTagDefinition> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.WebApiTagDefinition item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize6(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.IdentityRefWithVote>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize6(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.IdentityRefWithVote> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.IdentityRefWithVote item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize7(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.ResourceRef>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize7(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.ResourceRef> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Pingmint.AzureDevOps.ResourceRef item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize8(Utf8JsonWriter writer, List<int>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			writer.WriteNumberValue(item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize8(ref Utf8JsonReader reader, List<int> array)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.Number:
				{
					var item = reader.GetInt32();
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize9(Utf8JsonWriter writer, List<Pingmint.AzureDevOps.GitPullRequest>? array)
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static void Deserialize9(ref Utf8JsonReader reader, List<Pingmint.AzureDevOps.GitPullRequest> array)
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
public sealed partial record class GitCommitRef
{
	public GitUserDate? Author { get; set; }
	public string? Comment { get; set; }
	public string? CommitId { get; set; }
	public GitUserDate? Committer { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class GitForkRef
{
	public ReferenceLinks? Links { get; set; }
	public IdentityRef? Creator { get; set; }
	public bool? IsLocked { get; set; }
	public IdentityRef? IsLockedBy { get; set; }
	public string? Name { get; set; }
	public string? ObjectId { get; set; }
	public string? PeeledObjectId { get; set; }
	public GitRepository? Repository { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class GitRef
{
	public ReferenceLinks? Links { get; set; }
	public IdentityRef? Creator { get; set; }
	public bool? IsLocked { get; set; }
	public IdentityRef? IsLockedBy { get; set; }
	public string? Name { get; set; }
	public string? ObjectId { get; set; }
	public string? PeeledObjectId { get; set; }
	public List<Pingmint.AzureDevOps.GitStatus>? Statuses { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class GitRefsResponse
{
	public List<Pingmint.AzureDevOps.GitRef>? Value { get; set; }
	public int? Count { get; set; }
}
public sealed partial record class GitRefUpdate
{
	public bool? IsLocked { get; set; }
	public string? Name { get; set; }
	public string? NewObjectId { get; set; }
	public string? OldObjectId { get; set; }
	public string? RepositoryId { get; set; }
}
public sealed partial record class GitRepositoriesResponse
{
	public int? Count { get; set; }
	public List<Pingmint.AzureDevOps.GitRepository>? Value { get; set; }
}
public sealed partial record class GitRepository
{
	public ReferenceLinks? Links { get; set; }
	public string? CreationDate { get; set; }
	public string? DefaultBranch { get; set; }
	public string? Id { get; set; }
	public bool? IsDisabled { get; set; }
	public bool? IsFork { get; set; }
	public bool? IsInMaintenance { get; set; }
	public string? Name { get; set; }
	public GitRepositoryRef? ParentRepository { get; set; }
	public TeamProjectReference? Project { get; set; }
	public string? RemoteUrl { get; set; }
	public long? Size { get; set; }
	public string? SshUrl { get; set; }
	public string? Url { get; set; }
	public List<string>? ValidRemoteUrls { get; set; }
	public string? WebUrl { get; set; }
}
public sealed partial record class GitRepositoryRef
{
	public TeamProjectCollectionReference? Collection { get; set; }
	public string? Id { get; set; }
	public bool? IsFork { get; set; }
	public string? Name { get; set; }
	public TeamProjectReference? Project { get; set; }
	public string? RemoteUrl { get; set; }
	public string? SshUrl { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class GitStatus
{
	public ReferenceLinks? Links { get; set; }
	public GitStatusContext? Context { get; set; }
	public IdentityRef? CreatedBy { get; set; }
	public string? CreationDate { get; set; }
	public string? Description { get; set; }
	public int? Id { get; set; }
	public string? State { get; set; }
	public string? TargetUrl { get; set; }
	public string? UpdatedDate { get; set; }
}
public sealed partial record class GitStatusContext
{
	public string? Genre { get; set; }
	public string? Name { get; set; }
}
public sealed partial record class GitUserDate
{
	public string? Date { get; set; }
	public string? Email { get; set; }
	public string? ImageUrl { get; set; }
	public string? Name { get; set; }
}
public sealed partial record class GitMerge
{
	public ReferenceLinks? Links { get; set; }
	public string? Comment { get; set; }
	public GitMergeOperationStatusDetail? DetailedStatus { get; set; }
	public int? MergeOperationId { get; set; }
	public List<string>? Parents { get; set; }
	public string? Status { get; set; }
}
public sealed partial record class GitMergeOperationStatusDetail
{
	public string? FailureMessage { get; set; }
	public string? MergeCommitId { get; set; }
}
public sealed partial record class GitMergeParameters
{
	public string? Comment { get; set; }
	public List<string>? Parents { get; set; }
}
public sealed partial record class GitPullRequest
{
	public ReferenceLinks? Links { get; set; }
	public string? ArtifactId { get; set; }
	public IdentityRef? AutoCompleteSetBy { get; set; }
	public IdentityRef? ClosedBy { get; set; }
	public string? ClosedDate { get; set; }
	public int? CodeReviewId { get; set; }
	public List<Pingmint.AzureDevOps.GitCommitRef>? Commits { get; set; }
	public GitPullRequestCompletionOptions? CompletionOptions { get; set; }
	public string? CompletionQueueTime { get; set; }
	public IdentityRef? CreatedBy { get; set; }
	public string? CreationDate { get; set; }
	public string? Description { get; set; }
	public GitForkRef? ForkSource { get; set; }
	public bool? HasMultipleMergeBases { get; set; }
	public bool? IgnoreTargetRefAndChooseDynamically { get; set; }
	public bool? IsDraft { get; set; }
	public List<Pingmint.AzureDevOps.WebApiTagDefinition>? Labels { get; set; }
	public GitCommitRef? LastMergeCommit { get; set; }
	public GitCommitRef? LastMergeSourceCommit { get; set; }
	public GitCommitRef? LastMergeTargetCommit { get; set; }
	public string? MergeFailureMessage { get; set; }
	public string? MergeFailureType { get; set; }
	public string? MergeId { get; set; }
	public GitPullRequestMergeOptions? MergeOptions { get; set; }
	public string? MergeStatus { get; set; }
	public int? PullRequestId { get; set; }
	public string? RemoteUrl { get; set; }
	public GitRepository? Repository { get; set; }
	public List<Pingmint.AzureDevOps.IdentityRefWithVote>? Reviewers { get; set; }
	public string? SourceRefName { get; set; }
	public string? Status { get; set; }
	public bool? SupportsIterations { get; set; }
	public string? TargetRefName { get; set; }
	public string? Title { get; set; }
	public string? Url { get; set; }
	public List<Pingmint.AzureDevOps.ResourceRef>? WorkItemRefs { get; set; }
}
public sealed partial record class GitPullRequestCompletionOptions
{
	public List<int>? AutoCompleteIgnoreConfigIds { get; set; }
	public bool? BypassPolicy { get; set; }
	public string? BypassReason { get; set; }
	public bool? DeleteSourceBranch { get; set; }
	public string? MergeCommitMessage { get; set; }
	public string? MergeStrategy { get; set; }
	public bool? SquashMerge { get; set; }
	public bool? TransitionWorkItems { get; set; }
	public bool? TriggeredByAutoComplete { get; set; }
}
public sealed partial record class GitPullRequestMergeOptions
{
	public bool? ConflictAuthorshipCommits { get; set; }
	public bool? DetectRenameFalsePositives { get; set; }
	public bool? DisableRenames { get; set; }
}
public sealed partial record class GitPullRequestsResponse
{
	public List<Pingmint.AzureDevOps.GitPullRequest>? Value { get; set; }
	public int? Count { get; set; }
}
public sealed partial record class IdentityRefWithVote
{
	public ReferenceLinks? Links { get; set; }
	public string? Descriptor { get; set; }
	public string? DirectoryAlias { get; set; }
	public string? DisplayName { get; set; }
	public bool? HasDeclined { get; set; }
	public string? Id { get; set; }
	public string? ImageUrl { get; set; }
	public bool? Inactive { get; set; }
	public bool? IsAadIdentity { get; set; }
	public bool? IsContainer { get; set; }
	public bool? IsDeletedInOrigin { get; set; }
	public bool? IsFlagged { get; set; }
	public bool? IsReapprove { get; set; }
	public bool? IsRequired { get; set; }
	public string? ProfileUrl { get; set; }
	public string? ReviewerUrl { get; set; }
	public string? UniqueName { get; set; }
	public string? Url { get; set; }
	public int? Vote { get; set; }
	public List<Pingmint.AzureDevOps.IdentityRefWithVote>? VotedFor { get; set; }
}
public sealed partial record class IdentityRef
{
	public ReferenceLinks? Links { get; set; }
	public string? Descriptor { get; set; }
	public string? DirectoryAlias { get; set; }
	public string? DisplayName { get; set; }
	public string? Id { get; set; }
	public string? ImageUrl { get; set; }
	public bool? Inactive { get; set; }
	public bool? IsAadIdentity { get; set; }
	public bool? IsContainer { get; set; }
	public bool? IsDeletedInOrigin { get; set; }
	public string? ProfileUrl { get; set; }
	public string? UniqueName { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class ReferenceLink
{
	public string? Href { get; set; }
}
public sealed partial record class ReferenceLinks
{
	public Dictionary<String, Pingmint.AzureDevOps.ReferenceLink>? Links { get; set; }
}
public sealed partial record class ResourceRef
{
	public string? Id { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class TeamProjectCollectionReference
{
	public string? AvatarUrl { get; set; }
	public string? Id { get; set; }
	public string? Name { get; set; }
	public string? Url { get; set; }
}
public sealed partial record class TeamProjectReference
{
	public string? Abbreviation { get; set; }
	public string? DefaultTeamImageUrl { get; set; }
	public string? Description { get; set; }
	public string? Id { get; set; }
	public string? LastUpdateTime { get; set; }
	public string? Name { get; set; }
	public long? Revision { get; set; }
	public string? State { get; set; }
	public string? Url { get; set; }
	public string? Visibility { get; set; }
}
public sealed partial record class WebApiTagDefinition
{
	public bool? Active { get; set; }
	public string? Id { get; set; }
	public string? Name { get; set; }
	public string? Url { get; set; }
}
