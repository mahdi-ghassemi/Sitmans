using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmSearchEvent_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _fromDate;
        private string _toDate;
        private string _agentId;
        private string _agentName;
        private int _selectedSystemIndex;
        private List<string> _eventId;

       

        public frmSearchEvent_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void frmSearchEvent_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            FillDate();
            FillSystemName();          
           
        }

        private void FillForm()
        {
            LogicLayer ll = new LogicLayer();

            this.Text = ll.GetMessageFromDll(_langCode, "EventReport");
            grbDate.Text = ll.GetMessageFromDll(_langCode, "ReportDate");
            lblFromDate.Text = ll.GetMessageFromDll(_langCode, "FromDate");
            lblToDate.Text = ll.GetMessageFromDll(_langCode, "ToDate");

            grbAgent.Text = ll.GetMessageFromDll(_langCode, "SystemSelection");
            lblAgentName.Text = ll.GetMessageFromDll(_langCode, "SelectSystem");
          
            btnCancel.Text = ll.GetMessageFromDll(_langCode, "btnCancel");
            btnOk.Text = ll.GetMessageFromDll(_langCode, "btnOk");

        }

        private void FillDate()
        {

            dapFrom.GeoDate = DateTime.Now;
            dapTo.GeoDate = DateTime.Now;
        }

        private void FillSystemName()
        {
            int count = Program.AgentList.Count;
            ddlAgentName.BeginUpdate();
            for (int i = 0; i < count; i++)
            {
                ddlAgentName.Items.Add(Program.AgentList[i].ComputerName);

            }
            ddlAgentName.EndUpdate();
            ddlAgentName.SelectedIndex = 0;

        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string[] GetEventList()
        {
            LogicLayer lg = new LogicLayer();
            string[] _eventsName = new string[31];

        
            _eventsName[0] = lg.GetMessageFromDll(_langCode, "SelectAll");           
            _eventsName[1] = lg.GetMessageFromDll(_langCode, "CPUChanges");  
            _eventsName[2] = lg.GetMessageFromDll(_langCode, "MainboardChanges");            
            _eventsName[3] = lg.GetMessageFromDll(_langCode, "BiosChanges");
            _eventsName[4] = lg.GetMessageFromDll(_langCode, "MemoryChanges");                
            _eventsName[5] = lg.GetMessageFromDll(_langCode, "HardDiskChanges");                  
            _eventsName[6] = lg.GetMessageFromDll(_langCode, "LogicDiskChanges");                        
            _eventsName[7] = lg.GetMessageFromDll(_langCode, "VideoCardChanges");                        
            _eventsName[8] = lg.GetMessageFromDll(_langCode, "NetAdapterChanges");                           
            _eventsName[9] = lg.GetMessageFromDll(_langCode, "KeyboardChanges");                            
            _eventsName[10] = lg.GetMessageFromDll(_langCode, "MouseChanges");
            _eventsName[11] = lg.GetMessageFromDll(_langCode, "MonitorChanges");
            _eventsName[12] = lg.GetMessageFromDll(_langCode, "PrinterChanges");
            _eventsName[13] = lg.GetMessageFromDll(_langCode, "ScannerChanges");
            _eventsName[14] = lg.GetMessageFromDll(_langCode, "CammeraChanges");
            _eventsName[15] = lg.GetMessageFromDll(_langCode, "CdromChanges");
            _eventsName[16] = lg.GetMessageFromDll(_langCode, "ModemChanges");

            _eventsName[17] = lg.GetMessageFromDll(_langCode, "ApplicationChanges");
            _eventsName[18] = lg.GetMessageFromDll(_langCode, "OsChanges");           
            _eventsName[19] = lg.GetMessageFromDll(_langCode, "UpdatesChanges");

            _eventsName[20] = lg.GetMessageFromDll(_langCode, "IpChanges");
            _eventsName[21] = lg.GetMessageFromDll(_langCode, "SubnetChanges");
            _eventsName[22] = lg.GetMessageFromDll(_langCode, "GwChanges");
            _eventsName[23] = lg.GetMessageFromDll(_langCode, "MacChanges");
            _eventsName[24] = lg.GetMessageFromDll(_langCode, "DnsChanges");
            _eventsName[25] = lg.GetMessageFromDll(_langCode, "DhcpChanges");
          

            _eventsName[26] = lg.GetMessageFromDll(_langCode, "PowerChanges");
            _eventsName[27] = lg.GetMessageFromDll(_langCode, "FlashChanges");
            _eventsName[28] = lg.GetMessageFromDll(_langCode, "UserAccountChange");
            _eventsName[29] = lg.GetMessageFromDll(_langCode, "GroupAccountChange");

            _eventsName[30] = lg.GetMessageFromDll(_langCode, "PublicChanges");

            

            

            return _eventsName;
        }       

        private string GetDateTime(string DT)
        {
            DateTime d = DateTime.Parse(DT);
            string yyyy = d.Year.ToString();
            string mm = d.Month.ToString();
            string dd = d.Day.ToString();
            switch (mm)
            {
                case "1":
                    {
                        mm = "01";
                        break;
                    }
                case "2":
                    {
                        mm = "02";
                        break;
                    }
                case "3":
                    {
                        mm = "03";
                        break;
                    }
                case "4":
                    {
                        mm = "04";
                        break;
                    }
                case "5":
                    {
                        mm = "05";
                        break;
                    }
                case "6":
                    {
                        mm = "06";
                        break;
                    }
                case "7":
                    {
                        mm = "07";
                        break;
                    }
                case "8":
                    {
                        mm = "08";
                        break;
                    }
                case "9":
                    {
                        mm = "09";
                        break;
                    }
            }
            switch (dd)
            {
                case "1":
                    {
                        dd = "01";
                        break;
                    }
                case "2":
                    {
                        dd = "02";
                        break;
                    }
                case "3":
                    {
                        dd = "03";
                        break;
                    }
                case "4":
                    {
                        dd = "04";
                        break;
                    }
                case "5":
                    {
                        dd = "05";
                        break;
                    }
                case "6":
                    {
                        dd = "06";
                        break;
                    }
                case "7":
                    {
                        dd = "07";
                        break;
                    }
                case "8":
                    {
                        dd = "08";
                        break;
                    }
                case "9":
                    {
                        dd = "09";
                        break;
                    }
            }

            string result = mm + "/" + dd + "/" + yyyy;
            return result;
             
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string _fd = GetDateTime(dapFrom.GeoDate.ToString());
            string _td = GetDateTime(dapTo.GeoDate.ToString());

            _fromDate = _fd + " 00:00:02 ق.ظ";
            _toDate = _td + " 11:59:58 ب.ظ";

            _agentId = Program.AgentList[_selectedSystemIndex].AgentID;
            _agentName = Program.AgentList[_selectedSystemIndex].ComputerName;

            frmRepShowEvents_RtoL frmevent = new frmRepShowEvents_RtoL(_agentId, _agentName, _fromDate, _toDate);
            this.Hide();
            frmevent.Show();

            /*
            
            int _count;
            LogicLayer lg = new LogicLayer();
            _eventId = new List<string>();

          

            _count = ddlEvents.CheckedItems.Count;

            if (ddlEvents.GetItemCheckState(0) == CheckState.Checked)
            {
                SetAllEventId();
            }
            if (ddlEvents.GetItemCheckState(0) == CheckState.Unchecked)
            {
                if (ddlEvents.GetItemCheckState(1) == CheckState.Checked)
                {
                    SetCpuEventId();
                }

                if (ddlEvents.GetItemCheckState(2) == CheckState.Checked)
                {
                    SetMainBoardEventId();
                }

                if (ddlEvents.GetItemCheckState(3) == CheckState.Checked)
                {
                    SetBiosEventId();
                }

                if (ddlEvents.GetItemCheckState(4) == CheckState.Checked)
                {
                    SetMemoryEventId();
                }

                if (ddlEvents.GetItemCheckState(5) == CheckState.Checked)
                {
                    SetHardDiskEventId();
                }

                if (ddlEvents.GetItemCheckState(6) == CheckState.Checked)
                {
                    SetLogicDiskEventId();
                }

                if (ddlEvents.GetItemCheckState(7) == CheckState.Checked)
                {
                    SetVideoCardEventId();
                }

                if (ddlEvents.GetItemCheckState(8) == CheckState.Checked)
                {
                    SetNetAdapterEventId();
                }

                if (ddlEvents.GetItemCheckState(9) == CheckState.Checked)
                {
                    SetKeyboardEventId();
                }

                if (ddlEvents.GetItemCheckState(10) == CheckState.Checked)
                {
                    SetMouseEventId();
                }

                if (ddlEvents.GetItemCheckState(11) == CheckState.Checked)
                {
                    SetMonitorEventId();
                }

                if (ddlEvents.GetItemCheckState(12) == CheckState.Checked)
                {
                    SetPrinterEventId();
                }

                if (ddlEvents.GetItemCheckState(13) == CheckState.Checked)
                {
                    SetScannerEventId();
                }

                if (ddlEvents.GetItemCheckState(14) == CheckState.Checked)
                {
                    SetCammeraEventId();
                }

                if (ddlEvents.GetItemCheckState(15) == CheckState.Checked)
                {
                    SetCdromEventId();
                }

                if (ddlEvents.GetItemCheckState(16) == CheckState.Checked)
                {
                    SetModemEventId();
                }

                if (ddlEvents.GetItemCheckState(17) == CheckState.Checked)
                {
                    SetApplicationEventId();
                }

                if (ddlEvents.GetItemCheckState(18) == CheckState.Checked)
                {
                    SetOsEventId();
                }

                if (ddlEvents.GetItemCheckState(19) == CheckState.Checked)
                {
                    SetUpdatesEventId();
                }

                if (ddlEvents.GetItemCheckState(20) == CheckState.Checked)
                {
                    SetIpEventId();
                }

                if (ddlEvents.GetItemCheckState(21) == CheckState.Checked)
                {
                    SetSubnetEventId();
                }

                if (ddlEvents.GetItemCheckState(22) == CheckState.Checked)
                {
                    SetGwEventId();
                }

                if (ddlEvents.GetItemCheckState(23) == CheckState.Checked)
                {
                    SetMacEventId();
                }             

                if (ddlEvents.GetItemCheckState(24) == CheckState.Checked)
                {
                    SetDnsEventId();
                }

                if (ddlEvents.GetItemCheckState(25) == CheckState.Checked)
                {
                    SetDhcpEventId();
                }

                if (ddlEvents.GetItemCheckState(26) == CheckState.Checked)
                {
                    SetPowerEventId();
                }

                if (ddlEvents.GetItemCheckState(27) == CheckState.Checked)
                {
                    SetFlashEventId();
                }

                if (ddlEvents.GetItemCheckState(28) == CheckState.Checked)
                {
                    SetUserAccountEventId();
                }

                if (ddlEvents.GetItemCheckState(29) == CheckState.Checked)
                {
                    SetGroupAccountEventId();
                }

                if (ddlEvents.GetItemCheckState(30) == CheckState.Checked)
                {
                    SetPublicEventId();
                }
            }

            SetQuery();
             */



            
        }

        private void SetQuery()
        {
            int _count = _eventId.Count;
            string _query = "SELECT * FROM Agent.Events WHERE AgentId = " + _agentId;
            string _d = dapFrom.GeoDate.ToString();
            _d = dapTo.GeoDate.ToString();

        }

        private void SetPublicEventId()
        {
            _eventId.Add("31001");
            _eventId.Add("31002");
            _eventId.Add("31003");
            _eventId.Add("31004");

            _eventId.Add("32000");

            _eventId.Add("33000");
            _eventId.Add("33001");
        }


        private void SetGroupAccountEventId()
        {
            _eventId.Add("29001");
            _eventId.Add("29002");
            _eventId.Add("29003");
            _eventId.Add("29004");
            _eventId.Add("29005");
        }

        private void SetUserAccountEventId()
        {
            _eventId.Add("28001");
            _eventId.Add("28002");
            _eventId.Add("28003");
            _eventId.Add("28004");
            _eventId.Add("28005");
        }

        private void SetFlashEventId()
        {
            _eventId.Add("27001");
            _eventId.Add("27002");
        }

        private void SetPowerEventId()
        {
            _eventId.Add("26001");
            _eventId.Add("26002");
            _eventId.Add("26003");
            _eventId.Add("26004");
        }

        private void SetDnsEventId()
        {
            _eventId.Add("24000");
        }

        private void SetDhcpEventId()
        {
            _eventId.Add("25000");
            _eventId.Add("25001");
        }

        private void SetMacEventId()
        {
            _eventId.Add("23000");
        }

        private void SetGwEventId()
        {
            _eventId.Add("22000");
        }

        private void SetSubnetEventId()
        {
            _eventId.Add("21000");
        }

        private void SetIpEventId()
        {
            _eventId.Add("20000");
        }

        private void SetUpdatesEventId()
        {
            _eventId.Add("19001");
            _eventId.Add("19002");
        }

        private void SetOsEventId()
        {
            _eventId.Add("18001");
            _eventId.Add("18002");
            _eventId.Add("18003");
            _eventId.Add("18004");
            _eventId.Add("18005");
        }

        private void SetApplicationEventId()
        {
            _eventId.Add("17001");
            _eventId.Add("17002");
        }

        private void SetModemEventId()
        {
            _eventId.Add("16001");
            _eventId.Add("16002");
        }

        private void SetCdromEventId()
        {
            _eventId.Add("15001");
            _eventId.Add("15002");
            _eventId.Add("15003");
        }

        private void SetCammeraEventId()
        {
            _eventId.Add("14000");
        }

        private void SetScannerEventId()
        {
            _eventId.Add("13000");
        }

        private void SetPrinterEventId()
        {
            _eventId.Add("12000");
            _eventId.Add("12001");
            _eventId.Add("12002");
            _eventId.Add("12003");
        }

        private void SetMonitorEventId()
        {
            _eventId.Add("11000");
        }

        private void SetMouseEventId()
        {
            _eventId.Add("10000");
        }

        private void SetKeyboardEventId()
        {
            _eventId.Add("9000");
        }

        private void SetNetAdapterEventId()
        {
            _eventId.Add("8001");
            _eventId.Add("8002");
            _eventId.Add("8003");
            _eventId.Add("8004");
            _eventId.Add("8005");
            _eventId.Add("8006");
            _eventId.Add("8007");
        }

        private void SetVideoCardEventId()
        {
            _eventId.Add("7001");
            _eventId.Add("7002");
            _eventId.Add("7003");
            _eventId.Add("7004");
            _eventId.Add("7005");
            _eventId.Add("7006");
            _eventId.Add("7007");
        }

        private void SetLogicDiskEventId()
        {
            _eventId.Add("6001");
            _eventId.Add("6002");
            _eventId.Add("6003");
            _eventId.Add("6004");
            _eventId.Add("6005");
            _eventId.Add("6006");
            _eventId.Add("6007");
        }

        private void SetHardDiskEventId()
        {
            _eventId.Add("5001");
            _eventId.Add("5002");
            _eventId.Add("5003");
            _eventId.Add("5004");
            _eventId.Add("5005");
            _eventId.Add("5006");
        }

        private void SetMemoryEventId()
        {
            _eventId.Add("4001");
            _eventId.Add("4002");
            _eventId.Add("4003");
            _eventId.Add("4004");
        }

        private void SetBiosEventId()
        {
            _eventId.Add("3001");
            _eventId.Add("3002");
            _eventId.Add("3003");
            _eventId.Add("3004");
            _eventId.Add("3005");
        }

        private void SetMainBoardEventId()
        {
            _eventId.Add("2001");
            _eventId.Add("2002");
            _eventId.Add("2003");
            _eventId.Add("2004");
        }

        private void SetCpuEventId()
        {
            _eventId.Add("1000");
        }


        private void SetAllEventId()
        {
            _eventId.Add("1000");

            _eventId.Add("2001");
            _eventId.Add("2002");
            _eventId.Add("2003");
            _eventId.Add("2004");

            _eventId.Add("3001");
            _eventId.Add("3002");
            _eventId.Add("3003");
            _eventId.Add("3004");
            _eventId.Add("3005");

            _eventId.Add("4001");
            _eventId.Add("4002");
            _eventId.Add("4003");
            _eventId.Add("4004");

            _eventId.Add("5001");
            _eventId.Add("5002");
            _eventId.Add("5003");
            _eventId.Add("5004");
            _eventId.Add("5005");
            _eventId.Add("5006");


            _eventId.Add("6001");
            _eventId.Add("6002");
            _eventId.Add("6003");
            _eventId.Add("6004");
            _eventId.Add("6005");
            _eventId.Add("6006");
            _eventId.Add("6007");

            _eventId.Add("7001");
            _eventId.Add("7002");
            _eventId.Add("7003");
            _eventId.Add("7004");
            _eventId.Add("7005");
            _eventId.Add("7006");
            _eventId.Add("7007");

            _eventId.Add("8001");
            _eventId.Add("8002");
            _eventId.Add("8003");
            _eventId.Add("8004");
            _eventId.Add("8005");
            _eventId.Add("8006");
            _eventId.Add("8007");

            _eventId.Add("9000");

            _eventId.Add("10000");

            _eventId.Add("11000");


            _eventId.Add("12000");
            _eventId.Add("12001");
            _eventId.Add("12002");
            _eventId.Add("12003");

            _eventId.Add("13000");

            _eventId.Add("14000");

            _eventId.Add("15001");
            _eventId.Add("15002");
            _eventId.Add("15003");

            _eventId.Add("16001");
            _eventId.Add("16002");

            _eventId.Add("17001");
            _eventId.Add("17002");

            _eventId.Add("18001");
            _eventId.Add("18002");
            _eventId.Add("18003");
            _eventId.Add("18004");
            _eventId.Add("18005");

            _eventId.Add("19001");
            _eventId.Add("19002");

            _eventId.Add("20000");


            _eventId.Add("21000");

            _eventId.Add("22000");

            _eventId.Add("23000");

            _eventId.Add("24000");

            _eventId.Add("25000");
            _eventId.Add("25001");

            _eventId.Add("26001");
            _eventId.Add("26002");
            _eventId.Add("26003");
            _eventId.Add("26004");

            _eventId.Add("27001");
            _eventId.Add("27002");

            _eventId.Add("28001");
            _eventId.Add("28002");
            _eventId.Add("28003");
            _eventId.Add("28004");
            _eventId.Add("28005");

          
            _eventId.Add("29001");
            _eventId.Add("29002");
            _eventId.Add("29003");
            _eventId.Add("29004");
            _eventId.Add("29005");

            _eventId.Add("30001");
            _eventId.Add("30002");


            _eventId.Add("31001");
            _eventId.Add("31002");
            _eventId.Add("31003");
            _eventId.Add("31004");

            _eventId.Add("32000");

            _eventId.Add("33000");
            _eventId.Add("33001");           
        }

        private void ddlAgentName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            _selectedSystemIndex = ddlAgentName.SelectedIndex;
        }




        
    }
}
