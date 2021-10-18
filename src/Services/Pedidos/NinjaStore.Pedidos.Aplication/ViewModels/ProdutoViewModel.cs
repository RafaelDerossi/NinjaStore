using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Pedidos.Aplication.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public decimal Valor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }
      
    }
}
