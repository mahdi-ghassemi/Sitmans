using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmEmploye_RtoL : Telerik.WinControls.UI.RadForm
    {
        private Agents _agent;
        private string _langCode;

        public frmEmploye_RtoL(Agents agent)
        {
            _agent = agent;
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void frmEmploye_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            LogicLayer lo = new LogicLayer();

            this.Text = lo.GetMessageFromDll(_langCode, "UserFullName");
            lblFirstname.Text = lo.GetMessageFromDll(_langCode, "Firstname"); 
            lblLastname.Text = lo.GetMessageFromDll(_langCode, "Lastname"); 
            lblPersonalCode.Text = lo.GetMessageFromDll(_langCode, "PersonelCode"); 
            lblGender.Text = lo.GetMessageFromDll(_langCode, "Gender"); 
            cmbGender.Items.Add(lo.GetMessageFromDll(_langCode, "Male"));
            cmbGender.Items.Add(lo.GetMessageFromDll(_langCode, "Female"));
            cmbGender.SelectedIndex = 0;
            lblInternalNo.Text = lo.GetMessageFromDll(_langCode, "InternalContact");
            lblMailAddress.Text = lo.GetMessageFromDll(_langCode, "EmailAddress");
            lblPhone.Text = lo.GetMessageFromDll(_langCode, "Tell");
            lblCell.Text = lo.GetMessageFromDll(_langCode, "Mob"); 
            lblAddress.Text = lo.GetMessageFromDll(_langCode, "Address");
            lblTitle.Text = lo.GetMessageFromDll(_langCode, "JobTitle");
            btnBrowse.Text = lo.GetMessageFromDll(_langCode, "BrowseImage");


            grbPublic.Text = lo.GetMessageFromDll(_langCode, "AgentPublicInfo");
            lblComputerName.Text = lo.GetMessageFromDll(_langCode, "ComputerName"); 
            //lblAgentID.Text = Languages.AgentIDLable(Properties.Settings.Default.CurrentLanguage);
            lblAgentNumber.Text = lo.GetMessageFromDll(_langCode, "AgentID");
            lblStatus.Text = lo.GetMessageFromDll(_langCode, "AgentStatus");
            lblCurrentAccount.Text = lo.GetMessageFromDll(_langCode, "CurrentAccount");
            lblStartupTime.Text = lo.GetMessageFromDll(_langCode, "StartupTime");
            lblStartupDate.Text = lo.GetMessageFromDll(_langCode, "StartupDate");
            lblIpAddress.Text = lo.GetMessageFromDll(_langCode, "IPAddress");
            lblMacAddress.Text = lo.GetMessageFromDll(_langCode, "MacAddress");
            tsbUserEdit.Text = lo.GetMessageFromDll(_langCode, "Edit");
            tsbUserDelete.Text = lo.GetMessageFromDll(_langCode, "Delete");
            tsbSave.Text = lo.GetMessageFromDll(_langCode, "Save");

            txbAddress.Enabled = false;
            txbCell.Enabled = false;
            txbFirstname.Enabled = false;
            txbInternalNumber.Enabled = false;
            txbLastname.Enabled = false;
            txbTitle.Enabled = false;
            txbMailAddress.Enabled = false;
            txbPersonelCode.Enabled = false;
            txbPhone.Enabled = false;
            cmbGender.Enabled = false;
            btnBrowse.Enabled = false;
            tsbSave.Enabled = false;

            if (_agent.PersonnelLName == null || _agent.PersonnelLName == "")
            {
                tsbUserDelete.Enabled = false;
                //txbAddress.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                //txbCell.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                txbFirstname.Text = lo.GetMessageFromDll(_langCode, "NotDefine"); 
                //txbInternalNumber.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                txbLastname.Text = lo.GetMessageFromDll(_langCode, "NotDefine"); 
                //txbMailAddress.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                //txbPersonelCode.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                //txbPhone.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                //txbTitle.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
            }
            else
            {
                tsbUserDelete.Enabled = true;
                txbAddress.Text = _agent.PersonnelAddress;
                txbCell.Text = _agent.PersonnelCellNum;
                txbFirstname.Text = _agent.PersonnelFName;
                txbInternalNumber.Text = _agent.PersonnelInterNum;
                txbLastname.Text = _agent.PersonnelLName;
                txbMailAddress.Text = _agent.PersonnelMail;
                txbPersonelCode.Text = _agent.PersonnelCode;
                txbPhone.Text = _agent.PersonnelTellNum;
                txbTitle.Text = _agent.PersonnelTitle;
                pibEmploye.Image = _agent.PersonnelImage;
                cmbGender.SelectedIndex = Convert.ToInt32(_agent.PersonnelGender);
            }

            lbl_AgentNumber.Text = _agent.AgentID;
            lbl_AgentStatus.Text = _agent.Status;
            lbl_ComputerName.Text = _agent.ComputerName;
            lbl_IPAddress.Text = lo.GetFirstActiveIPV4(_agent.IPAddress[0]);
            lbl_LoginAccount.Text = _agent.CurrentAccount;
            lbl_MACAddress.Text = lo.RemoveBracket(_agent.MacAddress[0]);
            lbl_StartupDate.Text = _agent.StartupDate;
            lbl_StartupTime.Text = _agent.StartupTime;

        }

        private void tsbUserEdit_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl6)
            {
                LogicLayer lo = new LogicLayer();
                txbAddress.Enabled = true;
                txbCell.Enabled = true;
                txbFirstname.Enabled = true;
                txbInternalNumber.Enabled = true;
                txbLastname.Enabled = true;
                txbTitle.Enabled = true;
                txbMailAddress.Enabled = true;
                txbPersonelCode.Enabled = true;
                txbPhone.Enabled = true;
                cmbGender.Enabled = true;
                btnBrowse.Enabled = true;
                tsbSave.Enabled = true;
                tsbUserEdit.Enabled = false;
                tsbUserDelete.Enabled = false;

                if (txbFirstname.Text == lo.GetMessageFromDll(_langCode, "NotDefine"))
                {
                    txbFirstname.Text = "";
                    txbLastname.Text = "";
                }
                txbFirstname.Focus();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            if (txbFirstname.Text != "" || txbLastname.Text != "")
            {
               
                string[] param = new string[11];
                param[0] = txbAddress.Text;
                param[1] = txbCell.Text;
                param[2] = txbFirstname.Text;
                param[3] = txbInternalNumber.Text;
                param[4] = txbLastname.Text;
                param[5] = txbMailAddress.Text;
                param[6] = txbPersonelCode.Text;
                param[7] = txbPhone.Text;
                param[8] = txbTitle.Text;

                if (cmbGender.SelectedIndex == 0)
                    param[9] = "0";
                else
                    param[9] = "1";

                param[10] = _agent.AgentID;

                byte[] imageData = null;

                if (pibEmploye.ImageLocation != null)
                {
                    imageData = ReadFile(pibEmploye.ImageLocation);
                }

                if (_agent.PersonnelLName == null || _agent.PersonnelLName == "")
                {
                    lg.InsertPersonnelInfo(param, imageData);
                }
                else
                {
                    lg.UpdatePersonnelInfo(param, imageData);
                }
                //Update Agent list Property
                string AgentIDtoFind = _agent.AgentID;

                int index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agent.AgentID, StringComparison.Ordinal); });
                Program.AgentList[index].PersonnelAddress = txbAddress.Text;
                Program.AgentList[index].PersonnelCellNum = txbCell.Text;
                Program.AgentList[index].PersonnelFName = txbFirstname.Text;
                Program.AgentList[index].PersonnelInterNum = txbInternalNumber.Text;
                Program.AgentList[index].PersonnelLName = txbLastname.Text;
                Program.AgentList[index].PersonnelMail = txbMailAddress.Text;
                Program.AgentList[index].PersonnelCode = txbPersonelCode.Text;
                Program.AgentList[index].PersonnelTellNum = txbPhone.Text;
                Program.AgentList[index].PersonnelTitle = txbTitle.Text;
                Program.AgentList[index].PersonnelGender = cmbGender.SelectedIndex.ToString();
                Program.AgentList[index].PersonnelImage = pibEmploye.Image;

                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(lg.GetMessageFromDll(_langCode, "SaveSuccessfull"), 2);
                fs.ShowDialog();
                
            }
            else
            {
                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(lg.GetErrorMessage(26), 2);
                fs.ShowDialog();
            }
        }

        //Open file in to a filestream and read data in a byte array.
        private byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void tsbUserDelete_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl7)
            {
                LogicLayer lg = new LogicLayer();
                frmShowInfoSmall_RtoL fsm = new frmShowInfoSmall_RtoL(lg.GetMessageFromDll(_langCode, "DeleteNotification"), 3);
                DialogResult dr = fsm.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {

                    lg.DeletePersonnelInfo(_agent.AgentID);

                    //Update Agent list Property
                    string AgentIDtoFind = _agent.AgentID;

                    int index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agent.AgentID, StringComparison.Ordinal); });
                    Program.AgentList[index].PersonnelAddress = "";
                    Program.AgentList[index].PersonnelCellNum = "";
                    Program.AgentList[index].PersonnelFName = "";
                    Program.AgentList[index].PersonnelInterNum = "";
                    Program.AgentList[index].PersonnelLName = "";
                    Program.AgentList[index].PersonnelMail = "";
                    Program.AgentList[index].PersonnelCode = "";
                    Program.AgentList[index].PersonnelTellNum = "";
                    Program.AgentList[index].PersonnelTitle = "";
                    Program.AgentList[index].PersonnelGender = "";
                    Program.AgentList[index].PersonnelImage = null;

                    frmShowInfoSmall_RtoL fsm2 = new frmShowInfoSmall_RtoL(lg.GetMessageFromDll(_langCode, "DeleteSuccessfull"), 2);
                    fsm2.ShowDialog();
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
             //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AutoUpgradeEnabled = false;
            dlg.Title = "Select a picture";
            dlg.Filter = "Image File|*.jpg";
            DialogResult dlgRes = new System.Windows.Forms.DialogResult();
            dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pibEmploye.ImageLocation = dlg.FileName;
                
                FileInfo fi = new FileInfo(dlg.FileName);
                dlg.Dispose();
                GC.Collect();
                if (fi.Length > 50000) 
                {
                    LogicLayer lg = new LogicLayer();
                    frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(lg.GetErrorMessage(27), 2);
                    fm.ShowDialog();
                    pibEmploye.ImageLocation = null;
                }
            }
            else
                pibEmploye.ImageLocation = null;
        
        }

        private void frmEmploye_RtoL_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

    }
}
