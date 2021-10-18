using FluentValidation;
using System;

namespace NinjaStore.Clientes.Aplication.Commands.Validations
{
    public abstract class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do cliente não pode estar vazia!")
                .Length(1, 200).WithMessage("Nome do cliente deve ter entre 1 e 200 caracteres!");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email.Endereco)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
        protected void ValidateAldeia()
        {
            RuleFor(c => c.Aldeia)
                .NotEmpty().WithMessage("Aldeia do cliente não pode estar vazia!")
                .Length(1, 200).WithMessage("Aldeia do cliente deve ter entre 1 e 200 caracteres!");
        }
    }
}
