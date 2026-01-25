namespace CasaDosFarelos.Domain.Entities
{
    public class VendaItem : Entity
    {
        public Guid VendaId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public string DescricaoProduto { get; private set; } = string.Empty;

        public int Quantidade { get; private set; }

        public decimal PrecoUnitario { get; private set; }

        public decimal ValorTotal => Quantidade * PrecoUnitario;

        private VendaItem() { }

        public VendaItem(
            Guid produtoId,
            string descricaoProduto,
            int quantidade,
            decimal precoUnitario)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero");

            if (precoUnitario <= 0)
                throw new ArgumentException("Preço unitário deve ser maior que zero");

            ProdutoId = produtoId;
            DescricaoProduto = descricaoProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void VincularVenda(Guid vendaId)
        {
            VendaId = vendaId;
        }
    }
}
