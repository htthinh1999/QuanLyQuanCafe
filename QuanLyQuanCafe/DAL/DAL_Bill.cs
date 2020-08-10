using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;

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

            foreach (Bill row in dataTable.Rows)
            {
                billList.Add(row);
            }

            return billList;
        }

        public void CheckOutForTable(int tableID, float totalPrice, int discount)
        {
            string query = "USP_CheckOutTable";
            DataProvider.ExecuteQuery(query, new object[] { tableID, totalPrice, discount });
        }

        public DataTable GetListBillCheckedOutByDate(DateTime fromDate, DateTime toDate)
        {
            string query = "USP_GetListBillByDate";
            return DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate });
        }

        public DataTable GetListBillCheckedOutByDateAndPage(DateTime fromDate, DateTime toDate, int page, int rowsPerPage)
        {
            string query = "USP_GetListBillByDateAndPage";
            return DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate, page, rowsPerPage });
        }

        public int GetMaxPageOfListBillCheckedOutByDate(DateTime fromDate, DateTime toDate, int rowsPerPage)
        {
            string query = "SELECT COUNT(*) FROM dbo.Bill INNER JOIN dbo.TableFood ON TableFood.id = Bill.idTable "
                            + "WHERE Bill.status = N'Đã thanh toán' AND timeOut >= '" + fromDate + "' AND timeOut <= '" + toDate.AddDays(1) + "'";
            int maxRows = (int)DataProvider.ExecuteQuery(query).Rows[0][0];
            return (maxRows / rowsPerPage) + ((maxRows % rowsPerPage == 0) ? 0 : 1);
        }

    }
}
