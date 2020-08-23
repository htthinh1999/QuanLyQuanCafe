using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAL;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableFood : XtraForm
    {
        BindingSource bindingSource = new BindingSource();

        public fTableFood()
        {
            InitializeComponent();
            Init();
        }

        #region Methods

        void Init()
        {
            LoadData();
            DataBinding();
            LoadStatusList();
        }

        void LoadData()
        {
            gridControl.DataSource = bindingSource;
            bindingSource.DataSource = DAL_TableFood.Instance.LoadTableList();
            gridView.Columns["ID"].Caption = "Mã bàn";
            gridView.Columns["Name"].Caption = "Tên bàn";
            gridView.Columns["Status"].Caption = "Trạng thái";
        }

        void DataBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", bindingSource, "ID"));
            txtTableName.DataBindings.Add(new Binding("Text", bindingSource, "Name"));
            cbxStatus.DataBindings.Add(new Binding("Text", bindingSource, "Status"));
        }

        void LoadStatusList()
        {
            cbxStatus.DataSource = DAL_TableFood.Instance.LoadTableStatusList();
        }

        bool DataAvailable(bool mustExistTable)
        {
            if (txtTableName.Text.Equals(""))
            {
                XtraMessageBox.Show("Bạn chưa nhập tên bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (mustExistTable != DAL_TableFood.Instance.ExistTableFood(txtTableName.Text))
            {
                XtraMessageBox.Show(txtTableName.Text + ((mustExistTable) ? " không" : " đã") + " tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void fTableFood_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable(false) && XtraMessageBox.Show("Bạn có muốn thêm bàn " + txtTableName.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_TableFood.Instance.AddTableFood(txtTableName.Text);
                LoadData();
                XtraMessageBox.Show("Thêm bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable(true) && XtraMessageBox.Show("Bạn có muốn cập nhật thông tin bàn " + txtTableName.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_TableFood.Instance.UpdateTableFood(int.Parse(txtID.Text), txtTableName.Text);
                LoadData();
                XtraMessageBox.Show("Cập nhật thông tin bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataAvailable(true) && XtraMessageBox.Show("Bạn có muốn xóa bàn " + txtTableName.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAL_TableFood.Instance.DeleteTableFood(int.Parse(txtID.Text));
                LoadData();
                XtraMessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}