using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class EventObject
    {
        private int _radif;
        private string _description;
        private string _details;
        private string _date;
        private string _time;

        public int radif
        {
            get { return _radif; }
            set { _radif = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string newvalue
        {
            get { return _details; }
            set { _details = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string time
        {
            get { return _time; }
            set { _time = value; }
        }

        public EventObject(int ICounter, string IDescription, string IDetails, string IDate, string ITime)
        {
            _radif = ICounter;
            _description = IDescription;
            _details = IDetails;
            _date = IDate;
            _time = ITime;

        }
    }

}
