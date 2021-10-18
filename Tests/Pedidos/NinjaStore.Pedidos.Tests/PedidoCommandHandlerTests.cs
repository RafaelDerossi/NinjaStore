using Moq;
using Moq.AutoMock;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NinjaStore.Pedidos.Tests
{
    public class PedidoCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly PedidoCommandHandler _pedidoCommandHandler;

        public PedidoCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _pedidoCommandHandler = _mocker.CreateInstance<PedidoCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Pedido Válido")]
        [Trait("Categoria", "Pedido -PedidoCommandHandler")]
        public async Task AdicionarPedido_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = PedidoCommandFactory.CriarComandoAdicionarPedido();
            
            _mocker.GetMock<IPedidoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _pedidoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IPedidoRepository>().Verify(r => r.Adicionar(It.IsAny<Pedido>()), Times.Once);
            _mocker.GetMock<IPedidoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Pedido Inválido - Sem Cliente")]
        [Trait("Categoria", "Pedido - PedidoCommandHandler")]
        public async Task AdicionarPedido_CommandoInvalido_SemCliente_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = PedidoCommandFactory.CriarComandoAdicionarPedidoSemCliente();
          
            _mocker.GetMock<IPedidoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _pedidoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);            
        }

        [Fact(DisplayName = "Adicionar Pedido Inválido - Sem Produtos")]
        [Trait("Categoria", "Pedido - PedidoCommandHandler")]
        public async Task AdicionarPedido_CommandoInvalido_SemProduto_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = PedidoCommandFactory.CriarComandoAdicionarPedidoSemProdutos();

            _mocker.GetMock<IPedidoRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _pedidoCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }

    }
}
