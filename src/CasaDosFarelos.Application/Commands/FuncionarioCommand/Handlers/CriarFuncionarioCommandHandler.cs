using CasaDosFarelos.Application.Commands.FuncionarioCommand.Handlers;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Domain.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Commands.FuncionarioCommand;

public class CriarFuncionarioCommandHandler
    : IRequestHandler<CriarFuncionarioCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarFuncionarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CriarFuncionarioCommand request,
        CancellationToken cancellationToken)
    {
        var funcionario = new Funcionario(
            request.Nome,
            request.Email,
            request.Documento,
            request.Cargo
        );

        await _unitOfWork.Funcionarios.AddAsync(funcionario);
        await _unitOfWork.CommitAsync();

        return funcionario.Id;
    }
}