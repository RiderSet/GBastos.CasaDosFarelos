using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes;

public class AtualizarClienteHandler
    : IRequestHandler<AtualizarClienteCommand, Unit>
{
    private readonly IClienteWriteRepository _repository;

    public AtualizarClienteHandler(IClienteWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(
        AtualizarClienteCommand request,
        CancellationToken cancellationToken)
    {
        var cliente = await _repository
            .ObterPorIdAsync(request.Id, cancellationToken);

        if (cliente is null)
            throw new InvalidOperationException("Cliente não encontrado.");

        switch (cliente)
        {
            case ClientePF pf:
                pf.AtualizarDados(
                    request.Nome,
                    request.Email,
                    request.Documento,
                    request.CPF ?? throw new InvalidOperationException("CPF é obrigatório")
                );
                break;

            case ClientePJ pj:
                pj.AtualizarDados(
                    request.Nome,
                    request.Email,
                    request.Documento,
                    request.CNPJ ?? throw new InvalidOperationException("CNPJ é obrigatório")
                );
                break;

            default:
                throw new InvalidOperationException("Tipo de cliente inválido.");
        }

        await _repository.AtualizarAsync(cliente, cancellationToken);

        return Unit.Value;
    }
}