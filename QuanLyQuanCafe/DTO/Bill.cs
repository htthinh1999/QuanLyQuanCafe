using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public int ID { get; private set; }
        public int IDTable { get; private set; }
        public DateTime? TimeIn { get; private set; }
        public DateTime? TimeOut { get; private set; }
        public string Status { get; private set; }

        public Bill() { }

        public Bill(int id, int idTable, DateTime? timeIn, DateTime? timeOut, string status)
        {
            ID = id;
            IDTable = idTable;
            TimeIn = timeIn;
            TimeOut = timeOut;
            Status = status;
        }

        public Bill(DataRow row)
        {
            ID = (int)row["id"];
            IDTable = (int)row["idTable"];
            TimeIn = (DateTime)row["timeIn"];
            if(row["timeOut"] != null)
            {
                TimeOut = (DateTime)row["timeOut"];
            }
            Status = row["status"].ToString();
        }

    }
}
