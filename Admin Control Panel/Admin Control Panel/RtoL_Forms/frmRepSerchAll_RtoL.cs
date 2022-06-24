using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using Stimulsoft.Report;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmRepSerchAll_RtoL : Telerik.WinControls.UI.RadForm
    {
        private DataTable _mainDataTable;
        private string _reportTitle;
        private string _langCode;
        private LogicLayer lg;
        private List<AgentInReportList> AgentList;
        private List<AgentDetailsInReportList> InAgentDetails;
        private List<string> AgentIdList;
        private List<Query> _query;
        private string _groupText;
        private string _page;
        private string _from;
        private string _agentId;


        private string HCradif, HPersonnelName, HSysyemName, HLocation, HIP, HCItem, HCValue;  // Header Column Text
        
        public frmRepSerchAll_RtoL(DataTable MainDataTable, string ReportTitle,List<Query> IQuery,string AgentId)
        {
            if (AgentId != null)
                _agentId = AgentId;
            else
                _agentId = "";
            
            _mainDataTable = new DataTable();
            _mainDataTable = MainDataTable;
            _query = new List<Query>();
            _query = IQuery;
            AgentIdList = new List<string>();
            
            if (ReportTitle == null)
                _reportTitle = "";
            else
                _reportTitle = ReportTitle;

            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();             
            InitializeComponent();
        }

        private void frmRepSerchAll_RtoL_Load(object sender, EventArgs e)
        {
            _groupText = lg.GetMessageFromDll(_langCode, "GridViewGroupPanel");
            imgPersonel.Images.Add("UnKnown", Properties.Resources.unknown);
            SetHeaderColumnsText();
            SetMasterList();
            SetChildList();
            SetMasterGrid();
            SetChildGrid();
        }
        
        private void SetHeaderColumnsText()
        {
            this.Text = _reportTitle;

            HCradif = lg.GetMessageFromDll(_langCode, "radif");
            HPersonnelName = lg.GetMessageFromDll(_langCode, "UserFullName");

            HSysyemName = lg.GetMessageFromDll(_langCode, "System");
            HLocation = lg.GetMessageFromDll(_langCode, "LocalAddress");
            HIP = lg.GetMessageFromDll(_langCode, "IPAddress");
            HCItem = lg.GetMessageFromDll(_langCode, "Item");
            HCValue = lg.GetMessageFromDll(_langCode, "Value");
            _page = lg.GetMessageFromDll(_langCode, "Page");
            _from = lg.GetMessageFromDll(_langCode, "From");

        }

        private void SetMasterList()
        {
            AgentList = new List<AgentInReportList>();
            InAgentDetails = new List<AgentDetailsInReportList>();

            int tr = _mainDataTable.Rows.Count;
            if (tr > 0)
            {
                if (_agentId != "")
                {
                    AgentIdList.Add(_agentId);
                }
                else
                {

                    for (int i = 0; i < tr; i++)
                    {
                        string aid = _mainDataTable.Rows[i]["AgentId"].ToString();
                        int listIndex = AgentIdList.IndexOf(aid);
                        if (listIndex == -1)
                        {
                            AgentIdList.Add(aid);
                        }

                    }
                }

                for (int i = 0; i < AgentIdList.Count; i++)
                {
                    string aid = AgentIdList[i];
                    int index = Program.AgentList.FindIndex(item => item.AgentID == aid);
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
                    string location = Program.dataSource[index].Buildding + " " +
                                      Program.dataSource[index].Class + " " +
                                      Program.dataSource[index].Room + " " +
                                      Program.dataSource[index].Department;
                    string ip = Program.dataSource[index].AgentIP;
                    AgentList.Add(new AgentInReportList(i + 1, agantImage, Convert.ToInt32(aid), fullname, system, location, ip));
                }
            }
        }

        private void SetChildList()
        {
            int agentCount = AgentIdList.Count;
            string agid;
            for (int i = 0; i < agentCount; i++)
            {
                agid = AgentIdList[i];
              
                for (int j = 0; j < _query.Count; j++)
                {
                    for (int t = 0; t < _query[j].FieldsCount; t++)
                    {
                        string fullfield = _query[j].GetFieldName(t);
                        string field = GetFiledName(fullfield);
                        string fieldTrans = _query[j].Item;
                       
                       // for (int n = 0; n < _mainDataTable.Rows.Count; n++)
                        for (int n = 0; n < 1; n++)
                        {
                            DataRow[] tbr = _mainDataTable.Select("AgentId = "+agid);
                            string value = tbr[n][field].ToString();                            
                            string id =  tbr[n]["Id"].ToString();
                            string agentid =  tbr[n]["AgentId"].ToString();
                           // string value = _mainDataTable.Rows[n][field].ToString();                            
                           // string id = _mainDataTable.Rows[n]["Id"].ToString();
                            //string agentid = _mainDataTable.Rows[n]["AgentId"].ToString();
                            if (value != "")
                                InAgentDetails.Add(new AgentDetailsInReportList(j+1, Convert.ToInt32(id), Convert.ToInt32(agid), fieldTrans, value));                           
                        }                       
                    }
                }
            }
          
        }

        private void SetMasterGrid()
        {
            grvRep.DataSource = AgentList;

            grvRep.Columns[2].IsVisible = false;
           

            grvRep.Columns[0].HeaderText = HCradif;
            grvRep.Columns[1].HeaderText = "";
            grvRep.Columns[2].HeaderText = "AgentId";
            grvRep.Columns[3].HeaderText = HPersonnelName;
            grvRep.Columns[4].HeaderText = HSysyemName;
            grvRep.Columns[5].HeaderText = HLocation;
            grvRep.Columns[6].HeaderText = HIP;



            grvRep.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            grvRep.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
            grvRep.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;

            grvRep.Columns[0].ReadOnly = true;
            grvRep.Columns[1].ReadOnly = true;
            grvRep.Columns[2].ReadOnly = true;
            grvRep.Columns[3].ReadOnly = true;
            grvRep.Columns[4].ReadOnly = true;
            grvRep.Columns[5].ReadOnly = true;
            grvRep.Columns[6].ReadOnly = true;

            

            grvRep.Columns[0].MaxWidth = 40;//radif
            grvRep.Columns[0].MinWidth = 39;
            
            grvRep.Columns[1].MaxWidth = 64; //aks
            grvRep.Columns[1].MinWidth = 63;
            //grvRep.Columns[1].ImageLayout = ImageLayout.Stretch;
            grvRep.Columns[1].AutoSizeMode = Telerik.WinControls.UI.BestFitColumnMode.AllCells;
            

            grvRep.Columns[3].MinWidth = 150; //naam

            grvRep.Columns[4].MaxWidth = 150;//system
            grvRep.Columns[4].MinWidth = 149;

            grvRep.Columns[5].MaxWidth = 300; // location
            grvRep.Columns[5].MinWidth = 299;

            grvRep.Columns[6].MaxWidth = 100; //ip
            grvRep.Columns[6].MinWidth = 99;
            
            grvRep.AllowDragToGroup = true;

            this.grvRep.TableElement.EndUpdate(true);
        }

        private void SetChildGrid()
        {
            GridViewTemplate template = new GridViewTemplate();
            template.DataSource = InAgentDetails;
            

            template.Columns[1].IsVisible = false;
            template.Columns[2].IsVisible = false;


            template.Columns[0].HeaderText = HCradif;
            template.Columns[1].HeaderText = "Id";
            template.Columns[2].HeaderText = "AgentId";
            template.Columns[3].HeaderText = HCItem;
            template.Columns[4].HeaderText = HCValue;



            template.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;



            template.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;

            template.ReadOnly = true;

            template.AllowAddNewRow = false;
            template.AllowDeleteRow = false;
            template.AllowEditRow = false;



            template.Columns[0].MaxWidth = 40;
            template.Columns[0].MinWidth = 39;

            template.Columns[3].MaxWidth = 200;
            template.Columns[3].MinWidth = 149;


            template.Columns[4].MaxWidth = 700;
            template.Columns[4].MinWidth = 349;

            
            template.AllowDragToGroup = true;


            grvRep.MasterTemplate.Templates.Add(template);


            GridViewRelation relation = new GridViewRelation(grvRep.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "InAgentDevises";
            relation.ParentColumnNames.Add("AgentId");
            relation.ChildColumnNames.Add("ParentAgentId");
            grvRep.Relations.Add(relation);
        }
       
        private string GetFiledName(string FullField)
        {
            string res;
            string[] f = FullField.Split('.');
            int c = f.Length;
            res = f[c - 1];
            return res;
        }

        private void frmRepSerchAll_RtoL_Shown(object sender, EventArgs e)
        {
            this.grvRep.GridViewElement.GroupPanelElement.Text = _groupText;
        }

        private void grvRep_GroupByChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (e.GridViewTemplate.GroupDescriptors.Count == 0)
            {
                this.grvRep.GridViewElement.GroupPanelElement.Text = _groupText;
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            int _errorCode1 = 0;
            int _errorCode2 = 0;

            _errorCode1 = GetErrorCode();
            _errorCode2 = CheckReportFileExist("SearchAll_RtoL.mrt");

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

        private int GetErrorCode()
        {
            int _res = 0;
            int _rCount = _mainDataTable.Rows.Count;
            if (_rCount < 1)
                _res = 1;            
            return _res;
        }

        private void ShowErrorMessage(int ErrorCode)
        {
            string ms = "";
            switch (ErrorCode)
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

                ParentTable = GetParentDataTable();
                ChildTable = GetChildDataTable();


                DataSet ds = new DataSet();

                ds.Tables.Add(ParentTable);
                ds.Tables.Add(ChildTable);


                DataRelation r1 = new DataRelation("r1", ds.Tables[0].Columns["AgentId"], ds.Tables[1].Columns["ParentAgentId"]);

                ds.Relations.Add(r1);


                string _report = lg.GetMessageFromDll(_langCode, "Report");
                string _date = lg.GetMessageFromDll(_langCode, "EventDate");

                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SearchAll_RtoL.mrt");

                stiReport1.RegData(ds);


                stiReport1.Compile();
                stiReport1["CompanyName"] = Program.CustomerName;
                stiReport1["ReportTitle"] = _report + " " + this.Text;
                stiReport1["Date"] = _date + " : " + User.LocalToday.Trim();


                stiReport1["HCradif"] = HCradif;
                stiReport1["HPersonnelName"] = HPersonnelName;
                stiReport1["HSysyemName"] = HSysyemName;
                stiReport1["HLocation"] = HLocation;

                stiReport1["HIP"] = HIP;
                stiReport1["HCItem"] = HCItem;
                stiReport1["HCValue"] = HCValue;

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

        private DataTable GetParentDataTable()
        {
            DataTable dt1 = new DataTable();
            dt1.TableName = "Parent";
            dt1.Columns.Add("Radif", typeof(int));
            dt1.Columns.Add("AgentImage", typeof(Image));
            dt1.Columns.Add("AgentId", typeof(int));
            dt1.Columns.Add("PersonnelName", typeof(string));
            dt1.Columns.Add("AgentComputerName", typeof(string));
            dt1.Columns.Add("Location", typeof(string));
            dt1.Columns.Add("IPAddress", typeof(string));

            int rowCount = AgentList.Count;
            for (int i = 0; i < rowCount; i++)
            {

                dt1.Rows.Add(AgentList[i].Radif, AgentList[i].AgentImage, AgentList[i].AgentId, AgentList[i].PersonnelName, AgentList[i].AgentComputerName,
                             AgentList[i].Location,AgentList[i].IPAddress);
            }

            return dt1;
        }

        private DataTable GetChildDataTable()
        {
            DataTable dt2 = new DataTable();
            dt2.TableName = "Child";
            dt2.Columns.Add("Radif", typeof(int));
            dt2.Columns.Add("Id", typeof(int));
            dt2.Columns.Add("ParentAgentId", typeof(int));
            dt2.Columns.Add("Item", typeof(string));
            dt2.Columns.Add("Value", typeof(string));

            int rowCount = InAgentDetails.Count;
            for (int i = 0; i < rowCount; i++)
            {
                dt2.Rows.Add(InAgentDetails[i].Radif, InAgentDetails[i].Id, InAgentDetails[i].ParentAgentId, InAgentDetails[i].Item, InAgentDetails[i].Value);
            }

            return dt2;
        }

    }
}
