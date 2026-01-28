using MediatR;

public sealed record AtualizarFornecedorCommandPJ(
    Guid Id,
    string RazaoSocial,
    string CNPJ
) : IRequest<Unit>;