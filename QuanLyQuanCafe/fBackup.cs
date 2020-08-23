using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using QuanLyQuanCafe.DAL;

namespace QuanLyQuanCafe
{
    public partial class fBackup : SplashScreen
    {
        public fBackup()
        {
            InitializeComponent();
        }

        public fBackup(string filePath)
        {
            InitializeComponent();
            BackupData(filePath);
        }

        #region Methods

        void BackupData(string filePath)
        {
            labelStatus.Text = "Đang sao lưu dữ liệu...";
            progressBarControl.EditValue = 0;
            
            try
            {
                Server server = new Server(new ServerConnection(DataProvider.ServerName));
                Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = DataProvider.DatabaseName };
                dbBackup.Devices.AddDevice(filePath, DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.PercentComplete += BackupPercentComplete;
                dbBackup.Complete += BackupComplete;
                dbBackup.SqlBackupAsync(server);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sao lưu dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void BackupPercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl.Invoke((MethodInvoker)delegate
            {
                progressBarControl.EditValue = e.Percent;
                progressBarControl.Update();
            });
        }

        void BackupComplete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = "Hoàn tất sao lưu";
                    XtraMessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UseWaitCursor = false;
                    this.Close();
                });
            }
            else
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = "Sao lưu lỗi";
                    XtraMessageBox.Show("Sao lưu dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UseWaitCursor = false;
                    this.Close();
                });
            }
        }

        #endregion
    }
}