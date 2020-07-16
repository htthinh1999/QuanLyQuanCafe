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

namespace QuanLyQuanCafe
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fLogin)))
            {
                fLogin frmLogin = new fLogin();
                frmLogin.MdiParent = this;
                frmLogin.Show();
            }
        }

        private void btnInformation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fAccountInfo)))
            {
                fAccountInfo frmAccountInfo = new fAccountInfo();
                frmAccountInfo.MdiParent = this;
                frmAccountInfo.Show();
            }
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fChangePassword)))
            {
                fChangePassword frmChangePassword = new fChangePassword();
                frmChangePassword.MdiParent = this;
                frmChangePassword.Show();
            }
        }

        bool CheckExist(Type fType)
        {
            foreach(Form form in this.MdiChildren)
            {
                if(form.GetType() == fType)
                {
                    form.Focus();
                    return true;
                }
            }
            return false;
        }

        private void btnRevenue_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fRevenue)))
            {
                fRevenue frmRevenue = new fRevenue();
                frmRevenue.MdiParent = this;
                frmRevenue.Show();
            }
        }

        private void btnFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fFood)))
            {
                fFood frmFood = new fFood();
                frmFood.MdiParent = this;
                frmFood.Show();
            }
        }

        private void btnFoodCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fFoodCategory)))
            {
                fFoodCategory frmFoodCategory = new fFoodCategory();
                frmFoodCategory.MdiParent = this;
                frmFoodCategory.Show();
            }
        }

        private void btnTableFood_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fTableFood)))
            {
                fTableFood frmTableFood = new fTableFood();
                frmTableFood.MdiParent = this;
                frmTableFood.Show();
            }
        }

        private void btnAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fAccount)))
            {
                fAccount frmAccount = new fAccount();
                frmAccount.MdiParent = this;
                frmAccount.Show();
            }
        }

        private void btnTableManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExist(typeof(fTableManager)))
            {
                fTableManager frmTableManager = new fTableManager();
                frmTableManager.MdiParent = this;
                frmTableManager.Show();
            }
        }
    }
}