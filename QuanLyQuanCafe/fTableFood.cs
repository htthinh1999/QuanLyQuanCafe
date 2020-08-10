using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableFood : DevExpress.XtraEditors.XtraForm
    {
        public fTableFood()
        {
            InitializeComponent();
        }

        private void fTableFood_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}