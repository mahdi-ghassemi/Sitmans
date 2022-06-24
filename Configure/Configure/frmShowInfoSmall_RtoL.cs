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

    public partial class frmShowInfoSmall_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _message1;
        private int _bottum;

        public frmShowInfoSmall_RtoL(string LangCode, string Message1,int Bottum)
        {
            _langCode = LangCode;
            _message1 = Message1;
            _bottum = Bottum;
            InitializeComponent();
        }

        private void frmShowInfoSmall_RtoL_Load(object sender, EventArgs e)
        {
            lblInfo1.Text = _message1;
            this.Text = "";
            ShowBottums(); 
        }

        private void ShowBottums()
        {
            LocalData ld = new LocalData();
            switch (_bottum)
            {
                case 1:
                    {
                        btn1.Visible = true;
                        btn1.Text = ld.GetMessageFromDll(_langCode,"btnYes");
                        break;
                    }
                case 2:
                    {
                        btn2.Visible = true;
                        btn2.Text = ld.GetMessageFromDll(_langCode,"btnOk");
                        break;
                    }
                case 3:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn1.Text = ld.GetMessageFromDll(_langCode,"btnYes");
                        btn2.Text = ld.GetMessageFromDll(_langCode,"btnNo");
                        break;
                    }
                case 6:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;
                        btn1.Text = ld.GetMessageFromDll(_langCode,"btnYes");
                        btn2.Text = ld.GetMessageFromDll(_langCode,"btnNo");
                        btn3.Text = ld.GetMessageFromDll(_langCode,"btnCancel");
                        break;
                    }
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
