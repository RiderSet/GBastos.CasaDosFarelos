using MediatR;

namespace CasaDosFarelos.Application.Commands.ClientesCommand.CriarClientePJ;

public sealed class CriarClientePJCommand : IRequest<Guid>
{
    public string Nome { get; }
    public string Email { get; }
    public string Documento { get; }
    public string CNPJ { get; }

    public CriarClientePJCommand(
        string nome,
        string email,
        string documento,
        string cnpj)
    {
        Nome = nome;
        Email = email;
        Documento = documento;
        CNPJ = cnpj;
    }
}