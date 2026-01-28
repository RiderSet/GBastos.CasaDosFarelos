using MediatR;

namespace CasaDosFarelos.Application.Commands.FornecedorCommand.AtualizarFornecedor;

public class AtualizarFornecedorCommand : IRequest<Unit>
{
    public Guid Id { get; init; }

    public string Nome { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Documento { get; init; } = default!;

    public List<Guid> ProdutosIds { get; init; } = new();
}