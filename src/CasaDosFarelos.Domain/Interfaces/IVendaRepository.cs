using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Domain.Interfaces
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<IEnumerable<Venda>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim);
    }
}	
