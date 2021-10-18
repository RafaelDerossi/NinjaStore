using NinjaStore.Core.Data;
using NinjaStore.Produtos.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Domain.Interfaces
{
    public interface IProdutoQueryRepository : IRepository<ProdutoFlat>
    {        
    }
}