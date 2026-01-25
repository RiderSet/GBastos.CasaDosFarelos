public record VendaItemDto(
    Guid ProdutoId,
    string DescricaoProduto,
    int Quantidade,
    decimal PrecoUnitario
);