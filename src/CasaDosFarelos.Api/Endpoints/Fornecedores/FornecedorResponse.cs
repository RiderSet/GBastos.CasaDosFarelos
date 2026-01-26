namespace CasaDosFarelos.Api.Endpoints.Fornecedores;

public record FornecedorResponse(
    Guid Id,
    string Nome,
    string Email,
    string Documento,
    List<FornecedorProdutoResponse> Produtos
);

public record FornecedorProdutoResponse(
    Guid Id,
    string Nome
);