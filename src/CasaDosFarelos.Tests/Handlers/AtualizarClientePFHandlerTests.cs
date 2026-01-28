using CasaDosFarelos.Application.Commands.FornecedorCommand.AtualizarFornecedor;
using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using Moq;

public class AtualizarFornecedorPFHandlerTests
{
    private readonly Mock<IFornecedorReadRepository> _repoReadMock;
    private readonly Mock<IFornecedorWriteRepository> _repoWriteMock;
    private readonly Mock<IProdutoRepository> _produtoRepoMock;
    private readonly AtualizarFornecedorHandler _handler;

    public AtualizarFornecedorPFHandlerTests()
    {
        _repoReadMock = new Mock<IFornecedorReadRepository>();
        _repoWriteMock = new Mock<IFornecedorWriteRepository>();
        _produtoRepoMock = new Mock<IProdutoRepository>();

        _handler = new AtualizarFornecedorHandler(
            _repoReadMock.Object,
            _repoWriteMock.Object
        );
    }

    [Fact]
    public async Task Deve_atualizar_fornecedor_com_sucesso()
    {
        // Arrange
        var produtoId = Guid.NewGuid();

        var produtos = new List<Produto>
    {
        Produto.Add("Produto Teste", 151)
    };

        _produtoRepoMock
            .Setup(r => r.ObterPorIdsAsync(
                It.IsAny<IEnumerable<Guid>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(produtos);

        var command = new AtualizarFornecedorCommand
        {
            Id = Guid.NewGuid(),
            Nome = "Fornecedor Atualizado",
            Email = "fornecedor@teste.com",
            Documento = "123456789",
            ProdutosIds = new List<Guid> { produtoId }
        };

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _repoWriteMock.Verify(
            r => r.UpdateAsync(
                It.Is<Fornecedor>(f => f.Nome == "Fornecedor Atualizado"),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}