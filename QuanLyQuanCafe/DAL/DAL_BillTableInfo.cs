using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAL
{
    public class DAL_BillTableInfo
    {
        static DAL_BillTableInfo instance;
        public static DAL_BillTableInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_BillTableInfo();
                }
                return instance;
            }
            private set { instance = value; }
        }

        public DAL_BillTableInfo() { }

        public List<BillTableInfo> GetBillTableInfoByTableID(int idTable)
        {
            List<BillTableInfo> billTableInfoList = new List<BillTableInfo>();

            string query = "USP_GetBillByTableID";
            DataTable dataTable = DataProvider.ExecuteQuery(query, new object[] { idTable });
            foreach (DataRow row in dataTable.Rows)
            {
                BillTableInfo billTableInfo = new BillTableInfo(row);
                billTableInfoList.Add(billTableInfo);
            }

            return billTableInfoList;
        }
    }
}
