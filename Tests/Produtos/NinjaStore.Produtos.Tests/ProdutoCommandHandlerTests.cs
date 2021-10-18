using Moq;
using Moq.AutoMock;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Domain;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NinjaStore.Produtos.Tests
{
    public class ProdutoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ProdutoCommandHandler _produtoCommandHandler;

        public ProdutoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _produtoCommandHandler = _mocker.CreateInstance<ProdutoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Produto Válido")]
        [Trait("Categoria", "Produto - ProdutoCommandHandler")]
        public async Task AdicionarProduto_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = ProdutoCommandFactory.CriarComandoAdicionarProduto();          

            _mocker.GetMock<IProdutoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _produtoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IProdutoRepository>().Verify(r => r.Adicionar(It.IsAny<Produto>()), Times.Once);
            _mocker.GetMock<IProdutoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Produto Inválido - Sem Descrição")]
        [Trait("Categoria", "Produto - ProdutoCommandHandler")]
        public async Task AdicionarProduto_CommandoInvalido_SemDescricao_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ProdutoCommandFactory.CriarComandoAdicionarProdutoSemDescricao();
            
            _mocker.GetMock<IProdutoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _produtoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);            
        }

        [Fact(DisplayName = "Adicionar Produto Inválido - Com valor zero")]
        [Trait("Categoria", "Produto - ProdutoCommandHandler")]
        public async Task AdicionarProduto_CommandoInvalido_ValorZero_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ProdutoCommandFactory.CriarComandoAdicionarProdutoComValorZero();

            _mocker.GetMock<IProdutoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _produtoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Adicionar Produto Inválido - Com valor Negativo")]
        [Trait("Categoria", "Produto - ProdutoCommandHandler")]
        public async Task AdicionarProduto_CommandoInvalido_ValorNegativo_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ProdutoCommandFactory.CriarComandoAdicionarProdutoComValorNegativo();

            _mocker.GetMock<IProdutoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _produtoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }



    }
}
