using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin_Control_Panel.Classes
{
    public class SettingProfile
    {

        private string _Id;
        private string _ProfileId;
        private string _ProfileName;
        private string _UsbAccessControl;
        private string _UsbDataControl;
        private string _RegAccessControl;
        private string _AppInstallDisable;
        private string _AliasShow;
        private string _Alias;
        private string _AgentPassword;
        private string _HardwareCtr;
        private string _SoftwareCtr;
        private string _NetworkCtr;
        private string _AccountCtr;
        private string _ChatWithOther;
        private string _VideoWithOther;
        private string _FileTransferWithOther;
        private string _ImageProcessing;
        private string _RDPort;
        private string _ChatPort;
        private string _FTPort;
        private string _VCPort;
        private string _CommandPort;
        private string _WebinarPort;
        private Int32 _UpdateCounter;
        private string _PublicPort;
        private string _AppDisableRun;
        private string _DisableCtrlAltDel;


        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
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
        public string UsbAccessControl
        {
            get { return _UsbAccessControl; }
            set { _UsbAccessControl = value; }
        }
        public string UsbDataControl
        {
            get { return _UsbDataControl; }
            set { _UsbDataControl = value; }
        }
        public string RegAccessControl
        {
            get { return _RegAccessControl; }
            set { _RegAccessControl = value; }
        }
        public string AppInstallDisable
        {
            get { return _AppInstallDisable; }
            set { _AppInstallDisable = value; }
        }
        public string AliasShow
        {
            get { return _AliasShow; }
            set { _AliasShow = value; }
        }
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public string AgentPassword
        {
            get { return _AgentPassword; }
            set { _AgentPassword = value; }
        }
        public string HardwareCtr
        {
            get { return _HardwareCtr; }
            set { _HardwareCtr = value; }
        }
        public string SoftwareCtr
        {
            get { return _SoftwareCtr; }
            set { _SoftwareCtr = value; }
        }
        public string NetworkCtr
        {
            get { return _NetworkCtr; }
            set { _NetworkCtr = value; }
        }
        public string AccountCtr
        {
            get { return _AccountCtr; }
            set { _AccountCtr = value; }
        }
        public string ChatWithOther
        {
            get { return _ChatWithOther; }
            set { _ChatWithOther = value; }
        }
        public string VideoWithOther
        {
            get { return _VideoWithOther; }
            set { _VideoWithOther = value; }
        }
        public string FileTransferWithOther
        {
            get { return _FileTransferWithOther; }
            set { _FileTransferWithOther = value; }
        }
        public string ImageProcessing
        {
            get { return _ImageProcessing; }
            set { _ImageProcessing = value; }
        }
        public string RDPort
        {
            get { return _RDPort; }
            set { _RDPort = value; }
        }
        public string ChatPort
        {
            get { return _ChatPort; }
            set { _ChatPort = value; }
        }
        public string FTPort
        {
            get { return _FTPort; }
            set { _FTPort = value; }
        }
        public string VCPort
        {
            get { return _VCPort; }
            set { _VCPort = value; }
        }
        public string CommandPort
        {
            get { return _CommandPort; }
            set { _CommandPort = value; }
        }
        public string WebinarPort
        {
            get { return _WebinarPort; }
            set { _WebinarPort = value; }
        }
        public Int32 UpdateCounter

        {
            get { return _UpdateCounter; }
            set { _UpdateCounter = value; }
        }
        public string PublicPort
        {
            get { return _PublicPort; }
            set { _PublicPort = value; }
        }
        public string AppDisableRun
        {
            get { return _AppDisableRun; }
            set { _AppDisableRun = value; }
        }
        public string DisableCtrlAltDel
        {
            get { return _DisableCtrlAltDel; }
            set { _DisableCtrlAltDel = value; }
        }

        public SettingProfile(string IId, string IProfileId,string IProfileName, string IUsbAccessControl, string IUsbDataControl, string IRegAccessControl,
                              string IAppInstallDisable, string IAliasShow,string IAlias,string IAgentPassword,string IHardwareCtr,
                              string ISoftwareCtr,string INetworkCtr,string IAccountCtr,string IChatWithOther,string IVideoWithOther,
                              string IFileTransferWithOther,string IImageProcessing,string IRDPort,string IChatPort,string IFTPort,
                              string IVCPort, string ICommandPort, string IWebinarPort, string IUpdateCounter, string IPublicPort,
                              string IAppDisableRun, string IDisableCtrlAltDel)
        {
            _Id = IId;
            _ProfileId = IProfileId;
            _ProfileName = IProfileName;
            _UsbAccessControl = IUsbAccessControl;
            _UsbDataControl = IUsbDataControl;
            _RegAccessControl = IRegAccessControl;
            _AppInstallDisable = IAppInstallDisable;
            _AliasShow = IAliasShow;
            _Alias = IAlias;
            _AgentPassword = IAgentPassword;
            _HardwareCtr = IHardwareCtr;
            _SoftwareCtr = ISoftwareCtr;
            _NetworkCtr = INetworkCtr;
            _AccountCtr = IAccountCtr;
            _ChatWithOther = IChatWithOther;
            _VideoWithOther = IVideoWithOther;
            _FileTransferWithOther = IFileTransferWithOther;
            _ImageProcessing = IImageProcessing;
            _RDPort = IRDPort;
            _ChatPort = IChatPort;
            _FTPort = IFTPort;
            _VCPort = IVCPort;
            _CommandPort = ICommandPort;
            _WebinarPort = IWebinarPort;
            _UpdateCounter = Convert.ToInt32(IUpdateCounter);
            _PublicPort = IPublicPort;
            _AppDisableRun = IAppDisableRun;
            _DisableCtrlAltDel = IDisableCtrlAltDel;
        }
    }
}
