using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Query
{
    public class PedidoQuery : IPedidoQuery
    {
        private readonly IPedidoQueryRepository _pedidoQueryRepository;        

        public PedidoQuery(IPedidoQueryRepository pedidoQueryRepository)
        {
            _pedidoQueryRepository = pedidoQueryRepository;            
        }


        public async Task<PedidoFlat> ObterPorId(Guid Id)
        {
            return await _pedidoQueryRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<PedidoFlat>> ObterTodos()
        {
            return await _pedidoQueryRepository.Obter(x => !x.Lixeira);
        }

       
        public void Dispose()
        {
            _pedidoQueryRepository?.Dispose();
        }

    }
}