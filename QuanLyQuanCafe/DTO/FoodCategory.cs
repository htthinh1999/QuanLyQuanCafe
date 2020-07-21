using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class FoodCategory
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public FoodCategory() { }

        public FoodCategory(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public FoodCategory(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
        }
    }
}
