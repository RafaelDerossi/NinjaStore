using NinjaStore.Core.Enumeradores;
using NinjaStore.Core.Messages.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Core.Messages.IntegrationEvents
{
    public class PedidoAdicionadoEvent : PedidoEvent
    {

        public PedidoAdicionadoEvent
            (Guid id, int numero, StatusDePedido status, decimal valor, decimal desconto,
             decimal valorTotal, ClienteDTO cliente, List<ProdutoDTO> produtos)
        {
            AggregateId = id;
            Id = id;
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
