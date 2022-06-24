using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using Admin_Control_Panel.LtoR_Forms;
using System.ComponentModel;

namespace Admin_Control_Panel
{
    static class Program
    {
        public static List<Agents> AgentList;
        public static List<Events> EventList;
        public static List<SettingProfile> SettingProfileList;
        public static List<AlertProfile> AlertProfileDetailList;
        public static List<AlertProfile> AlertProfileHeaderList;
        public static List<frmChatAgent_RtoL> ChatBox;
        public static List<AclProfile> AclProfileList;
        public static List<AclObjectProfile> AclObjectsProfileList;
        public static List<string> ChatUserList;
        public static List<CustomReport> CustomReportList;

        public static BindingList<AgentView> dataSource;
        public static int TotalAgentRegistered;
        public static int TotalAgentAvailable;
        public static int TotalAgentUnavailable;
        public static int AgentLoadedDataCount;
        public static bool AgentViewLoadComplete;
        public static bool ReportReady;
        public static bool HasAlertIcon;
        public static List<int> AgentListIndex;


        public static string ReadKey;
        public static string WriteKey;
        public static int LangCode;
        public static bool RightToLeft;
        public static int AgentCount;
        public static string SqlConnectionString;
        public static bool IsRegister;
        public static string LockIpAddress;
        public static int MaxClientsCount;
        public static string CustomerName;
        public static string AccessDeniedMsg;
        public static string AccessDeniedToAgentMsg;

       // public static string Port;        
        public static int ChatPort;
        //public static string RDPort;  //remote desktop port
        //public static string FTPort;  //file transfer port
        //public static string VCPort;  //video conferance port
        //public static string CmdPort;
        //public static string WebinarPort;
        //public static string PublicPort;
        public static string LockSerialNumber;
        public static List<string> AutorizedAgentId;
        //public static int Seconds;

        public static DataTable tbl_item2_hardware;
        public static DataTable tbl_item2_personel;
        public static DataTable tbl_item2_software;
        public static DataTable tbl_item2_account;
        public static DataTable tbl_item2_group;
        public static DataTable tbl_item2_network;
        public static DataTable tbl_item2_event;

        public static int ErrorCode;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             string _langCode;
                string _rightToLeft;
                string _lockData = "";
                string _crc32;
            try
            {

               


                EventList = new List<Events>();
                AutorizedAgentId = new List<string>();
                AgentListIndex = new List<int>();
                SettingProfileList = new List<SettingProfile>();
                AlertProfileDetailList = new List<AlertProfile>();
                AlertProfileHeaderList = new List<AlertProfile>();
                AclProfileList = new List<AclProfile>();
                AclObjectsProfileList = new List<AclObjectProfile>();
                ChatBox = new List<frmChatAgent_RtoL>();
                ChatUserList = new List<string>();
                CustomReportList = new List<CustomReport>();
                LogicLayer layer = new LogicLayer();
                AgentViewLoadComplete = false;
              
                _langCode = layer.Decrypt(layer.GetDataFromDll("Setting", "LanguageCode", "ID = 1"), true, "");
                LangCode = Convert.ToInt32(_langCode);
              
                _rightToLeft = layer.Decrypt(layer.GetDataFromDll("Setting", "RightToleft", "ID = 1"), true, "");
               
                ReadKey = layer.Decrypt(layer.GetDataFromDll("Setting", "ReadKey", "ID = 1"), true, "");

              
                WriteKey = layer.Decrypt(layer.GetDataFromDll("Setting", "WriteKey", "ID = 1"), true, "");

              
                LockIpAddress = layer.GetDataFromDll("Setting", "LockIPAddress", "ID = 1");

         
                MaxClientsCount = Convert.ToInt32(layer.Decrypt(layer.GetDataFromDll("Setting", "ClientsCount", "ID = 1"), true, ""));

               
                CustomerName = layer.Decrypt(layer.GetDataFromDll("Setting", "CustomerName", "ID = 1"), true, "");

                AccessDeniedMsg = layer.GetMessageFromDll(_langCode, "AccessDenied");

             
                AccessDeniedToAgentMsg = layer.GetMessageFromDll(_langCode, "AccessDeniedToAgent");

          
                //Port = layer.GetDataFromDll("Setting", "Port", "ID = 1");
                //ChatPort = Convert.ToInt32(Port);
                //RDPort = layer.GetDataFromDll("Setting", "RDPort", "ID = 1");
                //FTPort = layer.GetDataFromDll("Setting", "FTPort", "ID = 1");
                //VCPort = layer.GetDataFromDll("Setting", "VCPort", "ID = 1");
                //CmdPort = layer.GetDataFromDll("Setting", "CMDPort", "ID = 1");
                //WebinarPort = layer.GetDataFromDll("Setting", "WebinarPort", "ID = 1");
                //PublicPort = layer.GetDataFromDll("Setting", "PublicPort", "ID = 1");
                //_crc32 = layer.Decrypt(layer.GetDataFromDll("Setting", "CRC32", "ID = 1"), true, "");


                USBLock usl = new USBLock();
              
                _lockData = usl.GetData();
                IsRegister = layer.IsRegister(_lockData);
                LockSerialNumber = layer.Encrypt(usl.GetLockSerial(), true, "");
                if (IsRegister == false)
                {
                    string m = layer.GetErrorMessage(1);
                    frmShowInfo_RtoL fr = new frmShowInfo_RtoL(m, 2);
                    fr.ShowDialog();
                    Environment.Exit(0);
                }
                SqlConnectionString = layer.GetSqlConnectionString(_lockData);
                if (SqlConnectionString == "")
                {
                    string m = layer.GetErrorMessage(35);
                    frmShowInfo_RtoL fr = new frmShowInfo_RtoL(m, 2);
                    fr.ShowDialog();
                    Environment.Exit(0);
                }



                AgentCount = usl.GetMaxNetworkClient();
                if (AgentCount != MaxClientsCount)
                {
                    AgentCount = 0;
                }



                /*
                if (_crc32 != layer.GetCrc32())
                {
                    AgentCount = 0;
                }
                */



                if (_rightToLeft == "1")
                    RightToLeft = true;
                else
                    RightToLeft = false;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SettingProfileList = new List<SettingProfile>();
                if (RightToLeft == true)
                    Application.Run(new frmSplash_RtoL());
                else
                    Application.Run(new frmSplash_LtoR());
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message);
                if (ex.InnerException.Message != null)
                    MessageBox.Show(ex.InnerException.Message);
            }

        }
    }
}
