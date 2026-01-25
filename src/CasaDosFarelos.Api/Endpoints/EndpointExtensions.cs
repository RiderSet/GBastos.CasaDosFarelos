using CasaDosFarelos.Api.Endpoints.Produtos;
using CasaDosFarelos.Api.Endpoints.Relatorios;
using CasaDosFarelos.Api.Endpoints.Vendas;
using src.CasaDosFarelos.Api.Endpoints.Fornecedores;
using src.CasaDosFarelos.Api.Endpoints.Funcionarios;

namespace CasaDosFarelos.Api.Endpoints;

public static class EndpointExtensions
{
    public static WebApplication MapApplicationEndpoints(
        this WebApplication app)
    {
        app.MapRelatoriosEndpoints();
        app.MapVendasEndpoints();
        app.MapProdutosEndpoints();
        app.MapFuncionariosEndpoints();
        app.MapFornecedoresEndpoints();

        return app;
    }
}