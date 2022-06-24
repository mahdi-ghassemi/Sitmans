using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Diagnostics;


namespace Configure
{
    public partial class frmMain_RtoL : Telerik.WinControls.UI.RadForm
    {
       
        #region Private Member

        private string _langCode;
        private string _customerName;
        private string _serialCode;
        private string _clientCount;
        private string _activeCode;
        private string _buyDate;
        private string _readKeyEn;
        private string _writeKeyEn;
        private string _LockSerialNumber;
        private string _lockIpAddress;
        private string _readKeyDe;
        private string _writeKeyDe;
        private string _settingPassword;
        private int _isRegister;
        private string _pathForITComplexSrv;
        private bool NowExit;


        /* Validation Control */
        private bool _isSqlConRigth;
        private bool _isSettingSaved;
        private bool _saveYes;
        private bool _isPortNumberRight;
        private bool _isIpAddressRight;
        private bool _isPasswordConfirm;
        private bool _isAllValid;
        

        /* Setting From Agents.dll */
        private string _SQLServerAddress_ITComplexSrv;
        private string _SQLUsername_ITComplexSrv;
        private string _SQLPassword_ITComplexSrv;
        private string _SQLDatabaseName_ITComplexSrv;

        private string _AgentPassword_ITComplexSrv;
        private string _IsRegister_ITComplexSrv;
        
        private string _ChatPort_ITComplexSrv;

        private string _UDPPort_ITComplexSrv;
      
        private string _LanguageCode_ITComplexSrv;
        private string _RigthToLeft_ITComplexSrv;

        private string _ClientCount_ITComplexSrv;
        private string _ChatWithOther_ITComplexSrv;
        private string _FileTransferToOther_ITComplexSrv;
        private string _VideoConfToOther_ITComplexSrv;

       
        private string _ImageProccesing_ITComplexSrv;
        private string _LockIpAddress_ITComplexSrv;

        private string _RDPort_ITComplexSrv;
        private string _FTPort_ITComplexSrv;
        private string _VCPort_ITComplexSrv;
        private string _CMDPort_ITComplexSrv;
        private string _WebinarPort_ITComplexSrv;
        private string _PublicPort_ITComplexSrv;

        private string _UsbAccessControl_ITComplexSrv;
        private string _UsbDataControl_ITComplexSrv;
        private string _RegAccessControl_ITComplexSrv;
        private string _AppInstallDisable_ITComplexSrv;
        private string _AppRunDisable_ITComplexSrv;
        private string _DisableCtrlAltDel_ITComplexSrv;
       


        /* Setting For Setting Profile in Sql */
        private string _Id;
        private string _ProfileId;
        private string _ProfileName;
        private string _UsbAccessControl;
        private string _UsbDataControl;
        private string _RegAccessControl;
        private string _AppInstallDisable;
        private string _AppRunDisable;
        private string _DisableCtrlAltDel;
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
        private string _PortNumber;
        private string _FTPort;
        private string _VCPort;
        private string _CommandPort;
        private string _WebinarPort;
        private string _PublicPort;
        private string _UpdateCounter;

        private LocalData ld;



       #endregion

        public bool IsSaveSetting
        {
            get { return _isSettingSaved; }
            set
            {
                _isSettingSaved = value;
                if (_isSettingSaved == true)
                {
                    btnSaveSetting.Enabled = false;
                }
                else if (_isSettingSaved == false)
                {
                    btnSaveSetting.Enabled = true;
                }
            }
        }


       
        public frmMain_RtoL(string LangCode)
        {
            NowExit = false;
            ld = new LocalData();
            _langCode = LangCode;
            InitializeComponent();
        }

        private void frmMain_RtoL_Load(object sender, EventArgs e)
        {
            _isSqlConRigth = false;
            _saveYes = false;
            this.IsSaveSetting = true;
            _pathForITComplexSrv = "";

            _isRegister = 0;

            GetFormMessage();
          
            _lockIpAddress = ld.GetDataFromDll("Setting", "LockIPAddress", "ID = 1");

            _isRegister = ld.IsRegister(_lockIpAddress);         
            

            FillForm(_isRegister);           

            tbiActiveSoftware.Focus();
                       

            DisableLanguagesControl();
        }

        private void DisableLanguagesControl()
        {
            rbtArabic.Enabled = false;
            rbtArmanian.Enabled = false;
            rbtChinese.Enabled = false;
            rbtDanish.Enabled = false;
            rbtDutch.Enabled = false;
            rbtFrench.Enabled = false;
            rbtGerman.Enabled = false;
            rbtEnglish.Enabled = false;
            rbtHungarian.Enabled = false;
            rbtItalian.Enabled = false;
            rbtJapanese.Enabled = false;
            rbtKorean.Enabled = false;
            rbtNorwegian.Enabled = false;
            rbtPortuguese.Enabled = false;
            rbtRomanian.Enabled = false;
            rbtRussian.Enabled = false;
            rbtSpanish.Enabled = false;
            rbtSwedish.Enabled = false;
            rbtTurkish.Enabled = false;

        }

        private void GetFormMessage()
        {            
            this.Text = ld.GetMessageFromDll(_langCode,"frmCaption");
            tbiActiveSoftware.Text = ld.GetMessageFromDll(_langCode, "tbiActive");
            tbiSql.Text = ld.GetMessageFromDll(_langCode, "tbiSql");
            tbiAgent.Text = ld.GetMessageFromDll(_langCode, "tbiAgent");
            tbiAccess.Text = ld.GetMessageFromDll(_langCode, "tbiAccess");

            tbiLanguage.Text = ld.GetMessageFromDll(_langCode,"tbiLanguage");
            tbiAbout.Text = ld.GetMessageFromDll(_langCode,"tbiAbout");
            btnLoadSetting.Text = ld.GetMessageFromDll(_langCode,"btnLoadSetting");
            btnSaveSetting.Text = ld.GetMessageFromDll(_langCode,"btnSaveSetting");

            lblSerialNumber.Text = ld.GetMessageFromDll(_langCode,"lblSerialNumber");
            lblActiveCode.Text = ld.GetMessageFromDll(_langCode,"lblActiveCode");
            lblClientCount.Text = ld.GetMessageFromDll(_langCode, "lblClientCount");
            lblCustomerName.Text = ld.GetMessageFromDll(_langCode,"lblCustomerName");
            lblBuyDate.Text = ld.GetMessageFromDll(_langCode,"lblBuyDate");
            btnActiveCheck.Text = ld.GetMessageFromDll(_langCode,"btnActiveCheck");
                      
            _customerName = ld.Decrypt(ld.GetDataFromDll("Setting", "CustomerName", "ID = 1"), true, "");
            _serialCode = ld.Decrypt(ld.GetDataFromDll("Setting", "SoftSerialNumber", "ID = 1"), true, "");
            _clientCount = ld.Decrypt(ld.GetDataFromDll("Setting", "ClientsCount", "ID = 1"), true, "");
            _activeCode = ld.GetDataFromDll("Setting", "ActiveCode", "ID = 1");
            _buyDate = ld.GetDataFromDll("Setting", "BuyDate", "ID = 1");
            _readKeyEn = ld.GetDataFromDll("Setting", "ReadKey", "ID = 1");
            _writeKeyEn = ld.GetDataFromDll("Setting", "WriteKey", "ID = 1");
            _settingPassword = ld.Decrypt(ld.GetDataFromDll("Setting", "Password", "ID = 1"), true, "");

        }

        private void FillForm(int IsRegister)
        {
            txbCustomerName.Text = _customerName;
            txbSerialNumber.Text = _serialCode;
            txbClientCount.Text = _clientCount;
            txbBuyDate.Text = _buyDate;
            if (IsRegister == 1)
            {
                txbActiveCode.Text = ld.GetMessageFromDll(_langCode, "txbActiveCodeReg"); 
                txbActiveCode.TextAlign = HorizontalAlignment.Center;
                FillOtherFormControls();
                EnableSettingControls();
            }
            else if (IsRegister != 1)
            {
                txbActiveCode.NullText = ld.GetMessageFromDll(_langCode, "txbActiveCode"); 
                txbActiveCode.Enabled = true;
                DisableSettingControls();
            }
        }

        private void FillOtherFormControls()
        {
            lblSqlServer.Text = ld.GetMessageFromDll(_langCode, "lblSqlServer");
            lblSqlDatabase.Text = ld.GetMessageFromDll(_langCode, "lblSqlDatabase");
            lblSqlUsername.Text = ld.GetMessageFromDll(_langCode, "lblSqlUsername");
            lblSqlPassword.Text = ld.GetMessageFromDll(_langCode, "lblSqlPassword");
            btnTestSqlCon.Text = ld.GetMessageFromDll(_langCode, "btnTestSqlCon");
            lblRemotePassword.Text = ld.GetMessageFromDll(_langCode, "lblRemotePassword");
            lblChatPort.Text = ld.GetMessageFromDll(_langCode, "ChatPortNumber");
            lblReRemotePassword.Text = ld.GetMessageFromDll(_langCode, "lblReRemotePassword");
            chbChatWithOther.Text = ld.GetMessageFromDll(_langCode, "chbChatWithOther");
            chbVideoWithOther.Text = ld.GetMessageFromDll(_langCode, "chbVideoWithOther");
            chbFileTransferWithOther.Text = ld.GetMessageFromDll(_langCode, "chbFileTransferWithOrher");
            chbImageProcessing.Text = ld.GetMessageFromDll(_langCode, "chbImageProcessing");
            grbControlSetting.Text = ld.GetMessageFromDll(_langCode, "grbControlSetting");
            grbNetSetting.Text = ld.GetMessageFromDll(_langCode, "grbNetSetting");
            grbPasswordSetting.Text = ld.GetMessageFromDll(_langCode, "grbPasswordSetting");
            lblSettingPassword.Text = ld.GetMessageFromDll(_langCode, "lblSettingPassword");
            lblReSettingPassword.Text = ld.GetMessageFromDll(_langCode, "lblReSettingPassword");
            lblLockIpAddress.Text = ld.GetMessageFromDll(_langCode, "lblLockIpAddress");
            lblRDPort.Text = ld.GetMessageFromDll(_langCode, "RDPort");
            lblFTPort.Text = ld.GetMessageFromDll(_langCode, "FTPort");
            lblVCPort.Text = ld.GetMessageFromDll(_langCode, "VCPort");
            lblWebinarPort.Text = ld.GetMessageFromDll(_langCode, "WebinarPort");
            lblCMDPort.Text = ld.GetMessageFromDll(_langCode, "CommandPort");
            lblPublicPort.Text = ld.GetMessageFromDll(_langCode, "PublicPort");
            chbAppInstallDisable.Text = ld.GetMessageFromDll(_langCode, "AppInstallDisable");
            chbAppRunDisable.Text = ld.GetMessageFromDll(_langCode, "AppRunDisable");
            chbRegAccessControl.Text = ld.GetMessageFromDll(_langCode, "RegistryDisable");
            chbUsbAccessControl.Text = ld.GetMessageFromDll(_langCode, "UsbDisable");
            chbUsbDataControl.Text = ld.GetMessageFromDll(_langCode, "UsbDataControl");
            chbDisableCrtlAltDel.Text = ld.GetMessageFromDll(_langCode, "DisableCtrlAltDel");
            btnAppList.Text = ld.GetMessageFromDll(_langCode, "ApplicationList");
            lblAddress.Text = ld.GetMessageFromDll(_langCode, "Address");
            lblContactInfo.Text = ld.GetMessageFromDll(_langCode, "ContactNumber");
            lblWebsite.Text = ld.GetMessageFromDll(_langCode, "Website");
            lblEmail.Text = ld.GetMessageFromDll(_langCode, "EmailAddress");
            Copyright.Text = ld.GetMessageFromDll(_langCode, "Copyright");
            Address.Text = ld.GetMessageFromDll(_langCode, "PishgamAddress");
            ContactInfo.Text = ld.GetMessageFromDll(_langCode, "PishgamTel");
            lblVersion.Text = ld.GetMessageFromDll(_langCode, "Version");

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Version.Text = version;

            btnCheckUpdate.Text = ld.GetMessageFromDll(_langCode, "CheckUpdate");
            btnLicense.Text = ld.GetMessageFromDll(_langCode, "ViewLicense");


        }

        
        private void EnableSettingControls()
        {
            imgOk.Visible = true;
            imgError.Visible = false;
            txbActiveCode.ReadOnly = true;
            btnActiveCheck.Enabled = false;
            tbiAgent.Enabled = true;
            tbiLanguage.Enabled = true;
            tbiAccess.Enabled = true;
            tbiSql.Enabled = true;
            btnLoadSetting.Enabled = true;


            chbChatWithOther.Checked = false;
            chbChatWithOther.Enabled = false;

            chbFileTransferWithOther.Checked = false;
            chbFileTransferWithOther.Enabled = false;

            chbImageProcessing.Checked = false;
            chbImageProcessing.Enabled = false;

            chbVideoWithOther.Checked = false;
            chbVideoWithOther.Enabled = false;

            chbAppInstallDisable.Checked = false;
            chbAppInstallDisable.Enabled = false;

            chbAppRunDisable.Checked = false;
            chbAppRunDisable.Enabled = false;

            chbDisableCrtlAltDel.Checked = false;
            chbDisableCrtlAltDel.Enabled = false;

            chbRegAccessControl.Checked = false;
            chbRegAccessControl.Enabled = false;

            chbUsbAccessControl.Checked = false;
            chbUsbAccessControl.Enabled = false;

            chbUsbDataControl.Checked = false;
            chbUsbDataControl.Enabled = false;

            btnAppList.Enabled = false;

            SetLanguageControl(_langCode);

        }

        private void SetLanguageControl(string lang)
        {
            switch (lang)
            {
                case "1":
                    rbtPersian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "2":
                    rbtEnglish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "3":
                    rbtArabic.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "4":
                    rbtArmanian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "5":
                    rbtChinese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "6":
                    rbtDanish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "7":
                    rbtFrench.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "8":
                    rbtGerman.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "9":
                    rbtHungarian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "10":
                    rbtItalian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "11":
                    rbtPortuguese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "12":
                    rbtRomanian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "13":
                    rbtDutch.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "14":
                    rbtNorwegian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "15":
                    rbtRussian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "16":
                    rbtJapanese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "17":
                    rbtKorean.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "18":
                    rbtSpanish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "19":
                    rbtSwedish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "20":
                    rbtTurkish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;
            }

        }
       
        private void DisableSettingControls()
        {
            imgOk.Visible = false;
            txbActiveCode.ReadOnly = false;
            btnActiveCheck.Enabled = true;
            tbiAgent.Enabled = false;
            tbiLanguage.Enabled = false;
            tbiAccess.Enabled = false;
            tbiSql.Enabled = false;
            btnLoadSetting.Enabled = false;
            btnSaveSetting.Enabled = false;
        }

        private void txbActiveCode_TextChanged(object sender, EventArgs e)
        {
            if (txbActiveCode.Text != "")
            {
                imgError.Visible = false;
                btnActiveCheck.Enabled = true;
            }
            else
            {
                imgError.Visible = false;
                imgOk.Visible = false;
                btnActiveCheck.Enabled = false;
            }
        }

        private void btnActiveCheck_Click(object sender, EventArgs e)
        {
            LocalData ld2 = new LocalData();
            _readKeyDe = ld2.Decrypt(_readKeyEn, true, "");
            USBLock ul = new USBLock();
            ul.ReadKey = _readKeyDe;
            _LockSerialNumber = ul.GetSerial();

            string _encrypt = ld2.GetEncrypted(txbActiveCode.Text.Trim(), _serialCode);


            if (_encrypt == _activeCode && _LockSerialNumber != "")
            {
                _isRegister = 1;
                FillOtherFormControls();
                EnableSettingControls();

                _writeKeyDe = ld2.Decrypt(_writeKeyEn, true, "");
                ul.ReadWriteKey = _writeKeyDe;
                string Data = ld2.Encrypt("Register", true, "") + "&&";
                int _lockErr = ul.SetData(Data);
                if (_lockErr != 0)
                {
                    string myMessage = ld2.GetMessageFromDll(_langCode,"Message2");
                    frmShowInfo_RtoL frmInfo = new frmShowInfo_RtoL(_langCode, "", myMessage, 2);
                    frmInfo.ShowDialog();

                }
            }
            else if (_encrypt != _activeCode || _LockSerialNumber == "")
            {
                _isRegister = 0;
                imgError.Visible = true;
                DisableSettingControls();

            }
        }

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.AutoUpgradeEnabled = false;
            openFileDialog1.ValidateNames = true;
            openFileDialog1.FileName = "Agents.dll";
            openFileDialog1.Title = "";
            openFileDialog1.Filter = "Dynamic-link library (*.DLL)| *.dll";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;         

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                if (file.Contains("Agents.dll"))
                {
                    _pathForITComplexSrv = file;
                    GetDataFrom_ITComplexSrv(file);
                    if (_clientCount == _ClientCount_ITComplexSrv)
                    {
                        if (_IsRegister_ITComplexSrv == "0")
                        {

                            string myMessage = ld.GetMessageFromDll(_langCode,"Message3");
                            frmShowInfoSmall_RtoL frmInfo = new frmShowInfoSmall_RtoL(_langCode,myMessage,2);
                            frmInfo.ShowDialog();

                        }
                        SetControlsFromLastSetting();
                    }
                }
                else
                {
                    string myMessage = ld.GetMessageFromDll(_langCode,"Message4");
                    frmShowInfoSmall_RtoL frmInfo = new frmShowInfoSmall_RtoL(_langCode,myMessage,2);
                    frmInfo.ShowDialog();
                }

            }
        }

        private void SetControlsFromLastSetting()
        {
            txbSqlDatabase.Text = _SQLDatabaseName_ITComplexSrv;
            txbSqlPassword.Text = _SQLPassword_ITComplexSrv;
            txbSqlServer.Text = _SQLServerAddress_ITComplexSrv;
            txbSqlUsername.Text = _SQLUsername_ITComplexSrv;

            txbRemotePassword.Text = _AgentPassword_ITComplexSrv;
            txbReRemotePassword.Text = _AgentPassword_ITComplexSrv;

            txbSettingPassword.Text = _settingPassword;
            txbReSettingPassword.Text = _settingPassword;

            if (_ChatPort_ITComplexSrv != "0")
            {
                txbChatPortNumber.Text = _ChatPort_ITComplexSrv;
                rdbTcp.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else if (_UDPPort_ITComplexSrv != "0")
            {
                txbChatPortNumber.Text = _UDPPort_ITComplexSrv;
                rdbUdp.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }

            if (_ChatWithOther_ITComplexSrv == "1")
                chbChatWithOther.Checked = true;
            else if (_ChatWithOther_ITComplexSrv == "0")
                chbChatWithOther.Checked = false;

            if (_VideoConfToOther_ITComplexSrv == "1")
                chbVideoWithOther.Checked = true;
            else if (_VideoConfToOther_ITComplexSrv == "0")
                chbVideoWithOther.Checked = false;

            if (_FileTransferToOther_ITComplexSrv == "1")
                chbFileTransferWithOther.Checked = true;
            else if (_FileTransferToOther_ITComplexSrv == "0")
                chbFileTransferWithOther.Checked = false;

            if (_ImageProccesing_ITComplexSrv == "1")
                chbImageProcessing.Checked = true;
            else if (_ImageProccesing_ITComplexSrv == "0")
                chbImageProcessing.Checked = false;

            if (_UsbAccessControl_ITComplexSrv == "1")
                chbUsbAccessControl.Checked = true;
            else if (_UsbAccessControl_ITComplexSrv == "0")
                chbUsbAccessControl.Checked = false;

            if (_UsbDataControl_ITComplexSrv == "1")
                chbUsbDataControl.Checked = true;
            else if (_UsbDataControl_ITComplexSrv == "0")
                chbUsbDataControl.Checked = false;

            if (_RegAccessControl_ITComplexSrv == "1")
                chbRegAccessControl.Checked = true;
            else if (_RegAccessControl_ITComplexSrv == "0")
                chbRegAccessControl.Checked = false;

            if (_AppInstallDisable_ITComplexSrv == "1")
                chbAppInstallDisable.Checked = true;
            else if (_AppInstallDisable_ITComplexSrv == "0")
                chbAppInstallDisable.Checked = false;

            if (_AppRunDisable_ITComplexSrv == "1")
                chbAppRunDisable.Checked = true;
            else if (_AppRunDisable_ITComplexSrv == "0")
                chbAppRunDisable.Checked = false;

            if (_DisableCtrlAltDel_ITComplexSrv == "1")
                chbDisableCrtlAltDel.Checked = true;
            else if (_DisableCtrlAltDel_ITComplexSrv == "0")
                chbDisableCrtlAltDel.Checked = false;


            txbRDPort.Text = _RDPort_ITComplexSrv ;
            txbFTPort.Text = _FTPort_ITComplexSrv ;
            txbVCPort.Text = _VCPort_ITComplexSrv ;
            txbCMDPort.Text = _CMDPort_ITComplexSrv ;
            txbWebinarPort.Text = _WebinarPort_ITComplexSrv ;
            txbPublicPort.Text = _PublicPort_ITComplexSrv ;
            txbLockIpAddress.Text = _LockIpAddress_ITComplexSrv;        
         

            switch (_LanguageCode_ITComplexSrv)
            {
                case "1":
                    rbtPersian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "2":
                    rbtEnglish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "3":
                    rbtArabic.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "4":
                    rbtArmanian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "5":
                    rbtChinese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "6":
                    rbtDanish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "7":
                    rbtFrench.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "8":
                    rbtGerman.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "9":
                    rbtHungarian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "10":
                    rbtItalian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "11":
                    rbtPortuguese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "12":
                    rbtRomanian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "13":
                    rbtDutch.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "14":
                    rbtNorwegian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "15":
                    rbtRussian.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "16":
                    rbtJapanese.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "17":
                    rbtKorean.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "18":
                    rbtSpanish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "19":
                    rbtSwedish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;

                case "20":
                    rbtTurkish.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                    break;
            }
        }        

        private void GetDataFrom_ITComplexSrv(string FilePath)
        {
            _SQLServerAddress_ITComplexSrv = "";
            _SQLUsername_ITComplexSrv = "";
            _SQLPassword_ITComplexSrv = "";
            _SQLDatabaseName_ITComplexSrv = "";

            _AgentPassword_ITComplexSrv = "";
            _IsRegister_ITComplexSrv = "";


            _UDPPort_ITComplexSrv = "";

            _LanguageCode_ITComplexSrv = "";
            _RigthToLeft_ITComplexSrv = "";

            _ClientCount_ITComplexSrv = "";
            _ChatWithOther_ITComplexSrv = "";
            _FileTransferToOther_ITComplexSrv = "";
            _VideoConfToOther_ITComplexSrv = "";

            _ImageProccesing_ITComplexSrv = "";
            _LockIpAddress_ITComplexSrv = "";

            _ChatPort_ITComplexSrv = "";


            _RDPort_ITComplexSrv = "";
            _FTPort_ITComplexSrv = "";
            _VCPort_ITComplexSrv = "";
            _CMDPort_ITComplexSrv = "";
            _WebinarPort_ITComplexSrv = "";
            _PublicPort_ITComplexSrv = "";

            _UsbAccessControl_ITComplexSrv = "";
            _UsbDataControl_ITComplexSrv = "";
            _RegAccessControl_ITComplexSrv = "";
            _AppInstallDisable_ITComplexSrv = "";
            _AppRunDisable_ITComplexSrv = "";
            _DisableCtrlAltDel_ITComplexSrv = "";


            LocalData ld4 = new LocalData(FilePath);

            _SQLServerAddress_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "SQLServerAddress", "ID = 1");
            _SQLUsername_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "SQLUsername", "ID = 1");
            _SQLPassword_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "SQLPassword", "ID = 1");
            _SQLDatabaseName_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "SQLDatabaseName", "ID = 1");

            _AgentPassword_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "AgentPassword", "ID = 1");
            _IsRegister_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "IsRegister", "ID = 1");

            _ChatPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "ChatPort", "ID = 1");

            _UDPPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "UDPPort", "ID = 1");

            _LanguageCode_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "LanguageCode", "ID = 1");
            _RigthToLeft_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "RigthToLeft", "ID = 1");

            _ClientCount_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "ClientCount", "ID = 1");
            _ChatWithOther_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "ChatWithOther", "ID = 1");
            _FileTransferToOther_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "FileTransferToOther", "ID = 1");
            _VideoConfToOther_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "VideoConfToOther", "ID = 1");


            _ImageProccesing_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "ImageProccesing", "ID = 1");
            _LockIpAddress_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "LockIpAddress", "ID = 1");

            _RDPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "RemoteDesktopPort", "ID = 1");
            _FTPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "FileTransferPort", "ID = 1");
            _VCPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "VideoConfPort", "ID = 1");
            _CMDPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "CMDPort", "ID = 1");
            _WebinarPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "WebinarPort", "ID = 1");
            _PublicPort_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "PublicPort", "ID = 1");

            _UsbAccessControl_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "UsbAccessControl", "ID = 1");
            _UsbDataControl_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "UsbDataControl", "ID = 1");
            _RegAccessControl_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "RegAccessControl", "ID = 1");
            _AppInstallDisable_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "AppInstallDisable", "ID = 1");
            _AppRunDisable_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "AppRunDisable", "ID = 1");
            _DisableCtrlAltDel_ITComplexSrv = ld4.GetDataFromDll("AgentSetting", "DisableCtrlAltDel", "ID = 1");
        }

        private void frmMain_RtoL_Shown(object sender, EventArgs e)
        {
            if (_isRegister == 0)
            {                
                string myMessage1 = ld.GetMessageFromDll(_langCode,"Message1-1");
                string myMessage2 = ld.GetMessageFromDll(_langCode,"Message1-2");
                frmShowInfo_RtoL frmInfo = new frmShowInfo_RtoL(_langCode, myMessage1, myMessage2, 2);
                frmInfo.ShowDialog();
            }
        }

        private void btnTestSqlCon_Click(object sender, EventArgs e)
        {
            TestSqlConnectionString();
        }

        private void UpdateProfileSettingInSql(string UsbAccessControl, string UsbDataControl, string RegAccessControl, string AppInstallDisable,
                                               string AgentPassword, string ChatWithOther, string VideoWithOther, string FileTransferWithOther,
                                               string ImageProcessing, string RDPort, string ChatPort, string FTPort, string VCPort, string CMDPort,
                                               string WebinarPort, string PublicPort, string DisableCtrlAltDel, string AppDisableRun)
        {
            string[,] newparams = new string[18, 2];

            newparams[0, 0] = "@UsbAccessControl";
            newparams[0, 1] = UsbAccessControl;

            newparams[1, 0] = "@UsbDataControl";
            newparams[1, 1] = UsbDataControl;

            newparams[2, 0] = "@RegAccessControl";
            newparams[2, 1] = RegAccessControl;

            newparams[3, 0] = "@AppInstallDisable";
            newparams[3, 1] = AppInstallDisable;

            newparams[4, 0] = "@AgentPassword";
            newparams[4, 1] = AgentPassword;
          
            newparams[5, 0] = "@ChatWithOther";
            newparams[5, 1] = ChatWithOther;

            newparams[6, 0] = "@VideoWithOther";
            newparams[6, 1] = VideoWithOther;

            newparams[7, 0] = "@FileTransferWithOther";
            newparams[7, 1] = FileTransferWithOther;

            newparams[8, 0] = "@ImageProcessing";
            newparams[8, 1] = ImageProcessing;

            newparams[9, 0] = "@RDPort";
            newparams[9, 1] = RDPort;

            newparams[10, 0] = "@ChatPort";
            newparams[10, 1] = ChatPort;

            newparams[11, 0] = "@FTPort";
            newparams[11, 1] = FTPort;

            newparams[12, 0] = "@VCPort";
            newparams[12, 1] = VCPort;

            newparams[13, 0] = "@CMDPort";
            newparams[13, 1] = CMDPort;

            newparams[14, 0] = "@WebinarPort";
            newparams[14, 1] = WebinarPort;

            newparams[15, 0] = "@PublicPort";
            newparams[15, 1] = PublicPort;

            newparams[16, 0] = "@DisableCtrlAltDel";
            newparams[16, 1] = DisableCtrlAltDel;

            newparams[17, 0] = "@AppDisableRun";
            newparams[17, 1] = AppDisableRun;    


            IntExcuteSP(newparams);


        }

        private void IntExcuteSP(string[,] SpParams)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlConnection;
                SqlCommand _sqlCommand;
                string _connectionString = "user id = " + txbSqlUsername.Text.Trim() + ";password = " + txbSqlPassword.Text.Trim() + ";server = " + txbSqlServer.Text.Trim() + ";database = " + txbSqlDatabase.Text.Trim();
                _sqlConnection = new SqlConnection();
                _sqlConnection.ConnectionString = _connectionString;
                _sqlCommand = new SqlCommand("prcUpdateSettingProfileFromConfigure", _sqlConnection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                _sqlCommand.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlConnection.Open();
                _sqlCommand.ExecuteReader();
                _sqlConnection.Close();

                _result = Convert.ToInt32(_sqlCommand.Parameters["@Result"].Value.ToString());


            }
            catch (SqlException)
            {

            }
        }

        private void TestSqlConnectionString()
        {
            if (txbSqlServer.Text.Trim().ToLower() == "localhost" || txbSqlServer.Text.Trim() == "127.0.0.1")
            {
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = ToolTipIcon.Error;
                toolTip1.SetToolTip(this.imgSqlError, GetToolTipMessage("ErrorSqlConnection"));
                _isSqlConRigth = false;
                imgSqlError.Visible = true;
                imgSqlOk.Visible = false;

            }
            else
            {
                string ConnectionString;
                ConnectionString = "user id = " + txbSqlUsername.Text.Trim() + ";password = " + txbSqlPassword.Text.Trim() + ";server = " + txbSqlServer.Text.Trim() + ";database = " + txbSqlDatabase.Text.Trim(); 
                SqlConnection _sqlConnection = new SqlConnection(ConnectionString);
                try
                {
                    _sqlConnection.Open();
                    _isSqlConRigth = true;
                    imgSqlError.Visible = false;
                    imgSqlOk.Visible = true;

                }
                catch (SqlException)
                {
                    toolTip1.IsBalloon = true;
                    toolTip1.ToolTipIcon = ToolTipIcon.Error;
                    toolTip1.SetToolTip(this.imgSqlError, GetToolTipMessage("ErrorSqlConnection"));
                    _isSqlConRigth = false;
                    imgSqlError.Visible = true;
                    imgSqlOk.Visible = false;


                }
            }
        }

        private void txbSqlServer_TextChanged(object sender, EventArgs e)
        {           
            SqlConectionItemsChanged();
        }

        private void txbSqlDatabase_TextChanged(object sender, EventArgs e)
        {           
            SqlConectionItemsChanged();
        }

        private void txbSqlUsername_TextChanged(object sender, EventArgs e)
        {           
            SqlConectionItemsChanged();
        }

        private void txbSqlPassword_TextChanged(object sender, EventArgs e)
        {           
            SqlConectionItemsChanged();
        }

        private void SqlConectionItemsChanged()
        {
            imgSqlOk.Visible = false;
            imgSqlError.Visible = false;
            _isSqlConRigth = false;
            this.IsSaveSetting = false;
        }

        private void frmMain_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (NowExit == false)
                {
                    if (_isSettingSaved == false)
                    {
                        LocalData ld7 = new LocalData();
                        string _message2 = ld7.GetMessageFromDll(_langCode, "Message5");
                        frmShowInfoSmall_RtoL fshow = new frmShowInfoSmall_RtoL(_langCode, _message2, 6);


                        DialogResult dr = fshow.ShowDialog();
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            _saveYes = true;
                            StartSaveSetting();

                        }
                        else if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            NowExit = true;
                            DoExit();
                        }
                        else if (dr == System.Windows.Forms.DialogResult.Cancel)
                        {
                            e.Cancel = true;

                        }
                    }
                    else
                    {
                        LocalData ld7 = new LocalData();
                        string _message2 = ld7.GetMessageFromDll(_langCode, "Message6");
                        frmShowInfoSmall_RtoL fshow = new frmShowInfoSmall_RtoL(_langCode, _message2, 3);
                        DialogResult dr = fshow.ShowDialog();
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            NowExit = true;
                            DoExit();
                        }
                        else if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            e.Cancel = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void DoExit()
        {
            GC.Collect();
            this.Close();
            Environment.Exit(0);
        } 

        private void StartSaveSetting()
        {
            // save start when _isAllValid == true
            if (_isAllValid == true)
            {
                DoSaveNow();
            }
            else
            {
                btnSaveSetting.Enabled = false;
                _isSettingSaved = true;
                LocalData ld = new LocalData();
                string Mes = ld.GetMessageFromDll(_langCode,"ErrorsExist");
                frmShowInfoSmall_RtoL fr = new frmShowInfoSmall_RtoL(_langCode,Mes,2);
                fr.ShowDialog();
            }
        }

           
        private void DoSaveNow()
        {
            LocalData ld9 = new LocalData();
            string _message2 = ld9.GetMessageFromDll(_langCode,"Message7");
            if (_saveYes == false)
            {
                frmShowInfoSmall_RtoL fsh = new frmShowInfoSmall_RtoL(_langCode,_message2,3);
                DialogResult dr = fsh.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    DoSaveSetting();

                }
            }
            else
            {
                DoSaveSetting();
            }
        }

        private string OpenSaveFileDialog()
        {
            string _path = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.AutoUpgradeEnabled = false;
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = false;
            saveFileDialog1.OverwritePrompt = false;

            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "Dynamic-link library (*.DLL)| *.dll";
            saveFileDialog1.FileName = "Agents.dll";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = saveFileDialog1.FileName;
                if (file.Contains("Agents.dll"))
                {
                    _path = file;

                }
                else
                {
                    LocalData ld6 = new LocalData();
                    string myMessage = ld6.GetMessageFromDll(_langCode,"Message4");
                    frmShowInfoSmall_RtoL frmInfo = new frmShowInfoSmall_RtoL(_langCode,myMessage,2);
                    frmInfo.ShowDialog();
                    _path = "";

                }
            }
            else
                _path = "";
            return _path;
        }

        private void DoSaveSettingNow(string Path)
        {
            LocalData ldd = new LocalData(Path);
            Encrypter encr = new Encrypter();

            string SQLServerAddress = txbSqlServer.Text.Trim();
            string SQLUsername = txbSqlUsername.Text.Trim();
            string SQLPassword = txbSqlPassword.Text.Trim();
            string SQLDatabaseName = txbSqlDatabase.Text.Trim();

            string AgentPassword = encr.Encrypt(txbRemotePassword.Text.Trim());
            string IsRegister = Convert.ToString(_isRegister);



            string ChatPort = txbChatPortNumber.Text.Trim();            
            string RDPort = txbRDPort.Text.Trim();
            string FTPort = txbFTPort.Text.Trim();
            string VCPort = txbVCPort.Text.Trim();
            string WebinarPort = txbWebinarPort.Text.Trim();
            string CMDPort = txbCMDPort.Text.Trim();
            string PublicPort = txbPublicPort.Text.Trim();                      

            string LanguageCode = "";
            string Rigth2Left = "";

            if (rbtPersian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "1";

            else if (rbtEnglish.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "2";

            else if (rbtArabic.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "3";

            else if (rbtArmanian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "4";

            else if (rbtChinese.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "5";
            else if (rbtDanish.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "6";
            else if (rbtFrench.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "7";
            else if (rbtGerman.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "8";
            else if (rbtHungarian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "9";
            else if (rbtItalian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "10";
            else if (rbtPortuguese.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "11";
            else if (rbtRomanian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "12";
            else if (rbtDutch.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "13";
            else if (rbtNorwegian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "14";
            else if (rbtRussian.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "15";
            else if (rbtJapanese.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "16";
            else if (rbtKorean.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "17";
            else if (rbtSpanish.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "18";
            else if (rbtSwedish.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "19";
            else if (rbtTurkish.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                LanguageCode = "20";

            if (LanguageCode == "1" || LanguageCode == "3")
                Rigth2Left = "1";
            else
                Rigth2Left = "0";


           


            string ChatWithOther = "";
            if (chbChatWithOther.Checked == true)
                ChatWithOther = "1";
            else if (chbChatWithOther.Checked == false)
                ChatWithOther = "0";

            string FileTransferToOther = "";
            if (chbFileTransferWithOther.Checked == true)
                FileTransferToOther = "1";
            else if (chbFileTransferWithOther.Checked == false)
                FileTransferToOther = "0";

            string VideoConfToOther = "";
            if (chbVideoWithOther.Checked == true)
                VideoConfToOther = "1";
            else if (chbVideoWithOther.Checked == false)
                VideoConfToOther = "0";           

            string ImageProccesing = "";
            if (chbImageProcessing.Checked == true)
                ImageProccesing = "1";
            else if (chbImageProcessing.Checked == false)
                ImageProccesing = "0";        

            string UsbAccessControl = "";
            if (chbUsbAccessControl.Checked == true)
                UsbAccessControl = "1";
            else if (chbUsbAccessControl.Checked == false)
                UsbAccessControl = "0";

            string UsbDataControl = "";
            if (chbUsbDataControl.Checked == true)
                UsbDataControl = "1";
            else if (chbUsbDataControl.Checked == false)
                UsbDataControl = "0";

            string RegAccessControl = "";
            if (chbRegAccessControl.Checked == true)
                RegAccessControl = "1";
            else if (chbRegAccessControl.Checked == false)
                RegAccessControl = "0";

            string AppInstallDisable = "";
            if (chbAppInstallDisable.Checked == true)
                AppInstallDisable = "1";
            else if (chbAppInstallDisable.Checked == false)
                AppInstallDisable = "0";

            string AppRunDisable = "";
            if (chbAppRunDisable.Checked == true)
                AppRunDisable = "1";
            else if (chbAppRunDisable.Checked == false)
                AppRunDisable = "0";

            string DisableCtrlAltDel = "";
            if (chbDisableCrtlAltDel.Checked == true)
                DisableCtrlAltDel = "1";
            else if (chbDisableCrtlAltDel.Checked == false)
                DisableCtrlAltDel = "0";

            string LockIpAddress = txbLockIpAddress.Text.Trim();


            string Query = "UPDATE AgentSetting SET SQLServerAddress = '" + SQLServerAddress + "',SQLUsername ='" + SQLUsername + "',SQLPassword ='" + SQLPassword + "',SQLDatabaseName ='" + SQLDatabaseName +
                           "',AgentPassword ='" + AgentPassword + "',IsRegister ='" + IsRegister + "',CMDPort ='" + CMDPort + "',WebinarPort ='" + WebinarPort +
                           "',PublicPort ='" + PublicPort + "',UsbAccessControl ='" + UsbAccessControl + "',UsbDataControl ='" + UsbDataControl +
                           "',ChatPort ='" + ChatPort + "',RegAccessControl ='" + RegAccessControl + "',AppInstallDisable ='" + AppInstallDisable + "',LanguageCode ='" + LanguageCode +
                           "',RigthToLeft ='" + Rigth2Left + "',AppRunDisable ='" + AppRunDisable + "',ChatWithOther ='" + ChatWithOther + "',FileTransferToOther ='" + FileTransferToOther +
                           "',VideoConfToOther ='" + VideoConfToOther + "',DisableCtrlAltDel ='" + DisableCtrlAltDel + "',ImageProccesing ='" + ImageProccesing + "',LockIpAddress ='" + LockIpAddress +
                           "',RemoteDesktopPort ='" + RDPort + "',FileTransferPort ='" + FTPort + "',VideoConfPort ='" + VCPort +
                           "' WHERE ID = 1";

            ldd.ExecuteQuery(Query);

            UpdateProfileSettingInSql(UsbAccessControl,UsbDataControl,RegAccessControl,AppInstallDisable,AgentPassword,ChatWithOther,VideoConfToOther,
                                      FileTransferToOther,ImageProccesing,RDPort,ChatPort,FTPort,VCPort,CMDPort,WebinarPort,PublicPort,
                                      DisableCtrlAltDel,AppRunDisable);


            LocalData ld12 = new LocalData();

            /* Save EditAgent.dll */

            SaveConfiguer(LanguageCode, Rigth2Left);


            /* Save Sql Connection String to Lock*/

            USBLock ul = new USBLock();
            ul.ReadWriteKey = ld12.Decrypt(ld12.GetDataFromDll("Setting", "WriteKey", "ID = 1"), true, "");
            ul.LockIPAddress = LockIpAddress;
            string ConnectionString = "user id = " + txbSqlUsername.Text.Trim() + ";password = " + txbSqlPassword.Text.Trim() + ";server = " + txbSqlServer.Text.Trim() + ";database = " + txbSqlDatabase.Text.Trim();
            string _enData = ld12.Encrypt("Register", true, "") + "&&" + ld12.Encrypt(ConnectionString, true, "");
            int err = ul.SetData(_enData);


            if (err == 0)
            {
                string mes = ld12.GetMessageFromDll(_langCode,"SaveOk");
                frmShowInfoSmall_RtoL frsh = new frmShowInfoSmall_RtoL(_langCode,mes,3);

                DialogResult dr = frsh.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    btnSaveSetting.Enabled = false;
                    _isSettingSaved = true;
                }
            }
            else
            {
                string mes = ld12.GetMessageFromDll(_langCode,"Message2");
                frmShowInfo_RtoL frsh = new frmShowInfo_RtoL(_langCode, "", mes, 2);

                DialogResult dr = frsh.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    Environment.Exit(0);
                }

            }

        }

        private void DoSaveSetting()
        {            
            string _path = "";
            if (_pathForITComplexSrv == "")
            {
                if (File.Exists(Environment.CurrentDirectory + "\\Agents.dll"))
                {
                    _path = Environment.CurrentDirectory + "\\Agents.dll";
                }
            
                else
                {
                   _path = OpenSaveFileDialog();

                }
            }
            else
            {
                _path = _pathForITComplexSrv;
            }

            if (_path != "")
            {
                DoSaveSettingNow(_path);
            }          

        }

        private void SaveConfiguer(string LanguageCode, string Rigth2Left)
        {
            string Password_en = ld.Encrypt(txbSettingPassword.Text.Trim(), true, "");
            string LanguageCode_en = ld.Encrypt(LanguageCode, true, "");
            string RightToleft_en = ld.Encrypt(Rigth2Left, true, "");
            string LockIp = txbLockIpAddress.Text.Trim();
            string Port = txbChatPortNumber.Text.Trim();
            string RDPort = txbRDPort.Text.Trim();
            string FTPort = txbFTPort.Text.Trim();
            string VCPort = txbVCPort.Text.Trim();
            string CMDPort = txbCMDPort.Text.Trim();
            string WebinarPort = txbWebinarPort.Text.Trim();
            string PublicPort = txbPublicPort.Text.Trim();


            string Query2 = "UPDATE Setting SET [Port] = '" + Port + "',[Password] = '" + Password_en + "',[RightToleft] = '" + RightToleft_en + "',[LanguageCode] = '" + LanguageCode_en +"',[LockIPAddress] = '" + LockIp +
                            "',[RDPort] = '" + RDPort +
                            "',[FTPort] = '" + FTPort +
                            "',[VCPort] = '" + VCPort +
                            "',[CMDPort] = '" + CMDPort +
                            "',[WebinarPort] = '" + WebinarPort +
                            "',[PublicPort] = '" + PublicPort +
                            "' WHERE ID = 1";
            ld.ExecuteQuery(Query2);
            
        }
      

       

        private void txbSettingPassword_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
        }

        private void txbReSettingPassword_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
            erpReSettingPassword.Clear();
        }

        private void txbSmsNumber_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
        }

        private void txbMailAddress_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
        }

        private void txbMailServerAddress_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
        }

        private void txbRemotePassword_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;            
        }

        private void txbReRemotePassword_TextChanged(object sender, EventArgs e)
        {
            this.IsSaveSetting = false;
            erpReRemotePassword.Clear();
        }

        private void rdbTcp_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rdbUdp_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbHardwareCtr_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbSoftwareCtr_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbNetworkCtr_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbAccountCtr_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbChatWithOther_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbVideoWithOther_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbFileTransferWithOrher_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbImageProcessing_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbSendSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void chbSendMail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtPersian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtEnglish_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtArabic_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtArmanian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtChinese_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtDanish_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtFrench_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtGerman_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtHungarian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtItalian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtPortuguese_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtRomanian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtDutch_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtNorwegian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtRussian_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtJapanese_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtKorean_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtSpanish_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtSwedish_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void rbtTurkish_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.IsSaveSetting = false;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            CheckValidation();
            StartSaveSetting();
        }

        private void CheckValidation()
        {
            _isAllValid = true;
            LocalData ld = new LocalData();

            if (_isSqlConRigth == false)
            {
                _isAllValid = false;
                string _mesage1 = ld.GetMessageFromDll(_langCode,"ErrorSqlConnection");
            }
            if (txbRemotePassword.Text.Trim() != txbReRemotePassword.Text.Trim() || txbRemotePassword.Text.Trim() == "")
            {
                _isAllValid = false;
                string _mesage2 = ld.GetMessageFromDll(_langCode,"ErrorPasswordConfirm");
            }
            int _portNumber = Convert.ToInt32(txbChatPortNumber.Text.Trim());
            if (_portNumber < 1 && _portNumber > 65535)
            {
                _isAllValid = false;
                string _mesage3 = ld.GetMessageFromDll(_langCode,"ErrorPortNumber");
            }

            if (txbSettingPassword.Text.Trim() != txbReSettingPassword.Text.Trim() || txbReSettingPassword.Text.Trim() == "")
            {
                _isAllValid = false;
                string _mesage4 = ld.GetMessageFromDll(_langCode,"ErrorPasswordConfirm"); 
            }

            if (IsValidIP(txbLockIpAddress.Text.Trim()) == false)
            {
                _isAllValid = false;
                string _mesage5 = ld.GetMessageFromDll(_langCode,"ErrorIpAddress");
            }

        }

        private void txbPortNumber_Validating(object sender, CancelEventArgs e)
        {
            LocalData ld = new LocalData();
            int _port = 0;
            if (txbChatPortNumber.Text.Trim() == "")
            {
                txbChatPortNumber.Text = "4242";
            }

            _port = Convert.ToInt32(txbChatPortNumber.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpPortNumber.SetError(txbChatPortNumber, ld.GetMessageFromDll(_langCode,"ErrorPortNumber"));
            }
            else
            {
                erpPortNumber.Clear();
                _isPortNumberRight = true;
            }
        }

        private void txbPortNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;

            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        public bool IsValidIP(string addr)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (addr == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(addr, 0);
            }
            //return the results
            return valid;
        }

      

        private void txbLockIpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            erpLockIp.Clear();
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }

        }

        private void txbLockIpAddress_Validating(object sender, CancelEventArgs e)
        {
            LocalData ld = new LocalData();
            bool _isIpValid;
            _isIpValid = IsValidIP(txbLockIpAddress.Text.Trim());
            if (_isIpValid == false || txbLockIpAddress.Text.Trim() == "127.0.0.1")
            {
                _isIpAddressRight = false;
                erpLockIp.SetError(txbLockIpAddress, ld.GetMessageFromDll(_langCode,"ErrorIpAddress"));
            }
            else
            {
                _isIpAddressRight = true;
                erpLockIp.Clear();
            }
            
        }

        private void txbAdminIpAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }

        }

      

        private string GetToolTipMessage(string ChildControl)
        {           
            string m = ld.GetMessageFromDll(_langCode,ChildControl);
            return m;

        }

        private void txbSqlServer_Validating(object sender, CancelEventArgs e)
        {
            if (txbSqlServer.Text.Trim().ToLower() == "localhost" || txbSqlServer.Text.Trim() == "127.0.0.1")
            {
                LocalData ld = new LocalData();
                erpSqlServer.SetError(txbSqlServer, ld.GetMessageFromDll(_langCode,"ErrorSqlServer"));
            }
            else
            {
                erpSqlServer.Clear();
            }
        }

        private void txbReRemotePassword_Validating(object sender, CancelEventArgs e)
        {
            if (txbReRemotePassword.Text.Trim() != txbRemotePassword.Text.Trim())
            {
                LocalData ld = new LocalData();
                erpReRemotePassword.SetError(txbReRemotePassword, ld.GetMessageFromDll(_langCode,"ErrorPasswordConfirm"));
                _isPasswordConfirm = false;
            }
            else
            {
                _isPasswordConfirm = true;
                erpReRemotePassword.Clear();
            }
        }

        private void txbReSettingPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txbReSettingPassword.Text.Trim() != txbSettingPassword.Text.Trim())
            {
                LocalData ld = new LocalData();
                erpReSettingPassword.SetError(txbReSettingPassword, ld.GetMessageFromDll(_langCode,"ErrorPasswordConfirm"));
                _isPasswordConfirm = false;
            }
            else
            {
                _isPasswordConfirm = true;
                erpReSettingPassword.Clear();
            }
        }

       

        private void txbSqlPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTestSqlCon_Click(sender, e);
            }
        }

       
       

      
       

        private void tbiSql_Paint(object sender, PaintEventArgs e)
        {
            txbSqlServer.Focus();
        }

        private void tbiAgent_Paint(object sender, PaintEventArgs e)
        {
            txbLockIpAddress.Focus();
        }

       
        private void txbRDPort_Validating(object sender, CancelEventArgs e)
        {
            LocalData ld = new LocalData();
            int _port = 0;
            if (txbRDPort.Text.Trim() == "")
            {
                txbRDPort.Text = "6001";
            }

            _port = Convert.ToInt32(txbRDPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpRDPort.SetError(txbRDPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpRDPort.Clear();
                _isPortNumberRight = true;
            }
        }

        private void txbFTPort_Validating(object sender, CancelEventArgs e)
        {
            LocalData ld = new LocalData();
            int _port = 0;
            if (txbFTPort.Text.Trim() == "")
            {
                txbFTPort.Text = "8001";
            }

            _port = Convert.ToInt32(txbFTPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpFTPort.SetError(txbFTPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpFTPort.Clear();
                _isPortNumberRight = true;
            }

        }

        private void txbVCPort_Validating(object sender, CancelEventArgs e)
        {
            LocalData ld = new LocalData();
            int _port = 0;
            if (txbVCPort.Text.Trim() == "")
            {
                txbVCPort.Text = "7001";
            }

            _port = Convert.ToInt32(txbVCPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpVCPort.SetError(txbVCPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpVCPort.Clear();
                _isPortNumberRight = true;
            }

        }

        private void txbRDPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            erpRDPort.Clear();
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
            this.IsSaveSetting = false;
            erpFTPort.Clear();

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
            this.IsSaveSetting = false;
            erpVCPort.Clear();
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbCMDPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            erpVCPort.Clear();
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
            this.IsSaveSetting = false;
            erpVCPort.Clear();
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbPublicPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            erpVCPort.Clear();
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbChatPortNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.IsSaveSetting = false;
            erpVCPort.Clear();
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void txbPublicPort_Validating(object sender, CancelEventArgs e)
        {           
            int _port = 0;
            if (txbPublicPort.Text.Trim() == "")
            {
                txbPublicPort.Text = "4001";
            }

            _port = Convert.ToInt32(txbPublicPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpVCPort.SetError(txbPublicPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpVCPort.Clear();
                _isPortNumberRight = true;
            }
        }

        private void txbWebinarPort_Validating(object sender, CancelEventArgs e)
        {
            int _port = 0;
            if (txbWebinarPort.Text.Trim() == "")
            {
                txbWebinarPort.Text = "10001";
            }

            _port = Convert.ToInt32(txbWebinarPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpVCPort.SetError(txbWebinarPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpVCPort.Clear();
                _isPortNumberRight = true;
            }
        }

        private void txbCMDPort_Validating(object sender, CancelEventArgs e)
        {
            int _port = 0;
            if (txbCMDPort.Text.Trim() == "")
            {
                txbCMDPort.Text = "9001";
            }

            _port = Convert.ToInt32(txbCMDPort.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpVCPort.SetError(txbCMDPort, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpVCPort.Clear();
                _isPortNumberRight = true;
            }
        }

        private void txbChatPortNumber_Validating(object sender, CancelEventArgs e)
        {
            int _port = 0;
            if (txbChatPortNumber.Text.Trim() == "")
            {
                txbChatPortNumber.Text = "5001";
            }

            _port = Convert.ToInt32(txbChatPortNumber.Text.Trim());

            if (_port < 1 || _port > 65535)
            {
                _isPortNumberRight = false;
                erpVCPort.SetError(txbChatPortNumber, ld.GetMessageFromDll(_langCode, "ErrorPortNumber"));
            }
            else
            {
                erpVCPort.Clear();
                _isPortNumberRight = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.papc.ir");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:info@papc.ir");
        }

        

       
            
    }
}
