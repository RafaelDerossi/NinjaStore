using NinjaStore.Core.Messages.CommonMessages;
using System;

namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class PedidoAprovadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; protected set; }

        public PedidoAprovadoEvent(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;            
        }        
    }
}
