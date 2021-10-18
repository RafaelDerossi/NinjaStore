using System.Threading.Tasks;

namespace NinjaStore.Core.Data
{
    public interface IUnitOfWorks
    {
        Task<bool> Commit();
    }
}