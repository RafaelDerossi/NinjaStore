using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Pedidos.Domain
{
    public class Produto : Entity
    {
        public const int Max = 200;

        public Guid ProdutoId { get; set; }

        public string Descricao { get; private set; }

        public string Foto { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Quantidade { get; private set; }

        public decimal Desconto { get; private set; }

        public decimal ValorTotal { get; private set; }

        public Guid PedidoId { get; set; }        


        protected Produto()
        {
        }

        public Produto
            (Guid id, Guid produtoId, string descricao, string foto, decimal valor, decimal quantidade, decimal desconto, decimal valorTotal)
        {
            SetEntidadeId(id);
            ProdutoId = produtoId;
            Descricao = descricao;
            Foto = foto;
            Valor = valor;
            Quantidade = quantidade;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }
    }
}
