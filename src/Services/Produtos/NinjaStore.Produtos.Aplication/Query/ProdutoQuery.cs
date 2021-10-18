using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Aplication.Query
{
    public class ProdutoQuery : IProdutoQuery
    {
        private readonly IProdutoQueryRepository _produtoQueryRepository;        

        public ProdutoQuery(IProdutoQueryRepository produtoQueryRepository)
        {
            _produtoQueryRepository = produtoQueryRepository;            
        }


        public async Task<ProdutoFlat> ObterPorId(Guid Id)
        {
            return await _produtoQueryRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<ProdutoFlat>> ObterTodos()
        {
            return await _produtoQueryRepository.Obter(x => !x.Lixeira);
        }

       
        public void Dispose()
        {
            _produtoQueryRepository?.Dispose();
        }

    }
}