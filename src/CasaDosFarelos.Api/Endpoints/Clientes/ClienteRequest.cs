namespace CasaDosFarelos.Api.Endpoints.Clientes;

public record CriarClientePFRequest(
    string Nome,
    string Email,
    string Documento,
    string CPF
);

public record CriarClientePJRequest(
    string Nome,
    string Email,
    string Documento,
    string CNPJ
);