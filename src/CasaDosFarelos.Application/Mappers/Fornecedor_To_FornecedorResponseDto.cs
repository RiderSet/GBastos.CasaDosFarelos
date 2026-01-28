using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Mappers;

public static class Fornecedor_To_FornecedorResponseDto
{
    public static Fornecedor ToEntity(
        this FornecedorResponseDto dto,
        List<Produto> produtos)
    {
        return new Fornecedor(
            dto.Nome,
            dto.Email,
            dto.Documento,
            produtos
        );
    }
}