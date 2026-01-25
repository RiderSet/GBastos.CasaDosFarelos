using CasaDosFarelos.Domain.Entities.Enums;

namespace CasaDosFarelos.Domain.Entities;

public class Funcionario : Pessoa
{
    public string Email { get; private set; }
    public string Documento { get; private set; }
    public Cargo Cargo { get; private set; }

    private Funcionario() { }

    public Funcionario(
        string nome,
        string email,
        string documento,
        Cargo cargo)
    {
        Nome = nome;
        Email = email;
        Documento = documento;
        Cargo = cargo;
    }
}