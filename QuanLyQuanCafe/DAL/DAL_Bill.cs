using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public class DAL_Bill
    {
        static DAL_Bill instance;
        public static DAL_Bill Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_Bill();
                }
                return instance;
            }
            private set { instance = value; }
        }

        public DAL_Bill() { }

        public List<Bill> GetBillUnCheckOutByTableID(int idTable)
        {
            List<Bill> billList = new List<Bill>();
            string query = "SELECT * FROM Bill WHERE status = N'Chưa thanh toán' AND idTable = " + idTable;
            DataTable dataTable = DataProvider.ExecuteQuery(query);

            foreach(Bill row in dataTable.Rows)
            {
                billList.Add(row);
            }

            return billList;
        }

        public void CheckOutForTable(int tableID, int discount)
        {
            string query = "USP_CheckOutTable";
            DataProvider.ExecuteQuery(query, new object[] { tableID, discount });
        }
    }
}
