namespace CasaDosFarelos.Application.DTOs;

public class FornecedorRequestDto
{
    public string Nome { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Documento { get; init; } = default!;

    /// <summary>
    /// IDs dos produtos fornecidos
    /// </summary>
    public List<Guid> ProdutosIds { get; init; } = new();
}