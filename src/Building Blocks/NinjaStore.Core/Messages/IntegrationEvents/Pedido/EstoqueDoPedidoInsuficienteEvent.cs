using NinjaStore.Core.Messages.CommonMessages;
using System;
namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class EstoqueDoPedidoInsuficienteEvent : IntegrationEvent
    {
        public Guid PedidoId { get; protected set; }

        public Guid ProdutoId { get; protected set; }

        public string Descricao { get; protected set; }

        public EstoqueDoPedidoInsuficienteEvent
            (Guid pedidoId, Guid produtoId, string descricao)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Descricao = descricao;
        }        
    }
}
