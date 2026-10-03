using System.Net.Http.Headers;
using Azure.Core;
using Azure.Identity;

namespace Pingmint.AzureDevOps.Tests;

public abstract class AzureDevOpsIntegrationTestBase
{
    private const string AzureDevOpsScope = "499b84ac-1321-427f-aa17-267ca6975798/.default";
    private static readonly InteractiveBrowserCredential Credential = new();

    protected string Organization { get; private set; } = null!;

    protected string Project { get; private set; } = null!;

    protected AccessToken AccessToken { get; private set; }

    public TestContext TestContext { get; set; } = null!;

    [TestInitialize]
    public async Task AuthenticateAsync()
    {
        var organization = Environment.GetEnvironmentVariable("AZURE_DEVOPS_ORGANIZATION");
        var project = Environment.GetEnvironmentVariable("AZURE_DEVOPS_PROJECT");

        if (string.IsNullOrWhiteSpace(organization) || string.IsNullOrWhiteSpace(project))
        {
            Assert.Inconclusive(
                "Set AZURE_DEVOPS_ORGANIZATION and AZURE_DEVOPS_PROJECT to run Azure DevOps integration tests.");
            return;
        }

        Organization = organization;
        Project = project;

        AccessToken = await Credential.GetTokenAsync(
            new TokenRequestContext([AzureDevOpsScope]),
            TestContext.CancellationToken);
    }

    protected void AddAuthorizationForAzureDevOps(HttpRequestMessage request)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken.Token);
    }
}