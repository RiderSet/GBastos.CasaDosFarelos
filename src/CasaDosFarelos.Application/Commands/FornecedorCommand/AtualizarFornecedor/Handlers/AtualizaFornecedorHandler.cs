using CasaDosFarelos.Application.Interfaces.Fornecedores;
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
        var fornecedor = await _readRepo.GetByIdAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Fornecedor não encontrado");

        fornecedor.UpdateName(command.Nome);

        await _writeRepo.UpdateAsync(fornecedor, ct);

        return Unit.Value;
    }
}