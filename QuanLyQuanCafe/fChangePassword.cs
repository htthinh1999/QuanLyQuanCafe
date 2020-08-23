using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fChangePassword : XtraForm
    {
        Account account;

        public fChangePassword()
        {
            InitializeComponent();
        }

        #region Methods

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

        void ClearAllInput()
        {
            foreach (PanelControl panel in this.Controls.OfType<PanelControl>())
            {
                foreach (TextEdit textEdit in panel.Controls.OfType<TextEdit>())
                {
                    textEdit.Text = string.Empty;
                }
            }
        }

        public void SetAccount(Account acc)
        {
            account = acc;
        }

        #endregion

        #region Events

        private void fChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (!(this.MdiParent as fMain).LoggingOut && DataEntering() && XtraMessageBox.Show("Các dữ liệu bạn đang nhập sẽ không được hoàn tác!\nBạn có chắc chắn muốn thoát?",
                                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            ClearAllInput();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtPassword.Text.Equals("") && !txtNewPassword.Text.Equals("") && !txtReEnterPassword.Text.Equals(""))
            {
                if (DAL_Account.Instance.Login(account.Username, txtPassword.Text))
                {
                    if (!txtPassword.Text.Equals(txtNewPassword.Text))
                    {
                        if (txtNewPassword.Text.Equals(txtReEnterPassword.Text))
                        {
                            if (XtraMessageBox.Show("Bạn có chắc chắn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DAL_Account.Instance.UpdatePassword(account.Username, txtNewPassword.Text);
                                XtraMessageBox.Show("Đổi mật khẩu thành công!\nMời bạn đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearAllInput();
                                txtPassword.Focus();
                                (this.MdiParent as fMain).LogOut();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Mật khẩu nhập lại phải trùng khớp mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtReEnterPassword.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNewPassword.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn đã nhập sai mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (PanelControl panel in this.Controls.OfType<PanelControl>().OrderBy(panel => panel.TabIndex))
                {
                    foreach (TextEdit textEdit in panel.Controls.OfType<TextEdit>())
                    {
                        if (textEdit.Text.Equals(""))
                        {
                            textEdit.Focus();
                            return;
                        }
                    }
                }
            }
        }

        #endregion
    }
}