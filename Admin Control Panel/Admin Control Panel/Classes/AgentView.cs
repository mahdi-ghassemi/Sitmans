using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Admin_Control_Panel.Classes
{
    public class AgentView : INotifyPropertyChanged
    {
        private string _AgentId;
        private int _AgentListIndex;
        private string _ComputerName;
        private string _UserFullName;
        private string _Alert;
        private string _Status;
        private Image _UserImage;        
        private Image _AlertImageIcon;
        private Image _AgentSystemType;
        private string _AgentIP;
        private string _Room;
        private string _Buildding;
        private string _Department;
        private string _Class;
        private string _IdleTime;
        private string _Alias;
        private string _SettingProfileName;
        private string _AlertProfileName;
        
        private string _SystemType;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;
        

        public AgentView(string IAgentId, int IAgentListIndex, string IComputerName,string IUserFullName,string IAlert, string IStatus, Image IUserImage, 
                         Image IAlertImageIcon, Image IAgentSystemType, string IAgentIP, string IRoom, string IBuildding, string IDepartment,
                         string IClass, string IIdleTime, string IAlias, string ISettingProfileName, string IAlertProfileName,
                         string ISystemType)
        {
            this._AgentId = IAgentId;
            this._AgentListIndex = IAgentListIndex;
            this._ComputerName = IComputerName;
            this._UserFullName = IUserFullName;
            this._Alert = IAlert;
            this._Status = IStatus;            
            this._UserImage = IUserImage;            
            this._AlertImageIcon = IAlertImageIcon;
            this._AgentSystemType = IAgentSystemType;
            this._AgentIP = IAgentIP;
            this._Room = IRoom;
            this._Buildding = IBuildding;
            this._Department = IDepartment;
            this._Class = IClass;
            this._IdleTime = IIdleTime;
            this._Alias = IAlias;
            this._SettingProfileName = ISettingProfileName;
            this._AlertProfileName = IAlertProfileName;            
            this._SystemType = ISystemType;
        }

        public string AgentId
        {
            get
            {
                return this._AgentId;
            }
            set
            {
                if (this._AgentId != value)
                {
                    this._AgentId = value;
                    OnPropertyChanged("AgentId");
                }
            }
        }

        public int AgentListIndex
        {
            get
            {
                return this._AgentListIndex;
            }
            set
            {
                if (this._AgentListIndex != value)
                {
                    this._AgentListIndex = value;
                    OnPropertyChanged("AgentListIndex");
                }
            }
        }

        public string ComputerName
        {
            get
            {
                return this._ComputerName;
            }
            set
            {
                if (this._ComputerName != value)
                {
                    this._ComputerName = value;
                    OnPropertyChanged("ComputerName");
                }
            }
        }

        public string UserFullName
        {
            get
            {
                return this._UserFullName;
            }
            set
            {
                if (this._UserFullName != value)
                {
                    this._UserFullName = value;
                    OnPropertyChanged("UserFullName");
                }
            }
        }

        public string Alert
        {
            get
            {
                return this._Alert;
            }
            set
            {
                if (this._Alert != value)
                {
                    this._Alert = value;
                    OnPropertyChanged("Alert");
                }
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                if (this._Status != value)
                {
                    this._Status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        public Image UserImage
        {
            get
            {
                return this._UserImage;
            }
            set
            {
                if (this._UserImage != value)
                {
                    this._UserImage = value;
                    OnPropertyChanged("UserImage");
                }
            }
        }

      

        public Image AlertImageIcon
        {
            get
            {
                return this._AlertImageIcon;
            }
            set
            {
                if (this._AlertImageIcon != value)
                {
                    this._AlertImageIcon = value;
                    OnPropertyChanged("AlertImageIcon");
                }
            }
        }

        public Image AgentSystemType
        {
            get
            {
                return this._AgentSystemType;
            }
            set
            {
                if (this._AgentSystemType != value)
                {
                    this._AgentSystemType = value;
                    OnPropertyChanged("AgentSystemType");
                }
            }
        }

        public string AgentIP
        {
            get
            {
                return this._AgentIP;
            }
            set
            {
                if (this._AgentIP != value)
                {
                    this._AgentIP = value;
                    OnPropertyChanged("AgentIP");
                }
            }
        }

        public string Room
        {
            get
            {
                return this._Room;
            }
            set
            {
                if (this._Room != value)
                {
                    this._Room = value;
                    OnPropertyChanged("Room");
                }
            }
        }

        public string Buildding
        {
            get
            {
                return this._Buildding;
            }
            set
            {
                if (this._Buildding != value)
                {
                    this._Buildding = value;
                    OnPropertyChanged("Buildding");
                }
            }
        }

        public string Department
        {
            get
            {
                return this._Department;
            }
            set
            {
                if (this._Department != value)
                {
                    this._Department = value;
                    OnPropertyChanged("Department");
                }
            }
        }

        public string Class
        {
            get
            {
                return this._Class;
            }
            set
            {
                if (this._Class != value)
                {
                    this._Class = value;
                    OnPropertyChanged("Class");
                }
            }
        }

        public string IdleTime
        {
            get
            {
                return this._IdleTime;
            }
            set
            {
                if (this._IdleTime != value)
                {
                    this._IdleTime = value;
                    OnPropertyChanged("IdleTime");
                }
            }
        }

        public string Alias
        {
            get
            {
                return this._Alias;
            }
            set
            {
                if (this._Alias != value)
                {
                    this._Alias = value;
                    OnPropertyChanged("Alias");
                }
            }
        }

        public string SettingProfileName
        {
            get
            {
                return this._SettingProfileName;
            }
            set
            {
                if (this._SettingProfileName != value)
                {
                    this._SettingProfileName = value;
                    OnPropertyChanged("SettingProfileName");
                }
            }
        }

        public string AlertProfileName
        {
            get
            {
                return this._AlertProfileName;
            }
            set
            {
                if (this._AlertProfileName != value)
                {
                    this._AlertProfileName = value;
                    OnPropertyChanged("AlertProfileName");
                }
            }
        }

       

        public string SystemType
        {
            get
            {
                return this._SystemType;
            }
            set
            {
                if (this._SystemType != value)
                {
                    this._SystemType = value;
                    OnPropertyChanged("SystemType");
                }
            }
        }       
    }
}
