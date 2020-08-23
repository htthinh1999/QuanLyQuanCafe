using System.Data;

namespace QuanLyQuanCafe.DTO
{
    class AccountType
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public AccountType() { }

        public AccountType(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public AccountType(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
        }
    }
}
