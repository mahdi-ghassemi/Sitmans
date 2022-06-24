using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmRepOnWork_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _fromDate;
        private string _toDate;
        private string _agentId;
        private string _agentName;
        private string _groupPanelText;
        private List<OnWorkObject> OnWorkList;

        public frmRepOnWork_RtoL(string AgentId, string AgentName, string FromDate, string ToDate)
        {
            _langCode = Program.LangCode.ToString();
            _agentId = AgentId;
            _fromDate = FromDate;
            _toDate = ToDate;
            _agentName = AgentName;
            InitializeComponent();
        }

        private void frmRepOnWork_RtoL_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            string radif, timeOff, onDurationTime, date, timeOn, idleDurationTime, standbyDurationTime, helpfulDurationTime ;
            int rowCount;
            string Id;
            string EventId;

            LogicLayer lg = new LogicLayer();

            this.Text = lg.GetMessageFromDll(_langCode, "OnWorkReport") + "  " + _agentName;

            radif = lg.GetMessageFromDll(_langCode, "radif");
            timeOff = lg.GetMessageFromDll(_langCode, "SystemOffTime");
            timeOn = lg.GetMessageFromDll(_langCode, "SystemOnTime");
            date = lg.GetMessageFromDll(_langCode, "EventDate");
            idleDurationTime = lg.GetMessageFromDll(_langCode, "SystemIdleDuration");
            standbyDurationTime = lg.GetMessageFromDll(_langCode, "SystemStandbyDurationTime");
            helpfulDurationTime = lg.GetMessageFromDll(_langCode, "SystemHelpfulDurationTime");
            onDurationTime = lg.GetMessageFromDll(_langCode, "OnDurationTime");
            _groupPanelText = lg.GetMessageFromDll(_langCode, "GridViewGroupPanel");


            DataTable dt = new DataTable();

            dt = lg.GetAgentOnWork(_agentId, _fromDate, _toDate);
            rowCount = dt.Rows.Count;
            List<String> dateList = new List<string>();
            dateList = lg.GetListOnDate(dt);



            string des, det, da, ti;

            OnWorkList = new List<OnWorkObject>();
            this.radGridView1.TableElement.BeginUpdate();
            int _parentId, _radif;
            string _date,_powerOnTime;
            for (int m = 0; m < dateList.Capacity; m++)
            {
                _parentId = m;
                _radif = m + 1;
                _date = dateList[m];
                DataRow[] powerOnTime = dt.Select("(EventDateTime = ");
                //OnWorkList.Add(new OnWorkObject(_parentId,_radif,_date))
            }


                for (int i = 0; i < rowCount; i++)
                {
                    Id = dt.Rows[i]["Id"].ToString();
                    EventId = dt.Rows[i]["EventId"].ToString();

                    des = lg.GetEventDescription(EventId);
                    det = lg.GetEventDetails(EventId, dt.Rows[i]["LastValue"].ToString(), dt.Rows[i]["CurrentValue"].ToString());
                    da = lg.GetEventDateFromSql(dt.Rows[i]["EventDateTime"].ToString());
                    ti = lg.GetEventTimeFromSql(dt.Rows[i]["EventDateTime"].ToString());

                }


            radGridView1.DataSource = OnWorkList;
            radGridView1.Columns[0].HeaderText = radif;
            radGridView1.Columns[1].HeaderText = date;
            radGridView1.Columns[2].HeaderText = timeOn;
            radGridView1.Columns[3].HeaderText = timeOff;
            radGridView1.Columns[4].HeaderText = idleDurationTime;
            radGridView1.Columns[5].HeaderText = standbyDurationTime;
            radGridView1.Columns[6].HeaderText = helpfulDurationTime;
            radGridView1.Columns[7].HeaderText = onDurationTime;
           

            radGridView1.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[6].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[7].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            radGridView1.Columns[0].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[1].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[4].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[5].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[6].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[7].TextAlignment = ContentAlignment.MiddleCenter;

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

        private void radGridView1_GroupByChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            if (e.GridViewTemplate.GroupDescriptors.Count == 0)
            {
                this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
            }
        }

        private void frmRepOnWork_RtoL_Shown(object sender, EventArgs e)
        {
            this.radGridView1.GridViewElement.GroupPanelElement.Text = _groupPanelText;
        }
    }
}
