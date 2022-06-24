using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Admin_Control_Panel.Classes;
using TINYLib;



namespace Admin_Control_Panel.Classes
{
    /// <summary>
    /// This class for comminucation with USB Lock
    /// </summary>
    public class USBLock
    {

        #region Fildes:

        /// <summary>
        /// USB Lock IP Address
        /// </summary>
        private string _lockAddress;

        private TINYLib.Tiny tiny;

        #endregion

        #region Properties:

        /// <summary>
        /// USB Lock IP Address
        /// </summary>
        public string LockIPAddress
        {
            get
            {
                return _lockAddress;
            }
            set
            {
                _lockAddress = value;
            }
        }
        #endregion

        #region Constructors:

        public USBLock()
        {
            try
            {
                tiny = new TINYLib.Tiny();
                _lockAddress = Program.LockIpAddress;
            }
            catch (COMException)
            {
                LogicLayer l = new LogicLayer();
                string mes = l.GetErrorMessage(36);
                frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(mes, 2);
                fm.ShowDialog();
                Environment.Exit(0);
                
            }            
                
        }

        #endregion

        #region Public Methods:

        public int CheckLock()
        {
            int _ret = 0;
            tiny.ServerIP = _lockAddress.ToString();
            tiny.NetWorkINIT = true;
            if (tiny.TinyErrCode != 0)
            {
                _ret = tiny.TinyErrCode;
            }

            tiny.NetWorkINIT = false;
            return _ret;
        }

        /// <summary>
        /// Get data from usb lock
        /// </summary>
        /// <returns>Data stored on usb lock</returns>
        public string GetData()
        {
            string _data = null;

            tiny.ServerIP = _lockAddress.ToString();
            tiny.Initialize = true;
            tiny.NetWorkINIT = true;
            tiny.UserPassWord = Program.ReadKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                _data = tiny.DataPartition;
            }
            else
            {
                LogicLayer l = new LogicLayer();
                string mes = l.GetErrorMessage(tiny.TinyErrCode);
                frmShowInfo_RtoL fm = new frmShowInfo_RtoL(mes, 2);
                fm.ShowDialog();
                Environment.Exit(0);

            }
            tiny.NetWorkINIT = false;
            return _data;

        }
        /// <summary>
        /// Save data to usb lock
        /// </summary>
        
        public void SetData(string Data)
        {
            
           tiny.ServerIP = _lockAddress.ToString();
           tiny.NetWorkINIT = true;
            tiny.UserPassWord = Program.WriteKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                tiny.DataPartition = Data.Trim();

            }
            else
            {
                //MessageBox.Show(Languages.LockKeyErr(Settings.Default.CurrentLanguage));
                Application.Exit();
            }
            tiny.NetWorkINIT = false;            
        }


        
        /// <summary>
        /// Check for read key in dll file
        /// </summary>
        /// <returns>usb lock error code</returns>
        public int CheckReadKey()
        {
            int _ret = 0;
            tiny.ServerIP = _lockAddress.ToString();
            tiny.NetWorkINIT = true;
            tiny.UserPassWord = Program.ReadKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            _ret = tiny.TinyErrCode;
            tiny.NetWorkINIT = false;
            return _ret;
        }

        public int GetMaxNetworkClient()
        {
            int _ret = 0;
            tiny.ServerIP = _lockAddress.ToString();
            tiny.NetWorkINIT = true;
            tiny.UserPassWord = Program.ReadKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            _ret = tiny.Counter;
            tiny.NetWorkINIT = false;
            return _ret;
        }

        public string GetLockSerial()
        {
            string _data = null;

            tiny.ServerIP = _lockAddress.ToString();
            tiny.Initialize = true;
            tiny.NetWorkINIT = true;
            tiny.UserPassWord = Program.ReadKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                _data = tiny.SerialNumber;

            }
            else
            {
                _data = "0000";
            }
            tiny.NetWorkINIT = false;
            return _data;
        }


        #endregion
              
       

    }
}

