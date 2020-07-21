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
        public fTableManager()
        {
            InitializeComponent();

            LoadFoodCategoryList();
            LoadTableList();
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

        void LoadTableList()
        {
            flowLayoutPanel.Controls.Clear();
            List<TableFood> tableList = DAL_TableFood.Instance.LoadTableFoodList();
            foreach(TableFood tableFood in tableList)
            {
                SimpleButton btnTable = new SimpleButton() { Width = tableFood.Width, Height = tableFood.Height };
                btnTable.Tag = tableFood.ID;
                btnTable.Click += LoadBillByTableID;
                btnTable.Text = tableFood.Name + "\n" + tableFood.Status;
                btnTable.Appearance.BackColor = Color.LightGray;
                if (tableFood.Status.Equals("Trống"))
                {
                    btnTable.Appearance.BackColor = Color.LightGreen;
                }
                flowLayoutPanel.AddControl(btnTable);
            }
        }

        void GetBillByTableID(int idTable)
        {
            float totalPrice = 0;
            List<BillTableInfo> billTableInfoList = DAL_BillTableInfo.Instance.GetBillTableInfoByTableID(idTable);
            lvBill.Items.Clear();
            foreach(BillTableInfo item in billTableInfoList)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                lvBill.Items.Add(listViewItem);

                totalPrice += item.TotalPrice;
            }

            // Show bill total price
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            ListViewItem lvTotalPriceItem = new ListViewItem("Tổng hóa đơn: " + totalPrice.ToString("c", cultureInfo));
            lvBill.Items.Add(lvTotalPriceItem);
        }

        void AddFood()
        {
            int foodID = (cbxFood.SelectedItem as Food).ID;
            int count = (int)nmrCount.Value;
            int tableID = (int)lvBill.Tag;
            DAL_Food.Instance.AddFood(foodID, count, tableID);
            nmrCount.Value = 1;
        }

        void LoadBillByTableID(object sender, EventArgs e)
        {
            int tableID = (int)(sender as SimpleButton).Tag;
            GetBillByTableID(tableID);
            lvBill.Tag = tableID;
        }

        void CheckOutForTable(int tableID)
        {
            DAL_Bill.Instance.CheckOutForTable(tableID);
            GetBillByTableID(tableID);
        }

        private void cbxFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int foodCategoryID = ((sender as System.Windows.Forms.ComboBox).SelectedItem as FoodCategory).ID;
            LoadFoodList(foodCategoryID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddFood();
            int tableID = (int)lvBill.Tag;
            GetBillByTableID(tableID);
            LoadTableList();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int tableID = (int)lvBill.Tag;
            CheckOutForTable(tableID);
            LoadTableList();
        }
    }
}