using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace CLRSQL
{
    public static class Functions
    {
        [SqlProcedure]
        public static void SetMoneyAmount(string name, int moneyAmount)
        {
            using (var connection = new SqlConnection("context connection=true"))
            {
                connection.Open();

                var command = new SqlCommand(
                    $"UPDATE dbo.Users SET MoneyAmount = '{moneyAmount}' WHERE Name='{name}'",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static int GetTotalMoneyAmount()
        {
            using (var connection = new SqlConnection("context connection=true"))
            {
                connection.Open();

                var cmd = new SqlCommand(
                    "SELECT SUM(MoneyAmount) FROM dbo.Users", connection);

                return (int) cmd.ExecuteScalar();
            }
        }

        [SqlTrigger]
        public static void InitUser()
        {
            using (var connection = new SqlConnection("context connection=true"))
            {
                connection.Open();

                var query = new SqlCommand("SELECT Name FROM INSERTED", connection);
                var name = (string) query.ExecuteScalar();

                var command = new SqlCommand(
                    $"UPDATE dbo.Users SET MoneyAmount = '1000' WHERE Name = '{name}'",
                    connection);

                command.ExecuteNonQuery();
            }
        }
    }
}