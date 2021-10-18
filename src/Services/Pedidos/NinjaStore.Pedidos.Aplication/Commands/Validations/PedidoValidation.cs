using FluentValidation;
using System;

namespace NinjaStore.Pedidos.Aplication.Commands.Validations
{
    public abstract class PedidoValidation<T> : AbstractValidator<T> where T : PedidoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }       
        
        protected void ValidateCliente()
        {
            RuleFor(c => c.Cliente)
                .NotNull();            
        }

        protected void ValidateProduto()
        {
            RuleFor(x => x.Produtos)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Produtos).ChildRules(Regras =>
            {
                Regras.RuleFor(p => p.ProdutoId).NotEmpty().NotNull().NotEqual(Guid.Empty);
                Regras.RuleFor(p => p.Descricao).NotEmpty().NotNull();
                Regras.RuleFor(p => p.Valor).NotEmpty().NotNull();
                Regras.RuleFor(p => p.ValorTotal).NotEmpty().NotNull();
            });          
        }
    }
}
