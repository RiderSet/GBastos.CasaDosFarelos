using CasaDosFarelos.Domain.Entities.Enums;
using MediatR;

namespace CasaDosFarelos.Application.Commands.FuncionarioCommand.Handlers;

public record CriarFuncionarioCommand(
    string Nome,
    string Email,
    string Documento,
    Cargo Cargo
) : IRequest<Guid>;