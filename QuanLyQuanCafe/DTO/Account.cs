using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public string Username { get; private set; }
        public string DisplayName { get; private set; }
        public int TypeID { get; private set; }
        public string Password { get; private set; }
        public string Sex { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Address { get; private set; }

        public Account() { }
        public Account(string username, string displayName, int typeID, string sex, DateTime birthday, string address, string password = null)
        {
            Username = username;
            DisplayName = displayName;
            TypeID = typeID;
            Sex = sex;
            Birthday = birthday;
            Address = address;
            Password = password;
        }

        public Account(DataRow row)
        {
            Username = row["username"].ToString();
            DisplayName = row["displayName"].ToString();
            TypeID = (int)row["typeID"];
            Sex = row["sex"].ToString();
            Birthday = (DateTime)row["birthday"];
            Address = row["address"].ToString();
            if (row["password"].ToString() != null)
            {
                Password = row["password"].ToString();
            }
        }

    }
}
