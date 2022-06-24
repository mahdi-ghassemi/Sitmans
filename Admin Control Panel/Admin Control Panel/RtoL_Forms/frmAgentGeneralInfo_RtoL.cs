using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using System.Threading;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentGeneralInfo_RtoL : Telerik.WinControls.UI.RadForm
    {
        private Agents _agent;
        private Thread _tAgentDetail;
        private LogicLayer lg;

        public frmAgentGeneralInfo_RtoL(Agents agent)
        {
            _agent = agent;
            lg = new LogicLayer();
            InitializeComponent();
        }

        private void GetAgentDetails()
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            LogicLayer lg1 = new LogicLayer();

            // Get CPU Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetProcessors.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            int _rowCount = dt.Rows.Count;

            _agent.VendorID = new string[_rowCount];
            _agent.SteppingID = new string[_rowCount];
            _agent.CpuModelNumber = new string[_rowCount];
            _agent.FamilyCode = new string[_rowCount];
            _agent.ProcessorType = new string[_rowCount];
            _agent.BrandID = new string[_rowCount];
            _agent.CpuSerialNumber = new string[_rowCount];
            _agent.SSE2 = new string[_rowCount];

            _agent.ExtendedModel = new string[_rowCount];
            _agent.ExtendedFamily = new string[_rowCount];
            _agent.Chunks = new string[_rowCount];
            _agent.Counts = new string[_rowCount];
            _agent.APICID = new string[_rowCount];
            _agent.MMX = new string[_rowCount];
            _agent.FxsaveFxrstorInstructions = new string[_rowCount];
            _agent.SSE = new string[_rowCount];
            _agent.CpuBrand = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agent.VendorID[i] = dt.Rows[i]["VendorId"].ToString();
                _agent.SteppingID[i] = dt.Rows[i]["SteppingId"].ToString();
                _agent.CpuModelNumber[i] = dt.Rows[i]["ModelNumber"].ToString();
                _agent.FamilyCode[i] = dt.Rows[i]["FamilyCode"].ToString();
                _agent.ProcessorType[i] = dt.Rows[i]["ProcessorType"].ToString();
                _agent.BrandID[i] = dt.Rows[i]["BrandId"].ToString();
                _agent.CpuSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.SSE2[i] = dt.Rows[i]["Sse2"].ToString();

                _agent.ExtendedModel[i] = dt.Rows[i]["ExtendedModel"].ToString();
                _agent.ExtendedFamily[i] = dt.Rows[i]["ExtendedFamily"].ToString();
                _agent.Chunks[i] = dt.Rows[i]["Chunks"].ToString();
                _agent.Counts[i] = dt.Rows[i]["Counts"].ToString();
                _agent.APICID[i] = dt.Rows[i]["APICID"].ToString();
                _agent.MMX[i] = dt.Rows[i]["MMX"].ToString();
                _agent.FxsaveFxrstorInstructions[i] = dt.Rows[i]["FxSaveFxStorinStructions"].ToString();
                _agent.SSE[i] = dt.Rows[i]["SSE"].ToString();
                _agent.CpuBrand[i] = dt.Rows[i]["Brand"].ToString();


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
            _agent.HardDiskSerialNumber = new string[_rowCount];
            _agent.HardDiskTableId = new string[_rowCount];
            _agent.HardDisk = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agent.HardDisk[i] = dt.Rows[i]["Caption"].ToString();
                _agent.HardDiskSignature[i] = dt.Rows[i]["Signatures"].ToString();
                _agent.HardDiskSize[i] = dt.Rows[i]["HardSize"].ToString();
                _agent.HardDiskPartitions[i] = dt.Rows[i]["Partitiones"].ToString();
                _agent.HardDiskPNPDeviceID[i] = dt.Rows[i]["PnpDevice"].ToString();
                _agent.HardDiskTableId[i] = dt.Rows[i]["Id"].ToString();
                _agent.HardDiskSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();

            }

            dt = null;

            // Get Memory Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMemory.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.BankLabel = new string[_rowCount];
            _agent.Speed = new string[_rowCount];
            _agent.MemoryModel = new string[_rowCount];
            _agent.MemorySerialNumber = new string[_rowCount];
            _agent.MemoryTableId = new string[_rowCount];
            _agent.Memory = new string[_rowCount]; 
            

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.BankLabel[i] = dt.Rows[i]["BankLable"].ToString();
                _agent.Speed[i] = dt.Rows[i]["Speed"].ToString();
                _agent.MemoryModel[i] = dt.Rows[i]["Model"].ToString();
                _agent.MemorySerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.MemoryTableId[i] = dt.Rows[i]["Id"].ToString();
                _agent.Memory[i] = dt.Rows[i]["Capacity"].ToString();
              
            }
            dt = null;

            //Get Active Network Setting info
          
            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetActiveNetworkSetting.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;

            _agent.ActiveNetworkAdapterCaption = new string[_rowCount];
            _agent.IPAddress = new string[_rowCount];
            _agent.MacAddress = new string[_rowCount];
            _agent.DefaultGW = new string[_rowCount];
            _agent.SubnetMask = new string[_rowCount];
            _agent.DNSServer = new string[_rowCount];
            _agent.DHCPEnabled = new string[_rowCount];
            _agent.DHCPServer = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agent.ActiveNetworkAdapterCaption[i] = dt.Rows[i]["Caption"].ToString();
                _agent.IPAddress[i] = dt.Rows[i]["IPAddress"].ToString();
                _agent.MacAddress[i] = dt.Rows[i]["MACAddress"].ToString();
                _agent.DefaultGW[i] = dt.Rows[i]["DefaultGateway"].ToString();
                _agent.SubnetMask[i] = dt.Rows[i]["SubnetMask"].ToString();
                _agent.DNSServer[i] = dt.Rows[i]["DNSHostName"].ToString();
                _agent.DHCPEnabled[i] = dt.Rows[i]["DHCPEnable"].ToString();
                _agent.DHCPServer[i] = dt.Rows[i]["DHCPServerIP"].ToString();
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
            _agent.NetSerialNumber = new string[_rowCount];
            _agent.NetTableId = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agent.NetDescription[i] = dt.Rows[i]["Description"].ToString();
                _agent.NetAdapterType[i] = dt.Rows[i]["AdapterType"].ToString();
                _agent.NetMACAddress[i] = dt.Rows[i]["MacAddress"].ToString();
                _agent.NetManufacturer[i] = dt.Rows[i]["Manufacturer"].ToString();
                _agent.NetConnectionID[i] = dt.Rows[i]["Netconnectionid"].ToString();
                _agent.NetPNPDeviceID[i] = dt.Rows[i]["PnpDeviceId"].ToString();
                _agent.NetTimeOfLastReset[i] = dt.Rows[i]["TimeOfLastReset"].ToString();
                _agent.NetSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.NetTableId[i] = dt.Rows[i]["Id"].ToString();
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
            _agent.VideoCardSerialNumber = new string[_rowCount];
            _agent.VideoCardTableId = new string[_rowCount];
            _agent.VideoCard = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.VideoCard[i] = dt.Rows[i]["Caption"].ToString();
                _agent.DriverDate[i] = dt.Rows[i]["DriverDate"].ToString();
                _agent.DriverVersion[i] = dt.Rows[i]["DriverVersion"].ToString();
                _agent.VideoProcessor[i] = dt.Rows[i]["VideoProcessor"].ToString();
                _agent.VideoModeDescription[i] = dt.Rows[i]["VideoMode"].ToString();
                _agent.AdapterRAM[i] = dt.Rows[i]["AdapterRam"].ToString();
                _agent.VideoCardSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.VideoCardTableId[i] = dt.Rows[i]["Id"].ToString();
            }
            dt = null;

            //Get OS Info details
            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetOS.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            _agent.OSSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            _agent.OSBuildNumber = dt.Rows[0]["BuildNumber"].ToString();
            _agent.FreePhysicalMemory = dt.Rows[0]["FreePhysicalMemory"].ToString();
            _agent.InstallDate = dt.Rows[0]["InstallDate"].ToString();
            _agent.Caption = dt.Rows[0]["Caption"].ToString();
            _agent.RegisteredUser = dt.Rows[0]["RegisterUser"].ToString();
            _agent.Version = dt.Rows[0]["Versions"].ToString();

            dt = null;

            //Get Mainboard Info Details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMotherboard.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _agent.MotherboardCaption = dt.Rows[0]["Manufactorer"].ToString();
            _agent.MotherboardModel = dt.Rows[0]["Product"].ToString();
            _agent.MotherboardSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            _agent.MotherboardVersion = dt.Rows[0]["Version"].ToString();

            dt = null;

            //Get Public Info Details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentStatus.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            string agentCurrentAccount = dt.Rows[0]["CurrentLogin"].ToString();
            string agentDuration = dt.Rows[0]["StartupDuration"].ToString();


            _agent.CurrentAccount = lg1.GetCurrentAccount(agentCurrentAccount);
            _agent.StartupDate = lg1.GetStartupDate(agentDuration);
            _agent.StartupTime = lg1.GetStratupTime(agentDuration);

            dt = null;

            //Get CDROM Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetCDROM.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.CDRomName = new string[_rowCount];
            _agent.CdromDrive = new string[_rowCount];
            _agent.CDRomSerialNumber = new string[_rowCount];
            _agent.CDRomTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.CDRomName[i] = dt.Rows[i]["CdRomName"].ToString();
                _agent.CdromDrive[i] = dt.Rows[i]["CdRomDrive"].ToString();
                _agent.CDRomSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.CDRomTableId[i] = dt.Rows[i]["Id"].ToString();
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
                _agent.LogicDiskDescription[i] = dt.Rows[i]["Description"].ToString();
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
            _agent.ModemSerialNumber = new string[_rowCount];
            _agent.ModemTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.Modem[i] = dt.Rows[i]["ModemName"].ToString();
                _agent.ModemTableId[i] = dt.Rows[i]["Id"].ToString();
                _agent.ModemSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
            }

            dt = null;

            // Get Printer Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPrinter.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.PrinterName = new string[_rowCount];
            _agent.PrinterNetwork = new string[_rowCount];
            _agent.PrinterSerialNumber = new string[_rowCount];
            _agent.PrinterTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.PrinterName[i] = dt.Rows[i]["PrinterName"].ToString();
                _agent.PrinterNetwork[i] = dt.Rows[i]["Network"].ToString();
                _agent.PrinterSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agent.PrinterTableId[i] = dt.Rows[i]["Id"].ToString();

            }

            dt = null;

            // Get Other Devices Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPublicDevices.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            _agent.Monitor = dt.Rows[0]["Monitor"].ToString();
            _agent.MonitorSerialNumber = dt.Rows[0]["MonitorSerialNumber"].ToString();

            _agent.Keyboard = dt.Rows[0]["Keyboard"].ToString();
            _agent.KeyboardSerialNumber = dt.Rows[0]["KeyboardSerialNumber"].ToString();

            _agent.Mouse = dt.Rows[0]["Mouse"].ToString();
            _agent.MouseSerialNumber = dt.Rows[0]["MouseSerialNumber"].ToString();

            _agent.Scanner = dt.Rows[0]["Scanner"].ToString();
            _agent.ScannerSerialNumber = dt.Rows[0]["ScannerSerialNumber"].ToString();

            _agent.Camera = dt.Rows[0]["Camera"].ToString();
            _agent.CameraSerialNumber = dt.Rows[0]["CameraSerialNumber"].ToString();

            _agent.AllDevicesTableId = dt.Rows[0]["Id"].ToString();



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
                _agent.UserAccountName[i] = dt.Rows[i]["Username"].ToString();
                _agent.UserAccountSID[i] = dt.Rows[i]["Sids"].ToString();
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
                _agent.UserGroupSID[i] = dt.Rows[i]["Sids"].ToString();
                _agent.UserGroupDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agent.UserGroupStatus[i] = dt.Rows[i]["Statuss"].ToString();
            }

            dt = null;

            // Get Application Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetApplication.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.SoftwareName = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agent.SoftwareName[i] = dt.Rows[i]["SoftwareName"].ToString();

            }

            dt = null;

            // Get Updates Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSecurityUpdate.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            _rowCount = dt.Rows.Count;
            _agent.UpdateName = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agent.UpdateName[i] = dt.Rows[i]["SoftwareName"].ToString();

            }

            dt = null;

            // Get Bios Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetBios.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);



            _agent.BiosReleaseDate = dt.Rows[0]["ReleasDate"].ToString();
            _agent.BiosRomSize = dt.Rows[0]["BiosRomSize"].ToString();
            _agent.BiosStartSegment = dt.Rows[0]["StartSegment"].ToString();
            _agent.BiosVendor = dt.Rows[0]["Vendor"].ToString();
            _agent.BiosVersion = dt.Rows[0]["Version"].ToString();



            dt = null;


            // Get Location Info

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentLocation.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            if (dt.Rows.Count != 0)
            {
                _agent.BuildingTitle = dt.Rows[0]["BuildingTitle"].ToString();
                _agent.BuildingId = Convert.ToInt32(dt.Rows[0]["BuildingId"].ToString());

                _agent.ClassTitle = dt.Rows[0]["ClassTitle"].ToString();
                _agent.ClassId = Convert.ToInt32(dt.Rows[0]["ClassId"].ToString());

                _agent.RoomTitle = dt.Rows[0]["RoomTitle"].ToString();
                _agent.RoomId = Convert.ToInt32(dt.Rows[0]["RoomId"].ToString());

                _agent.DepartmentTitle = dt.Rows[0]["DepartmentTitle"].ToString();
                _agent.DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"].ToString());

            }

            dt = null;

            // Get Persoonaly Info

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPersonnelInfo.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);

            if (dt.Rows.Count != 0)
            {
                _agent.PersonnelTitle = dt.Rows[0]["UserTitle"].ToString();
                _agent.PersonnelGender =dt.Rows[0]["Gender"].ToString();

                _agent.PersonnelCode = dt.Rows[0]["PersonnelCode"].ToString();
                _agent.PersonnelCellNum = dt.Rows[0]["UserMob"].ToString();

                _agent.PersonnelAddress = dt.Rows[0]["UserAddress"].ToString();
                _agent.PersonnelInterNum = dt.Rows[0]["UserInterNum"].ToString();

                _agent.PersonnelMail = dt.Rows[0]["UserEmail"].ToString();
                _agent.PersonnelTellNum = dt.Rows[0]["UserTell"].ToString();

            }

            dt = null;

            // Get Asset Info

            LogicLayer lg = new LogicLayer();

            dt = lg.GetAgentAssetNumbers(_agent.AgentID);

            
            if (dt.Rows.Count != 0)
            {
                _agent.AssetTableId = new string[dt.Rows.Count];
                _agent.DeviceId = new int[dt.Rows.Count];
                _agent.DeviceAssetNumber = new string[dt.Rows.Count];
                _agent.DeviceModel = new string[dt.Rows.Count];
                _agent.DeviceSerialNumber = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _agent.AssetTableId[i] = dt.Rows[i]["Id"].ToString();
                    _agent.DeviceId[i] = Convert.ToInt32(dt.Rows[i]["DeviceId"].ToString());
                    _agent.DeviceAssetNumber[i] = dt.Rows[i]["Assetnumber"].ToString();
                    _agent.DeviceModel[i] = dt.Rows[i]["DeviceModel"].ToString();
                    _agent.DeviceSerialNumber[i] = dt.Rows[i]["DeviceSerialNumber"].ToString();

                }               
            }
            if (dt.Rows.Count == 0)
            {


            }

            //Update Agent list Property
            //string AgentIDtoFind = _agent.AgentID;

            int index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agent.AgentID, StringComparison.Ordinal); });
            Program.AgentList[index] = _agent;


        }

        private void frmAgentGeneralInfo_RtoL_Load(object sender, EventArgs e)
        {

            // define and start thread for update agent details

            _tAgentDetail = new Thread(new ThreadStart(GetAgentDetails));
            _tAgentDetail.Start();

            LogicLayer lo = new LogicLayer();
            string _langCode = Convert.ToString(Program.LangCode);

            //**************************
            this.Text = lo.GetMessageFromDll(_langCode, "AgentGenericInfoTitle");
            grbPublic.Text = lo.GetMessageFromDll(_langCode, "AgentPublicInfo");
            grbOS.Text = lo.GetMessageFromDll(_langCode, "OS");

            grbHardware.Text = lo.GetMessageFromDll(_langCode, "Hardware");
            grbNetwork.Text = lo.GetMessageFromDll(_langCode, "Network");
            grbUser.Text = lo.GetMessageFromDll(_langCode, "User");
            grbLocation.Text = lo.GetMessageFromDll(_langCode, "LocalAddressDefine");
            grbAssetNumber.Text = lo.GetMessageFromDll(_langCode, "AssetNumber");

            //************ Public Info **************************

            lblComputerName.Text = lo.GetMessageFromDll(_langCode, "ComputerName");
            //lblAgentID.Text = Languages.AgentIDLable(Properties.Settings.Default.CurrentLanguage);
            lblAgentNumber.Text = lo.GetMessageFromDll(_langCode, "AgentID");
            lblStatus.Text = lo.GetMessageFromDll(_langCode, "AgentStatus");
            lblCurrentAccount.Text = lo.GetMessageFromDll(_langCode, "CurrentAccount");
            lblStartupTime.Text = lo.GetMessageFromDll(_langCode, "StartupTime");
            lblStartupDate.Text = lo.GetMessageFromDll(_langCode, "StartupDate");
            lbl_ComputerName.Text = _agent.ComputerName;
            //lbl_AgentID.Text = _agent.AgentID;
            lbl_AgentNumber.Text = _agent.AgentID;
            lbl_AgentStatus.Text = _agent.Status;
            lbl_LoginAccount.Text = _agent.CurrentAccount;
            lbl_StartupDate.Text = _agent.StartupDate;
            lbl_StartupTime.Text = _agent.StartupTime;

            //*************** User Info *****************************

            lblUserFullName.Text = lo.GetMessageFromDll(_langCode, "UserFullName");
            lblUserTitle.Text = lo.GetMessageFromDll(_langCode, "UserTitle");
            lblUserPersonelCode.Text = lo.GetMessageFromDll(_langCode, "UserPersonnelCode");

            if (_agent.PersonnelLName == null || _agent.PersonnelLName == "")
            {
                lbl_UserFullName.Text = lo.GetMessageFromDll(_langCode, "NotDefine");
                lbl_UserPersonelCode.Text = lbl_UserFullName.Text;
                lbl_UserTitle.Text = lbl_UserFullName.Text;

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

            lblOSCaption.Text = lo.GetMessageFromDll(_langCode, "OS");
            lblOSSerialNumber.Text = lo.GetMessageFromDll(_langCode, "lblSerialNumber");
            lblOSBuildNumber.Text = lo.GetMessageFromDll(_langCode, "BuildNumber");

            lbl_OSCaption.Text = _agent.Caption;
            lbl_OSSerialNumber.Text = _agent.OSSerialNumber;
            lbl_OSBuildNumber.Text = _agent.OSBuildNumber;

            //*************** Hardware Info ***************

            lblCPU.Text = lo.GetMessageFromDll(_langCode, "CPU");
            lblMotherboard.Text = lo.GetMessageFromDll(_langCode, "Motherboard");
            lblMemory.Text = lo.GetMessageFromDll(_langCode, "Memory");
            lblHardDisk.Text = lo.GetMessageFromDll(_langCode, "HardDisk");
            lblVideoCard.Text = lo.GetMessageFromDll(_langCode, "VideoCard");

            for (int i = 0; i < _agent.CpuBrand.Length; i++)
            {
                cmbCpu.Items.Add(_agent.CpuBrand[i].ToString());
            }
            cmbCpu.SelectedIndex = 0;

            lbl_Motherboard.Text = _agent.MotherboardCaption + " Model " + _agent.MotherboardModel;

            
            double _memory = 0;
            for (int i = 0; i < _agent.Memory.Length; i++)
            {
                _memory = _memory + Convert.ToDouble(_agent.Memory[i]);
            }

            lbl_Memory.Text = Convert.ToString((_memory / 1000000)) + " MB ";

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

            lblIpAddress.Text = lo.GetMessageFromDll(_langCode, "IPAddress");
            lblMacAddress.Text = lo.GetMessageFromDll(_langCode, "MacAddress");
            lblDefaultGW.Text = lo.GetMessageFromDll(_langCode, "GatewayAddress");
            lblSubnetMask.Text = lo.GetMessageFromDll(_langCode, "NetMask");

            lbl_IPAddress.Text = lo.GetFirstActiveIPV4(_agent.IPAddress[0].Trim());
            lbl_DefaultGW.Text = lo.RemoveBracket(_agent.DefaultGW[0].Trim());
            lbl_SubnetMask.Text = lo.RemoveBracket(_agent.SubnetMask[0].Trim());
            lbl_MACAddress.Text = lo.RemoveBracket(_agent.MacAddress[0].Trim());

            //*********** Location *****************

            lblBuilding.Text = lo.GetMessageFromDll(_langCode, "Building");
            lblClass.Text = lo.GetMessageFromDll(_langCode, "Class");
            lblDepartment.Text = lo.GetMessageFromDll(_langCode, "Department");
            lblRoom.Text = lo.GetMessageFromDll(_langCode, "Room");

            if (_agent.BuildingTitle != null)
                lbl_building.Text = _agent.BuildingTitle;
            else
                lbl_building.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if (_agent.RoomTitle != null)
                lbl_Room.Text = _agent.RoomTitle;
            else
                lbl_Room.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if(_agent.ClassTitle != null)
                lbl_Class.Text = _agent.ClassTitle;
            else
                lbl_Class.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if (_agent.DepartmentTitle != null)
                lbl_Department.Text = _agent.DepartmentTitle;
            else
                lbl_Department.Text = lo.GetMessageFromDll(_langCode, "NotDefine");




            //********* Asset Number *********
                      
            lblSystemAsset.Text = lo.GetMessageFromDll(_langCode, "System");
            btnAssetNumberDetials.Text = lo.GetMessageFromDll(_langCode, "Details");

            if (_agent.DeviceId != null)
            {
                int _systemAssetNumberIndex = Array.IndexOf(_agent.DeviceId,1);
                if (_systemAssetNumberIndex != -1)
                {
                    lbl_SystemAsset.Text = _agent.DeviceAssetNumber[_systemAssetNumberIndex].ToString().Trim();
                    btnAssetNumberDetials.Enabled = true;
                }
            }
            else
            {
                lbl_SystemAsset.Text = lo.GetMessageFromDll(_langCode, "NotDefine");
                btnAssetNumberDetials.Enabled = false;
            }


            //************ tooltips *****************

            tsbUser.Text = lo.GetMessageFromDll(_langCode, "User");
            tsbAgentDetails.Text =lo.GetMessageFromDll(_langCode,"Details"); 
            tsbAgentChat.Text = lo.GetMessageFromDll(_langCode, "Chat");
            // tsbHelp.ToolTipText =lo.GetMessageFromDll(_langCode,"Help"); 
            tsbAgentSetting.Text = lo.GetMessageFromDll(_langCode, "Setting");
            //tsbPrint.ToolTipText = lo.GetMessageFromDll(_langCode,"Print");
            tsbSendCommand.Text = lo.GetMessageFromDll(_langCode, "Command");
            tsbAsset.Text = lo.GetMessageFromDll(_langCode, "AssetNumber");
            tsbLocation.Text = lo.GetMessageFromDll(_langCode, "LocalAddress");



            this.pibUserImage.Focus();

        }

        private void tsbAgentSetting_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbAgentDetails_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl2)
            {
                frmAgentDetails_RtoL agd = new frmAgentDetails_RtoL(_agent);
                agd.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void tsbUser_Click(object sender, EventArgs e)
        {
            frmEmploye_RtoL em = new frmEmploye_RtoL(_agent);
            em.ShowDialog();
            UserDataUpdate();
        }

        private void UserDataUpdate()
        {
            LogicLayer lo = new LogicLayer();
            string _langCode = Convert.ToString(Program.LangCode);
            if (_agent.PersonnelLName == null)
            {
                lbl_UserFullName.Text = lo.GetMessageFromDll(_langCode, "NotDefine");
                lbl_UserPersonelCode.Text = lbl_UserFullName.Text;
                lbl_UserTitle.Text = lbl_UserFullName.Text;

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
        }

        private void tsbLocation_Click(object sender, EventArgs e)
        {
            frmAgentLocation_RtoL al = new frmAgentLocation_RtoL(_agent);
            al.ShowDialog();
            LocationDataUpdate();
        }

        private void LocationDataUpdate()
        {
            LogicLayer lo = new LogicLayer();
            string _langCode = Convert.ToString(Program.LangCode);
            if (_agent.BuildingTitle != null)
                lbl_building.Text = _agent.BuildingTitle;
            else
                lbl_building.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if (_agent.RoomTitle != null)
                lbl_Room.Text = _agent.RoomTitle;
            else
                lbl_Room.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if (_agent.ClassTitle != null)
                lbl_Class.Text = _agent.ClassTitle;
            else
                lbl_Class.Text = lo.GetMessageFromDll(_langCode, "NotDefine");

            if (_agent.DepartmentTitle != null)
                lbl_Department.Text = _agent.DepartmentTitle;
            else
                lbl_Department.Text = lo.GetMessageFromDll(_langCode, "NotDefine");
            
        }

        private void tsbAsset_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl21)
            {
                GetAgentDetails();
                frmAgentAssets_RtoL faa = new frmAgentAssets_RtoL(_agent);
                faa.ShowDialog();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void tsbAgentChat_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl13)
            {

            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void frmAgentGeneralInfo_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
    }
}

