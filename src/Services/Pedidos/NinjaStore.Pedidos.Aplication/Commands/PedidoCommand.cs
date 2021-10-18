using NinjaStore.Core.Messages.CommonMessages;
using NinjaStore.Core.Messages.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Numero { get; protected set; }

        public ClienteDTO Cliente { get; protected set; }        

        public List<ProdutoDTO> Produtos { get; protected set; }




        public void SetCliente(ClienteDTO cliente) => Cliente = cliente;

        public void SetListaDeProdutos(List<ProdutoDTO> produtos) => Produtos = produtos;
    }
}
