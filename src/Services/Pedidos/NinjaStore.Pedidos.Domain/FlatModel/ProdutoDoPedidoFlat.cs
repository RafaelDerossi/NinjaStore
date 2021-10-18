using System;

namespace NinjaStore.Pedidos.Domain.FlatModel
{
    public class ProdutoDoPedidoFlat
    {
        public Guid Id { get; private set; }

        public Guid ProdutoId { get; private set; }

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



        public string Descricao { get; private set; }

        public string Foto { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Quantidade { get; private set; }

        public decimal Desconto { get; private set; }

        public decimal ValorTotal { get; private set; }

        public Guid PedidoFlatId { get; set; }        


        protected ProdutoDoPedidoFlat()
        {
        }

        public ProdutoDoPedidoFlat
            (Guid id, Guid produtoId, string descricao, string foto, decimal valor,
             decimal quantidade, decimal desconto, decimal valorTotal)
        {
            Id = id;
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
