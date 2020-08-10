using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

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

        public TableFood LoadTableStatus(int tableID)
        {
            string query = "USP_LoadTableStatus";
            DataTable data = DataProvider.ExecuteQuery(query, new object[] { tableID });
            return new TableFood(data.Rows[0]);
        }

        public List<TableFood> LoadTableList()
        {
            List<TableFood> listTableFood = new List<TableFood>();

            string query = "USP_LoadTableList";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                TableFood tableFood = new TableFood(row);
                listTableFood.Add(tableFood);
            }

            return listTableFood;
        }

        public void MoveTable(int firstTableID, int secondTableID)
        {
            string query = "USP_MoveTable";
            DataProvider.ExecuteQuery(query, new object[] { firstTableID, secondTableID });
        }
    }
}
