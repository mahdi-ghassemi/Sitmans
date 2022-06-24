using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Configure
{
    public partial class frmLogin_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _caption;
        private string _btnOk;
        private string _btnExit;
        private string _lblPassword;
        private string _langCode;
        private string _password;
        private string _passwordWrong;

        public frmLogin_RtoL(string LangCode)
        {
            _langCode = LangCode;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmLogin_RtoL_Load(object sender, EventArgs e)
        {
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
            LocalData ld = new LocalData();
            _caption = ld.GetMessageFromDll(_langCode,"Caption");
            _btnOk = ld.GetMessageFromDll(_langCode,"btnLogin");
            _btnExit = ld.GetMessageFromDll(_langCode,"btnExit");
            _lblPassword = ld.GetMessageFromDll(_langCode,"lblPassword");
            _passwordWrong = ld.GetMessageFromDll(_langCode,"PasswordWrong");
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            erpPassword.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LocalData ld2 = new LocalData();
            _password = ld2.Decrypt(ld2.GetDataFromDll("Setting", "Password", "ID = 1"), true, "");

            if (txbPassword.Text.Trim() == _password.Trim())
            {
                frmMain_RtoL fm = new frmMain_RtoL(_langCode);
                this.Hide();
                fm.Show();

            }
            else
            {
                erpPassword.SetError(txbPassword, _passwordWrong);
                txbPassword.Text = "";
               
            }
        }            
    }
}
