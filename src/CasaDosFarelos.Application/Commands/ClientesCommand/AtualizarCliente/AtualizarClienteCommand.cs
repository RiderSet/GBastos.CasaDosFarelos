using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes
{
    public class AtualizarClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
    }
}