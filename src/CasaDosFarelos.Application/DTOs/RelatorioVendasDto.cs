namespace CasaDosFarelos.Application.DTOs;

public class RelatorioVendasDto
{
    public Guid VendaId { get; set; }
    public DateTime DataVenda { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }
}
