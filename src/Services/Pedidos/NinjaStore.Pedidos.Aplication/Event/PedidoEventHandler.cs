using MediatR;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;
using NinjaStore.Pedidos.Aplication.Commands;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Events
{
    public class PedidoEventHandler : CommandHandler,
         INotificationHandler<PedidoAdicionadoEvent>,
         INotificationHandler<EstoqueDoPedidoDebitadoEvent>,
         INotificationHandler<EstoqueDoPedidoInsuficienteEvent>,
         INotificationHandler<PedidoAprovadoEvent>,
         INotificationHandler<PedidoCanceladoEvent>,
         System.IDisposable
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPedidoQueryRepository _pedidoQueryRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoEventHandler
            (IMediatorHandler mediatorHandler, IPedidoQueryRepository pedidoQueryRepository,
             IPedidoRepository pedidoRepository)
        {
            _mediatorHandler = mediatorHandler;
            _pedidoQueryRepository = pedidoQueryRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task Handle(PedidoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var pedidoFlat = new PedidoFlat
                (notification.PedidoId, notification.Numero, notification.Status, notification.Valor,
                 notification.Desconto, notification.ValorTotal, notification.Cliente.Id,
                 notification.Cliente.Nome, notification.Cliente.Email, notification.Cliente.Aldeia);

            foreach (var item in notification.Produtos)
            {
                pedidoFlat.AdicionarProduto(new ProdutoDoPedidoFlat(item.Id, item.ProdutoId,
                                                                    item.Descricao, item.Foto,
                                                                    item.Valor, item.Quantidade,
                                                                    item.Desconto, item.ValorTotal));
            }

            pedidoFlat.SetNumero(await _pedidoRepository.ObterNumeroDoPedidoPorId(pedidoFlat.Id));

            _pedidoQueryRepository.Adicionar(pedidoFlat);
           
            await PersistirDados(_pedidoQueryRepository.UnitOfWork);
        }


        public async Task Handle(EstoqueDoPedidoInsuficienteEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new CancelarPedidoCommand(notification.PedidoId, $"Estoque do produto {notification.Descricao} não disponível!"));                        
        }


        public async Task Handle(EstoqueDoPedidoDebitadoEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.EnviarComando(new AprovarPedidoCommand(notification.PedidoId));                        
        }


        public async Task Handle(PedidoAprovadoEvent notification, CancellationToken cancellationToken)
        {
            var pedidoFlat = await _pedidoQueryRepository.ObterPorId(notification.PedidoId);
            if (pedidoFlat == null)
                return;

            pedidoFlat.AprovarPedido();

            _pedidoQueryRepository.Atualizar(pedidoFlat);

            await PersistirDados(_pedidoQueryRepository.UnitOfWork);
        }


        public async Task Handle(PedidoCanceladoEvent notification, CancellationToken cancellationToken)
        {
            var pedidoFlat = await _pedidoQueryRepository.ObterPorId(notification.PedidoId);
            if (pedidoFlat == null)
                return;

            pedidoFlat.CancelarPedido(notification.Justificativa);

            _pedidoQueryRepository.Atualizar(pedidoFlat);

            await PersistirDados(_pedidoQueryRepository.UnitOfWork);
        }



        public void Dispose()
        {
            _pedidoQueryRepository?.Dispose();
        }

    }
}
