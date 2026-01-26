namespace CasaDosFarelos.Domain.Entities;

public abstract class Pessoa: Entity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Documento { get; set; }
}

public class ClientePF : Pessoa
{
    public string CPF { get; set; } = string.Empty;
}

public class ClientePJ : Pessoa
{
    public string CNPJ { get; set; } = string.Empty;
}