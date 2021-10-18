using MediatR;
using NinjaStore.Core.Messages.CommonHandlers;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoEventHandler : EventHandler,
         INotificationHandler<ProdutoAdicionadoEvent>,
         System.IDisposable
    {

        private readonly IProdutoQueryRepository _produtoQueryRepository;

        public ProdutoEventHandler(IProdutoQueryRepository produtoQueryRepository)
        {
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
               

        public void Dispose()
        {
            _produtoQueryRepository?.Dispose();
        }

    }
}
