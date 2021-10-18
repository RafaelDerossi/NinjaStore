using NinjaStore.Core.Messages.CommonMessages;
using System;

namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class PedidoCanceladoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; protected set; }

        public string Justificativa { get; protected set; }

        public PedidoCanceladoEvent(Guid pedidoId, string justificativa)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            Justificativa = justificativa;
        }        
    }
}
