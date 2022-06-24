﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel
{
    public partial class frmLogin_RtoL : Telerik.WinControls.UI.RadForm
    {
        public frmLogin_RtoL()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LogicLayer lagic = new LogicLayer();
            int _errorCode = lagic.CheckLoginDetails(txbUsername.Text, txbPassword.Text);
            switch (_errorCode)
            {
                case 0:
                    {
                        // the username or password is not correct.
                        string mes = lagic.GetErrorMessage(21);
                        frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
                        fm.ShowDialog();

                        txbUsername.Text = "";
                        txbPassword.Text = "";
                        txbUsername.Focus();
                        break;
                    }
                case -2:
                    {
                        // plese enter username and password 
                        string mes = lagic.GetErrorMessage(22);
                        frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
                        fm.ShowDialog();

                        txbUsername.Focus();
                        break;
                    }
                case -3:
                    {
                        // please enter username
                        string mes = lagic.GetErrorMessage(28);
                        frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
                        fm.ShowDialog();

                        txbUsername.Text = "";
                        txbUsername.Focus();
                        break;
                    }
                case -4:
                    {
                        // please enter password
                        string mes = lagic.GetErrorMessage(29);
                        frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
                        fm.ShowDialog();

                        txbPassword.Text = "";
                        txbPassword.Focus();
                        break;
                    }
                default:
                    {
                        lagic.SetUserImage(txbUsername.Text.Trim(), txbPassword.Text.Trim());
                        lagic.SetCompanyInfo();
                        lagic.SetTodayDate();
                        frmMain_RtoL frmmain = new frmMain_RtoL();
                        this.Hide();
                       
                        frmmain.ShowDialog();
                        this.Close();
                        break;
                    }
            }

        }

        private void frmLogin_RtoL_Load(object sender, EventArgs e)
        {
            LogicLayer lagic = new LogicLayer();
            lblUsername.Text = lagic.GetMessageFromDll(Convert.ToString(Program.LangCode), "UserNameText");
            lblPassword.Text = lagic.GetMessageFromDll(Convert.ToString(Program.LangCode), "lblSqlPassword");
            btnOk.Text = lagic.GetMessageFromDll(Convert.ToString(Program.LangCode), "btnLogin");
            btnCancel.Text = lagic.GetMessageFromDll(Convert.ToString(Program.LangCode), "btnCancel");
            this.Text = lagic.GetMessageFromDll(Convert.ToString(Program.LangCode), "Caption");
            txbUsername.Focus();
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void txbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }
    }
}
