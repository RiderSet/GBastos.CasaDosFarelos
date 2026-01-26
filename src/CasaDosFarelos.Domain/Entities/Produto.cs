namespace CasaDosFarelos.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }  

    public string Nome { get; set; } = null!;
    public decimal Preco { get; set; }
}