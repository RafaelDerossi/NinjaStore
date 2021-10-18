using System;
namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoAdicionadoEvent : ProdutoEvent
    {

        public ProdutoAdicionadoEvent
            (Guid id, string descricao, decimal valor, string foto, decimal estoque)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
            Estoque = estoque;
        }        
    }
}
