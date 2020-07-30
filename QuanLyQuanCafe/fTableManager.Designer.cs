namespace QuanLyQuanCafe
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.cbxTableList = new System.Windows.Forms.ComboBox();
            this.nmrDiscount = new System.Windows.Forms.NumericUpDown();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nmrCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new DevExpress.XtraEditors.SimpleButton();
            this.cbxFoodCategory = new System.Windows.Forms.ComboBox();
            this.cbxFood = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveTable = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.s = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.cbxTableList);
            this.layoutControl2.Controls.Add(this.nmrDiscount);
            this.layoutControl2.Controls.Add(this.lvBill);
            this.layoutControl2.Controls.Add(this.nmrCount);
            this.layoutControl2.Controls.Add(this.btnAddFood);
            this.layoutControl2.Controls.Add(this.cbxFoodCategory);
            this.layoutControl2.Controls.Add(this.cbxFood);
            this.layoutControl2.Controls.Add(this.btnCheckOut);
            this.layoutControl2.Controls.Add(this.btnMoveTable);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.layoutControl2.Location = new System.Drawing.Point(429, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, 294, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(445, 555);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // cbxTableList
            // 
            this.cbxTableList.FormattingEnabled = true;
            this.cbxTableList.Location = new System.Drawing.Point(12, 496);
            this.cbxTableList.Name = "cbxTableList";
            this.cbxTableList.Size = new System.Drawing.Size(137, 21);
            this.cbxTableList.TabIndex = 12;
            // 
            // nmrDiscount
            // 
            this.nmrDiscount.Location = new System.Drawing.Point(153, 513);
            this.nmrDiscount.Name = "nmrDiscount";
            this.nmrDiscount.Size = new System.Drawing.Size(138, 21);
            this.nmrDiscount.TabIndex = 10;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(12, 62);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(421, 430);
            this.lvBill.TabIndex = 7;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // nmrCount
            // 
            this.nmrCount.Location = new System.Drawing.Point(371, 37);
            this.nmrCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmrCount.Name = "nmrCount";
            this.nmrCount.Size = new System.Drawing.Size(62, 21);
            this.nmrCount.TabIndex = 6;
            this.nmrCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddFood.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddFood.Appearance.Options.UseBackColor = true;
            this.btnAddFood.Appearance.Options.UseBorderColor = true;
            this.btnAddFood.Location = new System.Drawing.Point(237, 12);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(130, 46);
            this.btnAddFood.StyleController = this.layoutControl2;
            this.btnAddFood.TabIndex = 5;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbxFoodCategory
            // 
            this.cbxFoodCategory.FormattingEnabled = true;
            this.cbxFoodCategory.Location = new System.Drawing.Point(67, 12);
            this.cbxFoodCategory.Name = "cbxFoodCategory";
            this.cbxFoodCategory.Size = new System.Drawing.Size(166, 21);
            this.cbxFoodCategory.TabIndex = 4;
            this.cbxFoodCategory.SelectedIndexChanged += new System.EventHandler(this.cbxFoodCategory_SelectedIndexChanged);
            // 
            // cbxFood
            // 
            this.cbxFood.FormattingEnabled = true;
            this.cbxFood.Location = new System.Drawing.Point(67, 37);
            this.cbxFood.Name = "cbxFood";
            this.cbxFood.Size = new System.Drawing.Size(166, 21);
            this.cbxFood.TabIndex = 4;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckOut.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnCheckOut.Appearance.Options.UseBackColor = true;
            this.btnCheckOut.Appearance.Options.UseBorderColor = true;
            this.btnCheckOut.Location = new System.Drawing.Point(295, 496);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(138, 47);
            this.btnCheckOut.StyleController = this.layoutControl2;
            this.btnCheckOut.TabIndex = 8;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnMoveTable
            // 
            this.btnMoveTable.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMoveTable.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnMoveTable.Appearance.Options.UseBackColor = true;
            this.btnMoveTable.Appearance.Options.UseBorderColor = true;
            this.btnMoveTable.Location = new System.Drawing.Point(12, 521);
            this.btnMoveTable.Name = "btnMoveTable";
            this.btnMoveTable.Size = new System.Drawing.Size(137, 22);
            this.btnMoveTable.StyleController = this.layoutControl2;
            this.btnMoveTable.TabIndex = 11;
            this.btnMoveTable.Text = "Chuyển bàn";
            this.btnMoveTable.Click += new System.EventHandler(this.btnMoveTable_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.s,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem10,
            this.layoutControlItem8,
            this.simpleLabelItem1,
            this.layoutControlItem9});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(445, 555);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbxFoodCategory;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(225, 25);
            this.layoutControlItem1.Text = "Loại món";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // s
            // 
            this.s.Control = this.nmrCount;
            this.s.Location = new System.Drawing.Point(359, 0);
            this.s.MinSize = new System.Drawing.Size(46, 40);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(66, 50);
            this.s.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.s.Text = "Số lượng";
            this.s.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.s.TextLocation = DevExpress.Utils.Locations.Top;
            this.s.TextSize = new System.Drawing.Size(40, 20);
            this.s.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lvBill;
            this.layoutControlItem5.CustomizationFormText = "Hóa đơn";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(425, 434);
            this.layoutControlItem5.Text = "Hóa đơn";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbxFood;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem2.CustomizationFormText = "Tên món";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(225, 25);
            this.layoutControlItem2.Text = "Tên món";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAddFood;
            this.layoutControlItem3.CustomizationFormText = "Thêm món";
            this.layoutControlItem3.Location = new System.Drawing.Point(225, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(60, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(134, 50);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Thêm món";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCheckOut;
            this.layoutControlItem6.CustomizationFormText = "Thanh toán";
            this.layoutControlItem6.Location = new System.Drawing.Point(283, 484);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(142, 51);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Thanh toán";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cbxTableList;
            this.layoutControlItem10.CustomizationFormText = "Bàn số";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 484);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(79, 25);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(141, 25);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Bàn số";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.nmrDiscount;
            this.layoutControlItem8.CustomizationFormText = "(%)";
            this.layoutControlItem8.Location = new System.Drawing.Point(141, 501);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(59, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(142, 34);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "(%)";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.CustomizationFormText = "Giảm giá (%)";
            this.simpleLabelItem1.Location = new System.Drawing.Point(141, 484);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(142, 17);
            this.simpleLabelItem1.Text = "Giảm giá (%)";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnMoveTable;
            this.layoutControlItem9.CustomizationFormText = "Chuyển bàn";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 509);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(141, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Chuyển bàn";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(429, 555);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 555);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.layoutControl2);
            this.Name = "fTableManager";
            this.Text = "QUẢN LÝ DANH SÁCH BÀN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTableManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmrDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private System.Windows.Forms.ComboBox cbxFoodCategory;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnAddFood;
        private System.Windows.Forms.ComboBox cbxFood;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.NumericUpDown nmrCount;
        private DevExpress.XtraLayout.LayoutControlItem s;
        private System.Windows.Forms.NumericUpDown nmrDiscount;
        private DevExpress.XtraEditors.SimpleButton btnCheckOut;
        private DevExpress.XtraEditors.SimpleButton btnMoveTable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.ComboBox cbxTableList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ListView lvBill;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
    }
}