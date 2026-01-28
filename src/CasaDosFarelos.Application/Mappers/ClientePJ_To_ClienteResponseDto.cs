using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Mappers;

public static class ClientePJ_To_ClienteResponseDto
{
    public static ClientePJ ToClientePJ(this ClienteResponseDto dto)
    {
        if (dto.Tipo != "PJ")
            throw new InvalidOperationException("ClienteResponseDto não é do tipo PJ");

        return new ClientePJ(
            dto.Nome,
            dto.Email,
            dto.Documento,
            dto.CNPJ
                ?? throw new InvalidOperationException("CNPJ não informado")
        );
    }
}