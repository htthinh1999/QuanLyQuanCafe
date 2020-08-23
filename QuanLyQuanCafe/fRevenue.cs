using DevExpress.XtraReports.UI;
using QuanLyQuanCafe.DAL;
using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fRevenue : DevExpress.XtraEditors.XtraForm
    {
        int currentPage = 1;
        int rowsPerPage = 10;
        int maxPage = 3;
        DateTime fromDate, toDate;

        public fRevenue()
        {
            InitializeComponent();
            Init();
        }

        #region Methods

        void Init()
        {
            LoadDateTimePickerAndMaxPage();
            MoveToPage(1);
            cbxRowsPerPage.SelectedIndex = 1;
        }

        void LoadDateTimePickerAndMaxPage()
        {
            dtpkFromDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpkToDate.EditValue = dtpkFromDate.DateTime.AddMonths(1).AddDays(-1);

            fromDate = dtpkFromDate.DateTime;
            toDate = dtpkToDate.DateTime;
            maxPage = DAL_Bill.Instance.GetMaxPageOfListBillCheckedOutByDate(fromDate, toDate, rowsPerPage);
        }

        void MoveToPage(int page)
        {
            currentPage = Math.Min(Math.Max(1, page), maxPage);
            txtPageNumber.Text = currentPage.ToString() + "/" + maxPage;
            gridControl.DataSource = DAL_Bill.Instance.GetListBillCheckedOutByDateAndPage(fromDate, toDate, currentPage, rowsPerPage);
        }

        #endregion

        #region Events

        private void fRevenue_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            //gridControl.DataSource = DAL_Bill.Instance.GetListBillCheckedOutByDate(dtpkFromDate.DateTime, dtpkToDate.DateTime);
            fromDate = dtpkFromDate.DateTime;
            toDate = dtpkToDate.DateTime;
            maxPage = DAL_Bill.Instance.GetMaxPageOfListBillCheckedOutByDate(fromDate, toDate, rowsPerPage);
            MoveToPage(1);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            MoveToPage(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            MoveToPage(currentPage - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveToPage(currentPage + 1);
        }

        private void cbxRowsPerPage_SelectedValueChanged(object sender, EventArgs e)
        {
            rowsPerPage = Convert.ToInt32((sender as ComboBox).Text);
            maxPage = DAL_Bill.Instance.GetMaxPageOfListBillCheckedOutByDate(fromDate, toDate, rowsPerPage);
            MoveToPage(1);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            fReport frmReport = new fReport();
            frmReport.Submit(fromDate, toDate);
            frmReport.ShowPreviewDialog();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            MoveToPage(maxPage);
        }

        #endregion
    }
}