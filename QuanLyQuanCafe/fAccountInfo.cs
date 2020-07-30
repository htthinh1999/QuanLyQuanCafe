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

namespace QuanLyQuanCafe
{
    public partial class fAccountInfo : DevExpress.XtraEditors.XtraForm
    {
        public fAccountInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (DataEntering() && XtraMessageBox.Show("Các dữ liệu bạn đang nhập sẽ không được hoàn tác!\nBạn có chắc chắn muốn thoát?",
                                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            LoadData();
            this.Hide();
        }

        void LoadData()
        {

        }

        bool DataEntering()
        {
            foreach (PanelControl panel in this.Controls.OfType<PanelControl>())
            {
                foreach (TextEdit textEdit in panel.Controls.OfType<TextEdit>())
                {
                    if (textEdit.Text.Length != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}