using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int IDFoodCategory { get; private set; }
        public float Price { get; private set; }

        public Food() { }

        public Food(int id, string name, int idFoodCategory, float price)
        {
            ID = id;
            Name = name;
            IDFoodCategory = idFoodCategory;
            Price = price;
        }

        public Food(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
            IDFoodCategory = (int)row["idCategory"];
            Price = float.Parse(row["price"].ToString());
        }
    }
}
