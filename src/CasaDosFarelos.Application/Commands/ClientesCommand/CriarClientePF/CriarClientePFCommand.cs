using MediatR;

public record CriarClientePFCommand(string Nome, string Email, string Documento, string CPF)
    : IRequest<Guid>;