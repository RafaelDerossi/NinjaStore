using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Infra.Data.Repository
{
    public class ClienteQueryRepository : IClienteQueryRepository
    {
        private readonly ClienteQueryContextDB _context;
       
        public ClienteQueryRepository(ClienteQueryContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(ClienteFlat entity)
        {
            _context.ClientesFlat.Add(entity);
        }

        public void Atualizar(ClienteFlat entity)
        {
            _context.ClientesFlat.Update(entity);
        }

        public void Apagar(Func<ClienteFlat, bool> predicate)
        {
            _context.ClientesFlat.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<ClienteFlat> ObterPorId(Guid Id)
        {
            return await _context.ClientesFlat
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<ClienteFlat>> Obter(Expression<Func<ClienteFlat, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.ClientesFlat
                                            .AsNoTracking()
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.ClientesFlat
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.ClientesFlat
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.ClientesFlat
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
