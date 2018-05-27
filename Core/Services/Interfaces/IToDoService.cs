using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<int> Add(ToDo item);
        Task<int> Update(int id, ToDo item);
        Task<int> Delete(int id);
    }
}