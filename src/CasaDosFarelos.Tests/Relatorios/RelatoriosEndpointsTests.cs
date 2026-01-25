using CasaDosFarelos.IntegrationTests.Infrastructure;

namespace CasaDosFarelos.Api.IntegrationTests.Relatorios;

public class RelatoriosEndpointsTests
    : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public RelatoriosEndpointsTests(ApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GET_relatorios_vendas_deve_retornar_200()
    {
        // Arrange
        var inicio = DateTime.Today.AddDays(-7);
        var fim = DateTime.Today;

        var url = $"/api/relatorios/vendas" +
                  $"?dataInicio={inicio:yyyy-MM-dd}" +
                  $"&dataFim={fim:yyyy-MM-dd}";

        // Act
        var response = await _client.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadAsStringAsync();
        body.Should().NotBeNullOrEmpty();
    }
}