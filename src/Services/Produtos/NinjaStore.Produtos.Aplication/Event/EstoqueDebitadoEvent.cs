using System;
namespace NinjaStore.Produtos.Aplication.Events
{
    public class EstoqueDebitadoEvent : ProdutoEvent
    {
        public decimal Quantidade { get; protected set; }

        public EstoqueDebitadoEvent
            (Guid id, decimal quantidade)
        {
            AggregateId = id;
            Id = id;            
            Quantidade = quantidade;
        }        
    }
}
