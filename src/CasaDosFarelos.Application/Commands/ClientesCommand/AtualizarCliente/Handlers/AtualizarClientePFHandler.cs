using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using CasaDosFarelos.Application.Mappers;
using MediatR;

namespace CasaDosFarelos.Application.Commands.ClientesCommand.AtualizarCliente.Handlers;

public sealed class AtualizarClientePFHandler
    : IRequestHandler<AtualizarClientePFCommand, Unit>
{
    private readonly IClienteWritePFRepository _repoW;
    private readonly IClienteReadPFRepository _repoR;

    public AtualizarClientePFHandler(
        IClienteWritePFRepository repoW,
        IClienteReadPFRepository repoR)
    {
        _repoW = repoW;
        _repoR = repoR;
    }

    public async Task<Unit> Handle(
        AtualizarClientePFCommand command,
        CancellationToken ct)
    {
        var clienteDto = await _repoR.GetByIdAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Cliente PF não encontrado");
        var clientePF = ClienteResponseDto_To_ClientePF.ToClientePF(clienteDto);

        await _repoW.UpdateAsync(clientePF, ct);

        return Unit.Value;
    }
}