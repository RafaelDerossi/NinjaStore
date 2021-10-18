using NinjaStore.Core.Enumeradores;
using NinjaStore.Core.Messages.CommonMessages;
using NinjaStore.Core.Messages.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Core.Messages.IntegrationEvents.Pedidos
{
    public class PedidoAdicionadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; protected set; }

        public int Numero { get; protected set; }

        public StatusDePedido Status { get; protected set; }

        public string Justificativa { get; protected set; }

        public decimal Valor { get; protected set; }

        public decimal Desconto { get; protected set; }

        public decimal ValorTotal { get; protected set; }

        public ClienteDTO Cliente { get; protected set; }

        public List<ProdutoDTO> Produtos { get; protected set; }

        public PedidoAdicionadoEvent
            (Guid pedidoId, int numero, StatusDePedido status, decimal valor, decimal desconto,
             decimal valorTotal, ClienteDTO cliente, List<ProdutoDTO> produtos)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            Numero = numero;
            Status = status;
            Valor = valor;
            Desconto = desconto;
            ValorTotal = valorTotal;
            Cliente = cliente;
            Produtos = produtos;
        }        
    }
}
