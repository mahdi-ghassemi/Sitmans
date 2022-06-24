using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Telerik.WinControls.UI;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAlertProfile_RtoL : Telerik.WinControls.UI.RadForm
    {
        //private List<AlertProfile> HardwaresAlertList;
        private LogicLayer lg;
        private string _langCode;
        private string _SelectedProfileId;
        private bool _SqlError;
        private bool _errorProvider;


        /* Header Text */
        private string headerSubject;
        private string headerIcon;
        private string headerDesktop;
        private string headerSms;
        private string headerEmail;
        private string headerSound;
        private string headerSoundPath;
        private string headerNo;

        /* Events Text */

        private string lblCpuChanges;
        private string lblMainboard;
        private string lblBios;
        private string lblCdrom;
        private string lblHardDisk;
        private string lblKeyboard;
        private string lblLogicDisk;
        private string lblMemory;
        private string lblModem;
        private string lblMonitor;
        private string lblMouse;
        private string lblNetAdapter;
        private string lblPrinter;
        private string lblScaner;
        private string lblVideoCard;
        private string lblWebcam;

        private string lblAppChanges;
        private string lblOs;
        private string lblUpdates;
        private string lblIp;
        private string lblSubnet;
        private string lblGw;
        private string lblMac;
        private string lblDhcp;
        private string lblDns;
        private string lblPower;
        private string lblFlash;
        private string lblUserAccount;
        private string lblGroupAccount;

        private string lblChassis;
        private string lblSystemProperties;
        private string lblActiveNetwork;

      

        /* Grid View Rows Varible */

        private string EventLable;
        private bool IIcon;
        private bool Desktop;
        private bool Sms;
        private bool Email;
        private bool Sound;
        private string SoundFilePath;
        private bool No;

        /* Grid View Rows Varible For Update and Insert in SQL */

        private int _AlertId;
        private string _SubjectId;
        private string _Sound;
        private string _SoundFilePath;
        private string _SubjectGroup;
        private string _SubjectDes;


        public frmAlertProfile_RtoL()
        {
            _langCode = Program.LangCode.ToString();
            lg = new LogicLayer();
            _SqlError = false;
            InitializeComponent();
        }

        private void frmAlertProfile_RtoL_Load(object sender, EventArgs e)
        {            
            SetFormMessages();
            SetGridViews();
            FillProfileList();
        }

        private void SetGridViews()
        {
            grvHardwares.GridViewElement.ShowGroupPanel = false;
            grvHardwares.AutoScroll = false;
            grvHardwares.Columns["Subject"].HeaderText = headerSubject;
            grvHardwares.Columns["Icon"].HeaderText = headerIcon;
            grvHardwares.Columns["Desktop"].HeaderText = headerDesktop;
            grvHardwares.Columns["SMS"].HeaderText = headerSms;
            grvHardwares.Columns["EMail"].HeaderText = headerEmail;
            grvHardwares.Columns["Sound"].HeaderText = headerSound;
            grvHardwares.Columns["SoundBrowse"].HeaderText = headerSoundPath;
            grvHardwares.Columns["NoAlarm"].HeaderText = headerNo;

            grvHardwares.Columns["Subject"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["Icon"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["Desktop"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["SMS"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["EMail"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["Sound"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["SoundBrowse"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvHardwares.Columns["NoAlarm"].HeaderTextAlignment = ContentAlignment.MiddleCenter;

            grvHardwares.Columns["SMS"].IsVisible = false;
            grvHardwares.Columns["EMail"].IsVisible = false;
            grvHardwares.Columns["Sound"].IsVisible = false;
            grvHardwares.Columns["SoundBrowse"].IsVisible = false;
            grvHardwares.Columns["SubjectId"].IsVisible = false;
            grvHardwares.Columns["NoAlarm"].IsVisible = false;

            grvSoftwares.GridViewElement.ShowGroupPanel = false;
            grvSoftwares.Columns["Subject"].HeaderText = headerSubject;
            grvSoftwares.Columns["Icon"].HeaderText = headerIcon;
            grvSoftwares.Columns["Desktop"].HeaderText = headerDesktop;
            grvSoftwares.Columns["SMS"].HeaderText = headerSms;
            grvSoftwares.Columns["EMail"].HeaderText = headerEmail;
            grvSoftwares.Columns["Sound"].HeaderText = headerSound;
            grvSoftwares.Columns["SoundBrowse"].HeaderText = headerSoundPath;
            grvSoftwares.Columns["NoAlarm"].HeaderText = headerNo;

            grvSoftwares.Columns["Subject"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["Icon"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["Desktop"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["SMS"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["EMail"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["Sound"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["SoundBrowse"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvSoftwares.Columns["NoAlarm"].HeaderTextAlignment = ContentAlignment.MiddleCenter;

            grvSoftwares.Columns["SMS"].IsVisible = false;
            grvSoftwares.Columns["EMail"].IsVisible = false;
            grvSoftwares.Columns["Sound"].IsVisible = false;
            grvSoftwares.Columns["SoundBrowse"].IsVisible = false;
            grvSoftwares.Columns["SubjectId"].IsVisible = false;
            grvSoftwares.Columns["NoAlarm"].IsVisible = false;

            grvNetwork.GridViewElement.ShowGroupPanel = false;
            grvNetwork.Columns["Subject"].HeaderText = headerSubject;
            grvNetwork.Columns["Icon"].HeaderText = headerIcon;
            grvNetwork.Columns["Desktop"].HeaderText = headerDesktop;
            grvNetwork.Columns["SMS"].HeaderText = headerSms;
            grvNetwork.Columns["EMail"].HeaderText = headerEmail;
            grvNetwork.Columns["Sound"].HeaderText = headerSound;
            grvNetwork.Columns["SoundBrowse"].HeaderText = headerSoundPath;
            grvNetwork.Columns["NoAlarm"].HeaderText = headerNo;

            grvNetwork.Columns["Subject"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["Icon"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["Desktop"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["SMS"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["EMail"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["Sound"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["SoundBrowse"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvNetwork.Columns["NoAlarm"].HeaderTextAlignment = ContentAlignment.MiddleCenter;

            grvNetwork.Columns["SMS"].IsVisible = false;
            grvNetwork.Columns["EMail"].IsVisible = false;
            grvNetwork.Columns["Sound"].IsVisible = false;
            grvNetwork.Columns["SoundBrowse"].IsVisible = false;
            grvNetwork.Columns["SubjectId"].IsVisible = false;
            grvNetwork.Columns["NoAlarm"].IsVisible = false;

            grvPublic.GridViewElement.ShowGroupPanel = false;
            grvPublic.Columns["Subject"].HeaderText = headerSubject;
            grvPublic.Columns["Icon"].HeaderText = headerIcon;
            grvPublic.Columns["Desktop"].HeaderText = headerDesktop;
            grvPublic.Columns["SMS"].HeaderText = headerSms;
            grvPublic.Columns["EMail"].HeaderText = headerEmail;
            grvPublic.Columns["Sound"].HeaderText = headerSound;
            grvPublic.Columns["SoundBrowse"].HeaderText = headerSoundPath;
            grvPublic.Columns["NoAlarm"].HeaderText = headerNo;

            grvPublic.Columns["Subject"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["Icon"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["Desktop"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["SMS"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["EMail"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["Sound"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["SoundBrowse"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvPublic.Columns["NoAlarm"].HeaderTextAlignment = ContentAlignment.MiddleCenter;

            grvPublic.Columns["SMS"].IsVisible = false;
            grvPublic.Columns["EMail"].IsVisible = false;
            grvPublic.Columns["Sound"].IsVisible = false;
            grvPublic.Columns["SoundBrowse"].IsVisible = false;
            grvPublic.Columns["SubjectId"].IsVisible = false;
            grvPublic.Columns["NoAlarm"].IsVisible = false;
        }

        private void FillProfileList()
        {
            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");

            if (cmbProfileList.Items.Count > 0)
            {
                cmbProfileList.Items.Clear();
                cmbProfileTo.Items.Clear();
                cmbProfileFrom.Items.Clear();
            }

            lg.GetAlertHeaderProfile();
            int _rowCount = Program.AlertProfileHeaderList.Count;

            cmbProfileList.Items.Add(_default);
            cmbProfileTo.Items.Add(_default);
            cmbProfileFrom.Items.Add(_default);

            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.AlertProfileHeaderList[i].ProfileName);
                cmbProfileFrom.Items.Add(Program.AlertProfileHeaderList[i].ProfileName);
                cmbProfileTo.Items.Add(Program.AlertProfileHeaderList[i].ProfileName);
            }
         
            cmbProfileList.SelectedIndex = 0;
            cmbProfileFrom.SelectedIndex = 0;
            cmbProfileTo.SelectedIndex = 0;
        }

        private void SetFormMessages()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AlertSetting");

            grbProfileSelect.Text = lg.GetMessageFromDll(_langCode, "Profile");
            rbtNewProfile.Text = lg.GetMessageFromDll(_langCode, "NewProfile");
            rbtSelectProfile.Text = lg.GetMessageFromDll(_langCode, "SelectProfile");
            rbtCopyProfile.Text = lg.GetMessageFromDll(_langCode, "CopyProfile");
            lblTo.Text = lg.GetMessageFromDll(_langCode, "To");

            pwpHardwares.Text = lg.GetMessageFromDll(_langCode, "Hardwares");
            pwpSoftwares.Text = lg.GetMessageFromDll(_langCode, "Softwares");
            pwpNetworks.Text = lg.GetMessageFromDll(_langCode, "Network");
            pwpPublic.Text = lg.GetMessageFromDll(_langCode, "Public");

            headerSubject = lg.GetMessageFromDll(_langCode, "Event");
            headerDesktop = lg.GetMessageFromDll(_langCode, "clmDesktop");
            headerIcon = lg.GetMessageFromDll(_langCode, "clmNotifyIcon");
            headerEmail = lg.GetMessageFromDll(_langCode, "clmEmail");
            headerSms = lg.GetMessageFromDll(_langCode, "clmSMS");
            headerNo = lg.GetMessageFromDll(_langCode, "clmNoAlert");
            headerSound = lg.GetMessageFromDll(_langCode, "Sound");
            headerSoundPath = lg.GetMessageFromDll(_langCode, "SoundFilePath");

            lblCpuChanges = lg.GetMessageFromDll(_langCode, "CPUChanges");
            lblMainboard = lg.GetMessageFromDll(_langCode, "MainboardChanges");
            lblBios = lg.GetMessageFromDll(_langCode, "BiosChanges");
            lblCdrom = lg.GetMessageFromDll(_langCode, "CdromChanges");
            lblHardDisk = lg.GetMessageFromDll(_langCode, "HardDiskChanges");
            lblKeyboard = lg.GetMessageFromDll(_langCode, "KeyboardChanges");
            lblLogicDisk = lg.GetMessageFromDll(_langCode, "LogicDiskChanges");
            lblMemory = lg.GetMessageFromDll(_langCode, "MemoryChanges");
            lblModem = lg.GetMessageFromDll(_langCode, "ModemChanges");
            lblMonitor = lg.GetMessageFromDll(_langCode, "MonitorChanges");
            lblMouse = lg.GetMessageFromDll(_langCode, "MouseChanges");
            lblNetAdapter = lg.GetMessageFromDll(_langCode, "NetAdapterChanges");
            lblPrinter = lg.GetMessageFromDll(_langCode, "PrinterChanges");
            lblScaner = lg.GetMessageFromDll(_langCode, "ScannerChanges");
            lblVideoCard = lg.GetMessageFromDll(_langCode, "VideoCardChanges");
            lblWebcam = lg.GetMessageFromDll(_langCode, "CammeraChanges");

            lblAppChanges = lg.GetMessageFromDll(_langCode, "ApplicationChanges");
            lblOs = lg.GetMessageFromDll(_langCode, "OsChanges");
            lblUpdates = lg.GetMessageFromDll(_langCode, "UpdatesChanges");

            lblIp = lg.GetMessageFromDll(_langCode, "IpChanges");
            lblSubnet = lg.GetMessageFromDll(_langCode, "SubnetChanges");
            lblGw = lg.GetMessageFromDll(_langCode, "GwChanges");
            lblMac = lg.GetMessageFromDll(_langCode, "MacChanges");
            lblDhcp = lg.GetMessageFromDll(_langCode, "DhcpChanges");
            lblDns = lg.GetMessageFromDll(_langCode, "DnsChanges");
            lblNetAdapter = 

            lblPower = lg.GetMessageFromDll(_langCode, "PowerChanges");
            lblFlash = lg.GetMessageFromDll(_langCode, "FlashChanges");
            lblUserAccount = lg.GetMessageFromDll(_langCode, "UserAccountChange");
            lblGroupAccount = lg.GetMessageFromDll(_langCode, "GroupAccountChange");

            lblChassis = lg.GetMessageFromDll(_langCode, "ChassisChange");
            lblSystemProperties = lg.GetMessageFromDll(_langCode, "SystemPropertiesChange");
            lblActiveNetwork = lg.GetMessageFromDll(_langCode, "ActiveNetworkSettingChange");

            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");
            helpToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Help");           

        }

        private void cmbProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _profileId = Program.AlertProfileHeaderList[cmbProfileList.SelectedIndex].ProfileId;
            _SelectedProfileId = _profileId;
            ClearAllGridView();
            SetHardwaresAlerts(_profileId);
            SetSoftwaresAlerts(_profileId);
            SetNetworksAlerts(_profileId);
            SetPublicAlerts(_profileId);
        }

        private void ClearAllGridView()
        {
            grvHardwares.Rows.Clear();
            grvNetwork.Rows.Clear();
            grvPublic.Rows.Clear();
            grvSoftwares.Rows.Clear();
        }

        private void SetPublicAlerts(string ProfileId)
        {
            string subjectId, alertId, soundAlert, soundFilePath;
            DataTable dt = new DataTable();
            dt = lg.GetAlertProfileDetails(ProfileId, "4");
            int _rowCount = dt.Rows.Count;
            for (int i = 0; i < _rowCount; i++)
            {
                subjectId = dt.Rows[i]["SubjectId"].ToString();
                alertId = dt.Rows[i]["AlertId"].ToString();
                soundAlert = dt.Rows[i]["SoundAlert"].ToString();
                if (dt.Rows[i]["SoundFilePath"] != null)
                    soundFilePath = dt.Rows[i]["SoundFilePath"].ToString();
                else
                    soundFilePath = "";
                InsertGridRow(subjectId, alertId, soundAlert, soundFilePath, grvPublic);
            }
        }

        private void SetNetworksAlerts(string ProfileId)
        {
            string subjectId, alertId, soundAlert, soundFilePath;
            DataTable dt = new DataTable();
            dt = lg.GetAlertProfileDetails(ProfileId, "3");
            int _rowCount = dt.Rows.Count;
            for (int i = 0; i < _rowCount; i++)
            {
                subjectId = dt.Rows[i]["SubjectId"].ToString();
                alertId = dt.Rows[i]["AlertId"].ToString();
                soundAlert = dt.Rows[i]["SoundAlert"].ToString();
                if (dt.Rows[i]["SoundFilePath"] != null)
                    soundFilePath = dt.Rows[i]["SoundFilePath"].ToString();
                else
                    soundFilePath = "";
                InsertGridRow(subjectId, alertId, soundAlert, soundFilePath, grvNetwork);
            }
        }

        private void SetSoftwaresAlerts(string ProfileId)
        {
            string subjectId, alertId, soundAlert, soundFilePath;
            DataTable dt = new DataTable();
            dt = lg.GetAlertProfileDetails(ProfileId, "2");
            int _rowCount = dt.Rows.Count;
            for (int i = 0; i < _rowCount; i++)
            {
                subjectId = dt.Rows[i]["SubjectId"].ToString();
                alertId = dt.Rows[i]["AlertId"].ToString();
                soundAlert = dt.Rows[i]["SoundAlert"].ToString();
                if (dt.Rows[i]["SoundFilePath"] != null)
                    soundFilePath = dt.Rows[i]["SoundFilePath"].ToString();
                else
                    soundFilePath = "";
                InsertGridRow(subjectId, alertId, soundAlert, soundFilePath, grvSoftwares);
            }
        }


        private void SetHardwaresAlerts(string ProfileId)
        {
            string subjectId, alertId, soundAlert, soundFilePath;
            DataTable dt = new DataTable();
            dt = lg.GetAlertProfileDetails(ProfileId, "1");
            int _rowCount = dt.Rows.Count;
            
            for (int i = 0; i < _rowCount; i++)
            {
                subjectId = dt.Rows[i]["SubjectId"].ToString();
                alertId = dt.Rows[i]["AlertId"].ToString();
                soundAlert = dt.Rows[i]["SoundAlert"].ToString();
                if (dt.Rows[i]["SoundFilePath"] != null)
                    soundFilePath = dt.Rows[i]["SoundFilePath"].ToString();
                else
                    soundFilePath = "";
                InsertGridRow(subjectId, alertId, soundAlert, soundFilePath, grvHardwares);
            }
        }

        private void InsertGridRow(string subjectId, string alertId, string soundAlert, string soundFilePath, RadGridView radGW)
        {
            EventLable = GetEventLable(subjectId);
            SetCheckboxAlert(alertId, soundAlert);
            SoundFilePath = soundFilePath;
            radGW.Rows.Add(EventLable, IIcon, Desktop, Sms, Email, Sound, SoundFilePath, No, subjectId);
        }

        private void SetCheckboxAlert(string IAlertId, string ISound)
        {
            if (ISound == "1")
            {
                Sound = true;
            }
            else
            {
                Sound = false;
            }

            switch (IAlertId)
            {
                case "0":
                    {
                        IIcon = false;
                        Desktop = false;
                        Sms = false;
                        Email = false;
                        No = true;
                        break;
                    }
                case "1":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = false;
                        Email = false;
                        Sms = false;
                        break;
                    }
                case "2":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = true;
                        Email = false;
                        Sms = false;
                        break;
                    }
                case "3":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = true;
                        Email = false;
                        Sms = false;
                        break;
                    }
                case "4":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = false;
                        Email = true;
                        Sms = false;
                        break;
                    }
                case "5":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = false;
                        Email = true;
                        Sms = false;
                        break;
                    }
                case "6":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = true;
                        Email = true;
                        Sms = false;
                        break;
                    }
                case "7":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = true;
                        Email = true;
                        Sms = false;
                        break;
                    }
                case "8":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = false;
                        Email = false;
                        Sms = true;
                        break;
                    }
                case "9":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = false;
                        Email = false;
                        Sms = true;
                        break;
                    }
                case "10":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = true;
                        Email = false;
                        Sms = true;
                        break;
                    }
                case "11":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = true;
                        Email = false;
                        Sms = true;
                        break;
                    }
                case "12":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = false;
                        Email = true;
                        Sms = true;
                        break;
                    }
                case "13":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = false;
                        Email = true;
                        Sms = true;
                        break;
                    }
                case "14":
                    {
                        No = false;
                        Desktop = false;
                        IIcon = true;
                        Email = true;
                        Sms = true;
                        break;
                    }
                case "15":
                    {
                        No = false;
                        Desktop = true;
                        IIcon = true;
                        Email = true;
                        Sms = true;
                        break;
                    }
            }
        }

        private string GetEventLable(string subjectId)
        {
            string ret = "";
            switch (subjectId)
            {
                case "1":
                    {
                        ret = lblCpuChanges;
                        break;
                    }
                case "2":
                    {
                        ret = lblMainboard;
                        break;
                    }
                case "3":
                    {
                        ret = lblBios;
                        break;
                    }
                case "4":
                    {
                        ret = lblMemory;
                        break;
                    }
                case "5":
                    {
                        ret = lblHardDisk;
                        break;
                    }
                case "6":
                    {
                        ret = lblLogicDisk;
                        break;
                    }
                case "7":
                    {
                        ret = lblVideoCard;
                        break;
                    }
                case "8":
                    {
                        ret = lblNetAdapter;
                        break;
                    }
                case "9":
                    {
                        ret = lblKeyboard;
                        break;
                    }
                case "10":
                    {
                        ret = lblMouse;
                        break;
                    }
                case "11":
                    {
                        ret = lblMonitor;
                        break;
                    }
                case "12":
                    {
                        ret = lblPrinter;
                        break;
                    }
                case "13":
                    {
                        ret = lblWebcam;
                        break;
                    }
                case "14":
                    {
                        ret = lblScaner;
                        break;
                    }
                case "15":
                    {
                        ret = lblCdrom;
                        break;
                    }
                case "16":
                    {
                        ret = lblModem;
                        break;
                    }
                case "17":
                    {
                        ret = lblAppChanges;
                        break;
                    }
                case "18":
                    {
                        ret = lblOs;
                        break;
                    }
                case "19":
                    {
                        ret = lblUpdates;
                        break;
                    }
                case "20":
                    {
                        ret = lblIp;
                        break;
                    }
                case "21":
                    {
                        ret = lblSubnet;
                        break;
                    }
                case "22":
                    {
                        ret = lblGw;
                        break;
                    }
                case "23":
                    {
                        ret = lblMac;
                        break;
                    }
                case "24":
                    {
                        ret = lblDns;
                        break;
                    }
                case "25":
                    {
                        ret = lblDhcp;
                        break;
                    }
                case "26":
                    {
                        ret = lblPower;
                        break;
                    }
                case "27":
                    {
                        ret = lblFlash;
                        break;
                    }
                case "28":
                    {
                        ret = lblUserAccount;
                        break;
                    }
                case "29":
                    {
                        ret = lblGroupAccount;
                        break;
                    }
                case "30":
                    {
                        ret = lblChassis;
                        break;
                    }
                case "31":
                    {
                        ret = lblSystemProperties;
                        break;
                    }
                case "33":
                    {
                        ret = lblActiveNetwork;
                        break;
                    }
            }
            return ret;
        }

        private string GetSubjectDescription(string subjectId)
        {
            string ret = "";
            switch (subjectId)
            {
                case "1":
                    {
                        ret = "CPU";
                        break;
                    }
                case "2":
                    {
                        ret = "Motherboard";
                        break;
                    }
                case "3":
                    {
                        ret = "Bios";
                        break;
                    }
                case "4":
                    {
                        ret = "Memory";
                        break;
                    }
                case "5":
                    {
                        ret = "HardDisk";
                        break;
                    }
                case "6":
                    {
                        ret = "LogicDisk";
                        break;
                    }
                case "7":
                    {
                        ret = "VideoCard";
                        break;
                    }
                case "8":
                    {
                        ret = "NetAdapter";
                        break;
                    }
                case "9":
                    {
                        ret = "Keyboard";
                        break;
                    }
                case "10":
                    {
                        ret = "Mouse";
                        break;
                    }
                case "11":
                    {
                        ret = "Monitor";
                        break;
                    }
                case "12":
                    {
                        ret = "Printer";
                        break;
                    }
                case "13":
                    {
                        ret = "Webcam";
                        break;
                    }
                case "14":
                    {
                        ret = "Scanner";
                        break;
                    }
                case "15":
                    {
                        ret = "CdRom";
                        break;
                    }
                case "16":
                    {
                        ret = "Modem";
                        break;
                    }
                case "17":
                    {
                        ret = "Application";
                        break;
                    }
                case "18":
                    {
                        ret = "Os";
                        break;
                    }
                case "19":
                    {
                        ret = "SecurityUpdate";
                        break;
                    }
                case "20":
                    {
                        ret = "IP Address";
                        break;
                    }
                case "21":
                    {
                        ret = "Subnet Address";
                        break;
                    }
                case "22":
                    {
                        ret = "Gateway Address";
                        break;
                    }
                case "23":
                    {
                        ret = "MAC Address";
                        break;
                    }
                case "24":
                    {
                        ret = "DNS Address";
                        break;
                    }
                case "25":
                    {
                        ret = "DHCP Address";
                        break;
                    }
                case "26":
                    {
                        ret = "Power System";
                        break;
                    }
                case "27":
                    {
                        ret = "Flash Disk";
                        break;
                    }
                case "28":
                    {
                        ret = "User Account";
                        break;
                    }
                case "29":
                    {
                        ret = "Group Account";
                        break;
                    }
            }
            return ret;
        }

        private void pwpHardwares_Paint(object sender, PaintEventArgs e)
        {
            grvHardwares.Columns["Subject"].ReadOnly = true;
        }

        private void pwpSoftwares_Paint(object sender, PaintEventArgs e)
        {
            grvSoftwares.Columns["Subject"].ReadOnly = true;
        }

        private void pwpNetworks_Paint(object sender, PaintEventArgs e)
        {
            grvNetwork.Columns["Subject"].ReadOnly = true;
        }

        private void pwpPublic_Paint(object sender, PaintEventArgs e)
        {
            grvPublic.Columns["Subject"].ReadOnly = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Focus();
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                if (lg.CheckPermission(68))
                {
                    UpdateProfile();
                    ShowSaveMessage();
                }
                else
                {
                    frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                    frmmsg.ShowDialog();
                }
            }
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                if (lg.CheckPermission(67))
                {
                    bool IsProfileNameRepeat = CheckProfileName(txbProfileName.Text);
                    if (IsProfileNameRepeat == false)
                    {
                        SaveNewProfile();
                        if (_errorProvider == false)
                            ShowSaveMessage();
                        FillProfileList();
                    }
                    else
                    {
                        string mes = lg.GetMessageFromDll(_langCode, "ProfileNameIsRepeat");
                        frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                        frmsh.ShowDialog();
                    }
                }
                else
                {
                    frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                    frmmsg.ShowDialog();
                }
            }
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                if (lg.CheckPermission(68))
                {
                    UpdateProfile();
                    ShowSaveMessage();
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
            int count = Program.AlertProfileHeaderList.Count;
            for(int i = 0 ; i < count;i++)
            {
                if (Program.AlertProfileHeaderList[i].ProfileName.Trim() == NewProfileName.Trim())
                    result = true;            
            }
            return result;
        }

        private void SaveNewProfile()
        {
            if (txbProfileName.Text != "")
            {
                _errorProvider = false;
                string _lastProfileId = lg.GetLastAlertProfileId();
                _SelectedProfileId = _lastProfileId;
                int res = lg.InsertAlertProfile(_SelectedProfileId,txbProfileName.Text.Trim());
                if (res == 1)
                {
                    _SqlError = false;
                    SaveNewDetailsAlarmProfile();
                }
                else
                {
                    _SqlError = true;                    
                }
            }
            else
            {
                errorProvider1.SetError(txbProfileName, "Not");
                _errorProvider = true;
                txbProfileName.Focus();
            }
        }

        private void SaveNewDetailsAlarmProfile()
        {
            InsertAlert(grvHardwares,"1");
            InsertAlert(grvSoftwares,"2");
            InsertAlert(grvNetwork,"3");
            InsertAlert(grvPublic,"4");
        }


        private void ShowSaveMessage()
        {           
            if (_SqlError == false)
            {
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
    
        private void UpdateProfile()
        {
            UpdateAlert(grvHardwares);
            UpdateAlert(grvSoftwares);
            UpdateAlert(grvNetwork);
            UpdateAlert(grvPublic);
        }

        private void InsertAlert(RadGridView Rgv,string _Sg)
        {
            int _rowCount = Rgv.Rows.Count;
            int res;
            _SubjectGroup = _Sg;
            for (int i = 0; i < _rowCount; i++)
            {
                _SubjectId = Rgv.Rows[i].Cells["SubjectId"].Value.ToString();
                _AlertId = GetAlertId(i, Rgv);
                _Sound = GetSoundId(i, Rgv);
                _SubjectDes = GetSubjectDescription(_SubjectId);           

                if (_Sound == "1")
                {
                    _SoundFilePath = Rgv.Rows[i].Cells["SoundBrowse"].Value.ToString();
                }
                else
                {
                    _SoundFilePath = "";
                }

                res = lg.InsertAlertDetails(_SelectedProfileId, _SubjectId, _AlertId.ToString(),_SubjectGroup,_SubjectDes,_Sound, _SoundFilePath);
                if (res == 0)
                {
                    _SqlError = true;
                    break;
                }
            }

        }

        private void UpdateAlert(RadGridView Rgv)
        {
            int _rowCount = Rgv.Rows.Count;
            int res;
            for (int i = 0; i < _rowCount; i++)
            {
                _SubjectId = Rgv.Rows[i].Cells["SubjectId"].Value.ToString();
                _AlertId = GetAlertId(i, Rgv);
                _Sound = GetSoundId(i, Rgv);
                if (_Sound == "1")
                {
                    _SoundFilePath = Rgv.Rows[i].Cells["SoundBrowse"].Value.ToString();
                }
                else
                {
                    _SoundFilePath = "";
                }

                res = lg.UpdateAlertProfile(_SelectedProfileId, _SubjectId, _AlertId.ToString(), _Sound, _SoundFilePath);
                if (res == 0)
                {
                    _SqlError = true;
                    break;
                }
            }
        }

        private string GetSoundId(int Index, RadGridView Rgiv)
        {
            string sid = "0";
            if (Convert.ToBoolean(Rgiv.Rows[Index].Cells["Sound"].Value) == true)
            {
                sid = "1";
            }
            return sid;
        }

        private int GetAlertId(int Index,RadGridView Rgiv)
        {
            int aid = 0;
            if (Convert.ToBoolean(Rgiv.Rows[Index].Cells["Icon"].Value) == true)
            {
                aid = aid + 2;
            }
            if (Convert.ToBoolean(Rgiv.Rows[Index].Cells["Desktop"].Value) == true)
            {
                aid = aid + 1;
            }
            if (Convert.ToBoolean(Rgiv.Rows[Index].Cells["SMS"].Value) == true)
            {
                aid = aid + 8;
            }
            if (Convert.ToBoolean(Rgiv.Rows[Index].Cells["EMail"].Value) == true)
            {
                aid = aid + 4;
            }
            return aid;
        }

        private void rbtSelectProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                deleteToolStripButton.Enabled = true;
                cmbProfileList.Enabled = true;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
              
            }
        }

        private void rbtNewProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                deleteToolStripButton.Enabled = false;
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = true;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
                cmbProfileList.Enabled = false;
            }

            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                errorProvider1.Clear();
                txbProfileName.Text = "";
            }
        }

        private void rbtCopyProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                deleteToolStripButton.Enabled = false;
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = true;
                cmbProfileTo.Enabled = true;
                cmbProfileList.Enabled = false;
              
            }
        }

        private void txbProfileName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cmbProfileFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                string _profileId = Program.AlertProfileHeaderList[cmbProfileFrom.SelectedIndex].ProfileId;
                _SelectedProfileId = _profileId;

                grvHardwares.Rows.Clear();
                grvSoftwares.Rows.Clear();
                grvNetwork.Rows.Clear();
                grvPublic.Rows.Clear();
                SetHardwaresAlerts(_profileId);
                SetSoftwaresAlerts(_profileId);
                SetNetworksAlerts(_profileId);
                SetPublicAlerts(_profileId);
            }
        }

        private void cmbProfileTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedProfileId = Program.AlertProfileHeaderList[cmbProfileTo.SelectedIndex].ProfileId;
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(69))
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
            Res = lg.DeleteAlertProfileDetails(_SelectedProfileId);
            if (Res == 1)
            {
                Res = lg.DeleteAlertProfileHeader(_SelectedProfileId);
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
            else
            {
                ShowDeleteMessage(lg.GetErrorMessage(25));
            }
        }
           

        private void ShowDeleteMessage(string Message)
        {
            frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(Message, 2);
            frmsh.ShowDialog();
        }

    }
}
