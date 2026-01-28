using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Venda;

namespace CasaDosFarelos.Application.Commands.RelatoriosCommand;

public sealed class RelatorioVendasHandler : IRelatorioVendasHandler
{
    public async Task<RelatorioVendasDto> HandleAsync()
    {
        await Task.Delay(10);

        return new RelatorioVendasDto
        {
            DataVenda = Convert.ToDateTime("01/01/2026"),
            ValorTotal = 12500.50m
        };
    }
}