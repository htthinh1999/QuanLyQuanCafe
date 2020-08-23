using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAL
{
    public static class DataProvider
    {
        public readonly static string ServerName = "(local)";
        public readonly static string DatabaseName = "QuanLyQuanCafe";

        static string connectionStr = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=true";

        public static DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            if (parameter != null)
            {
                for (int i = 0; i < parameter.Length; i++)
                {
                    query += " N'" + Convert.ToString(parameter[i]) + "'";
                    if (i != parameter.Length - 1)
                    {
                        query += ",";
                    }
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    connection.Open();
                    adapter.Fill(data);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

    }
}
