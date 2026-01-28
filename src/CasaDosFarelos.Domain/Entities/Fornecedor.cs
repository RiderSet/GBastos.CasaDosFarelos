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
            IEnumerable<Produto> produtos)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Documento = documento;
            Produtos.AddRange(produtos);
        }

        public Fornecedor UpdateName(string nome)
        {
            return new Fornecedor(
                nome: Nome,
                email: Email,
                documento: Documento,
                produtos: Produtos
            );
        }
    }
}