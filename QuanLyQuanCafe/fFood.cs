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
            cbxCategoryName.DataBindings.Add(new Binding("Text", bindingSource, "Danh mục", true, DataSourceUpdateMode.Never));
            nrPrice.DataBindings.Add(new Binding("Value", bindingSource, "Giá tiền", true, DataSourceUpdateMode.Never));
        }

        bool DataAvailable(bool mustExistFood)
        {
            if (txtFoodName.Text.Equals(""))
            {
                XtraMessageBox.Show("Bạn cần phải nhập tên món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFoodName.Focus();
                return false;
            }

            if (nrPrice.Value == 0)
            {
                XtraMessageBox.Show("Bạn cần phải nhập giá món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nrPrice.Focus();
                return false;
            }

            if(mustExistFood != DAL_Food.Instance.ExistFood(txtFoodName.Text))
            {
                XtraMessageBox.Show("Món " + txtFoodName.Text + ((mustExistFood) ? " không" : " đã") + " tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
            if (DataAvailable(false) && XtraMessageBox.Show("Bạn có muốn thêm món " + txtFoodName.Text + " vào danh sách món?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.AddFood(txtFoodName.Text, (cbxCategoryName.SelectedValue as FoodCategory).ID, (float)nrPrice.Value);
                LoadData();
                XtraMessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable(true) && XtraMessageBox.Show("Bạn có muốn sửa thông tin món " + txtFoodName.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.UpdateFood(int.Parse(txtID.Text), txtFoodName.Text, (cbxCategoryName.SelectedValue as FoodCategory).ID, (float)nrPrice.Value);
                LoadData();
                XtraMessageBox.Show("Cập nhật thông tin món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable(true) && XtraMessageBox.Show("Bạn có muốn xóa món " + txtFoodName.Text + " khỏi danh sách món?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_Food.Instance.DeleteFood(int.Parse(txtID.Text));
                LoadData();
                XtraMessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            bindingSource.DataSource = DAL_Food.Instance.SearchFood(txtSearch.Text);
        }

        #endregion

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadData();
        }
    }
}