using MediatR;

namespace CasaDosFarelos.Application.Commands.FornecedorCommand.ExcluirFornecedor
{
    public class ExcluirFornecedorCommand : IRequest<Unit>
    {
        public ExcluirFornecedorCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}