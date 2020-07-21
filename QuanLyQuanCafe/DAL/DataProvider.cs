using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public static class DataProvider
    {
        static string connectionStr = "Data Source=TEAM-LIL;Initial Catalog=QuanLyQuanCafe;User ID=sa;Password=a123456";
        static SqlConnection con = new SqlConnection(connectionStr);

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
                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionStr);
                adapter.Fill(data);
            }
            catch (SqlException e) { }

            return data;
        }

    }
}
