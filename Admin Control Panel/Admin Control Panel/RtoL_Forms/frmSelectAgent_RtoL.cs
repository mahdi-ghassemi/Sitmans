using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;
using Admin_Control_Panel.Classes;
using System.Threading;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmSelectAgent_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _fromDate;
        private string _toDate;
        private string _agentId;
        private string _agentName;
        private string _fd;
        private string _td;
        private int _selectedSystemIndex;
        private List<string> _eventId;
        private string _reportName;

        private Thread thrAllEventShow;
        private ThreadStart thsAllEventShow;

        private Thread thrWaitting;
        private ThreadStart thsWaitting;

       

        public frmSelectAgent_RtoL(string ReportName)
        {
            _langCode = Convert.ToString(Program.LangCode);
            _reportName = ReportName; 
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
            /*
            int count = Program.AgentList.Count;
            ddlAgentName.BeginUpdate();
            for (int i = 0; i < count; i++)
            {
                ddlAgentName.Items.Add(Program.AgentList[i].ComputerName);

            }
            ddlAgentName.EndUpdate();
            ddlAgentName.SelectedIndex = 0;
            */
            LogicLayer lg = new LogicLayer();
            int count = Program.AgentList.Count;
            RadListDataItem ditem = new RadListDataItem();
            ddlAgentName.BeginUpdate();
            this.ddlAgentName.ListElement.AutoSizeItems = true;


            for (int i = 0; i < count; i++)
            {
                if (Program.dataSource[i].UserFullName != " ")
                    ddlAgentName.Items.Add(Program.dataSource[i].UserFullName);
                else
                    ddlAgentName.Items.Add(Program.AgentList[i].ComputerName);

                ddlAgentName.Items[i].TextImageRelation = TextImageRelation.ImageBeforeText;
                ddlAgentName.Items[i].Image = GetImageFromData(lg.imageToByteArray((Program.dataSource[i].UserImage)));
                ddlAgentName.Items[i].Font = new Font("Tahoma", 9, FontStyle.Regular);
            }
            ddlAgentName.EndUpdate();
            ddlAgentName.SelectedIndex = 0;

        }

        private Image GetImageFromData(byte[] imageData)
        {
            const int OleHeaderLength = 78;
            MemoryStream memoryStream = new MemoryStream();
            if (HasOleContainerHeader(imageData))
            {
                memoryStream.Write(imageData, OleHeaderLength, imageData.Length - OleHeaderLength);
            }
            else
            {
                memoryStream.Write(imageData, 0, imageData.Length);
            }
            Bitmap bitmap = new Bitmap(memoryStream);
            return bitmap.GetThumbnailImage(55, 65, null, new IntPtr());
        }

        private bool HasOleContainerHeader(byte[] imageByteArray)
        {
            const byte OleByte0 = 21;
            const byte OleByte1 = 28;
            return (imageByteArray[0] == OleByte0) && (imageByteArray[1] == OleByte1);
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
            string result = mm + "/" + dd + "/" + yyyy;
            return result;
             
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _fd = GetDateTime(dapFrom.GeoDate.ToString());
                _td = GetDateTime(dapTo.GeoDate.ToString());

                _agentId = Program.AgentList[_selectedSystemIndex].AgentID;
                _agentName = Program.AgentList[_selectedSystemIndex].ComputerName;

                thsAllEventShow = new ThreadStart(AllEventReport);
                thrAllEventShow = new Thread(thsAllEventShow);
                thrAllEventShow.Start();
                /*
                switch (_reportName)
                {
                    case "AllEventReport":
                        {
                           // thsWaitting = new ThreadStart(Waitting);
                            //thrWaitting = new Thread(thsWaitting);

                            thsAllEventShow = new ThreadStart(AllEventReport);
                            thrAllEventShow = new Thread(thsAllEventShow);

                            thrAllEventShow.Start();

                            if (thrAllEventShow.IsAlive == true)
                            {
                                timReportCheck.Enabled = true;
                                Program.ReportReady = false;
                                thrWaitting.Start();
                            }


                            break;
                        }
                    case "OnWorkReport":
                        {
                            frmRepOnWork_RtoL frmonwork = new frmRepOnWork_RtoL(_agentId, _agentName, _fd, _td);
                            this.Hide();
                            frmonwork.Show();
                            break;
                        }
                }
                 */
            }
            catch (Exception ex)
            {

            }
        }

        private void AllEventReport()
        {
            frmRepShowEvents_RtoL frmevent = new frmRepShowEvents_RtoL(_agentId, _agentName, _fd, _td);
            this.Invoke((MethodInvoker)delegate { this.Hide(); });
            frmevent.ShowDialog();
        }

        private void Waitting()
        {
            frmWaiting_RtoL frmva = new frmWaiting_RtoL(3);
            frmva.ShowDialog();
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

        private void timReportCheck_Tick(object sender, EventArgs e)
        {
            if (thrAllEventShow.IsAlive == false || Program.ReportReady == true)
            {
                timReportCheck.Enabled = false;
                Program.ReportReady = false;
                thrWaitting.Abort();
            }
        }




        
    }
}
