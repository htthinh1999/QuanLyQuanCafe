using System.Data;

namespace QuanLyQuanCafe.DTO
{
    class TableFood
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        public TableFood() { }
        public TableFood(int id, string name, string status)
        {
            ID = id;
            Name = name;
            Status = status;
        }
        public TableFood(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
            Status = row["status"].ToString();
        }

    }
}
