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
            string query = "USP_GetBillUnCheckOutByTableID";
            DataTable dataTable = DataProvider.ExecuteQuery(query, new object[] { idTable });

            foreach (Bill row in dataTable.Rows)
            {
                billList.Add(row);
            }

            return billList;
        }

        public void CheckoutTable(int tableID, float totalPrice, int discount)
        {
            string query = "USP_CheckoutTable";
            DataProvider.ExecuteQuery(query, new object[] { tableID, totalPrice, discount });
        }

        //public DataTable GetListBillCheckedOutByDate(DateTime fromDate, DateTime toDate)
        //{
        //    string query = "USP_GetListBillCheckedOutByDate";
        //    return DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate });
        //}

        public DataTable GetListBillCheckedOutByDateAndPage(DateTime fromDate, DateTime toDate, int page, int rowsPerPage)
        {
            string query = "USP_GetListBillCheckedOutByDateAndPage";
            return DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate, page, rowsPerPage });
        }

        public int GetMaxPageOfListBillCheckedOutByDate(DateTime fromDate, DateTime toDate, int rowsPerPage)
        {
            string query = "USP_GetMaxPageOfListBillCheckedOutByDate";
            int maxRows = (int)DataProvider.ExecuteQuery(query, new object[] { fromDate, toDate }).Rows[0][0];
            return (maxRows / rowsPerPage) + ((maxRows % rowsPerPage == 0) ? 0 : 1);
        }

    }
}