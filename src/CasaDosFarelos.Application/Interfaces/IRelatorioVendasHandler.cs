using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces
{
    public interface IRelatorioVendasHandler
    {
        Task<RelatorioVendasDto> HandleAsync();
    }
}
