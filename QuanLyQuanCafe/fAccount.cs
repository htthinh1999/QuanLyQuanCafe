using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.Design;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccount : DevExpress.XtraEditors.XtraForm
    {
        Account account;
        BindingSource bindingSource = new BindingSource();

        public fAccount()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            PreloadRadioButtons();
            LoadAccountTypeList();
            LoadData();
            BindingData();
        }

        void PreloadRadioButtons()
        {
            RadioGroupItem rdoMale = new RadioGroupItem("Nam", "Nam");  // value: giá trị của radio button - description: tên hiển thị của radio button
            RadioGroupItem rdoFemale = new RadioGroupItem("Nữ", "Nữ");
            rdgSex.Properties.Items.Add(rdoMale);
            rdgSex.Properties.Items.Add(rdoFemale);
        }

        void LoadAccountTypeList()
        {
            cbxType.DataSource = DAL_AccountType.Instance.LoadAcountTypeList();
            cbxType.DisplayMember = "name";
        }

        void LoadData()
        {
            gridControl.DataSource = bindingSource;
            bindingSource.DataSource = DAL_Account.Instance.GetAccountList();
        }

        void BindingData()
        {
            txtUsername.DataBindings.Add(new Binding("Text", bindingSource, "Tên tài khoản", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", bindingSource, "Tên hiển thị", true, DataSourceUpdateMode.Never));
            cbxType.DataBindings.Add(new Binding("Text", bindingSource, "Loại tài khoản", true, DataSourceUpdateMode.Never));
            rdgSex.DataBindings.Add(new Binding("EditValue", bindingSource, "Giới tính", true, DataSourceUpdateMode.Never));
            dtpkBirthday.DataBindings.Add(new Binding("DateTime", bindingSource, "Ngày sinh", true, DataSourceUpdateMode.Never));
            txtAddress.DataBindings.Add(new Binding("Text", bindingSource, "Địa chỉ", true, DataSourceUpdateMode.Never));
        }

        public void SetAccount(Account acc)
        {
            account = acc;
        }

        #region Events

        private void fAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!DAL_Account.Instance.ExistAccount(txtUsername.Text))
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn thêm tài khoản này?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL_Account.Instance.AddAccount(txtUsername.Text, txtDisplayName.Text, (cbxType.SelectedItem as AccountType).ID, rdgSex.EditValue.ToString(), dtpkBirthday.DateTime, txtAddress.Text);
                    XtraMessageBox.Show("Thêm tài khoản thành công!\nMật khẩu mặc định của tài khoản là 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            else
            {
                XtraMessageBox.Show("Tên tài khoản bạn chọn đã có người sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DAL_Account.Instance.ExistAccount(txtUsername.Text))
            {
                if (XtraMessageBox.Show("Bạn có muốn sửa thông tin tài khoản " + txtUsername.Text + "?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL_Account.Instance.UpdateAccountInfo(txtUsername.Text, txtDisplayName.Text, (cbxType.SelectedItem as AccountType).ID, rdgSex.EditValue.ToString(), dtpkBirthday.DateTime, txtAddress.Text);
                    XtraMessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có tài khoản nào có tên là " + txtUsername.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DAL_Account.Instance.ExistAccount(txtUsername.Text))
            {
                if (!txtUsername.Text.Equals(account.Username))
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa tài khoản " + txtUsername.Text + "?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DAL_Account.Instance.DeleteAccount(txtUsername.Text);
                        XtraMessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn không thể xóa chính bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("Không có tài khoản nào có tên là " + txtUsername.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (DAL_Account.Instance.ExistAccount(txtUsername.Text))
            {
                if (XtraMessageBox.Show("Bạn có muốn đặt lại mật khẩu cho tài khoản " + txtUsername.Text + "?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL_Account.Instance.ResetPassword(txtUsername.Text);
                    XtraMessageBox.Show("Đặt lại mật khẩu thành công!\nMật khẩu hiện tại là 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("Không có tài khoản nào có tên là " + txtUsername.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}