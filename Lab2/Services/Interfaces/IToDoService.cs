using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Services.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDo>> ListAsync();
        Task<ToDo> GetByIdAsync(int id);
        Task<int> CreateAsync(ToDo item);
        Task<int> UpdateAsync(ToDo item);
        Task<int> RemoveAsync(int id);
    }
}