namespace CasaDosFarelos.Domain.Entities
{

    public class Veiculo : Entity
    {
        public string Placa { get; private set; } = string.Empty;
        public string Modelo { get; private set; } = string.Empty;
    }
}