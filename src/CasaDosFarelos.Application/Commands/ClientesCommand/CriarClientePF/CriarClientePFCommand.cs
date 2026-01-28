using MediatR;

namespace CasaDosFarelos.Application.Commands.ClientesCommand.CriarClientePF;

public sealed class CriarClientePFCommand : IRequest<Guid>
{
    public string Nome { get; }
    public string Email { get; }
    public string Documento { get; }
    public string CPF { get; }

    public CriarClientePFCommand(
        string nome,
        string email,
        string documento,
        string cpf)
    {
        Nome = nome;
        Email = email;
        Documento = documento;
        CPF = cpf;
    }
}