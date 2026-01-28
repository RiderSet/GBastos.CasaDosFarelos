using MediatR;

namespace CasaDosFarelos.Application.Commands.FornecedorCommand.CriarFornecedor
{
    public class CriarFornecedorCommand : IRequest<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public List<Guid> ProdutosIds { get; set; } = new(); // referenciando produtos existentes
    }
}