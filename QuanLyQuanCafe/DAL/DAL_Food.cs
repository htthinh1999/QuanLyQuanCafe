using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAL
{
    public class DAL_Food
    {
        static DAL_Food instance;
        public static DAL_Food Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_Food();
                }
                return instance;
            }
            private set { instance = value; }
        }

        public DAL_Food() { }

        public List<Food> LoadFoodListByCategoryID(int idFoodCategory)
        {
            List<Food> foodList = new List<Food>();

            string query = "SELECT * FROM Food WHERE idCategory = " + idFoodCategory;
            DataTable dataTable = DataProvider.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food(row);
                foodList.Add(food);
            }

            return foodList;
        }

        public void AddFoodToTable(int foodID, int count, int tableID)
        {
            string query = "USP_AddFoodToTable";
            DataProvider.ExecuteQuery(query, new object[] { foodID, count, tableID });
        }

        public DataTable LoadFoodList()
        {
            string query = "SELECT f.id [ID], f.name [Tên món], fc.name [Loại món], price [Giá tiền] " +
                            "FROM Food f INNER JOIN dbo.FoodCategory fc ON fc.id = f.idCategory";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable Search(string text)
        {
            string query = "SELECT f.id [ID], f.name [Tên món], fc.name [Loại món], price [Giá tiền] " +
                            "FROM dbo.Food f INNER JOIN dbo.FoodCategory fc ON fc.id = f.idCategory " +
                            "WHERE dbo.fuConvertToUnsign(f.name) LIKE dbo.fuConvertToUnsign(N'%" + text + "%')";
            return DataProvider.ExecuteQuery(query);
        }

        public void AddFood(string foodName, int idCategory, float price)
        {
            string query = "INSERT INTO dbo.Food VALUES(N'" + foodName + "', " + idCategory + ", " + price + ")";
            DataProvider.ExecuteQuery(query);
        }

        public void UpdateFood(int foodID, string foodName, int categoryID, float price)
        {
            string query = "UPDATE dbo.Food SET name = N'" + foodName + "', idCategory = " + categoryID + ", price = " + price + " WHERE id = " + foodID;
            DataProvider.ExecuteQuery(query);
        }

        public void DeleteFood(int foodID)
        {
            string query = "DELETE dbo.Food WHERE id = " + foodID;
            DataProvider.ExecuteQuery(query);
        }
    }
}
