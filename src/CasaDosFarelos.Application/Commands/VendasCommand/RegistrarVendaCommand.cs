using MediatR;

namespace CasaDosFarelos.Application.Commands.Vendas;

public class RegistrarVendaCommand : IRequest<Guid>
{
    public Guid ClienteId { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataVenda { get; set; }
}