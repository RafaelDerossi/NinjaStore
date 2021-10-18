using FluentValidation.Results;
using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Produtos.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public const int Max = 200;        

        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public string Foto { get; private set; }

        public decimal Estoque { get; private set; }

        protected Produto()
        {
        }

        public Produto(string descricao, decimal valor, string foto, decimal estoque)
        {
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
            Estoque = estoque;
        }

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetValor(decimal valor) => Valor = valor;

        public void SetFoto(string foto) => Foto = foto;

        public void AdicionarEstoque(decimal quantidade)
        {
            Estoque += quantidade;
        }

        public ValidationResult DebitarEstoque(decimal quantidade)
        {
            if (quantidade > Estoque)
            {
                AdicionarErrosDaEntidade("Estoque insuficiente!");
                return ValidationResult;
            }

            Estoque -= quantidade;

            return ValidationResult;
        }

        public bool TemEstoque(decimal quantidade)
        {
            if (quantidade > Estoque)
                return false;

            return true;
        }
    }
}
