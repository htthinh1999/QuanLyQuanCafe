using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fMain : RibbonForm
    {
        #region All forms except main form

        fMain frmMain;
        public fLogin frmLogin;
        public fAccount frmAccount;
        public fAccountInfo frmAccountInfo;
        public fChangePassword frmChangePassword;
        public fFood frmFood;
        public fFoodCategory frmFoodCategory;
        public fRevenue frmRevenue;
        public fTableFood frmTableFood;
        public fTableManager frmTableManager;
        public fTutorial frmTutorial;
        public fSoftwareInfo frmSoftwareInfo;

        #endregion

        public bool LoggingOut { get; private set; } = false;

        Account account;

        public fMain()
        {
            InitializeComponent();

            PreLoadAllForms();
            ShowForm(frmLogin, typeof(fLogin));
        }

        #region Methods

        void PreLoadAllForms()
        {
            frmMain = this;
            frmLogin = new fLogin();
            frmAccount = new fAccount();
            frmAccountInfo = new fAccountInfo();
            frmChangePassword = new fChangePassword();
            frmFood = new fFood();
            frmFoodCategory = new fFoodCategory();
            frmRevenue = new fRevenue();
            frmTableFood = new fTableFood();
            frmTableManager = new fTableManager();
            frmTutorial = new fTutorial();
            frmSoftwareInfo = new fSoftwareInfo();
        }

        bool CheckExist(Type fType)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == fType)
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowForm(Form form, Type formType)
        {
            if (!CheckExist(formType))
            {
                form.MdiParent = frmMain;
            }
            form.Show();
            form.Activate();
        }

        public void LoggedIn()
        {
            LoggingOut = false;
            foreach (BarButtonItem btn in Ribbon.Items.OfType<BarButtonItem>())
            {
                btn.Enabled = true;
            }
            btnLogin.Enabled = false;
            if (account.TypeID != 1)   // account of staff
            {
                foreach (BarButtonItemLink btn in rbpgAdmin.ItemLinks)
                {
                    btn.Item.Enabled = false;
                }
                btnTableManager.Enabled = true;
            }
        }

        public void LogOut()
        {
            LoggingOut = true;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Visible)
                    form.Close();
            }
            foreach (BarButtonItem btn in Ribbon.Items.OfType<BarButtonItem>())
            {
                btn.Enabled = false;
            }
            foreach (BarButtonItemLink btn in rbpgHelp.ItemLinks)
            {
                btn.Item.Enabled = true;
            }
            btnSoftwareInfo.Enabled = true;
            btnLogin.Enabled = true;
            skinRibbonGalleryBarItem1.Enabled = true;
            ShowForm(frmLogin, typeof(fLogin));
        }

        public void SetAccount(Account acc)
        {
            account = acc;
            frmAccountInfo.SetAccount(acc);
            frmChangePassword.SetAccount(acc);
            frmAccount.SetAccount(acc);
        }

        #endregion

        #region Events

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmLogin, typeof(fLogin));
        }

        private void btnInformation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmAccountInfo, typeof(fAccountInfo));
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmChangePassword, typeof(fChangePassword));
        }

        private void btnRevenue_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmRevenue, typeof(fRevenue));
        }

        private void btnFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmFood, typeof(fFood));
        }

        private void btnFoodCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmFoodCategory, typeof(fFoodCategory));
        }

        private void btnTableFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmTableFood, typeof(fTableFood));
        }

        private void btnAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmAccount, typeof(fAccount));
        }

        private void btnTableManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmTableManager, typeof(fTableManager));
        }

        private void btnTutorial_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm(frmTutorial, typeof(fTutorial));
        }

        private void btnSoftwareInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSoftwareInfo.ShowDialog();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogOut();
            }
        }

        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog())
            {
                saveFileDialog.FileName = string.Format("backup_{0}.bak", DateTime.Now.ToString("ddMMyyy_hhmmss"));
                saveFileDialog.InitialDirectory = Application.StartupPath + "\\data\\backup";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new fBackup(saveFileDialog.FileName).ShowDialog();
                }
            }

        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (XtraOpenFileDialog openFileDialog = new XtraOpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath + "\\data\\backup";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new fRestore(openFileDialog.FileName).ShowDialog();
                    XtraMessageBox.Show("Chương trình sẽ tự khởi chạy lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (XtraMessageBox.Show("Bạn có muốn thoát phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        #endregion
    }
}