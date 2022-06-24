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
    public partial class frmLoginToAgent_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private Agents _agent;
        private string _caption;
        private string _btnOk;
        private string _btnExit;
        private string _lblPassword;
        private string _password;
        private string _passwordWrong;
        private LogicLayer lg;
        private string _agentIP;


        public frmLoginToAgent_RtoL(Agents agent,string AgentIP)
        {
            _langCode = Program.LangCode.ToString();
            _agent = agent;
            _agentIP = AgentIP;
            InitializeComponent();
        }

        private void frmLoginToAgent_RtoL_Load(object sender, EventArgs e)
        {           
            lg = new LogicLayer();
            GetFormMessage();
            FillForm();
        }

        private void FillForm()
        {
            this.Text = _caption;
            btnOk.Text = _btnOk;
            btnExit.Text = _btnExit;
            txbPassword.NullText = _lblPassword;

        }

        private void GetFormMessage()
        {
            _caption = lg.GetMessageFromDll(_langCode, "Caption");
            _btnOk = lg.GetMessageFromDll(_langCode, "btnLogin");
            _btnExit = lg.GetMessageFromDll(_langCode, "btnExit");
            _lblPassword = lg.GetMessageFromDll(_langCode, "LoginToAgent");
            _passwordWrong = lg.GetMessageFromDll(_langCode, "PasswordWrong");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pid = _agent.SettingProfileId;
            _password = lg.GetAgentPassword(pid);
            Encrypter enc = new Encrypter();
            string pass = enc.Decrypt(_password);
            
            if (txbPassword.Text.Trim() == pass.Trim())
            {
                
                Program.AutorizedAgentId.Add(_agent.AgentID);
                Com cm = new Com();
                
                cm.DestiniIp = _agentIP;
                int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);

                cm.DestiniPort = Program.SettingProfileList[_profileIdIndex].PublicPort;
                cm.SockType = "Tcp";
                string data = enc.Encrypt("LOGIN" + txbPassword.Text.Trim());
                cm.SendData(data);
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                 
            }
            else
            {               
                erpPassword.SetError(txbPassword, _passwordWrong);
                txbPassword.Text = "";               
            }
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            erpPassword.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }
    }
}
