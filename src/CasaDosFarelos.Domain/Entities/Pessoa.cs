namespace CasaDosFarelos.Domain.Entities;

public abstract class Pessoa: Entity
{
    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public string Documento { get; protected set; }
}

public class ClientePF : Pessoa
{
    public string CPF { get; set; } = string.Empty;
}

public class ClientePJ : Pessoa
{
    public string CNPJ { get; set; } = string.Empty;
}