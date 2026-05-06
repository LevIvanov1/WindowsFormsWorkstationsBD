using System;
using System.Data;
using Npgsql;

namespace WindowsFormsWorkstationsBD
{
    public static class DBHelper
    {
        public static event Action<string, string> OnQueryExecuted;

        private static string connectionString = "Host=localhost;Port=5433;Database=WorkOperatorSoftware;Username=postgres;Password=1234";

        public static DataTable ExecuteQuery(string query, bool log = true)
        {
            try
            {
                if (log)
                    OnQueryExecuted?.Invoke(query, "SELECT");

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка выполнения запроса: " + ex.Message);
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                OnQueryExecuted?.Invoke(query, "ИЗМЕНЕНИЕ");

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка выполнения команды: " + ex.Message);
            }
        }
    }
}