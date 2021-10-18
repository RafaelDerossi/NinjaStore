using NinjaStore.Clientes.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Aplication.Query
{
    public interface IClienteQuery : IDisposable
    {
        Task<ClienteFlat> ObterPorId(Guid Id);

        Task<IEnumerable<ClienteFlat>> ObterTodos();
    }
}