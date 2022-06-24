using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;
using System.Runtime.InteropServices;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmChatAgent_RtoL : Telerik.WinControls.UI.RadForm
    {
        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 uCount;
            public Int32 dwTimeout;
        }
        // stop flashing
        const int FLASHW_STOP = 0;

        // flash the window title
        const int FLASHW_CAPTION = 1;

        // flash the taskbar button
        const int FLASHW_TRAY = 2;

        // 1 | 2
        const int FLASHW_ALL = 3;

        // flash continuously
        const int FLASHW_TIMER = 4;

        // flash until the window comes to the foreground
        const int FLASHW_TIMERNOFG = 12;



        private Agents _agent;
        private bool _firstSend;
        private string _senderName;
        private string _senderIp;
        private string _langCode;
      

        public frmChatAgent_RtoL(Agents MyAgent)
        {
            _agent = MyAgent;
            InitializeComponent();
        }

        public frmChatAgent_RtoL(string Msg,string SenderName,string SenderIP,bool FirstSend)
        {
            _senderName = SenderName;
            _firstSend = FirstSend;
            _senderIp = SenderIP;
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string Msg = "";
            Msg = rtbMsg.Text.Trim();
            rtbMsg.Clear();
            rtbMsg.SelectionStart = rtbMsg.Text.Length;
            rtbMsg.SelectionLength = 0;
            rtbMsg.ScrollToCaret();
            
            string text = "Me : " + Msg;
            rtbLog.SelectionColor = Color.Green;
            rtbLog.SelectedText = Environment.NewLine + text;
            rtbLog.ScrollToCaret();
            
            Com opencdCommend = new Com();
            LogicLayer ll = new LogicLayer();

           

            opencdCommend.DestiniIp = lblSenderIp.Text;
            opencdCommend.DestiniPort = lblPort.Text;
            opencdCommend.SockType = "Tcp";
            opencdCommend.SourceIp = ll.LocalIPAddress();
            if (_firstSend == true)
            {
               // opencdCommend.TcpSendData("MSGOPAdministrator:" + opencdCommend.SourceIp + "/" + Msg);
                opencdCommend.SendData("MSGOPAdministrator:" + opencdCommend.SourceIp + "/" + Msg);
                _firstSend = false;
            }
            else
            {
                //opencdCommend.TcpSendData("MSGPMAdministrator:" + opencdCommend.SourceIp + "/" + Msg);
                opencdCommend.SendData("MSGPMAdministrator:" + opencdCommend.SourceIp + "/" + Msg);
               
            }
            
        }

     

        private void frmChatAgent_RtoL_Load(object sender, EventArgs e)
        {
            LogicLayer ll = new LogicLayer();

            string pid = _agent.SettingProfileId;
            int _profileIdIndex = Program.SettingProfileList.FindIndex(item => item.ProfileId == pid);
            lblPort.Text = Program.SettingProfileList[_profileIdIndex].ChatPort; 
           
            this.Text = _senderName;
            btnSend.Text = ll.GetMessageFromDll(_langCode, "Send");
            lblSenderName.Text = _senderName;
            lblSenderIp.Text = _senderIp;
           // lblPort.Text = Program.Port;
        }

        private void rtbMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                rtbMsg.Clear();
            }
        }

        public void RecivePM(string Msg)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                    Flash(false);

                this.Show();
                string text = lblSenderName.Text + " : " + Msg;
                rtbLog.SelectionColor = Color.Red;
                rtbLog.SelectedText = Environment.NewLine + text;
                rtbLog.ScrollToCaret();

            }
            catch (ObjectDisposedException)
            {


            }
            
            
        }

        private void Flash(bool stop)
        {
            FLASHWINFO fw = new FLASHWINFO();

            fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
            fw.hwnd = Handle;
            if (!stop)
                fw.dwFlags = 2;
            else
                fw.dwFlags = 0;
            fw.uCount = UInt32.MaxValue;

            FlashWindowEx(ref fw);
        }

        private void frmChatAgent_RtoL_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                Flash(true);
        }

        private void frmChatAgent_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
            int index;
            index = Program.ChatUserList.IndexOf(lblSenderName.Text);
            Program.ChatUserList.Remove(lblSenderName.Text);
            Program.ChatUserList.Insert(index, "");
        }

    }
}
