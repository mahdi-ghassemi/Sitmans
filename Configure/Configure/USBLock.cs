using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Windows.Forms;


namespace Configure
{
    class USBLock
    {
        #region Fildes:

        /// <summary>
        /// USB Lock IP Address
        /// </summary>
        private string _lockAddress;

        private TINYLib.Tiny tiny;

        private string _readKey;

        private string _readWriteKey;

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

        public string ReadKey
        {
            get
            {
                return _readKey;
            }
            set
            {
                _readKey = value;
            }
        }

        public string ReadWriteKey
        {
            get
            {
                return _readWriteKey;
            }
            set
            {
                _readWriteKey = value;
            }
        }

        #endregion

        #region Constructors:

        public USBLock()
        {
            tiny = new TINYLib.Tiny();
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

            return _ret;
        }

        /// <summary>
        /// Get data from usb lock
        /// </summary>
        /// <returns>Data stored on usb lock</returns>
        public string GetData()
        {
            string _data = null;
            if (_lockAddress != null)
            {
                tiny.ServerIP = _lockAddress.ToString();
                tiny.NetWorkINIT = true;
            } 
            tiny.Initialize = true;
            tiny.UserPassWord = _readKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                _data = tiny.DataPartition;

            }
            else
            {


            }
            return _data;

        }
        /// <summary>
        /// Save data to local usb lock
        /// </summary>

        public int SetData(string Data)
        {
            int _lockErr;
            if (_lockAddress != null)
            {
                tiny.ServerIP = _lockAddress.ToString();
                tiny.NetWorkINIT = true;
            }
           
            tiny.Initialize = true;
            tiny.UserPassWord = _readWriteKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                tiny.DataPartition = Data;
                _lockErr = tiny.TinyErrCode;

            }
            else
            {
                _lockErr = tiny.TinyErrCode;
            }

            return _lockErr;

        }

        /// <summary>
        /// Save data to remote usb lock
        /// </summary>

        public int SetData(string Data, string IpAddress, string SerialNumber)
        {
            int _lockErr;
            tiny.ServerIP = IpAddress;
            tiny.NetWorkINIT = true;
            tiny.UserPassWord = _readWriteKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                tiny.DataPartition = Data.Trim() + "&&";
                _lockErr = tiny.TinyErrCode;
            }
            else
            {
                _lockErr = tiny.TinyErrCode;
            }

            return _lockErr;

        }


        /// <summary>
        /// Check for read key in dll file
        /// </summary>
        /// <returns>usb lock error code</returns>
        public int CheckReadKey()
        {
            int _ret = 0;
            tiny.Initialize = true;
            tiny.UserPassWord = _readKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            _ret = tiny.TinyErrCode;
            return _ret;
        }

        public string GetSerial()
        {
            string _data = "";
            tiny.Initialize = true;
            tiny.UserPassWord = _readKey;
            tiny.AutoCheckingTiny = true;
            tiny.ShowTinyInfo = true;
            if (tiny.TinyErrCode == 0)
            {
                _data = tiny.SerialNumber;

            }
            return _data;
        }


        #endregion
    }
}
