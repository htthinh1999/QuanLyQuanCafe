using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccount : DevExpress.XtraEditors.XtraForm
    {
        public fAccount()
        {
            InitializeComponent();
        }

        private void fAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}