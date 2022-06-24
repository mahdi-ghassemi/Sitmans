using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentsIdChild
    {
        private bool _print;
        private int _id;
        private int _parentAgentId;
        private string _title;


        public bool Print
        {
            get { return _print; }
            set { _print = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int ParentAgentId
        {
            get { return _parentAgentId; }
            set { _parentAgentId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }




        public AgentsIdChild(bool IPrint, int IId, int IParentAgentId,string ITtile)
        {
            _print = IPrint;
            _id = IId;
            _parentAgentId = IParentAgentId;
            _title = ITtile;             
        }
    }
}
