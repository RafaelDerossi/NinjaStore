
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.ViewModels
{
   public class AdicionaPedidoViewModel
    {
        public Guid ClienteId { get; set; }       

        public List<ProdutoViewModel> Produtos { get; set; }

    }
}
