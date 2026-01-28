using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Mappers;

public static class ClientePF_To_ClienteResponseDto
{
    public static ClientePF ToClientePJ(this ClienteResponseDto dto)
    {
        if (dto.Tipo != "PF")
            throw new InvalidOperationException("ClienteResponseDto não é do tipo PF");

        return new ClientePF(
            dto.Nome,
            dto.Email,
            dto.Documento,
            dto.CPF
                ?? throw new InvalidOperationException("CPF não informado")
        );
    }
}