using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmProfileSetting_RtoL : Telerik.WinControls.UI.RadForm
    {

        private bool SaveReady;
        private bool ProfileNameOk;
        private bool AliasNameOk;
        private bool PasswordOk;
        private bool PortNumberOk;
        private bool RDPortOk;
        private bool FTPortOk;
        private bool VCPortOk;
        private bool CommandPortOk;
        private bool WebinarPortOk;
        private bool PublicPortOk;
       

       
        private string _langCode;
        private int _profileId;

        private string _Id;
        private string _UsbAccessControl;
        private string _UsbDataControl;
        private string _RegAccessControl;
        private string _AppInstallDisable;
        private string _AliasShow;
        private string _Alias;
        private string _AgentPassword;
        private string _HardwareCtr;
        private string _SoftwareCtr;
        private string _NetworkCtr;
        private string _AccountCtr;
        private string _ChatWithOther;
        private string _VideoWithOther;
        private string _FileTransferWithOther;
        private string _ImageProcessing;
        private string _RDPort;
        private string _ChatPort;
        private string _FTPort;
        private string _VCPort;
        private string _CommandPort;
        private string _WebinarPort;
        private string _UpdateCounter;
        private string _PublicPort;
        private string _AppDisableRun;
        private string _DisableCtrlAltDel;
            
        private LogicLayer lg;

        private int ProfileId
        {
            get
            {
                return _profileId;
            }
            set
            {
                value = _profileId;
                if (_profileId == 1)
                {
                    deleteToolStripButton.Enabled = false;
                }
                else
                    deleteToolStripButton.Enabled = true;
            }
        }

        public frmProfileSetting_RtoL()
        {
            lg = new LogicLayer();
            SaveReady = true;
            ProfileNameOk = true;
            AliasNameOk = true;
            PasswordOk = true;
            PortNumberOk = true;
            RDPortOk = true;
            FTPortOk = true;
            VCPortOk = true;
            CommandPortOk = true;
            WebinarPortOk = true;


            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void frmAgentsSetting_RtoL_Load(object sender, EventArgs e)
        {
            FillProfileList();
            SetProfileControl();            
            FillForm();
            LoadSettingControl(0);          

        }

        private void SetProfileControl()
        {
            rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;

            cmbProfileList.Enabled = true;
            cmbProfileList.SelectedIndex = 0;

            txbProfileName.Enabled = false;

            cmbProfileFrom.Enabled = false;
            cmbProfileTo.Enabled = false;
        }

        private void FillForm()
        {          
            this.Text = lg.GetMessageFromDll(_langCode, "frmCaption");

            grbProfileSelect.Text = lg.GetMessageFromDll(_langCode, "Profile");
            rbtNewProfile.Text = lg.GetMessageFromDll(_langCode, "NewProfile");
            rbtSelectProfile.Text = lg.GetMessageFromDll(_langCode, "SelectProfile");
            rbtCopyProfile.Text = lg.GetMessageFromDll(_langCode, "CopyProfile");
            lblTo.Text = lg.GetMessageFromDll(_langCode, "To");
            
            pwpPublic.Text = lg.GetMessageFromDll(_langCode, "Public");
            pwpSystemAccess.Text = lg.GetMessageFromDll(_langCode, "Access");
            pwpInternetAccess.Text = lg.GetMessageFromDll(_langCode, "Internet");
               
        
            chbAppInstallDisable.Text = lg.GetMessageFromDll(_langCode, "AppInstallDisable");
            chbAppRunDisable.Text = lg.GetMessageFromDll(_langCode, "AppRunDisable");
            chbRegAccessControl.Text = lg.GetMessageFromDll(_langCode, "RegistryDisable");
            chbUsbAccessControl.Text = lg.GetMessageFromDll(_langCode, "UsbDisable");
            chbUsbDataControl.Text = lg.GetMessageFromDll(_langCode, "UsbDataControl");
            chbDisableCtrlAltDel.Text = lg.GetMessageFromDll(_langCode, "DisableCtrlAltDel");
            btnAppList.Text = lg.GetMessageFromDll(_langCode, "ApplicationList");

            chbAliasShow.Text = lg.GetMessageFromDll(_langCode, "AliasShow");
            lblAlias.Text = lg.GetMessageFromDll(_langCode, "Alias");

            lblPassword.Text = lg.GetMessageFromDll(_langCode, "lblRemotePassword");
            lblPasswordConfirm.Text = lg.GetMessageFromDll(_langCode, "lblReRemotePassword");

            chbHardwareCtr.Text = lg.GetMessageFromDll(_langCode, "chbHardwareCtr");
            chbSoftwareCtr.Text = lg.GetMessageFromDll(_langCode, "chbSoftwareCtr");
            chbAccountCtr.Text = lg.GetMessageFromDll(_langCode, "chbAccountCtr");
            chbNetworkCtr.Text = lg.GetMessageFromDll(_langCode, "chbNetworkCtr");
            chbChatWithOther.Text = lg.GetMessageFromDll(_langCode, "chbChatWithOther");
            chbFileTransferWithOther.Text = lg.GetMessageFromDll(_langCode, "chbFileTransferWithOrher");
            chbImageProcessing.Text = lg.GetMessageFromDll(_langCode, "chbImageProcessing");
            chbVideoWithOther.Text = lg.GetMessageFromDll(_langCode, "chbVideoWithOther");

            lblPortNumber.Text = lg.GetMessageFromDll(_langCode, "ChatPortNumber");
            lblRDPort.Text = lg.GetMessageFromDll(_langCode, "RDPort");
            lblVCPort.Text = lg.GetMessageFromDll(_langCode, "VCPort");
            lblWebinarPort.Text = lg.GetMessageFromDll(_langCode, "WebinarPort");
            lblFTPort.Text = lg.GetMessageFromDll(_langCode, "FTPort");
            lblCommandPort.Text = lg.GetMessageFromDll(_langCode, "CommandPort");
            lblPublicPort.Text = lg.GetMessageFromDll(_langCode, "PublicPort");

            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");
            helpToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Help");

        }

        private void FillProfileList()
        {
            if (cmbProfileList.Items.Count > 0)
            {
                cmbProfileList.Items.Clear();
                cmbProfileTo.Items.Clear();
                cmbProfileFrom.Items.Clear();
            }
            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetSettingProfile();
            int _rowCount = Program.SettingProfileList.Count;

            cmbProfileList.Items.Add(_default);
            cmbProfileTo.Items.Add(_default);
            cmbProfileFrom.Items.Add(_default);

            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.SettingProfileList[i].ProfileName);
                cmbProfileFrom.Items.Add(Program.SettingProfileList[i].ProfileName);
                cmbProfileTo.Items.Add(Program.SettingProfileList[i].ProfileName);
            }
            _profileId = 1;
            ProfileId = _profileId;

            cmbProfileList.SelectedIndex = 0;
           // cmbProfileFrom.SelectedIndex = 0;
           // cmbProfileTo.SelectedIndex = 0;
        }
     
        private void LoadSettingControl(int ProfileIndex)
        {

            if (Program.SettingProfileList[ProfileIndex].UsbAccessControl == "1")
                chbUsbAccessControl.Checked = true;
            else
                chbUsbAccessControl.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].UsbDataControl == "1")
                chbUsbDataControl.Checked = true;
            else
                chbUsbDataControl.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].RegAccessControl == "1")
                chbRegAccessControl.Checked = true;
            else
                chbRegAccessControl.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].AppInstallDisable == "1")
                chbAppInstallDisable.Checked = true;
            else
                chbAppInstallDisable.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].AliasShow == "1")
                chbAliasShow.Checked = true;
            else
                chbAliasShow.Checked = false;

            txbAlias.Text = Program.SettingProfileList[ProfileIndex].Alias;
            txbPassword.Text = Program.SettingProfileList[ProfileIndex].AgentPassword;
            txbPasswordConfirm.Text = Program.SettingProfileList[ProfileIndex].AgentPassword;

            if (Program.SettingProfileList[ProfileIndex].HardwareCtr == "1")
                chbHardwareCtr.Checked = true;
            else
                chbHardwareCtr.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].SoftwareCtr == "1")
                chbSoftwareCtr.Checked = true;
            else
                chbSoftwareCtr.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].NetworkCtr == "1")
                chbNetworkCtr.Checked = true;
            else
                chbNetworkCtr.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].AccountCtr == "1")
                chbAccountCtr.Checked = true;
            else
                chbAccountCtr.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].ChatWithOther == "1")
                chbChatWithOther.Checked = true;
            else
                chbChatWithOther.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].VideoWithOther == "1")
                chbVideoWithOther.Checked = true;
            else
                chbVideoWithOther.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].FileTransferWithOther == "1")
                chbFileTransferWithOther.Checked = true;
            else
                chbFileTransferWithOther.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].ImageProcessing == "1")
                chbImageProcessing.Checked = true;
            else
                chbImageProcessing.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].AppDisableRun == "1")
                chbAppRunDisable.Checked = true;
            else
                chbAppRunDisable.Checked = false;

            if (Program.SettingProfileList[ProfileIndex].DisableCtrlAltDel == "1")
                chbDisableCtrlAltDel.Checked = true;
            else
                chbDisableCtrlAltDel.Checked = false;


            txbRDPort.Text = Program.SettingProfileList[ProfileIndex].RDPort;
            txbPortNumber.Text = Program.SettingProfileList[ProfileIndex].ChatPort;
            txbFTPort.Text = Program.SettingProfileList[ProfileIndex].FTPort;
            txbVCPort.Text = Program.SettingProfileList[ProfileIndex].VCPort;
            txbCommandPort.Text = Program.SettingProfileList[ProfileIndex].CommandPort;
            txbWebinarPort.Text = Program.SettingProfileList[ProfileIndex].WebinarPort;
            txbPublicPort.Text = Program.SettingProfileList[ProfileIndex].PublicPort;

        }
      
        private void chbAliasShow_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbAliasShow.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                lblAlias.Enabled = false;
                txbAlias.Enabled = false;
            }
            if (chbAliasShow.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                lblAlias.Enabled = true;
                txbAlias.Enabled = true;
            }
        }
        
        private void rbtSelectProfile_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                SetProfileControl();
            }
        }

        private void rbtNewProfile_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = true;

                cmbProfileList.Enabled = false;
                cmbProfileTo.Enabled = false;
                cmbProfileFrom.Enabled = false;
               
                txbProfileName.Focus();
            }
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                erpProfileName.Clear();
            }
        }

        private void rbtCopyProfile_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;

                cmbProfileList.Enabled = false;
                cmbProfileFrom.Enabled = true;
               // cmbProfileFrom.SelectedIndex = 0;

                cmbProfileTo.Enabled = true;
              //  cmbProfileTo.SelectedIndex = 0;
            }
        }

        private void cmbProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _index;
            _index = cmbProfileList.SelectedIndex;
            _profileId = _index + 1;
            ProfileId = _profileId;
            LoadSettingControl(_index);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            CheckValidation();
            if (SaveReady == true)
            {
                AssignProfileSettings();
                if (lg.CheckPermission(72))
                {
                    if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        UpdateProfile(cmbProfileList.SelectedIndex);
                    }
                }
                else
                {
                    frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                    frmmsg.ShowDialog();
                }
                if (lg.CheckPermission(71))
                {
                    if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        bool IsProfileNameRepeat = CheckProfileName(txbProfileName.Text);
                        if (IsProfileNameRepeat == false)
                        {
                            NewProfile();
                        }
                        else
                        {
                            string mes = lg.GetMessageFromDll(_langCode, "ProfileNameIsRepeat");
                            frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                            frmsh.ShowDialog();
                        }
                    }
                }
                else
                {
                    frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                    frmmsg.ShowDialog();
                }
                if (lg.CheckPermission(72))
                {
                    if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                    {
                        UpdateProfile(cmbProfileTo.SelectedIndex);
                    }
                }
                else
                {
                    frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                    frmmsg.ShowDialog();
                }
            }
        }

        private bool CheckProfileName(string NewProfileName)
        {
            bool result = false;
            int count = Program.SettingProfileList.Count;
            for (int i = 0; i < count; i++)
            {
                if (Program.SettingProfileList[i].ProfileName.Trim() == NewProfileName.Trim())
                    result = true;
            }
            return result;
        }

        private void CheckValidation()
        {
            PasswordConfirmValidating();
            AliasValidating();
            ProfileNameValidating();
            RDPortValidating();
            FTPortValidating();
            CommandPortValidating();
            VCPortValidating();
            WebinarPortValidating();
            PublicPortValidating();

        
            if (ProfileNameOk == true && AliasNameOk == true && PasswordOk == true && PortNumberOk == true && RDPortOk == true && FTPortOk &&
                VCPortOk == true && CommandPortOk == true && WebinarPortOk == true && PublicPortOk == true)
            {
                SaveReady = true;
            }
            else
            {
                SaveReady = false;
            }
           
        }              
        
        private void AssignProfileSettings()
        {        

            if (chbUsbAccessControl.Checked == true)
            {
                _UsbAccessControl = "1";
            }
            else
            {
                _UsbAccessControl = "0";
            }

            if (chbUsbDataControl.Checked == true)
            {
                _UsbDataControl = "1";
            }
            else
            {
                _UsbDataControl = "0";
            }

            if (chbRegAccessControl.Checked == true)
            {
                _RegAccessControl = "1";
            }
            else
            {
                _RegAccessControl = "0";
            }

            if (chbAppInstallDisable.Checked == true)
            {
                _AppInstallDisable = "1";
            }
            else
            {
                _AppInstallDisable = "0";
            }

            if (chbAliasShow.Checked == true)
            {
                _AliasShow = "1";
                _Alias = txbAlias.Text.Trim();
            }
            else
            {
                _AliasShow = "0";
                _Alias = "";
            }

            Encrypter enc = new Encrypter();
 
          _AgentPassword = enc.Encrypt(txbPassword.Text.Trim());

          if (chbHardwareCtr.Checked == true)
          {
              _HardwareCtr = "1";
          }
          else
          {
              _HardwareCtr = "0";
          }

          if (chbSoftwareCtr.Checked == true)
          {
              _SoftwareCtr = "1";
          }
          else
          {
              _SoftwareCtr = "0";
          }

          if (chbNetworkCtr.Checked == true)
          {
              _NetworkCtr = "1";
          }
          else
          {
              _NetworkCtr = "0";
          }

          if (chbAccountCtr.Checked == true)
          {
              _AccountCtr = "1";
          }
          else
          {
              _AccountCtr = "0";
          }

          if (chbChatWithOther.Checked == true)
          {
              _ChatWithOther = "1";
          }
          else
          {
              _ChatWithOther = "0";
          }

          if (chbVideoWithOther.Checked == true)
          {
              _VideoWithOther = "1";
          }
          else
          {
              _VideoWithOther = "0";
          }

          if (chbFileTransferWithOther.Checked == true)
          {
              _FileTransferWithOther = "1";
          }
          else
          {
              _FileTransferWithOther = "0";
          }

          if (chbImageProcessing.Checked == true)
          {
              _ImageProcessing = "1";
          }
          else
          {
              _ImageProcessing = "0";
          }

          if (chbAppRunDisable.Checked == true)
          {
              _AppDisableRun = "1";
          }
          else
          {
              _AppDisableRun = "0";
          }

          if (chbDisableCtrlAltDel.Checked == true)
          {
              _DisableCtrlAltDel = "1";
          }
          else
          {
              _DisableCtrlAltDel = "0";
          }
          
          _RDPort = txbRDPort.Text.Trim();
          _ChatPort = txbPortNumber.Text.Trim();
          _FTPort = txbFTPort.Text.Trim();
          _VCPort = txbVCPort.Text.Trim();
          _CommandPort = txbCommandPort.Text.Trim();
          _WebinarPort = txbWebinarPort.Text.Trim();
          _PublicPort = txbPublicPort.Text.Trim();
         
         

        }

        private void UpdateProfile(int Index)
        {
            _Id = Program.SettingProfileList[Index].Id;

            _UpdateCounter = Convert.ToString(Program.SettingProfileList[Index].UpdateCounter + 1);

            int res = lg.UpdateSettingProfile(_Id, _UsbAccessControl, _UsbDataControl, _RegAccessControl, _AppInstallDisable, _AliasShow, _Alias,
                                              _AgentPassword,_HardwareCtr,_SoftwareCtr,_NetworkCtr,_AccountCtr,_ChatWithOther,_VideoWithOther,
                                              _FileTransferWithOther,_ImageProcessing,_RDPort,_ChatPort,_FTPort,_VCPort,_CommandPort,
                                              _WebinarPort, _UpdateCounter,_PublicPort,_AppDisableRun,_DisableCtrlAltDel);
           

            if (res == 1)
            {
                lg.GetSettingProfile();
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
            else
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }

        }      

        private void NewProfile()
        {

            string _pid = lg.GetLastSettingProfileId();
            string _pname = txbProfileName.Text.Trim();
            int res = lg.InsertSettingProfile(_pid, _pname, _UsbAccessControl, _UsbDataControl, _RegAccessControl, _AppInstallDisable, _AliasShow, _Alias,
                                              _AgentPassword, _HardwareCtr, _SoftwareCtr, _NetworkCtr, _AccountCtr, _ChatWithOther, _VideoWithOther,
                                              _FileTransferWithOther, _ImageProcessing, _RDPort, _ChatPort, _FTPort, _VCPort, _CommandPort,
                                              _WebinarPort, _PublicPort, _AppDisableRun, _DisableCtrlAltDel);
            if (res == 1)
            {
                lg.GetSettingProfile();
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
                SetProfileControl();           
                FillProfileList();
            }
            else
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
        }      

        private void txbPortNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void PortNumberValidating()
        {
            int _port = 0;
            if (txbPortNumber.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbPortNumber.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbPortNumber.Text.Trim() == "")
            {
                PortNumberOk = false;
                erpPortNumber.SetError(txbPortNumber, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                PortNumberOk = true;
                erpPortNumber.Clear();
            }
        }

        private void txbPortNumber_Validating(object sender, CancelEventArgs e)
        {
            PortNumberValidating();

        }

        private void txbRDPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbFTPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbVCPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbCommandPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbWebinarPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void AliasValidating()
        {
            if (chbAliasShow.Checked == true)
            {
                if (txbAlias.Text.Trim() == "")
                {
                    AliasNameOk = false;
                    erpAlias.SetError(txbAlias, lg.GetMessageFromDll(_langCode, "AliasNameError"));
                }
                else
                {
                    erpAlias.Clear();
                    AliasNameOk = true;
                }
            }
        }

        private void ProfileNameValidating()
        {
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                if (txbProfileName.Text.Trim() == "")
                {
                    ProfileNameOk = false;
                    erpProfileName.SetError(txbProfileName, lg.GetMessageFromDll(_langCode, "ProfileNameError"));
                }
                else
                {
                    erpProfileName.Clear();
                    ProfileNameOk = true;
                }
            }
        }

        private void txbProfileName_Validating(object sender, CancelEventArgs e)
        {
            ProfileNameValidating();
        }

        private void txbAlias_Validating(object sender, CancelEventArgs e)
        {
            AliasValidating();
        }

        private void PasswordConfirmValidating()
        {
            if (txbPassword.Text.Trim() == "" || txbPasswordConfirm.Text.Trim() == "")
            {
                PasswordOk = false;
                erpPassword.SetError(txbPasswordConfirm, lg.GetMessageFromDll(_langCode, "PasswordBlankError"));
            }
            else
            {
                PasswordOk = true;
                erpPassword.Clear();
            }
            if (txbPasswordConfirm.Text.Trim() != txbPassword.Text.Trim())
            {
                PasswordOk = false;
                erpPassword.SetError(txbPasswordConfirm, lg.GetMessageFromDll(_langCode, "ErrorPasswordConfirm"));
            }
            else
            {
                PasswordOk = true;
                erpPassword.Clear();
            }
        }

        private void txbPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            PasswordConfirmValidating();
        }

        private void RDPortValidating()
        {
            int _port = 0;
            if (txbRDPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbRDPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbRDPort.Text.Trim() == "")
            {
                RDPortOk = false;
                erpRDPort.SetError(txbRDPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                RDPortOk = true;
                erpRDPort.Clear();
            }
        }

        private void txbRDPort_Validating(object sender, CancelEventArgs e)
        {
            RDPortValidating();
        }

        private void FTPortValidating()
        {
            int _port = 0;
            if (txbFTPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbFTPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbFTPort.Text.Trim() == "")
            {
                FTPortOk = false;
                erpFTPort.SetError(txbFTPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                FTPortOk = true;
                erpFTPort.Clear();
            }
        }

        private void txbFTPort_Validating(object sender, CancelEventArgs e)
        {
            FTPortValidating();
        }

        private void CommandPortValidating()
        {
            int _port = 0;
            if (txbCommandPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbCommandPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbCommandPort.Text.Trim() == "")
            {
                CommandPortOk = false;
                erpCommandPort.SetError(txbCommandPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                CommandPortOk = true;
                erpCommandPort.Clear();
            }
        }

        private void VCPortValidating()
        {
            int _port = 0;
            if (txbVCPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbVCPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbVCPort.Text.Trim() == "")
            {
                VCPortOk = false;
                erpVCPort.SetError(txbVCPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                VCPortOk = true;
                erpVCPort.Clear();
            }
        }

        private void txbVCPort_Validating(object sender, CancelEventArgs e)
        {
            VCPortValidating();
        }

        private void txbCommandPort_Validating(object sender, CancelEventArgs e)
        {
            CommandPortValidating();
        }

        private void WebinarPortValidating()
        {
            int _port = 0;
            if (txbWebinarPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbWebinarPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbWebinarPort.Text.Trim() == "")
            {
                WebinarPortOk = false;
                erpWebinarPort.SetError(txbWebinarPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                WebinarPortOk = true;
                erpWebinarPort.Clear();
            }
        }

        private void txbWebinarPort_Validating(object sender, CancelEventArgs e)
        {
            WebinarPortValidating();
        }

        private void cmbProfileFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _index;
            _index = cmbProfileFrom.SelectedIndex;
            _profileId = _index + 1;
            ProfileId = _profileId;
            LoadSettingControl(_index);
        }

        private void txbPublicPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void PublicPortValidating()
        {
            int _port = 0;
            if (txbPublicPort.Text.Trim() != "")
            {
                _port = Convert.ToInt32(txbPublicPort.Text.Trim());
            }

            if (_port < 1 || _port > 65535 || txbPublicPort.Text.Trim() == "")
            {
                PublicPortOk = false;
                erpWebinarPort.SetError(txbPublicPort, lg.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                PublicPortOk = true;
                erpWebinarPort.Clear();
            }
        }

        private void txbPublicPort_Validating(object sender, CancelEventArgs e)
        {
            PublicPortValidating();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(73))
            {
                if (cmbProfileList.SelectedIndex != 0)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteNotification");
                    frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 3);
                    DialogResult dr = frmsh.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        GoToDelete();
                    }
                }
                else
                {
                    ShowDeleteMessage(lg.GetErrorMessage(24));
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void GoToDelete()
        {
            int Res = 0;

            _Id = Program.SettingProfileList[cmbProfileList.SelectedIndex].Id;
            Res = lg.DeleteSettingProfile(_Id);

            if (Res == 1)
            {

                ShowDeleteMessage(lg.GetMessageFromDll(_langCode, "DeleteSuccessfull"));

                FillProfileList();
            }
            else
            {
                ShowDeleteMessage(lg.GetErrorMessage(20));
            }
        }


        private void ShowDeleteMessage(string Message)
        {
            frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(Message, 2);
            frmsh.ShowDialog();
        }

        private void cmbProfileTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
               
    }
}
