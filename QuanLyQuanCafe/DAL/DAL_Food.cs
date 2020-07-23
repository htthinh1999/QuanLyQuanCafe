using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Food> LoadFoodList(int idFoodCategory)
        {
            List<Food> foodList = new List<Food>();

            string query = "SELECT * FROM Food WHERE idCategory = " + idFoodCategory;
            DataTable dataTable = DataProvider.ExecuteQuery(query);

            foreach(DataRow row in dataTable.Rows)
            {
                Food food = new Food(row);
                foodList.Add(food);
            }

            return foodList;
        }

        public void AddFood(int foodID, int count, int tableID)
        {
            string query = "USP_AddFood";
            DataProvider.ExecuteQuery(query, new object[] { foodID, count, tableID });
        }
    }
}
