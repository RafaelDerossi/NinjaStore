using NinjaStore.Core.Messages.CommonMessages;
using System;
namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class EstoqueDoPedidoDebitadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; protected set; }

        public EstoqueDoPedidoDebitadoEvent
            (Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;            
        }        
    }
}
