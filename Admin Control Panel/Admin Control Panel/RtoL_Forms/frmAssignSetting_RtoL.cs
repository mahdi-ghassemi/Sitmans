using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAssignSetting_RtoL : Telerik.WinControls.UI.RadForm
    {
        private List<Agents> ags;
        private string _langCode;
        private LogicLayer lg;
        private string _selectedProfileId;
        private string _selectedProfileName;
        private bool _sqlError;

        public frmAssignSetting_RtoL(List<Agents> AgentList)
        {
            ags = new List<Agents>();
            lg = new LogicLayer();
            ags = AgentList;
            _langCode = Convert.ToString(Program.LangCode);
            _selectedProfileId = "1";
            _sqlError = false;
            InitializeComponent();
        }

        private void frmAssignSetting_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            SetProfileList();
        }       

        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "SettingAssign");
            this.lblTitle.Text = lg.GetMessageFromDll(_langCode, "SettingAssignTitle");
            this.btnOk.Text = lg.GetMessageFromDll(_langCode, "btnOk");
            this.btnCancel.Text = lg.GetMessageFromDll(_langCode, "btnExit");
            
        }

        private void SetProfileList()
        {
            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetSettingProfile();
            int _rowCount = Program.SettingProfileList.Count;
            cmbProfileList.Items.Add(_default);
            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.SettingProfileList[i].ProfileName);               
            }

            cmbProfileList.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbProfileList.SelectedIndex;
            _selectedProfileId = Program.SettingProfileList[index].ProfileId;
            _selectedProfileName = cmbProfileList.SelectedText;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_selectedProfileId == "1")
            {
                SaveDefaultProfile();
            }
            if (_selectedProfileId != "1")
            {
                SaveNoDefaultProfile();               
            }
            if (_sqlError == false)
            {
                UpdateAgentsSettingList();
            }            
            ShowSaveResult();
        }

        private void UpdateAgentsSettingList()
        {
            int r = ags.Count;
            int _agentIndex;

            for (int i = 0; i < r; i++)
            {
                _agentIndex = ags[i].AgentMainIndex;
                Program.AgentList[_agentIndex].SettingProfileId = _selectedProfileId;
                Program.AgentList[_agentIndex].SettingProfileName = _selectedProfileName;                 
            }

            UpdateRemoteAgentSetting();

        }

        private void UpdateRemoteAgentSetting()
        {
            ThreadStart thsAgentSettingUpdate = new ThreadStart(StartAgentSettingUpdate);
            Thread thrAgentSettingUpdate = new Thread(thsAgentSettingUpdate);

            thrAgentSettingUpdate.Start();
        
        }

        private void StartAgentSettingUpdate()
        {
            LogicLayer logl = new LogicLayer();
            string pid,dataToSend,lastpid;
            int pindex,lastpindex;
            foreach (Agents agent in ags)
            {
                if (agent.Status == "On" || agent.Status == "StandBy" || agent.Status == "Idle")
                {
                    pid = agent.SettingProfileId;
                    lastpid = agent.LastSettingProfileId;
                    pindex = Program.SettingProfileList.FindIndex(a => a.ProfileId == pid);
                    dataToSend = logl.SetProfileSettingDataForSendeing(pindex,agent.AgentMainIndex);
                    lastpindex = Program.SettingProfileList.FindIndex(b => b.ProfileId == lastpid);
                    logl.SendSettingDataToRemoteAgent(dataToSend, lastpindex,agent.AgentMainIndex);
                }
                else
                {
                    //res = logl.InsertAgentSettingUpdateToSql(agent.AgentID, agent.SettingProfileId);
                }
            }
        }

        private void ShowSaveResult()
        {
            if (_sqlError == false)
            {
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
            else
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                frmsh.ShowDialog();
            }
        }

        private void SaveDefaultProfile()
        {
            DataTable dt = new DataTable();
            int _count = ags.Count;
            string id = "";
            int res = 0;
            for (int i = 0; i < _count; i++)
            {
                dt = lg.GetAgentSettingProfile(ags[i].AgentID);
                ags[i].LastSettingProfileId = ags[i].SettingProfileId;
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["Id"].ToString();
                    res = lg.DeleteAgentSettingProfile(id);
                    if (res == 1)
                    {
                        _sqlError = false;
                    }
                    else
                    {
                        _sqlError = true;
                        break;
                    }

                }               
            }            
        }

        private void SaveNoDefaultProfile()
        {
            DataTable dt = new DataTable();
            int _count = ags.Count;
            string id = "";
            int res = 0;
            for (int i = 0; i < _count; i++)
            {
                dt = lg.GetAgentSettingProfile(ags[i].AgentID);
                ags[i].LastSettingProfileId = ags[i].SettingProfileId;
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["Id"].ToString();
                    res = lg.UpdateAgentSettingProfile(id, _selectedProfileId);
                    if (res == 1)
                    {
                        _sqlError = false;
                    }
                    else
                    {
                        _sqlError = true;
                        break;
                    }
                }
                else
                {
                    res = lg.InsertAgentSettingProfile(ags[i].AgentID, _selectedProfileId);
                    if (res == 1)
                    {
                        _sqlError = false;
                    }
                    else
                    {
                        _sqlError = true;
                        break;
                    }
                }
            }
        }


    }
}
