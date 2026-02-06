
using System.Net;

namespace ServiceLigueHockeyTest;

public class EquipeTest
{
    private HttpClient _httpClient;
    
    [SetUp]
    public void Setup()
    {
        // Initialize HttpClient for the API base address
        // Use WebApplicationFactory for in-memory hosting for integration tests
        // or point to a running API URL
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5245/") };
    }

    [Test]
    public async Task TestListerEquipes()
    {
        // Act
        HttpResponseMessage response = await _httpClient.GetAsync("api/equipe");

        // Assert
        Assert.That(response.StatusCode == HttpStatusCode.OK, "Le status n'est pas ok.");

        string content = await response.Content.ReadAsStringAsync();
        Assert.That(content != null, "La réponse ne devrait pas être nulle.");
        
        // Further assertions can be made on the JSON content
        //Console.Write(content);
        Assert.Pass();
    }

    [TearDown]
    public void JetteMoiAuxPoubelles()
    {
        _httpClient.Dispose();
    }
}