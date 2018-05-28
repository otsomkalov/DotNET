using System.Collections.Generic;
using System.Threading.Tasks;
using Lab4.Models;

namespace Lab4.Services.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> Get();
        Task<ToDo> Get(int id);
        Task<int> Add(ToDo item);
        Task<int> Update(ToDo item);
        Task<int> Delete(int id);
    }
}