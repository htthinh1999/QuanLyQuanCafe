using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class BillTableInfo
    {
        public string FoodName { get; private set; }
        public int Count { get; private set; }
        public float Price { get; private set; }
        public float TotalPrice { get; private set; }

        public BillTableInfo() { }
        public BillTableInfo(string foodName, int count, float price, float totalPrice)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }
        public BillTableInfo(DataRow row)
        {
            FoodName = row["name"].ToString();
            Count = (int)row["count"];
            Price = float.Parse(row["price"].ToString());
            TotalPrice = float.Parse(row["totalPrice"].ToString());
        }
    }
}
