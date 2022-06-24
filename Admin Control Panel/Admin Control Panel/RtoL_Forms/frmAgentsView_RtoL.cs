using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Data;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Layouts;
using System.Diagnostics;
using System.Threading;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentsView_RtoL : Telerik.WinControls.UI.RadForm
    {
        private const string ObjectName = "livAgentList";
        private LogicLayer lg;
        private string _langCode;

       
        private Agents _selectedAgent;
        private string[] _idGridOrder;
        private List<int> _columnsMoved = new List<int>();
        private string[] _columns;
        private string _PersonnelName;
        private string _ComputerName;
        private string _Alias;
        private string _Status;

        private Thread thrNewEventShow;
        private ThreadStart thsNewEventShow;

        private Thread thrWaitting;
        private ThreadStart thsWaitting;

        public frmAgentsView_RtoL()
        {         
            
            lg = new LogicLayer();
            _langCode = Program.LangCode.ToString();
                       

            imlPerssonel = new System.Windows.Forms.ImageList();
            imlPerssonel.ImageSize = new System.Drawing.Size(100, 100);
            imlPerssonel.ColorDepth = ColorDepth.Depth32Bit;       
           

            imlLargeImage = new System.Windows.Forms.ImageList();
            imlLargeImage.ImageSize = new System.Drawing.Size(48, 48);
            imlLargeImage.ColorDepth = ColorDepth.Depth32Bit;
            imlLargeImage.Images.Add("Desktop", Properties.Resources.Desktop);
            imlLargeImage.Images.Add("Labtop", Properties.Resources.Laptop);

            imlAlert = new System.Windows.Forms.ImageList();
            imlAlert.ImageSize = new System.Drawing.Size(24, 24);
            imlAlert.ColorDepth = ColorDepth.Depth32Bit;
           

            //SetIconAlert();
                  
            InitializeComponent();
            
        }

        private void SetIconAlert()
        {
            if (Program.HasAlertIcon == true)
            {
                if (Program.AgentListIndex != null)
                {
                    if (Program.AgentListIndex.Count > 0)
                    {
                        string _info = lg.GetMessageFromDll(_langCode, "Information");
                        string _warning = lg.GetMessageFromDll(_langCode, "Warning");

                        for (int i = 0; i < Program.AgentListIndex.Count; i++)
                        {
                            if (Program.AgentList[Program.AgentListIndex[i]].AlertLevelId == "1")
                            {
                                Program.dataSource[Program.AgentListIndex[i]].AlertImageIcon = imlAlert.Images["YelloAlert"];
                                Program.dataSource[Program.AgentListIndex[i]].Alert = _info;
                            }
                            if (Program.AgentList[Program.AgentListIndex[i]].AlertLevelId == "2")
                            {
                                Program.dataSource[Program.AgentListIndex[i]].AlertImageIcon = imlAlert.Images["RedAlert"];
                                Program.dataSource[Program.AgentListIndex[i]].Alert = _warning;
                            }
                            if (Program.AgentList[Program.AgentListIndex[i]].AlertLevelId == "3")
                            {
                                Program.dataSource[Program.AgentListIndex[i]].AlertImageIcon = imlAlert.Images["RedAlert"];
                                Program.dataSource[Program.AgentListIndex[i]].Alert = _warning;
                            }
                            if (Program.AgentList[Program.AgentListIndex[i]].AlertLevelId == "4")
                            {
                                Program.dataSource[Program.AgentListIndex[i]].AlertImageIcon = imlAlert.Images["RedAlert"];
                                Program.dataSource[Program.AgentListIndex[i]].Alert = _warning;
                            }
                        }

                        Program.AgentListIndex.Clear();
                        Program.HasAlertIcon = false;
                    }
                }
            }
        }            
        
        private void cmiChatToAgent_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl13)
            {
                LogicLayer ll = new LogicLayer();
                if (File.Exists(Environment.CurrentDirectory + "\\AgentChat.exe"))
                {


                    string _agentId = _selectedAgent.AgentID;
                    string _computerName = _selectedAgent.ComputerName;
                    string _agentIP = Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP;

                    string pid = _selectedAgent.SettingProfileId;
                    int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
                    string _agentPort = Program.SettingProfileList[_profileIdIndex].ChatPort;


                    //string _agentPort = Program.Port;
                    string _myPort = ll.GetMyPort();
                    string _langCode = Convert.ToString(Program.LangCode);
                    string _isPrivateChat = "Yes";
                    string _isDataGetting = "No";
                    string _Msg = "";
                    string _senderUserName = User.UserFirstName.Trim() + " " + User.UserLastName.Trim();
                    string _sqlConS = ll.GetSqlConnStringForDel();


                    ll.InsertChatBoxDataToDll(_agentId, _computerName, _agentIP, _agentPort, _myPort, _langCode, _isPrivateChat, _isDataGetting, _Msg, _senderUserName, _sqlConS);

                    string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

                    Process.Start(path + "\\AgentChat.exe");
                }
                else
                {
                    string msg1 = ll.GetErrorMessage(14);
                    frmShowInfo_RtoL fshi = new frmShowInfo_RtoL(msg1, 2);
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }
        
        private void cmiEvents_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl15)
            {

                thsWaitting = new ThreadStart(Waitting);
                thrWaitting = new Thread(thsWaitting);

                thsNewEventShow = new ThreadStart(ShowLastEventReport);
                thrNewEventShow = new Thread(thsNewEventShow);

                thrNewEventShow.Start();

                if (thrNewEventShow.IsAlive == true)
                {
                    timReportCheck.Enabled = true;
                    Program.ReportReady = false;
                    thrWaitting.Start();
                }


                Program.dataSource[_selectedAgent.AgentMainIndex].AlertImageIcon = imlAlert.Images["Ok"];
                Program.dataSource[_selectedAgent.AgentMainIndex].Alert = lg.GetMessageFromDll(_langCode, "Normal");
                Program.AgentListIndex.Remove(_selectedAgent.AgentMainIndex);
            }

            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
            
        }

        private void Waitting()
        {
            frmWaiting_RtoL frmva = new frmWaiting_RtoL(3);
            frmva.ShowDialog();
        }       


        private void ShowLastEventReport()
        {
            frmRepShowLastEvent_RtoL fr = new frmRepShowLastEvent_RtoL(_selectedAgent);
            fr.ShowDialog();
        }
        
        private void cmiVC_Click(object sender, EventArgs e)
        {
            int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

            if (index >= 0)
            {
                DoVideoConference();
            }
            else
            {
                DoLoginToAgent("VC");
            }
        }
             
        private void DoRemoteDesktop()
        {
            string agIP, lanC, myp, agentPort, agName;

            LogicLayer ll = new LogicLayer();

            lanC = Program.LangCode.ToString();
            myp = ll.GetMyPort();

            string pid = _selectedAgent.SettingProfileId;
            int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
            agentPort = Program.SettingProfileList[_profileIdIndex].RDPort; 

            //agentPort = Program.RDPort;

            agIP = Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP;

            agName = _selectedAgent.ComputerName;

            if (File.Exists(Environment.CurrentDirectory + "\\RemoteDesktop.exe"))
            {

                ll.InsertRemoteDesktopDataToDll(agentPort, agIP, agName, myp, lanC);
                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                Process.Start(path + "\\RemoteDesktop.exe");

            }
            else
            {
                string msg1 = ll.GetErrorMessage(15);
                frmShowInfo_RtoL fshi = new frmShowInfo_RtoL(msg1, 2);
            }
        }
        
        private void DoVideoConference()
        {

        }

            
        private void DoLoginToAgent(string Caller)
        {
            frmLoginToAgent_RtoL flta = new frmLoginToAgent_RtoL(_selectedAgent,Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
            DialogResult dr = flta.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                switch(Caller)
                {
                    case "RD":
                        DoRemoteDesktop();
                        break;
                    case "VC":
                        DoVideoConference();
                        break;
                    case "CMD":
                        DoCmd();
                        break;                  
                    case "CDOPN":
                        DoOpenCD();
                        break;
                    case "MONON":
                        DoMonitorOn();
                        break;
                    case "MONOFF":
                        DoMonitorOff();
                        break;
                    case "RESET":
                        DoRestart();
                        break;
                    case "SHUTDOWN":
                        DoShutdown();
                        break;
                    case "CDCLS":
                        DoCloseCD();
                        break;
                }                
            }
        }

        private void cmiRD_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl3)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoRemoteDesktop();
                }
                else
                {
                    DoLoginToAgent("RD");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiSetting_Click(object sender, EventArgs e)
        {
            List<Agents> _aglist = new List<Agents>();
            _aglist.Add(_selectedAgent);
            frmAssignSetting_RtoL frmas = new frmAssignSetting_RtoL(_aglist);
            frmas.Show();
        }

        private void DoCmd()
        {
            string agIP, lanC, myp, agentPort, agName, sqls, agId;

            LogicLayer ll = new LogicLayer();

            lanC = Program.LangCode.ToString();
            myp = ll.GetMyPort();

            string pid = _selectedAgent.SettingProfileId;
            int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
            agentPort = Program.SettingProfileList[_profileIdIndex].CommandPort; 

            
            //agentPort = Program.CmdPort;

            agIP = Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP;

            agName = Program.dataSource[_selectedAgent.AgentMainIndex].ComputerName;
            agId = Program.dataSource[_selectedAgent.AgentMainIndex].AgentId;

            sqls = ll.GetSqlConnStringForDel();

            if (File.Exists(Environment.CurrentDirectory + "\\AgentCmd.exe"))
            {

                ll.InsertAgentCmdDataToDll(myp, agIP, sqls, agName, agentPort, lanC, agId);
                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                Process.Start(path + "\\AgentCmd.exe");

            }
            else
            {
                string msg1 = ll.GetErrorMessage(16);
                frmShowInfo_RtoL fshi = new frmShowInfo_RtoL(msg1, 2);
            }
        }

        private void cmiSendCommand_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl12)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoCmd();
                }
                else
                {
                    DoLoginToAgent("CMD");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void mniList_Click(object sender, EventArgs e)
        {
            mniList.ToggleState = ToggleState.On;
            mniIcon.ToggleState = ToggleState.Off;
            mniDetails.ToggleState = ToggleState.Off;
            livAgentList.ViewType = ListViewType.ListView;
        }

        private void mniIcon_Click(object sender, EventArgs e)
        {
            mniList.ToggleState = ToggleState.Off;
            mniIcon.ToggleState = ToggleState.On;
            mniDetails.ToggleState = ToggleState.Off;
            livAgentList.ViewType = ListViewType.IconsView;
        }

        private void mniDetails_Click(object sender, EventArgs e)
        {
            mniList.ToggleState = ToggleState.Off;
            mniIcon.ToggleState = ToggleState.Off;
            mniDetails.ToggleState = ToggleState.On;
            livAgentList.ViewType = ListViewType.DetailsView;
        }     

        private void FillDataSource()
        {            
            string AgentId = "";
            int AgentListIndex = 0;
            string ComputerName= "";
            string Status = "";
            Image UserImage = null;
            string UserFullName = "";
            Image AlertImageIcon = null;
            Image AgentSystemType = null;
            string AgentIP = "";
            string Room = "";
            string Buildding = "";
            string Department = "";
            string Class = "";
            string IdleTime = "";
            string Alias = "";
            string SettingProfileName = "";
            string AlertProfileName = "";
            string CurrentApplication = "";
            string Alert = "";
            string SystemType = "";
            
            imlPerssonel.Images.Add("UnKnown", Properties.Resources.unknown);
            imlLargeImage.Images.Add("Desktop", Properties.Resources.Desktop);
            imlLargeImage.Images.Add("Labtop", Properties.Resources.Laptop);
            imlAlert.Images.Add("RedAlert", Properties.Resources.RedWarning);
            imlAlert.Images.Add("YelloAlert", Properties.Resources.YelloWarning);
            imlAlert.Images.Add("Ok", Properties.Resources.ActionSuccess);


            foreach (Agents agent in Program.AgentList)
            {

                if (agent.acl1 <= User.UserClassifyID)
                {
                    AgentId = agent.AgentID;
                    AgentListIndex = agent.AgentMainIndex;
                    ComputerName = agent.ComputerName;
                    Status = agent.Status;
                    SystemType = agent.AgentType;
                    if (agent.PersonnelImage != null)
                    {
                        imlPerssonel.Images.Add(agent.AgentID, agent.PersonnelImage);
                        UserImage = imlPerssonel.Images[agent.AgentID];
                    }
                    else
                    {
                        UserImage = imlPerssonel.Images["UnKnown"];
                    }

                    if (agent.AgentType == "Labtop" || agent.AgentType == "Notebook" || agent.AgentType == "Portable")
                    {
                        AgentSystemType = imlLargeImage.Images["Labtop"];

                    }
                    else
                    {
                        AgentSystemType = imlLargeImage.Images["Desktop"];
                    }

                    if (agent.AlertLevelId != null)
                    {
                        if (agent.AlertLevelId == "1")
                        {
                            AlertImageIcon = imlAlert.Images["YelloAlert"];
                            Alert = lg.GetMessageFromDll(_langCode, "Information");
                        }
                        if (agent.AlertLevelId == "2")
                        {
                            AlertImageIcon = imlAlert.Images["RedAlert"];
                            Alert = lg.GetMessageFromDll(_langCode, "Warning");
                        }
                        if (agent.AlertLevelId == "3")
                        {
                            AlertImageIcon = imlAlert.Images["RedAlert"];
                            Alert = lg.GetMessageFromDll(_langCode, "Warning");
                        }
                        if (agent.AlertLevelId == "4")
                        {
                            AlertImageIcon = imlAlert.Images["RedAlert"];
                            Alert = lg.GetMessageFromDll(_langCode, "Warning");
                        }
                    }
                    else
                    {
                        AlertImageIcon = imlAlert.Images["Ok"];
                        Alert = lg.GetMessageFromDll(_langCode, "Normal");
                    }

                    //AgentIP = lg.GetActiveIPV4(agent);
                    AgentIP = "192.168.1.1";
                    IdleTime = agent.IdleDuration;
                    Room = agent.RoomTitle;
                    Buildding = agent.BuildingTitle;
                    Department = agent.DepartmentTitle;
                    Class = agent.ClassTitle;
                    Alias = agent.Alias;
                    if (agent.PersonnelFName != null)
                        UserFullName = agent.PersonnelFName.Trim() + " " + agent.PersonnelLName.Trim();
                    else
                        UserFullName = "";
                    SettingProfileName = agent.SettingProfileName.Trim();
                    AlertProfileName = agent.AlertProfileName.Trim();

                    //dataSource.Add(new AgentView(AgentId, AgentListIndex, ComputerName, UserFullName, Alert, Status, UserImage, AlertImageIcon, AgentSystemType,
                     //                    AgentIP, Room, Buildding, Department, Class, IdleTime, Alias, SettingProfileName, AlertProfileName, SystemType));

                }
            }
            
            
        }

        private void livAgentList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            e.Item.Image = ((AgentView)e.Item.DataBoundItem).UserImage;
        }

        private void livAgentList_ViewTypeChanged(object sender, EventArgs e)
        {
            switch (livAgentList.ViewType)
            {
                case ListViewType.ListView:
                    SetupSimpleListView();
                    break;
                case ListViewType.IconsView:
                    SetupIconsView();
                    break;
                case ListViewType.DetailsView:
                    SetupDetailsView();
                    break;
            }
        }

        private void SetupDetailsView()
        {
            //ColumnReorder();
           // SetNewColumnIndex();
            this.livAgentList.AllowArbitraryItemHeight = true;
        }

        private void SetNewColumnIndex()
        {
            _columns = new string[livAgentList.Columns.Count];
            for (int i = 0; i < livAgentList.Columns.Count; i++)
            {
                _columns[i] = livAgentList.Columns[i].Name;
            }

           // = new string[] {"AgentId", "AgentListIndex", "ComputerName", "Status", "UserImage", "UserFullName",
            //                                     "AlertImageIcon","AgentSystemType","AgentIP","Room","Buildding","Department","Class",
            //                                     "IdleTime","Alias","SettingProfileName","AlertProfileName","Alert","SystemType"}; 
        }

        private void SetupIconsView()
        {
            this.livAgentList.ItemSize = new Size(200, 64);
            this.livAgentList.ItemSpacing = 5;
            this.livAgentList.AllowArbitraryItemHeight = true;
        }

        private void SetupSimpleListView()
        {
            this.livAgentList.AllowArbitraryItemHeight = true;
        }

        private void livAgentList_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            if (e.VisualItem.Data.Image != null)
            {
                e.VisualItem.Image = e.VisualItem.Data.Image.GetThumbnailImage(64, 64, null, IntPtr.Zero);
                e.VisualItem.Layout.RightPart.Margin = new Padding(2, 0, 0, 0);
            }



            if (this.livAgentList.ViewType == ListViewType.IconsView && e.VisualItem.Data.DataBoundItem != null)
            {
                _PersonnelName = ((AgentView)e.VisualItem.Data.DataBoundItem).UserFullName;
                _ComputerName = ((AgentView)e.VisualItem.Data.DataBoundItem).ComputerName;
                _Alias = ((AgentView)e.VisualItem.Data.DataBoundItem).Alias;

                _Status = ((AgentView)e.VisualItem.Data.DataBoundItem).Status;
                e.VisualItem.Text = "<html>" + "<br><span style=\"color:#000080\">" + _PersonnelName + "<br><span style=\"color:#999999\">" + _ComputerName + "<br><span style=\"color:#8B0000\">" + _Alias + "</span>";
            
                e.VisualItem.ImageLayout = ImageLayout.Center;
                e.VisualItem.ImageAlignment = ContentAlignment.MiddleCenter;              
            }
            


            if (this.livAgentList.ViewType == ListViewType.ListView && e.VisualItem.Data.DataBoundItem != null)
            {
                _PersonnelName = ((AgentView)e.VisualItem.Data.DataBoundItem).UserFullName;
                _ComputerName = ((AgentView)e.VisualItem.Data.DataBoundItem).ComputerName;
                _Alias = ((AgentView)e.VisualItem.Data.DataBoundItem).Alias;

                _Status = ((AgentView)e.VisualItem.Data.DataBoundItem).Status;
                e.VisualItem.Text = "<html>" + "<br><span style=\"color:#000080\">" + _PersonnelName + "<br><span style=\"color:#999999\">" + _ComputerName + "<br><span style=\"color:#8B0000\">" + _Alias + "</span>";              
            }
            
        }

        private void livAgentList_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {            
            if (this.livAgentList.ViewType == ListViewType.ListView && !(e.VisualItem is BaseListViewGroupVisualItem))
            {
                e.VisualItem = new AgentsListVisualItem();
            }
            if (this.livAgentList.ViewType == ListViewType.IconsView && !(e.VisualItem is BaseListViewGroupVisualItem))
            {
                e.VisualItem = new AgentsIconVisualItem();
            }
            
        }

        private void frmAgentsView_RtoL_Load(object sender, EventArgs e)
        {
            imlPerssonel.Images.Add("UnKnown", Properties.Resources.unknown);
            imlAlert.Images.Add("RedAlert", Properties.Resources.RedWarning);
            imlAlert.Images.Add("YelloAlert", Properties.Resources.YelloWarning);
            imlAlert.Images.Add("Ok", Properties.Resources.ActionSuccess);
            SetIconAlert();
            FillForm();
            FillDropDownList();
            SetListView();
            SetAgentVisibility();
            //Program.AgentViewLoadComplete = true;
        }

        private void SetListView()
        {

            this.livAgentList.AllowEdit = false;
            this.livAgentList.AllowRemove = false;
            this.livAgentList.ShowCheckBoxes = true;
            this.livAgentList.AllowColumnReorder = true;
            this.livAgentList.Items.BeginUpdate();
            this.livAgentList.DataSource = Program.dataSource;
            this.livAgentList.DisplayMember = "ComputerName";
            this.livAgentList.ValueMember = "AgentId";
            this.livAgentList.Items.EndUpdate();

            this.livAgentList.ViewType = ListViewType.IconsView;

            this.mniDetails.Click += new EventHandler(mniDetails_Click);
            this.mniIcon.Click += new EventHandler(mniIcon_Click);
            this.mniList.Click += new EventHandler(mniList_Click);
            this.cmiSendCommand.Click += new EventHandler(cmiSendCommand_Click);
            this.cmiChatToAgent.Click += new EventHandler(cmiChatToAgent_Click);
            this.cmiRD.Click += new EventHandler(cmiRD_Click);
            this.cmiVC.Click += new EventHandler(cmiVC_Click);
            this.cmiEvents.Click += new EventHandler(cmiEvents_Click);
            this.cmiSettingAssign.Click += new EventHandler(cmiSetting_Click);
            this.cmiAlertAssign.Click += new EventHandler(cmiAlertAssign_Click);
            this.cmiShutdown.Click += new EventHandler(cmiShutdown_Click);
            this.cmiRestart.Click += new EventHandler(cmiRestart_Click);
            this.cmiMonitorOff.Click += new EventHandler(cmiMonitorOff_Click);
            this.cmiMonitorOn.Click += new EventHandler(cmiMonitorOn_Click);
            this.cmiOpenCD.Click += new EventHandler(cmiOpenCD_Click);
            this.cmiCloseCD.Click += new EventHandler(cmiCloseCD_Click);


        }

        private void SetAgentVisibility()
        {
            int _count = this.livAgentList.Items.Count;
            this.livAgentList.Items.BeginUpdate();
            for (int i = 0; i < _count; i++)
            {
                if (User.UserClassifyID < Program.AgentList[i].acl24)
                    this.livAgentList.Items[i].Visible = false;
            }
            this.livAgentList.Items.EndUpdate();
        }


        void cmiCloseCD_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoCloseCD();
                }
                else
                {
                    DoLoginToAgent("CDCLS");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiOpenCD_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoOpenCD();
                }
                else
                {
                    DoLoginToAgent("CDOPN");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiMonitorOn_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoMonitorOn();
                }
                else
                {
                    DoLoginToAgent("MONON");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiMonitorOff_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoMonitorOff();
                }
                else
                {
                    DoLoginToAgent("MONOFF");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }

        }

        private void cmiRestart_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoRestart();
                }
                else
                {
                    DoLoginToAgent("RESET");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiShutdown_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                int index = Program.AutorizedAgentId.IndexOf(_selectedAgent.AgentID);

                if (index >= 0)
                {
                    DoShutdown();
                }
                else
                {
                    DoLoginToAgent("SHUTDOWN");
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void DoCloseCD()
        {
            SendCommand("CDCLZ", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
        }

        private void DoOpenCD()
        {
            SendCommand("CDOPN", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
        }

        private void DoMonitorOn()
        {
            SendCommand("MONON", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
        }

        private void DoMonitorOff()
        {
            SendCommand("MONOF", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
        }

        private void DoRestart()
        {
            SendCommand("SYSRE", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);
        }

        private void DoShutdown()
        {
            SendCommand("SYSOF", Program.dataSource[_selectedAgent.AgentMainIndex].AgentIP);          
        }

        private void SendCommand(string Command,string AgentIP)
        {
            if (User.UserClassifyID >= _selectedAgent.acl14)
            {
                Com cm = new Com();
                Encrypter enc = new Encrypter();
                cm.DestiniIp = AgentIP;

                string pid = _selectedAgent.SettingProfileId;
                int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
                cm.DestiniPort = Program.SettingProfileList[_profileIdIndex].PublicPort;

                cm.SockType = "Tcp";
                string data = enc.Encrypt(Command);
                cm.SendData(data);
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void cmiAlertAssign_Click(object sender, EventArgs e)
        {
            List<Agents> _aglist = new List<Agents>();
            _aglist.Add(_selectedAgent);
            frmAssignAlarm_RtoL fraa = new frmAssignAlarm_RtoL(_aglist);
            fraa.Show();
        }

                  

        private void ColumnReorder()
        {
            DataTable dt = new DataTable();
            int _oldIndex;
            int _newIndex;

            dt = lg.GetGridOrder(User.UserID.ToString(), ObjectName);
            int _rows = dt.Rows.Count;
            if (_rows == 0)
            {
                return;
            }
            if (_rows != 0)
            {
                _idGridOrder = new string[_rows];
                for (int i = 0; i < _rows; i++)
                {
                    _idGridOrder[i] = dt.Rows[i]["Id"].ToString();
                    _oldIndex = Convert.ToInt32(dt.Rows[i]["OldIndex"].ToString());
                    _newIndex = Convert.ToInt32(dt.Rows[i]["NewIndex"].ToString());
                    livAgentList.Columns.Move(_oldIndex, _newIndex);
                }
               
            }
        }

        private void FillDropDownList()
        {
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "None"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "ComputerName"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "User"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "Alias"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "AgentStatus"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "IPAddress"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "Department"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "Building"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "Class"));
            tcmSort.Items.Add(lg.GetMessageFromDll(_langCode, "Room"));

            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "None"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "AgentStatus"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "Department"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "Building"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "Class"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "Room"));
            tcmGroup.Items.Add(lg.GetMessageFromDll(_langCode, "EventStatus"));

            tcmSort.SelectedIndex = 0;
            tcmGroup.SelectedIndex = 0;
        }

        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AgentMenuText");
            tslGroup.Text = lg.GetMessageFromDll(_langCode, "GroupBy");
            tslSort.Text = lg.GetMessageFromDll(_langCode, "SortBy");

            tslFilter.Text = lg.GetMessageFromDll(_langCode, "Search:");
            lblCountTitle.Text = lg.GetMessageFromDll(_langCode, "DataSourceCount");
            lblCount.Text = Convert.ToString(Program.dataSource.Count);
            tsbAgentChat.Text = lg.GetMessageFromDll(_langCode, "Chat");
            tsbAgentCheckStatus.Text = lg.GetMessageFromDll(_langCode, "Select");
            tsbAgentAlarm.Text = lg.GetMessageFromDll(_langCode, "AlarmAssign");
            tsbAgentsId.Text = lg.GetMessageFromDll(_langCode, "Id");
            tsbAgentSetting.Text = lg.GetMessageFromDll(_langCode, "SettingAssign");
            tsbRefreshList.Text = lg.GetMessageFromDll(_langCode, "Refresh");
            tsbSendCommand.Text = lg.GetMessageFromDll(_langCode, "Command");
            tsbView.Text = lg.GetMessageFromDll(_langCode, "View");
            tsbSendFile.Text = lg.GetMessageFromDll(_langCode, "FileTransfer");
            tsbACL.Text = lg.GetMessageFromDll(_langCode, "AssignAclToAgent");
            tsbVideo.Text = lg.GetMessageFromDll(_langCode, "VideoConf");
            mniIcon.Text = lg.GetMessageFromDll(_langCode, "Icon");
            mniList.Text = lg.GetMessageFromDll(_langCode, "List");
            mniDetails.Text = lg.GetMessageFromDll(_langCode, "Details");

            cmiEvents.Text = lg.GetMessageFromDll(_langCode, "NewEventsShow");
            cmiRD.Text = lg.GetMessageFromDll(_langCode, "RemoteDesktop");
            cmiCommandBox.Text = lg.GetMessageFromDll(_langCode, "ControlBox");
            cmiSendCommand.Text = lg.GetMessageFromDll(_langCode, "GetCommandPrompt");
            cmiSettingAssign.Text = lg.GetMessageFromDll(_langCode, "SettingAssign");
            cmiAlertAssign.Text = lg.GetMessageFromDll(_langCode, "AlarmAssign");
            cmiCommandBox.Text = lg.GetMessageFromDll(_langCode, "ControlBox");
            cmiVC.Text = lg.GetMessageFromDll(_langCode, "VideoConf");
            cmiChatToAgent.Text = tsbAgentChat.Text;

            cmiShutdown.Text = lg.GetMessageFromDll(_langCode, "Shutdown");
            cmiRestart.Text = lg.GetMessageFromDll(_langCode, "Restart");
            cmiMonitorOff.Text = lg.GetMessageFromDll(_langCode, "MonitorOff");
            cmiMonitorOn.Text = lg.GetMessageFromDll(_langCode, "MonitorOn");
            cmiOpenCD.Text = lg.GetMessageFromDll(_langCode, "OpenCD");
            cmiCloseCD.Text = lg.GetMessageFromDll(_langCode, "CloseCD");

            tslSort.Font = new System.Drawing.Font("Tahoma", 9);
            tcmSort.Font = new System.Drawing.Font("Tahoma", 9);
            tslGroup.Font = new System.Drawing.Font("Tahoma", 9);
            tslFilter.Font = new System.Drawing.Font("Tahoma", 9);
            tcmGroup.Font = new System.Drawing.Font("Tahoma", 9);
            txbSearch.Font = new System.Drawing.Font("Tahoma", 9);
            lblCount.Font = new System.Drawing.Font("Tahoma", 9);
            lblCountTitle.Font = new System.Drawing.Font("Tahoma", 9);

            tslSort.ForeColor = System.Drawing.Color.DarkRed;
            tslGroup.ForeColor = System.Drawing.Color.DarkRed;
            tslFilter.ForeColor = System.Drawing.Color.DarkRed;
            lblCountTitle.ForeColor = System.Drawing.Color.DarkRed;

        }

        private void livAgentList_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {            
            if (e.CellElement.Image != null)
            {
                e.CellElement.Image = e.CellElement.Image.GetThumbnailImage(32, 32, null, IntPtr.Zero);                
            }
            if (e.CellElement.Text != null)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleCenter;
                e.CellElement.ForeColor = System.Drawing.Color.Navy;               
            }         
           
        }

        private void livAgentList_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        {  
                        
            if (e.Column.FieldName == "AgentId" || e.Column.FieldName == "AgentListIndex" || e.Column.FieldName == "UserImage")
            {
                e.Column.Visible = false;                
            }
            if (e.Column.FieldName == "AgentSystemType")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "Alert")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "EventStatus");
                e.Column.MaxWidth = 100;
            }
            if (e.Column.FieldName == "AlertImageIcon")
            {
                e.Column.Visible = false;
            }
            if (e.Column.FieldName == "SystemType")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "SystemType");
            }

            if (e.Column.FieldName == "ComputerName")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "ComputerName");
            }
            if (e.Column.FieldName == "Status")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "AgentStatus");
                e.Column.MaxWidth = 100;
            }
            if (e.Column.FieldName == "UserFullName")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "User");
            }
            if (e.Column.FieldName == "AgentIP")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "IPAddress");
                e.Column.MaxWidth = 100;
            }
            if (e.Column.FieldName == "Room")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "Room");
                e.Column.MaxWidth = 100;
            }
            if (e.Column.FieldName == "Class")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "Class");
                e.Column.MaxWidth = 100;
            }
            if (e.Column.FieldName == "Buildding")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "Building");
                e.Column.MaxWidth = 200;
            }
            if (e.Column.FieldName == "Department")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "Department");
                e.Column.MaxWidth = 200;
            }
            if (e.Column.FieldName == "IdleTime")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "IdleTime");
                e.Column.MaxWidth = 200;
            }
            if (e.Column.FieldName == "Alias")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "Alias");
            }
            if (e.Column.FieldName == "SettingProfileName")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "SettingProfile");
            }
            if (e.Column.FieldName == "AlertProfileName")
            {
                e.Column.HeaderText = lg.GetMessageFromDll(_langCode, "AlarmProfile");
            }

        }

        private void tcmSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.livAgentList.SortDescriptors.Clear();
            switch (this.tcmSort.SelectedIndex)
            {
                case 1:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("ComputerName", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 2:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("UserFullName", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 3:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Alias", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 4:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Status", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 5:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("AgentIP", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 6:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Department", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 7:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Buildding", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 8:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Class", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
                case 9:
                    this.livAgentList.SortDescriptors.Add(new SortDescriptor("Room", ListSortDirection.Ascending));
                    this.livAgentList.EnableSorting = true;
                    break;
            }
        }

        private void tcmGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.livAgentList.GroupDescriptors.Clear();
            switch (this.tcmGroup.SelectedIndex)
            {
                case 0:
                    this.livAgentList.EnableGrouping = false;
                    this.livAgentList.ShowGroups = false;
                    break;
                case 1:
                    this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Status", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
                case 2:
                    this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Department", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
                case 3:
                    this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Buildding", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
                case 4:
                    this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Class", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
                case 5:
                    this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Room", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
                case 6:
                     this.livAgentList.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("Alert", ListSortDirection.Ascending) }));
                    this.livAgentList.EnableGrouping = true;
                    this.livAgentList.ShowGroups = true;
                    break;
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            this.livAgentList.FilterDescriptors.Clear();

            if (String.IsNullOrEmpty(this.txbSearch.Text))
            {
                this.livAgentList.EnableFiltering = false;
            }
            else
            {
                this.livAgentList.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                this.livAgentList.FilterDescriptors.Add("ComputerName", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("UserFullName", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("Alias", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("Department", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("Buildding", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("Class", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("Room", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.FilterDescriptors.Add("AgentIP", FilterOperator.Contains, this.txbSearch.Text);
                this.livAgentList.EnableFiltering = true;
            }
        }

        private void livAgentList_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            _selectedAgent = Program.AgentList[livAgentList.SelectedIndex];
            if (User.UserClassifyID >= _selectedAgent.acl1)
            {                
                frmAgentGeneralInfo_RtoL frm = new frmAgentGeneralInfo_RtoL(_selectedAgent);
                frm.ShowDialog();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        }     

        private void livAgentList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                BaseListViewVisualItem item = this.livAgentList.ElementTree.GetElementAtPoint(e.Location) as BaseListViewVisualItem;
                if (item != null)
                {
                    this.livAgentList.SelectedItem = item.Data;
                    _selectedAgent = Program.AgentList[this.livAgentList.SelectedIndex];
                    if (lg.HaveEvent(_selectedAgent.AgentID) == true)
                    {
                        cmiEvents.Enabled = true;
                    }
                    else
                    {
                        cmiEvents.Enabled = false;                        
                    }
                    if (_selectedAgent.Status == "Off" || _selectedAgent.Status == "StandBy")
                    {
                        cmiCommandBox.Enabled = false;
                        cmiRD.Enabled = false;
                        cmiSendCommand.Enabled = false;
                        cmiVC.Enabled = false;                        
                    }
                    if (_selectedAgent.Status == "On" || _selectedAgent.Status == "Idle")
                    {
                        cmiCommandBox.Enabled = true;
                        cmiRD.Enabled = true;
                        cmiSendCommand.Enabled = true;
                        cmiVC.Enabled = true;
                    }

                    cmsAgent.Show(Cursor.Position);

                }
            }
        }
      
        private void frmAgentsView_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (_columnsReorder == true)
            {
                if (_idGridOrder != null)
                {
                    //DeleteGridOrder();
                    InsertGridOrder();                   
                }
                if (_idGridOrder == null)
                {
                    InsertGridOrder();
                }                
            }
             */ 
        }

        private void InsertGridOrder()
        {
            int _oldIndex, _newIndex, _res;
            for (int i = 0; i < _columnsMoved.Count; i++)
            {               
                    _oldIndex = _columnsMoved[i];
                   // _newIndex = _columnsMoved[i + 1];
                    _newIndex = livAgentList.Columns.IndexOf(_columns[_oldIndex]);
                    _res = lg.InsertGridOrder(User.UserID.ToString(), ObjectName, _oldIndex.ToString(), _newIndex.ToString());

                    if (_oldIndex != _newIndex)
                    {
                        _res = lg.InsertGridOrder(User.UserID.ToString(), ObjectName, _oldIndex.ToString(), _newIndex.ToString());
                    }
                    
               
            }
        }

        private void DeleteGridOrder()
        {
            int _row = _idGridOrder.Length;
            int _res;
            for (int i = 0; i < _row; i++)
            {
                _res = lg.DeleteGridOrder(_idGridOrder[i]);
                if (_res == 0)
                {
                    //SqlError
                }
            }
        }

      
        private void tsbAgentCheckStatus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < livAgentList.Items.Count; i++)
            {
                if (livAgentList.Items[i].CheckState == ToggleState.Off)
                    livAgentList.Items[i].CheckState = ToggleState.On;
                else
                    livAgentList.Items[i].CheckState = ToggleState.Off;
            }
        }

        private void timRefreshList_Tick(object sender, EventArgs e)
        {
            timRefreshList.Enabled = false;
            tsbRefreshList_Click(sender, e);
        }

        private void tsbSendFile_Click(object sender, EventArgs e)
        {
            string SqlConString, lanC, serverPort, agentPort;

            LogicLayer ll = new LogicLayer();
            SqlConString = ll.GetSqlConnStringForDel();
            lanC = Program.LangCode.ToString();

            string pid = _selectedAgent.SettingProfileId;
            int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
            serverPort = Program.SettingProfileList[_profileIdIndex].FTPort; 

           // serverPort = Program.FTPort;
            agentPort = Program.SettingProfileList[_profileIdIndex].PublicPort; 

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

        private void tsbAgentSetting_Click(object sender, EventArgs e)
        {
            int _count = livAgentList.Items.Count;
            if (livAgentList.CheckedItems.Count > 0)
            {

                List<Agents> _agl = new List<Agents>();
                for (int i = 0; i < _count; i++)
                {
                    if (livAgentList.Items[i].CheckState == ToggleState.On)
                    {
                        _agl.Add(Program.AgentList[i]);
                    }
                }

                frmAssignSetting_RtoL fasetting = new frmAssignSetting_RtoL(_agl);
                fasetting.ShowDialog();
            }
            else
            {               
                LogicLayer lg = new LogicLayer();
                string _mes = lg.GetErrorMessage(23);
                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(_mes, 2);
                DialogResult dr = fs.ShowDialog();
            }
        }

        private void tsbAgentFilter_Click(object sender, EventArgs e)
        {
            int _count = livAgentList.Items.Count;
            if (livAgentList.CheckedItems.Count > 0)
            {

                List<Agents> _agl = new List<Agents>();
                for (int i = 0; i < _count; i++)
                {
                    if (livAgentList.Items[i].CheckState == ToggleState.On)
                    {                       
                        _agl.Add(Program.AgentList[i]);
                    }
                }

                frmAssignAlarm_RtoL faalarm = new frmAssignAlarm_RtoL(_agl);
                faalarm.ShowDialog();
            }
            else
            {               
                LogicLayer lg = new LogicLayer();
                string _mes = lg.GetErrorMessage(23);
                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(_mes, 2);
                DialogResult dr = fs.ShowDialog();
            }
        }

        private void tsbRefreshList_Click(object sender, EventArgs e)
        {           
            if (Program.TotalAgentRegistered > Program.dataSource.Count)
            {               
                Program.dataSource = null;
                LogicLayer lglayer = new LogicLayer();
                lglayer.FirstGetAgentMainList();
                SetListView();
                lblCount.Text = Convert.ToString(Program.dataSource.Count);
            }          

            SetAgentPropertiesChange();
            
            if (Program.HasAlertIcon == true)
            {
                SetIconAlert();
            }
           
           timRefreshList.Enabled = true;    
        }

        private void SetAgentPropertiesChange()
        {
            int dc = Program.dataSource.Count;
            
            string _onWork = lg.GetMessageFromDll(_langCode, "OnWork");
            string _minute = lg.GetMessageFromDll(_langCode, "Minute");
            string _off = lg.GetMessageFromDll(_langCode, "SystemOff");
            string _standby = lg.GetMessageFromDll(_langCode, "SystemStandby");
            string _info = lg.GetMessageFromDll(_langCode, "Information");
            string _warning = lg.GetMessageFromDll(_langCode, "Warning");
            string _normal = lg.GetMessageFromDll(_langCode, "Normal");

           

            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentMainList.ToString();
            DataTable _dt = new DataTable();
            _dt = sql.ExcecuteQueryToDataTable();

            Program.TotalAgentAvailable = 0;
            Program.TotalAgentUnavailable = 0;
            byte[] imageData;

            for (int i = 0; i < dc; i++)
            {
                if (Program.AgentList[i].AlertLevelId != null)
                {
                    if (Program.AgentList[i].AlertLevelId == "1")
                    {
                        Program.dataSource[i].AlertImageIcon = imlAlert.Images["YelloAlert"];
                        Program.dataSource[i].Alert = _info;
                    }
                    if (Program.AgentList[i].AlertLevelId == "2")
                    {
                        Program.dataSource[i].AlertImageIcon = imlAlert.Images["RedAlert"];
                        Program.dataSource[i].Alert = _warning;
                    }
                    if (Program.AgentList[i].AlertLevelId == "3")
                    {
                        Program.dataSource[i].AlertImageIcon = imlAlert.Images["RedAlert"];
                        Program.dataSource[i].Alert = _warning;
                    }
                    if (Program.AgentList[i].AlertLevelId == "4")
                    {
                        Program.dataSource[i].AlertImageIcon = imlAlert.Images["RedAlert"];
                        Program.dataSource[i].Alert = _warning;
                    }
                }
                else
                {
                    Program.dataSource[i].AlertImageIcon = imlAlert.Images["Ok"];
                    Program.dataSource[i].Alert = _normal;
                }
                Program.AgentList[i].Status = lg.GetAgentStatus(_dt.Rows[i]["NowStatus"].ToString());
                Program.dataSource[i].Status = Program.AgentList[i].Status;

                if (_dt.Rows[i]["IdleDuration"] != DBNull.Value)
                {
                    Program.AgentList[i].IdleDuration = lg.GetIdleDuration(_dt.Rows[i]["IdleDuration"].ToString(), _dt.Rows[i]["NowStatus"].ToString());
                    Program.dataSource[i].IdleTime = Program.AgentList[i].IdleDuration + " " + _minute;;
                }
               
               
                if (_dt.Rows[i]["UserImage"] != DBNull.Value)
                {
                    imageData = (byte[])_dt.Rows[i]["UserImage"];
                    Image perImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);

                        //Set image variable value using memory stream.
                        perImage = Image.FromStream(ms, true);
                    }

                    Program.AgentList[i].PersonnelImage = perImage;
                    imlPerssonel.Images.Add(Program.AgentList[i].AgentID, Program.AgentList[i].PersonnelImage);
                    Program.dataSource[i].UserImage = imlPerssonel.Images[Program.AgentList[i].AgentID];

                }
                else
                {
                    Program.dataSource[i].UserImage = imlPerssonel.Images["UnKnown"];
                    Program.AgentList[i].PersonnelImage = Program.dataSource[i].UserImage;
                }
               
              

                Program.dataSource[i].UserFullName = Program.AgentList[i].PersonnelFName + " " + Program.AgentList[i].PersonnelLName;
                Program.dataSource[i].AgentIP = lg.GetFirstActiveIPV4(_dt.Rows[i]["IPAddress"].ToString());

                Program.dataSource[i].Alias = Program.AgentList[i].Alias;
                Program.dataSource[i].AlertProfileName = Program.AgentList[i].AlertProfileName;
                Program.dataSource[i].Buildding = Program.AgentList[i].BuildingTitle;
                Program.dataSource[i].Class = Program.AgentList[i].ClassTitle;
                Program.dataSource[i].Department = Program.AgentList[i].DepartmentTitle;
                Program.dataSource[i].Room = Program.AgentList[i].RoomTitle;
                Program.dataSource[i].ComputerName = Program.AgentList[i].ComputerName;
              
                
           }
        }

        private void frmAgentsView_RtoL_Shown(object sender, EventArgs e)
        {
            Program.AgentViewLoadComplete = true;
        }

        private void timReportCheck_Tick(object sender, EventArgs e)
        {
            if (thrNewEventShow.IsAlive == false || Program.ReportReady == true)
            {
                timReportCheck.Enabled = false;
                Program.ReportReady = false;
                thrWaitting.Abort();                
            }
        }

        private void tsbAgentsId_Click(object sender, EventArgs e)
        {
            int _count = livAgentList.Items.Count;
            if (livAgentList.CheckedItems.Count > 0)
            {

                List<Agents> _agl = new List<Agents>();
                for (int i = 0; i < _count; i++)
                {
                    if (livAgentList.Items[i].CheckState == ToggleState.On)
                    {
                        _agl.Add(Program.AgentList[i]);
                    }
                }

                frmRepAgentsId_RtoL frmAgId = new frmRepAgentsId_RtoL(_agl);
                frmAgId.Show();              
            }
            else
            {               
                LogicLayer lg = new LogicLayer();
                string _mes = lg.GetErrorMessage(23);
                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(_mes, 2);
                DialogResult dr = fs.ShowDialog();
            }
        }

        private void tsbAgentChat_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbACL_Click(object sender, EventArgs e)
        {
            int _count = livAgentList.Items.Count;
            if (livAgentList.CheckedItems.Count > 0)
            {

                List<Agents> _agl = new List<Agents>();
                for (int i = 0; i < _count; i++)
                {
                    if (livAgentList.Items[i].CheckState == ToggleState.On)
                    {
                        _agl.Add(Program.AgentList[i]);
                    }
                }

                frmAssignAcl_RtoL frmaacl = new frmAssignAcl_RtoL(_agl);
                frmaacl.ShowDialog();              
            }
            else
            {
                LogicLayer lg = new LogicLayer();
                string _mes = lg.GetErrorMessage(23);
                frmShowInfoSmall_RtoL fs = new frmShowInfoSmall_RtoL(_mes, 2);
                DialogResult dr = fs.ShowDialog();
            }
        }

      
        
    }    
}
