using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentDevicesList
    {
        private int _radif;
        private string _deviceName;
        private int _deviceId;
        private string _model;
        private string _serial;
        private string _asset;
        private string _tableId;

        public int Radif
        {
            get { return _radif; }
            set { _radif = value; }
        }
        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }
        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Serial
        {
            get { return _serial; }
            set { _serial = value; }
        }
        public string Asset
        {
            get { return _asset; }
            set { _asset = value; }
        }
        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public AgentDevicesList(int ICounter, string IDeviceName, int DeviceId, string IModel, string ISerial, string IAsset,string ITableId)
        {
            _radif = ICounter;
            _deviceName = IDeviceName;
            _deviceId = DeviceId;
            _model = IModel;
            _serial = ISerial;
            _asset = IAsset;
            _tableId = ITableId;
        }
    }
}
