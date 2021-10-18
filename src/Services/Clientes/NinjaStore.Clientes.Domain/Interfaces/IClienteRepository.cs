using NinjaStore.Core.Data;
using System.Threading.Tasks;

namespace NinjaStore.Clientes.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> VerificaEmailJaCadastrado(string email);
    }
}
