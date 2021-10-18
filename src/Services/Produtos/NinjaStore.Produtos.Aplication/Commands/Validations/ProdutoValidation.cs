using FluentValidation;
using System;

namespace NinjaStore.Produtos.Aplication.Commands.Validations
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Descrição do produto não pode estar vazia!")
                .Length(1, 200).WithMessage("Descrição do produto deve ter entre 1 e 200 caracteres!");
        }
        protected void ValidateValor()
        {
            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("Valor do produto não pode estar vazio!")
                .NotNull().WithMessage("Valor do produto não pode ser nulo!")
                .GreaterThan(0).WithMessage("Valor do produto deve ser maior que zero!");

        }
    }
}
