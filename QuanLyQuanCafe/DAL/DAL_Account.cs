using DevExpress.ClipboardSource.SpreadsheetML;
using QuanLyQuanCafe.DTO;
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

        public void UpdateAccountInfo(string username, string displayName, string sex, DateTime birthDay, string address)
        {
            string query = "USP_UpdateAccountInfo";
            DataProvider.ExecuteQuery(query, new object[] { username, displayName, sex, birthDay, address });
        }

        public Account GetAccountInfoByUsername(string username)
        {
            string query = "USP_GetAccountInfoByUsername";
            DataTable dataTable = DataProvider.ExecuteQuery(query, new object[] { username });

            Account account = new Account();
            foreach(DataRow row in dataTable.Rows)
            {
                account = new Account(row);
            }
            return account;
        }
    }
}
