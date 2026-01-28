using CasaDosFarelos.Domain.Entities;

public class FornecedorResponseDto
{
    public Guid Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Documento { get; init; } = default!;
    public List<Produto> Produtos { get; init; } = new();

    public FornecedorResponseDto(
        Guid id,
        string nome,
        string email,
        string documento,
        List<Produto>? produtos)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Documento = documento;
        Produtos = produtos;
    }
}