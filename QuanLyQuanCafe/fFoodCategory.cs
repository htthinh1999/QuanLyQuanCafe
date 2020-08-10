using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fFoodCategory : DevExpress.XtraEditors.XtraForm
    {
        public fFoodCategory()
        {
            InitializeComponent();
        }

        private void fFoodCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}