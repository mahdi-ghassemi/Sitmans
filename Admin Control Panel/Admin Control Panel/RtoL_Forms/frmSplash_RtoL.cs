using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel
{
    public partial class frmSplash_RtoL : Form
    {
        private Thread thrAgentList;        
        private ThreadStart thsAgentList;       
        private BackgroundWorker bw;

        public frmSplash_RtoL()
        {
            InitializeComponent();
        }


        private void SetAgentList()
        {          
            LogicLayer lg = new LogicLayer();

            lg.GetSettingProfile();

            Program.ChatPort = Convert.ToInt32(Program.SettingProfileList[0].ChatPort);
           
            lg.FirstGetAgentMainList();
           
            lg.SetAgentGeneralInfo();

       
                  
        }

      

        private void frmSplash_RtoL_Load(object sender, EventArgs e)
        {
            thsAgentList = new ThreadStart(SetAgentList);
            thrAgentList = new Thread(thsAgentList);           

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
           
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            }


        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            USBLock usbl = new USBLock();
            int _ercode = usbl.CheckLock();
            if (_ercode != 0)
            {
                LogicLayer l = new LogicLayer();
                string mes = l.GetErrorMessage(_ercode);
                frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
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
