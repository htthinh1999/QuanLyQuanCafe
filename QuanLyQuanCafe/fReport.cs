using DevExpress.XtraReports.UI;
using System;

namespace QuanLyQuanCafe
{
    public partial class fReport : XtraReport
    {
        public fReport()
        {
            InitializeComponent();
            Init();
        }

        #region Methods

        void Init()
        {
            fromDate.Description = "Từ ngày";
            toDate.Description = "Đến ngày";
            fromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            toDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
        }

        public void Submit(DateTime fromDate, DateTime toDate)
        {
            this.fromDate.Value = fromDate;
            this.toDate.Value = toDate;
            CreateDocument();
        }

        #endregion
    }
}
