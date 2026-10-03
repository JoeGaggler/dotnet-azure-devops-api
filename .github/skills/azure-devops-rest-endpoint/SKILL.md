---
name: azure-devops-rest-endpoint
description: 'Add or update support for an Azure DevOps REST API endpoint from its Microsoft Learn documentation URL, or refresh every API in the Supported APIs catalog to the latest release when invoked without an argument. Use when implementing or refreshing an Azure DevOps endpoint, documented request factory method, custom APISerializer schema and generated models, convenience deserializer, API catalog entry, or integration test in this repository.'
argument-hint: '[Microsoft Learn Azure DevOps REST API endpoint URL]'
user-invocable: true
---

# Add or Refresh Azure DevOps REST Endpoints

Implement an Azure DevOps REST API operation from its Microsoft Learn documentation URL, or refresh all currently supported operations when no URL is supplied. Complete the implementation and validation; do not stop at a plan.

## Input

Support two invocation modes.

### Endpoint Mode

When a Microsoft Learn endpoint URL is supplied, implement or update that operation, for example:

`https://learn.microsoft.com/en-us/rest/api/azure/devops/git/pull-requests/get-pull-requests-by-project?view=azure-devops-rest-7.2&tabs=HTTP`

Preserve the requested REST documentation release from the URL unless the user explicitly requests another version.

### Catalog Refresh Mode

When no URL is supplied, do not ask for one. Read `doc/azure-devops-rest-api.md` and treat every operation listed under `## Supported APIs` as the refresh queue. For each operation, use its `Documentation`, `Endpoint`, `Version`, `Request Method`, and `Response Model` entries to identify and audit the existing implementation.

Before editing, discover the latest Azure DevOps REST documentation release published on Microsoft Learn:

1. Inspect the official Azure DevOps REST API documentation and its version selector or page metadata for available releases.
2. Consider every published release, including releases whose operation pages require preview API versions. Never exclude or deprioritize a candidate merely because its exact `api-version` contains `-preview`.
3. Select the numerically newest REST documentation release that contains all cataloged operations. Do not assume the release encoded in the existing catalog URLs is current.
4. Open every cataloged operation at that release and extract the exact required `api-version` from its URI parameters and HTTP sample. Use the complete value, including a preview revision such as `7.2-preview.2`.
5. Compare each discovered value with the cataloged `Version`. A newer numeric preview, such as `7.2-preview.2`, takes precedence over an older stable version such as `7.1`. Use only versions explicitly published by Microsoft; never probe or invent a version number.

This library supports one Azure DevOps REST documentation release at a time. In catalog refresh mode, all documentation URLs and models must target the selected latest release. An operation's exact required `api-version` may include an operation-specific preview suffix. If the newest release does not contain a cataloged operation, report the conflict and stop before creating a mixed-release implementation.

## Source of Truth

Fetch each selected operation page before editing. In endpoint mode this is the supplied page; in catalog refresh mode these are the latest-release pages resolved from the Supported APIs catalog. Extract and verify:

- service, resource group, and operation title
- operation description and parameter descriptions for XML documentation
- HTTP method and route template
- exact required `api-version` value
- required path parameters
- documented query parameters
- response envelope and success status
- complete response model and referenced definitions
- HTTP sample request and response

The page heading, HTTP sample, endpoint, API version, and response definition must agree. In endpoint mode, if the supplied page is for a different operation than the user describes, surface the mismatch and follow the supplied URL unless the user corrects it. In catalog refresh mode, verify each resolved page still represents the cataloged operation before using it.

## Repository Surfaces

Inspect the current versions of these files before editing:

- `src/nuget/APISerializer.txt`
- `src/nuget/APISerializer.partial.cs`
- `src/nuget/HttpRequestFactory.cs`
- `doc/azure-devops-rest-api.md`
- the closest test under `src/test/`
- `.vscode/tasks.json`

Never manually edit `src/nuget/APISerializer.g.cs`; regenerate it from `APISerializer.txt` using the dedicated VS Code task.

## Procedure

### 1. Determine the Work Queue, Names, and Ownership

In endpoint mode, process the supplied operation. In catalog refresh mode, process every operation under `## Supported APIs`; do not add unrelated APIs found while browsing Microsoft Learn. Audit all implementation surfaces for each queued operation even when its version has not changed, because response definitions and parameter metadata may have changed within a documentation release.

Derive names from the documented operation and existing repository conventions:

- request factory: `<OperationName>Request`, such as `GetPullRequestsByProjectRequest`
- response envelope: a descriptive plural response type when the wire response contains `value`
- convenience method: `Deserialize<ResponseType>`
- integration test: a behavior name ending in `Async`

Reuse an existing model when its documented wire shape is the same. Extend its definition if the new endpoint documents additional fields. 
Do not create duplicate models with endpoint-specific names for a shared Azure DevOps definition.

### 2. Update `APISerializer.txt`

Model the documented JSON token types exactly:

- JSON string, including dates, UUIDs, and string enums: `string`
- JSON boolean: `bool`
- JSON int16 or int32: `int`
- JSON int64: `long`
- array: `[ElementType]`
- dictionary: `{ValueType}`
- nested object: a separately declared fully qualified type

Use this property syntax:

```text
Pingmint.AzureDevOps.Example
- "jsonName" => PropertyName : string
```

Use `"_links" => Links : Pingmint.AzureDevOps.ReferenceLinks` for Azure DevOps reference links. Unknown response properties are skipped by the generated reader, but the endpoint's documented response type itself must include all documented fields. Referenced models may be limited to the fields returned by this operation when fully expanding them would pull in unrelated graphs.

Organize definitions with `//` comments:

- service-wide Git models directly under `// Git`
- operation-family models under a subsection such as `// Git Pull Requests`
- service-agnostic Azure DevOps models under `// Meta: Common`

Sort type definitions alphabetically by fully qualified name inside each section. Keep each type's properties in the documentation's order unless the surrounding definition has an established order.

Do not use `#` headings; the generator uses `//` comments. Do not use unsupported aliases such as `short` with the pinned generator version.

### 3. Regenerate the Serializer

From `src/`, run the VS Code tasks:
1. dotnet: restore tools
2. dotnet: generate Azure DevOps API serializer

Generation is the first check after changing `APISerializer.txt`. If it fails, fix the schema rather than editing generated C#.

Inspect the generated response model names and property types before writing wrappers or tests.

### 4. Add the Request Factory Method

Add a public static method to `src/nuget/HttpRequestFactory.cs` that:

- uses the documented HTTP method
- accepts every required route parameter
- follows existing `organization` and `project` conventions
- uses the exact documented route
- includes the exact required `api-version`
- returns an `HttpRequestMessage` without adding authorization

Add XML documentation comments to every request factory method created or updated by this workflow. Derive their factual content from the selected Microsoft Learn operation page:

- `<summary>`: concisely paraphrase the official operation description
- `<param>`: document every method parameter using its official parameter description, including whether it is optional and what identifiers or names are accepted
- `<returns>`: state that the method returns an `HttpRequestMessage` for the documented operation
- `<remarks>`: include a `<see href="...">` link to the selected Microsoft Learn endpoint page and identify the API version

Escape XML-sensitive characters in documentation URLs, including writing query-string `&` characters as `&amp;`. Do not invent guarantees, validation behavior, defaults, or exceptions that are not present in the documentation or implementation.

Use this shape:

```csharp
/// <summary>
/// Retrieves a pull request.
/// </summary>
/// <param name="organization">The name of the Azure DevOps organization.</param>
/// <param name="pullRequestId">The ID of the pull request to retrieve.</param>
/// <returns>An HTTP request message for the Get Pull Request By Id operation.</returns>
/// <remarks>
/// Uses Azure DevOps REST API version 7.2-preview.2.
/// See <see href="https://learn.microsoft.com/...">the official Azure DevOps REST API documentation</see>.
/// </remarks>
```

Expose all optional query parameters as nullable method parameters. 
Only include optional query parameters in the URL when they are not null. 
Do not invent a broad options abstraction for one endpoint. 
Ensure dynamic query values are escaped when adding optional values.

### 5. Add Convenience Deserializers

In `src/nuget/APISerializer.partial.cs`, add overloads matching the current pattern:

```csharp
public static DeserializationResult<ResponseType> DeserializeResponseType(String json)
public static DeserializationResult<ResponseType> DeserializeResponseType(ReadOnlySpan<Byte> json)
```

The string overload must use `TryGetUtf8ByteArrayFromString` and delegate to the UTF-8 byte overload using only the written slice. The byte overload owns JSON reader creation and generated `Deserialize` invocation.

Return `DeserializationStatus.Failure` when UTF-8 conversion fails, the payload is empty, or the root token is not an object. Return `DeserializationStatus.ModelValidationFailure` when JSON deserialization completes but the model fails API-specific assertions, such as a missing required response envelope or required identity field. Return `Success` only after the generated deserializer completes and all API-specific model assertions pass.

Keep shared result/status types and UTF-8 conversion helpers single-instance; do not duplicate them per endpoint.

### 6. Update the API Catalog

Add the operation to `doc/azure-devops-rest-api.md` under the correct service/resource headings. Record:

- documentation URL
- endpoint route
- API version
- request method
- response model

Use the selected operation URL, not a nearby Microsoft Learn page. In catalog refresh mode, update every catalog entry's documentation URL and `Version` to the values verified from its latest-release page, even when no code changes are required.

### 7. Add Focused Coverage

Add or extend an integration test under `src/test/` that:

- derives from `AzureDevOpsIntegrationTestBase`
- has `[TestCategory("Integration")]`
- creates the request through `HttpRequestFactory`
- applies authorization through `AddAuthorizationForAzureDevOps`
- sends with `TestContext.CancellationToken`
- reports the response body when HTTP status is unsuccessful
- calls the public byte-oriented convenience deserializer
- asserts `DeserializationStatus.Success`
- compares deserialized values with the raw JSON response for scalar, nested object, and collection fields

Add focused non-integration coverage for each API-specific model assertion. Verify that violating the assertion returns `DeserializationStatus.ModelValidationFailure`, while malformed or structurally invalid payloads continue to return `DeserializationStatus.Failure`.

Reuse existing recursive JSON assertion helpers when practical instead of duplicating them. If the endpoint requires route inputs beyond organization/project, use clearly named environment variables and make missing configuration inconclusive rather than failed.

### 8. Validate

Run validation in this order:

1. regenerate `APISerializer.g.cs`
2. check diagnostics for edited files
3. build `src/Pingmint.AzureDevOps.slnx` in Release
4. run the focused test for every added or refreshed operation
5. run `git diff --check`

The integration test requires `AZURE_DEVOPS_ORGANIZATION` and `AZURE_DEVOPS_PROJECT` and may require endpoint-specific configuration. If credentials or configuration are unavailable, report the test as skipped/inconclusive; do not claim it passed.

Do not fix unrelated failures or revert user changes.

## Completion Report

Summarize:

- endpoint or endpoints and exact API versions implemented or refreshed
- latest REST documentation release selected and how it was verified in catalog refresh mode
- request factory methods added, updated, or confirmed current
- response/deserializer types added, updated, reused, or confirmed current
- catalog documentation and tests updated
- generator/build/test results for every processed operation, including skipped integration tests
