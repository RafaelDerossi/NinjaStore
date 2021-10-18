using MediatR;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Aplication.Events
{
    public class ClienteEventHandler : EventHandler,
         INotificationHandler<ClienteAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IClienteQueryRepository _clienteQueryRepository;

        public ClienteEventHandler(IClienteQueryRepository clienteQueryRepository)
        {
            _clienteQueryRepository = clienteQueryRepository;
        }


        public async Task Handle(ClienteAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var clienteFlat = new ClienteFlat
                (notification.Id, notification.Nome, notification.Email, notification.Aldeia);
           
            _clienteQueryRepository.Adicionar(clienteFlat);
           
            await PersistirDados(_clienteQueryRepository.UnitOfWork);
        }
               

        public void Dispose()
        {
            _clienteQueryRepository?.Dispose();
        }

    }
}
