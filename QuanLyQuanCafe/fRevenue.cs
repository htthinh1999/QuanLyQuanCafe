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
using QuanLyQuanCafe.DAL;

namespace QuanLyQuanCafe
{
    public partial class fRevenue : DevExpress.XtraEditors.XtraForm
    {
        public fRevenue()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            LoadDateTimePicker();
            gridControl.DataSource = DAL_Bill.Instance.GetListBillCheckedOutByDate(dtpkFromDate.DateTime, dtpkToDate.DateTime);
        }

        void LoadDateTimePicker()
        {
            dtpkFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpkToDate.EditValue = dtpkFromDate.DateTime.AddMonths(1).AddDays(-1);
        }

        private void fRevenue_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = DAL_Bill.Instance.GetListBillCheckedOutByDate(dtpkFromDate.DateTime, dtpkToDate.DateTime);
        }
    }
}