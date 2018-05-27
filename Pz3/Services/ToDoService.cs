using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Pz3.Models;
using Pz3.Services.Interfaces;

namespace Pz3.Services
{
    public class ToDoService : IToDoService
    {
        private readonly DataContext _context;
        private readonly Table<ToDo> _table;

        public ToDoService(string connectionString)
        {
            _context = new DataContext(connectionString);
            _table = _context.GetTable<ToDo>();
        }

        public IEnumerable<ToDo> Get()
        {
            return _table;
        }

        public ToDo Get(int id)
        {
            return _table.SingleOrDefault(toDo => toDo.Id == id);
        }

        public void Add(ToDo item)
        {
            _table.InsertOnSubmit(item);
            _context.SubmitChanges();
        }

        public void Update(int id, ToDo item)
        {
            var toDo = _table.SingleOrDefault(entity => entity.Id == id);

            if (toDo == null) return;

            toDo.Name = item.Name;
            toDo.Description = item.Description;
            toDo.IsDone = item.IsDone;

            _context.SubmitChanges();
        }

        public void Delete(int id)
        {
            var toDo = _table.SingleOrDefault(entity => entity.Id == id);

            if (toDo == null) return;

            _table.DeleteOnSubmit(toDo);

            _context.SubmitChanges();
        }
    }
}