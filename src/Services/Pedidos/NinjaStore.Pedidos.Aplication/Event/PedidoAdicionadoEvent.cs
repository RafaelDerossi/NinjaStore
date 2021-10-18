using NinjaStore.Core.Enumeradores;
using NinjaStore.Pedidos.Aplication.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Events
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
