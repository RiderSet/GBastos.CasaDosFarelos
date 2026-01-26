namespace CasaDosFarelos.Api.Contracts.Clientes;

public sealed class AtualizarClienteRequest
{
    public string Nome { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Documento { get; init; } = string.Empty;

    // Apenas um deles será usado, dependendo do tipo
    public string? CPF { get; init; }
    public string? CNPJ { get; init; }
}