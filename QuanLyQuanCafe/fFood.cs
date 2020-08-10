using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fFood : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bindingSource = new BindingSource();

        public fFood()
        {
            InitializeComponent();
            Init();
        }

        #region Methods

        void Init()
        {
            LoadData();
            LoadCategoryList();
            DataBinding();
        }

        void LoadData()
        {
            gridControl.DataSource = bindingSource;
            bindingSource.DataSource = DAL_Food.Instance.LoadFoodList();
        }

        void LoadCategoryList()
        {
            cbxCategoryName.DataSource = DAL_FoodCategory.Instance.LoadFoodCategoryList();
            cbxCategoryName.DisplayMember = "Name";
        }

        void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", bindingSource, "ID", true, DataSourceUpdateMode.Never));
            txtFoodName.DataBindings.Add(new Binding("Text", bindingSource, "Tên món", true, DataSourceUpdateMode.Never));
            cbxCategoryName.DataBindings.Add(new Binding("Text", bindingSource, "Loại món", true, DataSourceUpdateMode.Never));
            nrPrice.DataBindings.Add(new Binding("Value", bindingSource, "Giá tiền", true, DataSourceUpdateMode.Never));
        }

        bool DataAvailable()
        {
            if (!txtFoodName.Text.Equals("") && !cbxCategoryName.Text.Equals("") && nrPrice.Value != 0)
            {
                if (cbxCategoryName.SelectedValue != null)
                {
                    return true;
                }
                else
                {
                    XtraMessageBox.Show("Bạn cần phải chọn đúng loại món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        #endregion

        #region Events

        private void fFood_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable() && XtraMessageBox.Show("Bạn có muốn thêm món này vào danh sách món?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.AddFood(txtFoodName.Text, (cbxCategoryName.SelectedValue as FoodCategory).ID, (float)nrPrice.Value);
                LoadData();
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable() && XtraMessageBox.Show("Bạn có muốn sửa thông tin món này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.UpdateFood(int.Parse(txtID.Text), txtFoodName.Text, (cbxCategoryName.SelectedValue as FoodCategory).ID, (float)nrPrice.Value);
                LoadData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa món này khỏi danh sách món?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.DeleteFood(int.Parse(txtID.Text));
                LoadData();
            }
        }

        #endregion
    }
}