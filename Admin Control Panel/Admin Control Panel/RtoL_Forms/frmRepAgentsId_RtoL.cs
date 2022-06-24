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
using Admin_Control_Panel.Classes;
using Stimulsoft.Report;


namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmRepAgentsId_RtoL : Telerik.WinControls.UI.RadForm
    {
        private List<Agents> _agentsList;
        private List<AgentsIdParent> AgentParentList;
        private List<AgentsIdChild> AgentChildList;
        private List<AgentsIdChildDetails> AgentsChildDetailsList;

        private GridViewTemplate template;
        private GridViewTemplate template2;

        private string _langCode;
        private LogicLayer lg;

        private string _hardwares;
        private string _softwares;
        private string _networks;
        private string _os;
        private string _security;
        private string _accounts;
        private string _groups;
        private string _assets;
        private string _location;


        private string _cpu;
        private string _mainboard;
        private string _harddisk;
        private string _memory;
        private string _modem;
        private string _netadapter;
        private string _chasis;
        private string _keyboard;
        private string _mouse;
        private string _monitor;
        private string _vga;
        private string _printer;
        private string _scaner;
        private string _cdrom;
        private string _camera;
        private string _softwaresName;
        private string _osName;
        private string _serialNumber;
        private string _version;
        private string _securityName;
        private string _title;
        private string _case;
        private string _building;
        private string _room;
        private string _class;
        private string _department;
        private string _page;
        private string _from;



        private string HCradif, HPersonnelName, HSysyemName, HAgentId;  // Header Column Text


        public frmRepAgentsId_RtoL(List<Agents> AgentsList)
        {
            _agentsList = new List<Agents>();
            _agentsList = AgentsList;
            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();

            InitializeComponent();
        }

        private void frmRepAgentsId_RtoL_Load(object sender, EventArgs e)
        {
            this.grvAgentsId.ShowGroupPanel = false;

            this.Text = lg.GetMessageFromDll(_langCode, "SystemsID");
           
            _hardwares = lg.GetMessageFromDll(_langCode, "Hardware");
            _softwares = lg.GetMessageFromDll(_langCode, "Application");
            _networks = lg.GetMessageFromDll(_langCode, "Network");
            _os = lg.GetMessageFromDll(_langCode, "OS");
            _security = lg.GetMessageFromDll(_langCode, "SecurityUpdate");
            _accounts = lg.GetMessageFromDll(_langCode, "Accounts");
            _groups = lg.GetMessageFromDll(_langCode, "Groups");
            _assets = lg.GetMessageFromDll(_langCode, "AssetNumber");
            _location = lg.GetMessageFromDll(_langCode, "LocalAddress");

            _cpu = lg.GetMessageFromDll(_langCode, "CPU");
            _mainboard = lg.GetMessageFromDll(_langCode, "Motherboard");
            _harddisk = lg.GetMessageFromDll(_langCode, "HardDisk");
            _memory = lg.GetMessageFromDll(_langCode, "Memory");
            _modem = lg.GetMessageFromDll(_langCode, "Modem");
            _netadapter = lg.GetMessageFromDll(_langCode, "NetAdapter");
            _chasis = lg.GetMessageFromDll(_langCode, "Chassis");
            _keyboard = lg.GetMessageFromDll(_langCode, "Keyboard");
            _mouse = lg.GetMessageFromDll(_langCode, "Mouse");
            _monitor = lg.GetMessageFromDll(_langCode, "Monitor");
            _vga = lg.GetMessageFromDll(_langCode, "VideoCard");
            _printer = lg.GetMessageFromDll(_langCode, "Printer");
            _scaner = lg.GetMessageFromDll(_langCode, "Scanner");
            _cdrom = lg.GetMessageFromDll(_langCode, "CdRom");
            _camera = lg.GetMessageFromDll(_langCode, "Camera");

            _softwaresName = lg.GetMessageFromDll(_langCode, "SoftwareName");
            _osName = lg.GetMessageFromDll(_langCode, "OSName");
            _version = lg.GetMessageFromDll(_langCode, "Version");
            _serialNumber = lg.GetMessageFromDll(_langCode, "lblSerialNumber");
            _securityName = lg.GetMessageFromDll(_langCode, "SecurityUpdateName");

            _title = lg.GetMessageFromDll(_langCode, "Title");
            _case = lg.GetMessageFromDll(_langCode, "Case");

            _building = lg.GetMessageFromDll(_langCode, "Building");
            _room = lg.GetMessageFromDll(_langCode, "Room");
            _class = lg.GetMessageFromDll(_langCode, "Class");
            _department = lg.GetMessageFromDll(_langCode, "Department");
            _page = lg.GetMessageFromDll(_langCode, "Page");
            _from = lg.GetMessageFromDll(_langCode, "From");
            
            imgPersonel.Images.Add("UnKnown", Properties.Resources.unknown);

            grvAgentsId.AutoGenerateHierarchy = true;

            SetHeaderColumnsText();
            SetMasterList();
            SetChildList();
            SetChildDetailList();
            SetMasterGrid();
            SetChildGrid();            
            SetChildDetailsGrid();
           

        }

        private void SetHeaderColumnsText()
        {           

            HCradif = lg.GetMessageFromDll(_langCode, "radif");
            HPersonnelName = lg.GetMessageFromDll(_langCode, "UserFullName");
            HSysyemName = lg.GetMessageFromDll(_langCode, "System");
            HAgentId = lg.GetMessageFromDll(_langCode, "AgentID");        

        }

        private void SetMasterList()
        {
            AgentParentList = new List<AgentsIdParent>();
            AgentChildList = new List<AgentsIdChild>();
            AgentsChildDetailsList = new List<AgentsIdChildDetails>();

            for (int i = 0; i < _agentsList.Count; i++)
            {
                int index = Program.AgentList.FindIndex(item => item.AgentID == _agentsList[i].AgentID);
                string aid = Program.dataSource[index].AgentId;
                                
                Image agantImage;

                if (Program.dataSource[index].UserImage != null)
                {
                    imgPersonel.Images.Add(aid, Program.dataSource[index].UserImage);
                    agantImage = imgPersonel.Images[aid];
                }
                else
                {
                    agantImage = imgPersonel.Images["UnKnown"];
                }


                string fullname = Program.dataSource[index].UserFullName;
                string system = Program.dataSource[index].ComputerName;

                AgentParentList.Add(new AgentsIdParent(true,i + 1, agantImage, fullname, system, Convert.ToInt32(aid)));
            }

        }

        private void SetMasterGrid()
        {
            grvAgentsId.DataSource = AgentParentList;

            grvAgentsId.Columns[0].HeaderText = "";
            grvAgentsId.Columns[1].HeaderText = HCradif;
            grvAgentsId.Columns[2].HeaderText = "";            
            grvAgentsId.Columns[3].HeaderText = HPersonnelName;
            grvAgentsId.Columns[4].HeaderText = HSysyemName;
            grvAgentsId.Columns[5].HeaderText = HAgentId;
           



            grvAgentsId.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
         


            grvAgentsId.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            grvAgentsId.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;

            grvAgentsId.Columns[0].ReadOnly = false;
            grvAgentsId.Columns[1].ReadOnly = true;
            grvAgentsId.Columns[2].ReadOnly = true;
            grvAgentsId.Columns[3].ReadOnly = true;
            grvAgentsId.Columns[4].ReadOnly = true;
            grvAgentsId.Columns[5].ReadOnly = true;



            grvAgentsId.Columns[0].MaxWidth = 40;//checkbox
            grvAgentsId.Columns[0].MinWidth = 39;

            grvAgentsId.Columns[1].MaxWidth = 40;//radif
            grvAgentsId.Columns[1].MinWidth = 39;

            grvAgentsId.Columns[2].MaxWidth = 64; //aks
            grvAgentsId.Columns[2].MinWidth = 63;
            //grvAgentsId.Columns[1].ImageLayout = ImageLayout.Stretch;
            grvAgentsId.Columns[2].AutoSizeMode = Telerik.WinControls.UI.BestFitColumnMode.AllCells;


            grvAgentsId.Columns[3].MinWidth = 150; //naam

            grvAgentsId.Columns[4].MaxWidth = 150;//system
            grvAgentsId.Columns[4].MinWidth = 149;

            grvAgentsId.Columns[5].MaxWidth = 300; // location
            grvAgentsId.Columns[5].MinWidth = 299;

            grvAgentsId.MasterTemplate.Caption = "Master";

            grvAgentsId.AllowDragToGroup = true;

            this.grvAgentsId.TableElement.EndUpdate(true);
        }

        private void SetChildList()
        {
            for (int i = 0; i < _agentsList.Count; i++)
            {
                AgentChildList.Add(new AgentsIdChild(true, Convert.ToInt32("1" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _hardwares));
                AgentChildList.Add(new AgentsIdChild(false,Convert.ToInt32("2" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _softwares));
                AgentChildList.Add(new AgentsIdChild(true,Convert.ToInt32("3" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _networks));
                AgentChildList.Add(new AgentsIdChild(true, Convert.ToInt32("4" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _os));
                AgentChildList.Add(new AgentsIdChild(false,Convert.ToInt32("5" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _security));
                AgentChildList.Add(new AgentsIdChild(false,Convert.ToInt32("6" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _accounts));
                AgentChildList.Add(new AgentsIdChild(false,Convert.ToInt32("7" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _groups));
                AgentChildList.Add(new AgentsIdChild(true, Convert.ToInt32("8" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _assets));
                AgentChildList.Add(new AgentsIdChild(true, Convert.ToInt32("9" + i.ToString()), Convert.ToInt32(_agentsList[i].AgentID), _location));
            }

        }

        private void SetChildGrid()
        {
            template = new GridViewTemplate();
            template.DataSource = AgentChildList;


            template.Columns[1].IsVisible = false;
            template.Columns[2].IsVisible = false;


            template.Columns[0].HeaderText = "";
            template.Columns[1].HeaderText = "";
            template.Columns[2].HeaderText = "";
            template.Columns[3].HeaderText = "";
          



            template.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
         



            template.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
          

            template.ReadOnly = false;

            template.AllowAddNewRow = false;
            template.AllowDeleteRow = false;
            template.AllowEditRow = true;



            template.Columns[0].MaxWidth = 40;
            template.Columns[0].MinWidth = 39;

            template.Columns[3].MaxWidth = 200;
            template.Columns[3].MinWidth = 149;

            template.Columns[3].ReadOnly = true;

            template.AllowDragToGroup = true;
            template.ShowChildViewCaptions = false;

            template.Caption = "Child";

            grvAgentsId.MasterTemplate.Templates.Add(template);
           


            GridViewRelation relation = new GridViewRelation(grvAgentsId.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "AgentsIdChild";
            relation.ParentColumnNames.Add("AgentId");
            relation.ChildColumnNames.Add("ParentAgentId");
            grvAgentsId.Relations.Add(relation);
            
        }

        private void SetChildDetailsGrid()
        {
            template2 = new GridViewTemplate();
            template2.DataSource = AgentsChildDetailsList;


            template2.Columns[1].IsVisible = false;
            template2.Columns[2].IsVisible = false;
            template2.Columns["AgentId"].IsVisible = false;
            


            template2.Columns[0].HeaderText = "";
            template2.Columns[1].HeaderText = "";
            template2.Columns[2].HeaderText = "";
            template2.Columns[3].HeaderText = "";
            template2.Columns[4].HeaderText = "";




            template2.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;



            template2.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            template2.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;


            template2.ReadOnly = false;

            template2.AllowAddNewRow = false;
            template2.AllowDeleteRow = false;
            template2.AllowEditRow = true;



            template2.Columns[0].MaxWidth = 40;
            template2.Columns[0].MinWidth = 39;

            template2.Columns[3].MaxWidth = 200;
            template2.Columns[3].MinWidth = 149;

            template2.Columns[4].MaxWidth = 700;
            template2.Columns[4].MinWidth = 600;

            template2.Columns[3].ReadOnly = true;
            template2.Columns[4].ReadOnly = true;

            template2.AllowDragToGroup = true;
            template2.ShowChildViewCaptions = false;

            template2.Caption = "ChildDetials";

            template.Templates.Add(template2);
            



            GridViewRelation relation2 = new GridViewRelation(template);
            relation2.ChildTemplate = template2;
            relation2.RelationName = "AgentsIdChildDetails";
            relation2.ParentColumnNames.Add("Id");
            relation2.ChildColumnNames.Add("ParentId");
            grvAgentsId.Relations.Add(relation2);

            
        }
        
        private void SetChildDetailList()
        {
            for (int i = 0; i < _agentsList.Count; i++)
            {
                int index = Program.AgentList.FindIndex(item => item.AgentID == _agentsList[i].AgentID);
                string aid = Program.dataSource[index].AgentId;
                int agentID = Convert.ToInt32(aid);
                SetHardwares(i, agentID);
                SetApplications(i, agentID);
                SetNetworks(i, agentID);
                SetOS(i, agentID);
                SetSecurity(i, agentID);
                SetAccounts(i, agentID);
                SetGroups(i, agentID);
                SetAsset(i, agentID);
                SetLocations(i, agentID);


            }
                          
           
        }

        private void SetHardwares(int Index,int AgentId)
        {
            SetCpu(Index, AgentId);
            SetMainboard(Index, AgentId);
            SetHardDisk(Index, AgentId);
            SetMemory(Index, AgentId);
            SetVideoCard(Index, AgentId);
            SetModem(Index, AgentId);
            SetCdRom(Index, AgentId);
            SetNetAdapter(Index, AgentId);
            SetChasis(Index, AgentId);
            SetKeyboard(Index, AgentId);
            SetMouse(Index, AgentId);
            SetMonitor(Index, AgentId);
            SetPrinter(Index, AgentId);
            SetScaner(Index, AgentId);
            SetCamera(Index, AgentId);    
        }

        private void SetCpu(int Index, int AgentId)
        {
            int _rowcount;
            if (_agentsList[Index].CpuBrand == null)
            {
                GetAgentDetails(Index);
            }
            _rowcount = _agentsList[Index].CpuBrand.Length;

            
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].CpuBrand[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 1, Convert.ToInt32("1" + Index.ToString()), _cpu, _agentsList[Index].CpuBrand[i].Trim(),AgentId));                    
                }
            }
        }

        private void SetMainboard(int Index, int AgentId)
        {
            if (_agentsList[Index].MotherboardCaption != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 2, Convert.ToInt32("1" + Index.ToString()), _mainboard, _agentsList[Index].MotherboardCaption.Trim() + " Model: " + _agentsList[Index].MotherboardModel.Trim(), AgentId));
            }

        }

        private void SetHardDisk(int Index, int AgentId)
        {
            int _rowcount;
          
            _rowcount = _agentsList[Index].HardDisk.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].HardDisk[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 3, Convert.ToInt32("1" + Index.ToString()), _harddisk, _agentsList[Index].HardDisk[i].Trim(), AgentId));
                }
            }
        }

        private void SetMemory(int Index, int AgentId)
        {
            int _rowcount;
            _rowcount = _agentsList[Index].Memory.Length;
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].Memory[i].Trim() != "")
                {
                    Int64 size = Convert.ToInt64(_agentsList[Index].Memory[i].Trim());
                    Int64 sizeToGig = size / 1000000000;
                    string s = sizeToGig.ToString() + "GB";
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 4, Convert.ToInt32("1" + Index.ToString()), _memory, s + " " + _agentsList[Index].MemoryModel[i].Trim(), AgentId));
                }
            }
        }

        private void SetVideoCard(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].VideoCard.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].VideoCard[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 5, Convert.ToInt32("1" + Index.ToString()), _vga, _agentsList[Index].VideoCard[i].Trim(), AgentId));
                }
            }
        }

        private void SetModem(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].Modem.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].Modem[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 6, Convert.ToInt32("1" + Index.ToString()), _modem, _agentsList[Index].Modem[i].Trim(), AgentId));
                }
            }
        }

        private void SetCdRom(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].CDRomName.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].CDRomName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 7, Convert.ToInt32("1" + Index.ToString()), _cdrom, _agentsList[Index].CDRomName[i].Trim(), AgentId));
                }
            }
        }

        private void SetNetAdapter(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].NetManufacturer.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].NetManufacturer[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 8, Convert.ToInt32("1" + Index.ToString()), _netadapter, _agentsList[Index].NetManufacturer[i].Trim(), AgentId));
                }
            }
        }

        private void SetChasis(int Index, int AgentId)
        {
            int mainindex = _agentsList[Index].AgentMainIndex;
            string chassisType = Program.dataSource[mainindex].SystemType;
            AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 9, Convert.ToInt32("1" + Index.ToString()), _chasis, chassisType, AgentId));          

        }

        private void SetKeyboard(int Index, int AgentId)
        {
            if (_agentsList[Index].Keyboard != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 10, Convert.ToInt32("1" + Index.ToString()), _keyboard, _agentsList[Index].Keyboard.Trim(), AgentId));
            }

        }

        private void SetMouse(int Index, int AgentId)
        {
            if (_agentsList[Index].Mouse != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 11, Convert.ToInt32("1" + Index.ToString()), _mouse, _agentsList[Index].Mouse.Trim(), AgentId));
            }

        }

        private void SetMonitor(int Index, int AgentId)
        {
            if (_agentsList[Index].Monitor != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 12, Convert.ToInt32("1" + Index.ToString()), _monitor, _agentsList[Index].Monitor.Trim(), AgentId));
            }
        }

        private void SetPrinter(int Index, int AgentId)
        {
            int _rowcount;
            _rowcount = _agentsList[Index].PrinterName.Length;
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].PrinterName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 13, Convert.ToInt32("1" + Index.ToString()), _printer, _agentsList[Index].PrinterName[i].Trim(), AgentId));
                }
            }
        }

        private void SetScaner(int Index, int AgentId)
        {
            if (_agentsList[Index].Scanner != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 14, Convert.ToInt32("1" + Index.ToString()), _scaner, _agentsList[Index].Scanner.Trim(), AgentId));
            }
        }

        private void SetCamera(int Index, int AgentId)
        {
            if (_agentsList[Index].Camera != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 15, Convert.ToInt32("1" + Index.ToString()), _camera, _agentsList[Index].Camera.Trim(), AgentId));
            }
        }

        private void SetApplications(int Index, int AgentId)
        {
            int _rowcount;
         
            _rowcount = _agentsList[Index].SoftwareName.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].SoftwareName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 16, Convert.ToInt32("2" + Index.ToString()), _softwaresName, _agentsList[Index].SoftwareName[i].Trim(), AgentId));
                }
            }
        }

        private void SetNetworks(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].ActiveNetworkAdapterCaption.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].ActiveNetworkAdapterCaption[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 17, Convert.ToInt32("3" + Index.ToString()), "IP Address", _agentsList[Index].IPAddress[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 18, Convert.ToInt32("3" + Index.ToString()), "Subnet Mask", _agentsList[Index].SubnetMask[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 19, Convert.ToInt32("3" + Index.ToString()), "Gateway Address", _agentsList[Index].DefaultGW[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 20, Convert.ToInt32("3" + Index.ToString()), "MAC Address", _agentsList[Index].MacAddress[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 21, Convert.ToInt32("3" + Index.ToString()), "DNS Address", _agentsList[Index].DNSServer[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 22, Convert.ToInt32("3" + Index.ToString()), "DHCP Status", _agentsList[Index].DHCPEnabled[i].Trim(), AgentId));
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 23, Convert.ToInt32("3" + Index.ToString()), "DHCP Address", _agentsList[Index].DHCPServer[i].Trim(), AgentId));
                }
            }
        }

        private void SetOS(int Index, int AgentId)
        {
            if (_agentsList[Index].Caption != "")
            {
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 24, Convert.ToInt32("4" + Index.ToString()), _osName, _agentsList[Index].Caption.Trim(), AgentId));
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 25, Convert.ToInt32("4" + Index.ToString()), _serialNumber, _agentsList[Index].OSSerialNumber.Trim(), AgentId));
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 26, Convert.ToInt32("4" + Index.ToString()), _version, _agentsList[Index].Version.Trim(), AgentId));
            }

        }

        private void SetSecurity(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].UpdateName.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].UpdateName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 27, Convert.ToInt32("5" + Index.ToString()), _securityName, _agentsList[Index].UpdateName[i].Trim(), AgentId));
                }
            }
        }

        private void SetAccounts(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].UserAccountName.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].UserAccountName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 28, Convert.ToInt32("6" + Index.ToString()), _title, _agentsList[Index].UserAccountName[i].Trim(), AgentId));
                }
            }
        }

        private void SetGroups(int Index, int AgentId)
        {
            int _rowcount;

            _rowcount = _agentsList[Index].UserGroupName.Length;


            for (int i = 0; i < _rowcount; i++)
            {
                if (_agentsList[Index].UserGroupName[i].Trim() != "")
                {
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(false, 29, Convert.ToInt32("7" + Index.ToString()), _title, _agentsList[Index].UserGroupName[i].Trim(), AgentId));
                }
            }
        }

        private void SetAsset(int Index, int AgentId)
        {
            int _rowcount;
            string title = "";
            if (_agentsList[Index].DeviceAssetNumber != null)
            {
                _rowcount = _agentsList[Index].DeviceAssetNumber.Length;


                for (int i = 0; i < _rowcount; i++)
                {
                    if (_agentsList[Index].DeviceAssetNumber[i].Trim() != "")
                    {
                        title = GetDeviceName(_agentsList[Index].DeviceId[i]);

                        AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 30, Convert.ToInt32("8" + Index.ToString()), title, _agentsList[Index].DeviceAssetNumber[i].Trim(), AgentId));
                    }
                }
            }
        }

        private void SetLocations(int Index, int AgentId)
        {   
          
            if (_agentsList[Index].BuildingTitle != "")
                if(_agentsList[Index].BuildingTitle != null)
                    AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 31, Convert.ToInt32("9" + Index.ToString()), _building, _agentsList[Index].BuildingTitle.Trim(), AgentId));

            if (_agentsList[Index].ClassTitle != "")
                if (_agentsList[Index].ClassTitle != null)
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 32, Convert.ToInt32("9" + Index.ToString()), _class, _agentsList[Index].ClassTitle.Trim(), AgentId));

            if (_agentsList[Index].RoomTitle != "")
                if (_agentsList[Index].RoomTitle != null)
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 33, Convert.ToInt32("9" + Index.ToString()), _room, _agentsList[Index].RoomTitle.Trim(), AgentId));

            if (_agentsList[Index].DepartmentTitle != "")
                if (_agentsList[Index].DepartmentTitle != null)
                AgentsChildDetailsList.Add(new AgentsIdChildDetails(true, 34, Convert.ToInt32("9" + Index.ToString()), _department, _agentsList[Index].DepartmentTitle.Trim(), AgentId));
        }
       
        private string GetDeviceName(int DeviceId)
        {
            string result = "";
            switch(DeviceId)
            {
                case 1:
                    result = _case;
                    break;
                case 2:
                    result = _monitor;
                    break;
                case 3:
                    result = _keyboard;
                    break;
                case 4:
                    result = _mouse;
                    break;
                case 5:
                    result = _printer;
                    break;
                case 6:
                    result = _scaner;
                    break;
                case 7:
                    result = _camera;
                    break;
            }

            return result;
        }

        private void GetAgentDetails(int Index)
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            LogicLayer lg1 = new LogicLayer();

            // Get CPU Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetProcessors.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            int _rowCount = dt.Rows.Count;

            _agentsList[Index].VendorID = new string[_rowCount];
            _agentsList[Index].SteppingID = new string[_rowCount];
            _agentsList[Index].CpuModelNumber = new string[_rowCount];
            _agentsList[Index].FamilyCode = new string[_rowCount];
            _agentsList[Index].ProcessorType = new string[_rowCount];
            _agentsList[Index].BrandID = new string[_rowCount];
            _agentsList[Index].CpuSerialNumber = new string[_rowCount];
            _agentsList[Index].SSE2 = new string[_rowCount];

            _agentsList[Index].ExtendedModel = new string[_rowCount];
            _agentsList[Index].ExtendedFamily = new string[_rowCount];
            _agentsList[Index].Chunks = new string[_rowCount];
            _agentsList[Index].Counts = new string[_rowCount];
            _agentsList[Index].APICID = new string[_rowCount];
            _agentsList[Index].MMX = new string[_rowCount];
            _agentsList[Index].FxsaveFxrstorInstructions = new string[_rowCount];
            _agentsList[Index].SSE = new string[_rowCount];
            _agentsList[Index].CpuBrand = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].VendorID[i] = dt.Rows[i]["VendorId"].ToString();
                _agentsList[Index].SteppingID[i] = dt.Rows[i]["SteppingId"].ToString();
                _agentsList[Index].CpuModelNumber[i] = dt.Rows[i]["ModelNumber"].ToString();
                _agentsList[Index].FamilyCode[i] = dt.Rows[i]["FamilyCode"].ToString();
                _agentsList[Index].ProcessorType[i] = dt.Rows[i]["ProcessorType"].ToString();
                _agentsList[Index].BrandID[i] = dt.Rows[i]["BrandId"].ToString();
                _agentsList[Index].CpuSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].SSE2[i] = dt.Rows[i]["Sse2"].ToString();

                _agentsList[Index].ExtendedModel[i] = dt.Rows[i]["ExtendedModel"].ToString();
                _agentsList[Index].ExtendedFamily[i] = dt.Rows[i]["ExtendedFamily"].ToString();
                _agentsList[Index].Chunks[i] = dt.Rows[i]["Chunks"].ToString();
                _agentsList[Index].Counts[i] = dt.Rows[i]["Counts"].ToString();
                _agentsList[Index].APICID[i] = dt.Rows[i]["APICID"].ToString();
                _agentsList[Index].MMX[i] = dt.Rows[i]["MMX"].ToString();
                _agentsList[Index].FxsaveFxrstorInstructions[i] = dt.Rows[i]["FxSaveFxStorinStructions"].ToString();
                _agentsList[Index].SSE[i] = dt.Rows[i]["SSE"].ToString();
                _agentsList[Index].CpuBrand[i] = dt.Rows[i]["Brand"].ToString();


            }

            dt = null;

            // Get Hard Disk Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetHardDisk.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;

            _agentsList[Index].HardDiskSignature = new string[_rowCount];
            _agentsList[Index].HardDiskSize = new string[_rowCount];
            _agentsList[Index].HardDiskPartitions = new string[_rowCount];
            _agentsList[Index].HardDiskPNPDeviceID = new string[_rowCount];
            _agentsList[Index].HardDiskSerialNumber = new string[_rowCount];
            _agentsList[Index].HardDiskTableId = new string[_rowCount];
            _agentsList[Index].HardDisk = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].HardDisk[i] = dt.Rows[i]["Caption"].ToString();
                _agentsList[Index].HardDiskSignature[i] = dt.Rows[i]["Signatures"].ToString();
                _agentsList[Index].HardDiskSize[i] = dt.Rows[i]["HardSize"].ToString();
                _agentsList[Index].HardDiskPartitions[i] = dt.Rows[i]["Partitiones"].ToString();
                _agentsList[Index].HardDiskPNPDeviceID[i] = dt.Rows[i]["PnpDevice"].ToString();
                _agentsList[Index].HardDiskTableId[i] = dt.Rows[i]["Id"].ToString();
                _agentsList[Index].HardDiskSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();

            }

            dt = null;

            // Get Memory Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMemory.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].BankLabel = new string[_rowCount];
            _agentsList[Index].Speed = new string[_rowCount];
            _agentsList[Index].MemoryModel = new string[_rowCount];
            _agentsList[Index].MemorySerialNumber = new string[_rowCount];
            _agentsList[Index].MemoryTableId = new string[_rowCount];
            _agentsList[Index].Memory = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].BankLabel[i] = dt.Rows[i]["BankLable"].ToString();
                _agentsList[Index].Speed[i] = dt.Rows[i]["Speed"].ToString();
                _agentsList[Index].MemoryModel[i] = dt.Rows[i]["Model"].ToString();
                _agentsList[Index].MemorySerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].MemoryTableId[i] = dt.Rows[i]["Id"].ToString();
                _agentsList[Index].Memory[i] = dt.Rows[i]["Capacity"].ToString();

            }
            dt = null;

            //Get Active Network Setting info

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetActiveNetworkSetting.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;

            _agentsList[Index].ActiveNetworkAdapterCaption = new string[_rowCount];
            _agentsList[Index].IPAddress = new string[_rowCount];
            _agentsList[Index].MacAddress = new string[_rowCount];
            _agentsList[Index].DefaultGW = new string[_rowCount];
            _agentsList[Index].SubnetMask = new string[_rowCount];
            _agentsList[Index].DNSServer = new string[_rowCount];
            _agentsList[Index].DHCPEnabled = new string[_rowCount];
            _agentsList[Index].DHCPServer = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].ActiveNetworkAdapterCaption[i] = dt.Rows[i]["Caption"].ToString();
                _agentsList[Index].IPAddress[i] = dt.Rows[i]["IPAddress"].ToString();
                _agentsList[Index].MacAddress[i] = dt.Rows[i]["MACAddress"].ToString();
                _agentsList[Index].DefaultGW[i] = dt.Rows[i]["DefaultGateway"].ToString();
                _agentsList[Index].SubnetMask[i] = dt.Rows[i]["SubnetMask"].ToString();
                _agentsList[Index].DNSServer[i] = dt.Rows[i]["DNSHostName"].ToString();
                _agentsList[Index].DHCPEnabled[i] = dt.Rows[i]["DHCPEnable"].ToString();
                _agentsList[Index].DHCPServer[i] = dt.Rows[i]["DHCPServerIP"].ToString();
            }

            dt = null;

            //Get Network Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetNetworkAdapter.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);

            _rowCount = dt.Rows.Count;
            _agentsList[Index].NetDescription = new string[_rowCount];
            _agentsList[Index].NetAdapterType = new string[_rowCount];
            _agentsList[Index].NetMACAddress = new string[_rowCount];
            _agentsList[Index].NetManufacturer = new string[_rowCount];
            _agentsList[Index].NetConnectionID = new string[_rowCount];
            _agentsList[Index].NetPNPDeviceID = new string[_rowCount];
            _agentsList[Index].NetTimeOfLastReset = new string[_rowCount];
            _agentsList[Index].NetSerialNumber = new string[_rowCount];
            _agentsList[Index].NetTableId = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].NetDescription[i] = dt.Rows[i]["Description"].ToString();
                _agentsList[Index].NetAdapterType[i] = dt.Rows[i]["AdapterType"].ToString();
                _agentsList[Index].NetMACAddress[i] = dt.Rows[i]["MacAddress"].ToString();
                _agentsList[Index].NetManufacturer[i] = dt.Rows[i]["Manufacturer"].ToString();
                _agentsList[Index].NetConnectionID[i] = dt.Rows[i]["Netconnectionid"].ToString();
                _agentsList[Index].NetPNPDeviceID[i] = dt.Rows[i]["PnpDeviceId"].ToString();
                _agentsList[Index].NetTimeOfLastReset[i] = dt.Rows[i]["TimeOfLastReset"].ToString();
                _agentsList[Index].NetSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].NetTableId[i] = dt.Rows[i]["Id"].ToString();
            }
            dt = null;

            //Get videocard Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetVideoCard.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].DriverDate = new string[_rowCount];
            _agentsList[Index].DriverVersion = new string[_rowCount];
            _agentsList[Index].VideoProcessor = new string[_rowCount];
            _agentsList[Index].VideoModeDescription = new string[_rowCount];
            _agentsList[Index].AdapterRAM = new string[_rowCount];
            _agentsList[Index].VideoCardSerialNumber = new string[_rowCount];
            _agentsList[Index].VideoCardTableId = new string[_rowCount];
            _agentsList[Index].VideoCard = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].VideoCard[i] = dt.Rows[i]["Caption"].ToString();
                _agentsList[Index].DriverDate[i] = dt.Rows[i]["DriverDate"].ToString();
                _agentsList[Index].DriverVersion[i] = dt.Rows[i]["DriverVersion"].ToString();
                _agentsList[Index].VideoProcessor[i] = dt.Rows[i]["VideoProcessor"].ToString();
                _agentsList[Index].VideoModeDescription[i] = dt.Rows[i]["VideoMode"].ToString();
                _agentsList[Index].AdapterRAM[i] = dt.Rows[i]["AdapterRam"].ToString();
                _agentsList[Index].VideoCardSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].VideoCardTableId[i] = dt.Rows[i]["Id"].ToString();
            }
            dt = null;

            //Get OS Info details
            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetOS.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);

            _agentsList[Index].OSSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            _agentsList[Index].OSBuildNumber = dt.Rows[0]["BuildNumber"].ToString();
            _agentsList[Index].FreePhysicalMemory = dt.Rows[0]["FreePhysicalMemory"].ToString();
            _agentsList[Index].InstallDate = dt.Rows[0]["InstallDate"].ToString();
            _agentsList[Index].Caption = dt.Rows[0]["Caption"].ToString();
            _agentsList[Index].RegisteredUser = dt.Rows[0]["RegisterUser"].ToString();
            _agentsList[Index].Version = dt.Rows[0]["Versions"].ToString();

            dt = null;

            //Get Mainboard Info Details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMotherboard.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _agentsList[Index].MotherboardCaption = dt.Rows[0]["Manufactorer"].ToString();
            _agentsList[Index].MotherboardModel = dt.Rows[0]["Product"].ToString();
            _agentsList[Index].MotherboardSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            _agentsList[Index].MotherboardVersion = dt.Rows[0]["Version"].ToString();

            dt = null;

            //Get Public Info Details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentStatus.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);

            string agentCurrentAccount = dt.Rows[0]["CurrentLogin"].ToString();
            string agentDuration = dt.Rows[0]["StartupDuration"].ToString();


            _agentsList[Index].CurrentAccount = lg1.GetCurrentAccount(agentCurrentAccount);
            _agentsList[Index].StartupDate = lg1.GetStartupDate(agentDuration);
            _agentsList[Index].StartupTime = lg1.GetStratupTime(agentDuration);

            dt = null;

            //Get CDROM Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetCDROM.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].CDRomName = new string[_rowCount];
            _agentsList[Index].CdromDrive = new string[_rowCount];
            _agentsList[Index].CDRomSerialNumber = new string[_rowCount];
            _agentsList[Index].CDRomTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].CDRomName[i] = dt.Rows[i]["CdRomName"].ToString();
                _agentsList[Index].CdromDrive[i] = dt.Rows[i]["CdRomDrive"].ToString();
                _agentsList[Index].CDRomSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].CDRomTableId[i] = dt.Rows[i]["Id"].ToString();
            }

            dt = null;

            // Get Logic Disk Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLagicDisk.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;

            _agentsList[Index].LogicDiskCaption = new string[_rowCount];
            _agentsList[Index].LogicDiskDescription = new string[_rowCount];
            _agentsList[Index].LogicDiskFileSystem = new string[_rowCount];
            _agentsList[Index].LogicDiskFreeSpace = new string[_rowCount];
            _agentsList[Index].LogicDiskSize = new string[_rowCount];
            _agentsList[Index].LogicDiskVolumeName = new string[_rowCount];
            _agentsList[Index].LogicDiskVolumeSerialNumber = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].LogicDiskCaption[i] = dt.Rows[i]["Caption"].ToString();
                _agentsList[Index].LogicDiskDescription[i] = dt.Rows[i]["Description"].ToString();
                _agentsList[Index].LogicDiskFileSystem[i] = dt.Rows[i]["FileSystem"].ToString();
                _agentsList[Index].LogicDiskFreeSpace[i] = dt.Rows[i]["FreeSpace"].ToString();
                _agentsList[Index].LogicDiskSize[i] = dt.Rows[i]["VolumeSize"].ToString();
                _agentsList[Index].LogicDiskVolumeName[i] = dt.Rows[i]["VolumeName"].ToString();
                _agentsList[Index].LogicDiskVolumeSerialNumber[i] = dt.Rows[i]["VolumeSerialNumber"].ToString();
            }

            dt = null;

            // Get Modem Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetModem.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].Modem = new string[_rowCount];
            _agentsList[Index].ModemSerialNumber = new string[_rowCount];
            _agentsList[Index].ModemTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].Modem[i] = dt.Rows[i]["ModemName"].ToString();
                _agentsList[Index].ModemTableId[i] = dt.Rows[i]["Id"].ToString();
                _agentsList[Index].ModemSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
            }

            dt = null;

            // Get Printer Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPrinter.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].PrinterName = new string[_rowCount];
            _agentsList[Index].PrinterNetwork = new string[_rowCount];
            _agentsList[Index].PrinterSerialNumber = new string[_rowCount];
            _agentsList[Index].PrinterTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].PrinterName[i] = dt.Rows[i]["PrinterName"].ToString();
                _agentsList[Index].PrinterNetwork[i] = dt.Rows[i]["Network"].ToString();
                _agentsList[Index].PrinterSerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                _agentsList[Index].PrinterTableId[i] = dt.Rows[i]["Id"].ToString();

            }

            dt = null;

            // Get Other Devices Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPublicDevices.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);

            _agentsList[Index].Monitor = dt.Rows[0]["Monitor"].ToString();
            _agentsList[Index].MonitorSerialNumber = dt.Rows[0]["MonitorSerialNumber"].ToString();

            _agentsList[Index].Keyboard = dt.Rows[0]["Keyboard"].ToString();
            _agentsList[Index].KeyboardSerialNumber = dt.Rows[0]["KeyboardSerialNumber"].ToString();

            _agentsList[Index].Mouse = dt.Rows[0]["Mouse"].ToString();
            _agentsList[Index].MouseSerialNumber = dt.Rows[0]["MouseSerialNumber"].ToString();

            _agentsList[Index].Scanner = dt.Rows[0]["Scanner"].ToString();
            _agentsList[Index].ScannerSerialNumber = dt.Rows[0]["ScannerSerialNumber"].ToString();

            _agentsList[Index].Camera = dt.Rows[0]["Camera"].ToString();
            _agentsList[Index].CameraSerialNumber = dt.Rows[0]["CameraSerialNumber"].ToString();

            _agentsList[Index].AllDevicesTableId = dt.Rows[0]["Id"].ToString();



            dt = null;

            // Get Users Account Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetUserAccounts.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].UserAccountName = new string[_rowCount];
            _agentsList[Index].UserAccountSID = new string[_rowCount];
            _agentsList[Index].UserAccountDescription = new string[_rowCount];
            _agentsList[Index].UserAccountStatus = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].UserAccountName[i] = dt.Rows[i]["Username"].ToString();
                _agentsList[Index].UserAccountSID[i] = dt.Rows[i]["Sids"].ToString();
                _agentsList[Index].UserAccountDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agentsList[Index].UserAccountStatus[i] = dt.Rows[i]["Statuss"].ToString();
            }

            dt = null;

            // Get Users Group Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetUserGroups.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].UserGroupName = new string[_rowCount];
            _agentsList[Index].UserGroupSID = new string[_rowCount];
            _agentsList[Index].UserGroupDescription = new string[_rowCount];
            _agentsList[Index].UserGroupStatus = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].UserGroupName[i] = dt.Rows[i]["GroupName"].ToString();
                _agentsList[Index].UserGroupSID[i] = dt.Rows[i]["Sids"].ToString();
                _agentsList[Index].UserGroupDescription[i] = dt.Rows[i]["Descriptions"].ToString();
                _agentsList[Index].UserGroupStatus[i] = dt.Rows[i]["Statuss"].ToString();
            }

            dt = null;

            // Get Application Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetApplication.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].SoftwareName = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].SoftwareName[i] = dt.Rows[i]["SoftwareName"].ToString();

            }

            dt = null;

            // Get Updates Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSecurityUpdate.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);
            _rowCount = dt.Rows.Count;
            _agentsList[Index].UpdateName = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                _agentsList[Index].UpdateName[i] = dt.Rows[i]["SoftwareName"].ToString();

            }

            dt = null;

            // Get Bios Info details

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetBios.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);



            _agentsList[Index].BiosReleaseDate = dt.Rows[0]["ReleasDate"].ToString();
            _agentsList[Index].BiosRomSize = dt.Rows[0]["BiosRomSize"].ToString();
            _agentsList[Index].BiosStartSegment = dt.Rows[0]["StartSegment"].ToString();
            _agentsList[Index].BiosVendor = dt.Rows[0]["Vendor"].ToString();
            _agentsList[Index].BiosVersion = dt.Rows[0]["Version"].ToString();



            dt = null;


            // Get Location Info

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentLocation.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agentsList[Index].AgentID);

            if (dt.Rows.Count != 0)
            {
                _agentsList[Index].BuildingTitle = dt.Rows[0]["BuildingTitle"].ToString();
                _agentsList[Index].BuildingId = Convert.ToInt32(dt.Rows[0]["BuildingId"].ToString());

                _agentsList[Index].ClassTitle = dt.Rows[0]["ClassTitle"].ToString();
                _agentsList[Index].ClassId = Convert.ToInt32(dt.Rows[0]["ClassId"].ToString());

                _agentsList[Index].RoomTitle = dt.Rows[0]["RoomTitle"].ToString();
                _agentsList[Index].RoomId = Convert.ToInt32(dt.Rows[0]["RoomId"].ToString());

                _agentsList[Index].DepartmentTitle = dt.Rows[0]["DepartmentTitle"].ToString();
                _agentsList[Index].DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"].ToString());

            }


            // Get Asset Info

           

            dt = lg.GetAgentAssetNumbers(_agentsList[Index].AgentID);


            if (dt.Rows.Count != 0)
            {
                _agentsList[Index].AssetTableId = new string[dt.Rows.Count];
                _agentsList[Index].DeviceId = new int[dt.Rows.Count];
                _agentsList[Index].DeviceAssetNumber = new string[dt.Rows.Count];
                _agentsList[Index].DeviceModel = new string[dt.Rows.Count];
                _agentsList[Index].DeviceSerialNumber = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _agentsList[Index].AssetTableId[i] = dt.Rows[i]["Id"].ToString();
                    _agentsList[Index].DeviceId[i] = Convert.ToInt32(dt.Rows[i]["DeviceId"].ToString());
                    _agentsList[Index].DeviceAssetNumber[i] = dt.Rows[i]["Assetnumber"].ToString();
                    _agentsList[Index].DeviceModel[i] = dt.Rows[i]["DeviceModel"].ToString();
                    _agentsList[Index].DeviceSerialNumber[i] = dt.Rows[i]["DeviceSerialNumber"].ToString();

                }
            }
            if (dt.Rows.Count == 0)
            {


            }

            //Update Agent list Property
            //string AgentIDtoFind = _agentsList[Index].AgentID;

            int _index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agentsList[Index].AgentID, StringComparison.Ordinal); });
            Program.AgentList[_index] = _agentsList[Index];


        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            int _errorCode1 = 0;
            int _errorCode2 = 0;

            _errorCode1 = SelectedAgentControl();
            _errorCode2 = CheckReportFileExist("SystemID_RtoL.mrt");

            if (_errorCode1 == 0 && _errorCode2 == 0)
            {            
                    CreateReport();
            }
            else
            {
                if (_errorCode1 != 0)
                {                    
                    ShowErrorMessage(1);
                }
                if (_errorCode2 != 0)
                {                    
                    ShowErrorMessage(2);
                }              
            }         

        }

        private void ShowErrorMessage(int ErrorCode)
        {
            string ms = "";
            switch(ErrorCode)
            {
                case 1:
                    ms = lg.GetErrorMessage(30);
                    break;
                case 2:
                    ms = lg.GetErrorMessage(33);
                    break;
            }
         
            frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
            frmi.ShowDialog();  
        }

        private void CreateReport()
        {
            try
            {

                DataTable ParentTable = new DataTable();
                DataTable ChildTable = new DataTable();
                DataTable ChildDetailsTable = new DataTable();

                ParentTable = GetParentDataTable();
                ChildTable = GetChildDataTable();
                ChildDetailsTable = GetChildDetailsDataTable();

                DataSet ds = new DataSet();
                //ds.DataSetName = "AgentsID";
                ds.Tables.Add(ParentTable);
                ds.Tables.Add(ChildTable);
                ds.Tables.Add(ChildDetailsTable);




                DataRelation r1 = new DataRelation("r1", ds.Tables[0].Columns[0], ds.Tables[1].Columns[1]);
                DataRelation r2 = new DataRelation("r2", ds.Tables[1].Columns[0], ds.Tables[2].Columns[1]);

                ds.Relations.Add(r1);
                ds.Relations.Add(r2);

                string _report = lg.GetMessageFromDll(_langCode, "Report");
                string _date = lg.GetMessageFromDll(_langCode, "EventDate");

                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SystemID_RtoL.mrt");

                stiReport1.RegData(ds);


                stiReport1.Compile();
                stiReport1["CompanyName"] = Program.CustomerName;
                stiReport1["ReportTitle"] = _report + " " + this.Text;
                stiReport1["Date"] = _date + " : " + User.LocalToday.Trim();

                stiReport1["HPersonnelName"] = HPersonnelName;
                stiReport1["HSysyemName"] = HSysyemName;
                stiReport1["HAgentId"] = HAgentId;
                stiReport1["Page"] = _page;
                stiReport1["From"] = _from;

                stiReport1.Dictionary.Synchronize();
                stiReport1.Render();

                stiReport1.Show();
            }
            catch (Exception)
            {
                string ms = lg.GetErrorMessage(34);
                frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                frmi.ShowDialog(); 
            }
        }

        private int CheckReportFileExist(string FileName)
        {
            int _result = 0;

            string path = Application.StartupPath + "\\Reports\\" + FileName;

            if (!File.Exists(path))
            {
                _result = 1;
            }
            return _result;
        }

        private int SelectedAgentControl()
        {
            int _res = 1;
            int _rCount = grvAgentsId.MasterTemplate.Rows.Count;

            for (int i = 0; i < _rCount; i++)
            {
                if ((bool)grvAgentsId.MasterTemplate.Rows[i].Cells[0].Value == true)
                {
                    _res = 0;
                }
            }
            return _res;
        }

        private DataTable GetParentDataTable()
        {
            DataTable dt1 = new DataTable();
            dt1.TableName = "Parent";
            dt1.Columns.Add("AgentId", typeof(int));
            dt1.Columns.Add("ComputerName", typeof(string));
            dt1.Columns.Add("UserFullName", typeof(string));
            dt1.Columns.Add("UserImage", typeof(Image));

            int rowCount = AgentParentList.Count;
            for (int i = 0; i < rowCount; i++)
            {               
                bool check = (bool)grvAgentsId.MasterTemplate.Rows[i].Cells[0].Value;
                if(check)
                    dt1.Rows.Add(AgentParentList[i].AgentId, AgentParentList[i].AgentComputerName, AgentParentList[i].PersonnelName, AgentParentList[i].AgentImage);
            }

            return dt1;
        }

        private DataTable GetChildDataTable()
        {
            DataTable dt2 = new DataTable();
            dt2.TableName = "Child";
            dt2.Columns.Add("Id", typeof(int));
            dt2.Columns.Add("AgentId", typeof(int));
            dt2.Columns.Add("Title", typeof(string));

            int rowCount = AgentChildList.Count;
            for (int i = 0; i < rowCount; i++)
            {
                bool check = (bool)template.Rows[i].Cells[0].Value;
                if (check)
                    dt2.Rows.Add(AgentChildList[i].Id, AgentChildList[i].ParentAgentId, AgentChildList[i].Title);
            }

            return dt2;
        }

        private DataTable GetChildDetailsDataTable()
        {
            DataTable dt3 = new DataTable();
            dt3.TableName = "ChildDetails";
            dt3.Columns.Add("Id", typeof(int));
            dt3.Columns.Add("ParentId", typeof(int));
            dt3.Columns.Add("Title", typeof(string));
            dt3.Columns.Add("TitleValue", typeof(string));

            int rowCount = AgentsChildDetailsList.Count;
            for (int i = 0; i < rowCount; i++)
            {
                bool check = (bool)template2.Rows[i].Cells[0].Value;
                if (check)
                    dt3.Rows.Add(AgentsChildDetailsList[i].ChildId, AgentsChildDetailsList[i].ParentId, AgentsChildDetailsList[i].Title, AgentsChildDetailsList[i].TitleValue);
            }

            return dt3;
        }

        private void grvAgentsId_ValueChanged(object sender, EventArgs e)
        {            

            if (this.grvAgentsId.ActiveEditor is RadCheckBoxEditor)
            {
                grvAgentsId.ValueChanged -= grvAgentsId_ValueChanged;
               
                int rIndex = this.grvAgentsId.CurrentCell.RowIndex;
               
                object value = this.grvAgentsId.ActiveEditor.Value;
                string caption = this.grvAgentsId.CurrentCell.ViewTemplate.Caption;

                if (value.ToString() == "On")
                {
                    if (caption == "Master")
                    {
                        ChangeAllCheckBox(rIndex,true);
                    }
                    if (caption == "Child")
                    {
                        int _parentAgentId = (int)this.grvAgentsId.CurrentRow.Cells["ParentAgentId"].Value;
                        int _id = (int)this.grvAgentsId.CurrentRow.Cells["Id"].Value;
                        ChangeAllChildCheckBox(rIndex, true, _parentAgentId,_id);
                    }
                    if (caption == "ChildDetials")
                    {
                        int _agentId = (int)this.grvAgentsId.CurrentRow.Cells["AgentId"].Value;
                        int _parentId = (int)this.grvAgentsId.CurrentRow.Cells["ParentId"].Value;
                        ChangeUpperCheckBoxToTrue(_agentId, _parentId);
                       
                    }

                }
                else if (value.ToString() == "Off")
                {
                    if (caption == "Master")
                    {
                        ChangeAllCheckBox(rIndex,false);
                    }
                    if (caption == "Child")
                    {
                        int _parentAgentId = (int)this.grvAgentsId.CurrentRow.Cells["ParentAgentId"].Value;
                        int _id = (int)this.grvAgentsId.CurrentRow.Cells["Id"].Value;
                        ChangeAllChildCheckBox(rIndex, false, _parentAgentId,_id);
                    }
                }

                grvAgentsId.ValueChanged += grvAgentsId_ValueChanged;
               
            }
 
        }

        private void ChangeAllCheckBox(int MainRowIndex,bool Action)
        {
            ChangeChildCheckBox(MainRowIndex, Action);
            ChangeChildDetailsCheckBox(MainRowIndex, Action);          
        }

        private void ChangeAllChildCheckBox(int MainRowIndex, bool Action,int AgentId,int ParentId)
        {
           
            ChangeChildDetailsCheckBox(MainRowIndex, Action,ParentId,AgentId);
        }      

        private void ChangeChildCheckBox(int MainRowIndex, bool Action)
        {
            int tc = (MainRowIndex + 1) * 9;
            int i = MainRowIndex * 9;

            template.BeginUpdate();

            for (; i < tc; i++)
            {
                template.Rows[i].Cells[0].Value = Action;
            }

            template.EndUpdate();
        }

        private void ChangeChildDetailsCheckBox(int MainRowIndex, bool Action)
        {
            int _startIndex, _lastIndex;
            int _agentId = Convert.ToInt32(_agentsList[MainRowIndex].AgentID);


            _startIndex = AgentsChildDetailsList.FindIndex(item => item.AgentId == _agentId);
            _lastIndex = AgentsChildDetailsList.FindLastIndex(item => item.AgentId == _agentId);

            if (_startIndex != -1)
            {
                template2.BeginUpdate();
                for (; _startIndex < _lastIndex + 1; _startIndex++)
                {
                    template2.Rows[_startIndex].Cells[0].Value = Action;
                }
                template2.EndUpdate();
            }
        }

        private void ChangeChildDetailsCheckBox(int MainRowIndex, bool Action,int ParentId,int AgentId)
        {
            int _startIndex, _lastIndex;
            _startIndex = AgentsChildDetailsList.FindIndex(item => item.ParentId == ParentId && item.AgentId == AgentId);
            _lastIndex = AgentsChildDetailsList.FindLastIndex(item => item.ParentId == ParentId && item.AgentId == AgentId);

           
            if (_startIndex != -1)
            {
                template2.BeginUpdate();
                for (; _startIndex < _lastIndex + 1; _startIndex++)
                {
                    template2.Rows[_startIndex].Cells[0].Value = Action;
                }
                template2.EndUpdate();
            }
        }

        private void ChangeUpperCheckBoxToTrue(int AgentId, int ParentId)
        {
            int _mainIndex = AgentParentList.FindIndex(item => item.AgentId == AgentId);
            int _childIndex = AgentChildList.FindIndex(item => item.Id == ParentId);

           
            template.Rows[_childIndex].Cells[0].Value = true;      
            grvAgentsId.MasterTemplate.Rows[_mainIndex].Cells[0].Value = true;
           

        }
        
    }
}
