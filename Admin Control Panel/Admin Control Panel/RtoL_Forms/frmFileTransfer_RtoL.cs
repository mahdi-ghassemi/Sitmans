using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using System.Net;
using System.Collections;





namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmFileTransfer_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private bool IsFirstLoad;
        private Agents _selectedAgent1;
        private Agents _selectedAgent2;
        private string activeIP1;
        private string activeIP2;
        private string MyIpAddress;
        private int TreeViewId;
        



        public frmFileTransfer_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            IsFirstLoad = true;
            InitializeComponent();
        }

        private void frmFileTransfer_RtoL_Load(object sender, EventArgs e)
        {
            List<Agents> newAgentList = new List<Agents>();
            for (int i = 0 ; i < Program.AgentList.Count ; i++)
            {
                newAgentList.Add(Program.AgentList[i]);            
            }

            TreeViewId = 0;
            
            FillForm();
            DisableButtoms();
            ddlSender1.DataSource = null;
            ddlSender1.Items.Clear();
            ddlSender1.DataSource = Program.AgentList;
            ddlSender1.DisplayMember = "ComputerName";
            ddlSender1.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;


            ddlAgents2.DataSource = null;
            ddlAgents2.Items.Clear();
            ddlAgents2.DataSource = newAgentList;
            ddlAgents2.DisplayMember = "ComputerName";
            ddlAgents2.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;

            trvDir1.PathSeparator = "\\";
            trvAgent2.PathSeparator = "\\";
           
           

        }

        private void DisableButtoms()
        {
            btnCopyLtoR.Enabled = false;
            btnCopyRtoL.Enabled = false;
            btnDelete.Enabled = false;
            btnExecute.Enabled = false;
            btnNewFolder.Enabled = false;
            btnRefresh.Enabled = false;        
        }

        private void FillForm()
        {
            LogicLayer ll = new LogicLayer();
            this.Text = ll.GetMessageFromDll(_langCode, "FileTransfer");
            lblSender1.Text = ll.GetMessageFromDll(_langCode, "System");
            lblPath1.Text = ll.GetMessageFromDll(_langCode, "FilePath");
            btnCopyLtoR.Text = ll.GetMessageFromDll(_langCode, "Send");
            btnCopyRtoL.Text = btnCopyLtoR.Text;
            btnDelete.Text = ll.GetMessageFromDll(_langCode, "Delete");
            btnExecute.Text = ll.GetMessageFromDll(_langCode, "Execute");
            btnNewFolder.Text = ll.GetMessageFromDll(_langCode, "NewFolder");
            btnRefresh.Text = ll.GetMessageFromDll(_langCode, "Refresh");

            lblSender2.Text = lblSender1.Text;
            lblPath2.Text = lblPath1.Text;
        }

        

        private void ddlSender1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {            
            if (IsFirstLoad == false)
            {
                trvDir1.Nodes.Clear();
                LogicLayer ll = new LogicLayer();
                int _selectIndex1 = ddlSender1.SelectedIndex;
                _selectedAgent1 = Program.AgentList[_selectIndex1];
                ArrayList ip = ll.GetActiveIPV4Address(_selectedAgent1);
                activeIP1 = ip[0].ToString();

                try
                {
                    int len = _selectedAgent1.LogicDiskCaption.Length;
                    FillPartitionList(_selectedAgent1);

                }
                catch (NullReferenceException)
                {
                    GetLogicDiskList(_selectedAgent1);
                    FillPartitionList(_selectedAgent1);
                }
            }          
        }

        private void GetLogicDiskList(Agents _agent)
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();

            sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLagicDisk.ToString();
            dt = sql.ExcecuteQueryToDataTable(_agent.AgentID);
            int _rowCount = dt.Rows.Count;

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
        }



        private void FillPartitionList(Agents _selectedAgent)
        {
            int len = _selectedAgent.LogicDiskCaption.Length;
            int _nodeIndex;
            TreeViewId = 1;
            
            for (int i = 0; i < len; i++)
            {
                if (_selectedAgent.LogicDiskDescription[i].Contains("CD-ROM") == false)
                {
                    trvDir1.Nodes.Add(_selectedAgent.LogicDiskCaption[i]);
                    trvDir1.Nodes[i].Image = imlIcon.Images[0];
                    _nodeIndex = trvDir1.Nodes[i].Index;

                    FillPartitionContents(_selectedAgent, _selectedAgent.LogicDiskCaption[i], _nodeIndex);
                  
                }
            }        

        }

        private void FillPartitionContents(Agents SelectedAgent,string PartitionDrive,int NodeIndex)
        {
            LogicLayer ll = new LogicLayer();
            Com c = new Com();
            MyIpAddress = ll.LocalIPAddress();
            ArrayList ip = ll.GetActiveIPV4Address(SelectedAgent);
            c.DestiniIp = ip[0].ToString();
            c.DestiniPort = Program.Port;
            c.SockType = "Tcp";
            c.SendData("GETDI" + PartitionDrive + "/" + MyIpAddress + "&" + NodeIndex.ToString());

            
        }



        private void GetDirectoryFromAgent(string Path, int NodeIndex)
        {
            Com c = new Com();
            if(TreeViewId == 1)
                c.DestiniIp = activeIP1;
            if (TreeViewId == 2)
                c.DestiniIp = activeIP2;
            c.DestiniPort = Program.Port;
            c.SockType = "Tcp";
            c.SendData("GETDI" + Path + "/" + MyIpAddress + "&" + NodeIndex.ToString());
        }      

        private void ddlSender1_Click(object sender, EventArgs e)
        {
            IsFirstLoad = false;
        }

        private int GetLevelFromPath(string FullPath)
        {
            int _level = 0;
            int _index = 0;
            _index = FullPath.IndexOf("\\");
            while (_index != -1)
            {
                _level++;
                FullPath = FullPath.Remove(0, _index + 1);
                _index = FullPath.IndexOf("\\");

            }
            return _level;
        }


       // OKKKKKKKK Here

        public void GetNodeslist(string List)
        {
            /*
            [Node0:C:\Users]
            [22;$Recycle.Bin]
            [18;ASUS.DAT]
            [32;autoexec.bat]
            [32;config.sys]
            [9238;Documents and Settings]
            [16;Downloads]
            [16;eSupport]
            [8230;hiberfil.sys]
            [16;Intel]
            [38;pagefile.sys]
            [16;PerfLogs]
            [17;Program Files]
            [8210;ProgramData]
            [32;PTigerReport.txt]
            [8214;Recovery]
            [32;RHDSetup.log]
            [32;setup.iss]
            [32;setup.log]
            [22;System Volume Information]
            [17;Users]
            [32;USetup.iss]
            [16;Windows]
             */
            string _ParentNode = "";
            string _ChildNode = "";
            string _type = "";
            string _nodeIndex;
            int _nodeLevel;


            int _sIndex, _eIndex, _kIndex, NodeIndex;

            _sIndex = List.IndexOf(':');
            _nodeIndex = List.Substring(5, _sIndex - 5);

            NodeIndex = Convert.ToInt32(_nodeIndex);

            _eIndex = List.IndexOf(']');
            _ParentNode = List.Substring(_sIndex + 1, (_eIndex - _sIndex - 1));

            List = List.Remove(0, _eIndex + 1);

            _sIndex = List.IndexOf('[');

            _nodeLevel = GetLevelFromPath(_ParentNode);


            while (_sIndex != -1)
            {
                _kIndex = List.IndexOf(';');
                _eIndex = List.IndexOf(']');
                _type = List.Substring(1, (_kIndex - 1));
                _ChildNode = List.Substring((_kIndex + 1), (_eIndex - _kIndex - 1));
                if (_nodeLevel == 0)
                {
                    InsertNodeToTree(_ParentNode, _ChildNode, _type, NodeIndex);
                }
                else
                {
                    InsertNodeToTree(_ParentNode, _ChildNode, _type, NodeIndex, _nodeLevel);
                }

                List = List.Remove(0, _eIndex + 1);
                _sIndex = List.IndexOf('[');
            }
        }

        private void InsertNodeToTree(string ParentNode, string ChildNode, string NodeType, int NodeIndex)
        {
            if (TreeViewId == 1)
            {

                if ((NodeType == "32") || (NodeType == "38") || (NodeType == "8230"))
                {
                    trvDir1.Nodes[NodeIndex].Nodes.Add(ChildNode);
                    if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                    {
                        trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                        trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                    }
                    else
                    {
                        //trvDir.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];

                    }
                }
                else
                {
                    if (trvDir1.Nodes[NodeIndex].Nodes[""] != null)
                    {
                        int Oldindex = trvDir1.Nodes[NodeIndex].Nodes[""].Index;
                        trvDir1.Nodes[NodeIndex].Nodes.Add(ChildNode);
                        int Newindex = trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Index;
                        trvDir1.Nodes[NodeIndex].Nodes.Move(Newindex, Oldindex);
                        if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                        {
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                        }
                        else
                        {
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                        }

                    }
                    else
                    {
                        trvDir1.Nodes[NodeIndex].Nodes.Add(ChildNode);
                        trvDir1.Nodes[NodeIndex].Nodes.Add("");
                        trvDir1.Nodes[NodeIndex].Nodes[""].Visible = false;

                        if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                        {
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                        }
                        else
                        {
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                            trvDir1.Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                        }
                    }
                }
            }

            if (TreeViewId == 2)
            {
                if ((NodeType == "32") || (NodeType == "38") || (NodeType == "8230"))
                {
                    trvAgent2.Nodes[NodeIndex].Nodes.Add(ChildNode);
                    if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                    {
                        trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                        trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                    }
                    else
                    {
                        //trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];

                    }
                }
                else
                {
                    if (trvAgent2.Nodes[NodeIndex].Nodes[""] != null)
                    {
                        int Oldindex = trvAgent2.Nodes[NodeIndex].Nodes[""].Index;
                        trvAgent2.Nodes[NodeIndex].Nodes.Add(ChildNode);
                        int Newindex = trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Index;
                        trvAgent2.Nodes[NodeIndex].Nodes.Move(Newindex, Oldindex);
                        if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                        {
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                        }
                        else
                        {
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                        }

                    }
                    else
                    {
                        trvAgent2.Nodes[NodeIndex].Nodes.Add(ChildNode);
                        trvAgent2.Nodes[NodeIndex].Nodes.Add("");
                        trvAgent2.Nodes[NodeIndex].Nodes[""].Visible = false;

                        if (ChildNode.ToUpper().Contains("RECYCLE.BIN") == true)
                        {
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[1];
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Visible = false;
                        }
                        else
                        {
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                            trvAgent2.Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                        }
                    }
                }

            }
        }

        private void trvDir1_NodeMouseClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            int level;
            int nodeIndex;
            string nodeImageKey;
            string nodeText;
            string path;
            int nodeCount;

            TreeViewId = 1;

            path = trvDir1.SelectedNode.FullPath;
            nodeCount = e.Node.GetNodeCount(true);


           

            level = e.Node.Level;

            if (level == 0)
            {
                txbPath1.Text = path + "\\";
            }
            else
                txbPath1.Text = path;

            nodeIndex = e.Node.Index;
            nodeImageKey = e.Node.ImageKey;
            nodeText = e.Node.Text;

            if ((nodeImageKey != "Folder") && (level != 0) && (txbPath2.Text != ""))
                btnCopyRtoL.Enabled = true;
            if (nodeImageKey == "Folder")
                btnCopyRtoL.Enabled = false;


           
            if (level > 0 && nodeCount == 0 && nodeImageKey == "Folder")
            {
                GetDirectoryFromAgent(path, nodeIndex);
            }
            if (level == 0)
            {
                e.Node.Expand();
            }
        }       

        private void InsertNodeToTree(string Path,string ChildNode,string NodeType,int NodeIndex,int Nodelevel)
        {
            if (TreeViewId == 1)
            {
                if (ChildNode != "..")
                {
                    if (ChildNode != ".")
                    {
                        switch (Nodelevel)
                        {
                            case 1:
                                {
                                    string _root1 = Path.Substring(0, 2);

                                    if (NodeType != "32")
                                    {
                                        if (trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[""] != null)
                                        {
                                            int Oldindex = trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[""].Index;
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                            int Newindex = trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Index;
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes.Move(Newindex, Oldindex);
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";

                                        }
                                        else
                                        {
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                                        }
                                    }
                                    if (NodeType == "32")
                                    {

                                        if (trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[""] == null)
                                        {
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes.Add("");
                                            trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes[""].Visible = false;
                                        }

                                        trvDir1.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                        //trvDir.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[?];
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    break;
                                }
                        }

                        trvDir1.Update();
                    }
                }
            }
            if (TreeViewId == 2)
            {
                if (ChildNode != "..")
                {
                    if (ChildNode != ".")
                    {
                        switch (Nodelevel)
                        {
                            case 1:
                                {
                                    string _root1 = Path.Substring(0, 2);

                                    if (NodeType != "32")
                                    {
                                        if (trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[""] != null)
                                        {
                                            int Oldindex = trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[""].Index;
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                            int Newindex = trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Index;
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes.Move(Newindex, Oldindex);
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";

                                        }
                                        else
                                        {
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[2];
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].ImageKey = "Folder";
                                        }
                                    }
                                    if (NodeType == "32")
                                    {

                                        if (trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[""] == null)
                                        {
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes.Add("");
                                            trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[""].Visible = false;
                                        }

                                        trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes.Add(ChildNode);
                                        //trvAgent2.Nodes[_root1].Nodes[NodeIndex].Nodes[ChildNode].Image = imlIcon.Images[?];
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    break;
                                }
                        }

                        trvAgent2.Update();
                    }
                }

            }
        }

        private void ddlAgents2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (IsFirstLoad == false)
            {
                trvAgent2.Nodes.Clear();
                LogicLayer ll = new LogicLayer();
                int _selectIndex2 = ddlAgents2.SelectedIndex;
                _selectedAgent2 = Program.AgentList[_selectIndex2];
                ArrayList ip = ll.GetActiveIPV4Address(_selectedAgent2);
                activeIP2 = ip[0].ToString();

                try
                {
                    int len = _selectedAgent2.LogicDiskCaption.Length;
                    FillPartitionList(_selectedAgent2);

                }
                catch (NullReferenceException)
                {
                    GetLogicDiskList(_selectedAgent2);
                    FillPartitionList2(_selectedAgent2);
                }
            }
        }

        private void FillPartitionList2(Agents _selectedAgent2)
        {
            int len = _selectedAgent2.LogicDiskCaption.Length;
            int _nodeIndex;
            TreeViewId = 2;

            for (int i = 0; i < len; i++)
            {
                if (_selectedAgent2.LogicDiskDescription[i].Contains("CD-ROM") == false)
                {
                    trvAgent2.Nodes.Add(_selectedAgent2.LogicDiskCaption[i]);
                    trvAgent2.Nodes[i].Image = imlIcon.Images[0];
                    _nodeIndex = trvAgent2.Nodes[i].Index;

                    FillPartitionContents(_selectedAgent2, _selectedAgent2.LogicDiskCaption[i], _nodeIndex);

                }
            }        
           
        }

        private void trvAgent2_NodeMouseClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            int level;
            int nodeIndex;
            string nodeImageKey;
            string nodeText;
            string path;
            int nodeCount;

            TreeViewId = 2;

            path = trvAgent2.SelectedNode.FullPath;
            nodeCount = e.Node.GetNodeCount(true);

          

            level = e.Node.Level;

            if (level == 0)
            {
                txbPath2.Text = path + "\\";
            }
            else
                txbPath2.Text = path;

            nodeIndex = e.Node.Index;
            nodeImageKey = e.Node.ImageKey;
            nodeText = e.Node.Text;

            if ((nodeImageKey != "Folder") && (level != 0) && (txbPath1.Text != ""))
                btnCopyLtoR.Enabled = true;
            if (nodeImageKey == "Folder")
                btnCopyLtoR.Enabled = false;


            if (level > 0 && nodeCount == 0 && nodeImageKey == "Folder")
            {
                GetDirectoryFromAgent(path, nodeIndex);
            }
            if (level == 0)
            {
                e.Node.Expand();
            }

        }

        private void ddlAgents2_Click(object sender, EventArgs e)
        {
            IsFirstLoad = false;
        }

        private void btnCopyRtoL_Click(object sender, EventArgs e)
        {
            string SendData;
            string sourceIP;
            string destiIP;
            

            sourceIP = activeIP1;
            destiIP = activeIP2;

            SendData = "FITRF[" + txbPath1.Text.Trim() + "][" + txbPath2.Text.Trim() + "][" + sourceIP + "][" + destiIP + "][" + trvDir1.SelectedNode.Text + "]";

            Com c = new Com();
            c.DestiniIp = sourceIP;
            c.DestiniPort = Program.Port;
            c.SockType = "Tcp";
            c.SendData(SendData);            
        }

       

      
    }
}
