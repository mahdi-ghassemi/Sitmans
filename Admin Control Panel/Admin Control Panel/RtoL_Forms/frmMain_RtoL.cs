using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmMain_RtoL : Telerik.WinControls.UI.RadForm
    {
       
        private string _langCode;
        private delegate void AddMessage(string message);
        private UdpClient receivingClient;
        private Thread receivingThread;
        
        private IPAddress ip;
        private LogicLayer lg;

        private string _alertId;
        private string _soundId;
        private string _soundFilePath;


        private Thread thrAgentListView;
        private ThreadStart thsAgentListView;

        private Thread thrCheckAgentList;
        private ThreadStart thsCheckAgentList;

        private Thread thrCheckEvent;
        private ThreadStart thsCheckEvent;

        private Thread thrTables;
        private ThreadStart thsTables;

       

        public frmMain_RtoL()
        {
            lg = new LogicLayer();
            
            InitializeComponent();         
           
        }

        private void InitializeReceiver()
        {
            receivingClient = new UdpClient(Convert.ToInt32(Program.SettingProfileList[0].PublicPort));
            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        private void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(ip, Convert.ToInt32(Program.SettingProfileList[0].PublicPort));
            AddMessage messageDelegate = MessageReceived;

            while (true)
            {
                byte[] data = receivingClient.Receive(ref endPoint);
                string message = Encoding.ASCII.GetString(data);
                Invoke(messageDelegate, message);
            }
        }

        private void MessageReceived(string message)
        {
           
            string Command;
           
            Command = message.Substring(0, 5);

            switch (Command)
            {
                case "MSGPM":
                    {
                        
                        break;
                    }
                case "MSGOP":
                    {
                        RecieveMessege(message);
                        break;
                    }
                case "DIRFA":
                    {

                        break;
                    }
                case "DIRDI":
                    {
                        RecieveDirectoryList(message);
                        break;
                    }
            }        

        }

        private void RecieveDirectoryList(string Msg)
        {
            string _msg;
            _msg = Msg.Substring(5);
            //ft.GetNodeslist(_msg);            
        }
  
        private void RecieveMessege(string Msg)
        {
            LogicLayer ll = new LogicLayer();

            if (File.Exists(Environment.CurrentDirectory + "\\AgentChat.exe"))
            {

                string _msg, _senderName, _senderIp;

                int index = Msg.IndexOf(":");
                _senderName = Msg.Substring(5, index - 5);

                int index2 = Msg.IndexOf("/");
                _senderIp = Msg.Substring((index + 1), (index2 - index - 1));

                _msg = Msg.Substring(index2 + 1);



                int indexAgent = Program.AgentList.FindIndex(Ags => Ags.ComputerName.Equals(_senderName, StringComparison.Ordinal));

                string _agentId = Program.AgentList[indexAgent].AgentID;
                string pid = Program.AgentList[indexAgent].SettingProfileId;
                int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
                string _computerName = _senderName;
                string Mssg = _msg;
                string _agentIP = _senderIp;
                string _agentPort = Program.SettingProfileList[_profileIdIndex].PublicPort;
                //string _agentPort = Program.Port;
                string _myPort = ll.GetMyPort();
                string _langCode = Convert.ToString(Program.LangCode);
                string _isPrivateChat = "Yes";
                string _isDataGetting = "No";
                string _senderUserName = "";
                string _sqlConS = ll.GetSqlConnStringForDel();

                ll.InsertChatBoxDataToDll(_agentId, _computerName, _agentIP, _agentPort, _myPort, _langCode, _isPrivateChat, _isDataGetting, Mssg, _senderUserName, _sqlConS);

                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

                Process.Start(path + "\\AgentChat.exe");

            }
            else
            {
                string msg1 = ll.GetErrorMessage(14);
                frmShowInfo_RtoL fshi = new frmShowInfo_RtoL(msg1, 2);
            }          
        }

        private void RecievePm(string Msg)
        {
            RecieveMessege(Msg);         

        }

        private void frmMain_RtoL_Load(object sender, EventArgs e)
        {
            _langCode = Convert.ToString(Program.LangCode);

            thsAgentListView = new ThreadStart(Waitting);
            thrAgentListView = new Thread(thsAgentListView);

            thsCheckAgentList = new ThreadStart(CheckAgentList);
            thrCheckAgentList = new Thread(thsCheckAgentList);

            if (Program.tbl_item2_hardware == null)
            {
                thsTables = new ThreadStart(FillTables);
                thrTables = new Thread(thsTables);
                thrTables.Start();
            }

        
            
            timSendAlert.Enabled = true;  
            string _localip = lg.LocalIPAddress();
            IPAddress ipAdd = IPAddress.Parse(_localip);
            ip = ipAdd;

            Program.ChatUserList = new List<string>();
            Program.ChatBox = new List<frmChatAgent_RtoL>();            

            InitializeReceiver();            
           

           // Use_Notify(); // Setting up all Property of Notifyicon
          

            FillForm();
            FillStatusBar();
           
            this.WindowState = FormWindowState.Maximized;
        }

        private void FillTables()
        {
            LogicLayer ll = new LogicLayer();
            //Create the data source and fill some data
            Program.tbl_item2_hardware = new DataTable();

            Program.tbl_item2_hardware.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_hardware.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_hardware.Rows.Add(101, ll.GetMessageFromDll(_langCode, "CPU"));
            Program.tbl_item2_hardware.Rows.Add(102, ll.GetMessageFromDll(_langCode, "Motherboard"));
            Program.tbl_item2_hardware.Rows.Add(103, ll.GetMessageFromDll(_langCode, "Memory"));
            Program.tbl_item2_hardware.Rows.Add(104, ll.GetMessageFromDll(_langCode, "HardDisk"));
            Program.tbl_item2_hardware.Rows.Add(105, ll.GetMessageFromDll(_langCode, "VideoCard"));
            Program.tbl_item2_hardware.Rows.Add(106, ll.GetMessageFromDll(_langCode, "Bios"));
            Program.tbl_item2_hardware.Rows.Add(107, ll.GetMessageFromDll(_langCode, "LogicDisk"));
            Program.tbl_item2_hardware.Rows.Add(108, ll.GetMessageFromDll(_langCode, "CdRom"));
            Program.tbl_item2_hardware.Rows.Add(109, ll.GetMessageFromDll(_langCode, "Chassis"));
            Program.tbl_item2_hardware.Rows.Add(110, ll.GetMessageFromDll(_langCode, "Monitor"));
            Program.tbl_item2_hardware.Rows.Add(111, ll.GetMessageFromDll(_langCode, "Keyboard"));
            Program.tbl_item2_hardware.Rows.Add(112, ll.GetMessageFromDll(_langCode, "Mouse"));
            Program.tbl_item2_hardware.Rows.Add(113, ll.GetMessageFromDll(_langCode, "Printer"));
            Program.tbl_item2_hardware.Rows.Add(114, ll.GetMessageFromDll(_langCode, "Camera"));
            Program.tbl_item2_hardware.Rows.Add(115, ll.GetMessageFromDll(_langCode, "Scanner"));
            Program.tbl_item2_hardware.Rows.Add(116, ll.GetMessageFromDll(_langCode, "Modem"));
            Program.tbl_item2_hardware.Rows.Add(117, ll.GetMessageFromDll(_langCode, "NetAdapter"));

            Program.tbl_item2_personel = new DataTable();

            Program.tbl_item2_personel.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_personel.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_personel.Rows.Add(201, ll.GetMessageFromDll(_langCode, "Firstname"));
            Program.tbl_item2_personel.Rows.Add(202, ll.GetMessageFromDll(_langCode, "Lastname"));
            Program.tbl_item2_personel.Rows.Add(203, ll.GetMessageFromDll(_langCode, "PersonelCode"));
            Program.tbl_item2_personel.Rows.Add(204, ll.GetMessageFromDll(_langCode, "Gender"));
            Program.tbl_item2_personel.Rows.Add(205, ll.GetMessageFromDll(_langCode, "InternalContact"));
            Program.tbl_item2_personel.Rows.Add(206, ll.GetMessageFromDll(_langCode, "EmailAddress"));
            Program.tbl_item2_personel.Rows.Add(207, ll.GetMessageFromDll(_langCode, "Tell"));
            Program.tbl_item2_personel.Rows.Add(208, ll.GetMessageFromDll(_langCode, "Mob"));
            Program.tbl_item2_personel.Rows.Add(209, ll.GetMessageFromDll(_langCode, "Address"));
            Program.tbl_item2_personel.Rows.Add(210, ll.GetMessageFromDll(_langCode, "JobTitle"));

            Program.tbl_item2_software = new DataTable();

            Program.tbl_item2_software.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_software.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_software.Rows.Add(301, ll.GetMessageFromDll(_langCode, "OS"));
            Program.tbl_item2_software.Rows.Add(302, ll.GetMessageFromDll(_langCode, "Application"));
            Program.tbl_item2_software.Rows.Add(303, ll.GetMessageFromDll(_langCode, "SecurityUpdate"));

            Program.tbl_item2_account = new DataTable();

            Program.tbl_item2_account.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_account.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_account.Rows.Add(401, ll.GetMessageFromDll(_langCode, "UserNameText"));
            Program.tbl_item2_account.Rows.Add(402, ll.GetMessageFromDll(_langCode, "SID"));
            Program.tbl_item2_account.Rows.Add(403, ll.GetMessageFromDll(_langCode, "Status"));
            Program.tbl_item2_account.Rows.Add(404, ll.GetMessageFromDll(_langCode, "Description"));

            Program.tbl_item2_group = new DataTable();

            Program.tbl_item2_group.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_group.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_group.Rows.Add(501, ll.GetMessageFromDll(_langCode, "UserNameText"));
            Program.tbl_item2_group.Rows.Add(502, ll.GetMessageFromDll(_langCode, "SID"));
            Program.tbl_item2_group.Rows.Add(503, ll.GetMessageFromDll(_langCode, "Status"));
            Program.tbl_item2_group.Rows.Add(504, ll.GetMessageFromDll(_langCode, "Description"));

            Program.tbl_item2_network = new DataTable();

            Program.tbl_item2_network.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_network.Columns.Add("SubjectName", typeof(string));

            Program.tbl_item2_network.Rows.Add(701, ll.GetMessageFromDll(_langCode, "IPAddress"));
            Program.tbl_item2_network.Rows.Add(702, ll.GetMessageFromDll(_langCode, "MacAddress"));
            Program.tbl_item2_network.Rows.Add(703, ll.GetMessageFromDll(_langCode, "GatewayAddress"));
            Program.tbl_item2_network.Rows.Add(704, ll.GetMessageFromDll(_langCode, "NetMask"));
            Program.tbl_item2_network.Rows.Add(705, ll.GetMessageFromDll(_langCode, "DNSAddress"));
            Program.tbl_item2_network.Rows.Add(706, ll.GetMessageFromDll(_langCode, "DHCPAddress"));
            Program.tbl_item2_network.Rows.Add(707, ll.GetMessageFromDll(_langCode, "DHCPStatus"));

            Program.tbl_item2_event = new DataTable();

            Program.tbl_item2_event.Columns.Add("SubjectId", typeof(int));
            Program.tbl_item2_event.Columns.Add("SubjectName", typeof(string));

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


        }
      
        private void FillForm()
        {            
            this.Text = lg.GetMessageFromDll(_langCode, "SoftwaresName");
            mbiAgents.Text = lg.GetMessageFromDll(_langCode, "AgentMenuText");
            mbiNetwork.Text = lg.GetMessageFromDll(_langCode, "Network");
            mbiReports.Text = lg.GetMessageFromDll(_langCode, "Reports");
            mbiConfig.Text = lg.GetMessageFromDll(_langCode, "ConfigMenuText");
            mbiOptions.Text = lg.GetMessageFromDll(_langCode, "Tools");
            mbiHelp.Text = lg.GetMessageFromDll(_langCode, "Help");
            mniAlertSetting.Text = lg.GetMessageFromDll(_langCode, "AlertProfileDefine");
            mniEventSearch.Text = lg.GetMessageFromDll(_langCode, "EventReport");
            //mniOnWorkReport.Text = lg.GetMessageFromDll(_langCode, "OnWorkReport");
            //mniDBSetting.Text = lg.GetMessageFromDll(_langCode, "tbiSql");
            //mniAccount.Text = lg.GetMessageFromDll(_langCode, "AccountManage");
            mniLocalAddress.Text = lg.GetMessageFromDll(_langCode, "LocalAddressDefine");
            mniSettingProfile.Text = lg.GetMessageFromDll(_langCode, "ProfileSettingDefine");
            mniAccessControl.Text = lg.GetMessageFromDll(_langCode, "AccessControl");
            //mniBackupRestore.Text = lg.GetMessageFromDll(_langCode, "Backup");
            //mniRequests.Text = lg.GetMessageFromDll(_langCode, "RequestReport");
            //mniSystemChanges.Text = lg.GetMessageFromDll(_langCode, "SystemChangesReport");
           // mniSystemID.Text = lg.GetMessageFromDll(_langCode, "SystemsID");
            mniUsers.Text = lg.GetMessageFromDll(_langCode, "ITmanDefine");
            //mniApplicationRun.Text = lg.GetMessageFromDll(_langCode, "ApplicationRuns");
            //mniUpdate.Text = lg.GetMessageFromDll(_langCode, "Update");

            mniSearchAll.Text = lg.GetMessageFromDll(_langCode, "Search");
            //mniHardwareRep.Text = lg.GetMessageFromDll(_langCode, "HardwaresStock");
            mniCustomReport.Text = lg.GetMessageFromDll(_langCode, "CustomReport");
            mniBackup.Text = lg.GetMessageFromDll(_langCode, "DatabaseBackup");
            mniRestore.Text = lg.GetMessageFromDll(_langCode, "DatabaseRestore");
            mniAgentUpdateSetting.Text = lg.GetMessageFromDll(_langCode, "AgentUpdateSetting");

            cmiEvents.Text = lg.GetMessageFromDll(_langCode, "NewEventsShow");

            cmiRD.Text = lg.GetMessageFromDll(_langCode, "RemoteDesktop");

            cmiCommandBox.Text = lg.GetMessageFromDll(_langCode, "ControlBox");
            cmiSendCommand.Text = lg.GetMessageFromDll(_langCode, "GetCommandPrompt");
            cmiSetting.Text = lg.GetMessageFromDll(_langCode, "Setting");
            


            cmiAlertSetting.Text = mniAlertSetting.Text;


            cmiSendCommand.Text = lg.GetMessageFromDll(_langCode, "GetCommandPrompt");
            cmiChatToAgent.Text = lg.GetMessageFromDll(_langCode, "Chat");
            cmiVC.Text = lg.GetMessageFromDll(_langCode, "VideoConf");

            //mniChatToAll.Text = lg.GetMessageFromDll(_langCode, "Chat");
            //mniVideoConf.Text = lg.GetMessageFromDll(_langCode, "VideoConf");
            mniFileTransfer.Text = lg.GetMessageFromDll(_langCode, "FileTransfer");
            mniAgentAcl.Text = lg.GetMessageFromDll(_langCode, "AgentAclManegae");
            mniObjectAcl.Text = lg.GetMessageFromDll(_langCode, "ObjectAclManegae");

        }

        private void FillStatusBar()
        {
            if (User.UserImageData != null)
            {
                Byte[] imgBytesArray = User.UserImageData;
                MemoryStream ms = new MemoryStream(imgBytesArray);
                Image img = Image.FromStream(ms);
                Image thumb = new Bitmap(img, 24, 24);

                imgUser.Image = thumb;              

            }
            else
            {
                if (User.UserTypeID == 1)
                    imgUser.Image = Properties.Resources.Administrator;
                else if (User.UserTypeID == 2)
                    imgUser.Image = Properties.Resources.Manager;
                else
                    imgUser.Image = Properties.Resources.User;
            }
            tslUser.Text = User.UserFirstName.Trim() + " " + User.UserLastName.Trim();
            tslDateTime.Text = User.LocalToday.Trim();
            tslAgentAvalaibbe.Text = lg.GetMessageFromDll(_langCode, "AvailableSystem");
            tslAgentOutOfService.Text = lg.GetMessageFromDll(_langCode, "UnAvailableSystem");
            tslAgentTotal.Text = lg.GetMessageFromDll(_langCode, "TotalSystem");
            tslAgentTot.Text = Convert.ToString(Program.TotalAgentRegistered);
            tslAgentAva.Text = Convert.ToString(Program.TotalAgentAvailable);
            tslAgentOut.Text = Convert.ToString(Program.TotalAgentUnavailable);
           // lblLoadTime.Text = Convert.ToString(Program.Seconds) + " Seconds";

        }

        private void mbiAgents_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AgentsView_RtoL"] == null)
            {
                Program.AgentViewLoadComplete = false;

                if (thrAgentListView.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    thrAgentListView.Start();
                }
                if (thrAgentListView.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    thrAgentListView = new Thread(Waitting);
                    thrAgentListView.Start();
                }

                frmAgentsView_RtoL fav = new frmAgentsView_RtoL();
                fav.Name = "AgentsView_RtoL";
                fav.Show();
                //Program.AgentViewLoadComplete = true;  
            }
            else
            {
                ((frmAgentsView_RtoL)Application.OpenForms["AgentsView_RtoL"]).BringToFront();
            }
                    

        }

        private void Waitting()
        {
            frmWaiting_RtoL frmva = new frmWaiting_RtoL(2);
            frmva.ShowDialog();
        }       
              
        private void Use_Notify()
        {
           
            MyNotify.BalloonTipText = "This is A Sample Application";
            MyNotify.BalloonTipTitle = "Your Application Name";
            MyNotify.ShowBalloonTip(1);
           
        }    
       
        private void mniHardwareAlert_Click(object sender, EventArgs e)
        {           
            frmAlertProfile_RtoL fas = new frmAlertProfile_RtoL();
            fas.Show();
        }
        
        private void mniSettingProfile_Click(object sender, System.EventArgs e)
        {
            if (lg.CheckPermission(70))
            {
                frmProfileSetting_RtoL frps = new frmProfileSetting_RtoL();
                frps.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void timSendAlert_Tick(object sender, EventArgs e)
        {
            timSendAlert.Enabled = false;
            timCheckThread.Enabled = true;
            thsCheckEvent = new ThreadStart(CheckEvents);
            thrCheckEvent = new Thread(thsCheckEvent);

            thrCheckEvent.Start();



            /*
            lg.GetEventList();
            if (Program.EventList != null)
            {
                if (Program.EventList.Count > 0)
                {
                    SendAlert();
                    Program.EventList.Clear();
                }
            }

            timSendAlert.Enabled = true;
           */
        }

        private void CheckEvents()
        {
            lg.GetEventList();
            if (Program.EventList != null)
            {
                if (Program.EventList.Count > 0)
                {
                    SendAlert();
                    Program.EventList.Clear();
                }
            }
        }

      
        private void RefreshAgentTotal()
        {
            tslAgentTot.Text = Convert.ToString(Program.TotalAgentRegistered);
            tslAgentAva.Text = Convert.ToString(Program.TotalAgentAvailable);
            tslAgentOut.Text = Convert.ToString(Program.TotalAgentUnavailable);
        }
                
        private void SendAlert()
        {
            _alertId = "";
            _soundFilePath = "";
            _soundId = "";

            if (Program.EventList != null)
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < Program.EventList.Count; i++)
                {
                    dt = lg.GetAlertId(Program.EventList[i].AgentId, Program.EventList[i].SubjectId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        _alertId = dt.Rows[0]["AlertId"].ToString();
                        _soundId = dt.Rows[0]["SoundAlert"].ToString();
                        _soundFilePath = dt.Rows[0]["SoundFilePath"].ToString();
                    }
                    switch (_alertId)
                    {
                        case "1":
                            {
                                SendDesktopAlert(i);
                                break;
                            }
                        case "2":
                            {
                                SendIconAlert(i);
                                break;
                            }
                        case "3":
                            {
                                SendIconAlert(i);
                                SendDesktopAlert(i);                                
                                break;
                            }
                        case "4":
                            {
                                SendEmailAlert(i);
                                break;
                            }
                        case "5":
                            {
                                SendDesktopAlert(i);
                                SendEmailAlert(i);
                                break;
                            }
                        case "6":
                            {
                                SendIconAlert(i);
                                SendEmailAlert(i);
                                break;
                            }
                        case "7":
                            {
                                SendDesktopAlert(i);
                                SendIconAlert(i);
                                SendEmailAlert(i);                               
                                break;
                            }
                        case "8":
                            {
                                SendSmsAlert(i);
                                break;
                            }
                        case "9":
                            {
                                SendDesktopAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "10":
                            {
                                SendIconAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "11":
                            {
                                SendDesktopAlert(i);
                                SendIconAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "12":
                            {
                                SendEmailAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "13":
                            {
                                SendDesktopAlert(i);
                                SendEmailAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "14":
                            {
                                SendIconAlert(i);
                                SendEmailAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                        case "15":
                            {
                                SendIconAlert(i);
                                SendDesktopAlert(i);
                                SendEmailAlert(i);
                                SendSmsAlert(i);
                                break;
                            }
                    }                  
                }                
            }
        }

        private void SendIconAlert(int Index)
        {
             int _levelId = Convert.ToInt32(Program.EventList[Index].LevelId);
             int AgentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);
             if (Program.AgentList[AgentIndex].AlertLevelId == null)
             {
                 Program.AgentList[AgentIndex].AlertLevelId = _levelId.ToString();
                 Program.HasAlertIcon = true;
                 if (Program.AgentListIndex.IndexOf(AgentIndex) == -1)
                 {
                     Program.AgentListIndex.Add(AgentIndex);
                 }
             }
             else 
             {
                 if (_levelId >= Convert.ToInt32(Program.AgentList[AgentIndex].AlertLevelId))
                 {
                     Program.AgentList[AgentIndex].AlertLevelId = _levelId.ToString();
                     Program.HasAlertIcon = true;
                     if (Program.AgentListIndex.IndexOf(AgentIndex) == -1)
                     {
                         Program.AgentListIndex.Add(AgentIndex);
                     }                     
                 }                     
             }            
        }
        
        private void SendEmailAlert(int Index)
        {
            
        }

        private void SendSmsAlert(int Index)
        {
           
        }

        private void SendDesktopAlert(int Index)
        {
            int _eventId = Convert.ToInt32(Program.EventList[Index].EventId);
            switch (_eventId)
            {
                case 1000:  //Cpu Change
                    {
                        ShowCpuChangeEvent(Index);
                        break;
                    }
                case 2001: //Mainboard Manufacter Change
                    {
                        ShowMainboardManufacterChangeEvent(Index);
                        break;
                    }
                case 2002: //Mainboard Product Change
                    {
                        ShowMainboardProductChangeEvent(Index);
                        break;
                    }

                case 2003: //Mainboard Version Change
                    {
                        ShowMainboardVersionChangeEvent(Index);
                        break;
                    }
                case 2004: //Mainboard SerialNumber Change
                    {
                        ShowMainboardSerialNumberChangeEvent(Index);
                        break;
                    }
                case 3001:  //Bios Vendor Change
                    {
                        ShowBiosVendorChangeEvent(Index);
                        break;
                    }
                case 3002: //Bios Start Segment Change
                    {
                        ShowBiosStartSegmentChangeEvent(Index);
                        break;
                    }
                case 3003: //Bios Version Change
                    {
                        ShowBiosVersionChangeEvent(Index);
                        break;
                    }
                case 3004: //Bios Release Date Change
                    {
                        ShowBiosReleaseDateChangeEvent(Index);
                        break;
                    }
                case 3005: //Bios Rom Size Change
                    {
                        ShowBiosRomSizeChangeEvent(Index);
                        break;
                    }
                case 4001: //New Memory Card Install
                    {
                        ShowNewMemoryCardInstallEvent(Index);
                        break;
                    }
                case 4002: //UnistallMemoryCard
                    {
                        ShowUnistallMemoryCardEvent(Index);
                        break;
                    }
                case 4003: //Memory Capacity Change
                    {
                        ShowMemoryCapacityChangeEvent(Index);
                        break;
                    }
                case 4004: //Memory Speed Change
                    {
                        ShowMemorySpeedChangeEvent(Index);
                        break;
                    }
                case 5001: //New Hard Disk Install
                    {
                        ShowNewHardDiskInstallEvent(Index);
                        break;
                    }
                case 5002: //Uninstall Hard Disk
                    {
                        ShowUninstallHardDiskEvent(Index);
                        break;
                    }
                case 5003: //Hard Disk Signature Change
                    {
                        ShowHardDiskSignatureChangeEvent(Index);
                        break;
                    }
                case 5004: //Hard Disk Size Change
                    {
                        ShowHardDiskSizeChangeEvent(Index);
                        break;
                    }
                case 5005: //Hard Disk Partitions Change
                    {
                        ShowHardDiskPartitionsChangeEvent(Index);
                        break;
                    }
                case 5006: //Hard Disk PNPDeviceID Change
                    {
                        ShowHardDiskPNPDeviceIDChangeEvent(Index);
                        break;
                    }
                case 6001: //New Logic Disk Create
                    {
                        ShowNewLogicDiskCreateEvent(Index);
                        break;
                    }
                case 6002: //Logic Disk Remove
                    {
                        ShowLogicDiskRemoveEvent(Index);
                        break;
                    }
                case 6003: //Logic Disk Description Change
                    {
                        ShowLogicDiskDescriptionChangeEvent(Index);
                        break;
                    }
                case 6004: //Logic Disk FileSystem Change
                    {
                        ShowLogicDiskFileSystemChangeEvent(Index);
                        break;
                    }
                case 6005: //Logic Disk VolumeSize Change
                    {
                        ShowLogicDiskVolumeSizeChangeEvent(Index);
                        break;
                    }
                case 6006: //Logic Disk Volume Name Change
                    {
                        ShowLogicDiskVolumeNameChangeEvent(Index);
                        break;
                    }
                case 6007: //Logic Disk Volume Serial Number Change
                    {
                        ShowLogicDiskVolumeSerialNumberChangeEvent(Index);
                        break;
                    }
                case 7001: //Video Card Driver Date Change
                    {
                        ShowVideoCardDriverDateChangeEvent(Index);
                        break;
                    }
                case 7002: //Video Card Driver Version Change
                    {
                        ShowVideoCardDriveVersionChangeEvent(Index);
                        break;
                    }
                case 7003: //Video Card Video Processor Change
                    {
                        ShowVideoCardVideoProcessorChangeEvent(Index);
                        break;
                    }
                case 7004: //Video Card Video Mode Change
                    {
                        ShowVideoCardVideoModeChangeEvent(Index);
                        break;
                    }
                case 7005: //Video Card Adapter Ram Change
                    {
                        ShowVideoCardAdapterRamChangeEvent(Index);
                        break;
                    }
                case 7006: // New Video Card Install
                    {
                        ShowNewVideoCardInstallEvent(Index);
                        break;
                    }
                case 7007: //Remove Video Card
                    {
                        ShowRemoveVideoCardEvent(Index);
                        break;
                    }
                case 8001: //New Network Adapter Install
                    {
                        ShowNewNetworkAdapterInstallEvent(Index);
                        break;
                    }
                case 8002: //Network Adapter Uninstall
                    {
                        ShowNetworkAdapterUninstallEvent(Index);
                        break;
                    }
                case 8003: //Network Adapter Type Change
                    {
                        ShowNetworkAdapterTypeChangeEvent(Index);
                        break;
                    }
                case 8004: //Network Adapter MAC Address Change
                    {
                        ShowNetworkAdapterMACAddressChangeEvent(Index);
                        break;
                    }
                case 8005: //Network Adapter Manufacturer Change
                    {
                        ShowNetworkAdapterManufacturerChangeEvent(Index);
                        break;
                    }
                case 8006: //NetworkAdapterNetConnectionIDChange
                    {
                        ShowNetworkAdapterNetConnectionIDChangeEvent(Index);
                        break;
                    }
                case 8007: //Network Adapter PNPDeviceID Change
                    {
                        ShowNetworkAdapterPNPDeviceIDChangeEvent(Index);
                        break;
                    }
                case 9000: //Keyboard Change
                    {
                        ShowKeyboardChangeEvent(Index);
                        break;
                    }
                case 10000: //Mouse Change
                    {
                        ShowMouseChangeEvent(Index);
                        break;
                    }
                case 11000: //Monitor Change
                    {
                        ShowMonitorChangeEvent(Index);
                        break;
                    }
                case 12000: //Printer Change
                    {
                        ShowPrinterChangeEvent(Index);
                        break;
                    }
                case 12001: //New Printer Install
                    {
                        ShowNewPrinterInstallEvent(Index);
                        break;
                    }
                case 12002: //Printer Uninstall
                    {
                        ShowPrinterUninstallEvent(Index);
                        break;
                    }
                case 12003: //Printer Network Change
                    {
                        ShowPrinterNetworkChangeEvent(Index);
                        break;
                    }
                case 13000: //Webcam Change
                    {
                        ShowWebcamChangeEvent(Index);
                        break;
                    }
                case 14000: //Scanner Change
                    {
                        ShowScannerChangeEvent(Index);
                        break;
                    }
                case 15001: // New CDRom Install
                    {
                        ShowNewCDRomInstallEvent(Index);
                        break;
                    }
                case 15002: //CDRom Uninstall
                    {
                        ShowCDRomUninstallEvent(Index);
                        break;
                    }
                case 15003: //CDRom Drive Change
                    {
                        ShowCDRomDriveChangeEvent(Index);
                        break;
                    }
                case 16001: //New Modem Install
                    {
                        ShowNewModemInstallEvent(Index);
                        break;
                    }
                case 16002: //Modem Uninstall 
                    {
                        ShowModemUninstallEvent(Index);
                        break;
                    }
                case 17001: //New Application Install
                    {
                        ShowNewApplicationInstallEvent(Index);
                        break;
                    }
                case 17002: //Application Uninstall
                    {
                        ShowApplicationUninstallEvent(Index);
                        break;
                    }
                case 18001: //Os Serial Number Change
                    {
                        ShowOsSerialNumberChangeEvent(Index);
                        break;
                    }
                case 18002: //Os Build Number Change
                    {
                        ShowOsBuildNumberChangeEvent(Index);
                        break;
                    }
                case 18003: //Os Caption Change
                    {
                        ShowOsCaptionChangeEvent(Index);
                        break;
                    }
                case 18004: //Os Install Date Change
                    {
                        ShowOsInstallDateChangeEvent(Index);
                        break;
                    }
                case 18005: //Os Version Change 
                    {
                        ShowOsVersionChangeEvent(Index);
                        break;
                    }
                case 19001: //New Security Updates Install
                    {
                        ShowNewSecurityUpdatesInstallEvent(Index);
                        break;
                    }
                case 19002: // Security Updates Uninstall
                    {
                        ShowSecurityUpdatesUninstallEvent(Index);
                        break;
                    }
                case 20000: //IP Address Change
                    {
                        ShowIPAddressChangeEvent(Index);
                        break;
                    }
                case 21000: //Subnet Address Change
                    {
                        ShowSubnetAddressChangeEvent(Index);
                        break;
                    }
                case 22000: //Gateway Address Change
                    {
                        ShowGatewayAddressChangeEvent(Index);
                        break;
                    }
                case 23000: //MAC Address Change
                    {
                        ShowMACAddressChangeEvent(Index);
                        break;
                    }
                case 24000: //DNS Address Change
                    {
                        ShowDNSAddressChangeEvent(Index);
                        break;
                    }
                case 25000: //DHCP Address Change
                    {
                        ShowDHCPAddressChangeEvent(Index);
                        break;
                    }
                case 25001: //DHCP Status Change
                    {
                        ShowDHCPStatusChangeEvent(Index);
                        break;
                    }
                case 26001: //Power On
                    {
                        ShowPowerOnEvent(Index);
                        break;
                    }

                case 26002: //Normal Shutdown
                    {
                        ShowNormalShutdownEvent(Index);
                        break;
                    }

                case 26003: //Power Suspend
                    {
                        ShowPowerSuspendEvent(Index);
                        break;
                    }

                case 26004: //Power Resume Suspend
                    {
                        ShowPowerResumeSuspendEvent(Index);
                        break;
                    }

                case 27001:
                    {
                        ShowUSBCoolDiskInsertEvent(Index);
                        break;
                    }

                case 27002: //Flash Disk Remove
                    {
                        ShowFlashDiskRemoveEvent(Index);
                        break;
                    }

                case 28001: //New User Account Create
                    {
                        ShowNewUserAccountCreateEvent(Index);
                        break;
                    }

                case 28002: //User Account Delete
                    {
                        ShowUserAccountDeleteEvent(Index);
                        break;
                    }

                case 28003: //User Account UserName Change
                    {
                        ShowUserAccountUserNameChangeEvent(Index);
                        break;
                    }


                case 28004: //User Account Description Change
                    {
                        ShowUserAccountDescriptionChangeEvent(Index);
                        break;
                    }

                case 28005: //User Account Status Change
                    {
                        ShowUserAccountStatusChangeEvent(Index);
                        break;
                    }

                case 29001: //New Group Account Create
                    {
                        ShowNewGroupAccountCreateEvent(Index);
                        break;
                    }

                case 29002: //Group Account Delete
                    {
                        ShowGroupAccountDeleteEvent(Index);
                        break;
                    }

                case 29003: //Group Account GroupName Change
                    {
                        ShowGroupAccountGroupNameChangeEvent(Index);
                        break;
                    }

                case 29004: //Group Account Description Change
                    {
                        ShowGroupAccountDescriptionChangeEvent(Index);
                        break;
                    }

                case 29005: //Group Account Status Cahnge
                    {
                        ShowGroupAccountStatusCahngeEvent(Index);
                        break;
                    }

                case 30001: //Chassis Asset Tag Number Change
                    {
                        ShowChassisAssetTagNumberChangeEvent(Index);
                        break;
                    }

                case 30002: //Chassis Type Change
                    {
                        ShowChassisTypeChangeEvent(Index);
                        break;
                    }

                case 31001: //Computer Name Change
                    {
                        ShowComputerNameChangeEvent(Index);
                        break;
                    }

                case 31002: //Organization Change
                    {
                        ShowOrganizationChangeEvent(Index);
                        break;
                    }
                case 31003: //Register Company Change
                    {
                        ShowRegisterCompanyChangeEvent(Index);
                        break;
                    }
                case 31004: //Register User Change
                    {
                        ShowRegisterUserChangeEvent(Index);
                        break;
                    }

                case 32000: //UUID Change
                    {
                        ShowUUIDChangeEvent(Index);
                        break;
                    }

                case 33000: //New Network Setting Install
                    {
                        ShowNewNetworkSettingInstallEvent(Index);
                        break;
                    }

                case 33001: //Network Setting Uninstall
                    {
                        ShowNetworkSettingUninstallEvent(Index);
                        break;
                    }

            }

        }

        private void ShowNetworkSettingUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);

            _captionText = lg.GetMessageFromDll(_langCode, "NetworkSettingUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "NetAdapter") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[1]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewNetworkSettingInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);            


            _captionText = lg.GetMessageFromDll(_langCode, "NewNetworkSettingInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "NetAdapter") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[1]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowUUIDChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UUIDChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowRegisterUserChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "RegisterCompanyChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowRegisterCompanyChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "RegisterCompanyChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOrganizationChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OrganizationChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowComputerNameChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ComputerNameChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowChassisTypeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ChassisTypeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowChassisAssetTagNumberChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ChassisAssetTagNumberChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[28]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowGroupAccountStatusCahngeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "GroupAccountStatusCahnge");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowGroupAccountDescriptionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "GroupAccountDescriptionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowGroupAccountGroupNameChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "GroupAccountGroupNameChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowGroupAccountDeleteEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "GroupAccountDelete");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "UserGroupName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewGroupAccountCreateEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewGroupAccountCreate");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "UserGroupName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowUserAccountStatusChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UserAccountStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowUserAccountDescriptionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UserAccountDescription");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowUserAccountUserNameChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UserAccountUserName");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowUserAccountDeleteEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UserAccountDelete");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "lblSqlUsername") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowFlashDiskRemoveEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "FlashDiskRemove");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "Model") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[0]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowPowerResumeSuspendEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PowerStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "PowerResumeSuspend") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[26]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowPowerSuspendEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PowerStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "PowerSuspend") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[26]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNormalShutdownEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PowerStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "NormalShutdown") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[26]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowPowerOnEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PowerStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "PowerOn") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[26]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowDHCPStatusChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "DHCPStatusChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[25]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowDHCPAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "DHCPAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[25]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowDNSAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "DNSAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[24]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowMACAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MACAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[23]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowGatewayAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "GatewayAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[22]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowSubnetAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "SubnetAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[21]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowIPAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "IPAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[20]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowSecurityUpdatesUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "SecurityUpdatesUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "SecurityUpdateName") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "SecurityUpdateName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[19]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewSecurityUpdatesInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewSecurityUpdatesInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "SecurityUpdateName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[19]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOsVersionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OsVersionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[18]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOsInstallDateChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OsInstallDateChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[18]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOsCaptionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OsCaptionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[18]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOsBuildNumberChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OsBuildNumberChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[18]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowOsSerialNumberChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "OsSerialNumberChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[18]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowApplicationUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ApplicationUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "SoftwareName") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "SoftwareName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[17]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewApplicationInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewApplicationInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "SoftwareName") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[17]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowModemUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ModemUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[16]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewModemInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewModemInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[16]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowCDRomDriveChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "CDRomDriveChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[15]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowCDRomUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "CDRomUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[15]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewCDRomInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewCDRomInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                          // Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[15]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowScannerChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "ScannerChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[14]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowWebcamChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "WebcamChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[13]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowPrinterNetworkChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PrinterNetworkChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[12]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowPrinterUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PrinterUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[12]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewPrinterInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewPrinterInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[12]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowPrinterChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "PrinterChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[12]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowMonitorChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MonitorChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[11]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowMouseChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MouseChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[10]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowKeyboardChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "KeyboardChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[9]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterPNPDeviceIDChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterPNPDeviceID");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterNetConnectionIDChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterNetConnectionID");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterManufacturerChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterManufacturerChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterMACAddressChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterMACAddressChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterTypeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterTypeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNetworkAdapterUninstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NetworkAdapterUninstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewNetworkAdapterInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewNetworkAdapterInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[8]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowRemoveVideoCardEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "RemoveVideoCard");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewVideoCardInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewVideoCardInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowVideoCardAdapterRamChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "VideoCardAdapterRamChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowVideoCardVideoModeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "VideoCardVideoModeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowVideoCardVideoProcessorChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "VideoCardVideoProcessorChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowVideoCardDriveVersionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "VideoCardDriveVersion");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowVideoCardDriverDateChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "VideoCardDriverDateChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[7]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskVolumeSerialNumberChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskVolumeSerialNumberChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskVolumeNameChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskVolumeName");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskVolumeSizeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskVolumeSizeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskFileSystemChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskFileSystemChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskDescriptionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskDescriptionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowLogicDiskRemoveEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "LogicDiskRemove");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           //Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewLogicDiskCreateEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewLogicDiskCreate");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           //Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[6]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowHardDiskPNPDeviceIDChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "HardDiskPNPDeviceID");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowHardDiskPartitionsChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "HardDiskPartitions");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowHardDiskSizeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "HardDiskSizeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowHardDiskSignatureChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "HardDiskSignatureChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowUninstallHardDiskEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UninstallHardDisk");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }
            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewHardDiskInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewHardDiskInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +                          
                           Program.EventList[Index].CurrentValue  + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[5]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMemorySpeedChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MemorySpeedChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[4]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMemoryCapacityChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MemoryCapacityChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[4]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowUnistallMemoryCardEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "UnistallMemoryCard");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[4]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowNewMemoryCardInstallEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewMemoryCardInstall");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[4]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowBiosRomSizeChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "BiosRomSizeChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[3]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowBiosReleaseDateChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "BiosReleaseDateChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[3]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowBiosVersionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "BiosVersionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[3]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowBiosVendorChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "BiosVendorChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[3]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }
        
        private void ShowBiosStartSegmentChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "BiosStartSegmentChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[3]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMainboardSerialNumberChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MainboardSerialNumberChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[2]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMainboardVersionChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MainboardVersionChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[2]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMainboardProductChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MainboardProductChange");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[2]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowMainboardManufacterChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "MainboardChangeEvent");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].LastValue + " : " + lg.GetMessageFromDll(_langCode, "LastValue") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "CurrentValue") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[2]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }

        private void ShowCpuChangeEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "CpuCahngeEvent");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "Model") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[1]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);
        }     

        private void ShowUSBCoolDiskInsertEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);         
           

            _captionText = lg.GetMessageFromDll(_langCode, "USBCoolDiskInsert");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "Model") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");
           

            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[0]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone; 
                
                player.Play();
            }
            
            lg.UpdateShownInEvent(Index);
           
        }

        private void ShowNewUserAccountCreateEvent(int Index)
        {
            string _captionText;
            string _contentText;
            int agentIndex = Program.AgentList.FindIndex(item => item.AgentID == Program.EventList[Index].AgentId);


            _captionText = lg.GetMessageFromDll(_langCode, "NewUserAccountCreate");
            _contentText = Program.AgentList[agentIndex].ComputerName + " : " + lg.GetMessageFromDll(_langCode, "System") + "\n" +
                           Program.EventList[Index].CurrentValue + " : " + lg.GetMessageFromDll(_langCode, "lblSqlUsername") + "\n" +
                           Program.EventList[Index].Date + " : " + lg.GetMessageFromDll(_langCode, "EventDate") + "\n" +
                           Program.EventList[Index].Time + " : " + lg.GetMessageFromDll(_langCode, "EventTime");


            DesktopAlertSetup(_captionText, _contentText, imlAlert.Images[27]);

            if (_soundId == "1")
            {
                SoundPlayer player = new SoundPlayer();
                if (_soundFilePath != "")
                {
                    player.SoundLocation = _soundFilePath;
                }
                else
                    player.Stream = Properties.Resources.variometer_tone;

                player.Play();
            }

            lg.UpdateShownInEvent(Index);

        }
        
        private void DesktopAlertSetup(string Caption,string Content,Image ContentImage)
        {
            this.DesktopAlert1.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = new Font("Tahoma", 9, FontStyle.Regular);
            this.DesktopAlert1.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextAlignment = ContentAlignment.MiddleCenter;
            this.DesktopAlert1.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.Red;
            DesktopAlert1.AutoClose = false;
            DesktopAlert1.CaptionText = Caption;
            string ctext = "<html><size=9><font=tahoma>" + Content;
            DesktopAlert1.ContentText = ctext;
            DesktopAlert1.ContentImage = ContentImage;
            this.Invoke((MethodInvoker)delegate { DesktopAlert1.Show(); });
            //DesktopAlert1.Show();
        }       

        private void mniFileTransfer_Click(object sender, EventArgs e)
        {
            string SqlConString, lanC, serverPort, agentPort;

            LogicLayer ll = new LogicLayer();
            SqlConString = ll.GetSqlConnStringForDel();
            lanC = Program.LangCode.ToString();

            serverPort = Program.SettingProfileList[0].FTPort; 

            //serverPort = Program.FTPort;
            agentPort = Program.SettingProfileList[0].PublicPort;

            if (File.Exists(Environment.CurrentDirectory + "\\FileTransfer.exe"))
            {

                ll.InsertFileTransferDataToDll(SqlConString, lanC, serverPort, agentPort);
                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                Process.Start(path + "\\FileTransfer.exe");

            }
            else
            {
                string msg1 = ll.GetErrorMessage(17);
                frmShowInfo_RtoL fshi = new frmShowInfo_RtoL(msg1, 2);
            }
        }

        private void mniChatToAll_Click(object sender, EventArgs e)
        {

        }

        private void mniEventSearch_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(64))
            {
                frmSelectAgent_RtoL fse = new frmSelectAgent_RtoL("AllEventReport");
                fse.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void mniLocalAddress_Click(object sender, EventArgs e)
        {
            frmBulding_RtoL fb = new frmBulding_RtoL();
            fb.Show();
        }       

        private void mniAlertSetting_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(66))
            {
                frmAlertProfile_RtoL fams = new frmAlertProfile_RtoL();
                fams.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }       

        private void mbiNetwork_Click(object sender, EventArgs e)
        {
           
        }

        private void timPing_Tick(object sender, EventArgs e)
        {
            timPing.Enabled = false;

        }

      
        private void mniUsers_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(50))
            {
                frmUser_RtoL frmus = new frmUser_RtoL();
                frmus.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void frmMain_RtoL_Shown(object sender, EventArgs e)
        {
            if (Program.AgentLoadedDataCount < Program.TotalAgentRegistered)
            {
                frmWaiting_RtoL frmw = new frmWaiting_RtoL(1);
                frmw.ShowDialog();
            }
        }

        private void timUpdateStatusbar_Tick(object sender, EventArgs e)
        {
            if (User.UserImageDataChange)
            {
                if (User.UserImageData != null)
                {
                    Byte[] imgBytesArray = User.UserImageData;
                    MemoryStream ms = new MemoryStream(imgBytesArray);
                    Image img = Image.FromStream(ms);
                    Image thumb = new Bitmap(img, 24, 24);

                    imgUser.Image = thumb;

                }
                else
                {
                    if (User.UserTypeID == 1)
                        imgUser.Image = Properties.Resources.Administrator;
                    else if (User.UserTypeID == 2)
                        imgUser.Image = Properties.Resources.Manager;
                    else
                        imgUser.Image = Properties.Resources.User;
                }

                User.UserImageDataChange = false;
            }
           
            tslUser.Text = User.UserFirstName.Trim() + " " + User.UserLastName.Trim();
            tslDateTime.Text = User.LocalToday.Trim();           
            tslAgentTot.Text = Convert.ToString(Program.TotalAgentRegistered);
            tslAgentAva.Text = Convert.ToString(Program.TotalAgentAvailable);
            tslAgentOut.Text = Convert.ToString(Program.TotalAgentUnavailable);
           // lblLoadTime.Text = Convert.ToString(Program.Seconds) + " Seconds";

        }

        private void timCheckAgentList_Tick(object sender, EventArgs e)
        {
            thrCheckAgentList = new Thread(CheckAgentList);
            thrCheckAgentList.Start();
        }

        private void CheckAgentList()
        {
            lg.CheckAgentList();
        }

        private void mniOnWorkReport_Click(object sender, EventArgs e)
        {
            frmSelectAgent_RtoL fse = new frmSelectAgent_RtoL("OnWorkReport");
            fse.Show();
        }

        private void frmMain_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {           
            LogicLayer logl = new LogicLayer();
            Encrypter enc = new Encrypter();

            string pid,dataToSend;
            int pindex;
            int indexOnAturizeList;
            dataToSend = enc.Encrypt("LOGOT");
            foreach (Agents ag in Program.AgentList)
            {
                indexOnAturizeList = Program.AutorizedAgentId.IndexOf(ag.AgentID);
                if (indexOnAturizeList != -1)
                {
                    if (ag.Status == "On" || ag.Status == "Idle" || ag.Status == "StandBy")
                    {
                        pid = ag.SettingProfileId;
                        pindex = Program.SettingProfileList.FindIndex(a => a.ProfileId == pid);
                        logl.LogoutFromRemoteAgent(dataToSend, pindex, ag.AgentMainIndex);
                    }
                }
            }
        }

        private void timCheckThread_Tick(object sender, EventArgs e)
        {
            if (thrCheckEvent.IsAlive == false)
            {
                timSendAlert.Enabled = true;
            }
            else
            {
                timSendAlert.Enabled = false;
            }
        }

        private void mniHardwareRep_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(60))
            {
                frmSearchAll_RtoL frmsall = new frmSearchAll_RtoL();
                frmsall.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void mniSystemID_Click(object sender, EventArgs e)
        {
            frmSelectAgentForId_RtoL fsafi = new frmSelectAgentForId_RtoL();
            fsafi.Show();
        }

        private void mniAgentAcl_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(55))
            {
                frmACLProfile_RtoL frmacl = new frmACLProfile_RtoL();
                frmacl.Show();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void mniObjectAcl_Click(object sender, EventArgs e)
        {
            frmACLToObjectsProfile_RtoL frmaclobject = new frmACLToObjectsProfile_RtoL();
            frmaclobject.Show();
        }

        private void mniRestore_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(49))
            {
                frmRestoreDatabase_RtoL frmrestoredb = new frmRestoreDatabase_RtoL();
                frmrestoredb.ShowDialog();                
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void mniAgentUpdateSetting_Click(object sender, EventArgs e)
        {

        }

        private void mniBackup_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(48))
            {
                frmBackupDatabase_RtoL frmbackupdb = new frmBackupDatabase_RtoL();
                frmbackupdb.ShowDialog();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        
    }
}
