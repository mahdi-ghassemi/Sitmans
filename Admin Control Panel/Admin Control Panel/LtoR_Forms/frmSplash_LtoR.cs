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

namespace Admin_Control_Panel.LtoR_Forms
{
    public partial class frmSplash_LtoR : Telerik.WinControls.UI.RadForm
    {
        private Thread thrAgentList;
        private ThreadStart thsAgentList;
        private int lenght;
        private BackgroundWorker bw;

        public frmSplash_LtoR()
        {
            InitializeComponent();
        }

        private void SetAgentList()
        {

            Program.AgentList = new List<Agents>(Program.AgentCount);

            LogicLayer logl = new LogicLayer();
            string[,] _header = logl.GetAgentList();
            lenght = _header.Length / 9;

            if (lenght <= Program.AgentCount)
            {
                for (int i = 0; i < lenght; i++)
                {
                    Program.AgentList.Add(new Agents());
                    Program.AgentList[i].AgentID = _header[i, 0];
                    Program.AgentList[i].AgentNumber = _header[i, 1];
                    Program.AgentList[i].ComputerName = _header[i, 2];
                    Program.AgentList[i].Caption = _header[i, 3];

                    Program.AgentList[i].UUID = _header[i, 5];
                    Program.AgentList[i].Organization = _header[i, 6];
                    Program.AgentList[i].RegisterCompany = _header[i, 7];
                    Program.AgentList[i].RegisteredUser = _header[i, 8];

                }
            }
            else
            {
                for (int i = 0; i < Program.AgentCount; i++)
                {
                    Program.AgentList.Add(new Agents());
                    Program.AgentList[i].AgentID = _header[i, 0];
                    Program.AgentList[i].AgentNumber = _header[i, 1];
                    Program.AgentList[i].ComputerName = _header[i, 2];
                    Program.AgentList[i].Caption = _header[i, 3];

                    Program.AgentList[i].UUID = _header[i, 5];
                    Program.AgentList[i].Organization = _header[i, 6];
                    Program.AgentList[i].RegisterCompany = _header[i, 7];
                    Program.AgentList[i].RegisteredUser = _header[i, 8];

                }
            }

            logl.SetAgentGeneralInfo();

        }

        private void frmSplash_LtoR_Load(object sender, EventArgs e)
        {
            thsAgentList = new ThreadStart(SetAgentList);
            thrAgentList = new Thread(thsAgentList);

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Program.RightToLeft == true)
            {
                frmLogin_RtoL login = new frmLogin_RtoL();
                this.Hide();
                login.ShowDialog();
                Application.Exit();
            }
            else if (Program.RightToLeft == false)
            {
                frmLogin_LtoR login = new frmLogin_LtoR();
                this.Hide();
                login.ShowDialog();
                Application.Exit();

            }


        }



        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            USBLock usbl = new USBLock();


            if (usbl.CheckLock() != 0)
            {
                LogicLayer l = new LogicLayer();
                string mes = l.GetMessageFromDll(Convert.ToString(Program.LangCode), "LockNotFound");
                frmShowInfoSmall_LtoR fm = new frmShowInfoSmall_LtoR(mes, 2);
                fm.ShowDialog();
                Environment.Exit(0);
            }

            else
            {

                thrAgentList.Start();


            }
        }


    }
}
