using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentInCaseDevices
    {
        private int _radif;
        private string _deviceName;
        private int _deviceId;
        private int _parentDeviceId;
        private string _model;
        private string _serial;
        private string _asset;

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

        public int ParentDeviceId
        {
            get { return _parentDeviceId; }
            set { _parentDeviceId = value; }
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

        public AgentInCaseDevices(int ICounter, string IDeviceName, int IDeviceId,int IParentDeviceId, string IModel, string ISerial, string IAsset)
        {
            _radif = ICounter;
            _deviceName = IDeviceName;
            _deviceId = IDeviceId;
            _parentDeviceId = IParentDeviceId;
            _model = IModel;
            _serial = ISerial;
            _asset = IAsset;

        }
    }
}
