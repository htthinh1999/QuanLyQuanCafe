using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public int ID { get; private set; }
        public int IDTable { get; private set; }
        public float TotalPrice { get; private set; }
        public int Discount { get; private set; }
        public DateTime? TimeIn { get; private set; }
        public DateTime? TimeOut { get; private set; }
        public string Status { get; private set; }

        public Bill() { }

        public Bill(int id, int idTable, float totalPrice, int discount, DateTime? timeIn, DateTime? timeOut, string status)
        {
            ID = id;
            IDTable = idTable;
            TotalPrice = totalPrice;
            Discount = discount;
            TimeIn = timeIn;
            TimeOut = timeOut;
            Status = status;
        }

        public Bill(DataRow row)
        {
            ID = (int)row["id"];
            IDTable = (int)row["idTable"];
            TotalPrice = (int)row["totalPrice"];
            Discount = (int)row["discount"];
            TimeIn = (DateTime)row["timeIn"];
            if (row["timeOut"] != null)
            {
                TimeOut = (DateTime)row["timeOut"];
            }
            Status = row["status"].ToString();
        }

    }
}
