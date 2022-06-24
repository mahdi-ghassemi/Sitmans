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
    public partial class frmWaiting_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private LogicLayer lg;
        private int _opration;
       
        public frmWaiting_RtoL(int Opration)
        {
            _opration = Opration;
            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();
            InitializeComponent();
        }

        private void frmWaiting_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();          
            wabWait.Text = lg.GetMessageFromDll(_langCode, "LoadDataWaitting");
            timProgress.Enabled = true;
        }

        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "LoadData");                      
        }

        private void timProgress_Tick(object sender, EventArgs e)
        {
            if (_opration == 1)
            {
                MainFormWaitting();
            }
            if (_opration == 2)
            {
                AgentListViewWaitting();
            }
            if (_opration == 3)
            {
                ReportComplete();
            }
           
        }

        private void ReportComplete()
        {
            if (Program.ReportReady == false)
            {
                wabWait.StartWaiting();
            }
            else
            {
                timProgress.Enabled = false;
                wabWait.StopWaiting();
                this.Close();
            }
        }

      

        private void MainFormWaitting()
        {
            if (Program.AgentLoadedDataCount < Program.TotalAgentRegistered)
            {
                wabWait.StartWaiting();
            }
            else
            {
                timProgress.Enabled = false;
                wabWait.StopWaiting();
                this.Close();
            }
        }

        private void AgentListViewWaitting()
        {

            if (Program.AgentViewLoadComplete == false)
            {
                wabWait.StartWaiting();
            }
            else
            {
                timProgress.Enabled = false;
                wabWait.StopWaiting();
                this.Close();
            }
        }
    }
}
