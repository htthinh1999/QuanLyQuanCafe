using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccountInfo : XtraForm
    {
        Account account;

        public fAccountInfo()
        {
            InitializeComponent();
        }

        #region Methods

        public void SetAccount(Account acc)
        {
            account = acc;
            LoadAccountInfo();
        }

        void LoadAccountInfo()
        {
            txtUsername.Text = account.Username;
            txtDisplayName.Text = account.DisplayName;
            txtSex.Text = account.Sex;
            dtpkBirthday.DateTime = account.Birthday;
            txtAddress.Text = account.Address;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (!(this.MdiParent as fMain).LoggingOut && DataEntering() && XtraMessageBox.Show("Các dữ liệu bạn đang nhập sẽ không được hoàn tác!\nBạn có chắc chắn muốn thoát?",
                                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            ControlsEditable(false);
            LoadAccountInfo();
            this.Hide();
        }

        bool DataEntering()
        {
            foreach (PanelControl panel in this.Controls.OfType<PanelControl>())
            {
                foreach (TextEdit textEdit in panel.Controls.OfType<TextEdit>())
                {
                    if (!textEdit.ReadOnly && textEdit.Text.Length != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        void ControlsEditable(bool allow)
        {
            btnUpdate.Text = allow ? "Cập nhật" : "Thay đổi";
            foreach (PanelControl panel in this.Controls.OfType<PanelControl>())
            {
                foreach (TextEdit textEdit in panel.Controls.OfType<TextEdit>())
                {
                    textEdit.ReadOnly = !allow;
                }
            }
            txtUsername.ReadOnly = true;
            txtSex.Visible = !allow;
            rdoMale.Visible = allow;
            rdoFemale.Visible = allow;
        }

        #endregion

        #region Events

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text.Equals("Thay đổi"))
            {
                ControlsEditable(true);
            }
            else
            {
                if (!txtDisplayName.Text.Equals("") && !txtAddress.Text.Equals(""))
                {
                    if (XtraMessageBox.Show("Bạn có muốn cập nhật thông tin tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAL_Account.Instance.UpdateAccountInfo(txtUsername.Text, txtDisplayName.Text, account.TypeID, rdoMale.Checked ? "Nam" : "Nữ", dtpkBirthday.DateTime, txtAddress.Text);
                        ControlsEditable(false);
                        account = DAL_Account.Instance.GetAccountInfoByUsername(txtUsername.Text);
                        LoadAccountInfo();

                        XtraMessageBox.Show("Thay đổi thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn cần nhập đầy đủ thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        #endregion
    }
}