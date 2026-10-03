namespace Pingmint.AzureDevOps.Tests;

[TestClass]
public sealed class APISerializerTests
{
    [TestMethod]
    public void DeserializeGitRepositoriesResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRepositoriesResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoriesResponseWithInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepositoriesResponse("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoryWithoutIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitRepository("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitRepositoryWithInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitRepository("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestWithoutIdReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitPullRequest("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeGitPullRequestsResponseWithoutValueReturnsModelValidationFailure()
    {
        var result = APISerializer.DeserializeGitPullRequestsResponse("{}"u8);

        Assert.AreEqual(DeserializationStatus.ModelValidationFailure, result.Status);
    }

    [TestMethod]
    public void DeserializeInvalidRootReturnsFailure()
    {
        var result = APISerializer.DeserializeGitPullRequest("[]"u8);

        Assert.AreEqual(DeserializationStatus.Failure, result.Status);
    }
}