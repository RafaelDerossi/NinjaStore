using NinjaStore.Core.DomainObjects;
using NinjaStore.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Domain.FlatModel
{
   public class PedidoFlat : IAggregateRoot
   {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }        

        public bool Lixeira { get; private set; }



        public int Numero { get; private set; }

        public StatusDePedido Status { get; private set; }

        public string DescricaoDoStatus
        {
            get
            {
                return Status switch
                {
                    StatusDePedido.PENDENTE => "Pendente",
                    StatusDePedido.APROVADO => "Aprovado",
                    StatusDePedido.CANCELADO => "Cancelado",
                    _ => "Pendente",
                };
            }
        }

        public string JustificativaDoCancelamento { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Desconto { get; private set; }

        public decimal ValorTotal { get; private set; }


        public Guid ClienteId { get; protected set; }

        public string NomeDoCliente { get; protected set; }

        public string EmailDoCliente { get; protected set; }

        public string AldeiaDoCliente { get; protected set; }


        private readonly List<ProdutoDoPedidoFlat> _Produtos;
        public IReadOnlyCollection<ProdutoDoPedidoFlat> Produtos => _Produtos;


        protected PedidoFlat()
        {
            _Produtos = new List<ProdutoDoPedidoFlat>();
        }

        public PedidoFlat
            (Guid id, int numero, StatusDePedido status, decimal valor,
             decimal desconto, decimal valorTotal, Guid clienteId,
             string nomeDoCliente, string emailDoCliente, string aldeiaDoCliente)
        {
            _Produtos = new List<ProdutoDoPedidoFlat>();
            Id = id;
            Numero = numero;
            Status = status;
            Valor = valor;
            Desconto = desconto;
            ValorTotal = valorTotal;
            ClienteId = clienteId;
            NomeDoCliente = nomeDoCliente;
            EmailDoCliente = emailDoCliente;
            AldeiaDoCliente = aldeiaDoCliente;
        }


        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public void SetNumero(int numero) => Numero = numero;

        public void AdicionarProduto(ProdutoDoPedidoFlat produto)
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
