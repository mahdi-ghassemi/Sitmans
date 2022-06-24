using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class ACL
    {
        private int _SubjectId;
        private int _GroupId;
        private int  _AclId;


        public int SubjectId
        {
            get { return _SubjectId; }
            set { _SubjectId = value; }
        }
        public int GroupId
        {
            get { return _GroupId; }
            set { _GroupId = value; }
        }
        public int AclId
        {
            get { return _AclId; }
            set { _AclId = value; }
        }

        public ACL(int ISubjectId, int IGroupId, int IAclId)
        {
            _SubjectId = ISubjectId;
            _GroupId = IGroupId;
            _AclId = IAclId;
        }
    }
}
