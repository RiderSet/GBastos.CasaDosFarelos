using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories
{
    public class ClienteReadRepository : IClienteReadRepository
    {
        private readonly AppDbContext _context;

        public ClienteReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteResponseDto>> ListarClientesAsync(CancellationToken cancellationToken)
        {
            var clientesPF = _context.Set<ClientePF>()
                .AsNoTracking()
                .Select(c => new ClienteResponseDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Documento = c.Documento,
                    Tipo = "PF",
                    CPF = c.CPF,
                    CNPJ = null
                });

            var clientesPJ = _context.Set<ClientePJ>()
                .AsNoTracking()
                .Select(c => new ClienteResponseDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Documento = c.Documento,
                    Tipo = "PJ",
                    CPF = null,
                    CNPJ = c.CNPJ
                });

            return await clientesPF
                .Union(clientesPJ)
                .ToListAsync(cancellationToken);
        }

        public async Task<ClienteResponseDto?> ObterClientePorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var cliente = await _context.Set<Pessoa>()
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (cliente is ClientePF pf)
                return new ClienteResponseDto
                {
                    Id = pf.Id,
                    Nome = pf.Nome,
                    Email = pf.Email,
                    Documento = pf.Documento,
                    Tipo = "PF",
                    CPF = pf.CPF,
                    CNPJ = null
                };

            if (cliente is ClientePJ pj)
                return new ClienteResponseDto
                {
                    Id = pj.Id,
                    Nome = pj.Nome,
                    Email = pj.Email,
                    Documento = pj.Documento,
                    Tipo = "PJ",
                    CPF = null,
                    CNPJ = pj.CNPJ
                };

            return null;
        }
    }
}