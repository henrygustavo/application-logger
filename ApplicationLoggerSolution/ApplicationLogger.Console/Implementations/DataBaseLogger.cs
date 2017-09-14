
namespace ApplicationLogger.Console.Implementations
{
    using Enums;
    using Interfaces;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class DataBaseLogger : ILogger
    {
       public void LogMessage(LogMessageType logMessageType, string message)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"Insert into Log Values('{message}',{(int)logMessageType})";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
