using NinjaStore.Pedidos.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Aplication.Query
{
    public interface IPedidoQuery : IDisposable
    {
        Task<PedidoFlat> ObterPorId(Guid Id);

        Task<IEnumerable<PedidoFlat>> ObterTodos();
    }
}