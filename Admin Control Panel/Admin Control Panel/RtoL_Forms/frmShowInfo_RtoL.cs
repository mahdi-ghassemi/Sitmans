using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel
{
    public partial class frmShowInfo_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private string _message1;
        private int _bottum;
       

        public frmShowInfo_RtoL(string Message1, int Bottum)
        {
            _langCode = Convert.ToString(Program.LangCode);
            _message1 = Message1;
            _bottum = Bottum;           
            InitializeComponent();
        }

        private void frmShowInfo_RtoL_Load(object sender, EventArgs e)
        {
            LogicLayer ld = new LogicLayer();
            lblInfo1.Text = _message1;
            if (Program.ErrorCode != 0)
                this.Text = ld.GetMessageFromDll(_langCode, "ErrorNumber") + " " + Convert.ToString(Program.ErrorCode);
            else
                this.Text = "";

            ShowBottums(); 
        }

        private void ShowBottums()
        {
            LogicLayer ld = new LogicLayer();
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

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Program.ErrorCode = 0;
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            Program.ErrorCode = 0;
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Program.ErrorCode = 0;
            this.Close();
        }
    }
}
