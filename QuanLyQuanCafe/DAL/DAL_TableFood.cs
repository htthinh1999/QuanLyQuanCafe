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

        public bool ExistTableFood(string tableName)
        {
            string query = "USP_ExistTableFood";
            return DataProvider.ExecuteQuery(query, new object[] { tableName }).Rows.Count > 0;
        }

        public TableFood LoadTableStatusByID(int tableID)
        {
            string query = "USP_LoadTableStatusByID";
            DataTable data = DataProvider.ExecuteQuery(query, new object[] { tableID });
            return new TableFood(data.Rows[0]);
        }

        public List<string> LoadTableStatusList()
        {
            string query = "USP_LoadTableStatusList";
            DataTable dataTable = DataProvider.ExecuteQuery(query);
            List<string> statusList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                statusList.Add(row["status"].ToString());
            }
            return statusList;
        }

        public void MoveTable(int firstTableID, int secondTableID)
        {
            string query = "USP_MoveTable";
            DataProvider.ExecuteQuery(query, new object[] { firstTableID, secondTableID });
        }

        public void AddTableFood(string tableName)
        {
            string query = "USP_AddTableFood";
            DataProvider.ExecuteQuery(query, new object[] { tableName });
        }

        public void UpdateTableFood(int id, string tableName)
        {
            string query = "USP_UpdateTableFood";
            DataProvider.ExecuteQuery(query, new object[] { id, tableName });
        }

        public void DeleteTableFood(int id)
        {
            string query = "USP_DeleteTableFood";
            DataProvider.ExecuteQuery(query, new object[] { id });
        }
    }
}
