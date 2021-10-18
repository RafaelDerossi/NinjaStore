using NinjaStore.Core.ValueObjects;
using NinjaStore.Core.Messages.CommonMessages;

namespace NinjaStore.Clientes.Aplication.Events
{
    public abstract class ClienteEvent : Event
    {
        public System.Guid Id { get; protected set; }

        public string Nome { get; protected set; }        

        public Email Email { get; protected set; }

        public string Aldeia { get; protected set; }

    }
}
