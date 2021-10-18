using NinjaStore.Produtos.Aplication.Commands.Validations;
using System;

namespace NinjaStore.Produtos.Aplication.Commands
{
    public class AdicionarProdutoCommand : ProdutoCommand
    {

        public AdicionarProdutoCommand(string descricao, decimal valor, string foto, decimal estoque)
        {            
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
            Estoque = estoque;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarProdutoCommandValidation : ProdutoValidation<AdicionarProdutoCommand>
        {
            public AdicionarProdutoCommandValidation()
            {                               
                ValidateDescricao();
                ValidateValor();                
            }
        }

    }
}
