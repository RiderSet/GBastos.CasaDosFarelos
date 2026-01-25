using MediatR;

namespace CasaDosFarelos.Application.Commands.Vendas;

public record CriarVendaCommand(
    Guid ClienteId,
    List<VendaItemDto> Itens
) : IRequest<Guid>;