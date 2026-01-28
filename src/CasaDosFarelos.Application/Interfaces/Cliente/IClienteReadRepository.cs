using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces.Cliente
{
    public interface IClienteReadRepository
    {
        Task<List<ClienteResponseDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}
