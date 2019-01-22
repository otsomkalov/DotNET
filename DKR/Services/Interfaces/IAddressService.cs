using System.Threading.Tasks;
using DKR.Models;

namespace DKR.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address[]> ListAsync();
        Task<Address> GetByIdAsync(int id);
        Task CreateAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(Address address);
    }
}