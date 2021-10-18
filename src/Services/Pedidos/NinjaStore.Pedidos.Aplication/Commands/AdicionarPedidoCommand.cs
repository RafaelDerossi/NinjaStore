using NinjaStore.Core.Messages.DTO;
using NinjaStore.Pedidos.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public class AdicionarPedidoCommand : PedidoCommand
    {
        public AdicionarPedidoCommand(ClienteDTO cliente, List<ProdutoDTO> produtos)
        {            
            Cliente = cliente;
            Produtos = produtos;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarPedidoCommandValidation : PedidoValidation<AdicionarPedidoCommand>
        {
            public AdicionarPedidoCommandValidation()
            {                               
                ValidateCliente();
                ValidateProduto();
            }
        }

    }
}
