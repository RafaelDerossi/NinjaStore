using NinjaStore.Core.DomainObjects;
using NinjaStore.Pedidos.Aplication.ViewModels;
using System;

namespace NinjaStore.Pedidos.Aplication.DTO
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public decimal Valor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }

        public ProdutoDTO()
        {
        }

        public ProdutoDTO
            (Guid id, Guid produtoId, string descricao, string foto, decimal valor,
             decimal quantidade, decimal desconto, decimal valorTotal)
        {
            Id = id;
            ProdutoId = produtoId;
            Descricao = descricao;
            Foto = foto;
            Valor = valor;
            Quantidade = quantidade;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public static ProdutoDTO Mapear(ProdutoViewModel viewModel)
        {
            return
                new ProdutoDTO
                {
                    Id = Guid.NewGuid(), 
                    ProdutoId = viewModel.Id,
                    Descricao = viewModel.Descricao,
                    Foto = viewModel.Foto,
                    Valor = viewModel.Valor,
                    Quantidade = viewModel.Quantidade,
                    Desconto = viewModel.Desconto,
                    ValorTotal = viewModel.ValorTotal
                };
        }
    }
}
