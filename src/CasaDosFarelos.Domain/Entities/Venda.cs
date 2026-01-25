using CasaDosFarelos.Domain.Exceptions;

namespace CasaDosFarelos.Domain.Entities;

public class Venda : Entity
{
    public DateTime DataVenda { get; private set; }
    public Guid ClienteId { get; private set; }

    public IReadOnlyCollection<VendaItem> Itens => _itens;
    private readonly List<VendaItem> _itens = new();

    // ✅ ValorTotal Total calculado
    public decimal ValorTotal => _itens.Sum(i => i.ValorTotal);

    private Venda() { }

    private Venda(Guid clienteId, List<VendaItem> itens)
    {
        ClienteId = clienteId;
        DataVenda = DateTime.UtcNow;
        _itens = itens ?? throw new ArgumentNullException(nameof(itens));
    }

    public static Venda Criar(Guid clienteId, List<VendaItem> itens)
    {
        if (itens == null || !itens.Any())
            throw new DomainException("A venda deve possuir ao menos um item.");

        return new Venda(clienteId, itens);
    }
}