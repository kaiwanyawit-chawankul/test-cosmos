namespace DemoCosmos.Test;

using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Azure.Cosmos;

public class UnitTest1
{
    [Fact]
    public async Task Test1Async()
    {
        string endpoint = Environment.GetEnvironmentVariable("MY_SERVICE_URL") ??"https://localhost:8081";
        string key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        var clientOptions = new CosmosClientOptions
        {
            AllowBulkExecution = true,
            ConnectionMode = ConnectionMode.Direct,
            //ConnectionProtocol = Protocol.Tcp,
            MaxRetryAttemptsOnRateLimitedRequests = 9,
            MaxRetryWaitTimeOnRateLimitedRequests = TimeSpan.FromSeconds(30),
            ServerCertificateCustomValidationCallback = (cert, chain, errors) => true
        };

        var client = new CosmosClient(endpoint, key, clientOptions);

        var databaseResponse = await client.CreateDatabaseIfNotExistsAsync("TestDatabase");
        var containerResponse = await databaseResponse.Database.CreateContainerIfNotExistsAsync("TestContainer", "/id");

        //Console.WriteLine($"Container Id: {containerResponse.Container.Id}");
        containerResponse.Container.Id.Should().NotBeNull();
    }
}