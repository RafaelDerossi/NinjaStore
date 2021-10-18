using NinjaStore.Core.Messages.CommonMessages;

namespace NinjaStore.Produtos.Aplication.Events
{
    public abstract class ProdutoEvent : Event
    {
        public System.Guid Id { get; protected set; }

        public string Descricao { get; protected set; }        

        public decimal Valor { get; protected set; }

        public string Foto { get; protected set; }

        public decimal Estoque { get; protected set; }
    }
}
