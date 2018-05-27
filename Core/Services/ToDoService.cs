using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class ToDoService : IToDoService
    {
        private readonly SqlConnection _connection;

        public ToDoService(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration["ConnectionString"]);
            _connection.Open();
        }

        public async Task<List<ToDo>> Get()
        {
            var itemsList = new List<ToDo>();

            var command = new SqlCommand("SELECT * FROM ToDo", _connection);
            var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
                itemsList.Add(new ToDo
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    IsDone = reader.GetBoolean(3)
                });

            return itemsList;
        }

        public async Task<ToDo> Get(int id)
        {
            var command = new SqlCommand($"SELECT * FROM ToDo WHERE Id = {id}", _connection);
            var reader = await command.ExecuteReaderAsync();

            if (!reader.HasRows) return null;

            if (reader.Read())
                return new ToDo
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    IsDone = reader.GetBoolean(3)
                };

            return null;
        }

        public async Task<int> Add(ToDo item)
        {
            var command = new SqlCommand("SELECT Max(Id) FROM ToDo", _connection);
            var dbId = await command.ExecuteScalarAsync();
            var id = dbId == DBNull.Value ? 0 : (int) dbId;

            command = new SqlCommand(
                $"INSERT INTO ToDo (Id, Name, Description, IsDone) VALUES ({id + 1}, '{item.Name}', '{item.Description}', '{item.IsDone}')",
                _connection);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> Update(int id, ToDo item)
        {
            var command =
                new SqlCommand(
                    $"UPDATE ToDo SET Name = '{item.Name}', Description = '{item.Description}', IsDone = '{item.IsDone}' WHERE Id = {item.Id}",
                    _connection);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> Delete(int id)
        {
            var command = new SqlCommand($"DELETE FROM ToDo WHERE Id = {id}", _connection);
            return await command.ExecuteNonQueryAsync();
        }
    }
}