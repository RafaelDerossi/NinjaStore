using NinjaStore.Core.Data;
using System;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<int> ObterNumeroDoPedidoPorId(Guid Id);
    }
}
