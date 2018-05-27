using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Pz2
{
    public static class Program
    {
        private const string ConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Documents\\Projects\\DotNET\\Pz2\\db.mdf;Integrated Security=True;Connect Timeout=30";

        private static readonly SqlConnection Connection = new SqlConnection(ConnectionString);

        public static async Task Main()
        {
            await Connection.OpenAsync();

            await PrintAll();
            await Add("User123");
            await PrintAll();
            await SetMoneyAmount("User123", 2000);
            await PrintAll();
            await GetTotalMoneyAmount();
            Console.WriteLine(await GetTotalMoneyAmount());
        }

        private static async Task PrintAll()
        {
            var command = new SqlCommand("SELECT * FROM dbo.Users", Connection);
            var reader = await command.ExecuteReaderAsync();

            while (reader.Read()) Console.WriteLine($"Name:{reader.GetString(0)}, MoneyAmount:{reader.GetValue(1)}");
            reader.Close();
        }

        private static async Task Add(string name)
        {
            var command = new SqlCommand($"INSERT INTO dbo.Users (Name) VALUES ('{name}');", Connection);

            await command.ExecuteNonQueryAsync();
        }

        private static async Task SetMoneyAmount(string name, int moneyAmount)
        {
            var command = new SqlCommand($"EXEC dbo.SetMoneyAmount @name = N'{name}', @moneyAmount = {moneyAmount}",
                Connection);

            await command.ExecuteNonQueryAsync();
        }

        private static async Task<int> GetTotalMoneyAmount()
        {
            var command = new SqlCommand("SELECT dbo.GetTotalMoneyAmount()", Connection);

            var commandResult = await command.ExecuteScalarAsync();

            return (int) commandResult;
        }
    }
}