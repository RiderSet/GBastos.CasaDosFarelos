namespace CasaDosFarelos.Application.Interfaces.Fornecedores;

public interface IFornecedorReadRepository
{
    Task<List<FornecedorResponseDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<FornecedorResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}