using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fLogin : XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        #region Methods

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

        #endregion

        #region Events

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

        #endregion
    }
}