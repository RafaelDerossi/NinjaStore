using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContextDB _context;
       
        public PedidoRepository(PedidoContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Pedido entity)
        {
            _context.Pedidos.Add(entity);
        }

        public void Atualizar(Pedido entity)
        {
            _context.Pedidos.Update(entity);
        }

        public void Apagar(Func<Pedido, bool> predicate)
        {
            _context.Pedidos.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<Pedido> ObterPorId(Guid Id)
        {
            return await _context.Pedidos
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<Pedido>> Obter(Expression<Func<Pedido, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Pedidos
                                            .AsNoTracking()
                                            .Include(x => x.Produtos)
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.Pedidos
                                        .AsNoTracking()
                                        .Include(x => x.Produtos)
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.Pedidos
                                        .AsNoTracking()
                                        .Include(x => x.Produtos)
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.Pedidos
                                    .AsNoTracking()
                                    .Include(x => x.Produtos)
                                    .Where(expression)
                                    .OrderBy(x => x.DataDeCadastro)
                                    .ToListAsync();
        }

        public async Task<int> ObterNumeroDoPedidoPorId(Guid Id)
        {
            var pedido = await _context.Pedidos                
                .FirstOrDefaultAsync(u => u.Id == Id);
            return pedido.Numero;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
