namespace CasaDosFarelos.Application.Commands.ClientesCommand.AtualizarCliente;

public sealed class AtualizarClientePFCommand : AtualizarClienteCommand
{
    public string Nome { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Documento { get; init; } = null!;
    public string CPF { get; init; } = null!;
}