using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces.Cliente.PF
{
    public interface IClienteReadPFRepository : IClienteReadRepository
    {
        Task<ClienteResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}