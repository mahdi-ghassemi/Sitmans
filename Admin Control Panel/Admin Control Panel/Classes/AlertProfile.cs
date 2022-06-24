using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AlertProfile
    {
        private string _HeaderId;
        private string _ProfileId;
        private string _ProfileName;
        private string _DetailId;
        private string _SubjectId;
        private string _AlertId;
        private string _SubjectGroup;
        private string _SubjectDes;
        private string _SoundAlert;
        private string _SoundFilePath;
        private string _SmsNumber;
        private string _EmailAddress;

        public string HeaderId
        {
            get { return _HeaderId; }
            set { _HeaderId = value; }
        }
        public string ProfileName
        {
            get { return _ProfileName; }
            set { _ProfileName = value; }
        }
        public string ProfileId
        {
            get { return _ProfileId; }
            set { _ProfileId = value; }
        }
        public string DetailId
        {
            get { return _DetailId; }
            set { _DetailId = value; }
        }
        public string AlertId
        {
            get { return _AlertId; }
            set { _AlertId = value; }
        }
        public string SubjectGroup
        {
            get { return _SubjectGroup; }
            set { _SubjectGroup = value; }
        }
        public string SubjectDes
        {
            get { return _SubjectDes; }
            set { _SubjectDes = value; }
        }
        public string SoundAlert
        {
            get { return _SoundAlert; }
            set { _SoundAlert = value; }
        }
        public string SoundFilePath
        {
            get { return _SoundFilePath; }
            set { _SoundFilePath = value; }
        }
        public string SmsNumber
        {
            get { return _SmsNumber; }
            set { _SmsNumber = value; }
        }
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }
        public string SubjectId
        {
            get { return _SubjectId; }
            set { _SubjectId = value; }
        }

        public AlertProfile(string IHeaderId, string IProfileId, string IProfileName, string IDetailId,string _ISubjectId, string IAlertId, string ISubjectGroup,
                              string ISubjectDes, string ISoundAlert, string ISoundFilePath, string ISmsNumber, string IEmailAddress)
        {
            _HeaderId = IHeaderId;
            _ProfileId = IProfileId;
            _ProfileName = IProfileName;
            _DetailId = IDetailId;
            _SubjectId = _ISubjectId;
            _AlertId = IAlertId;
            _SubjectGroup = ISubjectGroup;
            _SubjectDes = ISubjectDes;
            _SoundAlert = ISoundAlert;
            _SoundFilePath = ISoundFilePath;
            _SmsNumber = ISmsNumber;
            _EmailAddress = IEmailAddress;
        }

         public AlertProfile(string IHeaderId, string IProfileId, string IProfileName)
        {
            _HeaderId = IHeaderId;
            _ProfileId = IProfileId;
            _ProfileName = IProfileName;
            _DetailId = "";
            _SubjectId = "";
            _AlertId = "";
            _SubjectGroup = "";
            _SubjectDes = "";
            _SoundAlert = "";
            _SoundFilePath = "";
            _SmsNumber = "";
            _EmailAddress = "";

        }


    }
}
