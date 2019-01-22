using System.Threading.Tasks;
using DKR.Models;

namespace DKR.Services.Interfaces
{
    public interface IStoreService
    {
        Task<Store[]> ListAsync();
        Task<Store> GetByIdAsync(int id);
        Task CreateAsync(Store store);
        Task UpdateAsync(Store store);
        Task RemoveAsync(Store store);
    }
}