using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using System.Linq.Expressions;

namespace QuanLyQuanCafe
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region All forms except main form
        
        public fLogin frmLogin;
        public fAccount frmAccount;
        public fAccountInfo frmAccountInfo;
        public fChangePassword frmChangePassword;
        public fFood frmFood;
        public fFoodCategory frmFoodCategory;
        public fRevenue frmRevenue;
        public fTableFood frmTableFood;
        public fTableManager frmTableManager;
        
        #endregion

        public fMain()
        {
            InitializeComponent();

            PreLoadAllForms();
            ShowForm(frmLogin, typeof(fLogin));
        }

        #region Methods

        void PreLoadAllForms()
        {
            frmLogin = new fLogin();
            frmAccount = new fAccount();
            frmAccountInfo = new fAccountInfo();
            frmChangePassword = new fChangePassword();
            frmFood = new fFood();
            frmFoodCategory = new fFoodCategory();
            frmRevenue = new fRevenue();
            frmTableFood = new fTableFood();
            frmTableManager = new fTableManager();
        }

        bool CheckExist(Type fType)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == fType)
                {
                    form.Focus();
                    return true;
                }
            }
            return false;
        }

        public void ShowForm(Form form, Type formType)
        {
            if (!CheckExist(formType))
            {
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                form.Focus();
            }

        }

        public void LoggedIn()
        {
            foreach (BarButtonItem btn in Ribbon.Items.OfType<BarButtonItem>())
            {
                btn.Enabled = true;
            }
            btnLogin.Enabled = false;
        }

        public void LogOut()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Hide();
            }
            foreach (BarButtonItem btn in Ribbon.Items.OfType<BarButtonItem>())
            {
                btn.Enabled = false;
            }
            btnLogin.Enabled = true;
            skinRibbonGalleryBarItem1.Enabled = true;
            btnTutorial.Enabled = true;
            btnContact.Enabled = true;
            btnSoftwareInfo.Enabled = true;
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

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            LogOut();
        }
        #endregion

    }
}