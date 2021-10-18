using NinjaStore.Core.DomainObjects;
using NinjaStore.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.Pedidos.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public int Numero { get; private set; }

        public StatusDePedido Status { get; set; }

        public string JustificativaDoCancelamento { get; private set; }

        public Guid ClienteId { get; private set; }


        public decimal Valor 
        { 
            get
            {
                if (_Produtos == null || _Produtos.Count() == 0)
                    return 0;

                return _Produtos.Sum(x => x.Valor);
            }
        }

        public decimal Desconto
        {
            get
            {
                if (_Produtos == null || _Produtos.Count() == 0)
                    return 0;

                return _Produtos.Sum(x => x.Desconto);
            }
        }        

        public decimal ValorTotal
        {
            get
            {
                if (_Produtos == null || _Produtos.Count() == 0)
                    return 0;

                return _Produtos.Sum(x => x.ValorTotal);
            }
        }
        

        private readonly List<Produto> _Produtos;
        public IReadOnlyCollection<Produto> Produtos => _Produtos;


        protected Pedido()
        {
            _Produtos = new List<Produto>();
        }

        public Pedido(Guid clienteId)
        {
            _Produtos = new List<Produto>();
            ClienteId = clienteId;
        }


        public void AdicionarProduto(Produto produto)
        {
            _Produtos.Add(produto);
        }

        public void AprovarPedido() => Status = StatusDePedido.APROVADO;

        public void CancelarPedido(string justificativa)
        {
            Status = StatusDePedido.CANCELADO;
            JustificativaDoCancelamento = justificativa;
        }

    }
}
