using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmRestoreDatabase_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _currentPath;
        private string _fileName;
        private bool sqlError;

        public frmRestoreDatabase_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            sqlError = false;
            InitializeComponent();
        }

        private void frmRestoreDatabase_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            ShowWarning(); 
            btnRestore.Enabled = false;
        }

        private void ShowWarning()
        {
            LogicLayer lg2 = new LogicLayer();
            string message = lg2.GetMessageFromDll(_langCode, "RestoreWarning");
            frmShowInfo_RtoL frmshow = new frmShowInfo_RtoL(message, 2);
            frmshow.ShowDialog();
        }

        private void FillForm()
        {
            LogicLayer lg1 = new LogicLayer();
            lblPath.Text = lg1.GetMessageFromDll(_langCode, "FilePath");
            this.Text = lg1.GetMessageFromDll(_langCode, "DatabaseRestore");
            btnRestore.Text = lg1.GetMessageFromDll(_langCode, "Restore");
            btnBrowse.Text = lg1.GetMessageFromDll(_langCode, "FileSelect");
            btnCancel.Text = lg1.GetMessageFromDll(_langCode, "btnCancel");

            grbSQL.HeaderText = lg1.GetMessageFromDll(_langCode, "tbiSql");
            lblPassword.Text = lg1.GetMessageFromDll(_langCode, "lblSqlPassword");
            lblUsername.Text = lg1.GetMessageFromDll(_langCode, "lblSqlUsername");
                      
            txbPath.Text = "";
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txbPath.Text != "")
            {
                Restore res = new Restore();
                try
                {
                    string fileName = this.txbPath.Text.Trim();
                    string databaseName = "ITC";

                    res.Database = databaseName;
                    res.Action = RestoreActionType.Database;
                    res.Devices.AddDevice(fileName, DeviceType.File);
                    res.ReplaceDatabase = true;
                    
                    SqlConnection conn = new SqlConnection();
                    if (chbSql.Checked == false)
                        conn.ConnectionString = Program.SqlConnectionString;
                    else
                    {
                        conn.ConnectionString = GetMasterConectionString();
                    }

                    ServerConnection con = new ServerConnection(conn);
                    Server srv = new Server(con);
                    srv.KillAllProcesses("ITC");
                    srv.KillDatabase("ITC");

                    this.prbRestore.Visible = true;
                    this.prbRestore.Value1 = 0;
                    this.prbRestore.Maximum = 100;
                    this.prbRestore.Value1 = 10;
                    this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
                    this.prbRestore.Update();

                    res.PercentCompleteNotification = 10;
                    res.ReplaceDatabase = true;
                    res.NoRecovery = false;
                    res.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
                    res.SqlRestore(srv);
                  
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.ToString());
                    LogicLayer lg4 = new LogicLayer();
                    string mes3 = lg4.GetMessageFromDll(_langCode, "RestoreFail");
                    frmShowInfoSmall_RtoL frmshs = new frmShowInfoSmall_RtoL(mes3, 2);
                    frmshs.ShowDialog();
                    prbRestore.Visible = false;
                }
                finally
                {                    
                    this.prbRestore.Value1 = 0;
                    this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
                    this.prbRestore.Update();
                }
            }
            else
            {
                //todo:file name is empty error
            }
        }

        private string GetMasterConectionString()
        {
            string _conString = "";
            string _username = txbUsername.Text.Trim();
            string _password = txbPassword.Text.Trim();
            int _startIndex = Program.SqlConnectionString.IndexOf("server") + 9;
            int _endIndex = Program.SqlConnectionString.IndexOf(";database");
            int _length = _endIndex - _startIndex;
            string _server = Program.SqlConnectionString.Substring(_startIndex,_length).Trim();
            _conString = "user id = " + _username + ";password = " + _password + ";server = " + _server + ";database = master";
            return _conString;            
        }

        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.prbRestore.Value1 = e.Percent;
            this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
            this.prbRestore.Update();
            if (prbRestore.Value1 == 100)
            {
                LogicLayer lg3 = new LogicLayer();
                string mes2 = lg3.GetMessageFromDll(_langCode, "BackupSuccess");
                frmShowInfoSmall_RtoL frmshs = new frmShowInfoSmall_RtoL(mes2, 2);
                frmshs.ShowDialog();
                prbRestore.Visible = false;
                Application.Exit();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog sav = new OpenFileDialog();
            sav.AutoUpgradeEnabled = false;
            sav.DefaultExt = "BAK";
            sav.FileName = _fileName;
            sav.Filter = @"SQL Backup files (*.BAK) |*.BAK|All files (*.*) |*.*";
           
            sav.Title = this.Text;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                txbPath.Text = sav.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void chbSql_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbSql.Checked == true)
            {
                txbPassword.Enabled = true;
                txbUsername.Enabled = true;
            }
            else
            {
                txbPassword.Enabled = false;
                txbUsername.Enabled = false;
            }
        }
    }
}
