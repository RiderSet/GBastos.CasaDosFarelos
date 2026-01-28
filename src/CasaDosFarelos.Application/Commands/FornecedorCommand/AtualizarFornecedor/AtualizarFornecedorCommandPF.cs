using MediatR;

public sealed record AtualizarFornecedorCommandPF(
    Guid Id,
    string Nome,
    string CPF
) : IRequest<Unit>;