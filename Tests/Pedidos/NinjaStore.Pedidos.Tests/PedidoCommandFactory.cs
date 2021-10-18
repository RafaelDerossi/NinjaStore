using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Aplication.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Tests
{
    public class PedidoCommandFactory
    {
        private static AdicionarPedidoCommand AdicionarPedidoCommandFactoy()
        {
            var cliente = new ClienteDTO(Guid.NewGuid(), "Nome do Cliente", "rafael@gmail.com", "aldeia");

            var produto1 = new ProdutoDTO(Guid.NewGuid(), Guid.NewGuid(), "Produto 1", "foto", 10, 1, 1, 9);
            var produto2 = new ProdutoDTO(Guid.NewGuid(), Guid.NewGuid(), "Produto 2", "foto", 20, 1, 2, 18);

            var produtos = new List<ProdutoDTO>
            {
                produto1,
                produto2
            };

            return new AdicionarPedidoCommand(cliente, produtos);
        }       


        public static AdicionarPedidoCommand CriarComandoAdicionarPedido()
        {
            return AdicionarPedidoCommandFactoy();
        }

        public static AdicionarPedidoCommand CriarComandoAdicionarPedidoSemCliente()
        {
            var comando = AdicionarPedidoCommandFactoy();
            comando.SetCliente(null);
            return comando;
        }

        public static AdicionarPedidoCommand CriarComandoAdicionarPedidoSemProdutos()
        {
            var comando = AdicionarPedidoCommandFactoy();
            comando.SetListaDeProdutos(new List<ProdutoDTO>());
            return comando;
        }
    }
}