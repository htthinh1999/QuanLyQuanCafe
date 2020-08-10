using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAL
{
    public class DAL_FoodCategory
    {
        static DAL_FoodCategory instance;
        public static DAL_FoodCategory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_FoodCategory();
                }
                return instance;
            }
            private set { instance = value; }
        }

        public DAL_FoodCategory() { }

        public List<FoodCategory> LoadFoodCategoryList()
        {
            List<FoodCategory> foodCategoryList = new List<FoodCategory>();
            string query = "SELECT * FROM FoodCategory";
            DataTable dataTable = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                FoodCategory foodCategory = new FoodCategory(row);
                foodCategoryList.Add(foodCategory);
            }

            return foodCategoryList;
        }
    }
}
