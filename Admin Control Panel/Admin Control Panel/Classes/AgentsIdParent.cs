using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentsIdParent
    {
        private bool _print;
        private int _radif;
        private Image _agentImage;
        private string _personnelName;
        private string _agentComputerName;
        private int _agentId;

        public bool Print
        {
            get { return _print; }
            set { _print = value; }
        }

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

        public int AgentId
        {
            get { return _agentId; }
            set { _agentId = value; }
        }


        public AgentsIdParent(bool IPrint,int ICounter, Image IAgentImage, string IPersonnelName, string IAgentComputerName, int IAgentId)
        {
            _print = IPrint;
            _radif = ICounter;
            _agentImage = IAgentImage;
            _personnelName = IPersonnelName;
            _agentComputerName = IAgentComputerName;
            _agentId = IAgentId;
        }
    }
}
