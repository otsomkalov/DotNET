using System.Threading.Tasks;
using DKR.Models;

namespace DKR.Services.Interfaces
{
    public interface IStoreProductService
    {
        Task<StoreProduct[]> ListAsync();
        Task<StoreProduct> GetByIdAsync(int id);
        Task CreateAsync(StoreProduct storeProduct);
        Task UpdateAsync(StoreProduct storeProduct);
        Task RemoveAsync(StoreProduct storeProduct);
    }
}