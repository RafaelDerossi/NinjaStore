using MediatR;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Core.Messages.IntegrationEvents.Pedidos;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoEventHandler : EventHandler,
         INotificationHandler<ProdutoAdicionadoEvent>,
         INotificationHandler<PedidoAdicionadoEvent>,
         INotificationHandler<EstoqueDebitadoEvent>,
         System.IDisposable
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoQueryRepository _produtoQueryRepository;

        public ProdutoEventHandler
            (IMediatorHandler mediatorHandler, IProdutoRepository produtoRepository,
             IProdutoQueryRepository produtoQueryRepository)
        {
            _mediatorHandler = mediatorHandler;
            _produtoRepository = produtoRepository;
            _produtoQueryRepository = produtoQueryRepository;
        }



        public async Task Handle(ProdutoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var produtoFlat = new ProdutoFlat
                (notification.Id, notification.Descricao, notification.Valor,
                 notification.Estoque, notification.Foto);
           
            _produtoQueryRepository.Adicionar(produtoFlat);
           
            await PersistirDados(_produtoQueryRepository.UnitOfWork);
        }


        public async Task Handle(PedidoAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            var listaComandos = new List<DebitarEstoqueCommand>();
            foreach (var produto in notification.Produtos)
            {
                var produtoBD = await _produtoRepository.ObterPorId(produto.ProdutoId);                
                if (produtoBD == null || !produtoBD.TemEstoque(produto.Quantidade))
                {
                    await _mediatorHandler.PublicarEvento(new EstoqueDoPedidoInsuficienteEvent
                        (notification.AggregateId, produto.ProdutoId, produto.Descricao));
                    return;
                }

                listaComandos.Add(new DebitarEstoqueCommand(produtoBD.Id, produto.Quantidade));
            }

            foreach (var comando in listaComandos)
            {
                await _mediatorHandler.EnviarComando(comando);
            }

            await _mediatorHandler.PublicarEvento(new EstoqueDoPedidoDebitadoEvent(notification.PedidoId));
        }


        public async Task Handle(EstoqueDebitadoEvent notification, CancellationToken cancellationToken)
        {
            var produtoFlat = await _produtoQueryRepository.ObterPorId(notification.Id);
            if (produtoFlat == null)
                return;

            produtoFlat.DebitarEstoque(notification.Quantidade);

            _produtoQueryRepository.Atualizar(produtoFlat);

            await PersistirDados(_produtoQueryRepository.UnitOfWork);
        }


        public void Dispose()
        {
            _produtoQueryRepository?.Dispose();
        }

    }
}
