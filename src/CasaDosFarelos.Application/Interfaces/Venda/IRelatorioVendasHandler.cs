using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces.Venda
{
    public interface IRelatorioVendasHandler
    {
        Task<RelatorioVendasDto> HandleAsync();
    }
}
