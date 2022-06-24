using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ITCA.Classes;
using ITCA.Forms;
using ITCA.Properties;
using ITCL;

namespace ITCA.Forms.RtoL
{
    public partial class frmAgentGeneralInfo : Form
    {
        private Agents _agent;
        private Thread _tAgentDetail;

        public frmAgentGeneralInfo(Agents agent)
        {
            _agent = agent;
            InitializeComponent();
        }

        private void GetAgentDetails()
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();

            // Get CPU Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetProcessors.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            int _rowCount = dt.Rows.Count;

            _agent.CPUNumberOfCores = new string[_rowCount];
            _agent.CPUProcessorId = new string[_rowCount];
            _agent.CPUSocketDesignation = new string[_rowCount];
            _agent.CPUVersion = new string[_rowCount];
            _agent.CPUCurrentClockSpeed = new string[_rowCount];
            _agent.CPUStatus = new string[_rowCount];
            _agent.CPUL2CacheSize = new string[_rowCount];
            _agent.CPUNumberOfLogicalProcessors = new string[_rowCount];
                        
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.CPUNumberOfCores[i] = dt.Rows[i]["NumberOfCores"].ToString();
                _agent.CPUProcessorId[i] = dt.Rows[i]["ProcessorID"].ToString();
                _agent.CPUSocketDesignation[i] = dt.Rows[i]["SocketDesignation"].ToString();
                _agent.CPUVersion[i] = dt.Rows[i]["Versions"].ToString();
                _agent.CPUCurrentClockSpeed[i] = dt.Rows[i]["CurrentClockSpeed"].ToString();
                _agent.CPUStatus[i] = dt.Rows[i]["CpuStatus"].ToString();
                _agent.CPUL2CacheSize[i] = dt.Rows[i]["L2CachSize"].ToString();
                _agent.CPUNumberOfLogicalProcessors[i] = dt.Rows[i]["NumberOfLagicalCpu"].ToString();
            }

            dt = null;           

            // Get Hard Disk Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetHardDisk.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;

            _agent.HardDiskSignature = new string[_rowCount];
            _agent.HardDiskSize = new string[_rowCount];
            _agent.HardDiskPartitions = new string[_rowCount];
            _agent.HardDiskPNPDeviceID = new string[_rowCount];
           
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.HardDiskSignature[i] = dt.Rows[i]["Signatures"].ToString();
                _agent.HardDiskSize[i] = dt.Rows[i]["HardSize"].ToString();
                _agent.HardDiskPartitions[i] = dt.Rows[i]["Partitiones"].ToString();
                _agent.HardDiskPNPDeviceID[i] = dt.Rows[i]["PNPDeviceID"].ToString();               
            }

            dt = null;

            // Get Memory Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMemory.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.BankLabel = new string[_rowCount];
            _agent.Speed = new string[_rowCount];
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.BankLabel[i] = dt.Rows[i]["BankLabel"].ToString();
                _agent.Speed[i] = dt.Rows[i]["Speed"].ToString();
            }
            dt = null;

            //Get Network Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetNetworkAdapter.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            _rowCount = dt.Rows.Count;
            _agent.NetDescription = new string[_rowCount];
            _agent.NetAdapterType = new string[_rowCount];
            _agent.NetMACAddress = new string[_rowCount];
            _agent.NetManufacturer = new string[_rowCount];
            _agent.NetConnectionID = new string[_rowCount];
            _agent.NetPNPDeviceID = new string[_rowCount];
            _agent.NetTimeOfLastReset = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.NetDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agent.NetAdapterType[i] = dt.Rows[i]["AdapterType"].ToString();
                _agent.NetMACAddress[i] = dt.Rows[i]["MACAddress"].ToString();
                _agent.NetManufacturer[i] = dt.Rows[i]["Manufacturer"].ToString();
                _agent.NetConnectionID[i] = dt.Rows[i]["NetConnectionID"].ToString();
                _agent.NetPNPDeviceID[i] = dt.Rows[i]["PNPDeviceID"].ToString();
                _agent.NetTimeOfLastReset[i] = dt.Rows[i]["TimeOfLastReset"].ToString();
            }
            dt = null;

            //Get videocard Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetVideoCard.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.DriverDate = new string[_rowCount];
            _agent.DriverVersion = new string[_rowCount];
            _agent.VideoProcessor = new string[_rowCount];
            _agent.VideoModeDescription = new string[_rowCount];
            _agent.AdapterRAM = new string[_rowCount];
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.DriverDate[i] = dt.Rows[i]["DriverDate"].ToString();
                _agent.DriverVersion[i] = dt.Rows[i]["DriverVersion"].ToString();
                _agent.VideoProcessor[i] = dt.Rows[i]["VideoProcessor"].ToString();
                _agent.VideoModeDescription[i] = dt.Rows[i]["VideoMode"].ToString();
                _agent.AdapterRAM[i] = dt.Rows[i]["AdapterRam"].ToString();
            }
            dt = null;

            //Get CDROM Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetCDROM.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.CDRomName = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.CDRomName[i] = dt.Rows[i]["CdromName"].ToString();                
            }

            dt = null;

            // Get Logic Disk Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLagicDisk.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;

            _agent.LogicDiskCaption = new string[_rowCount];
            _agent.LogicDiskDescription = new string[_rowCount];
            _agent.LogicDiskFileSystem = new string[_rowCount];
            _agent.LogicDiskFreeSpace = new string[_rowCount];
            _agent.LogicDiskSize = new string[_rowCount];
            _agent.LogicDiskVolumeName = new string[_rowCount];
            _agent.LogicDiskVolumeSerialNumber = new string[_rowCount];
            
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.LogicDiskCaption[i] = dt.Rows[i]["Caption"].ToString();
                _agent.LogicDiskDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agent.LogicDiskFileSystem[i] = dt.Rows[i]["FileSystem"].ToString();
                _agent.LogicDiskFreeSpace[i] = dt.Rows[i]["FreeSpace"].ToString();
                _agent.LogicDiskSize[i] = dt.Rows[i]["VolumeSize"].ToString();
                _agent.LogicDiskVolumeName[i] = dt.Rows[i]["VolumeName"].ToString();
                _agent.LogicDiskVolumeSerialNumber[i] = dt.Rows[i]["VolumeSerialNumber"].ToString();
            }

            dt = null;

            // Get Modem Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetModem.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.Modem = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.Modem[i] = dt.Rows[i]["ModemName"].ToString();
            }

            dt = null;

            // Get Printer Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPrinter.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.PrinterName = new string[_rowCount];
            _agent.PrinterNetwork = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.PrinterName[i] = dt.Rows[i]["PrinterName"].ToString();
                _agent.PrinterNetwork[i] = dt.Rows[i]["Network"].ToString();

            }

            dt = null;

            // Get Other Devices Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPublicDevices.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            _agent.Monitor = dt.Rows[0]["Monitor"].ToString();
            _agent.Keyboard = dt.Rows[0]["Keyboard"].ToString();
            _agent.Mouse = dt.Rows[0]["Mouse"].ToString();
            _agent.Scanner = dt.Rows[0]["Scanner"].ToString();
            _agent.Camera = dt.Rows[0]["Camera"].ToString();
            
            dt = null;

            // Get Users Account Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetUserAccounts.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.UserAccountName = new string[_rowCount];
            _agent.UserAccountSID = new string[_rowCount];
            _agent.UserAccountDescription = new string[_rowCount];
            _agent.UserAccountStatus = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.UserAccountName[i] = dt.Rows[i]["UserName"].ToString();
                _agent.UserAccountSID[i] = dt.Rows[i]["SIDs"].ToString();
                _agent.UserAccountDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agent.UserAccountStatus[i] = dt.Rows[i]["Statuss"].ToString();
            }

            dt = null;

            // Get Users Group Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetUserGroups.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.UserGroupName = new string[_rowCount];
            _agent.UserGroupSID = new string[_rowCount];
            _agent.UserGroupDescription = new string[_rowCount];
            _agent.UserGroupStatus = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.UserGroupName[i] = dt.Rows[i]["GroupName"].ToString();
                _agent.UserGroupSID[i] = dt.Rows[i]["SIDs"].ToString();
                _agent.UserGroupDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agent.UserGroupStatus[i] = dt.Rows[i]["Statuss"].ToString();
            }

            dt = null;

            // Get Softwares Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSoftwares.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.SoftwareName = new string[_rowCount];
            _agent.SoftwareInstallDate = new string[_rowCount];
            

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.SoftwareName[i] = dt.Rows[i]["SoftwareName"].ToString();
                _agent.SoftwareInstallDate[i] = dt.Rows[i]["InstallDate"].ToString();
                
            }

            dt = null;

            // Get Updates Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSecurityUpdate.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.UpdateName = new string[_rowCount];
            
            for (int i = 0; i < _rowCount; i++)
            {
                _agent.UpdateName[i] = dt.Rows[i]["PatchName"].ToString();
               
            }

            dt = null;

            //Update Agent list Property
            //string AgentIDtoFind = _agent.AgentID;

            int index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agent.AgentID, StringComparison.Ordinal); });
            Program.AgentList[index] = _agent;


        }

        private void frmAgentGeneralInfo_Load(object sender, EventArgs e)
        {
            // define and start thread for update agent details
 
            _tAgentDetail = new Thread(new ThreadStart(GetAgentDetails));
            if(_agent.CPUProcessorId[0] == null)
                _tAgentDetail.Start();

            //**************************
            this.Text = Languages.AgentGenericInfoTitle(Properties.Settings.Default.CurrentLanguage);
            grbPublic.Text = Languages.AgentPublicInfo(Properties.Settings.Default.CurrentLanguage);
            grbOS.Text = Languages.OS(Properties.Settings.Default.CurrentLanguage);
            grbHardware.Text = Languages.Hardware(Properties.Settings.Default.CurrentLanguage);
            grbNetwork.Text = Languages.Network(Properties.Settings.Default.CurrentLanguage);
            grbUser.Text = Languages.User(Properties.Settings.Default.CurrentLanguage);

            //************ Public Info **************************

            lblComputerName.Text = Languages.ComputerNameLable(Properties.Settings.Default.CurrentLanguage);
            //lblAgentID.Text = Languages.AgentIDLable(Properties.Settings.Default.CurrentLanguage);
            lblAgentNumber.Text = Languages.AgentNumberLable(Properties.Settings.Default.CurrentLanguage);
            lblStatus.Text = Languages.AgentStatus(Properties.Settings.Default.CurrentLanguage);
            lblCurrentAccount.Text = Languages.CurrentAccountLable(Properties.Settings.Default.CurrentLanguage);
            lblStartupTime.Text = Languages.StartupTimeLable(Properties.Settings.Default.CurrentLanguage);
            lblStartupDate.Text = Languages.StartupDateLable(Properties.Settings.Default.CurrentLanguage);
            lbl_ComputerName.Text = _agent.ComputerName;
            //lbl_AgentID.Text = _agent.AgentID;
            lbl_AgentNumber.Text = _agent.AgentNumber;
            lbl_AgentStatus.Text = _agent.Status;
            lbl_LoginAccount.Text = _agent.CurrentAccount;
            lbl_StartupDate.Text = _agent.StartupDate;
            lbl_StartupTime.Text = _agent.StartupTime;
            
            //*************** User Info *****************************

            lblUserFullName.Text = Languages.UserFullNameLable(Properties.Settings.Default.CurrentLanguage);
            lblUserTitle.Text = Languages.UserTitleLable(Properties.Settings.Default.CurrentLanguage);
            lblUserPersonelCode.Text = Languages.UserPersonnelCodeLable(Properties.Settings.Default.CurrentLanguage);

            if (_agent.PersonnelLName == null)
            {
                lbl_UserFullName.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                lbl_UserPersonelCode.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                lbl_UserTitle.Text = Languages.NotDefine(Properties.Settings.Default.CurrentLanguage);
                pibUserImage.Image = Properties.Resources.unknown;
                pibUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else
            {
                lbl_UserFullName.Text = _agent.PersonnelFName + " " + _agent.PersonnelLName;
                lbl_UserPersonelCode.Text = _agent.PersonnelCode;
                lbl_UserTitle.Text = _agent.PersonnelTitle;
                pibUserImage.Image = _agent.PersonnelImage;
                pibUserImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            //**************** OS Info **********************

            lblOSCaption.Text = Languages.OSLable(Properties.Settings.Default.CurrentLanguage);
            lblOSSerialNumber.Text = Languages.OSSerialNumberLable(Properties.Settings.Default.CurrentLanguage);
            lblOSBuildNumber.Text = Languages.OSBuildNumberLable(Properties.Settings.Default.CurrentLanguage);

            lbl_OSCaption.Text = _agent.Caption + " SP" + _agent.ServicePack;
            lbl_OSSerialNumber.Text = _agent.OSProductKey;
            lbl_OSBuildNumber.Text = _agent.OSBuildNumber;

            //*************** Hardware Info ***************

            lblCPU.Text = Languages.CPULable(Properties.Settings.Default.CurrentLanguage);
            lblMotherboard.Text = Languages.MotherboardLable(Properties.Settings.Default.CurrentLanguage);
            lblMemory.Text = Languages.MemoryLable(Properties.Settings.Default.CurrentLanguage);
            lblHardDisk.Text = Languages.HardDiskLable(Properties.Settings.Default.CurrentLanguage);
            lblVideoCard.Text = Languages.VideoCardLable(Properties.Settings.Default.CurrentLanguage);

            for (int i = 0; i < _agent.CPUCaption.Length; i++)
            {
                cmbCpu.Items.Add(_agent.CPUCaption[i].ToString());
            }
            cmbCpu.SelectedIndex = 0;

            lbl_Motherboard.Text = _agent.MotherboardCaption + " Model " + _agent.MotherboardModel;

            double _memory = 0;
            for (int i = 0; i < _agent.Memory.Length; i++)
            {
                _memory = _memory + Convert.ToDouble(_agent.Memory[i]);
            }

            lbl_Memory.Text = Convert.ToString((_memory / 1000000)) + " MB "  ;

            for (int i = 0; i < _agent.HardDisk.Length; i++)
            {
                cmbHardDisk.Items.Add(_agent.HardDisk[i]);
            }

            cmbHardDisk.SelectedIndex = 0;

            for (int i = 0; i < _agent.VideoCard.Length; i++)
            {
                cmbVideoCard.Items.Add(_agent.VideoCard[i].ToString());
            }
            cmbVideoCard.SelectedIndex = 0;

           

            //*********** Network Info *****************

            lblIpAddress.Text = Languages.IPAddressLable(Properties.Settings.Default.CurrentLanguage);
            lblMacAddress.Text = Languages.MacAddressLable(Properties.Settings.Default.CurrentLanguage);
            lblDefaultGW.Text = Languages.DefaultGWLable(Properties.Settings.Default.CurrentLanguage);
            lblSubnetMask.Text = Languages.NetMaskText(Properties.Settings.Default.CurrentLanguage);

            lbl_IPAddress.Text = _agent.IPAddress;
            lbl_DefaultGW.Text = _agent.DefaultGW;
            lbl_SubnetMask.Text = _agent.SubnetMask;
            lbl_MACAddress.Text = _agent.MacAddress;

            //************ tooltips *****************

            tsbUser.ToolTipText = Languages.UserFullName(Properties.Settings.Default.CurrentLanguage);
            tsbAgentDetails.ToolTipText = Languages.Details(Properties.Settings.Default.CurrentLanguage);
            tsbAgentChat.ToolTipText = Languages.Chat(Properties.Settings.Default.CurrentLanguage);
            tsbHelp.ToolTipText = Languages.Help(Properties.Settings.Default.CurrentLanguage);
            tsbAgentSetting.ToolTipText = Languages.AgentSetting(Properties.Settings.Default.CurrentLanguage);
            tsbPrint.ToolTipText = Languages.Print(Properties.Settings.Default.CurrentLanguage);
            tsbSendCommand.ToolTipText = Languages.SendCommand(Properties.Settings.Default.CurrentLanguage);


            this.pibUserImage.Focus();

        }

        private void tsbUser_Click(object sender, EventArgs e)
        {            
            frmEmploye fe = new frmEmploye(_agent);
            fe.ShowDialog();
        }

        private void tsbAgentSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbAgentDetails_Click(object sender, EventArgs e)
        {
            frmAgentDetails fad = new frmAgentDetails(_agent);
            fad.ShowDialog();
        }
    }
}
