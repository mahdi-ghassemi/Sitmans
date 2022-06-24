using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmHardAlertSetting_RtoL : Telerik.WinControls.UI.RadForm
    {

        private string _langCode;
        private DataTable objDataTable;
        private Agents[] _agents;
        private Agents _agent;
        private int _settingFor;  //0 = all ; 1 = for one ; 2 = for many


        private int CpuAlertId;
        private int MainAlertId;
        private int ModemAlertId;
        private int CdromAlertId;
        private int ScanerAlertId;
        private int WebcamAlertId;
        private int PrinterAlertId;
        private int MonitorAlertId;
        private int MouseAlertId;
        private int KeyboardAlertId;
        private int NetAlertId;
        private int VideoCardAlertId;
        private int LogicDiskAlertId;
        private int HardDiskAlertId;
        private int MemoryAlertId;
        private int BiosAlertId;

        private int CpuSoundId;
        private int MainSoundId;
        private int ModemSoundId;
        private int CdromSoundId;
        private int ScanerSoundId;
        private int WebcamSoundId;
        private int PrinterSoundId;
        private int MonitorSoundId;
        private int MouseSoundId;
        private int KeyboardSoundId;
        private int NetSoundId;
        private int VideoCardSoundId;
        private int LogicDiskSoundId;
        private int HardDiskSoundId;
        private int MemorySoundId;
        private int BiosSoundId;

        private string CpuSoundPath;
        private string MainSoundPath;
        private string ModemSoundPath;
        private string CdromSoundPath;
        private string ScanerSoundPath;
        private string WebcamSoundPath;
        private string PrinterSoundPath;
        private string MonitorSoundPath;
        private string MouseSoundPath;
        private string KeyboardSoundPath;
        private string NetSoundPath;
        private string VideoCardSoundPath;
        private string LogicDiskSoundPath;
        private string HardDiskSoundPath;
        private string MemorySoundPath;
        private string BiosSoundPath;

        private string AllSoundPath;



        public frmHardAlertSetting_RtoL()
        {
            CpuAlertId = 0;
            MainAlertId = 0;
            ModemAlertId = 0;
            CdromAlertId = 0;
            ScanerAlertId = 0;
            WebcamAlertId = 0;
            PrinterAlertId = 0;
            MonitorAlertId = 0;
            MouseAlertId = 0;
            KeyboardAlertId = 0;
            NetAlertId = 0;
            VideoCardAlertId = 0;
            LogicDiskAlertId = 0;
            HardDiskAlertId = 0;
            MemoryAlertId = 0;
            BiosAlertId = 0;

            CpuSoundId = 0;
            MainSoundId = 0;
            ModemSoundId = 0;
            CdromSoundId = 0;
            ScanerSoundId = 0;
            WebcamSoundId = 0;
            PrinterSoundId = 0;
            MonitorSoundId = 0;
            MouseSoundId = 0;
            KeyboardSoundId = 0;
            NetSoundId = 0;
            VideoCardSoundId = 0;
            LogicDiskSoundId = 0;
            HardDiskSoundId = 0;
            MemorySoundId = 0;
            BiosSoundId = 0;

            CpuSoundPath = "";
            MainSoundPath = "";
            ModemSoundPath = "";
            CdromSoundPath = "";
            ScanerSoundPath = "";
            WebcamSoundPath = "";
            PrinterSoundPath = "";
            MonitorSoundPath = "";
            MouseSoundPath = "";
            KeyboardSoundPath = "";
            NetSoundPath = "";
            VideoCardSoundPath = "";
            LogicDiskSoundPath = "";
            HardDiskSoundPath = "";
            MemorySoundPath = "";
            BiosSoundPath = "";

            AllSoundPath = "";


            _settingFor = 0;
            InitializeComponent();
        }

        public frmHardAlertSetting_RtoL(Agents agent)
        {
            _agent = agent;
            _settingFor = 1; 
            InitializeComponent();

        }

        public frmHardAlertSetting_RtoL(Agents[] agents)
        {
            _agents = agents;
            _settingFor = 2;
            InitializeComponent();
        }

        private void frmAlertSetting_RtoL_Load(object sender, EventArgs e)
        {
            _langCode = Convert.ToString(Program.LangCode);

            FillForm();
            SetData();
            //ModelControl();
            SetCheckBoxes();

        }
        /*
        private void ModelControl()
        {
            if (Program.Model == "Boronze")
            {
                BoronzeSet();
            }
            if (Program.Model == "Silver" || Program.Model == "Gold")
            {
                BoronzeSet();
                SilverSet();
            }
        }

        private void BoronzeSet()
        {
            chbSendEmailAll.Enabled = true;
            chbCpuMail.Enabled = true;
            chbMainEmail.Enabled = true;
            chbModemEmail.Enabled = true;
            chbCdromEmail.Enabled = true;
            chbScanerEmail.Enabled = true;
            chbWebcamEmail.Enabled = true;
            chbPrinterEmail.Enabled = true;
            chbMonitorEmail.Enabled = true;
            chbMouseEmail.Enabled = true;
            chbKeyboardEmail.Enabled = true;
            chbNetMail.Enabled = true;
            chbVideoCardEmail.Enabled = true;
            chbLogicDiskEmail.Enabled = true;
            chbHardDiskEmail.Enabled = true;
            chbMemoryEmail.Enabled = true;
            chbBiosEmail.Enabled = true;
        }

        private void SilverSet()
        {
            chbSendSMSAll.Enabled = true;
            chbCpuSMS.Enabled = true;
            chbMainSms.Enabled = true;
            chbModemSms.Enabled = true;
            chbCdromSms.Enabled = true;
            chbScanerSms.Enabled = true;
            chbWebcamSms.Enabled = true;
            chbPrinterSms.Enabled = true;
            chbMonitorSms.Enabled = true;
            chbMouseSms.Enabled = true;
            chbKeyboardSms.Enabled = true;
            chbNetSms.Enabled = true;
            chbVideoCardSms.Enabled = true;
            chbLogicDiskSms.Enabled = true;
            chbHardDiskSms.Enabled = true;
            chbMemorySms.Enabled = true;
            chbBiosSms.Enabled = true;
        }
        */
        private void SetCheckBoxes()
        {
            SetCpuAlertId();
            SetMainAlertId();
            SetBiosAlertId();
            SetMemoryAlertId();
            SetHardDiskAlertId();
            SetLogicDiskAlertId();
            SetVideoCardAlertId();
            SetNetAdapterAlertId();
            SetKeyboardAlertId();
            SetMouseAlertId();
            SetMonitorAlertId();
            SetPrinterAlertId();
            SetWebcamAlertId();
            SetScanerAlertId();
            SetCdromAlertId();
            SetModemAlertId();
            SetSoundCheckBoxes();

        }

        private void SetSoundCheckBoxes()
        {
            if (CpuSoundId == 1)
                chbCpuSound.Checked = true;
            else
                chbCpuSound.Checked = false;

            if (MainSoundId == 1)
                chbMainboardSound.Checked = true;
            else
                chbMainboardSound.Checked = false;

            if (BiosSoundId == 1)
                chbBiosSound.Checked = true;
            else
                chbBiosSound.Checked = false;

            if (MemorySoundId == 1)
                chbMemorySound.Checked = true;
            else
                chbMemorySound.Checked = false;

            if (HardDiskSoundId == 1)
                chbHardDiskSound.Checked = true;
            else
                chbHardDiskSound.Checked = false;

            if (LogicDiskSoundId == 1)
                chbLogicDiskSound.Checked = true;
            else
                chbLogicDiskSound.Checked = false;

            if (VideoCardSoundId == 1)
                chbVideoCardSound.Checked = true;
            else
                chbVideoCardSound.Checked = false;

            if (NetSoundId == 1)
                chbNetSound.Checked = true;
            else
                chbNetSound.Checked = false;

            if (KeyboardSoundId == 1)
                chbKeyboardSound.Checked = true;
            else
                chbKeyboardSound.Checked = false;

            if (MouseSoundId == 1)
                chbMouseSound.Checked = true;
            else
                chbMouseSound.Checked = false;

            if (MonitorSoundId == 1)
                chbMonitorSound.Checked = true;
            else
                chbMonitorSound.Checked = false;

            if (PrinterSoundId == 1)
                chbPrinterSound.Checked = true;
            else
                chbPrinterSound.Checked = false;

            if (WebcamSoundId == 1)
                chbWebcamSound.Checked = true;
            else
                chbWebcamSound.Checked = false;

            if (ScanerSoundId == 1)
                chbScanerSound.Checked = true;
            else
                chbScanerSound.Checked = false;

            if (CdromSoundId == 1)
                chbCdromSound.Checked = true;
            else
                chbCdromSound.Checked = false;

            if (ModemSoundId == 1)
                chbModemSound.Checked = true;
            else
                chbModemSound.Checked = false;
        }

        private void SetModemAlertId()
        {
            int _ModemAlertId = ModemAlertId;
            ModemAlertId = 0;
            switch (_ModemAlertId)
            {
                case 0:
                    {
                        chbModemNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 2:
                    {                       
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 3:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 4:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 5:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 6:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 7:
                    {                       
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = false;
                        break;
                    }
                case 8:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 9:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 10:
                    {                       
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 11:
                    {                       
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = false;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 12:
                    {                       
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 13:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = false;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 14:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = false;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = true;
                        break;
                    }
                case 15:
                    {                        
                        chbModemNo.Checked = false;
                        chbModemDesktop.Checked = true;
                        chbModemIcon.Checked = true;
                        chbModemEmail.Checked = true;
                        chbModemSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetCdromAlertId()
        {
            int _CdromAlertId = CdromAlertId;
            CdromAlertId = 0;
            switch (_CdromAlertId)
            {
                case 0:
                    {
                        chbCdromNo.Checked = true;
                        break;
                    }
                case 1:
                    {                       
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 2:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 3:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 4:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 5:
                    {                       
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 6:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 7:
                    {                       
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = false;
                        break;
                    }
                case 8:
                    {                       
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 9:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 10:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 11:
                    {                        
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = false;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = false;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = false;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbCdromNo.Checked = false;
                        chbCdromDesktop.Checked = true;
                        chbCdromIcon.Checked = true;
                        chbCdromEmail.Checked = true;
                        chbCdromSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetScanerAlertId()
        {
            int _ScanerAlertId = ScanerAlertId;
            ScanerAlertId = 0;
            switch (_ScanerAlertId)
            {
                case 0:
                    {
                        chbScanerNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = false;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = false;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = false;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbScanerNo.Checked = false;
                        chbScanerDesktop.Checked = true;
                        chbScanerIcon.Checked = true;
                        chbScanerEmail.Checked = true;
                        chbScanerSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetWebcamAlertId()
        {
            int _WebcamAlertId = WebcamAlertId;
            WebcamAlertId = 0;
            switch (_WebcamAlertId)
            {
                case 0:
                    {
                        chbWebcamNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = false;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = false;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = false;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbWebcamNo.Checked = false;
                        chbWebcamDesktop.Checked = true;
                        chbWebcamIcon.Checked = true;
                        chbWebcamEmail.Checked = true;
                        chbWebcamSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetPrinterAlertId()
        {
            int _PrinterAlertId = PrinterAlertId;
            PrinterAlertId = 0;
            switch (_PrinterAlertId)
            {
                case 0:
                    {
                        chbPrinterNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = false;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = false;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = false;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbPrinterNo.Checked = false;
                        chbPrinterDesktop.Checked = true;
                        chbPrinterIcon.Checked = true;
                        chbPrinterEmail.Checked = true;
                        chbPrinterSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetMonitorAlertId()
        {
            int _MonitorAlertId = MonitorAlertId;
            MonitorAlertId = 0;
            switch (_MonitorAlertId)
            {
                case 0:
                    {
                        chbMonitorNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = false;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = false;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = false;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbMonitorNo.Checked = false;
                        chbMonitorDesktop.Checked = true;
                        chbMonitorIcon.Checked = true;
                        chbMonitorEmail.Checked = true;
                        chbMonitorSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetMouseAlertId()
        {
            int _MouseAlertId = MouseAlertId;
            MouseAlertId = 0;
            switch (_MouseAlertId)
            {
                case 0:
                    {
                        chbMouseNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = false;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = false;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = false;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbMouseNo.Checked = false;
                        chbMouseDesktop.Checked = true;
                        chbMouseIcon.Checked = true;
                        chbMouseEmail.Checked = true;
                        chbMouseSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetKeyboardAlertId()
        {
            int _KeyboardAlertId = KeyboardAlertId;
            KeyboardAlertId = 0;
            switch (_KeyboardAlertId)
            {
                case 0:
                    {
                        chbKeyboardNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = false;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = false;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = false;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbKeyboardNo.Checked = false;
                        chbKeyboardDesktop.Checked = true;
                        chbKeyboardIcon.Checked = true;
                        chbKeyboardEmail.Checked = true;
                        chbKeyboardSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetNetAdapterAlertId()
        {
            int _NetAlertId = NetAlertId;
            NetAlertId = 0;
            switch (_NetAlertId)
            {
                case 0:
                    {
                        chbNetNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = false;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = false;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = false;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbNetNo.Checked = false;
                        chbNetDesktop.Checked = true;
                        chbNetIcon.Checked = true;
                        chbNetMail.Checked = true;
                        chbNetSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetVideoCardAlertId()
        {
            int _VideoCardAlertId = VideoCardAlertId;
            VideoCardAlertId = 0;
            switch (_VideoCardAlertId)
            {
                case 0:
                    {
                        chbVideoCardNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = false;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = false;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = false;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbVideoCardNo.Checked = false;
                        chbVideoCardDesktop.Checked = true;
                        chbVideoCardIcon.Checked = true;
                        chbVideoCardEmail.Checked = true;
                        chbVideoCardSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetLogicDiskAlertId()
        {
            int _LogicDiskAlertId = LogicDiskAlertId;
            LogicDiskAlertId = 0;
            switch (_LogicDiskAlertId)
            {
                case 0:
                    {
                        chbLogicDiskNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = false;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = false;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = false;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbLogicDiskNo.Checked = false;
                        chbLogicDiskDesktop.Checked = true;
                        chbLogicDiskIcon.Checked = true;
                        chbLogicDiskEmail.Checked = true;
                        chbLogicDiskSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetHardDiskAlertId()
        {
            int _HardDiskAlertId = HardDiskAlertId;
            HardDiskAlertId = 0;
            switch (_HardDiskAlertId)
            {
                case 0:
                    {
                        chbHardDiskNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = false;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = false;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = false;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbHardDiskNo.Checked = false;
                        chbHardDiskDesktop.Checked = true;
                        chbHardDiskIcon.Checked = true;
                        chbHardDiskEmail.Checked = true;
                        chbHardDiskSms.Checked = true;
                        break;
                    }
            }           
        }

        private void SetMemoryAlertId()
        {
            int _MemoryAlertId = MemoryAlertId;
            MemoryAlertId = 0;
            switch (_MemoryAlertId)
            {
                case 0:
                    {
                        chbMemoryNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = false;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = false;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = false;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbMemoryNo.Checked = false;
                        chbMemoryDesktop.Checked = true;
                        chbMemoryIcon.Checked = true;
                        chbMemoryEmail.Checked = true;
                        chbMemorySms.Checked = true;
                        break;
                    }
            }           
            
        }

        private void SetBiosAlertId()
        {
            int _BiosAlertId = BiosAlertId;
            BiosAlertId = 0;
            switch (_BiosAlertId)
            {
                case 0:
                    {
                        chbBiosNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = false;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = false;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = false;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbBiosNo.Checked = false;
                        chbBiosDesktop.Checked = true;
                        chbBiosIcon.Checked = true;
                        chbBiosEmail.Checked = true;
                        chbBiosSms.Checked = true;
                        break;
                    }


            }           
        }

        private void SetMainAlertId()
        {
            int _MainAlertId = MainAlertId;
            MainAlertId = 0;
            switch (_MainAlertId)
            {
                case 0:
                    {
                        chbMainNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = false;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = false;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = false;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbMainNo.Checked = false;
                        chbMainDesktop.Checked = true;
                        chbMainIcon.Checked = true;
                        chbMainEmail.Checked = true;
                        chbMainSms.Checked = true;
                        break;
                    }


            }
        }

        private void SetCpuAlertId()
        {
            int _CpuAlertId = CpuAlertId;
            CpuAlertId = 0;
            switch (_CpuAlertId)
            {
                case 0:
                    {
                        chbCpuNo.Checked = true;
                        break;
                    }
                case 1:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 2:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 3:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 4:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 5:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 6:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 7:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = false;
                        break;
                    }
                case 8:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 9:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 10:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 11:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = false;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 12:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 13:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = false;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 14:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = false;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = true;
                        break;
                    }
                case 15:
                    {
                        chbCpuNo.Checked = false;
                        chbCpuDesktop.Checked = true;
                        chbCpuIcon.Checked = true;
                        chbCpuMail.Checked = true;
                        chbCpuSMS.Checked = true;
                        break;
                    }
            }
        }

        private void SetData()
        {           
            SQLAccess sql = new SQLAccess();

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAllSystemAlertList.ToString();
            string[,] newparams = new string[1, 2];
            newparams[0, 0] = "@GroupId";
            newparams[0, 1] = "1";

            objDataTable = new DataTable("Table");
            objDataTable = sql.ExcecuteQueryToDataTable(newparams);

            CpuAlertId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[2].ToString());
            MainAlertId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[2].ToString());
            BiosAlertId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[2].ToString());
            MemoryAlertId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[2].ToString());
            HardDiskAlertId = Convert.ToInt32(objDataTable.Rows[4].ItemArray[2].ToString());
            LogicDiskAlertId = Convert.ToInt32(objDataTable.Rows[5].ItemArray[2].ToString());
            VideoCardAlertId = Convert.ToInt32(objDataTable.Rows[6].ItemArray[2].ToString());
            NetAlertId = Convert.ToInt32(objDataTable.Rows[7].ItemArray[2].ToString());
            KeyboardAlertId = Convert.ToInt32(objDataTable.Rows[8].ItemArray[2].ToString());
            MouseAlertId = Convert.ToInt32(objDataTable.Rows[9].ItemArray[2].ToString());
            MonitorAlertId = Convert.ToInt32(objDataTable.Rows[10].ItemArray[2].ToString());
            PrinterAlertId = Convert.ToInt32(objDataTable.Rows[11].ItemArray[2].ToString());
            WebcamAlertId = Convert.ToInt32(objDataTable.Rows[12].ItemArray[2].ToString());
            ScanerAlertId = Convert.ToInt32(objDataTable.Rows[13].ItemArray[2].ToString());
            CdromAlertId = Convert.ToInt32(objDataTable.Rows[14].ItemArray[2].ToString());
            ModemAlertId = Convert.ToInt32(objDataTable.Rows[15].ItemArray[2].ToString());

            CpuSoundId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[5].ToString());
            MainSoundId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[5].ToString());
            BiosSoundId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[5].ToString());
            MemorySoundId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[5].ToString());
            HardDiskSoundId = Convert.ToInt32(objDataTable.Rows[4].ItemArray[5].ToString());
            LogicDiskSoundId = Convert.ToInt32(objDataTable.Rows[5].ItemArray[5].ToString());
            VideoCardSoundId = Convert.ToInt32(objDataTable.Rows[6].ItemArray[5].ToString());
            NetSoundId = Convert.ToInt32(objDataTable.Rows[7].ItemArray[5].ToString());
            KeyboardSoundId = Convert.ToInt32(objDataTable.Rows[8].ItemArray[5].ToString());
            MouseSoundId = Convert.ToInt32(objDataTable.Rows[9].ItemArray[5].ToString());
            MonitorSoundId = Convert.ToInt32(objDataTable.Rows[10].ItemArray[5].ToString());
            PrinterSoundId = Convert.ToInt32(objDataTable.Rows[11].ItemArray[5].ToString());
            WebcamSoundId = Convert.ToInt32(objDataTable.Rows[12].ItemArray[5].ToString());
            ScanerSoundId = Convert.ToInt32(objDataTable.Rows[13].ItemArray[5].ToString());
            CdromSoundId = Convert.ToInt32(objDataTable.Rows[14].ItemArray[5].ToString());
            ModemSoundId = Convert.ToInt32(objDataTable.Rows[15].ItemArray[5].ToString());

            CpuSoundPath = objDataTable.Rows[0].ItemArray[6].ToString();
            MainSoundPath = objDataTable.Rows[1].ItemArray[6].ToString();
            BiosSoundPath =objDataTable.Rows[2].ItemArray[6].ToString();
            MemorySoundPath = objDataTable.Rows[3].ItemArray[6].ToString();
            HardDiskSoundPath = objDataTable.Rows[4].ItemArray[6].ToString();
            LogicDiskSoundPath = objDataTable.Rows[5].ItemArray[6].ToString();
            VideoCardSoundPath = objDataTable.Rows[6].ItemArray[6].ToString();
            NetSoundPath = objDataTable.Rows[7].ItemArray[6].ToString();
            KeyboardSoundPath = objDataTable.Rows[8].ItemArray[6].ToString();
            MouseSoundPath = objDataTable.Rows[9].ItemArray[6].ToString();
            MonitorSoundPath = objDataTable.Rows[10].ItemArray[6].ToString();
            PrinterSoundPath = objDataTable.Rows[11].ItemArray[6].ToString();
            WebcamSoundPath = objDataTable.Rows[12].ItemArray[6].ToString();
            ScanerSoundPath = objDataTable.Rows[13].ItemArray[6].ToString();
            CdromSoundPath = objDataTable.Rows[14].ItemArray[6].ToString();
            ModemSoundPath = objDataTable.Rows[15].ItemArray[6].ToString();


        }

        private void FillForm()
        {
            LogicLayer l1 = new LogicLayer();

            this.Text = l1.GetMessageFromDll(_langCode, "AlertSetting");
            grbHardwares.Text = l1.GetMessageFromDll(_langCode, "Hardwares");
            lblEvents.Text = l1.GetMessageFromDll(_langCode, "Event");
            chbDesktopAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmDesktop");
            chbNotifyIconAll.Text = l1.GetMessageFromDll(_langCode, "clmNotifyIcon");
            chbSendEmailAll.Text = l1.GetMessageFromDll(_langCode, "clmEmail");
            chbSendSMSAll.Text = l1.GetMessageFromDll(_langCode, "clmSMS");
            chbNoAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmNoAlert");
            chbSoundAll.Text = l1.GetMessageFromDll(_langCode, "Sound");

            lblCpuChanges.Text = l1.GetMessageFromDll(_langCode, "CPUChanges");
            lblMainboard.Text = l1.GetMessageFromDll(_langCode, "MainboardChanges");
            lblBios.Text = l1.GetMessageFromDll(_langCode, "BiosChanges");
            lblCdrom.Text = l1.GetMessageFromDll(_langCode, "CdromChanges");
            lblHardDisk.Text = l1.GetMessageFromDll(_langCode, "HardDiskChanges");
            lblKeyboard.Text = l1.GetMessageFromDll(_langCode, "KeyboardChanges");
            lblLogicDisk.Text = l1.GetMessageFromDll(_langCode, "LogicDiskChanges");
            lblMemory.Text = l1.GetMessageFromDll(_langCode, "MemoryChanges");
            lblModem.Text = l1.GetMessageFromDll(_langCode, "ModemChanges");
            lblMonitor.Text = l1.GetMessageFromDll(_langCode, "MonitorChanges");
            lblMouse.Text = l1.GetMessageFromDll(_langCode, "MouseChanges");
            lblNetAdapter.Text = l1.GetMessageFromDll(_langCode, "NetAdapterChanges");
            lblPrinter.Text = l1.GetMessageFromDll(_langCode, "PrinterChanges");
            lblScaner.Text = l1.GetMessageFromDll(_langCode, "ScannerChanges");
            lblVideoCard.Text = l1.GetMessageFromDll(_langCode, "VideoCardChanges");
            lblWebcam.Text = l1.GetMessageFromDll(_langCode, "CammeraChanges");

            tsbSave.Text = l1.GetMessageFromDll(_langCode, "Save");
            if (_settingFor == 0)
            {
                lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus0");
            }
            if (_settingFor == 1)
            {
                lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus1") + " " + _agent.ComputerName + " " + l1.GetMessageFromDll(_langCode, "AlertSettingStatus3");
            }
            if (_settingFor == 2)
            {
                lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus2");
            }
        }

        private void chbNoAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNoAlertAll.Checked == true)
            {
                chbCpuNo.Checked = true;
                chbCpuSMS.Checked = false;
                chbCpuMail.Checked = false;
                chbCpuIcon.Checked = false;
                chbCpuDesktop.Checked = false;
                chbSendSMSAll.Checked = false;
                chbSendEmailAll.Checked = false;
                chbNotifyIconAll.Checked = false;
                chbDesktopAlertAll.Checked = false;
                chbMainNo.Checked = true;
                chbMainSms.Checked = false;
                chbMainEmail.Checked = false;
                chbMainIcon.Checked = false;
                chbMainDesktop.Checked = false;
                chbModemNo.Checked = true;
                chbModemSms.Checked = false;
                chbModemEmail.Checked = false;
                chbModemIcon.Checked = false;
                chbModemDesktop.Checked = false;
                chbCdromNo.Checked = true;
                chbCdromSms.Checked = false;
                chbCdromEmail.Checked = false;
                chbCdromIcon.Checked = false;
                chbCdromDesktop.Checked = false;
                chbScanerNo.Checked = true;
                chbScanerSms.Checked = false;
                chbScanerEmail.Checked = false;
                chbScanerIcon.Checked = false;
                chbScanerDesktop.Checked = false;
                chbWebcamNo.Checked = true;
                chbWebcamSms.Checked = false;
                chbWebcamEmail.Checked = false;
                chbWebcamIcon.Checked = false;
                chbWebcamDesktop.Checked = false;
                chbPrinterNo.Checked = true;
                chbPrinterSms.Checked = false;
                chbPrinterEmail.Checked = false;
                chbPrinterIcon.Checked = false;
                chbPrinterDesktop.Checked = false;
                chbMonitorNo.Checked = true;
                chbMonitorSms.Checked = false;
                chbMonitorEmail.Checked = false;
                chbMonitorIcon.Checked = false;
                chbMonitorDesktop.Checked = false;
                chbMouseNo.Checked = true;
                chbMouseSms.Checked = false;
                chbMouseEmail.Checked = false;
                chbMouseIcon.Checked = false;
                chbMouseDesktop.Checked = false;
                chbKeyboardNo.Checked = true;
                chbKeyboardSms.Checked = false;
                chbKeyboardEmail.Checked = false;
                chbKeyboardIcon.Checked = false;
                chbKeyboardDesktop.Checked = false;
                chbNetNo.Checked = true;
                chbNetSms.Checked = false;
                chbNetMail.Checked = false;
                chbNetIcon.Checked = false;
                chbNetDesktop.Checked = false;
                chbVideoCardNo.Checked = true;
                chbVideoCardSms.Checked = false;
                chbVideoCardEmail.Checked = false;
                chbVideoCardIcon.Checked = false;
                chbVideoCardDesktop.Checked = false;
                chbLogicDiskNo.Checked = true;
                chbLogicDiskSms.Checked = false;
                chbLogicDiskEmail.Checked = false;
                chbLogicDiskIcon.Checked = false;
                chbLogicDiskDesktop.Checked = false;
                chbHardDiskNo.Checked = true;
                chbHardDiskSms.Checked = false;
                chbHardDiskEmail.Checked = false;
                chbHardDiskIcon.Checked = false;
                chbHardDiskDesktop.Checked = false;
                chbMemoryNo.Checked = true;
                chbMemorySms.Checked = false;
                chbMemoryEmail.Checked = false;
                chbMemoryIcon.Checked = false;
                chbMemoryDesktop.Checked = false;
                chbBiosNo.Checked = true;
                chbBiosSms.Checked = false;
                chbBiosEmail.Checked = false;
                chbBiosIcon.Checked = false;
                chbBiosDesktop.Checked = false;

                chbCpuSound.Checked = false;
                chbMainboardSound.Checked = false;
                chbBiosSound.Checked = false;
                chbMemorySound.Checked = false;
                chbHardDiskSound.Checked = false;
                chbLogicDiskSound.Checked = false;
                chbVideoCardSound.Checked = false;
                chbNetSound.Checked = false;
                chbKeyboardSound.Checked = false;
                chbMouseSound.Checked = false;
                chbMonitorSound.Checked = false;
                chbPrinterSound.Checked = false;
                chbWebcamSound.Checked = false;
                chbScanerSound.Checked = false;
                chbCdromSound.Checked = false;
                chbModemSound.Checked = false;


            }
            if (chbNoAlertAll.Checked == false)
            {
                chbCpuNo.Checked = false;
                chbMainNo.Checked = false;
                chbModemNo.Checked = false;
                chbCdromNo.Checked = false;
                chbScanerNo.Checked = false;
                chbWebcamNo.Checked = false;
                chbPrinterNo.Checked = false;
                chbMonitorNo.Checked = false;
                chbMouseNo.Checked = false;
                chbKeyboardNo.Checked = false;
                chbNetNo.Checked = false;
                chbVideoCardNo.Checked = false;
                chbLogicDiskNo.Checked = false;
                chbHardDiskNo.Checked = false;
                chbMemoryNo.Checked = false;
                chbBiosNo.Checked = false;


            }
        }

        private void chbDesktopAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbDesktopAlertAll.Checked == true)
            {
                chbNoAlertAll.Checked = false;
                chbCpuDesktop.Checked = true;
                chbMainDesktop.Checked = true;
                chbModemDesktop.Checked = true;
                chbCdromDesktop.Checked = true;
                chbScanerDesktop.Checked = true;
                chbWebcamDesktop.Checked = true;
                chbPrinterDesktop.Checked = true;
                chbMonitorDesktop.Checked = true;
                chbMouseDesktop.Checked = true;
                chbKeyboardDesktop.Checked = true;
                chbNetDesktop.Checked = true;
                chbVideoCardDesktop.Checked = true;
                chbLogicDiskDesktop.Checked = true;
                chbHardDiskDesktop.Checked = true;
                chbMemoryDesktop.Checked = true;
                chbBiosDesktop.Checked = true;
            }
            if (chbDesktopAlertAll.Checked == false)
            {
                chbCpuDesktop.Checked = false;
                chbMainDesktop.Checked = false;
                chbModemDesktop.Checked = false;
                chbCdromDesktop.Checked = false;
                chbScanerDesktop.Checked = false;
                chbWebcamDesktop.Checked = false;
                chbPrinterDesktop.Checked = false;
                chbMonitorDesktop.Checked = false;
                chbMouseDesktop.Checked = false;
                chbNetDesktop.Checked = false;
                chbVideoCardDesktop.Checked = false;
                chbLogicDiskDesktop.Checked = false;
                chbHardDiskDesktop.Checked = false;
                chbMemoryDesktop.Checked = false;
                chbBiosDesktop.Checked = false;
                chbKeyboardDesktop.Checked = false;

            }
        }

        private void chbNotifyIconAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNotifyIconAll.Checked == true)
            {
                chbNoAlertAll.Checked = false;
                chbCpuIcon.Checked = true;
                chbMainIcon.Checked = true;
                chbModemIcon.Checked = true;
                chbCdromIcon.Checked = true;
                chbScanerIcon.Checked = true;
                chbWebcamIcon.Checked = true;
                chbPrinterIcon.Checked = true;
                chbMonitorIcon.Checked = true;
                chbMouseIcon.Checked = true;
                chbKeyboardIcon.Checked = true;
                chbVideoCardIcon.Checked = true;
                chbLogicDiskIcon.Checked = true;
                chbHardDiskIcon.Checked = true;
                chbMemoryIcon.Checked = true;
                chbBiosIcon.Checked = true;
                chbNetIcon.Checked = true;

            }
            if (chbNotifyIconAll.Checked == false)
            {
                chbCpuIcon.Checked = false;
                chbMainIcon.Checked = false;
                chbModemIcon.Checked = false;
                chbCdromIcon.Checked = false;
                chbScanerIcon.Checked = false;
                chbWebcamIcon.Checked = false;
                chbPrinterIcon.Checked = false;
                chbMonitorIcon.Checked = false;
                chbMouseIcon.Checked = false;
                chbKeyboardIcon.Checked = false;
                chbVideoCardIcon.Checked = false;
                chbLogicDiskIcon.Checked = false;
                chbHardDiskIcon.Checked = false;
                chbMemoryIcon.Checked = false;
                chbBiosIcon.Checked = false;
                chbNetIcon.Checked = false;

            }
        }

        private void chbSendEmailAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbSendEmailAll.Checked == true)
            {
                chbNoAlertAll.Checked = false;
                chbCpuMail.Checked = true;
                chbMainEmail.Checked = true;
                chbModemEmail.Checked = true;
                chbCdromEmail.Checked = true;
                chbScanerEmail.Checked = true;
                chbWebcamEmail.Checked = true;
                chbPrinterEmail.Checked = true;
                chbMonitorEmail.Checked = true;
                chbMouseEmail.Checked = true;
                chbKeyboardEmail.Checked = true;
                chbNetMail.Checked = true;
                chbVideoCardEmail.Checked = true;
                chbLogicDiskEmail.Checked = true;
                chbHardDiskEmail.Checked = true;
                chbMemoryEmail.Checked = true;
                chbBiosEmail.Checked = true;
            }
            if (chbSendEmailAll.Checked == false)
            {
                chbCpuMail.Checked = false;
                chbMainEmail.Checked = false;
                chbModemEmail.Checked = false;
                chbCdromEmail.Checked = false;
                chbScanerEmail.Checked = false;
                chbWebcamEmail.Checked = false;
                chbPrinterEmail.Checked = false;
                chbMonitorEmail.Checked = false;
                chbMouseEmail.Checked = false;
                chbKeyboardEmail.Checked = false;
                chbNetMail.Checked = false;
                chbVideoCardEmail.Checked = false;
                chbLogicDiskEmail.Checked = false;
                chbHardDiskEmail.Checked = false;
                chbMemoryEmail.Checked = false;
                chbBiosEmail.Checked = false;

            }

        }

        private void chbSendSMSAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbSendSMSAll.Checked == true)
            {
                chbNoAlertAll.Checked = false;
                chbCpuSMS.Checked = true;
                chbMainSms.Checked = true;
                chbModemSms.Checked = true;
                chbCdromSms.Checked = true;
                chbScanerSms.Checked = true;
                chbWebcamSms.Checked = true;
                chbPrinterSms.Checked = true;
                chbMonitorSms.Checked = true;
                chbMouseSms.Checked = true;
                chbKeyboardSms.Checked = true;
                chbNetSms.Checked = true;
                chbVideoCardSms.Checked = true;
                chbLogicDiskSms.Checked = true;
                chbHardDiskSms.Checked = true;
                chbMemorySms.Checked = true;
                chbBiosSms.Checked = true;
            }
            if (chbSendSMSAll.Checked == false)
            {
                chbCpuSMS.Checked = false;
                chbMainSms.Checked = false;
                chbModemSms.Checked = false;
                chbCdromSms.Checked = false;
                chbScanerSms.Checked = false;
                chbWebcamSms.Checked = false;
                chbPrinterSms.Checked = false;
                chbMonitorSms.Checked = false;
                chbMouseSms.Checked = false;
                chbKeyboardSms.Checked = false;
                chbNetSms.Checked = false;
                chbVideoCardSms.Checked = false;
                chbLogicDiskSms.Checked = false;
                chbHardDiskSms.Checked = false;
                chbMemorySms.Checked = false;
                chbBiosSms.Checked = false;
            }
        }

        private void chbCpuNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuNo.Checked == true)
            {
                chbCpuDesktop.Checked = false;
                chbCpuIcon.Checked = false;
                chbCpuMail.Checked = false;
                chbCpuSMS.Checked = false;
                chbCpuSound.Checked = false;
            }
        }

        private void chbMainNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainNo.Checked == true)
            {
                chbMainDesktop.Checked = false;
                chbMainIcon.Checked = false;
                chbMainEmail.Checked = false;
                chbMainSms.Checked = false;
                chbMainboardSound.Checked = false;
            }

        }

        private void chbBiosNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosNo.Checked == true)
            {
                chbBiosDesktop.Checked = false;
                chbBiosIcon.Checked = false;
                chbBiosEmail.Checked = false;
                chbBiosSms.Checked = false;
                chbBiosSound.Checked = false;
            }

        }

        private void chbMemoryNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemoryNo.Checked == true)
            {
                chbMemoryDesktop.Checked = false;
                chbMemoryIcon.Checked = false;
                chbMemoryEmail.Checked = false;
                chbMemorySms.Checked = false;
                chbMemorySound.Checked = false;
            }

        }

        private void chbHardDiskNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskNo.Checked == true)
            {
                chbHardDiskDesktop.Checked = false;
                chbHardDiskIcon.Checked = false;
                chbHardDiskEmail.Checked = false;
                chbHardDiskSms.Checked = false;
                chbHardDiskSound.Checked = false;
            }

        }

        private void chbLogicDiskNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskNo.Checked == true)
            {
                chbLogicDiskDesktop.Checked = false;
                chbLogicDiskIcon.Checked = false;
                chbLogicDiskEmail.Checked = false;
                chbLogicDiskSms.Checked = false;
                chbLogicDiskSound.Checked = false;
            }

        }

        private void chbVideoCardNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardNo.Checked == true)
            {
                chbVideoCardDesktop.Checked = false;
                chbVideoCardIcon.Checked = false;
                chbVideoCardEmail.Checked = false;
                chbVideoCardSms.Checked = false;
                chbVideoCardSound.Checked = false;
            }

        }

        private void chbNetNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetNo.Checked == true)
            {
                chbNetDesktop.Checked = false;
                chbNetIcon.Checked = false;
                chbNetMail.Checked = false;
                chbNetSms.Checked = false;
                chbNetSound.Checked = false;
            }

        }

        private void chbKeyboardNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardNo.Checked == true)
            {
                chbKeyboardDesktop.Checked = false;
                chbKeyboardIcon.Checked = false;
                chbKeyboardEmail.Checked = false;
                chbKeyboardSms.Checked = false;
                chbKeyboardSound.Checked = false;
            }

        }

        private void chbMouseNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseNo.Checked == true)
            {
                chbMouseDesktop.Checked = false;
                chbMouseIcon.Checked = false;
                chbMouseEmail.Checked = false;
                chbMouseSms.Checked = false;
                chbMouseSound.Checked = false;
            }

        }

        private void chbMonitorNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorNo.Checked == true)
            {
                chbMonitorDesktop.Checked = false;
                chbMonitorIcon.Checked = false;
                chbMonitorEmail.Checked = false;
                chbMonitorSms.Checked = false;
                chbMonitorSound.Checked = false;
            }

        }

        private void chbPrinterNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterNo.Checked == true)
            {
                chbPrinterDesktop.Checked = false;
                chbPrinterIcon.Checked = false;
                chbPrinterEmail.Checked = false;
                chbPrinterSms.Checked = false;
                chbPrinterSound.Checked = false;
            }

        }

        private void chbWebcamNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamNo.Checked == true)
            {
                chbWebcamDesktop.Checked = false;
                chbWebcamIcon.Checked = false;
                chbWebcamEmail.Checked = false;
                chbWebcamSms.Checked = false;
                chbWebcamSound.Checked = false;
            }

        }

        private void chbScanerNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerNo.Checked == true)
            {
                chbScanerDesktop.Checked = false;
                chbScanerIcon.Checked = false;
                chbScanerEmail.Checked = false;
                chbScanerSms.Checked = false;
                chbScanerSound.Checked = false;
            }

        }

        private void chbCdromNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromNo.Checked == true)
            {
                chbCdromDesktop.Checked = false;
                chbCdromIcon.Checked = false;
                chbCdromEmail.Checked = false;
                chbCdromSms.Checked = false;
                chbCdromSound.Checked = false;
            }

        }

        private void chbModemNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemNo.Checked == true)
            {
                chbModemDesktop.Checked = false;
                chbModemIcon.Checked = false;
                chbModemEmail.Checked = false;
                chbModemSms.Checked = false;
                chbModemSound.Checked = false;
            }

        }

        private void chbCpuDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuDesktop.Checked == true)
            {
                chbCpuNo.Checked = false;
                CpuAlertId = CpuAlertId + 1;
            }
            if (chbCpuDesktop.Checked == false)
            {
                CpuAlertId = CpuAlertId - 1;
            }
        }

        private void chbCpuIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuIcon.Checked == true)
            {
                chbCpuNo.Checked = false;
                CpuAlertId = CpuAlertId + 2;
            }
            if (chbCpuIcon.Checked == false)
            {
                CpuAlertId = CpuAlertId - 2;
            }

        }

        private void chbCpuMail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuMail.Checked == true)
            {
                chbCpuNo.Checked = false;
                CpuAlertId = CpuAlertId + 4;
            }
            if (chbCpuMail.Checked == false)
            {
                CpuAlertId = CpuAlertId - 4;
            }

        }

        private void chbCpuSMS_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuSMS.Checked == true)
            {
                chbCpuNo.Checked = false;
                CpuAlertId = CpuAlertId + 8;
            }
            if (chbCpuSMS.Checked == false)
            {
                CpuAlertId = CpuAlertId - 8;
            }

        }

        private void chbMainDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainDesktop.Checked == true)
            {
                chbMainNo.Checked = false;
                MainAlertId = MainAlertId + 1;
            }
            if (chbMainDesktop.Checked == false)
            {
                MainAlertId = MainAlertId - 1;
            }

        }

        private void chbMainIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainIcon.Checked == true)
            {
                chbMainNo.Checked = false;
                MainAlertId = MainAlertId + 2;
            }
            if (chbMainIcon.Checked == false)
            {
                MainAlertId = MainAlertId - 2;
            }
        }

        private void chbMainEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainEmail.Checked == true)
            {
                chbMainNo.Checked = false;
                MainAlertId = MainAlertId + 4;
            }
            if (chbMainEmail.Checked == false)
            {
                MainAlertId = MainAlertId - 4;
            }
        }

        private void chbMainSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainSms.Checked == true)
            {
                chbMainNo.Checked = false;
                MainAlertId = MainAlertId + 8;
            }
            if (chbMainSms.Checked == false)
            {
                MainAlertId = MainAlertId - 8;
            }

        }

        private void chbBiosDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosDesktop.Checked == true)
            {
                chbBiosNo.Checked = false;
                BiosAlertId = BiosAlertId + 1;
            }
            if (chbBiosDesktop.Checked == false)
            {
                BiosAlertId = BiosAlertId - 1;
            }
        }

        private void chbBiosIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosIcon.Checked == true)
            {
                chbBiosNo.Checked = false;
                BiosAlertId = BiosAlertId + 2;
            }
            if (chbBiosIcon.Checked == false)
            {
                BiosAlertId = BiosAlertId - 2;
            }

        }

        private void chbBiosEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosEmail.Checked == true)
            {
                chbBiosNo.Checked = false;
                BiosAlertId = BiosAlertId + 4;
            }
            if (chbBiosEmail.Checked == false)
            {
                BiosAlertId = BiosAlertId - 4;
            }

        }

        private void chbBiosSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosSms.Checked == true)
            {
                chbBiosNo.Checked = false;
                BiosAlertId = BiosAlertId + 8;
            }
            if (chbBiosSms.Checked == false)
            {
                BiosAlertId = BiosAlertId - 8;
            }
        }

        private void chbMemoryDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemoryDesktop.Checked == true)
            {
                chbMemoryNo.Checked = false;
                MemoryAlertId = MemoryAlertId + 1;
            }
            if (chbMemoryDesktop.Checked == false)
            {
                MemoryAlertId = MemoryAlertId - 1;
            }

        }

        private void chbMemoryIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemoryIcon.Checked == true)
            {
                chbMemoryNo.Checked = false;
                MemoryAlertId = MemoryAlertId + 2;
            }
            if (chbMemoryIcon.Checked == false)
            {
                MemoryAlertId = MemoryAlertId - 2;
            }
        }

        private void chbMemoryEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemoryEmail.Checked == true)
            {
                chbMemoryNo.Checked = false;
                MemoryAlertId = MemoryAlertId + 4;
            }
            if (chbMemoryEmail.Checked == false)
            {
                MemoryAlertId = MemoryAlertId - 4;
            }
        }

        private void chbMemorySms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemorySms.Checked == true)
            {
                chbMemoryNo.Checked = false;
                MemoryAlertId = MemoryAlertId + 8;
            }
            if (chbMemorySms.Checked == false)
            {
                MemoryAlertId = MemoryAlertId - 8;
            }
        }

        private void chbHardDiskDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskDesktop.Checked == true)
            {
                chbHardDiskNo.Checked = false;
                HardDiskAlertId = HardDiskAlertId + 1;
            }
            if (chbHardDiskDesktop.Checked == false)
            {
                HardDiskAlertId = HardDiskAlertId - 1;
            }

        }

        private void chbHardDiskIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskIcon.Checked == true)
            {
                chbHardDiskNo.Checked = false;
                HardDiskAlertId = HardDiskAlertId + 2;
            }
            if (chbHardDiskIcon.Checked == false)
            {
                HardDiskAlertId = HardDiskAlertId - 2;
            }
        }

        private void chbHardDiskEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskEmail.Checked == true)
            {
                chbHardDiskNo.Checked = false;
                HardDiskAlertId = HardDiskAlertId + 4;
            }
            if (chbHardDiskEmail.Checked == false)
            {
                HardDiskAlertId = HardDiskAlertId - 4;
            }
        }

        private void chbHardDiskSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskSms.Checked == true)
            {
                chbHardDiskNo.Checked = false;
                HardDiskAlertId = HardDiskAlertId + 8;
            }
            if (chbHardDiskSms.Checked == false)
            {
                HardDiskAlertId = HardDiskAlertId - 8;
            }
        }

        private void chbLogicDiskDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskDesktop.Checked == true)
            {
                chbLogicDiskNo.Checked = false;
                LogicDiskAlertId = LogicDiskAlertId + 1;
            }
            if (chbLogicDiskDesktop.Checked == false)
            {
                LogicDiskAlertId = LogicDiskAlertId - 1;
            }
        }

        private void chbLogicDiskIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskIcon.Checked == true)
            {
                chbLogicDiskNo.Checked = false;
                LogicDiskAlertId = LogicDiskAlertId + 2;
            }
            if (chbLogicDiskIcon.Checked == false)
            {
                LogicDiskAlertId = LogicDiskAlertId - 2;
            }
        }

        private void chbLogicDiskEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskEmail.Checked == true)
            {
                chbLogicDiskNo.Checked = false;
                LogicDiskAlertId = LogicDiskAlertId + 4;
            }
            if (chbLogicDiskEmail.Checked == false)
            {
                LogicDiskAlertId = LogicDiskAlertId - 4;
            }
        }

        private void chbLogicDiskSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskSms.Checked == true)
            {
                chbLogicDiskNo.Checked = false;
                LogicDiskAlertId = LogicDiskAlertId + 8;
            }
            if (chbLogicDiskSms.Checked == false)
            {
                LogicDiskAlertId = LogicDiskAlertId - 8;
            }
        }

        private void chbVideoCardDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardDesktop.Checked == true)
            {
                chbVideoCardNo.Checked = false;
                VideoCardAlertId = VideoCardAlertId + 1;
            }
            if (chbVideoCardDesktop.Checked == false)
            {
                VideoCardAlertId = VideoCardAlertId - 1;
            }
        }

        private void chbVideoCardIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardIcon.Checked == true)
            {
                chbVideoCardNo.Checked = false;
                VideoCardAlertId = VideoCardAlertId + 2;
            }
            if (chbVideoCardIcon.Checked == false)
            {
                VideoCardAlertId = VideoCardAlertId - 2;
            }
        }

        private void chbVideoCardEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardEmail.Checked == true)
            {
                chbVideoCardNo.Checked = false;
                VideoCardAlertId = VideoCardAlertId + 4;
            }
            if (chbVideoCardEmail.Checked == false)
            {
                VideoCardAlertId = VideoCardAlertId - 4;
            }
        }

        private void chbVideoCardSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardSms.Checked == true)
            {
                chbVideoCardNo.Checked = false;
                VideoCardAlertId = VideoCardAlertId + 8;
            }
            if (chbVideoCardSms.Checked == false)
            {
                VideoCardAlertId = VideoCardAlertId - 8;
            }
        }

        private void chbNetDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetDesktop.Checked == true)
            {
                chbNetNo.Checked = false;
                NetAlertId = NetAlertId + 1;
            }
            if (chbNetDesktop.Checked == false)
            {
                NetAlertId = NetAlertId - 1;
            }
        }

        private void chbNetIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetIcon.Checked == true)
            {
                chbNetNo.Checked = false;
                NetAlertId = NetAlertId + 2;
            }
            if (chbNetIcon.Checked == false)
            {
                NetAlertId = NetAlertId - 2;
            }
        }

        private void chbNetMail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetMail.Checked == true)
            {
                chbNetNo.Checked = false;
                NetAlertId = NetAlertId + 4;
            }
            if (chbNetMail.Checked == false)
            {
                NetAlertId = NetAlertId - 4;
            }
        }

        private void chbNetSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetSms.Checked == true)
            {
                chbNetNo.Checked = false;
                NetAlertId = NetAlertId + 8;
            }
            if (chbNetSms.Checked == false)
            {
                NetAlertId = NetAlertId - 8;
            }
        }

        private void chbKeyboardDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardDesktop.Checked == true)
            {
                chbKeyboardNo.Checked = false;
                KeyboardAlertId = KeyboardAlertId + 1;
            }
            if (chbKeyboardDesktop.Checked == false)
            {
                KeyboardAlertId = KeyboardAlertId - 1;
            }
        }

        private void chbKeyboardIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardIcon.Checked == true)
            {
                chbKeyboardNo.Checked = false;
                KeyboardAlertId = KeyboardAlertId + 2;
            }
            if (chbKeyboardIcon.Checked == false)
            {
                KeyboardAlertId = KeyboardAlertId - 2;
            }
        }

        private void chbKeyboardEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardEmail.Checked == true)
            {
                chbKeyboardNo.Checked = false;
                KeyboardAlertId = KeyboardAlertId + 4;
            }
            if (chbKeyboardEmail.Checked == false)
            {
                KeyboardAlertId = KeyboardAlertId - 4;
            }
        }

        private void chbKeyboardSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardSms.Checked == true)
            {
                chbKeyboardNo.Checked = false;
                KeyboardAlertId = KeyboardAlertId + 8;
            }
            if (chbKeyboardSms.Checked == false)
            {
                KeyboardAlertId = KeyboardAlertId - 8;
            }
        }

        private void chbMouseDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseDesktop.Checked == true)
            {
                chbMouseNo.Checked = false;
                MouseAlertId = MouseAlertId + 1;
            }
            if (chbMouseDesktop.Checked == false)
            {
                MouseAlertId = MouseAlertId - 1;
            }
        }

        private void chbMouseIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseIcon.Checked == true)
            {
                chbMouseNo.Checked = false;
                MouseAlertId = MouseAlertId + 2;
            }
            if (chbMouseIcon.Checked == false)
            {
                MouseAlertId = MouseAlertId - 2;
            }
        }

        private void chbMouseEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseEmail.Checked == true)
            {
                chbMouseNo.Checked = false;
                MouseAlertId = MouseAlertId + 4;
            }
            if (chbMouseEmail.Checked == false)
            {
                MouseAlertId = MouseAlertId - 4;
            }
        }

        private void chbMouseSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseSms.Checked == true)
            {
                chbMouseNo.Checked = false;
                MouseAlertId = MouseAlertId + 8;
            }
            if (chbMouseSms.Checked == false)
            {
                MouseAlertId = MouseAlertId - 8;
            }
        }

        private void chbMonitorDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorDesktop.Checked == true)
            {
                chbMonitorNo.Checked = false;
                MonitorAlertId = MonitorAlertId + 1;
            }
            if (chbMonitorDesktop.Checked == false)
            {
                MonitorAlertId = MonitorAlertId - 1;
            }
        }

        private void chbMonitorIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorIcon.Checked == true)
            {
                chbMonitorNo.Checked = false;
                MonitorAlertId = MonitorAlertId + 2;
            }
            if (chbMonitorIcon.Checked == false)
            {
                MonitorAlertId = MonitorAlertId - 2;
            }
        }

        private void chbMonitorEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorEmail.Checked == true)
            {
                chbMonitorNo.Checked = false;
                MonitorAlertId = MonitorAlertId + 4;
            }
            if (chbMonitorEmail.Checked == false)
            {
                MonitorAlertId = MonitorAlertId - 4;
            }
        }

        private void chbMonitorSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorSms.Checked == true)
            {
                chbMonitorNo.Checked = false;
                MonitorAlertId = MonitorAlertId + 8;
            }
            if (chbMonitorSms.Checked == false)
            {
                MonitorAlertId = MonitorAlertId - 8;
            }
        }

        private void chbPrinterDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterDesktop.Checked == true)
            {
                chbPrinterNo.Checked = false;
                PrinterAlertId = PrinterAlertId + 1;
            }
            if (chbPrinterDesktop.Checked == false)
            {
                PrinterAlertId = PrinterAlertId - 1;
            }
        }

        private void chbPrinterIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterIcon.Checked == true)
            {
                chbPrinterNo.Checked = false;
                PrinterAlertId = PrinterAlertId + 2;
            }
            if (chbPrinterIcon.Checked == false)
            {
                PrinterAlertId = PrinterAlertId - 2;
            }
        }

        private void chbPrinterEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterEmail.Checked == true)
            {
                chbPrinterNo.Checked = false;
                PrinterAlertId = PrinterAlertId + 4;
            }
            if (chbPrinterEmail.Checked == false)
            {
                PrinterAlertId = PrinterAlertId - 4;
            }
        }

        private void chbPrinterSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterSms.Checked == true)
            {
                chbPrinterNo.Checked = false;
                PrinterAlertId = PrinterAlertId + 8;
            }
            if (chbPrinterSms.Checked == false)
            {
                PrinterAlertId = PrinterAlertId - 8;
            }
        }

        private void chbWebcamDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamDesktop.Checked == true)
            {
                chbWebcamNo.Checked = false;
                WebcamAlertId = WebcamAlertId + 1;
            }
            if (chbWebcamDesktop.Checked == false)
            {
                WebcamAlertId = WebcamAlertId - 1;
            }
        }

        private void chbWebcamIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamIcon.Checked == true)
            {
                chbWebcamNo.Checked = false;
                WebcamAlertId = WebcamAlertId + 2;
            }
            if (chbWebcamIcon.Checked == false)
            {
                WebcamAlertId = WebcamAlertId - 2;
            }
        }

        private void chbWebcamEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamEmail.Checked == true)
            {
                chbWebcamNo.Checked = false;
                WebcamAlertId = WebcamAlertId + 4;
            }
            if (chbWebcamEmail.Checked == false)
            {
                WebcamAlertId = WebcamAlertId - 4;
            }
        }

        private void chbWebcamSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamSms.Checked == true)
            {
                chbWebcamNo.Checked = false;
                WebcamAlertId = WebcamAlertId + 8;
            }
            if (chbWebcamSms.Checked == false)
            {
                WebcamAlertId = WebcamAlertId - 8;
            }
        }

        private void chbScanerDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerDesktop.Checked == true)
            {
                chbScanerNo.Checked = false;
                ScanerAlertId = ScanerAlertId + 1;
            }
            if (chbScanerDesktop.Checked == false)
            {
                ScanerAlertId = ScanerAlertId - 1;
            }
        }

        private void chbScanerIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerIcon.Checked == true)
            {
                chbScanerNo.Checked = false;
                ScanerAlertId = ScanerAlertId + 2;
            }
            if (chbScanerIcon.Checked == false)
            {
                ScanerAlertId = ScanerAlertId - 2;
            }
        }

        private void chbScanerEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerEmail.Checked == true)
            {
                chbScanerNo.Checked = false;
                ScanerAlertId = ScanerAlertId + 4;
            }
            if (chbScanerEmail.Checked == false)
            {
                ScanerAlertId = ScanerAlertId - 4;
            }
        }

        private void chbScanerSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerSms.Checked == true)
            {
                chbScanerNo.Checked = false;
                ScanerAlertId = ScanerAlertId + 8;
            }
            if (chbScanerSms.Checked == false)
            {
                ScanerAlertId = ScanerAlertId - 8;
            }
        }

        private void chbCdromDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromDesktop.Checked == true)
            {
                chbCdromNo.Checked = false;
                CdromAlertId = CdromAlertId + 1;
            }
            if (chbCdromDesktop.Checked == false)
            {
                CdromAlertId = CdromAlertId - 1;
            }
        }

        private void chbCdromIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromIcon.Checked == true)
            {
                chbCdromNo.Checked = false;
                CdromAlertId = CdromAlertId + 2;
            }
            if (chbCdromIcon.Checked == false)
            {
                CdromAlertId = CdromAlertId - 2;
            }
        }

        private void chbCdromEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromEmail.Checked == true)
            {
                chbCdromNo.Checked = false;
                CdromAlertId = CdromAlertId + 4;
            }
            if (chbCdromEmail.Checked == false)
            {
                CdromAlertId = CdromAlertId - 4;
            }
        }

        private void chbCdromSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromSms.Checked == true)
            {
                chbCdromNo.Checked = false;
                CdromAlertId = CdromAlertId + 8;
            }
            if (chbCdromSms.Checked == false)
            {
                CdromAlertId = CdromAlertId - 8;
            }
        }

        private void chbModemDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemDesktop.Checked == true)
            {
                chbModemNo.Checked = false;
                ModemAlertId = ModemAlertId + 1;
            }
            if (chbModemDesktop.Checked == false)
            {
                ModemAlertId = ModemAlertId - 1;
            }
        }

        private void chbModemIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemIcon.Checked == true)
            {
                chbModemNo.Checked = false;
                ModemAlertId = ModemAlertId + 2;
            }
            if (chbModemIcon.Checked == false)
            {
                ModemAlertId = ModemAlertId - 2;
            }
        }

        private void chbModemEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemEmail.Checked == true)
            {
                chbModemNo.Checked = false;
                ModemAlertId = ModemAlertId + 4;
            }
            if (chbModemEmail.Checked == false)
            {
                ModemAlertId = ModemAlertId - 4;
            }
        }

        private void chbModemSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemSms.Checked == true)
            {
                chbModemNo.Checked = false;
                ModemAlertId = ModemAlertId + 8;
            }
            if (chbModemSms.Checked == false)
            {
                ModemAlertId = ModemAlertId - 8;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveSettingToSql("1", CpuAlertId, CpuSoundId, CpuSoundPath);
            SaveSettingToSql("2", MainAlertId, MainSoundId, MainSoundPath);
            SaveSettingToSql("3", BiosAlertId, BiosSoundId, BiosSoundPath);
            SaveSettingToSql("4", MemoryAlertId, MemorySoundId, MemorySoundPath);
            SaveSettingToSql("5", HardDiskAlertId, HardDiskSoundId, HardDiskSoundPath);
            SaveSettingToSql("6", LogicDiskAlertId, LogicDiskSoundId, LogicDiskSoundPath);
            SaveSettingToSql("7", VideoCardAlertId, VideoCardSoundId, VideoCardSoundPath);
            SaveSettingToSql("8", NetAlertId, NetSoundId, NetSoundPath);
            SaveSettingToSql("9", KeyboardAlertId, KeyboardSoundId, KeyboardSoundPath);
            SaveSettingToSql("10", MouseAlertId, MouseSoundId, MouseSoundPath);
            SaveSettingToSql("11", MonitorAlertId, MonitorSoundId, MonitorSoundPath);
            SaveSettingToSql("12", PrinterAlertId, PrinterSoundId, PrinterSoundPath);
            SaveSettingToSql("13", WebcamAlertId, WebcamSoundId, WebcamSoundPath);
            SaveSettingToSql("14", ScanerAlertId, ScanerSoundId, ScanerSoundPath);
            SaveSettingToSql("15", CdromAlertId, CdromSoundId, CdromSoundPath);
            SaveSettingToSql("16", ModemAlertId, ModemSoundId, ModemSoundPath);
            this.Close();

        }

        private void SaveSettingToSql(string SubjectId, int AlertId)
        {
            SQLAccess sql = new SQLAccess();

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAllSystemAlertSubjects.ToString();
            string[,] newparams = new string[2, 2];
            newparams[0, 0] = "@AlertId";
            newparams[1, 0] = "@SubjectId";

            newparams[0, 1] = Convert.ToString(AlertId);
            newparams[1, 1] = SubjectId;
            int r = sql.IntExcuteSP(newparams);
        }

        private void SaveSettingToSql(string SubjectId, int AlertId,int SoundId,string SoundPath)
        {
            SQLAccess sql = new SQLAccess();

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAllSystemAlertSubjects.ToString();
            string[,] newparams = new string[4, 2];
            newparams[0, 0] = "@AlertId";
            newparams[1, 0] = "@SubjectId";
            newparams[2, 0] = "@SoundId";
            newparams[3, 0] = "@SoundPath";

            newparams[0, 1] = Convert.ToString(AlertId);
            newparams[1, 1] = SubjectId;
            newparams[2, 1] = Convert.ToString(SoundId);
            if (SoundId == 1 && SoundPath == "")
            {
                newparams[3, 1] = AllSoundPath;
            }
            else
                newparams[3, 1] = SoundPath;

            int r = sql.IntExcuteSP(newparams);
        }

        private void chbSoundAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbSoundAll.Checked == true)
            {
                chbNoAlertAll.Checked = false;
                chbCpuSound.Checked = true;
                chbMainboardSound.Checked = true;
                chbModemSound.Checked = true;
                chbCdromSound.Checked = true;
                chbScanerSound.Checked = true;
                chbWebcamSound.Checked = true;
                chbPrinterSound.Checked = true;
                chbMonitorSound.Checked = true;
                chbMouseSound.Checked = true;
                chbKeyboardSound.Checked = true;
                chbNetSound.Checked = true;
                chbVideoCardSound.Checked = true;
                chbLogicDiskSound.Checked = true;
                chbHardDiskSound.Checked = true;
                chbMemorySound.Checked = true;
                chbBiosSound.Checked = true;
            }
            if (chbSoundAll.Checked == false)
            {
                chbCpuSound.Checked = false;
                chbMainboardSound.Checked = false;
                chbModemSound.Checked = false;
                chbCdromSound.Checked = false;
                chbScanerSound.Checked = false;
                chbWebcamSound.Checked = false;
                chbPrinterSound.Checked = false;
                chbMonitorSound.Checked = false;
                chbMouseSound.Checked = false;
                chbNetSound.Checked = false;
                chbVideoCardSound.Checked = false;
                chbLogicDiskSound.Checked = false;
                chbHardDiskSound.Checked = false;
                chbMemorySound.Checked = false;
                chbBiosSound.Checked = false;
                chbKeyboardSound.Checked = false;

            }

        }

        private void chbCpuSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCpuSound.Checked == true)
                CpuSoundId = 1;
            if (chbCpuSound.Checked == false)
            {
                CpuSoundId = 0;
                CpuSoundPath = "";
            }
                
        }

        private void chbMainboardSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMainboardSound.Checked == true)
                MainSoundId = 1;
            if (chbMainboardSound.Checked == false)
            {
                MainSoundId = 0;
                MainSoundPath = "";
            }
                
        }

        private void chbBiosSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBiosSound.Checked == true)
                BiosSoundId = 1;
            if (chbBiosSound.Checked == false)
            {
                BiosSoundId = 0;
                BiosSoundPath = "";
            }
                
        }

        private void chbMemorySound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMemorySound.Checked == true)
                MemorySoundId = 1;
            if (chbMemorySound.Checked == false)
            {
                MemorySoundId = 0;
                MemorySoundPath = "";
            }
                
           
        }

        private void chbHardDiskSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbHardDiskSound.Checked == true)
                HardDiskSoundId = 1;
            if (chbHardDiskSound.Checked == false)
            {
                HardDiskSoundId = 0;
                HardDiskSoundPath = "";
            }
                
        }

        private void chbLogicDiskSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbLogicDiskSound.Checked == true)
                LogicDiskSoundId = 1;
            if (chbLogicDiskSound.Checked == false)
            {
                LogicDiskSoundId = 0;
                LogicDiskSoundPath = "";
            }
                
        }

        private void chbVideoCardSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbVideoCardSound.Checked == true)
                VideoCardSoundId = 1;
            if (chbVideoCardSound.Checked == false)
            {
                VideoCardSoundId = 0;
                VideoCardSoundPath = "";
            }
                
        }

        private void chbNetSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbNetSound.Checked == true)
                NetSoundId = 1;
            if (chbNetSound.Checked == false)
            {
                NetSoundId = 0;
                NetSoundPath = "";
            }
                
        }

        private void chbKeyboardSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbKeyboardSound.Checked == true)
                KeyboardSoundId = 1;
            if (chbKeyboardSound.Checked == false)
            {
                KeyboardSoundId = 0;
                KeyboardSoundPath = "";
            }
                
        }

        private void chbMouseSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMouseSound.Checked == true)
                MouseSoundId = 1;
            if (chbMouseSound.Checked == false)
            {
                MouseSoundId = 0;
                MouseSoundPath = "";
            }
                
        }

        private void chbMonitorSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbMonitorSound.Checked == true)
                MonitorSoundId = 1;
            if (chbMonitorSound.Checked == false)
            {
                MonitorSoundId = 0;
                MonitorSoundPath = "";
            }
                
        }

        private void chbPrinterSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbPrinterSound.Checked == true)
                PrinterSoundId = 1;
            if (chbPrinterSound.Checked == false)
            {
                PrinterSoundId = 0;
                PrinterSoundPath = "";
            }
                
        }

        private void chbWebcamSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbWebcamSound.Checked == true)
                WebcamSoundId = 1;
            if (chbWebcamSound.Checked == false)
            {
                WebcamSoundId = 0;
                WebcamSoundPath = "";
            }
                
        }

        private void chbScanerSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbScanerSound.Checked == true)
                ScanerSoundId = 1;
            if (chbScanerSound.Checked == false)
            {
                ScanerSoundId = 0;
                ScanerSoundPath = "";
            }
                
        }

        private void chbCdromSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbCdromSound.Checked == true)
                CdromSoundId = 1;
            if (chbCdromSound.Checked == false)
            {
                CdromSoundId = 0;
                CdromSoundPath = "";
            }
                
        }

        private void chbModemSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbModemSound.Checked == true)
                ModemSoundId = 1;
            if (chbModemSound.Checked == false)
            {
                ModemSoundId = 0;
                ModemSoundPath = "";
            }
               
        }

        private void btnSoundAll_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                AllSoundPath = openFileDialog1.FileName;
                chbSoundAll.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

            }
            else
                AllSoundPath = "";
        }

        private void btnCpuSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                CpuSoundPath = openFileDialog1.FileName;
                chbCpuSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

            }
            else
                CpuSoundPath = "";
        }

        private void btnMainboardSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                MainSoundPath = openFileDialog1.FileName;
                chbMainboardSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                MainSoundPath = "";

        }

        private void btnBiosSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                BiosSoundPath = openFileDialog1.FileName;
                chbBiosSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                BiosSoundPath = "";

        }

        private void btnMemorySound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                MemorySoundPath = openFileDialog1.FileName;
                chbMemorySound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                MemorySoundPath = "";

        }

        private void btnHardDiskSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                HardDiskSoundPath = openFileDialog1.FileName;
                chbHardDiskSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                HardDiskSoundPath = "";

        }

        private void btnLogicDiskSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                LogicDiskSoundPath = openFileDialog1.FileName;
                chbLogicDiskSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                LogicDiskSoundPath = "";

        }

        private void btnVideoCardSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                VideoCardSoundPath = openFileDialog1.FileName;
                chbVideoCardSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                VideoCardSoundPath = "";

        }

        private void btnNetSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                NetSoundPath = openFileDialog1.FileName;
                chbNetSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                NetSoundPath = "";

        }

        private void btnKeyboardSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                KeyboardSoundPath = openFileDialog1.FileName;
                chbKeyboardSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                KeyboardSoundPath = "";

        }

        private void btnMouseSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                MouseSoundPath = openFileDialog1.FileName;
                chbMouseSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                MouseSoundPath = "";

        }

        private void btnMonitorSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                MonitorSoundPath = openFileDialog1.FileName;
                chbMonitorSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                MonitorSoundPath = "";

        }

        private void btnPrinterSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                PrinterSoundPath = openFileDialog1.FileName;
                chbPrinterSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                PrinterSoundPath = "";

        }

        private void btnWebcamSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                WebcamSoundPath = openFileDialog1.FileName;
                chbWebcamSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                WebcamSoundPath = "";

        }

        private void btnScanerSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                ScanerSoundPath = openFileDialog1.FileName;
                chbScanerSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                ScanerSoundPath = "";
        }

        private void btnCdromSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                CdromSoundPath = openFileDialog1.FileName;
                chbCdromSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                CdromSoundPath = "";
        }

        private void btnModemSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            openFileDialog1.Title = "";

            openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                ModemSoundPath = openFileDialog1.FileName;
                chbModemSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            }
            else
                ModemSoundPath = "";
        }
    }
}
