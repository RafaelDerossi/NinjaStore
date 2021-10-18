using System;
using FluentValidation.Results;
using MediatR;

namespace NinjaStore.Core.Messages.CommonMessages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool EstaValido()
        {
            return ValidationResult.IsValid;
        }

        public void AdicionarErrosDeProcessamentoDoComando(string mensagemDeErro)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty,mensagemDeErro));
        }
    }
}