using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AgentDetailsInReportList
    {
        private int _radif;
        private int _id;
        private int _parentAgentId;
        private string _item;
        private  string _value;
       
        public int Radif
        {
            get { return _radif; }
            set { _radif = value; }
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

        public string Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public AgentDetailsInReportList(int ICounter, int IId, int IParentAgentId, string IItem, string IValue)
        {
            _radif = ICounter;
            _id = IId;
            _parentAgentId = IParentAgentId;
            _item = IItem;
            _value = IValue;           
        }
    }
}
