using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class fRestore : SplashScreen
    {
        public fRestore()
        {
            InitializeComponent();
        }

        public fRestore(string filePath)
        {
            InitializeComponent();
            RestoreData(filePath);
        }

        #region Methods

        void RestoreData(string filePath)
        {
            labelStatus.Text = "Đang khôi phục dữ liệu...";
            progressBarControl.EditValue = 0;
            try
            {
                Server server = new Server(new ServerConnection(DataProvider.ServerName));
                Restore dbRestore = new Restore() { Action = RestoreActionType.Database, Database = DataProvider.DatabaseName, ReplaceDatabase = true, NoRecovery = false };
                dbRestore.Devices.AddDevice(filePath, DeviceType.File);
                dbRestore.PercentComplete += RestorePercenComplete;
                dbRestore.Complete += RestoreComplete;

                Database database = new Database(server, DataProvider.DatabaseName);
                database.Refresh();
                server.KillAllProcesses(DataProvider.DatabaseName);
                database.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                database.Alter(TerminationClause.RollbackTransactionsImmediately);

                dbRestore.SqlRestoreAsync(server);

                database.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Khôi phục dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void RestorePercenComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBarControl.Invoke((MethodInvoker)delegate
            {
                progressBarControl.EditValue = e.Percent;
                progressBarControl.Update();
            });
        }

        private void RestoreComplete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = "Hoàn tất khôi phục";
                    XtraMessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UseWaitCursor = false;
                    this.Close();
                });
            }
            else
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = "Khôi phục lỗi";
                    XtraMessageBox.Show("Khôi phục dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UseWaitCursor = false;
                    this.Close();
                });
            }
        }

        #endregion
    }
}