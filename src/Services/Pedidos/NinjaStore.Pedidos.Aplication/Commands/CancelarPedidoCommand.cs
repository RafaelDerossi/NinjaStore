using NinjaStore.Pedidos.Aplication.Commands.Validations;
using System;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public class CancelarPedidoCommand : PedidoCommand
    {
        public CancelarPedidoCommand(Guid id, string justificativaCancelamento)
        {
            AggregateId = id;
            Id = id;
            JustificativaCancelamento = justificativaCancelamento;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarPedidoCommandValidation : PedidoValidation<CancelarPedidoCommand>
        {
            public CancelarPedidoCommandValidation()
            {
                ValidateId();
                ValidateJustificaticaCancelamento();
            }
        }

    }
}
