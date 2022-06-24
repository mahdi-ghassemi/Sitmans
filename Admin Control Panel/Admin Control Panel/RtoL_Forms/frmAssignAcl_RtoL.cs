﻿using System;
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
    public partial class frmAssignAcl_RtoL : Telerik.WinControls.UI.RadForm
    {
        private List<Agents> ags;
        private string _langCode;
        private LogicLayer lg;
        private string _selectedProfileId;
        private string _selectedProfileName;
        private bool _sqlError;

        public frmAssignAcl_RtoL(List<Agents> AgentList)
        {
            ags = new List<Agents>();
            lg = new LogicLayer();
            ags = AgentList;
            _langCode = Convert.ToString(Program.LangCode);
            _selectedProfileId = "1";
            _sqlError = false;
            InitializeComponent();
        }

        private void frmAssignAcl_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            SetProfileList();
        }

        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AclAssign");
            this.lblTitle.Text = lg.GetMessageFromDll(_langCode, "AclAssignTitle");
            this.btnOk.Text = lg.GetMessageFromDll(_langCode, "btnOk");
            this.btnCancel.Text = lg.GetMessageFromDll(_langCode, "btnExit");

        }

        private void SetProfileList()
        {
            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetAclHeaderProfile();
            int _rowCount = Program.AclProfileList.Count;
            cmbProfileList.Items.Add(_default);
            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.AclProfileList[i].ProfileName);
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
            _selectedProfileId = Program.AclProfileList[index].ProfileId;
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
                UpdateAgentsAclList();
            }
            ShowSaveResult();
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

        private void UpdateAgentsAclList()
        {
            int r = ags.Count;
            int _agentIndex;

            for (int i = 0; i < r; i++)
            {
                _agentIndex = ags[i].AgentMainIndex;
                Program.AgentList[_agentIndex].AclProfileId = _selectedProfileId;
                Program.AgentList[_agentIndex].AclProfileName = _selectedProfileName;
                lg.SetAgentAclProfileDetailInfo(_agentIndex);
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
                dt = lg.GetAgentAclProfile(ags[i].AgentID);
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["Id"].ToString();
                    res = lg.DeleteAgentAclProfile(id);
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
                dt = lg.GetAgentAclProfile(ags[i].AgentID);
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["Id"].ToString();
                    res = lg.UpdateAgentAclProfile(id, _selectedProfileId);
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
                    res = lg.InsertAgentAclProfile(ags[i].AgentID, _selectedProfileId);
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
