using CasaDosFarelos.Application.Commands.FornecedorCommand.AtualizarFornecedor;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Application.Mappers;
using MediatR;

public sealed class AtualizarFornecedorHandler
    : IRequestHandler<AtualizarFornecedorCommand, Unit>
{
    private readonly IFornecedorReadRepository _readRepo;
    private readonly IFornecedorWriteRepository _writeRepo;

    public AtualizarFornecedorHandler(
        IFornecedorReadRepository readRepo,
        IFornecedorWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<Unit> Handle(
        AtualizarFornecedorCommand command,
        CancellationToken ct)
    {
        var fornecedorDto = await _readRepo.GetByIdAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Fornecedor PF não encontrado");

        fornecedorDto.UpdateName(command.Nome);
        var produtos = fornecedorDto.Produtos;

        var fornecedor = Fornecedor_To_FornecedorResponseDto.ToEntity(fornecedorDto, produtos);

        await _writeRepo.UpdateAsync(fornecedor, ct);

        return Unit.Value;
    }
}