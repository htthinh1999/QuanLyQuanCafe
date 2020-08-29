using QuanLyQuanCafe.DTO;
using System;
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

        public DataTable LoadFoodList()
        {
            string query = "USP_LoadFoodList";
            return DataProvider.ExecuteQuery(query);
        }

        public List<Food> LoadFoodListByCategoryID(int idFoodCategory)
        {
            List<Food> foodList = new List<Food>();

            string query = "USP_LoadFoodListByCategoryID";
            DataTable dataTable = DataProvider.ExecuteQuery(query, new object[] { idFoodCategory });

            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food(row);
                foodList.Add(food);
            }

            return foodList;
        }

        public bool ExistFood(string foodName)
        {
            string query = "USP_ExistFood";
            return DataProvider.ExecuteQuery(query, new object[] { foodName }).Rows.Count > 0;
        }

        public void AddFoodToTable(int foodID, int count, int tableID)
        {
            string query = "USP_AddFoodToTable";
            DataProvider.ExecuteQuery(query, new object[] { foodID, count, tableID });
        }

        public DataTable SearchFood(string text)
        {
            string query = "USP_SearchFood";
            return DataProvider.ExecuteQuery(query, new object[] { text });
        }

        public void AddFood(string foodName, int idCategory, float price)
        {
            string query = "USP_AddFodd";
            DataProvider.ExecuteQuery(query, new object[] { foodName, idCategory, price });
        }

        public void UpdateFood(int foodID, string foodName, int categoryID, float price, int stateID)
        {
            string query = "USP_UpdateFood";
            DataProvider.ExecuteQuery(query, new object[] { foodID, foodName, categoryID, price, stateID });
        }

        public void DeleteFood(int foodID)
        {
            string query = "USP_DeleteFood";
            DataProvider.ExecuteQuery(query, new object[] { foodID });
        }

        public bool FoodWasUsing(int foodID)
        {
            string query = "USP_FoodWasUsing";
            return DataProvider.ExecuteQuery(query, new object[] { foodID }).Rows.Count > 0;
        }
    }
}
