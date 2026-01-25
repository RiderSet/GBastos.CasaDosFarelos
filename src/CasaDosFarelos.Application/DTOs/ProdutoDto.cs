namespace CasaDosFarelos.Application.DTOs;

public sealed class ProdutoDto
{
    public Guid Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public decimal Preco { get; init; }
}