using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Clientes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Aplication.Query
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IClienteQueryRepository _clienteQueryRepository;        

        public ClienteQuery(IClienteQueryRepository clienteQueryRepository)
        {
            _clienteQueryRepository = clienteQueryRepository;            
        }


        public async Task<ClienteFlat> ObterPorId(Guid Id)
        {
            return await _clienteQueryRepository.ObterPorId(Id);
        }

        public async Task<IEnumerable<ClienteFlat>> ObterTodos()
        {
            return await _clienteQueryRepository.Obter(x => !x.Lixeira);
        }

       
        public void Dispose()
        {
            _clienteQueryRepository?.Dispose();
        }

    }
}