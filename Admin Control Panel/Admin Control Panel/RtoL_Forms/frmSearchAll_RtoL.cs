using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using System.Threading;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmSearchAll_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _fromDate;
        private string _toDate;
        private string _agentId;
        private string _agentName;
        private string _fd;
        private string _td;
        private int _selectedSystemIndex;
        private string _reportName;

        private string _query;
        private int _currentRow;
        private string _selectedItemText;
        private int _selectedItemIndex;
        private string _condition;
        private string _dateCondition;
        private string _fromTable;
        private const string _and = " AND ";
        private const string _or = " OR ";

        private List<string> TableList;
        private List<string> FieldList;
        private List<Query> myQuery;


        private GridViewTextBoxColumn ItemIdColumn;
        private GridViewTextBoxColumn ItemColumn;
        private GridViewComboBoxColumn OpretorColumn;
        private GridViewComboBoxColumn LogicOpretorColumn;
        private GridViewTextBoxColumn ValueColumn;
        private GridViewCheckBoxColumn CheckColumn;
        private GridViewCommandColumn DeleteColumn;

       
        private DataTable Hard_Main_Details;
        private DataTable Soft_Main_Details;
        private DataTable Personnel_Main_Details;
        private DataTable Net_Main_Details;
        private DataTable Account_Main_Details;
        private DataTable Group_Main_Details;

        public frmSearchAll_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            Hard_Main_Details = new DataTable();
           
            InitializeComponent();
            //RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
        }

        private void frmSearchAll_RtoL_Load(object sender, EventArgs e)
        {
            this.grvRep.GridViewElement.GroupPanelElement.Visibility = ElementVisibility.Hidden;



            FillForm();
            FillDate();
            FillSystemName();
            //FillItem1();
            FillOprator();
            FillNextOprator();



            ddlHardware.DataSource = Program.tbl_item2_hardware;
            ddlHardware.DisplayMember = "SubjectName";
            ddlHardware.ValueMember = "SubjectId";
            ddlHardware.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;


            ddlSoftware.DataSource = Program.tbl_item2_software;
            ddlSoftware.DisplayMember = "SubjectName";
            ddlSoftware.ValueMember = "SubjectId";
            ddlSoftware.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;

            ddlNetwork.DataSource = Program.tbl_item2_network;
            ddlNetwork.DisplayMember = "SubjectName";
            ddlNetwork.ValueMember = "SubjectId";
            ddlNetwork.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;

            ddlAccount.DataSource = Program.tbl_item2_account;
            ddlAccount.DisplayMember = "SubjectName";
            ddlAccount.ValueMember = "SubjectId";
            ddlAccount.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;


            ddlGroup.DataSource = Program.tbl_item2_group;
            ddlGroup.DisplayMember = "SubjectName";
            ddlGroup.ValueMember = "SubjectId";
            ddlGroup.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;


            ddlPersonel.DataSource = Program.tbl_item2_personel;
            ddlPersonel.DisplayMember = "SubjectName";
            ddlPersonel.ValueMember = "SubjectId";
            ddlPersonel.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;

            ddlEvent.DataSource = Program.tbl_item2_event;
            ddlEvent.DisplayMember = "SubjectName";
            ddlEvent.ValueMember = "SubjectId";
            ddlEvent.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;




        }

        private void FillTablesDetails(string Code)
        {
            switch(Code)
            {
                case "101":
                    FillCpuItem();
                    break;
                case "102":
                    FillMainboardItem();
                    break;
                case "103":
                    FillMemoryItem();
                    break;
                case "104":
                    FillHardDiskItem();
                    break;
                case "105":
                    FillVideoCardItem();
                    break;
                case "106":
                    FillBiosItem();
                    break;
                case "107":
                    FillLogicDiskItem();
                    break;
                case "108":
                    FillCdRomItem();
                    break;
                case "109":
                    FillChassisItem();
                    break;
                case "110":
                    FillMonitorItem();
                    break;
                case "111":
                    FillKeyboardItem();
                    break;
                case "112":
                    FillMouseItem();
                    break;
                case "113":
                    FillPrinterItem();
                    break;
                case "114":
                    FillCameraItem();
                    break;
                case "115":
                    FillScannerItem();
                    break;
                case "116":
                    FillModemItem();
                    break;
                case "117":
                    FillNetAdapterItem();
                    break;
                case "204":
                    FillGenderItem();
                    break;
                case "301":
                    FillOSItem();
                    break;
                case "302":
                    FillApplicationItem();
                    break;
                case "303":
                    FillSecurityUpdateItem();
                    break;
                case "403":
                    FillAccountStatusItem();
                    break;
                case "503":
                    FillGroupStatusItem();
                    break;
                case "707":
                    FillDHCPStatusItem();
                    break;
               

            }

            /*
             * 
             * 
             *   
            Program.tbl_item2_event.Rows.Add(801, ll.GetMessageFromDll(_langCode, "CPUChanges"));
            Program.tbl_item2_event.Rows.Add(802, ll.GetMessageFromDll(_langCode, "MainboardChanges"));
            Program.tbl_item2_event.Rows.Add(803, ll.GetMessageFromDll(_langCode, "BiosChanges"));
            Program.tbl_item2_event.Rows.Add(804, ll.GetMessageFromDll(_langCode, "MemoryChanges"));
            Program.tbl_item2_event.Rows.Add(805, ll.GetMessageFromDll(_langCode, "HardDiskChanges"));
            Program.tbl_item2_event.Rows.Add(806, ll.GetMessageFromDll(_langCode, "LogicDiskChanges"));
            Program.tbl_item2_event.Rows.Add(807, ll.GetMessageFromDll(_langCode, "VideoCardChanges"));
            Program.tbl_item2_event.Rows.Add(808, ll.GetMessageFromDll(_langCode, "NetAdapterChanges"));
            Program.tbl_item2_event.Rows.Add(809, ll.GetMessageFromDll(_langCode, "KeyboardChanges"));
            Program.tbl_item2_event.Rows.Add(810, ll.GetMessageFromDll(_langCode, "MouseChanges"));

            Program.tbl_item2_event.Rows.Add(811, ll.GetMessageFromDll(_langCode, "MonitorChanges"));
            Program.tbl_item2_event.Rows.Add(812, ll.GetMessageFromDll(_langCode, "PrinterChanges"));
            Program.tbl_item2_event.Rows.Add(813, ll.GetMessageFromDll(_langCode, "ScannerChanges"));
            Program.tbl_item2_event.Rows.Add(814, ll.GetMessageFromDll(_langCode, "CammeraChanges"));
            Program.tbl_item2_event.Rows.Add(815, ll.GetMessageFromDll(_langCode, "CdromChanges"));
            Program.tbl_item2_event.Rows.Add(816, ll.GetMessageFromDll(_langCode, "ModemChanges"));
            Program.tbl_item2_event.Rows.Add(817, ll.GetMessageFromDll(_langCode, "ApplicationChanges"));
            Program.tbl_item2_event.Rows.Add(818, ll.GetMessageFromDll(_langCode, "OsChanges"));
            Program.tbl_item2_event.Rows.Add(819, ll.GetMessageFromDll(_langCode, "UpdatesChanges"));
            Program.tbl_item2_event.Rows.Add(820, ll.GetMessageFromDll(_langCode, "IpChanges"));

            Program.tbl_item2_event.Rows.Add(821, ll.GetMessageFromDll(_langCode, "SubnetChanges"));
            Program.tbl_item2_event.Rows.Add(822, ll.GetMessageFromDll(_langCode, "GwChanges"));
            Program.tbl_item2_event.Rows.Add(823, ll.GetMessageFromDll(_langCode, "MacChanges"));
            Program.tbl_item2_event.Rows.Add(824, ll.GetMessageFromDll(_langCode, "DnsChanges"));
            Program.tbl_item2_event.Rows.Add(825, ll.GetMessageFromDll(_langCode, "DhcpChanges"));
            Program.tbl_item2_event.Rows.Add(826, ll.GetMessageFromDll(_langCode, "PowerChanges"));
            Program.tbl_item2_event.Rows.Add(827, ll.GetMessageFromDll(_langCode, "FlashChanges"));
            Program.tbl_item2_event.Rows.Add(828, ll.GetMessageFromDll(_langCode, "UserAccountChange"));
            Program.tbl_item2_event.Rows.Add(829, ll.GetMessageFromDll(_langCode, "GroupAccountChange"));
            Program.tbl_item2_event.Rows.Add(830, ll.GetMessageFromDll(_langCode, "PublicChanges"));
             */


        }

        private void FillCpuItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_CPU = new DataTable();

            Hardware_CPU.Columns.Add("SubjectId", typeof(int));
            Hardware_CPU.Columns.Add("SubjectName", typeof(string));

            Hardware_CPU.Rows.Add(1011, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_CPU.Rows.Add(1012, ll.GetMessageFromDll(_langCode, "Speed"));
            Hardware_CPU.Rows.Add(1013, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_CPU;
        }

        private void FillMainboardItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_MB = new DataTable();

            Hardware_MB.Columns.Add("SubjectId", typeof(int));
            Hardware_MB.Columns.Add("SubjectName", typeof(string));

            Hardware_MB.Rows.Add(1021, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_MB.Rows.Add(1022, ll.GetMessageFromDll(_langCode, "Model"));
            Hardware_MB.Rows.Add(1023, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hardware_MB.Rows.Add(1024, ll.GetMessageFromDll(_langCode, "Version"));
            Hard_Main_Details = Hardware_MB;
        }

        private void FillMemoryItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Memory = new DataTable();

            Hardware_Memory.Columns.Add("SubjectId", typeof(int));
            Hardware_Memory.Columns.Add("SubjectName", typeof(string));

            Hardware_Memory.Rows.Add(1031, ll.GetMessageFromDll(_langCode, "Model"));
            Hardware_Memory.Rows.Add(1032, ll.GetMessageFromDll(_langCode, "Speed"));
            Hardware_Memory.Rows.Add(1033, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hardware_Memory.Rows.Add(1034, ll.GetMessageFromDll(_langCode, "Capacity"));
            Hard_Main_Details = Hardware_Memory;
        }

        private void FillHardDiskItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_HardDisk = new DataTable();

            Hardware_HardDisk.Columns.Add("SubjectId", typeof(int));
            Hardware_HardDisk.Columns.Add("SubjectName", typeof(string));

            Hardware_HardDisk.Rows.Add(1041, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_HardDisk.Rows.Add(1042, ll.GetMessageFromDll(_langCode, "Model"));
            Hardware_HardDisk.Rows.Add(1043, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hardware_HardDisk.Rows.Add(1044, ll.GetMessageFromDll(_langCode, "Capacity"));
            Hardware_HardDisk.Rows.Add(1045, ll.GetMessageFromDll(_langCode, "Parition"));
            Hard_Main_Details = Hardware_HardDisk;
        }

        private void FillVideoCardItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_VideoCard = new DataTable();

            Hardware_VideoCard.Columns.Add("SubjectId", typeof(int));
            Hardware_VideoCard.Columns.Add("SubjectName", typeof(string));

            Hardware_VideoCard.Rows.Add(1051, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_VideoCard.Rows.Add(1052, ll.GetMessageFromDll(_langCode, "DriverDate"));
            Hardware_VideoCard.Rows.Add(1053, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hardware_VideoCard.Rows.Add(1054, ll.GetMessageFromDll(_langCode, "DriverVersion"));
            Hardware_VideoCard.Rows.Add(1055, ll.GetMessageFromDll(_langCode, "VideoProcessor"));
            Hardware_VideoCard.Rows.Add(1056, ll.GetMessageFromDll(_langCode, "VideoMode"));
            Hardware_VideoCard.Rows.Add(1057, ll.GetMessageFromDll(_langCode, "AdapterRam"));
            Hard_Main_Details = Hardware_VideoCard;
        }

        private void FillBiosItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Bios = new DataTable();

            Hardware_Bios.Columns.Add("SubjectId", typeof(int));
            Hardware_Bios.Columns.Add("SubjectName", typeof(string));

            Hardware_Bios.Rows.Add(1061, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Bios.Rows.Add(1062, ll.GetMessageFromDll(_langCode, "DriverDate"));
            Hardware_Bios.Rows.Add(1063, ll.GetMessageFromDll(_langCode, "DriverVersion"));
            Hardware_Bios.Rows.Add(1064, ll.GetMessageFromDll(_langCode, "AdapterRam"));
            Hard_Main_Details = Hardware_Bios;
        }

        private void FillLogicDiskItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_LogicDisk = new DataTable();

            Hardware_LogicDisk.Columns.Add("SubjectId", typeof(int));
            Hardware_LogicDisk.Columns.Add("SubjectName", typeof(string));

            Hardware_LogicDisk.Rows.Add(1071, ll.GetMessageFromDll(_langCode, "Firstname"));
            Hardware_LogicDisk.Rows.Add(1072, ll.GetMessageFromDll(_langCode, "FileSystemType"));
            Hardware_LogicDisk.Rows.Add(1073, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_LogicDisk;
           
        }

        private void FillCdRomItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_CdRom = new DataTable();

            Hardware_CdRom.Columns.Add("SubjectId", typeof(int));
            Hardware_CdRom.Columns.Add("SubjectName", typeof(string));

            Hardware_CdRom.Rows.Add(1081, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_CdRom.Rows.Add(1082, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_CdRom;
          
        }

        private void FillChassisItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Chassis = new DataTable();

            Hardware_Chassis.Columns.Add("SubjectId", typeof(int));
            Hardware_Chassis.Columns.Add("SubjectName", typeof(string));

            Hardware_Chassis.Rows.Add(1091, ll.GetMessageFromDll(_langCode, "SystemType"));
            Hard_Main_Details = Hardware_Chassis;
        
        }

        private void FillMonitorItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Monitor = new DataTable();

            Hardware_Monitor.Columns.Add("SubjectId", typeof(int));
            Hardware_Monitor.Columns.Add("SubjectName", typeof(string));

            Hardware_Monitor.Rows.Add(1101, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Monitor.Rows.Add(1102, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Monitor.Rows.Add(1103, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Monitor;
        }

        private void FillKeyboardItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Keyboard = new DataTable();

            Hardware_Keyboard.Columns.Add("SubjectId", typeof(int));
            Hardware_Keyboard.Columns.Add("SubjectName", typeof(string));

            Hardware_Keyboard.Rows.Add(1111, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Keyboard.Rows.Add(1112, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Keyboard.Rows.Add(1113, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Keyboard;
        }

        private void FillMouseItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Mouse = new DataTable();

            Hardware_Mouse.Columns.Add("SubjectId", typeof(int));
            Hardware_Mouse.Columns.Add("SubjectName", typeof(string));

            Hardware_Mouse.Rows.Add(1121, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Mouse.Rows.Add(1122, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Mouse.Rows.Add(1123, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Mouse;
        }

        private void FillPrinterItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Printer = new DataTable();

            Hardware_Printer.Columns.Add("SubjectId", typeof(int));
            Hardware_Printer.Columns.Add("SubjectName", typeof(string));

            Hardware_Printer.Rows.Add(1131, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Printer.Rows.Add(1132, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Printer.Rows.Add(1133, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Printer;
        }

        private void FillCameraItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Camera = new DataTable();

            Hardware_Camera.Columns.Add("SubjectId", typeof(int));
            Hardware_Camera.Columns.Add("SubjectName", typeof(string));

            Hardware_Camera.Rows.Add(1141, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Camera.Rows.Add(1142, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Camera.Rows.Add(1143, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Camera;
        }

        private void FillScannerItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Scanner = new DataTable();

            Hardware_Scanner.Columns.Add("SubjectId", typeof(int));
            Hardware_Scanner.Columns.Add("SubjectName", typeof(string));

            Hardware_Scanner.Rows.Add(1151, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Scanner.Rows.Add(1152, ll.GetMessageFromDll(_langCode, "AssetNumber"));
            Hardware_Scanner.Rows.Add(1153, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Scanner;
        }

        private void FillModemItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_Modem = new DataTable();

            Hardware_Modem.Columns.Add("SubjectId", typeof(int));
            Hardware_Modem.Columns.Add("SubjectName", typeof(string));

            Hardware_Modem.Rows.Add(1161, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_Modem.Rows.Add(1162, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Hard_Main_Details = Hardware_Modem;
        }

        private void FillNetAdapterItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Hardware_NetAdapter = new DataTable();

            Hardware_NetAdapter.Columns.Add("SubjectId", typeof(int));
            Hardware_NetAdapter.Columns.Add("SubjectName", typeof(string));

            Hardware_NetAdapter.Rows.Add(1171, ll.GetMessageFromDll(_langCode, "Brand"));
            Hardware_NetAdapter.Rows.Add(1172, ll.GetMessageFromDll(_langCode, "NetType"));
            Hardware_NetAdapter.Rows.Add(1173, ll.GetMessageFromDll(_langCode, "MacAddress"));
            Hard_Main_Details = Hardware_NetAdapter;
        }

        private void FillGenderItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Perssonel_Gender = new DataTable();

            Perssonel_Gender.Columns.Add("SubjectId", typeof(int));
            Perssonel_Gender.Columns.Add("SubjectName", typeof(string));

            Perssonel_Gender.Rows.Add(2041, ll.GetMessageFromDll(_langCode, "Male"));
            Perssonel_Gender.Rows.Add(2042, ll.GetMessageFromDll(_langCode, "Female"));
            Personnel_Main_Details = Perssonel_Gender;
        }

        private void FillAccountStatusItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Account_Status = new DataTable();

            Account_Status.Columns.Add("SubjectId", typeof(int));
            Account_Status.Columns.Add("SubjectName", typeof(string));

            Account_Status.Rows.Add(4031, ll.GetMessageFromDll(_langCode, "Active"));
            Account_Status.Rows.Add(4032, ll.GetMessageFromDll(_langCode, "Inactive"));
            Account_Main_Details = Account_Status;
        }

        private void FillGroupStatusItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Group_Status = new DataTable();

            Group_Status.Columns.Add("SubjectId", typeof(int));
            Group_Status.Columns.Add("SubjectName", typeof(string));

            Group_Status.Rows.Add(5031, ll.GetMessageFromDll(_langCode, "Active"));
            Group_Status.Rows.Add(5032, ll.GetMessageFromDll(_langCode, "Inactive"));
            Group_Main_Details = Group_Status;
        }

        private void FillDHCPStatusItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable DHCP_Status = new DataTable();

            DHCP_Status.Columns.Add("SubjectId", typeof(int));
            DHCP_Status.Columns.Add("SubjectName", typeof(string));

            DHCP_Status.Rows.Add(7071, ll.GetMessageFromDll(_langCode, "Active"));
            DHCP_Status.Rows.Add(7072, ll.GetMessageFromDll(_langCode, "Inactive"));
            Net_Main_Details = DHCP_Status;
        }

        private void FillOSItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Software_OS = new DataTable();

            Software_OS.Columns.Add("SubjectId", typeof(int));
            Software_OS.Columns.Add("SubjectName", typeof(string));

            Software_OS.Rows.Add(3011, ll.GetMessageFromDll(_langCode, "BuildNumber"));
            Software_OS.Rows.Add(3012, ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
            Software_OS.Rows.Add(3013, ll.GetMessageFromDll(_langCode, "OSName"));
            Software_OS.Rows.Add(3014, ll.GetMessageFromDll(_langCode, "InstallDate"));
            Soft_Main_Details = Software_OS;
        }

        private void FillApplicationItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Software_Application = new DataTable();

            Software_Application.Columns.Add("SubjectId", typeof(int));
            Software_Application.Columns.Add("SubjectName", typeof(string));

            Software_Application.Rows.Add(3021, ll.GetMessageFromDll(_langCode, "ApplicationName"));
            Soft_Main_Details = Software_Application;
        }

        private void FillSecurityUpdateItem()
        {
            LogicLayer ll = new LogicLayer();
            DataTable Software_SecurityUpdate = new DataTable();

            Software_SecurityUpdate.Columns.Add("SubjectId", typeof(int));
            Software_SecurityUpdate.Columns.Add("SubjectName", typeof(string));

            Software_SecurityUpdate.Rows.Add(3031, ll.GetMessageFromDll(_langCode, "UpdateName"));
            Soft_Main_Details = Software_SecurityUpdate;
        }


        private void FillOprator()
        {
            LogicLayer ll = new LogicLayer();
            //Create the data source and fill some data
            DataTable tbl_oprator = new DataTable();

            tbl_oprator.Columns.Add("SubjectId", typeof(int));
            tbl_oprator.Columns.Add("SubjectName", typeof(string));

            tbl_oprator.Rows.Add(1, ll.GetMessageFromDll(_langCode, "AnyPartOfField"));
            tbl_oprator.Rows.Add(2, ll.GetMessageFromDll(_langCode, "WholeField"));
            tbl_oprator.Rows.Add(3, ll.GetMessageFromDll(_langCode, "StartOfField"));
            tbl_oprator.Rows.Add(4, ll.GetMessageFromDll(_langCode, "AgainstOfField"));
            tbl_oprator.Rows.Add(5, ll.GetMessageFromDll(_langCode, "SmallerThan"));
            tbl_oprator.Rows.Add(6, ll.GetMessageFromDll(_langCode, "GreaterThan"));
            tbl_oprator.Rows.Add(7, ll.GetMessageFromDll(_langCode, "SmallerOrEqualThan"));
            tbl_oprator.Rows.Add(8, ll.GetMessageFromDll(_langCode, "GreaterOrEqualThan"));

            OpretorColumn.DataSource = tbl_oprator;
        }

        private void FillNextOprator()
        {
            LogicLayer ll = new LogicLayer();
            //Create the data source and fill some data
            DataTable tbl_nextoprator = new DataTable();

            tbl_nextoprator.Columns.Add("SubjectId", typeof(int));
            tbl_nextoprator.Columns.Add("SubjectName", typeof(string));

            tbl_nextoprator.Rows.Add(1, ll.GetMessageFromDll(_langCode, "LogicAnd"));
            tbl_nextoprator.Rows.Add(2, ll.GetMessageFromDll(_langCode, "LogicOr"));


            LogicOpretorColumn.DataSource = tbl_nextoprator;
        }
        

        private void FillForm()
        {
            LogicLayer ll = new LogicLayer();

            this.Text = ll.GetMessageFromDll(_langCode, "Search");
            grbDate.Text = ll.GetMessageFromDll(_langCode, "ReportDate");
            lblFromDate.Text = ll.GetMessageFromDll(_langCode, "FromDate");
            lblToDate.Text = ll.GetMessageFromDll(_langCode, "ToDate");

            grbAgent.Text = ll.GetMessageFromDll(_langCode, "SystemSelection");
            lblAgentName.Text = ll.GetMessageFromDll(_langCode, "SelectSystem");

            grbReport.Text = ll.GetMessageFromDll(_langCode, "ReportProperties");
            lblRepName.Text = ll.GetMessageFromDll(_langCode, "ReportTitle");


            lblAccount.Text = ll.GetMessageFromDll(_langCode, "Accounts");
            lblAppRun.Text = ll.GetMessageFromDll(_langCode, "ApplicationRuns");
            lblEvent.Text = ll.GetMessageFromDll(_langCode, "Events");
            lblGroup.Text = ll.GetMessageFromDll(_langCode, "Groups");
            lblHardware.Text = ll.GetMessageFromDll(_langCode, "Hardware");
            lblNetwork.Text = ll.GetMessageFromDll(_langCode, "Network");
            lblPersonel.Text = ll.GetMessageFromDll(_langCode, "Personel");
            lblSoftware.Text = ll.GetMessageFromDll(_langCode, "Software");


            btnDelRep.Text = ll.GetMessageFromDll(_langCode, "DeleteReport");
            btnSaveRep.Text = ll.GetMessageFromDll(_langCode, "SaveReport");
            btnCancel.Text = ll.GetMessageFromDll(_langCode, "btnCancel");
            btnOk.Text = ll.GetMessageFromDll(_langCode, "btnOk");

            ItemIdColumn = new GridViewTextBoxColumn();
            ItemIdColumn.FieldName = "id";
            ItemIdColumn.Width = 20;
            ItemIdColumn.IsVisible = false;

            ItemColumn = new GridViewTextBoxColumn();
            ItemColumn.FieldName = ll.GetMessageFromDll(_langCode, "Item");
            ItemColumn.Width = 250;
           

            OpretorColumn = new GridViewComboBoxColumn();
            OpretorColumn.ValueMember = "SubjectId";
            OpretorColumn.DisplayMember = "SubjectName";
            OpretorColumn.FieldName = ll.GetMessageFromDll(_langCode, "Operator");
            OpretorColumn.Width = 120;

            ValueColumn = new GridViewTextBoxColumn();
            ValueColumn.FieldName = ll.GetMessageFromDll(_langCode, "Value");
            ValueColumn.Width = 370;

            LogicOpretorColumn = new GridViewComboBoxColumn();
            LogicOpretorColumn.ValueMember = "SubjectId";
            LogicOpretorColumn.DisplayMember = "SubjectName";
            LogicOpretorColumn.FieldName = ll.GetMessageFromDll(_langCode, "NextOperator");
            LogicOpretorColumn.Width = 150;

            DeleteColumn = new GridViewCommandColumn();
            DeleteColumn.Name = "CommandColumn";
            DeleteColumn.UseDefaultText = true;
            DeleteColumn.HeaderText = "";
            DeleteColumn.DefaultText = ll.GetMessageFromDll(_langCode, "DeleteRow");
            DeleteColumn.TextAlignment = ContentAlignment.MiddleCenter;
            DeleteColumn.Width = 100;


            this.grvRep.Columns.Add(ItemColumn);
            this.grvRep.Columns.Add(OpretorColumn);
            this.grvRep.Columns.Add(ValueColumn);
            this.grvRep.Columns.Add(LogicOpretorColumn);
            this.grvRep.Columns.Add(DeleteColumn);
            this.grvRep.Columns.Add(ItemIdColumn);

            this.grvRep.CommandCellClick += new CommandCellClickEventHandler(grvRep_CommandCellClick);

            this.grvRep.Columns[0].ReadOnly = true;



        }

        private void grvRep_CommandCellClick(object sender, EventArgs e)
        {
            int rIndex = grvRep.CurrentRow.Index;
            grvRep.Rows.RemoveAt(rIndex);
        }


        /*
        private void FillItem1()
        {
            LogicLayer ll = new LogicLayer();
            //Create the data source and fill some data
            DataTable tbl_item1 = new DataTable();
            tbl_item1.Columns.Add("SubjectId", typeof(int));
            tbl_item1.Columns.Add("SubjectName", typeof(string));

            tbl_item1.Rows.Add(1, ll.GetMessageFromDll(_langCode, "Hardware"));
            tbl_item1.Rows.Add(2, ll.GetMessageFromDll(_langCode, "Personel"));
            tbl_item1.Rows.Add(3, ll.GetMessageFromDll(_langCode, "Software"));
            tbl_item1.Rows.Add(4, ll.GetMessageFromDll(_langCode, "Accounts"));
            tbl_item1.Rows.Add(5, ll.GetMessageFromDll(_langCode, "Groups"));
            tbl_item1.Rows.Add(6, ll.GetMessageFromDll(_langCode, "ApplicationRuns"));
            tbl_item1.Rows.Add(7, ll.GetMessageFromDll(_langCode, "Network"));
            tbl_item1.Rows.Add(8, ll.GetMessageFromDll(_langCode, "Events"));
            Item1Column.DataSource = tbl_item1;
            

            this.grvRep.Update();           

        }
        
        private void FillHardwares()
        {           

            grvRep.Columns.BeginUpdate();
            //Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_hardware;
            grvRep.Columns.EndUpdate();
            
        }

        private void FillPersonel()
        {
            grvRep.Columns.BeginUpdate();
            //Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_personel;
            grvRep.Columns.EndUpdate();
        }

        private void FillSoftware()
        {
           
            grvRep.Columns.BeginUpdate();
            Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_software;
            grvRep.Columns.EndUpdate();
        }

        private void FillAccount()
        {
            grvRep.Columns.BeginUpdate();
           // Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_account;
            grvRep.Columns.EndUpdate();
        }

        private void FillGroup()
        {
            grvRep.Columns.BeginUpdate();
            //Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_group;
            grvRep.Columns.EndUpdate();
        }


        private void FillNetwork()
        {
           
            grvRep.Columns.BeginUpdate();
           // Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_network;
            grvRep.Columns.EndUpdate();
        }

        private void FillEvent()
        {
            grvRep.Columns.BeginUpdate();
           // Item2Column.DataSource = null;
            Item2Column.DataSource = Program.tbl_item2_event;
            grvRep.Columns.EndUpdate();
        }

        private void FillApplication()
        {
            grvRep.Columns.BeginUpdate();           
         //   Item2Column.DataSource = null;
            grvRep.Columns.EndUpdate();
        }


        
        private void FillItem2()
        {
            LogicLayer ll = new LogicLayer();
            //Create the data source and fill some data
            DataTable Program.tbl_item2_hardware = new DataTable();
            DataTable Program.tbl_item2_personel = new DataTable();
            DataTable Program.tbl_item2_software = new DataTable();
            DataTable Program.tbl_item2_account = new DataTable();
            DataTable Program.tbl_item2_group = new DataTable();
            DataTable Program.tbl_item2_network = new DataTable();
            DataTable Program.tbl_item2_event = new DataTable();


            Program.tbl_item2_hardware.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_hardware.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_hardware.Rows.Add(101, ll.GetMessageFromDll(_langCode, "Hardware"));
            Program.tbl_item2_hardware.Rows.Add(102, ll.GetMessageFromDll(_langCode, "Personel"));
            Program.tbl_item2_hardware.Rows.Add(103, ll.GetMessageFromDll(_langCode, "Software"));
            Program.tbl_item2_hardware.Rows.Add(4, ll.GetMessageFromDll(_langCode, "Accounts"));
            Program.tbl_item2_hardware.Rows.Add(5, ll.GetMessageFromDll(_langCode, "Groups"));
            Program.tbl_item2_hardware.Rows.Add(6, ll.GetMessageFromDll(_langCode, "ApplicationRuns"));
            Program.tbl_item2_hardware.Rows.Add(7, ll.GetMessageFromDll(_langCode, "Network"));
            Program.tbl_item2_hardware.Rows.Add(8, ll.GetMessageFromDll(_langCode, "Events"));

            GridViewComboBoxColumn Item1Column = new GridViewComboBoxColumn();

            Item1Column.DataSource = Program.tbl_item2;
            Item1Column.ValueMember = "SubjectId";
            Item1Column.DisplayMember = "SubjectName";
            Item1Column.FieldName = ll.GetMessageFromDll(_langCode, "FirstItem");
            Item1Column.Width = 200;
            this.grvRep.Columns.Add(Item1Column);

        }
        */

        private void FillDate()
        {

            dapFrom.GeoDate = DateTime.Now;
            dapTo.GeoDate = DateTime.Now;
        }

        private void FillSystemName()
        {
            LogicLayer lg = new LogicLayer();
            int count = Program.AgentList.Count;
            RadListDataItem ditem = new RadListDataItem();
            ddlAgentName.BeginUpdate();
            this.ddlAgentName.ListElement.AutoSizeItems = true;


            for (int i = 0; i < count; i++)
            {
                if (Program.dataSource[i].UserFullName != " ")
                    ddlAgentName.Items.Add(Program.dataSource[i].UserFullName);
                else
                    ddlAgentName.Items.Add(Program.AgentList[i].ComputerName);

                ddlAgentName.Items[i].TextImageRelation = TextImageRelation.ImageBeforeText;
                ddlAgentName.Items[i].Image = GetImageFromData(lg.imageToByteArray((Program.dataSource[i].UserImage)));
                ddlAgentName.Items[i].Font = new Font("Tahoma", 9, FontStyle.Regular);
            }
            ddlAgentName.EndUpdate();
            ddlAgentName.SelectedIndex = 0;

        }

        private Image GetImageFromData(byte[] imageData)
        {
            const int OleHeaderLength = 78;
            MemoryStream memoryStream = new MemoryStream();
            if (HasOleContainerHeader(imageData))
            {
                memoryStream.Write(imageData, OleHeaderLength, imageData.Length - OleHeaderLength);
            }
            else
            {
                memoryStream.Write(imageData, 0, imageData.Length);
            }
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap.GetThumbnailImage(55, 65, null, new IntPtr());
        }

        private bool HasOleContainerHeader(byte[] imageByteArray)
        {
            const byte OleByte0 = 21;
            const byte OleByte1 = 28;
            return (imageByteArray[0] == OleByte0) && (imageByteArray[1] == OleByte1);
        } 

        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDate.CheckState == CheckState.Checked)
            {
                dapFrom.Enabled = true;
                dapTo.Enabled = true;
            }
            else if (chbDate.CheckState == CheckState.Unchecked)
            {
                dapFrom.Enabled = false;
                dapTo.Enabled = false;
            }
        }

        private string GetDateTime(string DT)
        {
            DateTime d = DateTime.Parse(DT);
            string yyyy = d.Year.ToString();
            string mm = d.Month.ToString();
            string dd = d.Day.ToString();
            string result = mm + "/" + dd + "/" + yyyy;
            return result;

        }

        private void chbAgentName_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAgentName.CheckState == CheckState.Checked)
            {
                ddlAgentName.Enabled = true;
            }
            else if (chbAgentName.CheckState == CheckState.Unchecked)
            {
                ddlAgentName.Enabled = false;
            }
        }

        private void chbReportProperties_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReportProperties.CheckState == CheckState.Checked)
            {
                txbRepName.Enabled = true;
            }
            else if (chbReportProperties.CheckState == CheckState.Unchecked)
            {
                txbRepName.Enabled = false;
            }
        }

        private void frmSearchAll_RtoL_Shown(object sender, EventArgs e)
        {
            this.grvRep.GridViewElement.GroupPanelElement.Visibility = ElementVisibility.Hidden;           
        }

        private void grvRep_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            var editor = e.ActiveEditor;
            if (editor != null && editor is RadDropDownListEditor)
            {
                RadDropDownListEditor dropDown = (RadDropDownListEditor)editor;
                RadDropDownListEditorElement element = (RadDropDownListEditorElement)dropDown.EditorElement;
                element.Font = new Font("Tahoma", 8);
                element.ListElement.Font = new Font("Tahoma", 8);
            }
        }




        private void ddlHardware_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {            
            int i = ddlHardware.SelectedIndex;
            string value = ddlHardware.Items[i].Value.ToString();
            string n = ddlHardware.Items[i].DisplayValue.ToString();
            DataTable dt = new DataTable();
            FillTablesDetails(value);
            
           

            ddlHardDetails.BeginUpdate();
            ddlHardDetails.DataSource = Hard_Main_Details;
            ddlHardDetails.DisplayMember = "SubjectName";
            ddlHardDetails.ValueMember = "SubjectId";
            ddlHardDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            ddlHardDetails.EndUpdate();
        }

        private void chbHardware_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHardware.CheckState == CheckState.Checked)
            {
                ddlHardware.Enabled = true;
                btnHardware.Enabled = true;
                ddlHardDetails.Enabled = true;

            }
            else if (chbHardware.CheckState == CheckState.Unchecked)
            {
                ddlHardware.Enabled = false;
                btnHardware.Enabled = false;
                ddlHardDetails.Enabled = false;

            }
        }
      

        private void btnHardware_Click(object sender, EventArgs e)
        {
            int i = ddlHardware.SelectedIndex;
            int s = ddlHardDetails.SelectedIndex;
            string value2 = ddlHardDetails.Items[s].Value.ToString();
            string value = ddlHardware.Items[i].Value.ToString();
            string n = ddlHardware.Items[i].DisplayValue.ToString() + " => " + ddlHardDetails.Items[s].DisplayValue.ToString();
            //FieldList.Add(GetField(value));
            //TableList.Add("Hardware." + GetTableName(value));
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value2;
            grvRep.Rows.Add(rowInfo);
        }

        private string GetField(string Value)
        {
            string res = "";
            switch (Value)
            {
                case "101":
                    res = "Brand";
                    break;
            }
            return res;
        }

        private string GetTableName(string Value)
        {           
            string res = "";
            switch(Value)
            {
                case "101":
                    res = "Processors";
                    break;
                case "102":
                    res = "Motherboard";
                    break;
                case "103":
                    res = "Memory";
                    break;
                case "104":
                    res = "HardDisk";
                    break;
                case "105":
                    res = "VideoCard";
                    break;
                case "106":
                    res = "Bios";
                    break;
                case "107":
                    res = "LogicDisk";
                    break;
                case "108":
                    res = "CdRom";
                    break;
                case "109":
                    res = "Chassis";
                    break;
                case "110":
                case "111":
                case "112":
                case "114":
                case "115":
                    res = "PublicDevices";
                    break;               
                case "113":
                    res = "Printer";
                    break;              
                case "116":
                    res = "Modem";
                    break;
                case "117":
                    res = "NetworkAdapter";
                    break;
            }
            return res;
        }

        private void ddlHardware_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlSoftware_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlNetwork_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlAccount_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlGroup_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlPersonel_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlEvent_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void chbSoftware_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSoftware.CheckState == CheckState.Checked)
            {
                ddlSoftware.Enabled = true;
                btnSoftware.Enabled = true;
                ddlSoftDetails.Enabled = true;
            }
            else if (chbSoftware.CheckState == CheckState.Unchecked)
            {
                ddlSoftware.Enabled = false;
                btnSoftware.Enabled = false;
                ddlSoftDetails.Enabled = false;
            }
        }

        private void chbNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNetwork.CheckState == CheckState.Checked)
            {
                ddlNetwork.Enabled = true;
                btnNetwork.Enabled = true;

            }
            else if (chbNetwork.CheckState == CheckState.Unchecked)
            {
                ddlNetwork.Enabled = false;
                btnNetwork.Enabled = false;
                ddlNetDetails.Enabled = false;

            }
        }

        private void chbAppRun_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAppRun.CheckState == CheckState.Checked)
            {
                txbAppRun.Enabled = true;
                btnAppRun.Enabled = true;

            }
            else if (chbAppRun.CheckState == CheckState.Unchecked)
            {
                txbAppRun.Enabled = false;
                btnAppRun.Enabled = false;

            }
        }

        private void chbAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAccount.CheckState == CheckState.Checked)
            {
                ddlAccount.Enabled = true;
                btnAccount.Enabled = true;

            }
            else if (chbAccount.CheckState == CheckState.Unchecked)
            {
                ddlAccount.Enabled = false;
                btnAccount.Enabled = false;
                ddlAccontDetails.Enabled = false;
            }
        }

        private void chbGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chbGroup.CheckState == CheckState.Checked)
            {
                ddlGroup.Enabled = true;
                btnGroup.Enabled = true;

            }
            else if (chbGroup.CheckState == CheckState.Unchecked)
            {
                ddlGroup.Enabled = false;
                btnGroup.Enabled = false;
                ddlGroupDetails.Enabled = false;

            }
        }

        private void chbPersonel_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPersonel.CheckState == CheckState.Checked)
            {
                ddlPersonel.Enabled = true;
                btnPersonel.Enabled = true;

            }
            else if (chbPersonel.CheckState == CheckState.Unchecked)
            {
                ddlPersonel.Enabled = false;
                btnPersonel.Enabled = false;
                ddlPersonelDetails.Enabled = false;

            }
        }

        private void chbEvent_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEvent.CheckState == CheckState.Checked)
            {
                ddlEvent.Enabled = true;
                btnEvent.Enabled = true;

            }
            else if (chbEvent.CheckState == CheckState.Unchecked)
            {
                ddlEvent.Enabled = false;
                btnEvent.Enabled = false;

            }
        }

        private void btnSoftware_Click(object sender, EventArgs e)
        {
            int i = ddlSoftware.SelectedIndex;
            int s = ddlSoftDetails.SelectedIndex;
            string value2 = ddlSoftDetails.Items[s].Value.ToString();
            string value = ddlSoftware.Items[i].Value.ToString();
            string n = ddlSoftware.Items[i].DisplayValue.ToString() + " => " + ddlSoftDetails.Items[s].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value2;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {            
            
            int i = ddlNetwork.SelectedIndex;
            string value = ddlNetwork.Items[i].Value.ToString();
            string n = lblNetwork.Text + " => " + ddlNetwork.Items[i].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            if (value == "707")
            {
                int s = ddlNetDetails.SelectedIndex;
                string value2 = ddlNetDetails.Items[s].Value.ToString();
                rowInfo.Cells[2].Value = ddlNetDetails.Items[s].DisplayValue.ToString();
                value = value2;
            }
           
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            int i = ddlAccount.SelectedIndex;
            string value = ddlAccount.Items[i].Value.ToString();
            string n = lblAccount.Text + " => " + ddlAccount.Items[i].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            if (value == "403")
            {
                int s = ddlAccontDetails.SelectedIndex;
                string value2 = ddlAccontDetails.Items[s].Value.ToString();
                rowInfo.Cells[2].Value = ddlAccontDetails.Items[s].DisplayValue.ToString();
                value = value2;
            }
           
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            int i = ddlGroup.SelectedIndex;
            string value = ddlGroup.Items[i].Value.ToString();
            string n = lblGroup.Text + " => " + ddlGroup.Items[i].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            if (value == "503")
            {
                int s = ddlGroupDetails.SelectedIndex;
                string value2 = ddlGroupDetails.Items[s].Value.ToString();
                rowInfo.Cells[2].Value = ddlGroupDetails.Items[s].DisplayValue.ToString();
                value = value2;
            }
            
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            int i = ddlPersonel.SelectedIndex;
            string value = ddlPersonel.Items[i].Value.ToString();
            string n = lblPersonel.Text + " => " + ddlPersonel.Items[i].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            if (value == "204")
            {
                int s = ddlPersonelDetails.SelectedIndex;
                string value2 = ddlPersonelDetails.Items[s].Value.ToString();
                rowInfo.Cells[2].Value = ddlPersonelDetails.Items[s].DisplayValue.ToString();
                value = value2;
            }
            
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            int i = ddlEvent.SelectedIndex;
            string value = ddlEvent.Items[i].Value.ToString();
            string n = ddlEvent.Items[i].DisplayValue.ToString();
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[5].Value = value;
            grvRep.Rows.Add(rowInfo);
        }

        private void btnAppRun_Click(object sender, EventArgs e)
        {
            string value = txbAppRun.Text.Trim();

            string n = lblAppRun.Text;
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grvRep.MasterView);
            rowInfo.Cells[0].Value = n;
            rowInfo.Cells[2].Value = value;
            rowInfo.Cells[5].Value = "1000";
            grvRep.Rows.Add(rowInfo);
        }

        private void btnOk_Click(object sender, EventArgs e)        
        {
            _query = "SELECT ";
            _fromTable = "FROM ";
            _condition = "WHERE ";
            TableList = new List<string>();
            FieldList = new List<string>();
            myQuery = new List<Query>();

            if (chbDate.CheckState == CheckState.Checked)
            {
                _fd = GetDateTime(dapFrom.GeoDate.ToString());
                _td = GetDateTime(dapTo.GeoDate.ToString());
                _dateCondition = " EventDateTime >= Convert(date,'" + _fd + "') AND EventDateTime <= Convert(date,'" + _td + "')";
            }
            if (chbAgentName.CheckState == CheckState.Checked)
            {
                int i = ddlAgentName.SelectedIndex;
                _agentId = Program.AgentList[i].AgentID;
                _agentName = Program.AgentList[i].ComputerName;
            }
            if (grvRep.Rows.Count == 0)
            {
                LogicLayer ll = new LogicLayer();
                string ms = ll.GetErrorMessage(31);
                frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                frmi.ShowDialog();               
            }
            if (grvRep.Rows.Count == 1)
            {
                bool AreValuesFill = true;
                string op, value, code;
                value = "";
                code = grvRep.Rows[0].Cells[5].Value.ToString();
                if (grvRep.Rows[0].Cells[1].Value == null)
                    op = "1"; // Like
                else
                    op = grvRep.Rows[0].Cells[1].Value.ToString();
                if (grvRep.Rows[0].Cells[2].Value == null)
                {
                    AreValuesFill = false;
                }
                else
                {
                    if (code == "2041")
                        value = "0";
                    else if (code == "2042")
                        value = "1";
                    else if (code == "4031")
                        value = "OK";
                    else if (code == "4032")
                        value = "Degraded";
                    else if (code == "5031")
                        value = "OK";
                    else if (code == "5032")
                        value = "Degraded";
                    else if (code == "7071")
                        value = "True";
                    else if (code == "7072")
                        value = "False";

                    else
                        value = grvRep.Rows[0].Cells[2].Value.ToString();
                }

                SetQuery(code);
                myQuery[0].Item = grvRep.Rows[0].Cells[0].Value.ToString();
                List<string> eventsId = new List<string>();
                eventsId = SetEventsId(code);

                //bool AreValuesFill = CheckValues(myQuery);

                if (AreValuesFill == true)
                {
                    if (eventsId.Count != 0)
                        _query = BuildFinalQuery(0, op, value, eventsId);
                    else
                        _query = BuildFinalQuery(0, op, value);


                    SQLAccess sqla = new SQLAccess();
                    DataTable mdt = new DataTable();
                    mdt = sqla.ExcecuteSelectQueryToDataTable(_query);
                    if (mdt.Rows.Count == 0)
                    {
                        LogicLayer ll = new LogicLayer();
                        string ms = ll.GetMessageFromDll(_langCode, "SearchNoResult");
                        frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                        frmi.ShowDialog();
                    }
                    else
                    {
                        OpenResultForm(mdt, txbRepName.Text);
                    }
                }
                else
                {
                    LogicLayer ll = new LogicLayer();
                    string ms = ll.GetMessageFromDll(_langCode, "FillOneOrMoreValue");
                    frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                    frmi.ShowDialog();
                }
            }
            if (grvRep.Rows.Count > 1)
            {
                string op, value, code ,opnext;
                //value = "";
                for (int i = 0; i < grvRep.Rows.Count; i++)
                {
                    value = "";
                    code = grvRep.Rows[i].Cells[5].Value.ToString();
                    if (grvRep.Rows[i].Cells[1].Value != null)
                        op = grvRep.Rows[i].Cells[1].Value.ToString();
                    else
                        op = "1"; // Like
                    
                    if (grvRep.Rows[i].Cells[3].Value != null)
                    {
                        opnext = grvRep.Rows[i].Cells[3].Value.ToString();
                    }
                    else
                    {
                        if (i == grvRep.Rows.Count - 1)
                            opnext = "";
                        else
                            opnext = "2";//or
                    }
                    if (grvRep.Rows[i].Cells[2].Value == null)
                    {
                     
                    }
                    else
                    {
                        if (code == "2041")
                            value = "0";
                        else if (code == "2042")
                            value = "1";
                        else if (code == "4031")
                            value = "OK";
                        else if (code == "4032")
                            value = "Degraded";
                        else if (code == "5031")
                            value = "OK";
                        else if (code == "5032")
                            value = "Degraded";
                        else if (code == "7071")
                            value = "True";
                        else if (code == "7072")
                            value = "False";

                        else
                            value = grvRep.Rows[i].Cells[2].Value.ToString();
                    }                        
                    
                    SetQuery(code);
                    SetTableList();
                    List<string> eventsId = new List<string>();
                    eventsId = SetEventsId(code);
                  
                    myQuery[i].Value = value;
                    myQuery[i].Oprator = op;
                    myQuery[i].NextOprator = opnext;
                    myQuery[i].Item = grvRep.Rows[i].Cells[0].Value.ToString();
                    if (eventsId.Count != 0)
                        BuildCondition(i,eventsId);
                    else
                        BuildCondition(i);
                                       
                }

                bool AreValuesFill =  CheckValues(myQuery);

                if (AreValuesFill == true)
                {
                    _query = BuildFinalQuery(1, null, null);
                    SQLAccess sqla = new SQLAccess();
                    DataTable mdt = new DataTable();
                    mdt = sqla.ExcecuteSelectQueryToDataTable(_query);
                    if (mdt.Rows.Count == 0)
                    {
                        LogicLayer ll = new LogicLayer();
                        string ms = ll.GetMessageFromDll(_langCode, "SearchNoResult");
                        frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                        frmi.ShowDialog();
                    }
                    else
                    {
                        OpenResultForm(mdt, txbRepName.Text);
                    }
                }
                else
                {
                    LogicLayer ll = new LogicLayer();
                    string ms = ll.GetMessageFromDll(_langCode, "FillOneOrMoreValue");
                    frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                    frmi.ShowDialog();
                }              
            }    
        }

        private bool CheckValues(List<Query> Qr)
        {
            bool result = false;
            int r = Qr.Count;
            if (r > 0)
            {
                result = true;
                for (int i = 0; i < r; i++)
                {
                    if (Qr[i].Value == "")
                        result = false;
                    else if (Qr[i].Value == null)
                        result = false;
                }
            }
            return result;
        }

        private List<string> SetEventsId(string Code)
        {
            List<string> res = new List<string>();
            string code = Code;
            switch (code)
            {
                case "801":
                    res.Add("1000");
                    break;
                case "802":
                    res.Add("2000");
                    res.Add("2001");
                    res.Add("2002");
                    res.Add("2003");
                    res.Add("2004");
                  
                    break;
                case "803":
                    res.Add("3000");
                    res.Add("3001");
                    res.Add("3002");
                    res.Add("3003");
                    res.Add("3004");
                    res.Add("3005");
                  
                    break;
                case "804":
                    res.Add("4000");
                    res.Add("4001");
                    res.Add("4002");
                    res.Add("4003");
                    res.Add("4004");
                  
                    break;
                case "805":
                    res.Add("5000");
                    res.Add("5001");
                    res.Add("5002");
                    res.Add("5003");
                    res.Add("5004");
                    res.Add("5005");
                  
                    break;
                case "806":
                    res.Add("6000");
                    res.Add("6001");
                    res.Add("6002");
                    res.Add("6003");
                    res.Add("6004");
                    res.Add("6005");
                    res.Add("6006");
                    res.Add("6007");
                
                    break;
                case "807":
                    res.Add("7000");
                    res.Add("7001");
                    res.Add("7002");
                    res.Add("7003");
                    res.Add("7004");
                    res.Add("7005");
                    res.Add("7006");
                    res.Add("7007");
                    break;           
                case "808":
                    res.Add("8000");
                    res.Add("8001");
                    res.Add("8002");
                    res.Add("8003");
                    res.Add("8004");
                    res.Add("8005");
                    res.Add("8006");
                    res.Add("8007");
             
                    break;
                case "809":
                    res.Add("9000");
                
                    break;
                case "810":
                    res.Add("10000");
              
                    break;
                case "811":
                    res.Add("11000");
                
                    break;
                case "812":
                    res.Add("12000");
                    res.Add("12001");
                    res.Add("12002");
                    res.Add("12003");
             
                    break;
                case "813":
                    res.Add("14000");
             
                    break;
                case "814":
                    res.Add("13000");
             
                    break;
                case "815":
                    res.Add("15000");
                    res.Add("15001");
                    res.Add("15002");
                    res.Add("15003");
        
                    break;
                case "816":
                    res.Add("16000");
                    res.Add("16001");
                    res.Add("16002");
          
                    break;
                case "817":
                    res.Add("17000");
                    res.Add("17001");
                    res.Add("17002");
               
                    break;
                case "818":
                    res.Add("18000");
                    res.Add("18001");
                    res.Add("18002");
                    res.Add("18003");
                    res.Add("18004");
                    res.Add("18005");
         
                    break;
                case "819":
                    res.Add("19000");
                    res.Add("19001");
                    res.Add("19002");
             
                    break;
                case "820":
                    res.Add("20000");
                
                    break;
                case "821":
                    res.Add("21000");
               
                    break;
                case "822":
                    res.Add("22000");
         
                    break;
                case "823":
                    res.Add("23000");
          
                    break;
                case "824":
                    res.Add("24000");
           
                    break;
                case "825":
                    res.Add("25000");
         
                    break;
                case "826":
                    res.Add("26000");
                    res.Add("26001");
                    res.Add("26002");
                    res.Add("26003");
                    res.Add("26004");
            
                    break;
                case "827":
                    res.Add("27000");
                    res.Add("27001");
                    res.Add("27002");
        
                    break;
                case "828":
                    res.Add("28000");
                    res.Add("28001");
                    res.Add("28002");
                    res.Add("28003");
                    res.Add("28004");
                    res.Add("28005");
            
                    break;
                case "829":
                    res.Add("29000");
                    res.Add("29001");
                    res.Add("29002");
                    res.Add("29003");
                    res.Add("29004");
                    res.Add("29005");
           
                    break;
                case "830":
                    res.Add("30000");
                    res.Add("30001");
                    res.Add("30002");
                    res.Add("31000");
                    res.Add("31001");
                    res.Add("31002");
                    res.Add("31003");
                    res.Add("31004");
                    res.Add("32000");
                    res.Add("33000");
                    res.Add("33001");
           
                    break;         
            }
            return res;
        }

        private void OpenResultForm(DataTable mdt, string p)
        {
            if (chbAgentName.CheckState == CheckState.Checked)
            {
                frmRepSerchAll_RtoL frmsa = new frmRepSerchAll_RtoL(mdt, p, myQuery, _agentId);
                frmsa.Show();
            }
            else
            {
                frmRepSerchAll_RtoL frmsa2 = new frmRepSerchAll_RtoL(mdt, p, myQuery, null);
                frmsa2.Show();
            }
        }

        private void SetTableList()
        {
            int f = myQuery.Count;
            string tname = "";
            int index = 0;
            for (int i = 0; i < f; i++)
            {
                tname = myQuery[i].GetTableName(0);
                index = TableList.IndexOf(tname);
                if (index == -1)
                    TableList.Add(tname);
                tname = "";
                index = 0;
            }
        }

        private void BuildCondition(int Index,List<string> EvId)
        {
            StringBuilder q = new StringBuilder();
            string r;
            if (EvId.Count == 1)
            {
                if (chbDate.CheckState == CheckState.Unchecked)
                    r = " Agent.Events.EventId = " + EvId[0] + " AND ";
                else
                    r = " Agent.Events.EventId = " + EvId[0] + " AND " + _dateCondition + " AND ";
            }
            else
            {
                if (chbDate.CheckState == CheckState.Unchecked)
                    r = " Agent.Events.EventId BETWEEN " + EvId[0] + " AND " + EvId[EvId.Count - 1] + " AND ";
                else
                    r = " Agent.Events.EventId BETWEEN " + EvId[0] + " AND " + EvId[EvId.Count - 1] + " AND " + _dateCondition + " AND ";
            }
            int l = myQuery[Index].FieldsCount;
            q.Append("(");
            q.Append(r);
            for (int i = 0; i < l; i++)
            {
                string cond = GetOprator(myQuery[Index].GetFieldName(i), myQuery[Index].Oprator, myQuery[Index].Value);
                q.Append(cond);
                if (i < l - 1)
                    q.Append(" OR ");
            }
            q.Append(")");
            if (myQuery[Index].NextOprator == "1")
                q.Append(" AND ");
            else if (myQuery[Index].NextOprator == "2")
                q.Append(" OR ");

            myQuery[Index].Condition = q.ToString();

        }

        private void BuildCondition(int Index)
        {
            StringBuilder q = new StringBuilder();


            int l = myQuery[Index].FieldsCount;
            q.Append("(");
            for (int i = 0; i < l; i++)
            {
                string cond = GetOprator(myQuery[Index].GetFieldName(i), myQuery[Index].Oprator, myQuery[Index].Value);
                q.Append(cond);
                if (i < l - 1)
                    q.Append(" OR ");
            }
            q.Append(")");
            if (myQuery[Index].NextOprator == "1")
                q.Append(" AND ");
            else if (myQuery[Index].NextOprator == "2")
                q.Append(" OR ");

            myQuery[Index].Condition = q.ToString();
            
        }

        private string BuildFinalQuery(int Join, string Oprator, string Value,List <string> EvId)
        {
            StringBuilder q = new StringBuilder();
            q.Append("SELECT * FROM ");



            if (Join == 0)
            {
                q.Append(myQuery[0].GetTableName(0));

                if (EvId.Count == 1)
                {
                    if (chbDate.CheckState == CheckState.Unchecked)
                        q.Append(" WHERE Agent.Events.EventId = " + EvId[0] + " AND ");
                    else
                        q.Append(" WHERE Agent.Events.EventId = " + EvId[0] + " AND " + _dateCondition + " AND ");
                }
                else
                {
                    int len = EvId.Count;
                    if (chbDate.CheckState == CheckState.Unchecked)
                        q.Append(" WHERE Agent.Events.EventId BETWEEN " + EvId[0] + " AND " + EvId[len - 1] + " AND ");
                    else
                        q.Append(" WHERE Agent.Events.EventId BETWEEN " + EvId[0] + " AND " + EvId[len - 1] + " AND " + _dateCondition + " AND ");
                }

                if (chbAgentName.CheckState == CheckState.Checked)
                {
                    q.Append("AgentId = " + _agentId + " AND ");
                }

                int l = myQuery[0].FieldsCount;

                for (int i = 0; i < l; i++)
                {
                    string cond = GetOprator(myQuery[0].GetFieldName(i), Oprator, Value);
                    q.Append(cond);
                    if (i < l - 1)
                        q.Append(" OR ");
                }
            }
            if (Join == 1)
            {
                q.Append(TableList[0]);

                for (int i = 0; i < TableList.Count; i++)
                {
                    if (TableList.Count > 1 && i > 0)
                    {
                        q.Append(" JOIN ");
                        q.Append(TableList[i]);
                        q.Append(" ON ");
                        q.Append(TableList[i] + ".AgentId = " + TableList[i - 1] + ".AgentId");
                    }

                }
                q.Append(" WHERE ");
                for (int i = 0; i < myQuery.Count; i++)
                {
                    q.Append(myQuery[i].Condition);
                }
            }



            return q.ToString();
        }

        private string BuildFinalQuery(int Join,string Oprator,string Value)
        {
            StringBuilder q = new StringBuilder();
            q.Append("SELECT * FROM ");



            if (Join == 0)
            {
                q.Append(myQuery[0].GetTableName(0));
                if (chbAgentName.CheckState == CheckState.Unchecked)
                    q.Append(" WHERE ");
                else
                    q.Append(" WHERE AgentId = " + _agentId + " AND ");
                int l = myQuery[0].FieldsCount;


                for (int i = 0;i < l;i++)
                {
                    string cond = GetOprator(myQuery[0].GetFieldName(i), Oprator, Value);
                    q.Append(cond);
                    if (i < l - 1)
                        q.Append(" OR ");
                }
            }
            if (Join == 1)
            {               
                q.Append(TableList[0]);

                for (int i = 0; i < TableList.Count; i++)
                {                 
                    if (TableList.Count > 1 && i > 0)
                    {                        
                        q.Append(" JOIN ");
                        q.Append(TableList[i]);
                        q.Append(" ON ");
                        q.Append(TableList[i] + ".AgentId = " + TableList[i - 1] + ".AgentId");
                    }

                }
                if (chbAgentName.CheckState == CheckState.Unchecked)
                    q.Append(" WHERE ");
                else
                    q.Append(" WHERE " + TableList[0] + ".AgentId = " + _agentId + " AND ");

                for (int i = 0; i < myQuery.Count; i++)
                {
                    q.Append(myQuery[i].Condition);
                }
            }



            return q.ToString();
        }

        private void SetQuery(string Code)
        {
            LogicLayer ll = new LogicLayer();
            Query fQ = new Query();
            fQ.Name = Code;
            switch (Code)
            {
                case "1011":
                    fQ.AddTable("Hardware.Processors");
                    fQ.AddField("Hardware.Processors.Brand");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1012":
                    fQ.AddTable("Hardware.Processors");
                    fQ.AddField("Hardware.Processors.Brand");
                   // fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1013":
                    fQ.AddTable("Hardware.Processors");
                    fQ.AddField("Hardware.Processors.SerialNumber");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1021":
                    fQ.AddTable("Hardware.Motherboard");
                    fQ.AddField("Hardware.Motherboard.Manufactorer");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1022":
                    fQ.AddTable("Hardware.Motherboard");
                    fQ.AddField("Hardware.Motherboard.Product");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Model"));
                    break;
                case "1023":
                    fQ.AddTable("Hardware.Motherboard");
                    fQ.AddField("Hardware.Motherboard.SerialNumber");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1024":
                    fQ.AddTable("Hardware.Motherboard");
                    fQ.AddField("Hardware.Motherboard.Version");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Version"));
                    break;
                case "1031":
                    fQ.AddTable("Hardware.Memory");
                    fQ.AddField("Hardware.Memory.Model");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Model"));
                    break;
                case "1032":
                    fQ.AddTable("Hardware.Memory");
                    fQ.AddField("Hardware.Memory.Speed");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Speed"));
                    break;
                case "1033":
                    fQ.AddTable("Hardware.Memory");
                    fQ.AddField("Hardware.Memory.SerialNumber");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1034":
                    fQ.AddTable("Hardware.Memory");
                    fQ.AddField("Hardware.Memory.Capacity");
                    //fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Capacity"));
                    break;
                case "1041":
                    fQ.AddTable("Hardware.HardDisk");
                    fQ.AddField("Hardware.HardDisk.Caption");
                    // fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1042":
                    fQ.AddTable("Hardware.HardDisk");
                    fQ.AddField("Hardware.HardDisk.PnpDevice");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Model"));
                    break;
                case "1043":
                    fQ.AddTable("Hardware.HardDisk");
                    fQ.AddField("Hardware.HardDisk.SerialNumber");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1044":
                    fQ.AddTable("Hardware.HardDisk");
                    fQ.AddField("Hardware.HardDisk.HardSize");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Capacity"));
                    break;
                case "1045":
                    fQ.AddTable("Hardware.HardDisk");
                    fQ.AddField("Hardware.HardDisk.Partitiones");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Parition"));
                    break;                 
                case "1051":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.Caption");
                    // fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1052":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.DriverDate");
                    // fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DriverDate"));
                    break;
                case "1053":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.SerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1054":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.DriverVersion");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DriverVersion"));
                    break;
                case "1055":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.VideoProcessor");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "VideoProcessor"));
                    break;
                case "1056":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.VideoMode");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "VideoMode"));
                    break;
                case "1057":
                    fQ.AddTable("Hardware.VideoCard");
                    fQ.AddField("Hardware.VideoCard.AdapterRam");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AdapterRam"));
                    break;   
                case "1061":
                    fQ.AddTable("Hardware.Bios");
                    fQ.AddField("Hardware.Bios.Vendor");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1062":
                    fQ.AddTable("Hardware.Bios");
                    fQ.AddField("Hardware.Bios.ReleasDate");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DriverDate"));
                    break;
                case "1063":
                    fQ.AddTable("Hardware.Bios");
                    fQ.AddField("Hardware.Bios.Version");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DriverVersion"));
                    break;
                case "1064":
                    fQ.AddTable("Hardware.Bios");
                    fQ.AddField("Hardware.Bios.BiosRomSize");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AdapterRam"));
                    break;    
                case "1071":
                    fQ.AddTable("Hardware.LogicDisk");
                    fQ.AddField("Hardware.LogicDisk.VolumeName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Firstname"));
                    break;
                case "1072":
                    fQ.AddTable("Hardware.LogicDisk");
                    fQ.AddField("Hardware.LogicDisk.FileSystem");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "FileSystemType"));
                    break;
                case "1073":
                    fQ.AddTable("Hardware.LogicDisk");
                    fQ.AddField("Hardware.LogicDisk.VolumeSerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1081":
                    fQ.AddTable("Hardware.CdRom");
                    fQ.AddField("Hardware.CdRom.CdRomName");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1082":
                    fQ.AddTable("Hardware.CdRom");
                    fQ.AddField("Hardware.CdRom.SerialNumber");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;              
                case "1091":
                    fQ.AddTable("Hardware.Chassis");
                    fQ.AddField("Hardware.Chassis.AssetTagNumber");
                    fQ.AddField("Hardware.Chassis.ChassisType");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "SystemType"));
                    break;       
                case "1101":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.Monitor");
                    //      fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1102":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1103":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.MonitorSerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1111":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.Keyboard");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1112":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1113":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.KeyboardSerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1121":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.Mouse");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1122":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1123":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.MouseSerialNumber");
                    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1141":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.Camera");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1142":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1143":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.CameraSerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1151":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.Scanner");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1152":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1153":
                    fQ.AddTable("Hardware.PublicDevices");
                    fQ.AddField("Hardware.PublicDevices.ScannerSerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;               
                case "1131":
                    fQ.AddTable("Hardware.Printer");
                    fQ.AddField("Hardware.Printer.PrinterName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1132":
                    fQ.AddTable("Agent.AssetNumber");
                    fQ.AddField("Agent.AssetNumber.Assetnumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "AssetNumber"));
                    break;
                case "1133":
                    fQ.AddTable("Hardware.Printer");
                    fQ.AddField("Hardware.Printer.SerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break; 
                case "1161":
                    fQ.AddTable("Hardware.Modem");
                    fQ.AddField("Hardware.Modem.ModemName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1162":
                    fQ.AddTable("Hardware.Modem");
                    fQ.AddField("Hardware.Modem.SerialNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "1171":
                    fQ.AddTable("Hardware.NetworkAdapter");
                    fQ.AddField("Hardware.NetworkAdapter.Description");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Brand"));
                    break;
                case "1172":
                    fQ.AddTable("Hardware.NetworkAdapter");
                    fQ.AddField("Hardware.NetworkAdapter.AdapterType");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "NetType"));
                    break;
                case "1173":
                    fQ.AddTable("Hardware.NetworkAdapter");
                    fQ.AddField("Hardware.NetworkAdapter.MacAddress");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "MacAddress"));
                    break;        
                case "201":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.FirstName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Firstname"));
                    break;
                case "202":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.LastName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Lastname"));
                    break;
                case "203":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.PersonnelCode");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "PersonelCode"));
                    break;
                case "2041":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.Gender");
                    //     fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Gender"));
                    break;
                case "2042":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.Gender");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Gender"));
                    break;
                case "205":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserInterNum");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "InternalContact"));
                    break;
                case "206":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserEmail");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "EmailAddress"));
                    break;
                case "207":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserTell");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Tell"));
                    break;
                case "208":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserMob");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Mob"));
                    break;
                case "209":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserAddress");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Address"));
                    break;
                case "210":
                    fQ.AddTable("Users.Personnel");
                    fQ.AddField("Users.Personnel.UserTitle");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "JobTitle"));
                    break;       
                case "3011":
                    fQ.AddTable("Software.OperatingSystem");
                    fQ.AddField("Software.OperatingSystem.BuildNumber");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "BuildNumber"));
                    break;
                case "3012":
                    fQ.AddTable("Software.OperatingSystem");
                    fQ.AddField("Software.OperatingSystem.SerialNumber");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "lblSerialNumber"));
                    break;
                case "3013":
                    fQ.AddTable("Software.OperatingSystem");
                    fQ.AddField("Software.OperatingSystem.Caption");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "OSName"));
                    break;
                case "3014":
                    fQ.AddTable("Software.OperatingSystem");
                    fQ.AddField("Software.OperatingSystem.InstallDate");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "InstallDate"));
                    break;                 
                case "3021":
                    fQ.AddTable("Software.Softwares");
                    fQ.AddField("Software.Softwares.SoftwareName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "ApplicationName"));
                    break;
                case "3031":
                    fQ.AddTable("Software.Softwares");
                    fQ.AddField("Software.Softwares.SoftwareName");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "UpdateName"));
                    break;     
                case "401":
                    fQ.AddTable("Account.UserAccounts");
                    fQ.AddField("Account.UserAccounts.Username");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "UserNameText"));
                    break;
                case "402":
                    fQ.AddTable("Account.UserAccounts");
                    fQ.AddField("Account.UserAccounts.Sids");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "SID"));
                    break;
                case "4031":
                case "4032":
                    fQ.AddTable("Account.UserAccounts");
                    fQ.AddField("Account.UserAccounts.Statuss");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Status"));
                    break;
                case "404":
                    fQ.AddTable("Account.UserAccounts");
                    fQ.AddField("Account.UserAccounts.Descriptions");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Description"));
                    break;
                case "501":
                    fQ.AddTable("Account.UserGroup");
                    fQ.AddField("Account.UserGroup.GroupName");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "UserNameText"));
                    break;
                case "502":
                    fQ.AddTable("Account.UserGroup");
                    fQ.AddField("Account.UserGroup.Sids");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "SID"));
                    break;
                case "5031":
                case "5032":
                    fQ.AddTable("Account.UserGroup");
                    fQ.AddField("Account.UserGroup.Statuss");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Status"));
                    break;
                case "504":
                    fQ.AddTable("Account.UserGroup");
                    fQ.AddField("Account.UserGroup.Descriptions");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Description"));
                    break;
                case "701":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.IPAddress");
                    //     fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "IPAddress"));
                    break;
                case "702":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.MACAddress");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "MacAddress"));
                    break;
                case "703":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.DefaultGateway");
                    //  fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "GatewayAddress"));
                    break;
                case "704":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.SubnetMask");
                    //    fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "NetMask"));
                    break;
                case "705":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.DNSHostName");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DNSAddress"));
                    break;
                case "706":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.DHCPServerIP");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DHCPAddress"));
                    break;
                case "7071":
                case "7072":
                    fQ.AddTable("Network.ActiveAdapter");
                    fQ.AddField("Network.ActiveAdapter.DHCPEnable");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "DHCPStatus"));
                    break;
                case "801":
                case "802":
                case "803":
                case "804":
                case "805":
                case "806":
                case "807":
                case "808":
                case "809":
                case "810":
                case "811":
                case "812":
                case "813":
                case "814":
                case "815":
                case "816":
                case "817":
                case "818":
                case "819":
                case "820":
                case "821":
                case "822":
                case "823":
                case "824":
                case "825":
                case "826":
                case "827":
                case "828":
                case "829":
                case "830":
                    fQ.AddTable("Agent.Events");
                    fQ.AddField("Agent.Events.CurrentValue");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "Event"));
                    break;
                case "1000":
                    fQ.AddTable("Agent.ApplicationRuns");
                    fQ.AddField("Agent.ApplicationRuns.Title");
                    //   fQ.AddFieldTransName(ll.GetMessageFromDll(_langCode, "ApplicationName"));
                    break;

            }
            myQuery.Add(fQ);
            /*
         Program.tbl_item2_event.Rows.Add(801, ll.GetMessageFromDll(_langCode, "CPUChanges"));
            Program.tbl_item2_event.Rows.Add(802, ll.GetMessageFromDll(_langCode, "MainboardChanges"));
            Program.tbl_item2_event.Rows.Add(803, ll.GetMessageFromDll(_langCode, "BiosChanges"));
            Program.tbl_item2_event.Rows.Add(804, ll.GetMessageFromDll(_langCode, "MemoryChanges"));
            Program.tbl_item2_event.Rows.Add(805, ll.GetMessageFromDll(_langCode, "HardDiskChanges"));
            Program.tbl_item2_event.Rows.Add(806, ll.GetMessageFromDll(_langCode, "LogicDiskChanges"));
            Program.tbl_item2_event.Rows.Add(807, ll.GetMessageFromDll(_langCode, "VideoCardChanges"));
            Program.tbl_item2_event.Rows.Add(808, ll.GetMessageFromDll(_langCode, "NetAdapterChanges"));
            Program.tbl_item2_event.Rows.Add(809, ll.GetMessageFromDll(_langCode, "KeyboardChanges"));
            Program.tbl_item2_event.Rows.Add(810, ll.GetMessageFromDll(_langCode, "MouseChanges"));

            Program.tbl_item2_event.Rows.Add(811, ll.GetMessageFromDll(_langCode, "MonitorChanges"));
            Program.tbl_item2_event.Rows.Add(812, ll.GetMessageFromDll(_langCode, "PrinterChanges"));
            Program.tbl_item2_event.Rows.Add(813, ll.GetMessageFromDll(_langCode, "ScannerChanges"));
            Program.tbl_item2_event.Rows.Add(814, ll.GetMessageFromDll(_langCode, "CammeraChanges"));
            Program.tbl_item2_event.Rows.Add(815, ll.GetMessageFromDll(_langCode, "CdromChanges"));
            Program.tbl_item2_event.Rows.Add(816, ll.GetMessageFromDll(_langCode, "ModemChanges"));
            Program.tbl_item2_event.Rows.Add(817, ll.GetMessageFromDll(_langCode, "ApplicationChanges"));
            Program.tbl_item2_event.Rows.Add(818, ll.GetMessageFromDll(_langCode, "OsChanges"));
            Program.tbl_item2_event.Rows.Add(819, ll.GetMessageFromDll(_langCode, "UpdatesChanges"));
            Program.tbl_item2_event.Rows.Add(820, ll.GetMessageFromDll(_langCode, "IpChanges"));

            Program.tbl_item2_event.Rows.Add(821, ll.GetMessageFromDll(_langCode, "SubnetChanges"));
            Program.tbl_item2_event.Rows.Add(822, ll.GetMessageFromDll(_langCode, "GwChanges"));
            Program.tbl_item2_event.Rows.Add(823, ll.GetMessageFromDll(_langCode, "MacChanges"));
            Program.tbl_item2_event.Rows.Add(824, ll.GetMessageFromDll(_langCode, "DnsChanges"));
            Program.tbl_item2_event.Rows.Add(825, ll.GetMessageFromDll(_langCode, "DhcpChanges"));
            Program.tbl_item2_event.Rows.Add(826, ll.GetMessageFromDll(_langCode, "PowerChanges"));
            Program.tbl_item2_event.Rows.Add(827, ll.GetMessageFromDll(_langCode, "FlashChanges"));
            Program.tbl_item2_event.Rows.Add(828, ll.GetMessageFromDll(_langCode, "UserAccountChange"));
            Program.tbl_item2_event.Rows.Add(829, ll.GetMessageFromDll(_langCode, "GroupAccountChange"));
            Program.tbl_item2_event.Rows.Add(830, ll.GetMessageFromDll(_langCode, "PublicChanges"));
             */
        }

        private string GetOprator(string Field,string Oprator,string Value)
        {
            string res = "";
            switch(Oprator)
            {
                case "1":
                    res = Field + " LIKE '%" + Value + "%'";
                    break;
                case "2":
                    res = Field + " = '" + Value + "'";
                    break;
                case "3":
                    res = Field + " LIKE '" + Value + "%'";
                    break;
                case "4":
                    res = "NOT "+ Field + " = '"+ Value + "'";
                    break;
                case "5":
                    res = Field + " < '" + Value + "'";
                    break;
                case "6":
                    res = Field + " > '" + Value + "'";
                    break;
                case "7":
                    res = Field + " <= '" + Value + "'";
                    break;
                case "8":
                    res = Field + " >= '" + Value + "'";
                    break;
            }
            return res;           
        }

        private void ddlHardDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlAgentName_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlSoftware_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int i = ddlSoftware.SelectedIndex;
            string value = ddlSoftware.Items[i].Value.ToString();
            string n = ddlSoftware.Items[i].DisplayValue.ToString();
            DataTable dt = new DataTable();
            FillTablesDetails(value);

            ddlSoftDetails.BeginUpdate();
            ddlSoftDetails.DataSource = Soft_Main_Details;
            ddlSoftDetails.DisplayMember = "SubjectName";
            ddlSoftDetails.ValueMember = "SubjectId";
            ddlSoftDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            ddlSoftDetails.EndUpdate();
        }

        private void ddlSoftDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlNetwork_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int i = ddlNetwork.SelectedIndex;
            string value = ddlNetwork.Items[i].Value.ToString();
            string n = ddlNetwork.Items[i].DisplayValue.ToString();
            if (value == "707")
            {
                ddlNetDetails.Enabled = true;
                DataTable dt = new DataTable();
                FillTablesDetails(value);

                ddlNetDetails.BeginUpdate();
                ddlNetDetails.DataSource = Net_Main_Details;
                ddlNetDetails.DisplayMember = "SubjectName";
                ddlNetDetails.ValueMember = "SubjectId";
                ddlNetDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
                ddlNetDetails.EndUpdate();
            }
            else
            {
                ddlNetDetails.BeginUpdate();
                ddlNetDetails.DataSource = null;
                ddlNetDetails.EndUpdate();
                ddlNetDetails.Enabled = false;
            }
        }

        private void ddlNetDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

      
        private void ddlPersonel_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int i = ddlPersonel.SelectedIndex;
            string value = ddlPersonel.Items[i].Value.ToString();            
            string n = ddlPersonel.Items[i].DisplayValue.ToString();
            if (value == "204")
            {
                ddlPersonelDetails.Enabled = true;
                DataTable dt = new DataTable();
                FillTablesDetails(value);

                ddlPersonelDetails.BeginUpdate();
                ddlPersonelDetails.DataSource = Personnel_Main_Details;
                ddlPersonelDetails.DisplayMember = "SubjectName";
                ddlPersonelDetails.ValueMember = "SubjectId";
                ddlPersonelDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
                ddlPersonelDetails.EndUpdate();
            }
            else
            {
                ddlPersonelDetails.BeginUpdate();
                ddlPersonelDetails.DataSource = null;
                ddlPersonelDetails.EndUpdate();
                ddlPersonelDetails.Enabled = false;
            }

        }

        private void ddlPersonelDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlAccount_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int i = ddlAccount.SelectedIndex;
            string value = ddlAccount.Items[i].Value.ToString();
            string n = ddlAccount.Items[i].DisplayValue.ToString();
            if (value == "403")
            {
                ddlAccontDetails.Enabled = true;
                DataTable dt = new DataTable();
                FillTablesDetails(value);

                ddlAccontDetails.BeginUpdate();
                ddlAccontDetails.DataSource = Account_Main_Details;
                ddlAccontDetails.DisplayMember = "SubjectName";
                ddlAccontDetails.ValueMember = "SubjectId";
                ddlAccontDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
                ddlAccontDetails.EndUpdate();
            }
            else
            {
                ddlAccontDetails.BeginUpdate();
                ddlAccontDetails.DataSource = null;
                ddlAccontDetails.EndUpdate();
                ddlAccontDetails.Enabled = false;
            }
        }

        private void ddlGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int i = ddlGroup.SelectedIndex;
            string value = ddlGroup.Items[i].Value.ToString();
            string n = ddlGroup.Items[i].DisplayValue.ToString();
            if (value == "503")
            {
                ddlGroupDetails.Enabled = true;
                DataTable dt = new DataTable();
                FillTablesDetails(value);

                ddlGroupDetails.BeginUpdate();
                ddlGroupDetails.DataSource = Group_Main_Details;
                ddlGroupDetails.DisplayMember = "SubjectName";
                ddlGroupDetails.ValueMember = "SubjectId";
                ddlGroupDetails.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
                ddlGroupDetails.EndUpdate();
            }
            else
            {
                ddlGroupDetails.BeginUpdate();
                ddlGroupDetails.DataSource = null;
                ddlGroupDetails.EndUpdate();
                ddlGroupDetails.Enabled = false;
            }
        }

        private void ddlAccontDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void ddlGroupDetails_VisualListItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Tahoma", 8);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }



}
