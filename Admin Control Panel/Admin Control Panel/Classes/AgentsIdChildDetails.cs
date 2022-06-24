using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentsIdChildDetails
    {        
        private bool _print;
        private int _childId;
        private int _parentId;
        private string _title;
        private string _titleValue;
        private int _agentId;


        public bool Print
        {
            get { return _print; }
            set { _print = value; }
        }

        public int ChildId
        {
            get { return _childId; }
            set { _childId = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string TitleValue
        {
            get { return _titleValue; }
            set { _titleValue = value; }
        }

        public int AgentId
        {
            get { return _agentId; }
            set { _agentId = value; }
        }




        public AgentsIdChildDetails(bool IPrint, int IId, int IParentId, string ITtile,string ITitleValue,int IAgentId)
        {
            _print = IPrint;
            _childId = IId;
            _parentId = IParentId;
            _title = ITtile;
            _titleValue = ITitleValue;
            _agentId = IAgentId;
        }
     
    }
}
