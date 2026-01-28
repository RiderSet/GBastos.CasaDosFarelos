using MediatR;

public class AtualizarFornecedorCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public List<Guid> ProdutosIds { get; set; } = new();

    public AtualizarFornecedorCommand() { } // construtor vazio
}