using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using Dapper;
using System.Data;

namespace CasaDosFarelos.Infrastructure.Repositories;

public class FornecedorReadRepository : IFornecedorReadRepository
{
    private readonly IDbConnection _connection;

    public FornecedorReadRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Fornecedor>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        const string sql = """
        SELECT 
            f.Id, f.Nome, f.Email, f.Documento,
            p.Id AS ProdutoId, p.Nome AS ProdutoNome
        FROM Fornecedores f
        LEFT JOIN FornecedorProdutos fp ON fp.FornecedorId = f.Id
        LEFT JOIN Produtos p ON p.Id = fp.ProdutoId
        """;

        var lookup = new Dictionary<Guid, Fornecedor>();

        await _connection.QueryAsync<FornecedorFlat, Produto, Fornecedor>(
            sql,
            (f, produto) =>
            {
                if (!lookup.TryGetValue(f.Id, out var fornecedor))
                {
                    fornecedor = new Fornecedor(
                        f.Nome,
                        f.Email,
                        f.Documento,
                        new List<Produto>()
                    );
                    lookup.Add(f.Id, fornecedor);
                }

                if (produto is not null)
                    fornecedor.Produtos.Add(produto);

                return fornecedor;
            },
            splitOn: "ProdutoId"
        );

        return lookup.Values.ToList();
    }

    public async Task<Fornecedor?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var fornecedores = await GetAllAsync(cancellationToken);
        return fornecedores.FirstOrDefault(f => f.Id == id);
    }

    private sealed record FornecedorFlat(
        Guid Id,
        string Nome,
        string Email,
        string Documento
    );
}