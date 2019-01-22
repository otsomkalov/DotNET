using System.Threading.Tasks;
using DKR.Models;

namespace DKR.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product[]> ListAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(Product product);
    }
}