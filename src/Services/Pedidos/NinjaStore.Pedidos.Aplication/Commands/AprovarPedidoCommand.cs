using NinjaStore.Pedidos.Aplication.Commands.Validations;
using System;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public class AprovarPedidoCommand : PedidoCommand
    {
        public AprovarPedidoCommand(Guid pedidoId)
        {
            AggregateId = pedidoId;
            Id = pedidoId;            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AprovarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AprovarPedidoCommandValidation : PedidoValidation<AprovarPedidoCommand>
        {
            public AprovarPedidoCommandValidation()
            {
                ValidateId();                
            }
        }

    }
}
