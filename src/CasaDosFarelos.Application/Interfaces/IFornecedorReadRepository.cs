using CasaDosFarelos.Application.DTOs;

namespace CasaDosFarelos.Application.Interfaces;

public interface IFornecedorReadRepository
{
    Task<List<FornecedorResponseDto>> ListarAsync(CancellationToken cancellationToken);
    Task<FornecedorResponseDto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
}