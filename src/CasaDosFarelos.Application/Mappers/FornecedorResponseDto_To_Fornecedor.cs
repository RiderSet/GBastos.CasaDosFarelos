using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Mappers;

public static class FornecedorResponseDto_To_Fornecedor
{
    public static FornecedorResponseDto ToResponseDto(this Fornecedor fornecedor)
    {
        return new FornecedorResponseDto(
            fornecedor.Id,
            fornecedor.Nome,
            fornecedor.Email,
            fornecedor.Documento,
            fornecedor.Produtos
                .Select(p => new Produto(
                    p.Nome,
                    p.Preco
                ))
                .ToList()
        );
    }
}