using NinjaStore.Core.Enumeradores;
using NinjaStore.Core.Messages;
using NinjaStore.Pedidos.Aplication.DTO;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Events
{
    public abstract class PedidoEvent : Event
    {
        public System.Guid Id { get; protected set; }

        public int Numero { get; protected set; }

        public StatusDePedido Status { get; protected set; }

        public string Justificativa { get; protected set; }

        public decimal Valor { get; protected set; }

        public decimal Desconto { get; protected set; }

        public decimal ValorTotal { get; protected set; }

        public ClienteDTO Cliente { get; protected set; }

        public List<ProdutoDTO> Produtos { get; protected set; }
    }
}
