namespace CasaDosFarelos.Application.Commands.ClientesCommand.AtualizarCliente
{
    public sealed class AtualizarClientePJCommand : AtualizarClienteCommand
    {
        public string RazaoSocial { get; init; } = null!;
        public string CNPJ { get; init; } = null!;
    }
}
