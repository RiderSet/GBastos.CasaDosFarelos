using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Queries.ClientesQueries.ObterClientePorId.Handlers
{
    public class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, ClienteResponseDto?>
    {
        private readonly IClienteReadRepository _repository;

        public ObterClientePorIdHandler(IClienteReadRepository repository)
        {
            _repository = repository;
        }

        public Task<ClienteResponseDto?> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.ObterClientePorIdAsync(request.Id, cancellationToken);
        }
    }
}
