using System.Collections.Generic;
using Pz3.Models;

namespace Pz3.Services.Interfaces
{
    public interface IToDoService
    {
        IEnumerable<ToDo> Get();
        ToDo Get(int id);
        void Add(ToDo item);
        void Update(int id, ToDo item);
        void Delete(int id);
    }
}