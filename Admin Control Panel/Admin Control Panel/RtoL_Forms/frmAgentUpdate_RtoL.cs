using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentUpdate_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;

        public frmAgentUpdate_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgentUpdate_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            LogicLayer lg1 = new LogicLayer();
            lblPath.Text = lg1.GetMessageFromDll(_langCode, "ShareFolderName");
            lblIPAddress.Text = lg1.GetMessageFromDll(_langCode, "IPAddress");
            this.Text = lg1.GetMessageFromDll(_langCode, "AgentUpdateSetting");
            btnOk.Text = lg1.GetMessageFromDll(_langCode, "btnOk");            
            btnCancel.Text = lg1.GetMessageFromDll(_langCode, "btnCancel");
            
        }

      

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txbPath.Text != "" && txbIPAddress.Text != "")
            {
                LogicLayer lg = new LogicLayer();
                int _result = 0;
               // int _result = lg.AgentUpdateSettingUpdate(txbPath.Text.Trim());
                if (_result == 1)
                {
                    //todo : save setting success
                }
                else
                {
                    //todo : save setting fail
                }
            }
            else
            {
                //todo : path empty
            }
        }
    }
}
