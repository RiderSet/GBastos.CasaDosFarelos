using CasaDosFarelos.Domain.Entities;

namespace src.CasaDosFarelos.Domain.Entities;

public class Veiculo : Entity
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
}