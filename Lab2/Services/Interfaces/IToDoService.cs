using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Services.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<int> Add(ToDo item);
        Task<int> Update(ToDo item);
        Task<int> Delete(int id);
    }
}