using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Produtos.Domain;
using NinjaStore.Produtos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Produtos.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContextDB _context;
       
        public ProdutoRepository(ProdutoContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Produto entity)
        {
            _context.Produtos.Add(entity);
        }

        public void Atualizar(Produto entity)
        {
            _context.Produtos.Update(entity);
        }

        public void Apagar(Func<Produto, bool> predicate)
        {
            _context.Produtos.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<Produto> ObterPorId(Guid Id)
        {
            return await _context.Produtos                
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<Produto>> Obter(Expression<Func<Produto, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Produtos
                                            .AsNoTracking()
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.Produtos
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.Produtos
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.Produtos
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
