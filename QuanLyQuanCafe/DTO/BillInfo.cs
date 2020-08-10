using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public int ID { get; private set; }
        public int IDBill { get; private set; }
        public int IDFood { get; private set; }
        public int Count { get; private set; }

        public BillInfo() { }

        public BillInfo(int id, int idBill, int idFood, int count)
        {
            ID = id;
            IDBill = idBill;
            IDFood = idFood;
            Count = count;
        }
        public BillInfo(DataRow row)
        {
            ID = (int)row["id"];
            IDBill = (int)row["idBill"];
            IDFood = (int)row["idFood"];
            Count = (int)row["count"];
        }

    }
}
