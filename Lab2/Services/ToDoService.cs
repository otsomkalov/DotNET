using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Lab2.Services
{
    public class ToDoService : IToDoService
    {
        private readonly NpgsqlConnection _connection;

        public ToDoService(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration["ConnectionString"]);
            _connection.Open();
        }

        public async Task<List<ToDo>> ListAsync()
        {
            var itemsList = new List<ToDo>();

            var command = new NpgsqlCommand("SELECT * FROM ToDo", _connection);
            var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
                itemsList.Add(new ToDo
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2),
                    IsDone = reader.GetBoolean(3)
                });

            reader.Close();

            return itemsList;
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            var command = new NpgsqlCommand($"SELECT * FROM ToDo WHERE Id = {id}", _connection);
            var reader = await command.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                reader.Close();

                return null;
            }

            if (reader.Read())
            {
                var toDo = new ToDo
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2),
                    IsDone = reader.GetBoolean(3)
                };

                reader.Close();

                return toDo;
            }

            reader.Close();

            return null;
        }

        public async Task<int> CreateAsync(ToDo item)
        {
            var command = new NpgsqlCommand("SELECT Max(Id) FROM ToDo", _connection);
            var dbId = await command.ExecuteScalarAsync();
            var id = dbId == DBNull.Value ? 0 : (int) dbId;

            command = new NpgsqlCommand(
                $"INSERT INTO ToDo (Title, Description, IsDone) VALUES ('{item.Title}', '{item.Description}', '{item.IsDone}')",
                _connection);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateAsync(ToDo item)
        {
            var command =
                new NpgsqlCommand(
                    $"UPDATE ToDo SET Title = '{item.Title}', Description = '{item.Description}', IsDone = '{item.IsDone}' WHERE Id = {item.Id}",
                    _connection);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var command = new NpgsqlCommand($"DELETE FROM ToDo WHERE Id = {id}", _connection);
            return await command.ExecuteNonQueryAsync();
        }
    }
}