using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Produtos.Domain.FlatModel;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Infra.Data.Repository
{
    public class ProdutoQueryRepository : IProdutoQueryRepository
    {
        private readonly ProdutoQueryContextDB _context;
       
        public ProdutoQueryRepository(ProdutoQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(ProdutoFlat entity)
        {
            _context.ProdutosFlat.Add(entity);
        }

        public void Atualizar(ProdutoFlat entity)
        {
            _context.ProdutosFlat.Update(entity);
        }

        public void Apagar(Func<ProdutoFlat, bool> predicate)
        {
            _context.ProdutosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<ProdutoFlat> ObterPorId(Guid Id)
        {
            return await _context.ProdutosFlat
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<ProdutoFlat>> Obter(Expression<Func<ProdutoFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.ProdutosFlat
                                            .AsNoTracking()
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.ProdutosFlat
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.ProdutosFlat
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.ProdutosFlat
                                    .AsNoTracking()
                                    .Where(expression)
                                    .OrderBy(x => x.DataDeCadastro)
                                    .ToListAsync();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
