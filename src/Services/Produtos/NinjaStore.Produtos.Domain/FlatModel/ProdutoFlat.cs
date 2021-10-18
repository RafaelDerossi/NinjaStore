using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Produtos.Domain.FlatModel
{
   public class ProdutoFlat : IAggregateRoot
   {
        public const int Max = 200;
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


        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Estoque { get; private set; }

        public string Foto { get; private set; }

        protected ProdutoFlat()
        {
        }

        public ProdutoFlat
            (Guid id, string descricao, decimal valor, decimal estoque, string foto)
        {
            Id = id;            
            Descricao = descricao;
            Valor = valor;
            Estoque = estoque;
            Foto = foto;
        }

        public void SetEntidadeId(Guid NovoId) => Id = NovoId;

        public void EnviarParaLixeira() => Lixeira = true;

        public void RestaurarDaLixeira() => Lixeira = false;

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetValor(decimal valor) => Valor = valor;

        public void SetFoto(string foto) => Foto = foto;

        public void AdicionarEstoque(decimal quantidade)
        {
            Estoque += quantidade;
        }

        public void DebitarEstoque(decimal quantidade)
        {
            if (quantidade > Estoque)
                Estoque = 0;

            Estoque -= quantidade;
        }

        public bool TemEstoque(decimal quantidade)
        {
            if (quantidade > Estoque)
                return false;

            return true;
        }
    }
}
