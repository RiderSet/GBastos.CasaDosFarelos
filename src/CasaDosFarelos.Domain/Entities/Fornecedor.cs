namespace CasaDosFarelos.Domain.Entities
{
    public class Fornecedor : Pessoa
    {
        public List<Produto> Produtos { get; private set; } = new();

        private Fornecedor() { }

        public Fornecedor(
            string nome,
            string email,
            string documento,
            List<Produto> produtos)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
            Produtos = produtos;
        }
    }
}