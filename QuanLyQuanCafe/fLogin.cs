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
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        void Login()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (DAL_Account.Instance.Login(username, password))
            {
                fMain frmMain = this.MdiParent as fMain;
                frmMain.LoggedIn();
                frmMain.ShowForm(frmMain.frmTableManager, typeof(fTableManager));
                Exit();
            }
            else
            {
                XtraMessageBox.Show("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu!\nMời bạn nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearAllInput();
            }
        }

        void ClearAllInput()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        void Exit()
        {
            ClearAllInput();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}