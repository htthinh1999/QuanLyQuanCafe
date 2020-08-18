using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Data.Controls.ExpressionEditor;
using DevExpress.XtraReports.Parameters;

namespace QuanLyQuanCafe
{
    public partial class fReport : DevExpress.XtraReports.UI.XtraReport
    {
        public fReport()
        {
            InitializeComponent();
            Init();
        }

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

    }
}
