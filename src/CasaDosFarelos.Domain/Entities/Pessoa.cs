namespace CasaDosFarelos.Domain.Entities;

public abstract class Pessoa : Entity
{
    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public string Documento { get; protected set; }

    protected Pessoa() { } // EF

    protected Pessoa(string nome, string email, string documento)
    {
        Nome = nome;
        Email = email;
        Documento = documento;
    }

    protected void AtualizarPessoa(
        string nome,
        string email,
        string documento)
    {
        Nome = nome;
        Email = email;
        Documento = documento;
    }
}

public class ClientePF : Pessoa
{
    public string CPF { get; private set; }

    protected ClientePF() { } // EF

    public ClientePF(
        string nome,
        string email,
        string documento,
        string cpf)
        : base(nome, email, documento)
    {
        CPF = cpf;
    }

    public void AtualizarDados(
        string nome,
        string email,
        string documento,
        string cpf)
    {
        AtualizarPessoa(nome, email, documento);
        CPF = cpf;
    }
}

public class ClientePJ : Pessoa
{
    public string CNPJ { get; private set; }

    protected ClientePJ() { } // EF

    public ClientePJ(
        string nome,
        string email,
        string documento,
        string cnpj)
        : base(nome, email, documento)
    {
        CNPJ = cnpj;
    }

    public void AtualizarDados(
        string nome,
        string email,
        string documento,
        string cnpj)
    {
        AtualizarPessoa(nome, email, documento);
        CNPJ = cnpj;
    }
}