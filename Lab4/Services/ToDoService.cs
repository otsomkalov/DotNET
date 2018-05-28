using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Lab4.Models;
using Lab4.Services.Interfaces;

namespace Lab4.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IDbConnection _connection;

        public ToDoService(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public Task<IEnumerable<ToDo>> Get()
        {
            return _connection.QueryAsync<ToDo>("SELECT * FROM ToDo");
        }

        public Task<ToDo> Get(int id)
        {
            return _connection.QuerySingleOrDefaultAsync<ToDo>("SELECT * FROM ToDo WHERE Id = @id", new {id});
        }

        public async Task<int> Add(ToDo item)
        {
            var id = await _connection.ExecuteScalarAsync("SELECT MAX(Id) FROM ToDo") as int?;

            if (id.HasValue) item.Id = id.Value + 1;

            return await _connection.ExecuteAsync(
                "INSERT INTO ToDo (Id, Name, Description, IsDone) VALUES (@Id, @Name, @Description, @IsDone)", item);
        }

        public Task<int> Update(ToDo item)
        {
            return _connection.ExecuteAsync(
                "UPDATE ToDo SET Name = @Name, Description = @Description, IsDone = @IsDone WHERE Id = @Id", item);
        }

        public Task<int> Delete(int id)
        {
            return _connection.ExecuteAsync("DELETE FROM ToDo WHERE Id = @id", new {id});
        }
    }
}