using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.Classes
{
    public class OnWorkObject
    {
        private int _parentId;
        private int _radif;
        private string _date;
        private string _timeOn;
        private string _timeOff;
        private int _onDurationTime;
        private int _idleDurationTime;
        private int _standbyDurationTime;
        private int _helpfulDurationTime;
        private int _TotalOnDurationTime;
        private int _TotalIdleDurationTime;
        private int _TotalStandbyDurationTime;
        private int _TotalHelpfulDurationTime;
      

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public int radif
        {
            get { return _radif; }
            set { _radif = value; }
        }

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string timeOn
        {
            get { return _timeOn; }
            set { _timeOn = value; }
        }

        public string timeOff
        {
            get { return _timeOff; }
            set { _timeOff = value; }
        }

        public int onDurationTime
        {
            get { return _onDurationTime; }
            set { _onDurationTime = value; }
        }

        public int idleDurationTime
        {
            get { return _idleDurationTime; }
            set { _idleDurationTime = value; }
        }

        public int standbyDurationTime
        {
            get { return _standbyDurationTime; }
            set { _standbyDurationTime = value; }
        }

        public int helpfulDurationTime
        {
            get { return _helpfulDurationTime; }
            set { _helpfulDurationTime = value; }
        }

        public int TotalOnDurationTime
        {
            get { return _TotalOnDurationTime; }
            set { _TotalOnDurationTime = value; }
        }

        public int TotalIdleDurationTime
        {
            get { return _TotalIdleDurationTime; }
            set { _TotalIdleDurationTime = value; }
        }

        public int TotalStandbyDurationTime
        {
            get { return _TotalStandbyDurationTime; }
            set { _TotalStandbyDurationTime = value; }
        }

        public int TotalHelpfulDurationTime
        {
            get { return _TotalHelpfulDurationTime; }
            set { _TotalHelpfulDurationTime = value; }
        }

        public OnWorkObject(int Id,int Radif,string Date, string PowerOnTime,string PowerOffTime)
        {
            _parentId = Id;
            _radif = Radif;
            _timeOn = PowerOnTime;
            _timeOff = PowerOffTime;
            _date = Date;
        }

       

    }
}
