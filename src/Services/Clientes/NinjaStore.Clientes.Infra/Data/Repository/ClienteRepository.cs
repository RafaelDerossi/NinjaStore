using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContextDB _context;
       
        public ClienteRepository(ClienteContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Cliente entity)
        {
            _context.Clientes.Add(entity);
        }

        public void Atualizar(Cliente entity)
        {
            _context.Clientes.Update(entity);
        }

        public void Apagar(Func<Cliente, bool> predicate)
        {
            _context.Clientes.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public async Task<Cliente> ObterPorId(Guid Id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(u => u.Id == Id && !u.Lixeira);
        }

        public async Task<IEnumerable<Cliente>> Obter(Expression<Func<Cliente, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Clientes
                                            .AsNoTracking()
                                            .Where(expression)
                                            .OrderByDescending(x => x.DataDeCadastro)
                                            .Take(take)
                                            .ToListAsync();

                return await _context.Clientes
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro)
                                        .ToListAsync();
            }

            if (take > 0)
                return await _context.Clientes
                                        .AsNoTracking()
                                        .Where(expression)
                                        .OrderBy(x => x.DataDeCadastro)
                                        .Take(take)
                                        .ToListAsync();

            return await _context.Clientes
                                    .AsNoTracking()
                                    .Where(expression)
                                    .OrderBy(x => x.DataDeCadastro)
                                    .ToListAsync();
        }

        public async Task<bool> VerificaEmailJaCadastrado(string email)
        {
            return await _context.Clientes
                .Where(u => u.Email.Endereco == email && !u.Lixeira).CountAsync() > 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
