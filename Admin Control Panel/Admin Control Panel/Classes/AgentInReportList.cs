using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Admin_Control_Panel.Classes
{
    public class AgentInReportList
    {
        private int _radif;
        private Image _agentImage;
        private int _agentId;
        private string _personnelName;
        private string _agentComputerName;
        private string _location;
        private string _ipaddress;

        public int Radif
        {
            get { return _radif; }
            set { _radif = value; }
        }
        public Image AgentImage
        {
            get { return _agentImage; }
            set { _agentImage = value; }
        }
        public int AgentId
        {
            get { return _agentId; }
            set { _agentId = value; }
        }

        public string PersonnelName
        {
            get { return _personnelName; }
            set { _personnelName = value; }
        }
        public string AgentComputerName
        {
            get { return _agentComputerName; }
            set { _agentComputerName = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string IPAddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }

        public AgentInReportList(int ICounter, Image IAgentImage, int IAgentId, string IPersonnelName, string IAgentComputerName, string ILocation, string IIPAddress)
        {
            _radif = ICounter;
            _agentImage = IAgentImage;
            _agentId = IAgentId;
            _personnelName = IPersonnelName;
            _agentComputerName = IAgentComputerName;
            _location = ILocation;
            _ipaddress = IIPAddress;
        }
    }
}
