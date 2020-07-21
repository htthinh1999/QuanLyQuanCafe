using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public class DAL_Account
    {
        static DAL_Account instance;
        public static DAL_Account Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_Account();
                }
                return instance;
            }
        }
        public DAL_Account() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login";
            DataTable data = DataProvider.ExecuteQuery(query, new object[] { username, password });
            return data.Rows.Count > 0;
        }
    }
}
