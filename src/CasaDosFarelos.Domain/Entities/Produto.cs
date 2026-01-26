namespace CasaDosFarelos.Domain.Entities;

public class Produto : Entity
{
    public string Nome { get; set; } = null!;
    public decimal Preco { get; set; }
}