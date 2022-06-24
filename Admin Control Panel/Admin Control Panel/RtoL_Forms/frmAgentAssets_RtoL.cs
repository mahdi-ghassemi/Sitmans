using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentAssets_RtoL : Telerik.WinControls.UI.RadForm
    {
        private Agents _agent;
        private string _langCode;
        private LogicLayer lg;
        private List<AgentDevicesList> DeviceList;
        private List<AgentInCaseDevices> InCaseDeviceList;
        private List<string> _resultList = new List<string>();
        private List<int> _resultInt = new List<int>();


        private string HCradif, HCdeviceName, HCmodel, HCserial, HCasset, HCUnitName;  // Header Column Text
        private string _Copy, _Paste, _Edit, _ClearValue;  // Context Menu Text
        private int radif;

        private int[] memoryRow;
        private int[] harddiskRow;
        private int[] videocardRow;
        private int[] cdromRow;
        private int[] modemRow;
        private int[] netRow;

        private string _groupPanelText;
       
        private bool[] IsFirstSave;
        private bool[] IsFirstSaveChild;
        private bool DataChanged;

       
        public frmAgentAssets_RtoL(Agents Agent)
        {
            _agent = new Agents();
            _agent = Agent;
            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();
            radif = 1;
            InitializeComponent();
        }

        private void frmAgentAssets_RtoL_Load(object sender, EventArgs e)
        {           
            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            helpToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Help");
            SetHeaderColumnsText();
            SetMasterList();
            SetChildList();
            SetMasterGrid();
            SetChildGrid();    
            

        }

        private void SetChildList()
        {           
            radif = 1;
            SetCpu();
            SetMainboard();
            SetHardDisk();
            SetMemory();
            SetVideoCard();
            SetModem();
            SetCdRom();
            SetNetAdapter();           
        }

        private void SetCpu()
        {
            int _rowcount;
            _rowcount = _agent.CpuBrand.Length;
            
            string CPU = lg.GetMessageFromDll(_langCode, "CPU");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.CpuBrand[i].Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, CPU, 1, 1, _agent.CpuBrand[i].Trim(), _agent.CpuSerialNumber[i].Trim(), ""));
                    radif++;
                }
            }
        }

        private void SetMainboard()
        {
            int _rowcount;
            _rowcount = 1;
            
            string mb = lg.GetMessageFromDll(_langCode, "Motherboard");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.MotherboardCaption.Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, mb, 2, 1, _agent.MotherboardCaption.Trim() + "  " + _agent.MotherboardModel.Trim(), _agent.MotherboardSerialNumber.Trim(), ""));
                    radif++;
                }
            }
        }

        private void SetHardDisk()
        {
            int _rowcount;
            _rowcount = _agent.HardDisk.Length;
            harddiskRow = new int[_rowcount];

            string hd = lg.GetMessageFromDll(_langCode, "HardDisk");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.HardDisk[i].Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, hd, 3, 1, _agent.HardDisk[i].Trim(), _agent.HardDiskSignature[i].Trim(), ""));
                    harddiskRow[i] = radif - 1;
                    radif++;
                }
            }
        }

        private void SetMemory()
        {
            int _rowcount;
            _rowcount = _agent.Memory.Length;
            memoryRow = new int[_rowcount];

            string me = lg.GetMessageFromDll(_langCode, "Memory");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Memory[i].Trim() != "")
                {
                    string _mod = _agent.MemoryModel[i].Trim();
                    string _sn = _agent.MemorySerialNumber[i].Trim();
    
                    string _mem =  lg.GetMemoryDetails(_agent.BankLabel[i].Trim(), _agent.Memory[i].Trim(), _agent.Speed[i].Trim());
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, me, 4, 1, _mem + " " + _mod , _sn, ""));
                    memoryRow[i] = radif - 1;
                    radif++;
                }
            }

        }

        private void SetVideoCard()
        {
            int _rowcount;
            _rowcount = _agent.VideoCard.Length;
            videocardRow = new int[_rowcount];
            string _sn = "";
            
            string vc = lg.GetMessageFromDll(_langCode, "VideoCard");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.VideoCard[i].Trim() != "")
                {
                    _sn = _agent.VideoCardSerialNumber[i].Trim();
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, vc, 5, 1, _agent.VideoCard[i].Trim(), _sn, ""));
                    videocardRow[i] = radif - 1;
                    radif++;
                }
            }

        }

        private void SetModem()
        {
            int _rowcount;
            _rowcount = _agent.Modem.Length;
            modemRow = new int[_rowcount];
            string mo = lg.GetMessageFromDll(_langCode, "Modem");
            for (int i = 0; i < _rowcount; i++)
            {
                string _sn = "";
                _sn = _agent.ModemSerialNumber[i].Trim();
                if (_agent.Modem[i].Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, mo, 6, 1, _agent.Modem[i].Trim(), _sn, ""));
                    modemRow[i] = radif - 1;
                    radif++;
                }
            }

        }

        private void SetCdRom()
        {
            int _rowcount;
            _rowcount = _agent.CDRomName.Length;
            cdromRow = new int[_rowcount];
            string cd = lg.GetMessageFromDll(_langCode, "CdRom");
            for (int i = 0; i < _rowcount; i++)
            {
                string _sn = "";
                _sn = _agent.CDRomSerialNumber[i].Trim();
                if (_agent.CDRomName[i].Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, cd, 7, 1, _agent.CDRomName[i].Trim(), _sn, ""));
                    cdromRow[i] = radif - 1;
                    radif++;
                }
            }

        }

        private void SetNetAdapter()
        {
            int _rowcount;
            _rowcount = _agent.NetDescription.Length;
            netRow = new int[_rowcount];
            string lan = lg.GetMessageFromDll(_langCode, "NetAdapter");
            for (int i = 0; i < _rowcount; i++)
            {
                string _sn = "";
                _sn = _agent.NetSerialNumber[i].Trim();
                if (_agent.NetDescription[i].Trim() != "")
                {
                    InCaseDeviceList.Add(new AgentInCaseDevices(radif, lan, 8, 1, _agent.NetDescription[i].Trim(), _sn, ""));
                    netRow[i] = radif - 1;
                    radif++;
                }
            }

        }

        private void SetChildGrid()
        {
            GridViewTemplate template = new GridViewTemplate();
            template.DataSource = InCaseDeviceList;

            template.Columns[2].IsVisible = false;
            template.Columns[3].IsVisible = false;
            template.Columns[6].IsVisible = false;

            template.Columns[0].HeaderText = HCradif;
            template.Columns[1].HeaderText = HCUnitName;
            template.Columns[2].HeaderText = "DeviceId";
            template.Columns[3].HeaderText = "ParentDeviceId";
            template.Columns[4].HeaderText = HCmodel;
            template.Columns[5].HeaderText = HCserial;
            template.Columns[6].HeaderText = HCasset;


            template.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            template.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].TextAlignment = ContentAlignment.MiddleRight;
            template.Columns[4].TextAlignment = ContentAlignment.MiddleRight;
            template.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
            template.ReadOnly = false;

            template.AllowAddNewRow = false;
            template.AllowDeleteRow = false;

            template.AllowEditRow = true;
            


            template.Columns[0].MaxWidth = 40;
            template.Columns[0].MinWidth = 39;

            template.Columns[1].MaxWidth = 150;
            template.Columns[1].MinWidth = 149;

            template.Columns[4].MinWidth = 300;

            template.Columns[5].MaxWidth = 350;
            template.Columns[5].MinWidth = 349;


            template.AllowDragToGroup = true;       

          
            radGridView1.MasterTemplate.Templates.Add(template);
            

            GridViewRelation relation = new GridViewRelation(radGridView1.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "InCaseDevises";
            relation.ParentColumnNames.Add("DeviceId");
            relation.ChildColumnNames.Add("ParentDeviceId");
            radGridView1.Relations.Add(relation);
        }       

        private void SetMasterGrid()
        {
            radGridView1.DataSource = DeviceList;

            radGridView1.Columns[2].IsVisible = false;
            radGridView1.Columns[6].IsVisible = false;

            radGridView1.Columns[0].HeaderText = HCradif;
            radGridView1.Columns[1].HeaderText = HCdeviceName;
            radGridView1.Columns[2].HeaderText = "DeviceId";
            radGridView1.Columns[3].HeaderText = HCmodel;
            radGridView1.Columns[4].HeaderText = HCserial;
            radGridView1.Columns[5].HeaderText = HCasset;
           


            radGridView1.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleRight;
            radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;

            radGridView1.Columns[0].ReadOnly = true;
            radGridView1.Columns[1].ReadOnly = true;
            radGridView1.Columns[2].ReadOnly = true;
            
            radGridView1.Columns[0].MaxWidth = 40;
            radGridView1.Columns[0].MinWidth = 39;

            radGridView1.Columns[1].MaxWidth = 200;
            radGridView1.Columns[1].MinWidth = 199;

            radGridView1.Columns[3].MinWidth = 300;

            radGridView1.Columns[4].MaxWidth = 200;
            radGridView1.Columns[4].MinWidth = 199;

            radGridView1.Columns[5].MaxWidth = 100;
            radGridView1.Columns[5].MinWidth = 99;

            radGridView1.AllowDragToGroup = true;

            


            this.radGridView1.TableElement.EndUpdate(true);
        }

        private void SetHeaderColumnsText()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AssetNumber");

            HCradif = lg.GetMessageFromDll(_langCode, "radif");
            HCdeviceName = lg.GetMessageFromDll(_langCode, "DeviceName");

            HCmodel = lg.GetMessageFromDll(_langCode, "Model");
            HCserial = lg.GetMessageFromDll(_langCode, "lblSerialNumber");
            HCasset = lg.GetMessageFromDll(_langCode, "AssetNumber");
            HCUnitName = lg.GetMessageFromDll(_langCode, "UnitName");

            _groupPanelText = lg.GetMessageFromDll(_langCode, "GridViewGroupPanel");

            _Copy = lg.GetMessageFromDll(_langCode, "Copy");
            _Paste = lg.GetMessageFromDll(_langCode, "Paste");
            _Edit = lg.GetMessageFromDll(_langCode, "Edit");
            _ClearValue = lg.GetMessageFromDll(_langCode, "CleareValue");


            
        }

        private void SetMasterList()
        {
            DeviceList = new List<AgentDevicesList>();
            InCaseDeviceList = new List<AgentInCaseDevices>();
            if (_agent.AgentType == "Desktop")
            {
                SetCaseBox();
                SetMonitorDevices();
                SetKeyboardDevices();
                SetPrinterDevices();
                SetScannerDevices();
                SetMouseDevices();
                SetWebcamDevices();
            }
            if (_agent.AgentType == "Notebook")
            {
                SetLabTop();
            }            
        }

        private void SetLabTop()
        {
            string Case = lg.GetMessageFromDll(_langCode, "Labtop");

            if (_agent.DeviceId != null)
            {
                int index = Array.IndexOf(_agent.DeviceId, 1);
                if (index != -1)
                {
                    DeviceList.Add(new AgentDevicesList(radif, Case, 1, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index],_agent.AssetTableId[index]));
                    radif++;
                }
                else
                {
                    DeviceList.Add(new AgentDevicesList(radif, Case, 1,_agent.MotherboardCaption.Trim() , "", "",""));
                    radif++;
                }
            }
            else
            {
                DeviceList.Add(new AgentDevicesList(radif, Case, 1, _agent.MotherboardCaption.Trim(), "", "",""));
                radif++;
            }

        }

        private void SetCaseBox()
        {
            string Case = lg.GetMessageFromDll(_langCode, "Case");

            if (_agent.DeviceId != null)
            {
                int index = Array.IndexOf(_agent.DeviceId, 1);
                if (index != -1)
                {
                    DeviceList.Add(new AgentDevicesList(radif, Case, 1, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index],_agent.AssetTableId[index]));
                    radif++;
                }
                else
                {
                    DeviceList.Add(new AgentDevicesList(radif, Case, 1, "", "", "",""));
                    radif++;
                }
            }
            else
            {
                DeviceList.Add(new AgentDevicesList(radif, Case, 1, "", "", "",""));
                radif++;
            }           
            
        }

        private void SetMonitorDevices()
        {
            int _rowcount;
            _rowcount = 1;
            string Monitor = lg.GetMessageFromDll(_langCode, "Monitor");

            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Monitor.Trim() != "")
                {                    
                    if (_agent.DeviceId != null)
                    {
                        int index = Array.IndexOf(_agent.DeviceId, 2);
                        if (index != -1)
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Monitor, 2, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                            radif++;
                        }
                        else
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Monitor, 2, _agent.Monitor, "", "",""));
                            radif++;
                        }
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Monitor, 2, _agent.Monitor, "", "",""));
                        radif++;
                    }
                   
                }
                
            }          

        }

        private void SetKeyboardDevices()
        {
            int _rowcount;
            _rowcount = 1;
            string Keyboard = lg.GetMessageFromDll(_langCode, "Keyboard");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Keyboard.Trim() != "")
                {
                    if (_agent.DeviceId != null)
                    {
                        int index = Array.IndexOf(_agent.DeviceId, 3);
                        if (index != -1)
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Keyboard, 3, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                            radif++;
                        }
                        else
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Keyboard, 3, _agent.Keyboard, "", "",""));
                            radif++;
                        }
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Keyboard, 3, _agent.Keyboard, "", "",""));
                        radif++;
                    }                    
                }                
            }
        }

        private void SetPrinterDevices()
        {
            int _rowcount;
            _rowcount = _agent.PrinterName.Length;
            string Printer = lg.GetMessageFromDll(_langCode, "Printer");

            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.PrinterNetwork[i] == "Local" && _agent.PrinterName[i].Contains("Fax") == false && _agent.PrinterName[i].Contains("Microsoft XPS") == false && _agent.PrinterName[i].Contains("OneNote") == false)
                {
                    if (_agent.DeviceId != null)
                    {
                       int index = Array.IndexOf(_agent.DeviceId, 5);
                       if (index != -1)
                       {
                           index = Array.IndexOf(_agent.DeviceModel, _agent.PrinterName[i]);
                           if (index != -1)
                           {
                               DeviceList.Add(new AgentDevicesList(radif, Printer, 5, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                               radif++; 
                           }
                           else
                           {
                               DeviceList.Add(new AgentDevicesList(radif, Printer, 5, _agent.PrinterName[i], "", "",""));
                               radif++;
                           }
                       }
                       else
                       {
                           DeviceList.Add(new AgentDevicesList(radif, Printer, 5, _agent.PrinterName[i], "", "",""));
                           radif++;
                       }
                        
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Printer, 5, _agent.PrinterName[i], "", "",""));
                        radif++;
                    }

                    
                }
               
            }     

        }

        private void SetScannerDevices()
        {
            int _rowcount;
            _rowcount = 1;
            string Scanner = lg.GetMessageFromDll(_langCode, "Scanner");

            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Scanner.Trim() != "")
                {
                    if (_agent.DeviceId != null)
                    {
                        int index = Array.IndexOf(_agent.DeviceId, 6);
                        if (index != -1)
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Scanner, 6, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                            radif++;
                        }
                        else
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Scanner, 6, _agent.Scanner, "", "",""));
                            radif++;
                        }
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Scanner, 6, _agent.Scanner, "", "",""));
                        radif++;
                    }                    
                }
                
            }        

        }

        private void SetMouseDevices()
        {
            int _rowcount;
            _rowcount = 1;
            string Mouse = lg.GetMessageFromDll(_langCode, "Mouse");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Mouse.Trim() != "")
                {
                    if (_agent.DeviceId != null)
                    {
                        int index = Array.IndexOf(_agent.DeviceId, 4);
                        if (index != -1)
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Mouse, 4, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                            radif++;
                        }
                        else
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Mouse, 4, _agent.Mouse, "", "",""));
                            radif++;
                        }
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Mouse, 4, _agent.Mouse, "", "",""));
                        radif++;
                    }
                                    
                }
               
            }      

        }

        private void SetWebcamDevices()
        {
            int _rowcount;
            _rowcount = 1;
            string Webcam = lg.GetMessageFromDll(_langCode, "Camera");
            for (int i = 0; i < _rowcount; i++)
            {
                if (_agent.Camera.Trim() != "")
                {
                    if (_agent.DeviceId != null)
                    {
                        int index = Array.IndexOf(_agent.DeviceId, 7);
                        if (index != -1)
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Webcam, 7, _agent.DeviceModel[index], _agent.DeviceSerialNumber[index], _agent.DeviceAssetNumber[index], _agent.AssetTableId[index]));
                            radif++;
                        }
                        else
                        {
                            DeviceList.Add(new AgentDevicesList(radif, Webcam, 7, _agent.Camera, "", "",""));
                            radif++;
                        }
                    }
                    else
                    {
                        DeviceList.Add(new AgentDevicesList(radif, Webcam, 7, _agent.Camera, "", "",""));
                        radif++;
                    }
                    
                }
               
            }

        }

        private void frmAgentAssets_RtoL_Shown(object sender, EventArgs e)
        {            
            this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
            int rc = radGridView1.Rows.Count;
            int rc2 = radGridView1.MasterTemplate.Templates[0].RowCount;

            IsFirstSave = new bool[rc];
            IsFirstSaveChild = new bool[rc2];

            for (int i = 1; i < rc; i++)
            {
                radGridView1.Rows[i].Cells[3].ReadOnly = true;
            }

            for (int n = 0; n < rc; n++)
            {
                if (radGridView1.Rows[n].Cells[5].Value.ToString().Trim() != "" && radGridView1.Rows[n].Cells[6].Value.ToString().Trim() != "")
                {
                    IsFirstSave[n] = false;
                }
                if (radGridView1.Rows[n].Cells[5].Value.ToString().Trim() == "" && radGridView1.Rows[n].Cells[6].Value.ToString().Trim() == "")
                {
                    IsFirstSave[n] = true;
                }                
            }

            for (int y = 0; y < rc2; y++)
            {
                if (radGridView1.MasterTemplate.Templates[0].Rows[y].Cells[5].Value.ToString().Trim() != "")
                {
                    IsFirstSaveChild[y] = false;
                }
                if (radGridView1.MasterTemplate.Templates[0].Rows[y].Cells[5].Value.ToString().Trim() == "")
                {
                    IsFirstSaveChild[y] = true;
                }
            }


                //set read only for templete gridview
                radGridView1.MasterTemplate.Templates[0].Columns[0].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Columns[1].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Columns[2].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Columns[3].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Columns[6].ReadOnly = true;

            // cpu model and serial
            radGridView1.MasterTemplate.Templates[0].Rows[0].Cells[4].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Rows[0].Cells[5].ReadOnly = true;

            //mainboard model and serial
            radGridView1.MasterTemplate.Templates[0].Rows[1].Cells[4].ReadOnly = true;
            radGridView1.MasterTemplate.Templates[0].Rows[1].Cells[5].ReadOnly = true;

            //harddisk model and serial
            for (int i = 0; i < harddiskRow.Length; i++)
            {
                radGridView1.MasterTemplate.Templates[0].Rows[harddiskRow[i]].Cells[4].ReadOnly = true;
                radGridView1.MasterTemplate.Templates[0].Rows[harddiskRow[i]].Cells[5].ReadOnly = true;
            }

            //memory model and serial
            for (int m = 0; m < memoryRow.Length; m++)
            {
                radGridView1.MasterTemplate.Templates[0].Rows[memoryRow[m]].Cells[4].ReadOnly = false;
                radGridView1.MasterTemplate.Templates[0].Rows[memoryRow[m]].Cells[5].ReadOnly = false;
            }

            //videocard model and serial
            for (int i = 0; i < videocardRow.Length; i++)
            {
                radGridView1.MasterTemplate.Templates[0].Rows[videocardRow[i]].Cells[4].ReadOnly = true;                
            }

            //videocard model and serial
            for (int i = 0; i < videocardRow.Length; i++)
            {
                radGridView1.MasterTemplate.Templates[0].Rows[videocardRow[i]].Cells[4].ReadOnly = true;
            }

            if (_agent.Modem.Length != 0)
            {
                for (int i = 0; i < modemRow.Length; i++)
                {
                    radGridView1.MasterTemplate.Templates[0].Rows[modemRow[i]].Cells[4].ReadOnly = true;
                }
            }

            if (_agent.CDRomName.Length != 0)
            {
                for (int i = 0; i < cdromRow.Length; i++)
                {
                    radGridView1.MasterTemplate.Templates[0].Rows[cdromRow[i]].Cells[4].ReadOnly = true;
                }
            }

            if (_agent.NetDescription.Length != 0)
            {
                for (int i = 0; i < netRow.Length; i++)
                {
                    radGridView1.MasterTemplate.Templates[0].Rows[netRow[i]].Cells[4].ReadOnly = true;
                }
            }
            
           
        }             

        private void radGridView1_GroupByChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            if (e.GridViewTemplate.GroupDescriptors.Count == 0)
            {
                this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (User.UserClassifyID >= _agent.acl22)
            {
                SaveMasterGridItems();
                SaveChildGridItems();
                CheckSaveError();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedToAgentMsg, 2);
                frmmsg.ShowDialog();
            }
        } 
      
        private void SaveMasterGridItems()
        {
            int _rowCount;
            _rowCount = radGridView1.RowCount;

            for (int i = 0; i < _rowCount; i++)
            {
                if (radGridView1.Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.Rows[i].Cells[4].Value.ToString().Trim() != "")
                {
                    SaveWhenAssetAndSerialNotNull(i);
                }
                else if (radGridView1.Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.Rows[i].Cells[2].Value.ToString().Trim() == "1")
                {
                    SaveWhenAssetNotNullAndDeviceIsCase(i);
                }
                else if (radGridView1.Rows[i].Cells[5].Value.ToString().Trim() == "" && IsFirstSave[i] == false)
                {
                    DeleteAssetFromSql(i);
                }
            }

        }

        private void SaveChildGridItems()
        {
             int _rowCount;
            _rowCount = radGridView1.MasterTemplate.Templates[0].RowCount;
            string _idcell,_model,_sn = "";
            int memoryIndex,VideoCardIndex,CdromIndex,ModemIndex,NetIndex;
            memoryIndex = 0;
            VideoCardIndex = 0;
            CdromIndex = 0;
            ModemIndex = 0;
            NetIndex = 0;

            for (int i = 0; i < _rowCount; i++)
            {
                _idcell = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[2].Value.ToString().Trim();                              
                switch (_idcell)
                {
                    case "4":
                        {
                            if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value != null)
                            {
                                if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != _agent.MemorySerialNumber[memoryIndex].Trim())
                                {
                                    _model = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim();
                                    _sn = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim();
                                    UpdateMemoryModelAndSNInSql(_model, _sn, memoryIndex);
                                }
                            }
                            memoryIndex++;
                            break;
                        }
                    case "5":
                        {
                            if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value != null)
                            {
                                if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != _agent.VideoCardSerialNumber[VideoCardIndex].Trim())
                                {
                                    _model = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim();
                                    _sn = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim();
                                    UpdateVideoCardSNInSql(VideoCardIndex, _sn, _model);
                                }
                            }
                            VideoCardIndex++;
                            break;
                        }
                    case "6":
                        {
                            if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != _agent.ModemSerialNumber[ModemIndex].Trim())
                            {
                                _model = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim();
                                _sn = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim();
                                UpdateModemSNInSql(ModemIndex, _sn,_model);
                            }
                            ModemIndex++;
                            break;
                        }
                    case "7":
                        {
                            if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value != null)
                            {
                                if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != _agent.CDRomSerialNumber[CdromIndex].Trim())
                                {
                                    _model = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim();
                                    _sn = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim();
                                    UpdateCdromSNInSql(CdromIndex, _sn, _model);
                                }
                            }
                            CdromIndex++;
                            break;
                        }
                    case "8":
                        {
                            if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value != null)
                            {
                                if (radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != "" && radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim() != _agent.NetSerialNumber[NetIndex].Trim())
                                {
                                    _model = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[4].Value.ToString().Trim();
                                    _sn = radGridView1.MasterTemplate.Templates[0].Rows[i].Cells[5].Value.ToString().Trim();
                                    UpdateNetSNInSql(NetIndex, _sn, _model);
                                }
                            }
                            NetIndex++;
                            break;
                        }
                }           
               
            }
        }
       
        private void SaveWhenAssetAndSerialNotNull(int index)
        {
            int i = index;
            int result;
            string DeviceId, DeviceModel, DeviceSerialNumber, AssetNumber,TableId;

            DeviceId = radGridView1.Rows[i].Cells[2].Value.ToString().Trim();
            DeviceModel = radGridView1.Rows[i].Cells[3].Value.ToString().Trim();
            DeviceSerialNumber = radGridView1.Rows[i].Cells[4].Value.ToString().Trim();
            AssetNumber = radGridView1.Rows[i].Cells[5].Value.ToString().Trim();
            TableId = radGridView1.Rows[i].Cells[6].Value.ToString().Trim();
            if (IsFirstSave[i] == true)
            {
                result = lg.SaveAgentAssetNumberToSql(_agent.AgentID, DeviceId, DeviceModel, DeviceSerialNumber, AssetNumber);
                if (result == 0 || result == 3)
                {
                    _resultList.Add(radGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    _resultInt.Add(result);
                }
            }
            if (IsFirstSave[i] == false)
            {
                result = lg.UpdateAgentAssetNumberInSql(DeviceModel, DeviceSerialNumber, AssetNumber,TableId);
                if (result == 0 || result == 3)
                {
                    _resultList.Add(radGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    _resultInt.Add(result);
                }

            }
        }
       
        private void SaveWhenAssetNotNullAndDeviceIsCase(int index)
        {
            int i = index;
            int result;
            string DeviceId, DeviceModel, DeviceSerialNumber, AssetNumber,TableId;

            DeviceId = radGridView1.Rows[i].Cells[2].Value.ToString().Trim();
            DeviceModel = radGridView1.Rows[i].Cells[3].Value.ToString().Trim();
            DeviceSerialNumber = radGridView1.Rows[i].Cells[4].Value.ToString().Trim();
            AssetNumber = radGridView1.Rows[i].Cells[5].Value.ToString().Trim();
            TableId = radGridView1.Rows[i].Cells[6].Value.ToString().Trim();

            if (IsFirstSave[i] == true)
            {
                result = lg.SaveAgentAssetNumberToSql(_agent.AgentID, DeviceId, DeviceModel, DeviceSerialNumber, AssetNumber);
                if (result == 0 || result == 3)
                {
                    _resultList.Add(radGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    _resultInt.Add(result);
                }
            }
            if (IsFirstSave[i] == false)
            {
                result = lg.UpdateAgentAssetNumberInSql(DeviceModel, DeviceSerialNumber, AssetNumber,TableId);
                if (result == 0 || result == 3)
                {
                    _resultList.Add(radGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    _resultInt.Add(result);
                }

            }

        }

        private void UpdateMemoryModelAndSNInSql(string MemoryModel,string MemorySN,int TableIdIndex)
        {           
            int result;
            string TableId;
            TableId = _agent.MemoryTableId[TableIdIndex].Trim();

            result = lg.UpdateMemoryDetailsInSql(TableId, MemoryModel, MemorySN);
            if (result == 0)
            {
                _resultList.Add(MemoryModel);
                _resultInt.Add(result);
            }
        }

        private void UpdateVideoCardSNInSql( int TableIdIndex, string VideoCardSN,string Model)
        {
            int result;
            string TableId;
            TableId = _agent.VideoCardTableId[TableIdIndex].Trim();

            result = lg.UpdateVideoCardSNInSql(TableId, VideoCardSN);
            if (result == 0)
            {
                _resultList.Add(Model);
                _resultInt.Add(result);
            }
        }

        private void UpdateModemSNInSql(int TableIdIndex, string ModemSN, string Model)
        {
            int result;
            string TableId;
            TableId = _agent.ModemTableId[TableIdIndex].Trim();

            result = lg.UpdateModemSNInSql(TableId, ModemSN);
            if (result == 0)
            {
                _resultList.Add(Model);
                _resultInt.Add(result);
            }
        }

        private void UpdateCdromSNInSql(int TableIdIndex, string CdromSN, string Model)
        {
            int result;
            string TableId;
            TableId = _agent.CDRomTableId[TableIdIndex].Trim();

            result = lg.UpdateCdromSNInSql(TableId, CdromSN);
            if (result == 0)
            {
                _resultList.Add(Model);
                _resultInt.Add(result);
            }
        }

        private void UpdateNetSNInSql(int TableIdIndex, string NetSN, string Model)
        {
            int result;
            string TableId;
            TableId = _agent.NetTableId[TableIdIndex].Trim();

            result = lg.UpdateNetSNInSql(TableId, NetSN);
            if (result == 0)
            {
                _resultList.Add(Model);
                _resultInt.Add(result);
            }
        }
              
        private void CheckSaveError()
        {
            if (_resultList.Count != 0)
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();

            }
            if (_resultList.Count == 0)
            {
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
            }

        }

        private void DeleteAssetFromSql(int Index)
        {
            int i = Index;
            int result;
            string TableId;

            TableId = radGridView1.Rows[i].Cells[6].Value.ToString().Trim();

            result = lg.DeleteAssetNumberFromSql(TableId);
            if (result == 0)
            {
                _resultList.Add(radGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                _resultInt.Add(result);
            }
        }

        private void radGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            for (int i = 0; i < e.ContextMenu.Items.Count; i++)
            {
                if (e.ContextMenu.Items[i].Text == "Copy")
                {
                    e.ContextMenu.Items[i].Text = _Copy;
                    e.ContextMenu.Items[i].Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                   
                }
                if (e.ContextMenu.Items[i].Text == "Paste")
                {
                    e.ContextMenu.Items[i].Text = _Paste;
                    e.ContextMenu.Items[i].Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                if (e.ContextMenu.Items[i].Text == "Edit")
                {
                    e.ContextMenu.Items[i].Text = _Edit;
                    e.ContextMenu.Items[i].Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                if (e.ContextMenu.Items[i].Text == "Clear Value")
                {
                    e.ContextMenu.Items[i].Text = _ClearValue;
                    e.ContextMenu.Items[i].Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

            }
        }

              
    }
}
