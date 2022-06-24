using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class AclProfile
    {
        private string _HeaderId;
        private string _ProfileId;
        private string _ProfileName;


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

        public AclProfile(string IHeaderId, string IProfileId, string IProfileName)
        {
            _HeaderId = IHeaderId;
            _ProfileId = IProfileId;
            _ProfileName = IProfileName;
        }
    }
}
