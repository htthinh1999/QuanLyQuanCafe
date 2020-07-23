using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.DAL;
using DevExpress.Utils.Extensions;
using System.Globalization;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<int, SimpleButton> btnTable = new Dictionary<int, SimpleButton>();
        int tableIDChosen = 1;
        float totalPriceOfTableChosen = 0;

        public fTableManager()
        {
            InitializeComponent();

            LoadFoodCategoryList();
            LoadTableList();
            GetBillByTableID(tableIDChosen);
        }

        void LoadFoodCategoryList()
        {
            List<FoodCategory> foodCategoryList = DAL_FoodCategory.Instance.LoadFoodCategoryList();
            cbxFoodCategory.DataSource = foodCategoryList;
            cbxFoodCategory.DisplayMember = "Name";
        }

        void LoadFoodList(int idFoodCategory)
        {
            List<Food> foodList = DAL_Food.Instance.LoadFoodList(idFoodCategory);
            cbxFood.DataSource = foodList;
            cbxFood.DisplayMember = "Name";
        }

        void UpdateTableStatus(SimpleButton btnTableFood, string name, string status)
        {
            btnTableFood.Text = name + "\n" + status;
            btnTableFood.Appearance.BackColor = Color.LightGray;
            if (status.Equals("Trống"))
            {
                btnTableFood.Appearance.BackColor = Color.LightGreen;
            }
        }

        void LoadTableStatus(int idTable)
        {
            TableFood table = DAL_TableFood.Instance.LoadTableStatus(idTable);
            UpdateTableStatus(btnTable[idTable], table.Name, table.Status);
        }

        void LoadTableList()
        {
            List<TableFood> tableList = DAL_TableFood.Instance.LoadTableList();
            foreach(TableFood tableFood in tableList)
            {
                SimpleButton btnTableFood = new SimpleButton() { Width = tableFood.Width, Height = tableFood.Height };
                btnTableFood.Tag = tableFood.ID;
                btnTableFood.Click += LoadBillByTableID;
                UpdateTableStatus(btnTableFood, tableFood.Name, tableFood.Status);

                flowLayoutPanel.AddControl(btnTableFood);
                btnTable.Add(tableFood.ID, btnTableFood);
            }
            cbxTableList.DataSource = tableList;
            cbxTableList.DisplayMember = "Name";
        }

        void GetBillByTableID(int idTable)
        {
            totalPriceOfTableChosen = 0;
            List<BillTableInfo> billTableInfoList = DAL_BillTableInfo.Instance.GetBillTableInfoByTableID(idTable);
            lvBill.Items.Clear();
            foreach(BillTableInfo item in billTableInfoList)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                lvBill.Items.Add(listViewItem);

                totalPriceOfTableChosen += item.TotalPrice;
            }

            // Show bill total price
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            ListViewItem lvTotalPriceItem = new ListViewItem("Tổng tiền bàn số " + idTable + ":");
            lvTotalPriceItem.SubItems.Add("");
            lvTotalPriceItem.SubItems.Add("");
            lvTotalPriceItem.SubItems.Add(totalPriceOfTableChosen.ToString("c", cultureInfo));
            lvTotalPriceItem.Font = new Font(lvTotalPriceItem.Font, FontStyle.Bold);
            lvBill.Items.Add(lvTotalPriceItem);
        }

        void LoadBillByTableID(object sender, EventArgs e)
        {
            int tableID = (int)(sender as SimpleButton).Tag;
            GetBillByTableID(tableID);
            tableIDChosen = tableID;
        }

        private void cbxFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int foodCategoryID = ((sender as System.Windows.Forms.ComboBox).SelectedItem as FoodCategory).ID;
            LoadFoodList(foodCategoryID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int foodID = (cbxFood.SelectedItem as Food).ID;
            int count = (int)nmrCount.Value;

            DAL_Food.Instance.AddFood(foodID, count, tableIDChosen);
            nmrCount.Value = 1;

            GetBillByTableID(tableIDChosen);
            LoadTableStatus(tableIDChosen);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (btnTable[tableIDChosen].Text.Contains("Trống"))
            {
                XtraMessageBox.Show("Đây là bàn trống, bạn phải chọn bàn đã có người!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (XtraMessageBox.Show(string.Format("Bạn có muốn thanh toán cho bàn số " + tableIDChosen + "?\n"
                     + ((nmrDiscount.Value == 0) ? "Tổng tiền là " + totalPriceOfTableChosen.ToString("c", new CultureInfo("vi-VN")) + "!": "Tổng tiền sau khi được giảm giá " + nmrDiscount.Value + "% là " + (totalPriceOfTableChosen - (totalPriceOfTableChosen * (float)nmrDiscount.Value) / 100).ToString("c", new CultureInfo("vi-VN")) + "!")),
                     "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int discount = Convert.ToInt32(nmrDiscount.Value);
                DAL_Bill.Instance.CheckOutForTable(tableIDChosen, discount);
                GetBillByTableID(tableIDChosen);
                LoadTableStatus(tableIDChosen);
            }
        }

        private void btnMoveTable_Click(object sender, EventArgs e)
        {
            int secondTableID = (cbxTableList.SelectedItem as TableFood).ID;
            DAL_TableFood.Instance.MoveTable(tableIDChosen, secondTableID);
            LoadTableStatus(tableIDChosen);
            LoadTableStatus(secondTableID);
        }
    }
}