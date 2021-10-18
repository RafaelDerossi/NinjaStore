using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Pedidos.Domain.FlatModel;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Infra.Data.Repository
{
    public class PedidoQueryRepository : IPedidoQueryRepository
    {
        private readonly PedidoQueryContextDB _context;
       
        public PedidoQueryRepository(PedidoQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(PedidoFlat entity)
        {
            _context.PedidosFlat.Add(entity);
        }

        public void Atualizar(PedidoFlat entity)
        {
            _context.PedidosFlat.Update(entity);
        }

        public void Apagar(Func<PedidoFlat, bool> predicate)
        {
            _context.PedidosFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<PedidoFlat> ObterPorId(Guid Id)
        {
            return await _context.PedidosFlat
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<PedidoFlat>> Obter(Expression<Func<PedidoFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.PedidosFlat
                                            .AsNoTracking()
                                            .Include(x => x.Produtos)
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.PedidosFlat
                                        .AsNoTracking()
                                        .Include(x => x.Produtos)
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.PedidosFlat
                                        .AsNoTracking()
                                        .Include(x => x.Produtos)
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.PedidosFlat
                                    .AsNoTracking()
                                    .Include(x => x.Produtos)
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
