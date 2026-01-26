namespace CasaDosFarelos.Api.Endpoints.Fornecedores;

public record FornecedorRequest(
    string Nome,
    string Email,
    string Documento,
    List<Guid> ProdutosIds
);

public record AtualizarFornecedorRequest(
    Guid Id,
    string Nome,
    string Email,
    string Documento,
    List<Guid> ProdutosIds
);