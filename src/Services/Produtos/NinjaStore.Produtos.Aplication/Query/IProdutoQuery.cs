using NinjaStore.Produtos.Domain.FlatModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Query
{
    public interface IProdutoQuery : IDisposable
    {
        Task<ProdutoFlat> ObterPorId(Guid Id);

        Task<IEnumerable<ProdutoFlat>> ObterTodos();
    }
}