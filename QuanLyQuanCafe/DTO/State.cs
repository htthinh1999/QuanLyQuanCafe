using System.Data;

namespace QuanLyQuanCafe.DTO
{
    class State
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public State() { }

        public State(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public State(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
        }
    }
}
