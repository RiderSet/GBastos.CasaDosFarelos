using CasaDosFarelos.Application.Commands.FornecedorCommand.CriarFornecedor;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using MediatR;

public sealed class CriarFornecedorHandler
    : IRequestHandler<CriarFornecedorCommand, Guid>
{
    private readonly IFornecedorWriteRepository _fornecedorRepo;
    private readonly IProdutoRepository _produtoRepo;

    public CriarFornecedorHandler(
        IFornecedorWriteRepository fornecedorRepo,
        IProdutoRepository produtoRepo)
    {
        _fornecedorRepo = fornecedorRepo;
        _produtoRepo = produtoRepo;
    }

    public async Task<Guid> Handle(
        CriarFornecedorCommand command,
        CancellationToken ct)
    {
        var produtos = await _produtoRepo
            .ObterPorIdsAsync(command.ProdutosIds, ct);

        if (produtos.Count != command.ProdutosIds.Count)
            throw new InvalidOperationException("Um ou mais produtos não encontrados");

        var fornecedor = new Fornecedor(
            command.Nome,
            command.Email,
            command.Documento,
            produtos
        );

        await _fornecedorRepo.AddAsync(fornecedor, ct);

        return fornecedor.Id;
    }
}