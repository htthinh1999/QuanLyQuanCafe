using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    class DAL_TableFood
    {
        static DAL_TableFood instance;
        public static DAL_TableFood Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_TableFood();
                }
                return instance;
            }
        }

        public DAL_TableFood() { }

        public List<TableFood> LoadTableFoodList()
        {
            List<TableFood> listTableFood = new List<TableFood>();

            string query = "USP_LoadTableFoodList";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                TableFood tableFood = new TableFood(row);
                listTableFood.Add(tableFood);
            }

            return listTableFood;
        }
    }
}
