using System.Threading.Tasks;
using DKR.Models;

namespace DKR.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company[]> ListAsync(params string[] includes);
        Task<Company> GetByIdAsync(int id);
        Task CreateAsync(Company company);
        Task Update(Company company);
        Task Remove(Company company);
    }
}