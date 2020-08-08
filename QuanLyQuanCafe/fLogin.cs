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
using QuanLyQuanCafe.DTO;

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
                Account acc = DAL_Account.Instance.GetAccountInfoByUsername(username);
                fMain frmMain = this.MdiParent as fMain;
                frmMain.SetAccount(acc);
                frmMain.LoggedIn();
                frmMain.ShowForm(frmMain.frmTableManager, typeof(fTableManager));
                this.Close();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ClearAllInput();
            this.Hide();
        }
    }
}