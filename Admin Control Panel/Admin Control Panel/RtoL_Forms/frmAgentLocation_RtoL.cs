using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentLocation_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private Agents _agent;
        private LogicLayer lg;

        private List<string> Buildingtitle;
        private List<int> Buildingid;

        private List<string> Classtitle;
        private List<int> Classid;

        private List<string> Roomtitle;
        private List<int> Roomid;

        private List<string> Departmenttitle;
        private List<int> Departmentid;

        private bool DeleteEnable;
        private bool IsFirstSave;
        private bool DataChanged;

        private string BuilldingText;
        private string RoomText;
        private string ClassText;
        private string DepartmentText;
        


        public frmAgentLocation_RtoL(Agents Agent)
        {
            _agent = new Agents();
            _agent = Agent;
            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();
            DataChanged = false;

            Buildingtitle = new List<string>();
            Buildingid = new List<int>();

            Classtitle = new List<string>();
            Classid = new List<int>();

            Roomtitle = new List<string>();
            Roomid = new List<int>();

            Departmenttitle = new List<string>();
            Departmentid = new List<int>();

            InitializeComponent();

        }

        private void frmAgentLocation_RtoL_Load(object sender, EventArgs e)
        {           
            FillForm();
            BindData();
            DisableControls();
        }

        private void BindData()
        {            
            FillBuildingList();
            FillClasslist();
            FillRoomList();
            FillDepartmentList();            
        }

        private void DisableControls()
        {
            lblBuilding.Enabled = false;
            lblClass.Enabled = false;
            lblDepartment.Enabled = false;
            lblRoom.Enabled = false;

            cmbBuilding.Enabled = false;
            cmbClass.Enabled = false;
            cmbDepartment.Enabled = false;
            cmbRoom.Enabled = false;

            saveToolStripButton.Enabled = false;
            if (DeleteEnable == true)
                deleteToolStripButton.Enabled = true;
            else
                deleteToolStripButton.Enabled = false;


        }

        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "LocalAddressDefine");
            lblBuilding.Text = lg.GetMessageFromDll(_langCode, "Building");
            lblClass.Text = lg.GetMessageFromDll(_langCode, "Class");
            lblDepartment.Text = lg.GetMessageFromDll(_langCode, "Department");
            lblRoom.Text = lg.GetMessageFromDll(_langCode, "Room");

            openToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Edit");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");
            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            helpToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Help");

        }

        private void FillBuildingList()
        {
            DataTable dt = new DataTable();
            dt = lg.GetBuldingList();
            if (dt != null)
            {
                int row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    Buildingid.Add(Convert.ToInt32(dt.Rows[i]["BuildingID"].ToString()));
                    Buildingtitle.Add(dt.Rows[i]["BuildingTitle"].ToString());
                    cmbBuilding.Items.Add(Buildingtitle[i]);
                }

                if (_agent.BuildingTitle != null)
                {
                    cmbBuilding.SelectedText = _agent.BuildingTitle;
                    BuilldingText = _agent.BuildingTitle; 
                    DeleteEnable = true;
                    IsFirstSave = false;
                }
                else
                {
                    IsFirstSave = true;
                    cmbBuilding.SelectedIndex = 0;
                    BuilldingText = cmbBuilding.Text;
                }
                    
                
            }
        }

        private void FillClasslist()
        {
            DataTable dt = new DataTable();
            dt = lg.GetClassList();
            if (dt != null)
            {
                int row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    Classid.Add(Convert.ToInt32(dt.Rows[i]["ClassID"].ToString()));
                    Classtitle.Add(dt.Rows[i]["ClassTitle"].ToString());
                    cmbClass.Items.Add(Classtitle[i]);
                }
                if (_agent.ClassTitle != null)
                {
                    cmbClass.SelectedText = _agent.ClassTitle;
                    ClassText = _agent.ClassTitle;
                    DeleteEnable = true;
                }
                else
                {
                    IsFirstSave = true;
                    cmbClass.SelectedIndex = 0;
                    ClassText = cmbClass.Text;
                }
                    
            }
        }

        private void FillRoomList()
        {
            DataTable dt = new DataTable();
            dt = lg.GetRoomList();
            if (dt != null)
            {
                int row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    Roomid.Add(Convert.ToInt32(dt.Rows[i]["RoomID"].ToString()));
                    Roomtitle.Add(dt.Rows[i]["RoomTitle"].ToString());
                    cmbRoom.Items.Add(Roomtitle[i]);
                }
                if (_agent.RoomTitle != null)
                {
                    cmbRoom.SelectedText = _agent.RoomTitle;
                    RoomText = _agent.RoomTitle; 
                    DeleteEnable = true;
                }
                else
                {
                    IsFirstSave = true;
                    cmbRoom.SelectedIndex = 0;
                    RoomText = cmbRoom.Text;
                }
            }
        }

        private void FillDepartmentList()
        {
            DataTable dt = new DataTable();
            dt = lg.GetDepartmentList();
            if (dt != null)
            {
                int row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    Departmentid.Add(Convert.ToInt32(dt.Rows[i]["DepartmentID"].ToString()));
                    Departmenttitle.Add(dt.Rows[i]["DepartmentTitle"].ToString());
                    cmbDepartment.Items.Add(Departmenttitle[i]);
                }
                if (_agent.DepartmentTitle != null)
                {
                    cmbDepartment.SelectedText = _agent.DepartmentTitle;
                    DepartmentText = _agent.DepartmentTitle;
                    DeleteEnable = true;
                }
                else
                {
                    IsFirstSave = true;
                    cmbDepartment.SelectedIndex = 0;
                    DepartmentText = cmbDepartment.Text;
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void EnableControls()
        {
            lblBuilding.Enabled = true;
            lblClass.Enabled = true;
            lblDepartment.Enabled = true;
            lblRoom.Enabled = true;

            cmbBuilding.Enabled = true;
            cmbClass.Enabled = true;
            cmbDepartment.Enabled = true;
            cmbRoom.Enabled = true;

            saveToolStripButton.Enabled = true;
            openToolStripButton.Enabled = false;

            deleteToolStripButton.Enabled = false;

            cmbBuilding.Focus();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            int buildinedex = cmbBuilding.FindString(BuilldingText);
            int roomindex = cmbRoom.FindString(RoomText);
            int classindex = cmbClass.FindString(ClassText);
            int depindex = cmbDepartment.FindString(DepartmentText);

            string buildId = Buildingid[buildinedex].ToString();
            string roomId = Roomid[roomindex].ToString();
            string classId = Classid[classindex].ToString();
            string depId = Departmentid[depindex].ToString();

            int res = 0;
            if (IsFirstSave == true)
                res = lg.SaveAgentLocationToSql(_agent.AgentID, buildId, classId, roomId, depId);
            if (IsFirstSave == false)
                res = lg.UpdateAgentLocationInSql(_agent.AgentID, buildId, classId, roomId, depId);

            if (res == 1)
            {
                UpdateAgentList("Update");
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                DeleteEnable = true;
                DisableControls();
                openToolStripButton.Enabled = true;

            }
            if (res == 0)
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                DisableControls();
                openToolStripButton.Enabled = true;
                
            }
        }

        private void UpdateAgentList(string Action)
        {
            //Update Agent list Property
            string AgentIDtoFind = _agent.AgentID;

            int index = Program.AgentList.FindIndex(delegate(Agents Ag) { return Ag.AgentID.Equals(_agent.AgentID, StringComparison.Ordinal); });

            if (Action == "Update")
            {
                int buildinedex = cmbBuilding.FindString(BuilldingText);
                int roomindex = cmbRoom.FindString(RoomText);
                int classindex = cmbClass.FindString(ClassText);
                int depindex = cmbDepartment.FindString(DepartmentText);

                Program.AgentList[index].BuildingId = Convert.ToInt32(Buildingid[buildinedex].ToString());
                Program.AgentList[index].ClassId = Convert.ToInt32(Classid[classindex].ToString());
                Program.AgentList[index].RoomId = Convert.ToInt32(Roomid[roomindex].ToString());
                Program.AgentList[index].DepartmentId = Convert.ToInt32(Departmentid[depindex].ToString());

                Program.AgentList[index].BuildingTitle = Buildingtitle[buildinedex].ToString();
                Program.AgentList[index].ClassTitle = Classtitle[classindex].ToString();
                Program.AgentList[index].RoomTitle = Roomtitle[roomindex].ToString();
                Program.AgentList[index].DepartmentTitle = Departmenttitle[depindex].ToString();
            }
            if (Action == "Delete")
            {
                Program.AgentList[index].BuildingId = -1;
                Program.AgentList[index].ClassId = -1;
                Program.AgentList[index].RoomId = -1;
                Program.AgentList[index].DepartmentId = -1;

                Program.AgentList[index].BuildingTitle = null;
                Program.AgentList[index].ClassTitle = null;
                Program.AgentList[index].RoomTitle = null;
                Program.AgentList[index].DepartmentTitle = null;

            }
           
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            int res = lg.DeleteAgentLocationFromSql(_agent.AgentID);
            if (res == 1)
            {
                UpdateAgentList("Delete");
                string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();               
                DeleteEnable = false;
                DisableControls();
                openToolStripButton.Enabled = true;

            }
            if (res == 0)
            {
                string mes = lg.GetErrorMessage(20);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                DisableControls();
                openToolStripButton.Enabled = true;

            }

        }

        private void frmAgentLocation_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void cmbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuilldingText = cmbBuilding.Text;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassText = cmbClass.Text;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoomText = cmbRoom.Text;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentText = cmbDepartment.Text;
        }
    }
}
