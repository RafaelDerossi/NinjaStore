using Moq;
using Moq.AutoMock;
using NinjaStore.Clientes.Aplication.Commands;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NinjaStore.Clientes.Tests
{
    public class ClienteCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly ClienteCommandHandler _clienteCommandHandler;

        public ClienteCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _clienteCommandHandler = _mocker.CreateInstance<ClienteCommandHandler>();
        }

        [Fact(DisplayName = "Adicionar Cliente Válido")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoValido_DevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarCliente();

            _mocker.GetMock<IClienteRepository>().Setup(r => r.VerificaEmailJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IClienteRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.True(result.IsValid);
            _mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(It.IsAny<Cliente>()), Times.Once);
            _mocker.GetMock<IClienteRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }


        [Fact(DisplayName = "Adicionar Cliente Inválido - E-mail ja cadastrado")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoInvalido_EmailJaCadastrado_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarCliente();

            _mocker.GetMock<IClienteRepository>().Setup(r => r.VerificaEmailJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(true));

            _mocker.GetMock<IClienteRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);            
        }


        [Fact(DisplayName = "Adicionar Cliente Inválido - Sem E-mail")]
        [Trait("Categoria", "Cliente - ClienteCommandHandler")]
        public async Task AdicionarCliente_CommandoInvalido_SemEmail_NaoDevePassarNaValidacao()
        {
            //Arrange
            var Command = ClienteCommandFactory.CriarComandoAdicionarClienteSemEmail();

            _mocker.GetMock<IClienteRepository>().Setup(r => r.VerificaEmailJaCadastrado(Command.Email.Endereco))
                .Returns(Task.FromResult(false));

            _mocker.GetMock<IClienteRepository>().Setup(r => r.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await _clienteCommandHandler.Handle(Command, CancellationToken.None);

            //Assert
            Assert.False(result.IsValid);
        }
    }
}
