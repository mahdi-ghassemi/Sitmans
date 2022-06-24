using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using Telerik.WinControls.UI;
using System.Reflection;

namespace Admin_Control_Panel.RtoL_Forms
{
    

    public partial class frmACLToObjectsProfile_RtoL : Telerik.WinControls.UI.RadForm
    {
        private LogicLayer lg;
        private string _langCode;
        private string _SelectedProfileId;
        private bool _SqlError;
        private string SubjectTitle;
        private DataTable dtAgentsAcl;
        private DataTable dtObjectsAcl;
       


        /* Header Text */
        private string headerSubject;
        private string headerAcl;

        /*ACL Text */

      // private string l0;
      //  private string l1;
        


        public frmACLToObjectsProfile_RtoL()
        {
            dtAgentsAcl = new DataTable();
            _langCode = Program.LangCode.ToString();
            lg = new LogicLayer();
            _SqlError = false;
            InitializeComponent();
        }

        private void frmACLToObjectsProfile_RtoL_Load(object sender, EventArgs e)
        {
            SetFormMessages();
            FillTreeViews();       
            FillProfileList();
        }     

        private void SetFormMessages()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "AclDefine");

            grbProfileSelect.Text = lg.GetMessageFromDll(_langCode, "Profile");
            rbtNewProfile.Text = lg.GetMessageFromDll(_langCode, "NewProfile");
            rbtSelectProfile.Text = lg.GetMessageFromDll(_langCode, "SelectProfile");
            rbtCopyProfile.Text = lg.GetMessageFromDll(_langCode, "CopyProfile");
            lblTo.Text = lg.GetMessageFromDll(_langCode, "To");

          
            pwpReports.Text = lg.GetMessageFromDll(_langCode, "Objects");

            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");

            

            
        //    l0 = lg.GetMessageFromDll(_langCode, "DeniedAccess");
        //    l1 = lg.GetMessageFromDll(_langCode, "GrantAccess");
        
        }

        private void FillTreeViews()
        {
           

            trvObjects.Nodes["Node1"].Text = lg.GetMessageFromDll(_langCode, "acl25");
            trvObjects.Nodes["Node2"].Text = lg.GetMessageFromDll(_langCode, "acl26");
            trvObjects.Nodes["Node3"].Text = lg.GetMessageFromDll(_langCode, "acl27");
            trvObjects.Nodes["Node4"].Text = lg.GetMessageFromDll(_langCode, "acl28");
            trvObjects.Nodes["Node5"].Text = lg.GetMessageFromDll(_langCode, "acl30");
            trvObjects.Nodes["Node6"].Text = lg.GetMessageFromDll(_langCode, "acl39");
            trvObjects.Nodes["Node7"].Text = lg.GetMessageFromDll(_langCode, "acl44");
            trvObjects.Nodes["Node8"].Text = lg.GetMessageFromDll(_langCode, "acl45");

            trvObjects.Nodes["Node1"].Nodes["46"].Text = lg.GetMessageFromDll(_langCode, "acl46");
            trvObjects.Nodes["Node1"].Nodes["47"].Text = lg.GetMessageFromDll(_langCode, "acl47");

            trvObjects.Nodes["Node2"].Nodes["48"].Text = lg.GetMessageFromDll(_langCode, "acl48");
            trvObjects.Nodes["Node2"].Nodes["49"].Text = lg.GetMessageFromDll(_langCode, "acl49");

            trvObjects.Nodes["Node3"].Nodes["50"].Text = lg.GetMessageFromDll(_langCode, "acl50");
            trvObjects.Nodes["Node3"].Nodes["51"].Text = lg.GetMessageFromDll(_langCode, "acl51");
            trvObjects.Nodes["Node3"].Nodes["52"].Text = lg.GetMessageFromDll(_langCode, "acl52");
            trvObjects.Nodes["Node3"].Nodes["53"].Text = lg.GetMessageFromDll(_langCode, "acl53");
            trvObjects.Nodes["Node3"].Nodes["54"].Text = lg.GetMessageFromDll(_langCode, "acl54");

            trvObjects.Nodes["Node4"].Nodes["55"].Text = lg.GetMessageFromDll(_langCode, "acl55");
            trvObjects.Nodes["Node4"].Nodes["56"].Text = lg.GetMessageFromDll(_langCode, "acl56");

            trvObjects.Nodes["Node5"].Nodes["57"].Text = lg.GetMessageFromDll(_langCode, "acl57");
            trvObjects.Nodes["Node5"].Nodes["58"].Text = lg.GetMessageFromDll(_langCode, "acl58");
            trvObjects.Nodes["Node5"].Nodes["59"].Text = lg.GetMessageFromDll(_langCode, "acl59");

            trvObjects.Nodes["Node6"].Nodes["60"].Text = lg.GetMessageFromDll(_langCode, "acl60");
            trvObjects.Nodes["Node6"].Nodes["61"].Text = lg.GetMessageFromDll(_langCode, "acl61");
            trvObjects.Nodes["Node6"].Nodes["62"].Text = lg.GetMessageFromDll(_langCode, "acl62");
            trvObjects.Nodes["Node6"].Nodes["63"].Text = lg.GetMessageFromDll(_langCode, "acl63");
            trvObjects.Nodes["Node6"].Nodes["64"].Text = lg.GetMessageFromDll(_langCode, "acl64");
            trvObjects.Nodes["Node6"].Nodes["65"].Text = lg.GetMessageFromDll(_langCode, "acl65");

            trvObjects.Nodes["Node7"].Nodes["66"].Text = lg.GetMessageFromDll(_langCode, "acl66");
            trvObjects.Nodes["Node7"].Nodes["67"].Text = lg.GetMessageFromDll(_langCode, "acl67");
            trvObjects.Nodes["Node7"].Nodes["68"].Text = lg.GetMessageFromDll(_langCode, "acl68");
            trvObjects.Nodes["Node7"].Nodes["69"].Text = lg.GetMessageFromDll(_langCode, "acl69");

            trvObjects.Nodes["Node8"].Nodes["70"].Text = lg.GetMessageFromDll(_langCode, "acl70");
            trvObjects.Nodes["Node8"].Nodes["71"].Text = lg.GetMessageFromDll(_langCode, "acl71");
            trvObjects.Nodes["Node8"].Nodes["72"].Text = lg.GetMessageFromDll(_langCode, "acl72");
            trvObjects.Nodes["Node8"].Nodes["73"].Text = lg.GetMessageFromDll(_langCode, "acl73");

         /*  trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev1"].Text = "Access";
             trvObjects.Nodes["Node1"].Nodes["46"].Nodes["lev2"].Text = l1;
   

            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node1"].Nodes["47"].Nodes["lev2"].Text = l1;
        

            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node2"].Nodes["48"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node2"].Nodes["49"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node3"].Nodes["50"].Nodes["lev2"].Text = l1;
       

            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node3"].Nodes["51"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node3"].Nodes["52"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node3"].Nodes["53"].Nodes["lev2"].Text = l1;
          

            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node3"].Nodes["54"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node4"].Nodes["55"].Nodes["lev2"].Text = l1;
          

            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node4"].Nodes["56"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node5"].Nodes["57"].Nodes["lev2"].Text = l1;
    

            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node5"].Nodes["58"].Nodes["lev2"].Text = l1;
   

            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node5"].Nodes["59"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["60"].Nodes["lev2"].Text = l1;
       

            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["61"].Nodes["lev2"].Text = l1;
       

            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["62"].Nodes["lev2"].Text = l1;
         

            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["63"].Nodes["lev2"].Text = l1;
    

            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["64"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node6"].Nodes["65"].Nodes["lev2"].Text = l1;
       

            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node7"].Nodes["66"].Nodes["lev2"].Text = l1;
       

            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node7"].Nodes["67"].Nodes["lev2"].Text = l1;
    

            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node7"].Nodes["68"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node7"].Nodes["69"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node8"].Nodes["70"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node8"].Nodes["71"].Nodes["lev2"].Text = l1;
  

            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node8"].Nodes["72"].Nodes["lev2"].Text = l1;
      

            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev1"].Text = l0;
            trvObjects.Nodes["Node8"].Nodes["73"].Nodes["lev2"].Text = l1;
      
            */
            this.trvObjects.SortOrder = SortOrder.Ascending;
            trvObjects.CollapseAll();
            
        }    

        private void FillProfileList()
        {
            if (cmbProfileList.Items.Count > 0)
            {
                cmbProfileList.Items.Clear();
                cmbProfileTo.Items.Clear();
                cmbProfileFrom.Items.Clear();
            }

            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetAclObjectsHeaderProfile();
            int _rowCount = Program.AclObjectsProfileList.Count;

            cmbProfileList.Items.Add(_default);
            cmbProfileTo.Items.Add(_default);
            cmbProfileFrom.Items.Add(_default);

            for (int i = 1; i < _rowCount; i++)
            {
                cmbProfileList.Items.Add(Program.AclObjectsProfileList[i].ProfileName);
                cmbProfileFrom.Items.Add(Program.AclObjectsProfileList[i].ProfileName);
                cmbProfileTo.Items.Add(Program.AclObjectsProfileList[i].ProfileName);
            }
          
            cmbProfileList.SelectedIndex = 0;
            cmbProfileFrom.SelectedIndex = 0;
            cmbProfileTo.SelectedIndex = 0;
        }

        private void cmbProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _profileId = Program.AclObjectsProfileList[cmbProfileList.SelectedIndex].ProfileId;
            _SelectedProfileId = _profileId;
            SetObjectsAclTables(_SelectedProfileId);
            FillObjectsTreeViewData();         
        }
   
        private void SetObjectsAclTables(string _SelectedProfileId)
        {
            dtObjectsAcl = null;
            dtObjectsAcl = lg.GetAclObjectsDetails(_SelectedProfileId, "2");
        }
    
        private void FillObjectsTreeViewData()
        {
            int _rows = dtObjectsAcl.Rows.Count;
            string _subId, _aclLevel;
            for (int i = 0; i < _rows; i++)
            {
                _subId = dtObjectsAcl.Rows[i]["SubjectId"].ToString();
                _aclLevel = dtObjectsAcl.Rows[i]["AclLevel"].ToString();
                SetAclNode(_subId, Convert.ToInt32(_aclLevel));
            }
        }

        private void SetAclNode(string SubId, int Acl)
        {
            switch (SubId)
            {

                case "46":
                    {
                        if(Acl == 1)
                            trvObjects.Nodes["Node1"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node1"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "47":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node1"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node1"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "48":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node2"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node2"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "49":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node2"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node2"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "50":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "51":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "52":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "53":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "54":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node3"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "55":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node4"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node4"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "56":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node4"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node4"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "57":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "58":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "59":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node5"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "60":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "61":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "62":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "63":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "64":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "65":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node6"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "66":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "67":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "68":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "69":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node7"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "70":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "71":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "72":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = false;
                        break;
                    }

                case "73":
                    {
                        if (Acl == 1)
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = true;
                        else
                            trvObjects.Nodes["Node8"].Nodes[SubId].Checked = false;
                        break;
                    }
            }
        }                 

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(56))
            {
                this.Focus();
                if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    UpdateProfile();
                    ShowSaveMessage();
                }
                if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    bool IsProfileNameRepeat = CheckProfileName(txbProfileName.Text);
                    if (IsProfileNameRepeat == false)
                    {
                        SaveNewProfile();
                        ShowSaveMessage();
                        SetProfileControl();
                        FillProfileList();
                    }
                    else
                    {
                        string mes = lg.GetMessageFromDll(_langCode, "ProfileNameIsRepeat");
                        frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 2);
                        frmsh.ShowDialog();
                    }
                }
                if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    UpdateProfile();
                    ShowSaveMessage();
                    SetProfileControl();
                    FillProfileList();
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void SetProfileControl()
        {
            rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;

            cmbProfileList.Enabled = true;
            cmbProfileList.SelectedIndex = 0;

            txbProfileName.Enabled = false;

            cmbProfileFrom.Enabled = false;
            cmbProfileTo.Enabled = false;
        }

        private bool CheckProfileName(string NewProfileName)
        {
            bool result = false;
            int count = Program.AclObjectsProfileList.Count;
            for (int i = 0; i < count; i++)
            {
                if (Program.AclObjectsProfileList[i].ProfileName.Trim() == NewProfileName.Trim())
                    result = true;
            }
            return result;
        }

        private void UpdateProfile()
        {          
           UpdateAcl(trvObjects);
           lg.SetUserAclObjects();
        }

        private void UpdateAcl(RadTreeView Rgv)
        {
            string _SubjectId = "";
            string _AclId = "";
            int res, _childCount;
            int _rootCount = Rgv.Nodes.Count;
            for (int i = 0; i < _rootCount; i++)
            {
                _childCount = Rgv.Nodes[i].Nodes.Count;
                for (int m = 0; m < _childCount; m++)
                {
                    _SubjectId = Rgv.Nodes[i].Nodes[m].Name;
               
                    if (Rgv.Nodes[i].Nodes[m].Checked == true)
                        _AclId = "1";
                    else
                        _AclId = "0";

                    res = lg.UpdateAclObjectProfile(_SelectedProfileId, _SubjectId, _AclId);
                    if (res == 0)
                    {
                        _SqlError = true;
                        break;
                    }
                }
                if (_SqlError == true)
                {
                    break;
                }
            }        
        }

        private void ShowSaveMessage()
        {
            if (_SqlError == false)
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

        private void SaveNewProfile()
        {
            if (txbProfileName.Text != "")
            {
                string _lastProfileId = lg.GetLastAclObjectProfileId();
                _SelectedProfileId = _lastProfileId;
                int res = lg.InsertAclObjectProfile(_SelectedProfileId, txbProfileName.Text.Trim());
                if (res == 1)
                {
                    _SqlError = false;
                    SaveNewDetailsAclProfile();
                }
                else
                {
                    _SqlError = true;
                }
            }
            else
            {
                errorProvider1.SetError(txbProfileName, "Not");
                txbProfileName.Focus();
            }
        }

        private void SaveNewDetailsAclProfile()
        {          
            InsertAcl(trvObjects , "2");
        }

        private void InsertAcl(RadTreeView Rgv, string _SGroup)
        {
            string _SubjectId = "";
            string _AclId = "";
            int res, _childCount;
            string _SubjectGroup = _SGroup;
            int _rootCount = Rgv.Nodes.Count;
            for (int i = 0; i < _rootCount; i++)
            {
                _childCount = Rgv.Nodes[i].Nodes.Count;
                for (int m = 0; m < _childCount; m++)
                {
                    _SubjectId = Rgv.Nodes[i].Nodes[m].Name;

                    if (Rgv.Nodes[i].Nodes[m].Checked == true)
                        _AclId = "1";
                    else
                        _AclId = "0";

                    res = lg.InsertAclObjectDetails(_SelectedProfileId, _SubjectId, _AclId, _SubjectGroup);
                    if (res == 0)
                    {
                        _SqlError = true;
                        break;
                    }                 
                }
                if (_SqlError == true)
                {
                    break;
                }
            }
        }

        private void rbtSelectProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtSelectProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                cmbProfileList.Enabled = true;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
            }
        }

        private void rbtNewProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtNewProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = true;
                rbtCopyProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = false;
                cmbProfileTo.Enabled = false;
                cmbProfileList.Enabled = false;
            }
        }

        private void rbtCopyProfile_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                rbtSelectProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                txbProfileName.Enabled = false;
                rbtNewProfile.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                cmbProfileFrom.Enabled = true;
                cmbProfileTo.Enabled = true;
                cmbProfileList.Enabled = false;
            }
        }

        private void txbProfileName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void cmbProfileFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtCopyProfile.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                string _profileId = Program.AclObjectsProfileList[cmbProfileFrom.SelectedIndex].ProfileId;
                _SelectedProfileId = _profileId;
               
                SetObjectsAclTables(_SelectedProfileId);
              
                FillObjectsTreeViewData();            
            }
        }

        private void cmbProfileTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedProfileId = Program.AclObjectsProfileList[cmbProfileTo.SelectedIndex].ProfileId;
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(56))
            {
                if (cmbProfileList.SelectedIndex != 0)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteNotification");
                    frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(mes, 3);
                    DialogResult dr = frmsh.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        GoToDelete();
                    }
                }
                else
                {
                    ShowDeleteMessage(lg.GetErrorMessage(24));
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void GoToDelete()
        {
            int Res = 0;
            Res = lg.DeleteAclObjectProfileDetails(_SelectedProfileId);
            if (Res == 1)
            {
                Res = lg.DeleteAclObjectProfileHeader(_SelectedProfileId);
                if (Res == 1)
                {
                    ShowDeleteMessage(lg.GetMessageFromDll(_langCode, "DeleteSuccessfull"));
                    SetProfileControl();
                    FillProfileList();
                }
                else
                {
                    ShowDeleteMessage(lg.GetErrorMessage(20));
                }
            }
            else
            {
                ShowDeleteMessage(lg.GetErrorMessage(25));
            }
        }


        private void ShowDeleteMessage(string Message)
        {
            frmShowInfoSmall_RtoL frmsh = new frmShowInfoSmall_RtoL(Message, 2);
            frmsh.ShowDialog();
        }
                      
    }   
}
