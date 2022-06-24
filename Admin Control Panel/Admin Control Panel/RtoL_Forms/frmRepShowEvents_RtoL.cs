using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;
using Admin_Control_Panel.Classes;
using Stimulsoft.Report;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmRepShowEvents_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _fromDate;
        private string _toDate;
        private string _agentId;
        private string _agentName;
        private List<EventObject> EventList;
        private string _groupPanelText;
        private string _page;
        private string _from;
        private int _indexInAgentFirstList;

        
        private string HRadif, HPersonnelName, HSysyemName, HLocation, HIP;  // Header Column Text
        private string HDescription, HNewValue, Hdate, Htime,HFromDate,HToDate;

        public frmRepShowEvents_RtoL(string AgentId, string AgentName, string FromDate, string ToDate)
        {
            _langCode = Program.LangCode.ToString();
            _agentId = AgentId;
            _fromDate = FromDate;
            _toDate = ToDate;
            _agentName = AgentName;         
            InitializeComponent();
        }

        private void frmRepShowEvents_RtoL_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            string radif, description, newvalue, date, time;
            int rowCount;
            string Id;
            string EventId;

            LogicLayer lg = new LogicLayer();

            this.Text = lg.GetMessageFromDll(_langCode, "EventReportSysetm") + "  " + _agentName;

            radif = lg.GetMessageFromDll(_langCode, "radif");
            description = lg.GetMessageFromDll(_langCode, "EventType");
            newvalue = lg.GetMessageFromDll(_langCode, "Description");
            date = lg.GetMessageFromDll(_langCode, "EventDate");
            time = lg.GetMessageFromDll(_langCode, "EventTime");
            _groupPanelText = lg.GetMessageFromDll(_langCode, "GridViewGroupPanel");

            HFromDate = lg.GetMessageFromDll(_langCode, "FromDate");
            HToDate = lg.GetMessageFromDll(_langCode, "ToDate");

            HRadif = radif;
            HDescription = description;
            HNewValue = newvalue;
            Hdate = date;
            Htime = time;

            DataTable dt = new DataTable();
            dt = lg.GetAgentAllEvents(_agentId, _fromDate, _toDate);
            rowCount = dt.Rows.Count;
            
            string des, det, da, ti;

            EventList = new List<EventObject>();
            this.radGridView1.TableElement.BeginUpdate();
            for (int i = 0; i < rowCount; i++)
            {
                Id = dt.Rows[i]["Id"].ToString();
                EventId = dt.Rows[i]["EventId"].ToString();

                des = lg.GetEventDescription(EventId);
                det = lg.GetEventDetails(EventId, dt.Rows[i]["LastValue"].ToString(), dt.Rows[i]["CurrentValue"].ToString());
                da = lg.GetEventDateFromSql(dt.Rows[i]["EventDateTime"].ToString());
                ti = lg.GetEventTimeFromSql(dt.Rows[i]["EventDateTime"].ToString());
                EventList.Add(new EventObject(i + 1, des, det, da, ti));
            }        


            radGridView1.DataSource = EventList;
            radGridView1.Columns[0].HeaderText = radif;
            radGridView1.Columns[1].HeaderText = description;
            radGridView1.Columns[2].HeaderText = newvalue;
            radGridView1.Columns[3].HeaderText = date;
            radGridView1.Columns[4].HeaderText = time;


            radGridView1.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;


            radGridView1.Columns[0].MaxWidth = 40;
            radGridView1.Columns[0].MinWidth = 39;

            radGridView1.Columns[1].MaxWidth = 200;
            radGridView1.Columns[1].MinWidth = 199;

            radGridView1.Columns[2].MinWidth = 400;

            radGridView1.Columns[3].MaxWidth = 100;
            radGridView1.Columns[3].MinWidth = 99;

            radGridView1.Columns[4].MaxWidth = 100;
            radGridView1.Columns[4].MinWidth = 99;

            radGridView1.AllowDragToGroup = true;


            this.radGridView1.TableElement.EndUpdate(true);
           
        }

        private void radGridView1_GroupByChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            
            if (e.GridViewTemplate.GroupDescriptors.Count == 0)
            {
                this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
                this.radGridView1.GridViewElement.GroupPanelElement.ToolTipText = "gh";

            }
        }

        private void frmRepShowEvents_RtoL_Shown(object sender, EventArgs e)
        {
            this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
            this.radGridView1.GridViewElement.GroupPanelElement.ToolTipText = "gh";
            Program.ReportReady = true;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            int _errorCode1 = 0;
            int _errorCode2 = 0;

            _errorCode1 = GetErrorCode();
            _errorCode2 = CheckReportFileExist("ShowEvents_RtoL.mrt");

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

        private void ShowErrorMessage(int ErrorCode)
        {
            LogicLayer lg = new LogicLayer();
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

        private int GetErrorCode()
        {
            int _res = 0;
            int _rCount = EventList.Count;
            if (_rCount < 1)
                _res = 1;
            return _res;
        }

        private void CreateReport()
        {
            try
            {

                DataTable ParentTable = new DataTable();
                LogicLayer lg = new LogicLayer();

                _indexInAgentFirstList = Program.AgentList.FindIndex(item => item.AgentID == _agentId);


                HPersonnelName = lg.GetMessageFromDll(_langCode, "UserFullName");
                HSysyemName = lg.GetMessageFromDll(_langCode, "System");
                HLocation = lg.GetMessageFromDll(_langCode, "LocalAddress");
                HIP = lg.GetMessageFromDll(_langCode, "IPAddress");

                _page = lg.GetMessageFromDll(_langCode, "Page");
                _from = lg.GetMessageFromDll(_langCode, "From");



                ParentTable = GetParentDataTable();


                string _report = lg.GetMessageFromDll(_langCode, "EventReport");
                string _date = lg.GetMessageFromDll(_langCode, "EventDate");

                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\ShowEvents_RtoL.mrt");

                stiReport1.RegData("Parent", ParentTable);


                stiReport1.Compile();
                stiReport1["CompanyName"] = Program.CustomerName;
                stiReport1["ReportTitle"] = _report;
                stiReport1["Date"] = _date + " : " + User.LocalToday.Trim();


                stiReport1["HRadif"] = HRadif;
                stiReport1["HPersonnelName"] = HPersonnelName;
                stiReport1["HSysyemName"] = HSysyemName;
                stiReport1["HLocation"] = HLocation;
                stiReport1["HIP"] = HIP;
                stiReport1["HDescription"] = HDescription;
                stiReport1["HNewValue"] = HNewValue;
                stiReport1["Hdate"] = Hdate;
                stiReport1["Htime"] = Htime;
                stiReport1["HFromDate"] = HFromDate;
                stiReport1["HToDate"] = HToDate;


                stiReport1["PPersonelName"] = Program.dataSource[_indexInAgentFirstList].UserFullName;
                stiReport1["PComputerName"] = Program.dataSource[_indexInAgentFirstList].ComputerName;
                stiReport1["PLocation"] = Program.dataSource[_indexInAgentFirstList].Buildding + "-" +
                                          Program.dataSource[_indexInAgentFirstList].Class + "-" +
                                          Program.dataSource[_indexInAgentFirstList].Room + "-" +
                                          Program.dataSource[_indexInAgentFirstList].Department;
                stiReport1["PIP"] = Program.dataSource[_indexInAgentFirstList].AgentIP;

                stiReport1["PFromDate"] = lg.GetEventDateFromSql(_fromDate);
                stiReport1["PToDate"] = lg.GetEventDateFromSql(_toDate);


                stiReport1["Page"] = _page;
                stiReport1["From"] = _from;

                stiReport1.Dictionary.Synchronize();
                stiReport1.Render();

                StiOptions.Viewer.AllowUseDragDrop = false;

                stiReport1.Show();
            }
            catch (Exception)
            {
                LogicLayer lg2 = new LogicLayer();
                string ms = lg2.GetErrorMessage(34);
                frmShowInfoSmall_RtoL frmi = new frmShowInfoSmall_RtoL(ms, 2);
                frmi.ShowDialog();
            }
        }

        private DataTable GetParentDataTable()
        {
            DataTable dt1 = new DataTable();
            dt1.TableName = "Parent";
            dt1.Columns.Add("radif", typeof(int));
            dt1.Columns.Add("description", typeof(string));
            dt1.Columns.Add("newvalue", typeof(string));
            dt1.Columns.Add("date", typeof(string));
            dt1.Columns.Add("time", typeof(string));        

            int rowCount = EventList.Count;

            for (int i = 0; i < rowCount; i++)
            {
                dt1.Rows.Add(EventList[i].radif, EventList[i].description, EventList[i].newvalue, EventList[i].date, EventList[i].time);
            }

            return dt1;
        }

    }

} 
