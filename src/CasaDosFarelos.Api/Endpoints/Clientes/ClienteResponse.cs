namespace CasaDosFarelos.Api.Endpoints.Clientes;

public class ClienteResponse
{
    public Guid Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Documento { get; init; } = string.Empty;

    /// <summary>
    /// PF ou PJ
    /// </summary>
    public string Tipo { get; init; } = string.Empty;

    /// <summary>
    /// Preenchido somente se Tipo == PF
    /// </summary>
    public string? CPF { get; init; }

    /// <summary>
    /// Preenchido somente se Tipo == PJ
    /// </summary>
    public string? CNPJ { get; init; }
}