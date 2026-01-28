using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Mappers;

public static class ClienteResponseDto_To_ClientePJ
{
    public static ClientePF ToClientePJ(this ClienteResponseDto dto)
    {
        if (dto.Tipo != "PJ")
            throw new InvalidOperationException("ClienteResponseDto não é do tipo PJ");

        return new ClientePF(
            dto.Nome,
            dto.Email,
            dto.Documento,
            dto.CNPJ
                ?? throw new InvalidOperationException("CNPJ não informado")
        );
    }
}