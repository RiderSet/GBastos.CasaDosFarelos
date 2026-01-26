using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces
{
    public interface IClienteReadRepository
    {
        Task<List<ClienteResponseDto>> ListarClientesAsync(CancellationToken cancellationToken);
        Task<ClienteResponseDto?> ObterClientePorIdAsync(Guid id, CancellationToken cancellationToken);
    }
}