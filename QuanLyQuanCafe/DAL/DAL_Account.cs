using QuanLyQuanCafe.DTO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

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

        public DataTable LoadAccountList()
        {
            string query = "USP_LoadAccountList";
            return DataProvider.ExecuteQuery(query);
        }

        public bool ExistAccount(string username)
        {
            string query = "USP_ExistAccount";
            return DataProvider.ExecuteQuery(query, new object[] { username }).Rows.Count > 0;
        }

        string EncryptMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2")); // Change it into 2 hexadecimal digits
            }
            return stringBuilder.ToString();
        }

        public bool Login(string username, string password)
        {
            string query = "USP_Login";
            DataTable data = DataProvider.ExecuteQuery(query, new object[] { username, EncryptMD5(password) });
            return data.Rows.Count > 0;
        }

        public Account GetAccountInfoByUsername(string username)
        {
            string query = "USP_GetAccountInfoByUsername";
            DataTable dataTable = DataProvider.ExecuteQuery(query, new object[] { username });

            Account account = new Account();
            foreach (DataRow row in dataTable.Rows)
            {
                account = new Account(row);
            }
            return account;
        }

        public void UpdateAccountInfo(string username, string displayName, int typeID, string sex, DateTime birthDay, string address)
        {
            string query = "USP_UpdateAccountInfo";
            DataProvider.ExecuteQuery(query, new object[] { username, displayName, typeID, sex, birthDay, address });
        }

        public void UpdatePassword(string username, string newPassword)
        {
            string query = "USP_UpdatePassword";
            DataProvider.ExecuteQuery(query, new object[] { username, EncryptMD5(newPassword) });
        }

        public void AddAccount(string username, string displayName, int typeID, string sex, DateTime birthday, string address)
        {
            string query = "USP_AddAccount";
            DataProvider.ExecuteQuery(query, new object[] { username, displayName, typeID, sex, birthday, address });
        }

        public void DeleteAccount(string username)
        {
            string query = "USP_DeleteAccount";
            DataProvider.ExecuteQuery(query, new object[] { username });
        }

        public void ResetPassword(string username)
        {
            string query = "USP_ResetPassword";
            DataProvider.ExecuteQuery(query, new object[] { username });
        }
    }
}
