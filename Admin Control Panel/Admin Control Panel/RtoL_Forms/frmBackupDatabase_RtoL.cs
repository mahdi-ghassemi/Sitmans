using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmBackupDatabase_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _currentPath;
        private string _fileName;
        private bool sqlError;
     

        public frmBackupDatabase_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            sqlError = false;
            InitializeComponent();
        }

        private void frmBackupDatabase_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            ShowWarning(); 
        }

        private void ShowWarning()
        {
            LogicLayer lg2 = new LogicLayer();
            string message = lg2.GetMessageFromDll(_langCode, "BackupWarning");
            frmShowInfo_RtoL frmshow = new frmShowInfo_RtoL(message, 2);
            frmshow.ShowDialog();
        }

        private void FillForm()
        {            
            LogicLayer lg1 = new LogicLayer();
            lblPath.Text = lg1.GetMessageFromDll(_langCode, "CurrentPath");
            this.Text = lg1.GetMessageFromDll(_langCode, "DatabaseBackup");
            btnBackup.Text = lg1.GetMessageFromDll(_langCode, "Backup");
            btnBrowse.Text = lg1.GetMessageFromDll(_langCode, "ChangePath");
            btnCancel.Text = lg1.GetMessageFromDll(_langCode, "btnCancel");

            _fileName = lg1.GetBackupFileName();
            _currentPath = Application.StartupPath;
            txbPath.Text = _currentPath + @"\Backups\" + _fileName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.AutoUpgradeEnabled = false;
            sav.DefaultExt = "BAK";
            sav.FileName = _fileName;
            sav.Filter = @"SQL Backup files (*.BAK) |*.BAK|All files (*.*) |*.*";
            sav.OverwritePrompt = true;
            sav.Title = this.Text;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                txbPath.Text = sav.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {          

            this.prbBackup.Visible = true;
            prbBackup.Value1 = 0;
            prbBackup.Maximum = 100;
            prbBackup.Value1 = 25;
            prbBackup.Text = prbBackup.Value1.ToString() + "%";
            prbBackup.Update();
            SQLAccess sql = new SQLAccess();
            SqlConnection conn = new SqlConnection(Program.SqlConnectionString);
            BackupDatabase(conn, txbPath.Text.Trim());          
        }

        public void BackupDatabase(SqlConnection con,string backupFilename)
        {
            con.FireInfoMessageEventOnUserErrors = true;
            con.InfoMessage += OnInfoMessage;
            string command = @"BACKUP DATABASE ITC TO DISK='" + backupFilename + "'";
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.InfoMessage -= OnInfoMessage;
            con.FireInfoMessageEventOnUserErrors = false;
            sqlError = false;
        }

        private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (!sqlError)
            {
                foreach (SqlError info in e.Errors)
                {
                    if (info.Class > 10)
                    {
                        LogicLayer lg4 = new LogicLayer();
                        string mes3 = lg4.GetMessageFromDll(_langCode, "BackupFail");
                        frmShowInfoSmall_RtoL frmshs = new frmShowInfoSmall_RtoL(mes3, 2);
                        frmshs.ShowDialog();
                        prbBackup.Visible = false;
                        sqlError = true;
                        break;
                    }
                    else
                    {
                        prbBackup.Value1 += 25;
                        prbBackup.Text = prbBackup.Value1.ToString() + "%";
                        prbBackup.Update();
                        if (prbBackup.Value1 == 100)
                        {
                            LogicLayer lg3 = new LogicLayer();
                            string mes2 = lg3.GetMessageFromDll(_langCode, "BackupSuccess");
                            frmShowInfoSmall_RtoL frmshs = new frmShowInfoSmall_RtoL(mes2, 2);
                            frmshs.ShowDialog();
                            prbBackup.Visible = false;
                        }
                    }
                }
            }
        }

      

      
    }
}
