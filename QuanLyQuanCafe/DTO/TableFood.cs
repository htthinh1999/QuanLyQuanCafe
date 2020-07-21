using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    class TableFood
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }

        public int Width { get; private set; } = 95;
        public int Height { get; private set; } = 95;

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
