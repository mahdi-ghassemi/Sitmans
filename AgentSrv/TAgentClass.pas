unit TAgentClass;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, LocalData,GetCPU,GetMainboard,GetBIOS,GetSys,GetChassis,GetOS,GetHardDisk,
  GetVideoCard,GetCDRom,GetLogicDisk,GetMemory,GetModem,GetNetworkAdapter,
  GetPrinter,GetPublicDevices,GetSoftwares,GetUserAccount,SQLData,
  GetGroupAccount,GetActiveNetworkSetting,GetAgentProperties,Data.DB, Data.Win.ADODB;



type
  TMyAgent = class
    private

    _AgentID : string;
    _ComputerName : string;
    _Organization : string;
    _CurrentUser : string;
    _RegisterCompany : string;
    _RegisterUser : string;
    _AgentFingerPrint : string;
    _LastBootupTime : string;
    _SendToSql : string;
    _HashCode : string;
    _SystemHashCode : string;

    _SQLServerAddress : string;
    _SQLUsername : string;
    _SQLPassword : string;
    _SQLDatabaseName : string;
    _AgentPassword : string;
    _SQLConnString : string;
    _SendAllToSql : string;
    _RunOnce : string;
    _IsRegister : string;
    _ControlSoftware : string;
    _ControlHardware : string;
    _ControlNetwork : string;
    _ControlAccounts : string;
    _SendSMS : string;
    _ChatPort : string;
    _UDPPort : string;
    _AdminMachineIPAddress : string;
    _Version : string;
    _LanguageCode : string;
    _RigthToLeft : string;
    _StepNumber : string;
    _ChatWithOther :string;
    _FileTransferToOther :string;
    _VideoConfToOther :string;
    _ImageProccesing:string;
    _LockIpAddress  :string;
    _SendMail :string;
    _RemoteDesktopPort : string;
    _FileTransferPort : string;
    _VideoConfPort : string;
    _CMDPort : string;
    _WebinarPort : string;
    _PublicPort : string;
    _UsbAccessControl : string;
    _UsbDataControl : string;
    _RegAccessControl: string;
    _AppInstallDisable : string;
    _AppRunDisable : string;
    _DisableCtrlAltDel : string;
    _UpdateCounter : string;


    _HardCaption :  LocalData.TStringArray;
    _HardSignature : LocalData.TStringArray;
    _HardSize  : LocalData.TStringArray;
    _HardPartitions : LocalData.TStringArray;
    _HardPNPDeviceID : LocalData.TStringArray;
    _HardHashCode : LocalData.TStringArray;
    _HardSendToSql : LocalData.TStringArray;
    _HardTotalHashCode : string;

     _CpuVendorid : string;
     _CpuSteppingid : string;
     _CpuModelnumber : string;
     _CpuFamilycode : string;
     _CpuProcessortype : string;
     _CpuExtendedModel: string;
     _CpuExtendedfamily: string;
     _CpuBrandid : string;
     _CpuChunks : string;
     _CpuCount : string;
     _CpuAPICID : string;
     _CpuSerialnumber: string;
     _CpuMMX : string;
     _CpuFXSAVE_FXRSTOR_Instructions : string;
     _CpuSSE : string;
     _CpuSSE2: string;
     _CpuExtendedCPUID : string;
     _CpuLargest_Function_Supported : string;
     _CpuBrand_String : string;
     _CpuHashCode : string;
     _CpuSendToSql : string;

     _BiosVendor : string;
     _BiosStartSegment : string;
     _BiosVersion : string;
     _BiosReleaseDate : string;
     _BiosBiosRomSize : string;
     _BiosHashCode : string;
     _BiosSendToSql : string;

     _ChassisAssetTagNumber : string;
     _ChassisChassisType : string;
     _ChassisHashCode : string;
     _ChassisSendToSql : string;

     _MainboardManufacter : string;
     _MainboardProduct : string;
     _MainboardVersion : string;
     _MainboardSerialNumber : string;
     _MainboardHashCode : string;
     _MainboardSendToSql : string;

     _OsSerialNumber : string;
     _OsBuildNumber : string;
     _OsCaption : string;
     _OsFreePhysicalMemory : string;
     _OsInstallDate : string;
     _OsVersion : string;
     _OsLastBootUpTime :string;
     _OsHashCode : string;
     _OsSendToSql : string;

     _SysUUID : string;
     _SysHashCode : string;
     _SysSendToSql : string;

     _VideoCardCaption :  LocalData.TStringArray;
     _VideoCardDriverDate : LocalData.TStringArray;
     _VideoCardDriverVersion  : LocalData.TStringArray;
     _VideoCardVideoProcessor : LocalData.TStringArray;
     _VideoCardVideoMode : LocalData.TStringArray;
     _VideoCardAdapterRam : LocalData.TStringArray;
     _VideoCardHashCode : LocalData.TStringArray;
     _VideoCardTotalHashCode : string;
     _VideoCardSendToSql : LocalData.TStringArray;

     _CDRomName :  LocalData.TStringArray;
     _CDRomDrive :  LocalData.TStringArray;
     _CDRomHashCode : LocalData.TStringArray;
     _CDRomTotalHashCode : string;
     _CDRomSendToSql : LocalData.TStringArray;

     _LogicDiskCaption :  LocalData.TStringArray;
     _LogicDiskDescription : LocalData.TStringArray;
     _LogicDiskFileSystem  : LocalData.TStringArray;
     _LogicDiskVolumeSize : LocalData.TStringArray;
     _LogicDiskFreeSpace : LocalData.TStringArray;
     _LogicDiskVolumeName : LocalData.TStringArray;
     _LogicDiskVolumeSerialNumber : LocalData.TStringArray;
     _LogicDiskHashCode : LocalData.TStringArray;
     _LogicDiskSendToSql : LocalData.TStringArray;
     _LogicDiskTotalHashCode : string;

     _MemoryBankLabel :  LocalData.TStringArray;
     _MemoryCapacity : LocalData.TStringArray;
     _MemorySpeed  : LocalData.TStringArray;
     _MemorySendToSql : LocalData.TStringArray;
     _MemoryHashCode : LocalData.TStringArray;
     _MemoryTotalHashCode : string;

     _ModemModemName :  LocalData.TStringArray;
     _ModemHashCode : LocalData.TStringArray;
     _ModemSendToSql : LocalData.TStringArray;
     _ModemTotalHashCode : string;

     _NetworkAdapterDescription :  LocalData.TStringArray;
     _NetworkAdapterAdapterType : LocalData.TStringArray;
     _NetworkAdapterMACAddress  : LocalData.TStringArray;
     _NetworkAdapterManufacturer : LocalData.TStringArray;
     _NetworkAdapterNetConnectionID : LocalData.TStringArray;
     _NetworkAdapterPNPDeviceID : LocalData.TStringArray;
     _NetworkAdapterTimeOfLastReset : LocalData.TStringArray;
     _NetworkAdapterHashCode : LocalData.TStringArray;
     _NetworkAdapterSendToSql : LocalData.TStringArray;
     _NetworkAdapterTotalHashCode : string;

     _PrinterPrinterName :  LocalData.TStringArray;
     _PrinterNetwork : LocalData.TStringArray;
     _PrinterHashCode : LocalData.TStringArray;
     _PrinterSendToSql : LocalData.TStringArray;
     _PrinterTotalHashCode : string;

     _PublicDevicesMonitor : string;
     _PublicDevicesKeyboard : string;
     _PublicDevicesMouse  : string;
     _PublicDevicesCamera : string;
     _PublicDevicesHashCode : string;
     _PublicDevicesSendToSql : String;

     _SoftwareName : LocalData.TName;
     _SoftwareSendToSql : LocalData.TStringArray;
     _SoftwareHashCode : string;

     _UserAccountUserName :  LocalData.TStringArray;
     _UserAccountSID : LocalData.TStringArray;
     _UserAccountDescription  : LocalData.TStringArray;
     _UserAccountStatus : LocalData.TStringArray;
     _UserAccountHashCode : LocalData.TStringArray;
     _UserAccountSendToSql : LocalData.TStringArray;
     _UserAccountTotalHashCode : string;

     _GroupAccountGroupName :  LocalData.TStringArray;
     _GroupAccountGID : LocalData.TStringArray;
     _GroupAccountDescription  : LocalData.TStringArray;
     _GroupAccountStatus : LocalData.TStringArray;
     _GroupAccountHashCode : LocalData.TStringArray;
     _GroupAccountSendToSql : LocalData.TStringArray;
     _GroupAccountTotalHashCode : string;

     _ActiveNetworkSettingCaption : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingIPAddress :  GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingSubnetMask : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingDefaultGateway  : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingDNSServer : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingDHCPActive : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingDHCPServer : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingMACAddress : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingHashCode : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingSendToSql : GetActiveNetworkSetting.TNewStringArray;
     _ActiveNetworkSettingTotalHashCode : string;

     _Dll_Total_HashCode : string;
     _Dll_CPU_HashCode : string;
     _Dll_Mainboard_HashCode : string;
     _Dll_Bios_HashCode : string;
     _Dll_TotalMemory_HashCode : string;
     _Dll_TotalHardDisks_HashCode : string;
     _Dll_TotalLogicHards_HashCode : string;
     _Dll_TotalSoftwares_HashCode : string;
     _Dll_Chassis_HashCode : string;
     _Dll_AgentProperties_HashCode : string;
     _Dll_OS_HashCode : string;
     _Dll_Sys_HashCode : string;
     _Dll_TotalVideoCards_HashCode : string;
     _Dll_TotalCdRom_HashCode : string;
     _Dll_TotalModems_HashCode : string;
     _Dll_TotalNetworkAdapters_HashCode : string;
     _Dll_TotalPrinters_HashCode : string;
     _Dll_PublicDevices_HashCode : string;
     _Dll_TotalUserAccounts_HashCode : string;
     _Dll_TotalGroupAccounts_HashCode : string;
     _Dll_TotalActiveNetworkSetting_HashCode : string;

     _TotalHashCodeChanged : boolean;
     _CPU_HashCodeChanged : boolean;
     _Mainboard_HashCodeChanged : boolean;
     _Bios_HashCodeChanged : boolean;
     _TotalMemory_HashCodeChanged : boolean;
     _TotalHardDisks_HashCodeChanged : boolean;
     _TotalLogicHards_HashCodeChanged : boolean;
     _TotalSoftwares_HashCodeChanged : boolean;
     _Chassis_HashCodeChanged : boolean;
     _AgentProperties_HashCodeChanged : boolean;
     _OS_HashCodeChanged : boolean;
     _Sys_HashCodeChanged : boolean;
     _TotalVideoCards_HashCodeChanged : boolean;
     _TotalCdRom_HashCodeChanged : boolean;
     _TotalModems_HashCodeChanged : boolean;
     _TotalNetworkAdapters_HashCodeChanged : boolean;
     _TotalPrinters_HashCodeChanged : boolean;
     _PublicDevices_HashCodeChanged : boolean;
     _TotalUserAccounts_HashCodeChanged : boolean;
     _TotalGroupAccounts_HashCodeChanged : boolean;
     _TotalActiveNetworkSetting_HashCodeChanged : boolean;

     function  CompareHashCodes(HashCode1:string;HashCode2:string):boolean;

    published
     constructor Create;




     procedure GetSystemInfo;
     procedure GetSystemHashCode;
     procedure SaveSystemInfoToDll;
     procedure SaveSystemCPUToDll;
     procedure SaveSystemMainboardToDll;
     procedure SaveSystemBiosToDll;
     procedure SaveSystemChassisToDll;
     procedure SaveSystemAgentToDll;
     procedure SaveSystemOSToDll;
     procedure SaveSystemSysToDll;
     procedure SaveSystemHardDisksToDll;
     procedure SaveSystmVideoCardToDll;
     procedure SaveSystemCDRomToDll;
     procedure SaveSystemLogicDiskToDll;
     procedure SaveSystemMemoryToDll;
     procedure SaveSystemModemToDll;
     procedure SaveSystemNetworkAdapterToDll;
     procedure SaveSystemPrinterToDll;
     procedure SaveSystemPublicDevicesToDll;
     procedure SaveSystemSoftwareToDll;
     procedure SaveSystemUserAccountToDll;
     procedure SaveSystemGroupAccountToDll;
     procedure SaveSystemActiveNetworkSettingToDll;
     procedure GetAgentSettingFromDll;
     procedure GetAllPropertiesFromDll;
     procedure SaveAllPropertiesToSql;
     procedure GetSystemAgentFromDll;
     procedure GetSystemCPUFromDll;
     procedure GetSystemMainboardFromDll;
     procedure GetSystemBiosFromDll;
     procedure GetSystemChassisFromDll;
     procedure GetSystemOSFromDll;
     procedure GetSystemSysFromDll;
     procedure GetSystemHardDisksFromDll;
     procedure GetSystmVideoCardFromDll;
     procedure GetSystemCDRomFromDll;
     procedure GetSystemLogicDiskFromDll;
     procedure GetSystemMemoryFromDll;
     procedure GetSystemModemFromDll;
     procedure GetSystemNetworkAdapterFromDll;
     procedure GetSystemPrinterFromDll;
     procedure GetSystemPublicDevicesFromDll;
     procedure GetSystemSoftwareFromDll;
     procedure GetSystemUserAccountFromDll;
     procedure GetSystemGroupAccountFromDll;
     procedure GetSystemActiveNetworkSettingFromDll;

     procedure SaveSystemAgentToSql;
     procedure SaveSystemCPUToSql;
     procedure SaveSystemMainboardToSql;
     procedure SaveSystemBiosToSql;
     procedure SaveSystemChassisToSql;
     procedure SaveSystemOSFromToSql;
     procedure SaveSystemHardDisksToSql;
     procedure SaveSystmVideoCardToSql;
     procedure SaveSystemCDRomToSql;
     procedure SaveSystemLogicDiskToSql;
     procedure SaveSystemMemoryToSql;
     procedure SaveSystemModemToSql;
     procedure SaveSystemNetworkAdapterToSql;
     procedure SaveSystemPrinterToSql;
     procedure SaveSystemPublicDevicesToSql;
     procedure SaveSystemSoftwareToSql;
     procedure SaveSystemUserAccountToSql;
     procedure SaveSystemGroupAccountToSql;
     procedure SaveSystemActiveNetworkSettingToSql;
     procedure GetHashCodesFromDll;



     procedure FindChanges;
     procedure FindCpuDetailsChange;
     procedure FindMainboardDetailsChange;
     procedure FindBiosDetailsChange;
     procedure FindMemoryDetailsChange;
     procedure FindHardDisksDetailsChange;
     procedure FindLogicDisksDetailsChange;
     procedure FindSoftwaresDetailsChange;
     procedure FindChassisDetailsChange;
     procedure FindAgentPropertiesDetailsChange;
     procedure FindOSDetailsChange;
     procedure FindSysDetailsChange;
     procedure FindVideoCardsDetailsChange;
     procedure FindCdRomDetailsChange;
     procedure FindModemsDetailsChange;
     procedure FindNetworkAdaptersDetailsChange;
     procedure FindPrintersDetailsChange;
     procedure FindPublicDevicesChange;
     procedure FindUserAccountsChange;
     procedure FindGroupAccountsChange;
     procedure FindActiveNetworkSettingChange;
     procedure NewAccountsInsertEvent(CList:TStringList);
     procedure AccountsDeleteEvent(DList:TStringList);
     procedure InstallNewMemoryInsertEvent(CList:TStringList);
     procedure UninstallMemoryEvent(DList:TStringList);
     procedure NewVideoCardInsertEvent(CList:TStringList);
     procedure VideoCardUninstallEvent(DList:TStringList);
     procedure NewVideoCardCaptionInsertEvent(CList:TStringList);
     procedure VideoCardCaptionUninstallEvent(CList:TStringList);
     procedure NewCDRomInsertEvent(CList:TStringList);
     procedure NewCdromNameInsertEvent(CList:TStringList);
     procedure CDRomUninstallEvent(DList:TStringList);
     procedure CdromNameUninstallEvent(CList:TStringList);
     procedure NewModemInsertEvent(CList:TStringList);
     procedure NewModemNameInsertEvent(CList:TStringList);
     procedure ModemNameUninstallEvent(CList:TStringList);
     procedure ModemUninstallEvent(DList:TStringList);
     procedure NewNetworkAdapterInsertEvent(CList:TStringList);
     procedure NewNetworkAdapterDescriptionInsertEvent(CList:TStringList);
     procedure NetworkAdapterUninstallEvent(DList:TStringList);
     procedure NetworkAdapterDescriptionUninstallEvent(CList:TStringList);
     procedure NewPrinterInsertEvent(CList:TStringList);
     procedure NewPrinterNameInsertEvent(CList:TStringList);
     procedure PrinterNameUninstallEvent(CList:TStringList);
     procedure PrinterUninstallEvent(DList:TStringList);
     procedure NewHardDiskInsertEvent(CList:TStringList);
     procedure NewHardDiskCaptionInsertEvent(CList:TStringList);
     procedure HardDiskCaptionUninstallEvent(CList:TStringList);
     procedure HardDiskUninstallEvent(DList:TStringList);
     procedure NewLogicDiskInsertEvent(CList:TStringList);
     procedure NewLogicDiskCaptionInsertEvent(CList:TStringList);
     procedure LogicDiskCaptionUninstallEvent(CList:TStringList);
     procedure LogicDiskUninstallEvent(DList:TStringList);
     procedure NewSoftwareInstallEvent(CList:TStringList);
     procedure SoftwareUninstallEvent(DList:TStringList);
     procedure NewSIDAccountsInsertEvent(CList:TStringList);
     procedure AccountsSIDDeleteEvent(DList:TStringList);
     procedure NewGroupAccountsInsertEvent(CList:TStringList);
     procedure NewGIDGroupAccountsInsertEvent(CList:TStringList);
     procedure GroupAccountsDeleteEvent(DList:TStringList);
     procedure GroupAccountsGIDDeleteEvent(DList:TStringList);
     procedure DeleteAgentInfoFromSql(SpName:string);
     procedure NewActiveNetworkInsertEvent(CList:TStringList);
     procedure NewActiveNetworkCaptionInsertEvent(CList:TStringList);
     procedure ActiveNetworkCaptionUninstallEvent(CList:TStringList);
     procedure ActiveNetworkUninstallEvent(DList:TStringList);
     procedure UpdateAgentStatusInSql(AgentID:string;CurrentUser:string;
                Status:string;IdleDuration:string);
     procedure SaveSystemStatusToSql;
     procedure UpdateTotoalSystemHashCode;
     procedure SendEventFromDllToSql;
     procedure SendEventDllToSql(RowCount:integer);
     procedure StartUpEvent;
     procedure SendAppRunsDllToSql(RowCount:integer);
     procedure SendAppRunsFromDllToSql;

     function CompareTotalHashCodes:boolean;
     function CompareCpuHashCodes:boolean;
     function CompareMainboardHashCodes:boolean;
     function CompareBiosHashCodes:boolean;
     function CompareTotalMemoryHashCodes:boolean;
     function CompareTotalHardDisksHashCodes:boolean;
     function CompareTotalLogicHardsHashCodes:boolean;
     function CompareTotalSoftwaresHashCodes:boolean;
     function CompareChassisHashCodes:boolean;
     function CompareAgentPropertiesHashCodes:boolean;
     function CompareOSHashCodes:boolean;
     function CompareSysHashCodes:boolean;
     function CompareTotalVideoCardsHashCodes:boolean;
     function CompareTotalCdRomHashCodes:boolean;
     function CompareTotalModemsHashCodes:boolean;
     function CompareTotalNetworkAdaptersHashCodes:boolean;
     function CompareTotalPrintersHashCodes:boolean;
     function ComparePublicDevicesHashCodes:boolean;
     function CompareTotalUserAccountsHashCodes:boolean;
     function CompareTotalGroupAccountsHashCodes:boolean;
     function CompareTotalActiveNetworkSettingHashCodes:boolean;
     function SaveEventToSql(EventId:string;LastValue:string;CurrentValue:string;LevelId:string;SubjectId:string):integer;
     function SaveEvToSql(AgId:string;EvId:string;EvDateTime:string;LastVal:string;CurrentVal:string;LevId:string;SubId:string):integer;


     property AgentID : string read _AgentID write _AgentID;
     property ComputerName : string read _ComputerName write _ComputerName;
     property Organization : string read _Organization write _Organization;
     property CurrentUser : string read _CurrentUser write _CurrentUser;
     property RegisterCompany : string read _RegisterCompany write _RegisterCompany;
     property RegisterUser : string read _RegisterUser write _RegisterUser;
     property LastBootupTime : string read _LastBootupTime write _LastBootupTime;
     property AgentFingerPrint : string read _AgentFingerPrint write _AgentFingerPrint;
     property HashCode : string read _HashCode write _HashCode;

     property SystemHashCode : string read _SystemHashCode write _SystemHashCode;


     property SQLServerAddress : string read _SQLServerAddress write _SQLServerAddress;
     property SQLUsername : string read _SQLUsername write _SQLUsername;
     property SQLPassword : string read _SQLPassword write _SQLPassword;
     property SQLDatabaseName : string read _SQLDatabaseName write _SQLDatabaseName;
     property AgentPassword : string read _AgentPassword write _AgentPassword;
     property SQLConnString : string read _SQLConnString write _SQLConnString;
     property RunOnce : string read _RunOnce write _RunOnce;
     property IsRegister : string read _IsRegister write _IsRegister;
     property ControlSoftware : string read _ControlSoftware write _ControlSoftware;
     property ControlHardware : string read _ControlHardware write _ControlHardware;
     property ControlNetwork : string read _ControlNetwork write _ControlNetwork;
     property ControlAccounts : string read _ControlAccounts write _ControlAccounts;
     property SendSMS : string read _SendSMS write _SendSMS;
     property ChatPort : string read _ChatPort write _ChatPort;
     property UDPPort : string read _UDPPort write _UDPPort;
     property AdminMachineIPAddress : string read _AdminMachineIPAddress write _AdminMachineIPAddress;
     property LanguageCode : string read _LanguageCode write _LanguageCode;
     property RigthToLeft : string read _RigthToLeft write _RigthToLeft;
     property StepNumber : string read _StepNumber write _StepNumber;
     property Version : string read _Version write _Version;
     property ChatWithOther : string read _ChatWithOther write _ChatWithOther;
     property FileTransferToOther : string read _FileTransferToOther write _FileTransferToOther;
     property VideoConfToOther : string read _VideoConfToOther write _VideoConfToOther;
     property ImageProccesing : string read _ImageProccesing write _ImageProccesing;
     property LockIpAddress  : string read _LockIpAddress write _LockIpAddress;
     property SendMail : string read _SendMail write _SendMail;
     property RemoteDesktopPort : string read _RemoteDesktopPort write _RemoteDesktopPort;
     property FileTransferPort : string read _FileTransferPort write _FileTransferPort;
     property VideoConfPort : string read _VideoConfPort write _VideoConfPort;
     property CMDPort : string read _CMDPort write _CMDPort;
     property WebinarPort : string read _WebinarPort write _WebinarPort;
     property PublicPort : string read _PublicPort write _PublicPort;
     property UsbAccessControl : string read _UsbAccessControl write _UsbAccessControl;
     property UsbDataControl : string read _UsbDataControl write _UsbDataControl;
     property RegAccessControl : string read _RegAccessControl write _RegAccessControl;
     property AppInstallDisable : string read _AppInstallDisable write _AppInstallDisable;
     property AppRunDisable : string read _AppRunDisable write _AppRunDisable;
     property DisableCtrlAltDel : string read _DisableCtrlAltDel write _DisableCtrlAltDel;
     property UpdateCounter : string read _UpdateCounter write _UpdateCounter;

     property HardCaption :  LocalData.TStringArray read _HardCaption write _HardCaption;
     property HardSignature : LocalData.TStringArray read _HardSignature write _HardSignature;
     property HardSize  : LocalData.TStringArray read _HardSize write _HardSize;
     property HardPartitions : LocalData.TStringArray read _HardPartitions write _HardPartitions;
     property HardPNPDeviceID : LocalData.TStringArray read _HardPNPDeviceID write _HardPNPDeviceID;
     property HardHashCode : LocalData.TStringArray read _HardHashCode write _HardHashCode;
     property HardTotalHashCode : string read _HardTotalHashCode write _HardTotalHashCode;

     property CpuVendorid : string read _CpuVendorid write _CpuVendorid;
     property CpuSteppingid : string read _CpuSteppingid write _CpuSteppingid;
     property CpuModelnumber : string read _CpuModelnumber write _CpuModelnumber;
     property CpuFamilycode : string read _CpuFamilycode write _CpuFamilycode;
     property CpuProcessortype : string read _CpuProcessortype write _CpuProcessortype;
     property CpuExtendedModel: string read _CpuExtendedModel write _CpuExtendedModel;
     property CpuExtendedfamily: string read _CpuExtendedfamily write _CpuExtendedfamily;
     property CpuBrandid : string read _CpuBrandid write _CpuBrandid;
     property CpuChunks : string read _CpuChunks write _CpuChunks;
     property CpuCount : string read _CpuCount write _CpuCount;
     property CpuAPICID : string read _CpuAPICID write _CpuAPICID;
     property CpuSerialnumber: string read _CpuSerialnumber write _CpuSerialnumber;
     property CpuMMX : string read _CpuMMX write _CpuMMX;
     property CpuFXSAVE_FXRSTOR_Instructions : string read _CpuFXSAVE_FXRSTOR_Instructions write _CpuFXSAVE_FXRSTOR_Instructions;
     property CpuSSE : string read _CpuSSE write _CpuSSE;
     property CpuSSE2: string read _CpuSSE2 write _CpuSSE2;
     property CpuExtendedCPUID : string read _CpuLargest_Function_Supported write _CpuLargest_Function_Supported;
     property CpuLargest_Function_Supported : string read _HardTotalHashCode write _HardTotalHashCode;
     property CpuBrand_String : string read _CpuBrand_String write _CpuBrand_String;
     property CpuHashCode : string read _CpuHashCode write _CpuHashCode;

     property BiosVendor : string read _BiosVendor write _BiosVendor;
     property BiosStartSegment : string read _BiosStartSegment write _BiosStartSegment;
     property BiosVersion : string read _BiosVersion write _BiosVersion;
     property BiosReleaseDate : string read _BiosReleaseDate write _BiosReleaseDate;
     property BiosBiosRomSize : string read _BiosBiosRomSize write _BiosBiosRomSize;
     property BiosHashCode : string read _BiosHashCode write _BiosHashCode;

     property ChassisAssetTagNumber : string read _ChassisAssetTagNumber write _ChassisAssetTagNumber;
     property ChassisChassisType : string read _ChassisChassisType write _ChassisChassisType;
     property ChassisHashCode : string read _ChassisHashCode write _ChassisHashCode;

     property MainboardManufacter : string read _MainboardManufacter write _MainboardManufacter;
     property MainboardProduct : string read _MainboardProduct write _MainboardProduct;
     property MainboardVersion : string read _MainboardVersion write _MainboardVersion;
     property MainboardSerialNumber : string read _MainboardSerialNumber write _MainboardSerialNumber;
     property MainboardHashCode : string read _MainboardHashCode write _MainboardHashCode;

     property OsSerialNumber : string read _OsSerialNumber write _OsSerialNumber;
     property OsBuildNumber : string read _OsBuildNumber write _OsBuildNumber;
     property OsCaption : string read _OsCaption write _OsCaption;
     property OsFreePhysicalMemory : string read _OsFreePhysicalMemory write _OsFreePhysicalMemory;
     property OsInstallDate : string read _OsInstallDate write _OsInstallDate;
     property OsVersion : string read _OsVersion write _OsVersion;
     property OsLastBootUpTime : string read _OsLastBootUpTime write _OsLastBootUpTime;
     property OsHashCode : string read _OsHashCode write _OsHashCode;

     property SysUUID : string read _SysUUID write _SysUUID;
     property SysHashCode : string read _SysHashCode write _SysHashCode;

     property VideoCardCaption :  LocalData.TStringArray read _VideoCardCaption write _VideoCardCaption;
     property VideoCardDriverDate : LocalData.TStringArray read _VideoCardDriverDate write _VideoCardDriverDate;
     property VideoCardDriverVersion  : LocalData.TStringArray read _VideoCardDriverVersion write _VideoCardDriverVersion;
     property VideoCardVideoProcessor : LocalData.TStringArray read _VideoCardVideoProcessor write _VideoCardVideoProcessor;
     property VideoCardVideoMode : LocalData.TStringArray read _VideoCardVideoMode write _VideoCardVideoMode;
     property VideoCardAdapterRam : LocalData.TStringArray read _VideoCardAdapterRam write _VideoCardAdapterRam;
     property VideoCardHashCode : LocalData.TStringArray read _VideoCardHashCode write _VideoCardHashCode;
     property VideoCardTotalHashCode : string read _VideoCardTotalHashCode write _VideoCardTotalHashCode;

     property CDRomName :  LocalData.TStringArray read _CDRomName write _CDRomName;
     property CDRomDrive :  LocalData.TStringArray read _CDRomDrive write _CDRomDrive;
     property CDRomHashCode : LocalData.TStringArray read _CDRomHashCode write _CDRomHashCode;
     property CDRomTotalHashCode : string read _CDRomTotalHashCode write _CDRomTotalHashCode;

     property LogicDiskCaption :  LocalData.TStringArray read _LogicDiskCaption write _LogicDiskCaption;
     property LogicDiskDescription : LocalData.TStringArray read _LogicDiskDescription write _LogicDiskDescription;
     property LogicDiskFileSystem  : LocalData.TStringArray read _LogicDiskFileSystem write _LogicDiskFileSystem;
     property LogicDiskVolumeSize : LocalData.TStringArray read _LogicDiskVolumeSize write _LogicDiskVolumeSize;
     property LogicDiskFreeSpace : LocalData.TStringArray read _LogicDiskFreeSpace write _LogicDiskFreeSpace;
     property LogicDiskVolumeName : LocalData.TStringArray read _LogicDiskVolumeName write _LogicDiskVolumeName;
     property LogicDiskVolumeSerialNumber : LocalData.TStringArray read _LogicDiskVolumeSerialNumber write _LogicDiskVolumeSerialNumber;
     property LogicDiskHashCode : LocalData.TStringArray read _LogicDiskHashCode write _LogicDiskHashCode;
     property LogicDiskTotalHashCode : string read _LogicDiskTotalHashCode write _LogicDiskTotalHashCode;

     property MemoryBankLabel :  LocalData.TStringArray read _MemoryBankLabel write _MemoryBankLabel;
     property MemoryCapacity : LocalData.TStringArray read _MemoryCapacity write _MemoryCapacity;
     property MemorySpeed  : LocalData.TStringArray read _MemorySpeed write _MemorySpeed;
     property MemoryHashCode : LocalData.TStringArray read _MemoryHashCode write _MemoryHashCode;
     property MemoryTotalHashCode : string read _MemoryTotalHashCode write _MemoryTotalHashCode;

     property ModemModemName :  LocalData.TStringArray read _ModemModemName write _ModemModemName;
     property ModemHashCode : LocalData.TStringArray read _ModemHashCode write _ModemHashCode;
     property ModemTotalHashCode : string read _ModemTotalHashCode write _ModemTotalHashCode;

     property NetworkAdapterDescription :  LocalData.TStringArray read _NetworkAdapterDescription write _NetworkAdapterDescription;
     property NetworkAdapterAdapterType : LocalData.TStringArray read _NetworkAdapterAdapterType write _NetworkAdapterAdapterType;
     property NetworkAdapterMACAddress  : LocalData.TStringArray read _NetworkAdapterMACAddress write _NetworkAdapterMACAddress;
     property NetworkAdapterManufacturer : LocalData.TStringArray read _NetworkAdapterManufacturer write _NetworkAdapterManufacturer;
     property NetworkAdapterNetConnectionID : LocalData.TStringArray read _NetworkAdapterNetConnectionID write _NetworkAdapterNetConnectionID;
     property NetworkAdapterPNPDeviceID : LocalData.TStringArray read _NetworkAdapterPNPDeviceID write _NetworkAdapterPNPDeviceID;
     property NetworkAdapterTimeOfLastReset : LocalData.TStringArray read _NetworkAdapterTimeOfLastReset write _NetworkAdapterTimeOfLastReset;
     property NetworkAdapterHashCode : LocalData.TStringArray read _NetworkAdapterHashCode write _NetworkAdapterHashCode;
     property NetworkAdapterTotalHashCode : string read _NetworkAdapterTotalHashCode write _NetworkAdapterTotalHashCode;

     property PrinterPrinterName :  LocalData.TStringArray read _PrinterPrinterName write _PrinterPrinterName;
     property PrinterNetwork : LocalData.TStringArray read _PrinterNetwork write _PrinterNetwork;
     property PrinterHashCode : LocalData.TStringArray read _PrinterHashCode write _PrinterHashCode;
     property PrinterTotalHashCode : string read _PrinterTotalHashCode write _PrinterTotalHashCode;

     property PublicDevicesMonitor : string read _PublicDevicesMonitor write _PublicDevicesMonitor;
     property PublicDevicesKeyboard : string read _PublicDevicesKeyboard write _PublicDevicesKeyboard;
     property PublicDevicesMouse  : string read _PublicDevicesMouse write _PublicDevicesMouse;
     property PublicDevicesCamera : string read _PublicDevicesCamera write _PublicDevicesCamera;
     property PublicDevicesHashCode : string read _PublicDevicesHashCode write _PublicDevicesHashCode;

     property SoftwareName : LocalData.TName read _SoftwareName write _SoftwareName;
     property SoftwareHashCode : string read _SoftwareHashCode write _SoftwareHashCode;

     property UserAccountUserName :  LocalData.TStringArray read _UserAccountUserName write _UserAccountUserName;
     property UserAccountSID : LocalData.TStringArray read _UserAccountSID write _UserAccountSID;
     property UserAccountDescription  : LocalData.TStringArray read _UserAccountDescription write _UserAccountDescription;
     property UserAccountStatus : LocalData.TStringArray read _UserAccountStatus write _UserAccountStatus;
     property UserAccountHashCode : LocalData.TStringArray read _UserAccountHashCode write _UserAccountHashCode;
     property UserAccountTotalHashCode : string read _UserAccountTotalHashCode write _UserAccountTotalHashCode;

     property GroupAccountGroupName :  LocalData.TStringArray read _GroupAccountGroupName write _GroupAccountGroupName;
     property GroupAccountGID : LocalData.TStringArray read _GroupAccountGID write _GroupAccountGID;
     property GroupAccountDescription  : LocalData.TStringArray read _GroupAccountDescription write _GroupAccountDescription;
     property GroupAccountStatus : LocalData.TStringArray read _GroupAccountStatus write _GroupAccountStatus;
     property GroupAccountHashCode : LocalData.TStringArray read _GroupAccountHashCode write _GroupAccountHashCode;
     property GroupAccountTotalHashCode : string read _GroupAccountTotalHashCode write _GroupAccountTotalHashCode;

     property ActiveNetworkSettingCaption : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingCaption write _ActiveNetworkSettingCaption;
     property ActiveNetworkSettingIPAddress :  GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingIPAddress write _ActiveNetworkSettingIPAddress;
     property ActiveNetworkSettingSubnetMask : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingSubnetMask write _ActiveNetworkSettingSubnetMask;
     property ActiveNetworkSettingDefaultGateway  : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingDefaultGateway write _ActiveNetworkSettingDefaultGateway;
     property ActiveNetworkSettingDNSServer : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingDNSServer write _ActiveNetworkSettingDNSServer;
     property ActiveNetworkSettingDHCPActive : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingDHCPActive write _ActiveNetworkSettingDHCPActive;
     property ActiveNetworkSettingDHCPServer : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingDHCPServer write _ActiveNetworkSettingDHCPServer;
     property ActiveNetworkSettingMACAddress : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingMACAddress write _ActiveNetworkSettingMACAddress;
     property ActiveNetworkSettingHashCode : GetActiveNetworkSetting.TNewStringArray read _ActiveNetworkSettingHashCode write _ActiveNetworkSettingHashCode;
     property ActiveNetworkSettingTotalHashCode : string read _ActiveNetworkSettingTotalHashCode write _ActiveNetworkSettingTotalHashCode;

     property Dll_Total_HashCode : string read _Dll_Total_HashCode write _Dll_Total_HashCode;
     property Dll_CPU_HashCode : string read _Dll_CPU_HashCode write _Dll_CPU_HashCode;
     property Dll_Mainboard_HashCode : string read _Dll_Mainboard_HashCode write _Dll_Mainboard_HashCode;
     property Dll_Bios_HashCode : string read _Dll_Bios_HashCode write _Dll_Bios_HashCode;
     property Dll_TotalMemory_HashCode : string read _Dll_TotalMemory_HashCode write _Dll_TotalMemory_HashCode;
     property Dll_TotalHardDisks_HashCode : string read _Dll_TotalHardDisks_HashCode write _Dll_TotalHardDisks_HashCode;
     property Dll_TotalLogicHards_HashCode : string read _Dll_TotalLogicHards_HashCode write _Dll_TotalLogicHards_HashCode;
     property Dll_TotalSoftwares_HashCode : string read _Dll_TotalSoftwares_HashCode write _GroupAccountTotalHashCode;
     property Dll_Chassis_HashCode : string read _Dll_Chassis_HashCode write _Dll_Chassis_HashCode;
     property Dll_AgentProperties_HashCode : string read _Dll_AgentProperties_HashCode write _Dll_AgentProperties_HashCode;
     property Dll_OS_HashCode : string read _Dll_OS_HashCode write _Dll_OS_HashCode;
     property Dll_Sys_HashCode : string read _Dll_Sys_HashCode write _Dll_Sys_HashCode;
     property Dll_TotalVideoCards_HashCode : string read _Dll_TotalVideoCards_HashCode write _Dll_TotalVideoCards_HashCode;
     property Dll_TotalCdRom_HashCode : string read _Dll_TotalCdRom_HashCode write _Dll_TotalCdRom_HashCode;
     property Dll_TotalModems_HashCode : string read _Dll_TotalModems_HashCode write _GroupAccountTotalHashCode;
     property Dll_TotalNetworkAdapters_HashCode : string read _Dll_TotalNetworkAdapters_HashCode write _Dll_TotalNetworkAdapters_HashCode;
     property Dll_TotalPrinters_HashCode : string read _Dll_TotalPrinters_HashCode write _Dll_TotalPrinters_HashCode;
     property Dll_PublicDevices_HashCode : string read _Dll_PublicDevices_HashCode write _Dll_PublicDevices_HashCode;
     property Dll_TotalUserAccounts_HashCode : string read _Dll_TotalUserAccounts_HashCode write _Dll_TotalUserAccounts_HashCode;
     property Dll_TotalGroupAccounts_HashCode : string read _Dll_TotalGroupAccounts_HashCode write _Dll_TotalGroupAccounts_HashCode;
     property Dll_TotalActiveNetworkSetting_HashCode : string read _Dll_TotalActiveNetworkSetting_HashCode write _Dll_TotalActiveNetworkSetting_HashCode;


end;

implementation

constructor TMyAgent.Create;
begin
 GetAgentSettingFromDll;
end;

procedure TMyAgent.UpdateTotoalSystemHashCode;
var
SQLStr : string;
Date_Time : string;
res : integer;
begin
 Date_Time := Localdata.ConvertToday;
 SQLStr := 'UPDATE HashCodes SET HashCode ="'+_SystemHashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 1';
   res := ExecuteQueryDll(SQLStr,1);

end;

function TMyAgent.CompareTotalHashCodes:boolean;
begin
   _TotalHashCodeChanged := CompareHashCodes(_Dll_Total_HashCode,_SystemHashCode);
   result := _TotalHashCodeChanged;
end;

function TMyAgent.CompareCpuHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_Cpu_HashCode,_CpuHashCode);
end;

function TMyAgent.CompareMainboardHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_Mainboard_HashCode,_MainboardHashCode);
end;

function TMyAgent.CompareBiosHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_Bios_HashCode,_BiosHashCode);
end;

function TMyAgent.CompareTotalMemoryHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalMemory_HashCode,_MemoryTotalHashCode);
end;

function TMyAgent.CompareTotalHardDisksHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_TotalHardDisks_HashCode,_HardTotalHashCode);
end;

function TMyAgent.CompareTotalLogicHardsHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_TotalLogicHards_HashCode,_LogicDiskTotalHashCode);
end;


function TMyAgent.CompareTotalSoftwaresHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_TotalSoftwares_HashCode,_SoftwareHashCode);
end;


function TMyAgent.CompareChassisHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_Chassis_HashCode,_ChassisHashCode);
end;

function TMyAgent.CompareAgentPropertiesHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_AgentProperties_HashCode,_HashCode);
end;

function TMyAgent.CompareOSHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_OS_HashCode,_OSHashCode);
end;

function TMyAgent.CompareSysHashCodes:boolean;
begin
    result := CompareHashCodes(_Dll_Sys_HashCode,_SysHashCode);
end;

function TMyAgent.CompareTotalVideoCardsHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalVideoCards_HashCode,_VideoCardTotalHashCode);
end;

function TMyAgent.CompareTotalCdRomHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_TotalVideoCards_HashCode,_VideoCardTotalHashCode);
end;

function TMyAgent.CompareTotalModemsHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_TotalModems_HashCode,_ModemTotalHashCode);
end;

function TMyAgent.CompareTotalNetworkAdaptersHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalNetworkAdapters_HashCode,_NetworkAdapterTotalHashCode);
end;

function TMyAgent.CompareTotalPrintersHashCodes:boolean;
begin
 result := CompareHashCodes(_Dll_TotalPrinters_HashCode,_PrinterTotalHashCode);
end;

function TMyAgent.ComparePublicDevicesHashCodes:boolean;
begin
  result := CompareHashCodes(_Dll_PublicDevices_HashCode,_PublicDevicesHashCode);
end;

function TMyAgent.CompareTotalUserAccountsHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalUserAccounts_HashCode,_UserAccountTotalHashCode);
end;

function TMyAgent.CompareTotalGroupAccountsHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalGroupAccounts_HashCode,_GroupAccountTotalHashCode);
end;

function TMyAgent.CompareTotalActiveNetworkSettingHashCodes:boolean;
begin
   result := CompareHashCodes(_Dll_TotalActiveNetworkSetting_HashCode,_ActiveNetworkSettingTotalHashCode);
end;

procedure TMyAgent.FindChanges;
var
_isChange : boolean;
begin

  _isChange := CompareCpuHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1')then FindCpuDetailsChange;

  _isChange := CompareMainboardHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindMainboardDetailsChange;

  _isChange := CompareBiosHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindBiosDetailsChange;

   _isChange := CompareTotalMemoryHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindMemoryDetailsChange;

   _isChange := CompareTotalHardDisksHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindHardDisksDetailsChange;

    _isChange := CompareTotalLogicHardsHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindLogicDisksDetailsChange;

     _isChange := CompareTotalSoftwaresHashCodes;
  if (_isChange = true)  AND (_ControlSoftware = '1') then FindSoftwaresDetailsChange;

     _isChange := CompareChassisHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindChassisDetailsChange;

     _isChange := CompareAgentPropertiesHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindAgentPropertiesDetailsChange;

      _isChange := CompareOSHashCodes;
  if (_isChange = true)  AND (_ControlSoftware = '1') then FindOSDetailsChange;

      _isChange := CompareSysHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindSysDetailsChange;

     _isChange := CompareTotalVideoCardsHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindVideoCardsDetailsChange;

      _isChange := CompareTotalCdRomHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindCdRomDetailsChange;

      _isChange := CompareTotalModemsHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindModemsDetailsChange;


      _isChange := CompareTotalNetworkAdaptersHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindNetworkAdaptersDetailsChange;

      _isChange := CompareTotalPrintersHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindPrintersDetailsChange;


      _isChange := ComparePublicDevicesHashCodes;
  if (_isChange = true)  AND (_ControlHardware = '1') then FindPublicDevicesChange;


      _isChange := CompareTotalUserAccountsHashCodes;
  if (_isChange = true)  AND (_ControlAccounts = '1') then FindUserAccountsChange;

      _isChange := CompareTotalGroupAccountsHashCodes;
  if (_isChange = true)  AND (_ControlAccounts = '1') then FindGroupAccountsChange;

     _isChange := CompareTotalActiveNetworkSettingHashCodes;
  if (_isChange = true)  AND (_ControlNetwork = '1') then FindActiveNetworkSettingChange;

end;


procedure TMyAgent.FindCpuDetailsChange;
var
NewBrand,OldBrand : string;
res : integer;
begin
 NewBrand := _CpuBrand_String;

 OldBrand := LocalData.GetDataFromDll('Processors','Brand','1');
 res := SaveEventToSql('1000',OldBrand,NewBrand,'2','1');
   if res = 0 then
   begin
      //save to dll for send to sql later
      LocalData.SaveEventInDll(_AgentId,'1000',OldBrand,NewBrand,'2','1');
   end;
 LocalData.DeleteDataFromDll('Processors');
 SaveSystemCpuToDll;
 DeleteAgentInfoFromSql('prcDeleteCpuInfo');
 GetSystemCPUFromDll;
 SaveSystemCpuToSql;
end;


procedure TMyAgent.FindMainboardDetailsChange;
var
res : integer;
MManufacter,MProduct,MVersion,MSerialNumber : string;
begin
 MManufacter :=  LocalData.GetDataFromDll('Motherboard','Manufacturer','1');
 MProduct :=  LocalData.GetDataFromDll('Motherboard','Product','1');
 MVersion :=  LocalData.GetDataFromDll('Motherboard','Version','1');
 MSerialNumber :=  LocalData.GetDataFromDll('Motherboard','SerialNumber','1');

if _MainboardManufacter <> MManufacter  then
begin
   res := SaveEventToSql('2001',MManufacter,_MainboardManufacter,'2','2');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'2001',MManufacter,_MainboardManufacter,'2','2');
   end;
end
else
begin
if _MainboardProduct <> MProduct then
begin
   res := SaveEventToSql('2002',MProduct,_MainboardProduct,'2','2');
   if res = 0 then
   begin
      //save to dll for send to sql later
      LocalData.SaveEventInDll(_AgentId,'2002',MProduct,_MainboardProduct,'2','2');
   end;
end;
if _MainboardVersion <> MVersion then
begin
  res := SaveEventToSql('2003',MVersion,_MainboardVersion,'1','2');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'2003',MVersion,_MainboardVersion,'1','2');
   end;
end;
if _MainboardSerialNumber <> MSerialNumber then
begin
   res := SaveEventToSql('2004',MSerialNumber,_MainboardSerialNumber,'2','2');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'2004',MSerialNumber,_MainboardSerialNumber,'2','2');
   end;
end;
end;

 LocalData.DeleteDataFromDll('Motherboard');
 SaveSystemMainboardToDll;
 DeleteAgentInfoFromSql('prcDeleteMainboardInfo');
 GetSystemMainboardFromDll;
 SaveSystemMainboardToSql;
end;


procedure TMyAgent.FindBiosDetailsChange;
var
res : integer;
BVendor,BStartSegment,BVersion,BReleaseDate,BRomSize : string;
begin
BVendor :=  LocalData.GetDataFromDll('BIOS','Vendor','1');
BStartSegment :=  LocalData.GetDataFromDll('BIOS','StartSegment','1');
BVersion :=  LocalData.GetDataFromDll('BIOS','Version','1');
BReleaseDate :=  LocalData.GetDataFromDll('BIOS','ReleaseDate','1');
BRomSize :=  LocalData.GetDataFromDll('BIOS','BiosRomSize','1');

if _BiosVendor <> BVendor  then
begin
   res := SaveEventToSql('3001',BVendor,_BiosVendor,'2','3');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'3001',BVendor,_BiosVendor,'2','3');
   end;
end
else
begin
if _BiosStartSegment <> BStartSegment  then
begin
   res := SaveEventToSql('3002',BStartSegment,_BiosStartSegment,'1','3');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'3002',BStartSegment,_BiosStartSegment,'1','3');
   end;
end;
if _BiosVersion <> BVersion  then
begin
   res := SaveEventToSql('3003',BVersion,_BiosVersion,'1','3');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'3003',BVersion,_BiosVersion,'1','3');
   end;
end;
if _BiosReleaseDate <> BReleaseDate  then
begin
   res := SaveEventToSql('3004',BReleaseDate,_BiosReleaseDate,'1','3');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'3004',BReleaseDate,_BiosReleaseDate,'1','3');
   end;
end;
if _BiosBiosRomSize <> BRomSize  then
begin
   res := SaveEventToSql('3005',BRomSize,_BiosBiosRomSize,'1','3');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'3005',BRomSize,_BiosBiosRomSize,'1','3');
   end;
end;
end;
 LocalData.DeleteDataFromDll('BIOS');
 SaveSystemBiosToDll;
 DeleteAgentInfoFromSql('prcDeleteBiosInfo');
 GetSystemBiosFromDll;
 SaveSystemBiosToSql;
end;


procedure TMyAgent.FindMemoryDetailsChange;
var
MemoryHashCodesArrayFromDll,MemoryBankArrayFromDll,MemoryCapacityArrayFromDll,MemorySpeedArrayFromDll: LocalData.TStringArray;
MemoryArrayFromDll : LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,BankDllList,BankCurrentList : TStringList;
i,res : integer;
begin
     MemoryHashCodesArrayFromDll := LocalData.HashCodesToArray('Memory');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(MemoryHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_MemoryHashCode);
     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         InstallNewMemoryInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('Memory');
         LocalData.CreateRowDataTableInDll('Memory',32);
         SaveSystemMemoryToDll;
         DeleteAgentInfoFromSql('prcDeleteMemoryInfo');
         GetSystemMemoryFromDll;
         SaveSystemMemoryToSql;
     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
        // delete items
         UninstallMemoryEvent(DllList);
         LocalData.DeleteDataFromDll('Memory');
         LocalData.CreateRowDataTableInDll('Memory',32);
         SaveSystemMemoryToDll;
         DeleteAgentInfoFromSql('prcDeleteMemoryInfo');
         GetSystemMemoryFromDll;
         SaveSystemMemoryToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items

        MemoryBankArrayFromDll := LocalData.GetDataArrayFromDll('Memory','BankLabel');
        BankDllList := TstringList.Create;
        BankDllList := LocalData.GetListFromArray(MemoryBankArrayFromDll);

        BankCurrentList := TstringList.Create;
        BankCurrentList := LocalData.GetListFromArray(_MemoryBankLabel);

        LocalData.CompareLists(BankCurrentList,BankDllList);

        if BankCurrentList.Count > 0 then
        begin
        // this is new Memory
          InstallNewMemoryInsertEvent(BankCurrentList);
          LocalData.DeleteDataFromDll('Memory');
          LocalData.CreateRowDataTableInDll('Memory',32);
          SaveSystemMemoryToDll;
          DeleteAgentInfoFromSql('prcDeleteMemoryInfo');
          GetSystemMemoryFromDll;
          SaveSystemMemoryToSql;

        end;
        if BankDllList.Count > 0 then
        begin
        // this is delete Memory
          UninstallMemoryEvent(BankDllList);
          LocalData.DeleteDataFromDll('Memory');
          LocalData.CreateRowDataTableInDll('Memory',32);
          SaveSystemMemoryToDll;
          DeleteAgentInfoFromSql('prcDeleteMemoryInfo');
          GetSystemMemoryFromDll;
          SaveSystemMemoryToSql;

        end;
        if CurrentList.Count > BankCurrentList.Count then
        begin
          // this is change Memory
        MemoryCapacityArrayFromDll := LocalData.GetDataArrayFromDll('Memory','Capacity');
        MemorySpeedArrayFromDll := LocalData.GetDataArrayFromDll('Memory','Speed');

        i := 0;
        while i <  Length(_MemoryCapacity) do
        begin

            if _MemoryCapacity[i] <> MemoryCapacityArrayFromDll[i] then
            begin
               res := SaveEventToSql('4003',MemoryCapacityArrayFromDll[i],_MemoryCapacity[i],'1','4');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'4003',MemoryCapacityArrayFromDll[i],_MemoryCapacity[i],'1','4');
               end;
            end;

            if _MemorySpeed[i] <> MemorySpeedArrayFromDll[i] then
            begin
               res := SaveEventToSql('4004',MemorySpeedArrayFromDll[i],_MemorySpeed[i],'1','4');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'4004',MemorySpeedArrayFromDll[i],_MemorySpeed[i],'1','4');
               end;
            end;
           inc(i);
        end;
          LocalData.DeleteDataFromDll('Memory');
          LocalData.CreateRowDataTableInDll('Memory',32);
          SaveSystemMemoryToDll;
          DeleteAgentInfoFromSql('prcDeleteMemoryInfo');
          GetSystemMemoryFromDll;
          SaveSystemMemoryToSql;

      end;
    end;

end;

procedure TMyAgent.FindHardDisksDetailsChange;
var
HardHashCodesArrayFromDll,HardCaptionArrayFromDll: LocalData.TStringArray;
HardSignatureArrayFromDll : LocalData.TStringArray;
HardSizeArrayFromDll :LocalData.TStringArray;
HardPartitionsArrayFromDll :LocalData.TStringArray;
HardPNPDeviceIDArrayFromDll :LocalData.TStringArray;

CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     HardHashCodesArrayFromDll := LocalData.HashCodesToArray('HardDisk');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(HardHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_HardHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewHardDiskInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('HardDisk');
         LocalData.CreateRowDataTableInDll('HardDisk',32);
         SaveSystemHardDisksToDll;
         DeleteAgentInfoFromSql('prcDeleteHardDiskInfo');
         GetSystemHardDisksFromDll;
         SaveSystemHardDisksToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         HardDiskUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('HardDisk');
         LocalData.CreateRowDataTableInDll('HardDisk',32);
         SaveSystemHardDisksToDll;
         DeleteAgentInfoFromSql('prcDeleteHardDiskInfo');
         GetSystemHardDisksFromDll;
         SaveSystemHardDisksToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        HardCaptionArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','Caption');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(HardCaptionArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_HardCaption);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Hard Disk
          NewHardDiskCaptionInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('HardDisk');
          LocalData.CreateRowDataTableInDll('HardDisk',32);
          SaveSystemHardDisksToDll;
          DeleteAgentInfoFromSql('prcDeleteHardDiskInfo');
          GetSystemHardDisksFromDll;
          SaveSystemHardDisksToSql;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Hard Disk
          HardDiskCaptionUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('HardDisk');
          LocalData.CreateRowDataTableInDll('HardDisk',32);
          SaveSystemHardDisksToDll;
          DeleteAgentInfoFromSql('prcDeleteHardDiskInfo');
          GetSystemHardDisksFromDll;
          SaveSystemHardDisksToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change video card properties
        HardSignatureArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','Signature');
        HardSizeArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','HardSize');
        HardPartitionsArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','Partitions');
        HardPNPDeviceIDArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','PNPDeviceID');

        i := 0;
        while i <  Length(_HardSignature) do
        begin

            if _HardSignature[i] <> HardSignatureArrayFromDll[i] then
            begin
               res := SaveEventToSql('5003',HardSignatureArrayFromDll[i],_HardSignature[i],'1','5');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'5003',HardSignatureArrayFromDll[i],_HardSignature[i],'1','5');
               end;
            end;

            if _HardSize[i] <> HardSizeArrayFromDll[i] then
            begin
               res := SaveEventToSql('5004',HardSizeArrayFromDll[i],_HardSize[i],'1','5');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'5004',HardSizeArrayFromDll[i],_HardSize[i],'1','5');
               end;
            end;

            if _HardPartitions[i] <> HardPartitionsArrayFromDll[i] then
            begin
               res := SaveEventToSql('5005',HardPartitionsArrayFromDll[i],_HardPartitions[i],'1','5');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'5005',HardPartitionsArrayFromDll[i],_HardPartitions[i],'1','5');
               end;
            end;

            if _HardPNPDeviceID[i] <> HardPNPDeviceIDArrayFromDll[i] then
            begin
               res := SaveEventToSql('5006',HardPNPDeviceIDArrayFromDll[i],_HardPNPDeviceID[i],'1','5');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'5006',HardPNPDeviceIDArrayFromDll[i],_HardPNPDeviceID[i],'1','5');
               end;
            end;
           inc(i);
        end;

          LocalData.DeleteDataFromDll('HardDisk');
          LocalData.CreateRowDataTableInDll('HardDisk',32);
          SaveSystemHardDisksToDll;
          DeleteAgentInfoFromSql('prcDeleteHardDiskInfo');
          GetSystemHardDisksFromDll;
          SaveSystemHardDisksToSql;
       end;
     end;
end;

procedure TMyAgent.NewHardDiskInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
HardHashCodeList : TStringList;
begin
HardHashCodeList := TstringList.Create;
HardHashCodeList := LocalData.GetListFromArray(_HardHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := HardHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('5001','',_HardCaption[index],'1','5');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'5001','',_HardCaption[index],'1','5');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewHardDiskCaptionInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('5001','',CList[i],'1','5');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'5001','',CList[i],'1','5');
   end;
   inc(i);
end;
end;

procedure TMyAgent.HardDiskCaptionUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('5002',CList[i],'','1','5');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'5002',CList[i],'','1','5');
   end;
   inc(i);
end;
end;


procedure TMyAgent.HardDiskUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
HardHashCodesArrayFromDll: LocalData.TStringArray;
HardCaptionArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
HardHashCodesArrayFromDll := LocalData.HashCodesToArray('HardDisk');
HardCaptionArrayFromDll := LocalData.GetDataArrayFromDll('HardDisk','Caption');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(HardHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('5002',HardCaptionArrayFromDll[index],'','1','5');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'5002',HardCaptionArrayFromDll[index],'','1','5');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindLogicDisksDetailsChange;
var
LogicHashCodesArrayFromDll,LogicCaptionArrayFromDll: LocalData.TStringArray;
LogicDescriptionArrayFromDll : LocalData.TStringArray;
LogicFileSystemArrayFromDll :LocalData.TStringArray;
LogicVolumeSizeArrayFromDll :LocalData.TStringArray;
LogicVolumeNameArrayFromDll :LocalData.TStringArray;
LogicVolumeSerialNumberArrayFromDll :LocalData.TStringArray;

CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     LogicHashCodesArrayFromDll := LocalData.HashCodesToArray('LogicDisk');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(LogicHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_LogicDiskHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewLogicDiskInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('LogicDisk');
         LocalData.CreateRowDataTableInDll('LogicDisk',50);
         SaveSystemLogicDiskToDll;
         DeleteAgentInfoFromSql('prcDeleteLogicDiskInfo');
         GetSystemLogicDiskFromDll;
         SaveSystemLogicDiskToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         LogicDiskUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('LogicDisk');
         LocalData.CreateRowDataTableInDll('LogicDisk',50);
         SaveSystemLogicDiskToDll;
         DeleteAgentInfoFromSql('prcDeleteLogicDiskInfo');
         GetSystemLogicDiskFromDll;
         SaveSystemLogicDiskToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        LogicCaptionArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','Caption');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(LogicCaptionArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_LogicDiskCaption);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Hard Disk
          NewLogicDiskCaptionInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('LogicDisk');
           LocalData.CreateRowDataTableInDll('LogicDisk',50);
          SaveSystemLogicDiskToDll;
          DeleteAgentInfoFromSql('prcDeleteLogicDiskInfo');
          GetSystemLogicDiskFromDll;
          SaveSystemLogicDiskToSql;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Hard Disk
          LogicDiskCaptionUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('LogicDisk');
           LocalData.CreateRowDataTableInDll('LogicDisk',50);
          SaveSystemLogicDiskToDll;
          DeleteAgentInfoFromSql('prcDeleteLogicDiskInfo');
          GetSystemLogicDiskFromDll;
          SaveSystemLogicDiskToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change video card properties
        LogicDescriptionArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','Description');
        LogicFileSystemArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','FileSystem');
        LogicVolumeSizeArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','VolumeSize');
        LogicVolumeNameArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','VolumeName');
        LogicVolumeSerialNumberArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','VolumeSerialNumber');
        i := 0;
        while i < Length(_LogicDiskDescription) do
        begin

            if _LogicDiskDescription[i] <> LogicDescriptionArrayFromDll[i] then
            begin
               res := SaveEventToSql('6003',LogicDescriptionArrayFromDll[i],_LogicDiskDescription[i],'1','6');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'6003',LogicDescriptionArrayFromDll[i],_LogicDiskDescription[i],'1','6');
               end;
            end;

            if _LogicDiskFileSystem[i] <> LogicFileSystemArrayFromDll[i] then
            begin
               res := SaveEventToSql('6004',LogicFileSystemArrayFromDll[i],_LogicDiskFileSystem[i],'1','6');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'6004',LogicFileSystemArrayFromDll[i],_LogicDiskFileSystem[i],'1','6');
               end;
            end;

            if _LogicDiskVolumeSize[i] <> LogicVolumeSizeArrayFromDll[i] then
            begin
               res := SaveEventToSql('6005',LogicVolumeSizeArrayFromDll[i],_LogicDiskVolumeSize[i],'1','6');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'6005',LogicVolumeSizeArrayFromDll[i],_LogicDiskVolumeSize[i],'1','6');
               end;
            end;

            if _LogicDiskVolumeName[i] <> LogicVolumeNameArrayFromDll[i] then
            begin
               res := SaveEventToSql('6006',LogicVolumeNameArrayFromDll[i],_LogicDiskVolumeName[i],'1','6');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'6006',LogicVolumeNameArrayFromDll[i],_LogicDiskVolumeName[i],'1','6');
               end;
            end;

             if _LogicDiskVolumeSerialNumber[i] <> LogicVolumeSerialNumberArrayFromDll[i] then
            begin
               res := SaveEventToSql('6007',LogicVolumeSerialNumberArrayFromDll[i],_LogicDiskVolumeSerialNumber[i],'1','6');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'6007',LogicVolumeSerialNumberArrayFromDll[i],_LogicDiskVolumeSerialNumber[i],'1','6');
               end;
            end;

           inc(i);
        end;

          LocalData.DeleteDataFromDll('LogicDisk');
           LocalData.CreateRowDataTableInDll('LogicDisk',50);
          SaveSystemLogicDiskToDll;
          DeleteAgentInfoFromSql('prcDeleteLogicDiskInfo');
          GetSystemLogicDiskFromDll;
          SaveSystemLogicDiskToSql;
       end;
     end;
end;

procedure TMyAgent.NewLogicDiskInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
LogicHashCodeList : TStringList;
begin
LogicHashCodeList := TstringList.Create;
LogicHashCodeList := LocalData.GetListFromArray(_LogicDiskHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := LogicHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('6001','',_LogicDiskCaption[index],'1','6');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'6001','',_LogicDiskCaption[index],'1','6');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewLogicDiskCaptionInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('6001','',CList[i],'1','6');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'6001','',CList[i],'1','6');
   end;
   inc(i);
end;
end;

procedure TMyAgent.LogicDiskCaptionUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('6002',CList[i],'','1','5');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'6002',CList[i],'','1','5');
   end;
   inc(i);
end;
end;


procedure TMyAgent.LogicDiskUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
LogicHashCodesArrayFromDll: LocalData.TStringArray;
LogicCaptionArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
LogicHashCodesArrayFromDll := LocalData.HashCodesToArray('LogicDisk');
LogicCaptionArrayFromDll := LocalData.GetDataArrayFromDll('LogicDisk','Caption');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(LogicHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('6002',LogicCaptionArrayFromDll[index],'','1','6');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'6002',LogicCaptionArrayFromDll[index],'','1','6');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindSoftwaresDetailsChange;
var
SoftwareNameArrayFromDll: LocalData.TStringArray;

CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList: TStringList;
i,res : integer;
begin

     SoftwareNameArrayFromDll := LocalData.GetDataArrayFromDll('Software','SoftwareName');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(SoftwareNameArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetSoftListFromArray(_SoftwareName);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) then
     begin
         // new items
         NewSoftwareInstallEvent(CurrentList);
         LocalData.DeleteDataFromDll('Software');
         SaveSystemSoftwareToDll;
         DeleteAgentInfoFromSql('prcDeleteSoftwareInfo');
         GetSystemSoftwareFromDll;
         SaveSystemSoftwareToSql;

     end;

     if (DllList.Count > 0) then
     begin
         SoftwareUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('Software');
         SaveSystemSoftwareToDll;
         DeleteAgentInfoFromSql('prcDeleteSoftwareInfo');
          GetSystemSoftwareFromDll;
         SaveSystemSoftwareToSql;
     end;
end;

procedure TMyAgent.NewSoftwareInstallEvent(CList:TStringList);
var
i,len,res,index1,index2 : integer;
name : string;
begin
i := 0;
len := CList.Count;
while i < len do
begin
   name := CList[i];
   index1 :=  Pos(name,'Update');
   index2 := Pos(name,'Hotfix');
   if (index1 <> -1) OR (index2 <> -1)   then
   begin
     res := SaveEventToSql('17001','',CList[i],'1','17');
     if res = 0 then
     begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'17001','',CList[i],'1','17');
     end;
   end else
   begin
     res := SaveEventToSql('17001','',CList[i],'1','17');
     if res = 0 then
     begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'17001','',CList[i],'1','17');
     end;
   end;
   inc(i);
end;
end;

procedure TMyAgent.SoftwareUninstallEvent(DList:TStringList);
var
i,len,res,index1,index2 : integer;
name : string;
begin
i := 0;
len := DList.Count;
while i < len do
begin
   name := DList[i];
   index1 :=  Pos(name,'Update');
   index2 := Pos(name,'Hotfix');
   if (index1 <> -1) OR (index2 <> -1)   then
   begin
     res := SaveEventToSql('17002',DList[i],'','2','17');
     if res = 0 then
     begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'17002',DList[i],'','2','17');
     end;
   end else
   begin
     res := SaveEventToSql('17002',DList[i],'','2','17');
     if res = 0 then
     begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'17002',DList[i],'','2','17');
     end;
   end;
   inc(i);
end;
end;



procedure TMyAgent.FindChassisDetailsChange;
var
res : integer;
ChAssetTagNumber,ChChassisType: string;
begin
ChAssetTagNumber :=  LocalData.GetDataFromDll('Chassis','AssetTagNumber','1');
ChChassisType :=  LocalData.GetDataFromDll('Chassis','ChassisType','1');

if _ChassisAssetTagNumber <> ChAssetTagNumber  then
begin
   res := SaveEventToSql('30001',ChAssetTagNumber,_ChassisAssetTagNumber,'2','30');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'30001',ChAssetTagNumber,_ChassisAssetTagNumber,'2','30');
   end;
end;
if _ChassisChassisType <> ChChassisType  then
begin
   res := SaveEventToSql('30002',ChChassisType,_ChassisChassisType,'2','30');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'30002',ChChassisType,_ChassisChassisType,'2','30');
   end;
end;
LocalData.DeleteDataFromDll('Chassis');
LocalData.CreateRowDataTableInDll('Chassis',1);
SaveSystemChassisToDll;
DeleteAgentInfoFromSql('prcDeleteChassisInfo');
GetSystemChassisFromDll;
SaveSystemChassisToSql;
end;

procedure TMyAgent.FindAgentPropertiesDetailsChange;
var
res : integer;
Date_Time,CompName,Organiz,RegCompany,RegUser: string;
begin
CompName :=  LocalData.GetDataFromDll('AgentDetails','ComputerName','1');
Organiz :=  LocalData.GetDataFromDll('AgentDetails','Organization','1');
RegCompany :=  LocalData.GetDataFromDll('AgentDetails','RegisterCompany','1');
RegUser :=  LocalData.GetDataFromDll('AgentDetails','RegisterUser','1');

if _ComputerName <> CompName  then
begin
   res := SaveEventToSql('31001',CompName,_ComputerName,'2','31');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'31001',CompName,_ComputerName,'2','31');
   end;
end;
if _Organization <> Organiz  then
begin
   res := SaveEventToSql('31002',_Organization,Organiz,'1','31');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'31002',_Organization,Organiz,'1','31');
   end;
end;

if _RegisterCompany <> RegCompany  then
begin
   res := SaveEventToSql('31003',_RegisterCompany,RegCompany,'1','31');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'31003',_RegisterCompany,RegCompany,'1','31');
   end;
end;

if _RegisterUser <> RegUser  then
begin
   res := SaveEventToSql('31004',_RegisterUser,RegUser,'1','31');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'31004',_RegisterUser,RegUser,'1','31');
   end;
end;
LocalData.UpdateFieldToDll('AgentDetails','ComputerName',_ComputerName,'ID = 1');
LocalData.UpdateFieldToDll('AgentDetails','Organization',_Organization,'ID = 1');
LocalData.UpdateFieldToDll('AgentDetails','RegisterCompany',_RegisterCompany,'ID = 1');
LocalData.UpdateFieldToDll('AgentDetails','RegisterUser',_RegisterUser,'ID = 1');
LocalData.UpdateFieldToDll('HashCodes','HashCode',_HashCode,'ID = 10');
Date_Time := LocalData.ConvertToday;
LocalData.UpdateFieldToDll('HashCodes','LastUpdateDate',Date_Time,'ID = 10');
DeleteAgentInfoFromSql('prcDeleteAgentDetailInfo');
GetSystemAgentFromDll;
SaveSystemAgentToSql;


end;

procedure TMyAgent.FindOSDetailsChange;
var
res : integer;
OsSN,OsBN,OsCap,OsInsDate,OsVer: string;
begin
OsSN :=  LocalData.GetDataFromDll('OperatingSystem','SerialNumber','1');
OsBN :=  LocalData.GetDataFromDll('OperatingSystem','BuildNumber','1');
OsCap :=  LocalData.GetDataFromDll('OperatingSystem','Caption','1');
OsInsDate :=  LocalData.GetDataFromDll('OperatingSystem','InstallDate','1');
OsVer :=  LocalData.GetDataFromDll('OperatingSystem','Version','1');

if _OsSerialNumber <> OsSN  then
begin
   res := SaveEventToSql('18001',_OsSerialNumber,OsSN,'2','18');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'18001',_OsSerialNumber,OsSN,'2','18');
   end;
end;

if _OsBuildNumber <> OsBN  then
begin
   res := SaveEventToSql('18002',_OsBuildNumber,OsBN,'1','18');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'18002',_OsBuildNumber,OsBN,'1','18');
   end;
end;

if _OsCaption <> OsCap  then
begin
   res := SaveEventToSql('18003',_OsCaption,OsCap,'2','18');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'18003',_OsCaption,OsCap,'2','18');
   end;
end;

if _OsInstallDate <> OsInsDate  then
begin
   res := SaveEventToSql('18004',_OsInstallDate,OsInsDate,'1','18');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'18004',_OsInstallDate,OsInsDate,'1','18');
   end;
end;

if _OsVersion <> OsVer  then
begin
   res := SaveEventToSql('18005',_OsVersion,OsVer,'1','18');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'18005',_OsVersion,OsVer,'1','18');
   end;
end;
LocalData.DeleteDataFromDll('OperatingSystem');
LocalData.CreateRowDataTableInDll('OperatingSystem',1);
SaveSystemOsToDll;
DeleteAgentInfoFromSql('prcDeleteOsInfo');
GetSystemOsFromDll;
SaveSystemOsFromToSql;
end;


procedure TMyAgent.FindSysDetailsChange;
var
res : integer;
SyUUID: string;
begin
SyUUID :=  LocalData.GetDataFromDll('Sys','UUID','1');
if _SysUUID <> SyUUID  then
begin
   res := SaveEventToSql('32000',_SysUUID,SyUUID,'1','32000');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'32000',_SysUUID,SyUUID,'1','32000');
   end;
end;
LocalData.DeleteDataFromDll('Sys');
LocalData.CreateRowDataTableInDll('Sys',1);
SaveSystemSysToDll;
DeleteAgentInfoFromSql('prcDeleteAgentDetailInfo');
GetSystemSysFromDll;
SaveSystemAgentToSql;
end;

procedure TMyAgent.FindVideoCardsDetailsChange;
var
VideoCardHashCodesArrayFromDll,VideoCardCaptionArrayFromDll: LocalData.TStringArray;
VideoCardArrayFromDll : LocalData.TStringArray;
VideoCardDriverDateArrayFromDll :LocalData.TStringArray;
VideoCardDriverVersionArrayFromDll :LocalData.TStringArray;
VideoCardVideoProcessorArrayFromDll :LocalData.TStringArray;
VideoCardVideoModeArrayFromDll :LocalData.TStringArray;
VideoCardAdapterRamArrayFromDll :LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     VideoCardHashCodesArrayFromDll := LocalData.HashCodesToArray('VideoCard');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(VideoCardHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_VideoCardHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewVideoCardInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('VideoCard');
         LocalData.CreateRowDataTableInDll('VideoCard',4);
         SaveSystmVideoCardToDll;
         DeleteAgentInfoFromSql('prcDeleteVideoCardInfo');
         GetSystmVideoCardFromDll;
         SaveSystmVideoCardToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         VideoCardUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('VideoCard');
         LocalData.CreateRowDataTableInDll('VideoCard',4);
         SaveSystmVideoCardToDll;
         DeleteAgentInfoFromSql('prcDeleteVideoCardInfo');
         GetSystmVideoCardFromDll;
         SaveSystmVideoCardToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        VideoCardCaptionArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','Caption');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(VideoCardCaptionArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_VideoCardCaption);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new video card
          NewVideoCardCaptionInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('VideoCard');
          LocalData.CreateRowDataTableInDll('VideoCard',4);
          SaveSystmVideoCardToDll;
          DeleteAgentInfoFromSql('prcDeleteVideoCardInfo');
          GetSystmVideoCardFromDll;
          SaveSystmVideoCardToSql;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete video card
          VideoCardCaptionUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('VideoCard');
          LocalData.CreateRowDataTableInDll('VideoCard',4);
          SaveSystmVideoCardToDll;
          DeleteAgentInfoFromSql('prcDeleteVideoCardInfo');
          GetSystmVideoCardFromDll;
          SaveSystmVideoCardToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change video card properties
        VideoCardDriverDateArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','DriverDate');
        VideoCardDriverVersionArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','DriverVersion');
        VideoCardVideoProcessorArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','VideoProcessor');
        VideoCardVideoModeArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','VideoMode');
        VideoCardAdapterRamArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','AdapterRam');

        i:=0;
        while i <  Length(_VideoCardDriverDate) do
        begin

            if _VideoCardDriverDate[i] <> VideoCardDriverDateArrayFromDll[i] then
            begin
               res := SaveEventToSql('7001',VideoCardDriverDateArrayFromDll[i],_VideoCardDriverDate[i],'1','7');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'7001',VideoCardDriverDateArrayFromDll[i],_VideoCardDriverDate[i],'1','7');
               end;
            end;

            if _VideoCardDriverVersion[i] <> VideoCardDriverVersionArrayFromDll[i] then
            begin
               res := SaveEventToSql('7002',VideoCardDriverVersionArrayFromDll[i],_VideoCardDriverVersion[i],'1','7');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'7002',VideoCardDriverVersionArrayFromDll[i],_VideoCardDriverVersion[i],'1','7');
               end;
            end;

            if _VideoCardVideoProcessor[i] <> VideoCardVideoProcessorArrayFromDll[i] then
            begin
               res := SaveEventToSql('7003',VideoCardVideoProcessorArrayFromDll[i],_VideoCardVideoProcessor[i],'1','7');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'7003',VideoCardVideoProcessorArrayFromDll[i],_VideoCardVideoProcessor[i],'1','7');
               end;
            end;

            if _VideoCardVideoMode[i] <> VideoCardVideoModeArrayFromDll[i] then
            begin
               res := SaveEventToSql('7004',VideoCardVideoModeArrayFromDll[i],_VideoCardVideoMode[i],'1','7');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'7004',VideoCardVideoModeArrayFromDll[i],_VideoCardVideoMode[i],'1','7');
               end;
            end;

            if _VideoCardAdapterRam[i] <> VideoCardAdapterRamArrayFromDll[i] then
            begin
               res := SaveEventToSql('7005',VideoCardAdapterRamArrayFromDll[i],_VideoCardAdapterRam[i],'1','7');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'7005',VideoCardAdapterRamArrayFromDll[i],_VideoCardAdapterRam[i],'1','7');
               end;
            end;
            inc(i);
        end;

        LocalData.DeleteDataFromDll('VideoCard');
        LocalData.CreateRowDataTableInDll('VideoCard',4);
        SaveSystmVideoCardToDll;
        DeleteAgentInfoFromSql('prcDeleteVideoCardInfo');
        GetSystmVideoCardFromDll;
        SaveSystmVideoCardToSql;
       end;
     end;
end;

procedure TMyAgent.NewVideoCardInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
VideoCardHashCodeList : TStringList;
begin
VideoCardHashCodeList := TstringList.Create;
VideoCardHashCodeList := LocalData.GetListFromArray(_VideoCardHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := VideoCardHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('7006','',_VideoCardCaption[index],'1','7');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'7006','',_VideoCardCaption[index],'1','7');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewVideoCardCaptionInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('7006','',CList[i],'1','7');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'7006','',CList[i],'1','7');
   end;
   inc(i);
end;
end;

procedure TMyAgent.VideoCardCaptionUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('7007',CList[i],'','1','7');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'7007',CList[i],'','1','7');
   end;
   inc(i);
end;
end;


procedure TMyAgent.VideoCardUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
VideoCardHashCodesArrayFromDll: LocalData.TStringArray;
VideoCardCaptionArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
VideoCardHashCodesArrayFromDll := LocalData.HashCodesToArray('VideoCard');
VideoCardCaptionArrayFromDll := LocalData.GetDataArrayFromDll('VideoCard','Caption');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(VideoCardHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('7007',VideoCardCaptionArrayFromDll[index],'','1','7');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'7007',VideoCardCaptionArrayFromDll[index],'','1','7');
   end;

   inc(i);
end;
end;



procedure TMyAgent.FindCdRomDetailsChange;
var
CdRomHashCodesArrayFromDll,CdRomNameArrayFromDll: LocalData.TStringArray;
CdRomArrayFromDll : LocalData.TStringArray;
CdRomDriveArrayFromDll :LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     CdRomHashCodesArrayFromDll := LocalData.HashCodesToArray('CDROM');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(CdRomHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_CDRomHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewCDRomInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('CDROM');
         LocalData.CreateRowDataTableInDll('CDROM',32);
         SaveSystemCDRomToDll;
         DeleteAgentInfoFromSql('prcDeleteCDROMInfo');
         GetSystemCDRomFromDll;
         SaveSystemCDRomToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         CDRomUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('CDROM');
          LocalData.CreateRowDataTableInDll('CDROM',32);
         SaveSystemCDRomToDll;
         DeleteAgentInfoFromSql('prcDeleteCDROMInfo');
         GetSystemCDRomFromDll;
         SaveSystemCDRomToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        CdRomNameArrayFromDll := LocalData.GetDataArrayFromDll('CDROM','CdromName');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(CdRomNameArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_CdromName);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Cdrom
          NewCdromNameInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('CDROM');
          SaveSystemCDRomToDll;
          DeleteAgentInfoFromSql('prcDeleteCDROMInfo');
          GetSystemCDRomFromDll;
         SaveSystemCDRomToSql;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Cdrom
          CdromNameUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('CDROM');
           LocalData.CreateRowDataTableInDll('CDROM',32);
          SaveSystemCDRomToDll;
          DeleteAgentInfoFromSql('prcDeleteCDROMInfo');
          GetSystemCDRomFromDll;
         SaveSystemCDRomToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change Cdrom properties
        CdRomDriveArrayFromDll := LocalData.GetDataArrayFromDll('CDROM','CdromDrive');

        i:=0;
        while i <  Length(_CDRomDrive) do
        begin

            if _CDRomDrive[i] <> CdRomDriveArrayFromDll[i] then
            begin
               res := SaveEventToSql('15003',CdRomDriveArrayFromDll[i],_CDRomDrive[i],'1','15');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'15003',CdRomDriveArrayFromDll[i],_CDRomDrive[i],'1','15');
               end;
            end;

            inc(i);
        end;
        LocalData.DeleteDataFromDll('CDROM');
         LocalData.CreateRowDataTableInDll('CDROM',32);
        SaveSystemCDRomToDll;
        DeleteAgentInfoFromSql('prcDeleteCDROMInfo');
        GetSystemCDRomFromDll;
        SaveSystemCDRomToSql;
       end;
     end;
end;

procedure TMyAgent.NewCDRomInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
CDRomHashCodeList : TStringList;
begin
CDRomHashCodeList := TstringList.Create;
CDRomHashCodeList := LocalData.GetListFromArray(_CDRomHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := CDRomHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('15001','',_CDRomName[index],'1','15');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'15001','',_CDRomName[index],'1','15');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewCdromNameInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('15001','',CList[i],'1','15');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'15001','',CList[i],'1','15');
   end;
   inc(i);
end;
end;

procedure TMyAgent.CdromNameUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('15002',CList[i],'','1','15');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'15002',CList[i],'','1','15');
   end;
   inc(i);
end;
end;


procedure TMyAgent.CDRomUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
CDRomHashCodesArrayFromDll: LocalData.TStringArray;
CDRomNameArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
CDRomHashCodesArrayFromDll := LocalData.HashCodesToArray('CDROM');
CDRomNameArrayFromDll := LocalData.GetDataArrayFromDll('CDROM','CdromName');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(CDRomHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('15002',CDRomNameArrayFromDll[index],'','1','15');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'15002',CDRomNameArrayFromDll[index],'','1','15');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindModemsDetailsChange;
var
ModemsHashCodesArrayFromDll,ModemsNameArrayFromDll: LocalData.TStringArray;
ModemsArrayFromDll : LocalData.TStringArray;

CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     ModemsHashCodesArrayFromDll := LocalData.HashCodesToArray('Modem');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(ModemsHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_ModemHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewModemInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('Modem');
          LocalData.CreateRowDataTableInDll('Modem',32);
         SaveSystemModemToDll;
         DeleteAgentInfoFromSql('prcDeleteModemInfo');
         GetSystemModemFromDll;
         SaveSystemModemToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         ModemUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('Modem');
           LocalData.CreateRowDataTableInDll('Modem',32);
         SaveSystemModemToDll;
         DeleteAgentInfoFromSql('prcDeleteModemInfo');
         GetSystemModemFromDll;
         SaveSystemModemToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        ModemsNameArrayFromDll := LocalData.GetDataArrayFromDll('Modem','ModemName');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(ModemsNameArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_ModemModemName);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Modem
          NewModemNameInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('Modem');
            LocalData.CreateRowDataTableInDll('Modem',32);
          SaveSystemModemToDll;
          DeleteAgentInfoFromSql('prcDeleteModemInfo');
          GetSystemModemFromDll;
          SaveSystemModemToSql;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Modem
          ModemNameUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('Modem');
            LocalData.CreateRowDataTableInDll('Modem',32);
          SaveSystemModemToDll;
          DeleteAgentInfoFromSql('prcDeleteModemInfo');
          GetSystemModemFromDll;
         SaveSystemModemToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change Modem properties
        ModemsNameArrayFromDll := LocalData.GetDataArrayFromDll('Modem','ModemName');

        i:=0;
        while i <  Length(_ModemModemName) do
        begin

            if _ModemModemName[i] <> ModemsNameArrayFromDll[i] then
            begin
               res := SaveEventToSql('16001',ModemsNameArrayFromDll[i],_ModemModemName[i],'1','16');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'16001',ModemsNameArrayFromDll[i],_ModemModemName[i],'1','16');
               end;
            end;

            inc(i);
        end;
        LocalData.DeleteDataFromDll('Modem');
          LocalData.CreateRowDataTableInDll('Modem',32);
        SaveSystemModemToDll;
        DeleteAgentInfoFromSql('prcDeleteModemInfo');
        GetSystemModemFromDll;
        SaveSystemModemToSql;
       end;
     end;
end;

procedure TMyAgent.NewModemInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
ModemHashCodeList : TStringList;
begin
ModemHashCodeList := TstringList.Create;
ModemHashCodeList := LocalData.GetListFromArray(_ModemHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := ModemHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('16001','',_ModemModemName[index],'1','16');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'16001','',_ModemModemName[index],'1','16');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewModemNameInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('16001','',CList[i],'1','16');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'16001','',CList[i],'1','16');
   end;
   inc(i);
end;
end;

procedure TMyAgent.ModemNameUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('16002',CList[i],'','1','16');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'16002',CList[i],'','1','16');
   end;
   inc(i);
end;
end;


procedure TMyAgent.ModemUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
ModemHashCodesArrayFromDll: LocalData.TStringArray;
ModemNameArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
ModemHashCodesArrayFromDll := LocalData.HashCodesToArray('Modem');
ModemNameArrayFromDll := LocalData.GetDataArrayFromDll('Modem','ModemName');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(ModemHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('16002',ModemNameArrayFromDll[index],'','1','16');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'16002',ModemNameArrayFromDll[index],'','1','16');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindNetworkAdaptersDetailsChange;
var
NetworkAdapterHashCodesArrayFromDll,NetworkAdapterDescriptionArrayFromDll: LocalData.TStringArray;
NetworkAdapterArrayFromDll : LocalData.TStringArray;
NetworkAdapterAdapterTypeArrayFromDll :LocalData.TStringArray;
NetworkAdapterMACAddressArrayFromDll :LocalData.TStringArray;
NetworkAdapterManufacturerArrayFromDll :LocalData.TStringArray;
NetworkAdapterNetConnectionIDArrayFromDll :LocalData.TStringArray;
NetworkAdapterPNPDeviceIDArrayFromDll :LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     NetworkAdapterHashCodesArrayFromDll := LocalData.HashCodesToArray('NetworkAdapter');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(NetworkAdapterHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_NetworkAdapterHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewNetworkAdapterInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('NetworkAdapter');
         LocalData.CreateRowDataTableInDll('NetworkAdapter',32);
         SaveSystemNetworkAdapterToDll;
         DeleteAgentInfoFromSql('prcDeleteNetworkAdapterInfo');
         GetSystemNetworkAdapterFromDll;
         SaveSystemNetworkAdapterToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         NetworkAdapterUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('NetworkAdapter');
         LocalData.CreateRowDataTableInDll('NetworkAdapter',32);
         SaveSystemNetworkAdapterToDll;
         DeleteAgentInfoFromSql('prcDeleteNetworkAdapterInfo');
         GetSystemNetworkAdapterFromDll;
         SaveSystemNetworkAdapterToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        NetworkAdapterDescriptionArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','Description');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(NetworkAdapterDescriptionArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_NetworkAdapterDescription);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Network Adapter
          NewNetworkAdapterDescriptionInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('NetworkAdapter');
          LocalData.CreateRowDataTableInDll('NetworkAdapter',32);
          SaveSystemNetworkAdapterToDll;
          DeleteAgentInfoFromSql('prcDeleteNetworkAdapterInfo');
          GetSystemNetworkAdapterFromDll;
         SaveSystemNetworkAdapterToSql;
     end;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Network Adapter
          NetworkAdapterDescriptionUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('NetworkAdapter');
          LocalData.CreateRowDataTableInDll('NetworkAdapter',32);
          SaveSystemNetworkAdapterToDll;
          DeleteAgentInfoFromSql('prcDeleteNetworkAdapterInfo');
          GetSystemNetworkAdapterFromDll;
         SaveSystemNetworkAdapterToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change Network Adapter properties
        NetworkAdapterAdapterTypeArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','AdapterType');
        NetworkAdapterMACAddressArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','MACAddress');
        NetworkAdapterManufacturerArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','Manufacturer');
        NetworkAdapterNetConnectionIDArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','NetConnectionID');
        NetworkAdapterPNPDeviceIDArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','PNPDeviceID');

        i:= 0;
        while i <  Length(_NetworkAdapterAdapterType) do
        begin

            if _NetworkAdapterAdapterType[i] <> NetworkAdapterAdapterTypeArrayFromDll[i] then
            begin
               res := SaveEventToSql('8003',NetworkAdapterAdapterTypeArrayFromDll[i],_NetworkAdapterAdapterType[i],'1','8');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'8003',NetworkAdapterAdapterTypeArrayFromDll[i],_NetworkAdapterAdapterType[i],'1','8');
               end;
            end;

            if _NetworkAdapterMACAddress[i] <> NetworkAdapterMACAddressArrayFromDll[i] then
            begin
               res := SaveEventToSql('8004',NetworkAdapterMACAddressArrayFromDll[i],_NetworkAdapterMACAddress[i],'2','8');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'8004',NetworkAdapterMACAddressArrayFromDll[i],_NetworkAdapterMACAddress[i],'2','8');
               end;
            end;

            if _NetworkAdapterManufacturer[i] <> NetworkAdapterManufacturerArrayFromDll[i] then
            begin
               res := SaveEventToSql('8005',NetworkAdapterManufacturerArrayFromDll[i],_NetworkAdapterManufacturer[i],'1','8');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'8005',NetworkAdapterManufacturerArrayFromDll[i],_NetworkAdapterManufacturer[i],'1','8');
               end;
            end;

            if _NetworkAdapterNetConnectionID[i] <> NetworkAdapterNetConnectionIDArrayFromDll[i] then
            begin
               res := SaveEventToSql('8006',NetworkAdapterNetConnectionIDArrayFromDll[i],_NetworkAdapterNetConnectionID[i],'1','8');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'8006',NetworkAdapterNetConnectionIDArrayFromDll[i],_NetworkAdapterNetConnectionID[i],'1','8');
               end;
            end;

            if _NetworkAdapterPNPDeviceID[i] <> NetworkAdapterPNPDeviceIDArrayFromDll[i] then
            begin
               res := SaveEventToSql('8007',NetworkAdapterPNPDeviceIDArrayFromDll[i],_NetworkAdapterPNPDeviceID[i],'1','8');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'8007',NetworkAdapterPNPDeviceIDArrayFromDll[i],_NetworkAdapterPNPDeviceID[i],'1','8');
               end;
            end;
            inc(i);
        end;

        LocalData.DeleteDataFromDll('NetworkAdapter');
        LocalData.CreateRowDataTableInDll('NetworkAdapter',32);
          SaveSystemNetworkAdapterToDll;
          DeleteAgentInfoFromSql('prcDeleteNetworkAdapterInfo');
          GetSystemNetworkAdapterFromDll;
         SaveSystemNetworkAdapterToSql;
       end;
end;

procedure TMyAgent.NewNetworkAdapterInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
NetworkAdapterHashCodeList : TStringList;
begin
NetworkAdapterHashCodeList := TstringList.Create;
NetworkAdapterHashCodeList := LocalData.GetListFromArray(_NetworkAdapterHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := NetworkAdapterHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('8001','',_NetworkAdapterDescription[index],'1','8');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'8001','',_NetworkAdapterDescription[index],'1','8');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewNetworkAdapterDescriptionInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('8001','',CList[i],'1','8');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'8001','',CList[i],'1','8');
   end;
   inc(i);
end;
end;

procedure TMyAgent.NetworkAdapterDescriptionUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('8002',CList[i],'','1','8');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'8002',CList[i],'','1','8');
   end;
   inc(i);
end;
end;


procedure TMyAgent.NetworkAdapterUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
NetworkAdapterHashCodesArrayFromDll: LocalData.TStringArray;
NetworkAdapterDescriptionArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
NetworkAdapterHashCodesArrayFromDll := LocalData.HashCodesToArray('NetworkAdapter');
NetworkAdapterDescriptionArrayFromDll := LocalData.GetDataArrayFromDll('NetworkAdapter','Description');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(NetworkAdapterHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('8002',NetworkAdapterDescriptionArrayFromDll[index],'','1','8');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'8002',NetworkAdapterDescriptionArrayFromDll[index],'','1','8');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindPrintersDetailsChange;
var
PrinterHashCodesArrayFromDll,PrinterNameArrayFromDll: LocalData.TStringArray;

PrinterNetworkArrayFromDll :LocalData.TStringArray;

CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     PrinterHashCodesArrayFromDll := LocalData.HashCodesToArray('Printer');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(PrinterHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_PrinterHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewPrinterInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('Printer');
         LocalData.CreateRowDataTableInDll('Printer',32);
         SaveSystemPrinterToDll;
         DeleteAgentInfoFromSql('prcDeletePrinterInfo');
         GetSystemPrinterFromDll;
         SaveSystemPrinterToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         PrinterUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('Printer');
         LocalData.CreateRowDataTableInDll('Printer',32);
         SaveSystemPrinterToDll;
         DeleteAgentInfoFromSql('prcDeletePrinterInfo');
         GetSystemPrinterFromDll;
         SaveSystemPrinterToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        PrinterNameArrayFromDll := LocalData.GetDataArrayFromDll('Printer','PrinterName');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(PrinterNameArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromArray(_PrinterPrinterName);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Network Adapter
          NewPrinterNameInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('Printer');
          LocalData.CreateRowDataTableInDll('Printer',32);
          SaveSystemPrinterToDll;
          DeleteAgentInfoFromSql('prcDeletePrinterInfo');
          GetSystemPrinterFromDll;
          SaveSystemPrinterToSql;
     end;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Network Adapter
          PrinterNameUninstallEvent(CaptionDllList);
          LocalData.DeleteDataFromDll('Printer');
          LocalData.CreateRowDataTableInDll('Printer',32);
          SaveSystemPrinterToDll;
          DeleteAgentInfoFromSql('prcDeletePrinterInfo');
          GetSystemPrinterFromDll;
          SaveSystemPrinterToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change Network Adapter properties
        PrinterNetworkArrayFromDll := LocalData.GetDataArrayFromDll('Printer','Network');

        i:=0;
        while i <  Length(_PrinterNetwork) do
        begin

            if _PrinterNetwork[i] <> PrinterNetworkArrayFromDll[i] then
            begin
               res := SaveEventToSql('12003',PrinterNetworkArrayFromDll[i],_PrinterNetwork[i],'1','12');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'12003',PrinterNetworkArrayFromDll[i],_PrinterNetwork[i],'1','12');
               end;
            end;
            inc(i);
        end;

          LocalData.DeleteDataFromDll('Printer');
          LocalData.CreateRowDataTableInDll('Printer',32);
          SaveSystemPrinterToDll;
          DeleteAgentInfoFromSql('prcDeletePrinterInfo');
          GetSystemPrinterFromDll;
          SaveSystemPrinterToSql;
       end;
end;

procedure TMyAgent.NewPrinterInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
PrinterHashCodeList : TStringList;
begin
PrinterHashCodeList := TstringList.Create;
PrinterHashCodeList := LocalData.GetListFromArray(_PrinterHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := PrinterHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('12001','',_PrinterPrinterName[index],'1','12');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'12001','',_PrinterPrinterName[index],'1','12');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewPrinterNameInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('12001','',CList[i],'1','12');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'12001','',CList[i],'1','12');
   end;
   inc(i);
end;
end;

procedure TMyAgent.PrinterNameUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('12002',CList[i],'','1','12');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'12002',CList[i],'','1','12');
   end;
   inc(i);
end;
end;


procedure TMyAgent.PrinterUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
PrinterHashCodesArrayFromDll: LocalData.TStringArray;
PrinterNameArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
PrinterHashCodesArrayFromDll := LocalData.HashCodesToArray('Printer');
PrinterNameArrayFromDll := LocalData.GetDataArrayFromDll('Printer','PrinterName');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(PrinterHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('12002',PrinterNameArrayFromDll[index],'','1','12');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'12002',PrinterNameArrayFromDll[index],'','1','12');
   end;

   inc(i);
end;
end;


procedure TMyAgent.FindPublicDevicesChange;
var
res : integer;
Monitor,Keyboard,Mouse,Camera: string;
begin
Monitor :=  LocalData.GetDataFromDll('PublicDevices','Monitor','1');
Keyboard :=  LocalData.GetDataFromDll('PublicDevices','Keyboard','1');
Mouse :=  LocalData.GetDataFromDll('PublicDevices','Mouse','1');
Camera :=  LocalData.GetDataFromDll('PublicDevices','Camera','1');

if _PublicDevicesMonitor <> Monitor  then
begin
   res := SaveEventToSql('11000',_PublicDevicesMonitor,Monitor,'1','11');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'11000',_PublicDevicesMonitor,Monitor,'1','11');
   end;
end;
if _PublicDevicesKeyboard <> Keyboard  then
begin
   res := SaveEventToSql('9000',_PublicDevicesKeyboard,Keyboard,'1','9');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'9000',_PublicDevicesKeyboard,Keyboard,'1','9');
   end;
end;
if _PublicDevicesMouse <> Mouse  then
begin
   res := SaveEventToSql('10000',_PublicDevicesMouse,Mouse,'1','10');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'10000',_PublicDevicesMouse,Mouse,'1','10');
   end;
end;
if _PublicDevicesCamera <> Camera  then
begin
   res := SaveEventToSql('13000',_PublicDevicesCamera,Camera,'1','13');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'13000',_PublicDevicesCamera,Camera,'1','13');
   end;
end;
LocalData.DeleteDataFromDll('PublicDevices');
LocalData.CreateRowDataTableInDll('PublicDevices',1);
SaveSystemPublicDevicesToDll;
DeleteAgentInfoFromSql('prcDeletePublicDevicesInfo');
GetSystemPublicDevicesFromDll;
SaveSystemPublicDevicesToSql;
end;

procedure TMyAgent.FindUserAccountsChange;
var
UserAccountHashCodesArrayFromDll,UserAccountSIDArrayFromDll: LocalData.TStringArray;
UserAccountArrayFromDll : LocalData.TStringArray;
UserNameArrayFromDll,DescriptionArrayFromDll,StatusArrayFromDll : LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex,Res : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,SidDllList,SidCurrentList : TStringList;
i : integer;
begin

     UserAccountHashCodesArrayFromDll := LocalData.HashCodesToArray('UserAccount');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(UserAccountHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_UserAccountHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewAccountsInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('UserAccount');
         SaveSystemUserAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserAccountInfo');
         GetSystemUserAccountFromDll;
         SaveSystemUserAccountToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
        // delete items
         AccountsDeleteEvent(DllList);
         LocalData.DeleteDataFromDll('UserAccount');
         SaveSystemUserAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserAccountInfo');
         GetSystemUserAccountFromDll;
         SaveSystemUserAccountToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        UserAccountSIDArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','SID');
        SidDllList := TstringList.Create;
        SidDllList := LocalData.GetListFromArray(UserAccountSIDArrayFromDll);

        SidCurrentList := TstringList.Create;
        sidCurrentList := LocalData.GetListFromArray(_UserAccountSID);

        LocalData.CompareLists(SidCurrentList,SidDllList);

        if SidCurrentList.Count > 0 then
        begin
        // this is new accounts
          NewSIDAccountsInsertEvent(SidCurrentList);
          LocalData.DeleteDataFromDll('UserAccount');
          SaveSystemUserAccountToDll;
          DeleteAgentInfoFromSql('prcDeleteUserAccountInfo');
          GetSystemUserAccountFromDll;
          SaveSystemUserAccountToSql;

        end;
        if SidDllList.Count > 0 then
        begin
        // this is delete accounts
          AccountsSIDDeleteEvent(SidDllList);
          LocalData.DeleteDataFromDll('UserAccount');
          SaveSystemUserAccountToDll;
          DeleteAgentInfoFromSql('prcDeleteUserAccountInfo');
          GetSystemUserAccountFromDll;
          SaveSystemUserAccountToSql;
        end;
        if CurrentList.Count > SidCurrentList.Count then
        begin
          // this is change accounts
        UserNameArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','UserName');
        DescriptionArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','Description');
        StatusArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','Status');

        i:=0;
        while i <  Length(_UserAccountUserName) do
        begin

            if _UserAccountUserName[i] <> UserNameArrayFromDll[i] then
            begin
               res := SaveEventToSql('28003',UserNameArrayFromDll[i],_UserAccountUserName[i],'2','28');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'28003',UserNameArrayFromDll[i],_UserAccountUserName[i],'2','28');
               end;
            end;

            if _UserAccountDescription[i] <> DescriptionArrayFromDll[i] then
            begin
               res := SaveEventToSql('28004',DescriptionArrayFromDll[i],_UserAccountDescription[i],'1','28');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'28004',DescriptionArrayFromDll[i],_UserAccountDescription[i],'1','28');
               end;
            end;

            if _UserAccountStatus[i] <> StatusArrayFromDll[i] then
            begin
               res := SaveEventToSql('28005',StatusArrayFromDll[i],_UserAccountStatus[i],'1','28');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'28005',StatusArrayFromDll[i],_UserAccountStatus[i],'1','28');
               end;
            end;
           inc(i);
        end;

          LocalData.DeleteDataFromDll('UserAccount');
          SaveSystemUserAccountToDll;
          DeleteAgentInfoFromSql('prcDeleteUserAccountInfo');
          GetSystemUserAccountFromDll;
          GetSystemUserAccountFromDll;
          SaveSystemUserAccountToSql;

        end;
     end;

end;


procedure TMyAgent.NewAccountsInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
UserAccountHashCodeList : TStringList;
begin
UserAccountHashCodeList := TstringList.Create;
UserAccountHashCodeList := LocalData.GetListFromArray(_UserAccountHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := UserAccountHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('28001','',_UserAccountUserName[index],'2','28');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'28001','',_UserAccountUserName[index],'2','28');
   end;
   inc(i);
end;
end;

procedure TMyAgent.NewSIDAccountsInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
UserAccountSIDList : TStringList;
begin
UserAccountSIDList := TstringList.Create;
UserAccountSIDList := LocalData.GetListFromArray(_UserAccountSID);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := UserAccountSIDList.IndexOf(CList[i]);
   res := SaveEventToSql('28001','',_UserAccountUserName[index],'2','28');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'28001','',_UserAccountUserName[index],'2','28');
   end;
   inc(i);
end;
end;



procedure TMyAgent.AccountsDeleteEvent(DList:TStringList);
var
i,len,index,res : integer;
UserAccountHashCodesArrayFromDll: LocalData.TStringArray;
UserAccountNameArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
UserAccountHashCodesArrayFromDll := LocalData.HashCodesToArray('UserAccount');
UserAccountNameArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','UserName');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(UserAccountHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('28002',UserAccountNameArrayFromDll[index],'','2','28');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'28002',UserAccountNameArrayFromDll[index],'','2','28');
   end;
   inc(i);
end;
end;

procedure TMyAgent.AccountsSIDDeleteEvent(DList:TStringList);
var
i,len,index,res : integer;
UserAccountSIDList : TStringList;
UserAccountSIDArrayFromDll : LocalData.TStringArray;
UserAccountUsernameArrayFromDll : LocalData.TStringArray;
begin
UserAccountSIDArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','SID');
UserAccountUsernameArrayFromDll := LocalData.GetDataArrayFromDll('UserAccount','UserName');
UserAccountSIDList := TstringList.Create;
UserAccountSIDList := LocalData.GetListFromArray(UserAccountSIDArrayFromDll);
index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := UserAccountSIDList.IndexOf(DList[i]);
   res := SaveEventToSql('28002','',UserAccountUsernameArrayFromDll[index],'2','28');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'28002','',UserAccountUsernameArrayFromDll[index],'2','28');
   end;
   inc(i);
end;
end;


procedure TMyAgent.FindGroupAccountsChange;
var
GroupAccountHashCodesArrayFromDll,GroupAccountGIDArrayFromDll: LocalData.TStringArray;
GroupAccountArrayFromDll : LocalData.TStringArray;
GroupNameArrayFromDll,DescriptionArrayFromDll,StatusArrayFromDll : LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex,Res : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,SidDllList,SidCurrentList : TStringList;
i : integer;
begin

     GroupAccountHashCodesArrayFromDll := LocalData.HashCodesToArray('UserGroup');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(GroupAccountHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromArray(_GroupAccountHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewGroupAccountsInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('UserGroup');
         SaveSystemGroupAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserGroupInfo');
         GetSystemGroupAccountFromDll;
         SaveSystemGroupAccountToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
        // delete items
         GroupAccountsDeleteEvent(DllList);
         LocalData.DeleteDataFromDll('UserGroup');
         SaveSystemGroupAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserGroupInfo');
         GetSystemGroupAccountFromDll;
         SaveSystemGroupAccountToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        GroupAccountGIDArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','GID');
        SidDllList := TstringList.Create;
        SidDllList := LocalData.GetListFromArray(GroupAccountGIDArrayFromDll);

        SidCurrentList := TstringList.Create;
        sidCurrentList := LocalData.GetListFromArray(_GroupAccountGID);

        LocalData.CompareLists(SidCurrentList,SidDllList);

        if SidCurrentList.Count > 0 then
        begin
        // this is new accounts
          NewGIDGroupAccountsInsertEvent(SidCurrentList);
         LocalData.DeleteDataFromDll('UserGroup');
         SaveSystemGroupAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserGroupInfo');
         GetSystemGroupAccountFromDll;
         SaveSystemGroupAccountToSql;

        end;
        if SidDllList.Count > 0 then
        begin
        // this is delete accounts
          GroupAccountsGIDDeleteEvent(SidDllList);
         LocalData.DeleteDataFromDll('UserGroup');
         SaveSystemGroupAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserGroupInfo');
         GetSystemGroupAccountFromDll;
         SaveSystemGroupAccountToSql;
        end;
        if CurrentList.Count > SidCurrentList.Count then
        begin
          // this is change accounts
        GroupNameArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','GroupName');
        DescriptionArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','Description');
        StatusArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','Status');

        i:=0;
        while i <  Length(_GroupAccountGroupName) do
        begin

            if _GroupAccountGroupName[i] <> GroupNameArrayFromDll[i] then
            begin
               res := SaveEventToSql('29003',GroupNameArrayFromDll[i],_GroupAccountGroupName[i],'2','29');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'29003',GroupNameArrayFromDll[i],_GroupAccountGroupName[i],'2','29');
               end;
            end;

            if _GroupAccountDescription[i] <> DescriptionArrayFromDll[i] then
            begin
               res := SaveEventToSql('29004',DescriptionArrayFromDll[i],_GroupAccountDescription[i],'1','29');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'29004',DescriptionArrayFromDll[i],_GroupAccountDescription[i],'1','29');
               end;
            end;

            if _GroupAccountStatus[i] <> StatusArrayFromDll[i] then
            begin
               res := SaveEventToSql('29005',StatusArrayFromDll[i],_GroupAccountStatus[i],'1','29');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'29005',StatusArrayFromDll[i],_GroupAccountStatus[i],'1','29');
               end;
            end;
           inc(i);
        end;

         LocalData.DeleteDataFromDll('UserGroup');
         SaveSystemGroupAccountToDll;
         DeleteAgentInfoFromSql('prcDeleteUserGroupInfo');
         GetSystemGroupAccountFromDll;
         SaveSystemGroupAccountToSql;

        end;
     end;

end;


procedure TMyAgent.NewGroupAccountsInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
GroupAccountHashCodeList : TStringList;
begin
GroupAccountHashCodeList := TstringList.Create;
GroupAccountHashCodeList := LocalData.GetListFromArray(_GroupAccountHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := GroupAccountHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('29001','',_GroupAccountGroupName[index],'1','29');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'29001','',_GroupAccountGroupName[index],'1','29');
   end;
   inc(i);
end;
end;

procedure TMyAgent.NewGIDGroupAccountsInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
GroupAccountGIDList : TStringList;
begin
GroupAccountGIDList := TstringList.Create;
GroupAccountGIDList := LocalData.GetListFromArray(_GroupAccountGID);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := GroupAccountGIDList.IndexOf(CList[i]);
   res := SaveEventToSql('29001','',_GroupAccountGroupName[index],'1','29');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'29001','',_GroupAccountGroupName[index],'1','29');
   end;
   inc(i);
end;
end;



procedure TMyAgent.GroupAccountsDeleteEvent(DList:TStringList);
var
i,len,index,res : integer;
GroupAccountHashCodesArrayFromDll: LocalData.TStringArray;
GroupAccountNameArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
GroupAccountHashCodesArrayFromDll := LocalData.HashCodesToArray('UserGroup');
GroupAccountNameArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','GroupName');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(GroupAccountHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('29002',GroupAccountNameArrayFromDll[index],'','2','29');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'29002',GroupAccountNameArrayFromDll[index],'','2','29');
   end;
   inc(i);
end;
end;

procedure TMyAgent.GroupAccountsGIDDeleteEvent(DList:TStringList);
var
i,len,index,res : integer;
GroupAccountGIDList : TStringList;
GroupAccountGIDArrayFromDll : LocalData.TStringArray;
GroupAccountGroupnameArrayFromDll : LocalData.TStringArray;
begin
GroupAccountGIDArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','GID');
GroupAccountGroupnameArrayFromDll := LocalData.GetDataArrayFromDll('UserGroup','GroupName');
GroupAccountGIDList := TstringList.Create;
GroupAccountGIDList := LocalData.GetListFromArray(GroupAccountGIDArrayFromDll);
index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := GroupAccountGIDList.IndexOf(DList[i]);
   res := SaveEventToSql('29002','',GroupAccountGroupnameArrayFromDll[index],'2','29');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'29002','',GroupAccountGroupnameArrayFromDll[index],'2','29');
   end;
   inc(i);
end;
end;


procedure TMyAgent.FindActiveNetworkSettingChange;
var
ActiveNetworkHashCodesArrayFromDll,ActiveNetworkCaptionArrayFromDll: LocalData.TStringArray;
ActiveNetworkIpArrayFromDll :LocalData.TStringArray;
ActiveNetworkMACAddressArrayFromDll :LocalData.TStringArray;
ActiveNetworkGwArrayFromDll :LocalData.TStringArray;
ActiveNetworkSubnetArrayFromDll :LocalData.TStringArray;
ActiveNetworkDhcpAddressArrayFromDll :LocalData.TStringArray;
ActiveNetworkDhcpArrayFromDll :LocalData.TStringArray;
ActiveNetworkDnsAddressArrayFromDll :LocalData.TStringArray;
CurentArrayLength,DllArrayLength,loopIndex : integer;
_lastValue,_currentValue : string;
CurrentList,DllList,CaptionDllList,CaptionCurrentList : TStringList;
i,res : integer;
begin

     ActiveNetworkHashCodesArrayFromDll := LocalData.HashCodesToArray('ActiveNetworkSetting');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(ActiveNetworkHashCodesArrayFromDll);

     CurrentList := TstringList.Create;
     CurrentList := LocalData.GetListFromTNewstringArray(_ActiveNetworkSettingHashCode);


     LocalData.CompareLists(CurrentList,DllList);

     if (CurrentList.Count > 0) AND (DllList.Count = 0) then
     begin
         // new items
         NewActiveNetworkInsertEvent(CurrentList);
         LocalData.DeleteDataFromDll('ActiveNetworkSetting');
         LocalData.CreateRowDataTableInDll('ActiveNetworkSetting',32);
         SaveSystemActiveNetworkSettingToDll;
         DeleteAgentInfoFromSql('prcDeleteActiveNetworkInfo');
         GetSystemActiveNetworkSettingFromDll;
         SaveSystemActiveNetworkSettingToSql;

     end;

     if (CurrentList.Count = 0) AND (DllList.Count > 0) then
     begin
         ActiveNetworkUninstallEvent(DllList);
         LocalData.DeleteDataFromDll('ActiveNetworkSetting');
          LocalData.CreateRowDataTableInDll('ActiveNetworkSetting',32);
         SaveSystemActiveNetworkSettingToDll;
         DeleteAgentInfoFromSql('prcDeleteActiveNetworkInfo');
         GetSystemActiveNetworkSettingFromDll;
         SaveSystemActiveNetworkSettingToSql;
     end;

     if (CurrentList.Count > 0) AND (DllList.Count > 0) then
     begin
        // new or delete or change items
        ActiveNetworkCaptionArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','Caption');
        CaptionDllList := TstringList.Create;
        CaptionDllList := LocalData.GetListFromArray(ActiveNetworkCaptionArrayFromDll);

        CaptionCurrentList := TstringList.Create;
        CaptionCurrentList := LocalData.GetListFromTNewstringArray(_ActiveNetworkSettingCaption);

        LocalData.CompareLists(CaptionCurrentList,CaptionDllList);

        if CaptionCurrentList.Count > 0 then
        begin
        // this is new Network Adapter
          NewActiveNetworkCaptionInsertEvent(CaptionCurrentList);
          LocalData.DeleteDataFromDll('ActiveNetworkSetting');
           LocalData.CreateRowDataTableInDll('ActiveNetworkSetting',32);
         SaveSystemActiveNetworkSettingToDll;
         DeleteAgentInfoFromSql('prcDeleteActiveNetworkInfo');
         GetSystemActiveNetworkSettingFromDll;
         SaveSystemActiveNetworkSettingToSql;
     end;
        end;
        if CaptionDllList.Count > 0 then
        begin
        // this is delete Network Adapter
          ActiveNetworkCaptionUninstallEvent(CaptionDllList);
         LocalData.DeleteDataFromDll('ActiveNetworkSetting');
          LocalData.CreateRowDataTableInDll('ActiveNetworkSetting',32);
         SaveSystemActiveNetworkSettingToDll;
         DeleteAgentInfoFromSql('prcDeleteActiveNetworkInfo');
         GetSystemActiveNetworkSettingFromDll;
         SaveSystemActiveNetworkSettingToSql;
        end;
        if CurrentList.Count > CaptionCurrentList.Count then
        begin
         // this is change Network Adapter properties
        ActiveNetworkIpArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','IPAddress');
        ActiveNetworkMACAddressArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','MACAddress');
        ActiveNetworkGwArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','DefaultGateway');
        ActiveNetworkSubnetArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','SubnetMask');
        ActiveNetworkDhcpAddressArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','DHCPServer');
        ActiveNetworkDhcpArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','DHCPActive');
        ActiveNetworkDnsAddressArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','DNSServer');

        i:=0;
        while i <  Length(_ActiveNetworkSettingIPAddress) do
        begin

            if _ActiveNetworkSettingIPAddress[i] <> ActiveNetworkIpArrayFromDll[i] then
            begin
               res := SaveEventToSql('20000',ActiveNetworkIpArrayFromDll[i],_ActiveNetworkSettingIPAddress[i],'1','20');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'20000',ActiveNetworkIpArrayFromDll[i],_ActiveNetworkSettingIPAddress[i],'1','20');
               end;
            end;

            if _ActiveNetworkSettingSubnetMask[i] <> ActiveNetworkSubnetArrayFromDll[i] then
            begin
               res := SaveEventToSql('21000',ActiveNetworkSubnetArrayFromDll[i],_ActiveNetworkSettingSubnetMask[i],'2','21');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'21000',ActiveNetworkSubnetArrayFromDll[i],_ActiveNetworkSettingSubnetMask[i],'2','21');
               end;
            end;

            if _ActiveNetworkSettingDefaultGateway[i] <> ActiveNetworkGwArrayFromDll[i] then
            begin
               res := SaveEventToSql('22000',ActiveNetworkGwArrayFromDll[i],_ActiveNetworkSettingDefaultGateway[i],'2','22');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'22000',ActiveNetworkGwArrayFromDll[i],_ActiveNetworkSettingDefaultGateway[i],'2','22');
               end;
            end;

            if _ActiveNetworkSettingDNSServer[i] <> ActiveNetworkDnsAddressArrayFromDll[i] then
            begin
               res := SaveEventToSql('24000',ActiveNetworkDnsAddressArrayFromDll[i],_ActiveNetworkSettingDNSServer[i],'1','24');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'24000',ActiveNetworkDnsAddressArrayFromDll[i],_ActiveNetworkSettingDNSServer[i],'1','24');
               end;
            end;

            if _ActiveNetworkSettingDHCPActive[i] <> ActiveNetworkDhcpArrayFromDll[i] then
            begin
               res := SaveEventToSql('25001',ActiveNetworkDhcpArrayFromDll[i],_ActiveNetworkSettingDHCPActive[i],'1','25');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'25001',ActiveNetworkDhcpArrayFromDll[i],_ActiveNetworkSettingDHCPActive[i],'1','25');
               end;
            end;

             if _ActiveNetworkSettingDHCPServer[i] <> ActiveNetworkDhcpAddressArrayFromDll[i] then
            begin
               res := SaveEventToSql('25000',ActiveNetworkDhcpAddressArrayFromDll[i],_ActiveNetworkSettingDHCPServer[i],'1','25');
               if res = 0 then
               begin
                     //save to dll for send to sql later
                     LocalData.SaveEventInDll(_AgentId,'25000',ActiveNetworkDhcpAddressArrayFromDll[i],_ActiveNetworkSettingDHCPServer[i],'1','25');
               end;
            end;
            inc(i);
        end;

         LocalData.DeleteDataFromDll('ActiveNetworkSetting');
          LocalData.CreateRowDataTableInDll('ActiveNetworkSetting',32);
         SaveSystemActiveNetworkSettingToDll;
         DeleteAgentInfoFromSql('prcDeleteActiveNetworkInfo');
         GetSystemActiveNetworkSettingFromDll;
         SaveSystemActiveNetworkSettingToSql;
       end;
end;

procedure TMyAgent.NewActiveNetworkInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
NetworkAdapterHashCodeList : TStringList;
begin
NetworkAdapterHashCodeList := TstringList.Create;
NetworkAdapterHashCodeList := LocalData.GetListFromTNewstringArray(_ActiveNetworkSettingHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := NetworkAdapterHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('33000','',_ActiveNetworkSettingCaption[index],'2','33');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'33000','',_ActiveNetworkSettingCaption[index],'2','33');
   end;

   inc(i);
end;
end;

procedure TMyAgent.NewActiveNetworkCaptionInsertEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('33000','',CList[i],'1','33');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'33000','',CList[i],'1','33');
   end;
   inc(i);
end;
end;

procedure TMyAgent.ActiveNetworkCaptionUninstallEvent(CList:TStringList);
var
i,len,res : integer;

begin
i := 0;
len := CList.Count;
while i < len do
begin
   res := SaveEventToSql('33001',CList[i],'','2','33');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'33001',CList[i],'','2','33');
   end;
   inc(i);
end;
end;


procedure TMyAgent.ActiveNetworkUninstallEvent(DList:TStringList);
var
i,len,index,res : integer;
ActiveNetworkHashCodesArrayFromDll: LocalData.TStringArray;
ActiveNetworkCaptionArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
ActiveNetworkHashCodesArrayFromDll := LocalData.HashCodesToArray('ActiveNetworkSetting');
ActiveNetworkCaptionArrayFromDll := LocalData.GetDataArrayFromDll('ActiveNetworkSetting','Caption');
     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(ActiveNetworkHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('33001',ActiveNetworkCaptionArrayFromDll[index],'','1','33');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'33001',ActiveNetworkCaptionArrayFromDll[index],'','1','33');
   end;

   inc(i);
end;
end;



procedure TMyAgent.InstallNewMemoryInsertEvent(CList:TStringList);
var
i,len,index,res : integer;
MemoryHashCodeList : TStringList;
begin
MemoryHashCodeList := TstringList.Create;
MemoryHashCodeList := LocalData.GetListFromArray(_MemoryHashCode);
index := 0;
i := 0;
len := CList.Count;
while i < len do
begin
   index := MemoryHashCodeList.IndexOf(CList[i]);
   res := SaveEventToSql('4001','',_MemoryBankLabel[index],'1','4');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'4001','',_MemoryBankLabel[index],'1','4');
   end;

   inc(i);
end;

end;

procedure TMyAgent.UninstallMemoryEvent(DList:TStringList);
var
i,len,index,res : integer;
MemoryHashCodesArrayFromDll: LocalData.TStringArray;
DllList : TStringList;
begin
MemoryHashCodesArrayFromDll := LocalData.HashCodesToArray('Memory');

     DllList := TstringList.Create;
     DllList := LocalData.GetListFromArray(MemoryHashCodesArrayFromDll);


index := 0;
i := 0;
len := DList.Count;
while i < len do
begin
   index := DllList.IndexOf(DList[i]);
   res := SaveEventToSql('4002','Uninstall Bank'+intToStr(index),'','1','4');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'4002','Uninstall Bank'+intToStr(index),'','1','4');
   end;

   inc(i);
end;

end;

procedure TMyAgent.GetAgentSettingFromDll;
begin
  _SQLServerAddress := LocalData.GetDataFromDll('AgentSetting','SQLServerAddress','1');
  _SQLUsername := LocalData.GetDataFromDll('AgentSetting','SQLUsername','1');
  _SQLPassword := LocalData.GetDataFromDll('AgentSetting','SQLPassword','1');
  _SQLDatabaseName := LocalData.GetDataFromDll('AgentSetting','SQLDatabaseName','1');
  _AgentPassword := LocalData.GetDataFromDll('AgentSetting','AgentPassword','1');
  _RunOnce := LocalData.GetDataFromDll('AgentSetting','RunOnce','1');
  _IsRegister := LocalData.GetDataFromDll('AgentSetting','IsRegister','1');
  _SendAllToSql := LocalData.GetDataFromDll('AgentSetting','SendToSQL','1');
  _ControlSoftware := LocalData.GetDataFromDll('AgentSetting','ControlSoftware','1');
  _ControlHardware := LocalData.GetDataFromDll('AgentSetting','ControlHardware','1');
  _ControlNetwork := LocalData.GetDataFromDll('AgentSetting','ControlNetwork','1');
  _ControlAccounts := LocalData.GetDataFromDll('AgentSetting','ControlAccounts','1');
  _SendSMS := LocalData.GetDataFromDll('AgentSetting','SendSMS','1');
  _ChatPort := LocalData.GetDataFromDll('AgentSetting','ChatPort','1');
  _UDPPort := LocalData.GetDataFromDll('AgentSetting','UDPPort','1');
  _AdminMachineIPAddress := LocalData.GetDataFromDll('AgentSetting','AdminMachineIPAddress','1');
  _Version := LocalData.GetDataFromDll('AgentSetting','Version','1');
  _LanguageCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
  _RigthToLeft := LocalData.GetDataFromDll('AgentSetting','RigthToLeft','1');
  _StepNumber := LocalData.GetDataFromDll('AgentSetting','StepNumber','1');
  _ChatWithOther := LocalData.GetDataFromDll('AgentSetting','ChatWithOther','1') ;
  _FileTransferToOther := LocalData.GetDataFromDll('AgentSetting','FileTransferToOther','1') ;
  _VideoConfToOther := LocalData.GetDataFromDll('AgentSetting','VideoConfToOther','1') ;
  _ImageProccesing := LocalData.GetDataFromDll('AgentSetting','ImageProccesing','1') ;
  _LockIpAddress  := LocalData.GetDataFromDll('AgentSetting','LockIpAddress','1') ;
  _SendMail := LocalData.GetDataFromDll('AgentSetting','SendMail','1') ;
  _RemoteDesktopPort := LocalData.GetDataFromDll('AgentSetting','RemoteDesktopPort','1') ;
  _FileTransferPort :=  LocalData.GetDataFromDll('AgentSetting','FileTransferPort','1') ;

  _VideoConfPort :=  LocalData.GetDataFromDll('AgentSetting','VideoConfPort','1') ;
  _CMDPort :=  LocalData.GetDataFromDll('AgentSetting','CMDPort','1') ;
  _WebinarPort :=  LocalData.GetDataFromDll('AgentSetting','WebinarPort','1') ;
  _PublicPort :=  LocalData.GetDataFromDll('AgentSetting','PublicPort','1') ;
  _UsbAccessControl :=  LocalData.GetDataFromDll('AgentSetting','UsbAccessControl','1') ;
  _UsbDataControl :=  LocalData.GetDataFromDll('AgentSetting','UsbDataControl','1') ;
  _RegAccessControl :=  LocalData.GetDataFromDll('AgentSetting','RegAccessControl','1') ;
  _AppInstallDisable :=  LocalData.GetDataFromDll('AgentSetting','AppInstallDisable','1') ;
  _AppRunDisable :=  LocalData.GetDataFromDll('AgentSetting','AppRunDisable','1') ;
  _DisableCtrlAltDel :=  LocalData.GetDataFromDll('AgentSetting','DisableCtrlAltDel','1') ;
  _UpdateCounter :=  LocalData.GetDataFromDll('AgentSetting','UpdateCounter','1') ;
end;

procedure TMyAgent.SendEventFromDllToSql;
var
_eventsCount : integer;
AgId,EvID,EvDateTime,LastVal,CurrentVal,LevId,SubId : string;
begin
   _eventsCount := localData.GetRowCountWithCondition('EventOccur','SendTOSql = "0"');
   if _eventsCount > 0 then
   begin
   SendEventDllToSql(_eventsCount);

   end;
end;

procedure TMyAgent.SendAppRunsFromDllToSql;
var
_eventsCount : integer;
AgId,EvID,EvDateTime,LastVal,CurrentVal,LevId,SubId : string;
begin
   _eventsCount := localData.GetRowCountWithCondition('ApplicationRuns','SendToSql = "0"');
   if _eventsCount > 0 then
   begin
   SendAppRunsDllToSql(_eventsCount);

   end;
end;

procedure TMyAgent.StartUpEvent;
var
res : integer;
begin
res := SaveEventToSql('26001','Power On','','1','26');
   if res = 0 then
   begin
       //save to dll for send to sql later
       LocalData.SaveEventInDll(_AgentId,'26001','Power On','','1','26');
   end else
   begin
   UpdateAgentStatusInSql(_AgentId,_CurrentUser,'1','0');
   end;

end;


procedure TMyAgent.SendEventDllToSql(RowCount:integer);
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
  arraylen,i,R : integer;

 ConnString : string;
begin
  ConnString := LocalData.ConnS1 + LocalData.GetSysDir + LocalData.ConnsData;
  SQLStr := 'SELECT * FROM EventOccur WHERE SendTOSql = "0"' ;
  SetLength(Res,8);
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }




  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('AgentId').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('EventID').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('EventDateTime').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('LastValue').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('CurrentValue').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('LevelId').AsString);
  Res[6] := Trim(ADOQuery_FRTO.FieldByName('SubjectId').AsString);
  Res[7] := Trim(ADOQuery_FRTO.FieldByName('ID').AsString);
  R := SaveEvToSql(Res[0],Res[1],Res[2],Res[3],Res[4],Res[5],Res[6]);
  if R = 1  then LocalData.UpdateFieldToDll('EventOccur','SendTOSql','1','ID = '+ Res[7]);

  i := 1;
  while i < RowCount  do
  begin
     ADOQuery_FRTO.Next;
     Res[0] := Trim(ADOQuery_FRTO.FieldByName('AgentId').AsString);
     Res[1] := Trim(ADOQuery_FRTO.FieldByName('EventID').AsString);
     Res[2] := Trim(ADOQuery_FRTO.FieldByName('EventDateTime').AsString);
     Res[3] := Trim(ADOQuery_FRTO.FieldByName('LastValue').AsString);
     Res[4] := Trim(ADOQuery_FRTO.FieldByName('CurrentValue').AsString);
     Res[5] := Trim(ADOQuery_FRTO.FieldByName('LevelId').AsString);
     Res[6] := Trim(ADOQuery_FRTO.FieldByName('SubjectId').AsString);
     Res[7] := Trim(ADOQuery_FRTO.FieldByName('ID').AsString);
     R := SaveEvToSql(Res[0],Res[1],Res[2],Res[3],Res[4],Res[5],Res[6]);
     if R = 1  then LocalData.UpdateFieldToDll('EventOccur','SendTOSql','1','ID = '+ Res[7]);
     inc(i);
  end;

  ADOQuery_FRTO.Close;
  ADOConn.Close;
  except
  on E:Exception do
  begin
     exit;
  end;
  end;
end;

procedure TMyAgent.SendAppRunsDllToSql(RowCount:integer);
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
  arraylen,i,R2 : integer;

 ConnString : string;
begin
  ConnString := LocalData.ConnS1 + LocalData.GetSysDir + LocalData.ConnsData;
  SQLStr := 'SELECT * FROM ApplicationRuns WHERE SendToSql = "0"' ;
  SetLength(Res,5);
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }
  R2 := 0;
  try
  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }




  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('ApplicationTitle').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Action').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('ActionDate').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('ActionTime').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('Id').AsString);
  R2 := LocalData.SaveAppRunsFromDllToSql(_SQLServerAddress,_SQLDatabaseName,_SQLUsername,_SQLPassword,
                                  _AgentID,Res[0],Res[1],Res[2],Res[3]);
  if R2 = 1  then LocalData.UpdateFieldToDll('ApplicationRuns','SendToSql','1','Id = '+ Res[4]);

  i := 1;
  while i < RowCount  do
  begin
  ADOQuery_FRTO.Next;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('ApplicationTitle').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Action').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('ActionDate').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('ActionTime').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('Id').AsString);
     R2 := LocalData.SaveAppRunsFromDllToSql(_SQLServerAddress,_SQLDatabaseName,_SQLUsername,_SQLPassword,
                                  _AgentID,Res[0],Res[1],Res[2],Res[3]);
     if R2 = 1  then LocalData.UpdateFieldToDll('ApplicationRuns','SendToSql','1','Id = '+ Res[4]);
     inc(i);
  end;

  ADOQuery_FRTO.Close;
  ADOConn.Close;
  except
  on E:Exception do
  begin
     exit;
  end;
  end;
end;

function TMyAgent.SaveEvToSql(AgId:string;EvId:string;EvDateTime:string;LastVal:string;CurrentVal:string;LevId:string;SubId:string):integer;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
begin

  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertEvent';

  SetLength(ParName,8);
  SetLength(ParValue,8);

  ParName[0] := '@AgentID';
  ParValue[0] := AgId;

  ParName[1] := '@EventId';
  ParValue[1] := EvId;

  ParName[2] := '@EventDateTime';
  ParValue[2] := EvDateTime;

  ParName[3] := '@LastValue';
  ParValue[3] := LastVal;

  ParName[4] := '@CurrentValue';
  ParValue[4] := CurrentVal;

  ParName[5] := '@Shown';
  ParValue[5] := '0';

  ParName[6] := '@SubjectId';
  ParValue[6] := SubId;

  ParName[7] := '@LevelId';
  ParValue[7] := LevId;


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  Result := res;

end;



procedure TMyAgent.GetSystemInfo;
begin

  GetCPU.start;  { Grab CPU Informations }
  { Start Insert CPU Information to CPU Record}
  _CpuVendorid := GetCPU.vendorid;
  _CpuSteppingid := GetCPU.steppingid;
  _CpuModelnumber := GetCPU.modelnumber;
  _CpuFamilycode := GetCPU.familycode;
  _CpuProcessortype := GetCPU.processortype;
  _CpuExtendedModel := GetCPU.extendedModel;
  _CpuExtendedfamily := GetCPU.extendedfamily;
  _CpuBrandid := GetCPU.brandid;
  _CpuChunks := GetCPU.chunks;
  _CpuCount := GetCPU.count;
  _CpuAPICID  := GetCPU.APICID;
  _CpuSerialnumber := GetCPU.serialnumber;
  _CpuMMX := GetCPU.MMX;
  _CpuFXSAVE_FXRSTOR_Instructions := GetCPU.FXSAVE_FXRSTOR_Instructions;
  _CpuSSE := GetCPU.SSE;
  _CpuSSE2 := GetCPU.SSE2;
  _CpuExtendedCPUID := GetCPU.extendedCPUID;
  _CpuLargest_Function_Supported := GetCPU.Largest_Function_Supported;
  _CpuBrand_String := GetCPU.Brand_String;
  _CpuHashCode := GetCPU.HashCode;
  { End Insert CPU Information to CPU Record}


  GetMainboard.start; { Grab Mainboard Informations }
  { Start Insert Mainboard Information to Mainboard Record}
  _MainboardManufacter := GetMainboard.Manufacter;
  _MainboardProduct := GetMainboard.Product;
  _MainboardVersion := GetMainboard.Version;
  _MainboardSerialNumber := GetMainboard.SerialNumber;
  _MainboardHashCode := GetMainboard.HashCode;
  { End Insert Mainboard Information to Mainboard Record}


  GetBIOS.Start; { Grab BIOS Informations }
  { Start Insert BIOS Information to BIOS Record}

  _BiosVendor := GetBios.Vendor;
  _BiosStartSegment := GetBios.StartSegment;
  _BiosVersion := GetBios.Version;
  _BiosReleaseDate := GetBios.ReleaseDate;
  _BiosBiosRomSize := GetBios.BiosRomSize;
  _BiosHashCode := GetBios.HashCode;
  { End Insert BIOS Information to BIOS Record}


  GetSys.Start; { Grab UUID Informations }
   { Start Insert Sys Information to Sys Record}
  _SysUUID := GetSys._UUID;
  _SysHashCode := GetSys.HashCode;
   { End Insert Sys Information to Sys Record}


  GetChassis.Start; { Grab Chassis Informations }
  { Start Insert Chassis Information to Chassis Record}
  _ChassisAssetTagNumber := GetChassis.AssetTagNumber;
  _ChassisChassisType := GetChassis.ChassisType;
  _ChassisHashCode := GetChassis.HashCode;
  { End Insert Chassis Information to Chassis Record}


  GetOS.Start; { Grab OS Informations }
  { Start Insert OS Information to OS Record}
  _OsSerialNumber := GetOS.SerialNumber;
  _OsBuildNumber := GetOS.BuildNumber;
  _OsCaption := GetOS.Caption;
  _OsFreePhysicalMemory := GetOS.FreePhysicalMemory;
  _OsInstallDate := GetOS.InstallDate;
  _OsVersion := GetOS.Version;
  _OsLastBootUpTime := GetOS.LastBootupTime;
  _OsHashCode := GetOS.HashCode;
  { End Insert OS Information to OS Record}


  GetHardDisk.Start; { Grab Hard Disks Informations }
  { Start Insert Hard Disks Information to Hard Disks Record}
  _HardCaption := GetHardDisk.CaptionArray;
  _HardSignature := GetHardDisk.SignatureArray;
  _HardSize := GetHardDisk.HardSizeArray;
  _HardPartitions := GetHardDisk.PartitionsArray;
  _HardPNPDeviceID := GetHardDisk.PNPDeviceIDArray;
  _HardTotalHashCode := GetHardDisk.TotalHashCode;
  _HardHashCode := GetHardDisk.HashCode;
  { End Insert Hard Disks Information to Hard Disks Record}

   GetVideoCard.Start; { Grab Video Card Informations }
  { Start Insert Video Card Information to Video Card Record}
   _VideoCardCaption := GetVideoCard.Caption;
   _VideoCardDriverDate := GetVideoCard.DriverDate;
   _VideoCardDriverVersion := GetVideoCard.DriverVersion;
   _VideoCardVideoProcessor := GetVideoCard.VideoProcessor;
   _VideoCardVideoMode := GetVideoCard.VideoMode;
   _VideoCardAdapterRam := GetVideoCard.AdapterRam;
   _VideoCardTotalHashCode := GetVideoCard.TotalHashCode;
   _VideoCardHashCode := GetVideoCard.HashCode;
  { End Insert Video Card Information to Video Card Record}

    GetCDRom.Start; { Grab DVD/CD Rom Informations }
  { Start Insert DVD/CD Rom Information to DVD/CD Rom Record}
   _CDRomName := GetCDRom.Name;
   _CDRomDrive := GetCDRom.Drive;
   _CDRomTotalHashCode := GetCDRom.TotalHashCode;
   _CDRomHashCode := GetCDRom.HashCode;
   { End Insert DVD/CD Rom Information to DVD/CD Rom Record}

   GetLogicDisk.Start; { Grab Logic Disks Informations }
  { Start Insert  Logic Disks Information to  Logic Disks Record}
   _LogicDiskCaption := GetLogicDisk.Caption;
   _LogicDiskDescription := GetLogicDisk.Description;
   _LogicDiskFileSystem := GetLogicDisk.FileSystem;
   _LogicDiskVolumeSize := GetLogicDisk.VolumeSize;
   _LogicDiskFreeSpace := GetLogicDisk.FreeSpace;
   _LogicDiskVolumeName := GetLogicDisk.VolumeName;
   _LogicDiskVolumeSerialNumber := GetLogicDisk.VolumeSerialNumber;
   _LogicDiskHashCode := GetLogicDisk.HashCode;
   _LogicDiskTotalHashCode := GetLogicDisk.TotalHashCode;
  { End Insert  Logic Disks Information to  Logic Disks Record}


   GetMemory.Start; { Grab Memory Informations }
  { Start Insert  Memory Information to Memory Record}
   _MemoryBankLabel := GetMemory.BankLabel;
   _MemoryCapacity := GetMemory.Capacity;
   _MemorySpeed := GetMemory.Speed;
   _MemoryHashCode := GetMemory.HashCode;
   _MemoryTotalHashCode := GetMemory.TotalHashCode;
  { End Insert  Memory Information to  Memory Record}


   GetModem.Start; { Grab Modem Informations }
  { Start Insert  Modem Information to Modem Record}
   _ModemModemName := GetModem.ModemName;
   _ModemHashCode := GetModem.HashCode;
   _ModemTotalHashCode := GetModem.TotalHashCode;
  { End Insert  Modem Information to  Modem Record}

   GetNetworkAdapter.Start; { Grab Network Adapter Informations }
  { Start Insert  Network Adapter Information to  Network Adapter Record}
   _NetworkAdapterDescription := GetNetworkAdapter.Description;
   _NetworkAdapterAdapterType := GetNetworkAdapter.AdapterType;
   _NetworkAdapterMACAddress := GetNetworkAdapter.MACAddress;
   _NetworkAdapterManufacturer := GetNetworkAdapter.Manufacturer;
   _NetworkAdapterNetConnectionID := GetNetworkAdapter.NetConnectionID;
   _NetworkAdapterPNPDeviceID := GetNetworkAdapter.PNPDeviceID;
   _NetworkAdapterTimeOfLastReset := GetNetworkAdapter.TimeOfLastReset;
   _NetworkAdapterHashCode := GetNetworkAdapter.HashCode;
   _NetworkAdapterTotalHashCode := GetNetworkAdapter.TotalHashCode;
  { End Insert  Network Adapter Information to  Network Adapter Record}

   GetPrinter.Start; { Grab Printer Informations }
  { Start Insert  Printer Information to Printer Record}
   _PrinterPrinterName := GetPrinter.PrinterName;
   _PrinterNetwork := GetPrinter.Network;
   _PrinterHashCode := GetPrinter.HashCode;
   _PrinterTotalHashCode := GetPrinter.TotalHashCode;
  { End Insert  Printer Information to  Printer Record}

   GetPublicDevices.Start; { Grab Keyboard,Mouse,Monitor,Cammear Informations }
  { Start Insert  Public Devices Information to Public Devices Record}
   _PublicDevicesMonitor := GetPublicDevices.Monitor;
   _PublicDevicesKeyboard := GetPublicDevices.Keyboard;
   _PublicDevicesMouse := GetPublicDevices.Mouse;
   _PublicDevicesCamera := GetPublicDevices.Camera;
   _PublicDevicesHashCode := GetPublicDevices.HashCode;
   { End Insert  Public Devices Information to  Public Devices Record}


   GetSoftwares.Start; { Grab Installed Softwares Informations }
  { Start Insert  Installed Softwares Information to Softwares Record}
   _SoftwareName := GetSoftwares.SoftName;
   _SoftwareHashCode := GetSoftwares.HashCode;
  { End Insert  Installed Softwares Information to  Softwares Record}



  GetUserAccount.Start; { Grab User Account Informations }
  { Start Insert  User Account Information to User Account Record}
  _UserAccountUserName := GetUserAccount.UserName;
  _UserAccountSID := GetUserAccount.SID;
  _UserAccountDescription := GetUserAccount.Description;
  _UserAccountStatus := GetUserAccount.Status;
  _UserAccountHashCode := GetUserAccount.HashCode;
  _UserAccountTotalHashCode := GetUserAccount.TotalHashCode;
  { End Insert  User Account Information to  User Account Record}

  GetGroupAccount.Start; { Grab Group Account Informations }
  { Start Insert  Group Account Information to Group Account Record}
  _GroupAccountGroupName := GetGroupAccount.GroupName;
  _GroupAccountGID := GetGroupAccount.GID;
  _GroupAccountDescription := GetGroupAccount.Description;
  _GroupAccountStatus := GetGroupAccount.Status;
  _GroupAccountHashCode := GetGroupAccount.HashCode;
  _GroupAccountTotalHashCode := GetGroupAccount.TotalHashCode;
  { End Insert  Group Account Information to  Group Account Record}

   GetActiveNetworkSetting.Start; { Grab Active Network Setting Informations }
  { Start Insert  Active Network Setting Information to  Active Network Setting Record}
   _ActiveNetworkSettingCaption :=  GetActiveNetworkSetting.Caption;
   _ActiveNetworkSettingIPAddress := GetActiveNetworkSetting.IPAddress;
   _ActiveNetworkSettingSubnetMask := GetActiveNetworkSetting.SubnetMask;
   _ActiveNetworkSettingDefaultGateway := GetActiveNetworkSetting.DefaultGateway;
   _ActiveNetworkSettingDNSServer := GetActiveNetworkSetting.DNSServer;
   _ActiveNetworkSettingDHCPActive := GetActiveNetworkSetting.DHCPActive;
   _ActiveNetworkSettingDHCPServer := GetActiveNetworkSetting.DHCPServer;
   _ActiveNetworkSettingMACAddress := GetActiveNetworkSetting.MACAddress;
   _ActiveNetworkSettingHashCode := GetActiveNetworkSetting.HashCode;
   _ActiveNetworkSettingTotalHashCode := GetActiveNetworkSetting.TotalHashCode;
  { End Insert  Active Network Setting Information to  Active Network Setting Record}

  GetAgentProperties.Start; { Grab Agent Properties Informations }
  { Start Insert  Agent Properties Information to Agent Properties Record}
  _ComputerName := GetAgentProperties.ComputerName;
  _Organization  := GetAgentProperties.Organization;
  _CurrentUser := GetAgentProperties.CurrentUser;
  _RegisterCompany  := GetAgentProperties.RegisterCompany;
  _RegisterUser := GetAgentProperties.RegisterUser;
  _HashCode  := GetAgentProperties.HashCode;
  { End Insert  Agent Properties Information to  Agent Properties Record}
end;

procedure TMyAgent.GetSystemHashCode;
var
_systemString : string;
begin
    _systemString := HashCode + CpuHashCode + MainboardHashCode+
                     BiosHashCode+ChassisHashCode+OsHashCode+
                     SysHashCode+HardTotalHashCode+VideoCardTotalHashCode+
                     CDRomTotalHashCode+LogicDiskTotalHashCode+MemoryTotalHashCode+
                     ModemTotalHashCode+NetworkAdapterTotalHashCode+PrinterTotalHashCode+
                     PublicDevicesHashCode+SoftwareHashCode+UserAccountTotalHashCode+
                     GroupAccountTotalHashCode+ActiveNetworkSettingTotalHashCode;
  _SystemHashCode := LocalData.GetMD5String(_systemString,TEncoding.Unicode);
end;



procedure TMyAgent.SaveSystemAgentToDll;
var
_values : array[0..7] of string;
_result :integer;
begin
   _values[0] := ComputerName;
   _values[1] := Organization;
   _values[2] := CurrentUser;
   _values[3] := RegisterCompany;
   _values[4] := RegisterUser;
   _values[5] := OsLastBootUpTime;
   _values[6] := HashCode;
   _values[7] := SystemHashCode;
   _result := LocalData.SaveAgentToDll(_values);

end;

procedure  TMyAgent.SaveSystemCPUToDll;
var
_values : array[0..19] of string;
_result :integer;
begin
   _values[0] := CpuVendorid;
   _values[1] := CpuSteppingid;
   _values[2] := CpuModelnumber;
   _values[3] := CpuFamilycode;
   _values[4] := CpuProcessortype;
   _values[5] := CpuExtendedModel;
   _values[6] := CpuExtendedfamily;
   _values[7] := CpuBrandid;
   _values[8] := CpuChunks;
   _values[9] := CpuCount;
   _values[10] := CpuAPICID;
   _values[11] := CpuSerialnumber;
   _values[12] := CpuMMX;
   _values[13] := CpuFXSAVE_FXRSTOR_Instructions;
   _values[14] := CpuSSE;
   _values[15] := CpuSSE2;
   _values[16] := CpuExtendedCPUID;
   _values[17] := CpuLargest_Function_Supported;
   _values[18] := CpuBrand_String;
   _values[19] := CpuHashCode;


   _result := LocalData.SaveCPUToDll(_values);

end;

procedure TMyAgent.SaveSystemMainboardToDll;
var
_values : array[0..4] of string;
_result :integer;
begin
   _values[0] := MainboardManufacter;
   _values[1] := MainboardSerialNumber;
   _values[2] :=  MainboardProduct;
   _values[3] := MainboardVersion;
   _values[4] := MainboardHashCode;

   _result := LocalData.SaveMainboardToDll(_values);

end;

procedure TMyAgent.SaveSystemBiosToDll();
var
_values : array[0..5] of string;
_result :integer;
begin
   _values[0] := BiosVendor;
   _values[1] :=  BiosVersion;
   _values[2] :=  BiosStartSegment;
   _values[3] := BiosReleaseDate;
   _values[4] := BiosBiosRomSize;
   _values[5] := BiosHashCode;

   _result := LocalData.SaveBiosToDll(_values);

end;

procedure TMyAgent.SaveSystemChassisToDll;
var
_values : array[0..2] of string;
_result :integer;
begin
  ChassisAssetTagNumber := GetChassis.AssetTagNumber;
  ChassisChassisType := GetChassis.ChassisType;
  ChassisHashCode := GetChassis.HashCode;

   _values[0] := ChassisAssetTagNumber;
   _values[1] :=  ChassisChassisType;
   _values[2] :=  ChassisHashCode;

   _result := LocalData.SaveChassisToDll(_values);

end;

procedure TMyAgent.SaveSystemOSToDll;
var
_values : array[0..6] of string;
_result :integer;
begin
   _values[0] := OSSerialNumber;
   _values[1] := OSBuildNumber;
   _values[2] := OSCaption;
   _values[3] := OSFreePhysicalMemory;
   _values[4] := OSInstallDate;
   _values[5] := OSVersion;
   _values[6] := OSHashCode;

   _result := LocalData.SaveOSToDll(_values);

end;

procedure TMyAgent.SaveSystemSysToDll;
var
_values : array[0..1] of string;
_result :integer;
begin
   _values[0] := SysUUID;
   _values[1] := SysHashCode;

   _result := LocalData.SaveSysToDll(_values);

end;

procedure TMyAgent.SaveSystemHardDisksToDll;
var
_hashCode : string;
_values : array[0..5] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := HardCaption;
   _values[1] := HardSignature;
   _values[2] := HardSize;
   _values[3] := HardPartitions;
   _values[4] := HardPNPDeviceID;
   _values[5] := HardHashCode;
   _hashCode := HardTotalHashCode;

   _result := LocalData.SaveHardDisksToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystmVideoCardToDll;
var
_hashCode : string;
_values : array[0..6] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := VideoCardCaption;
   _values[1] := VideoCardDriverDate;
   _values[2] := VideoCardDriverVersion;
   _values[3] := VideoCardVideoProcessor;
   _values[4] := VideoCardVideoMode;
   _values[5] := VideoCardAdapterRam;
   _values[6] := VideoCardHashCode;
   _hashCode := VideoCardTotalHashCode;

   _result := LocalData.SaveVideoCardToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemCDRomToDll;
var
_hashCode : string;
_values : array[0..2] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := CDRomName;
   _values[1] := CDRomDrive;
   _values[2] := CDRomHashCode;
   _hashCode := CDRomTotalHashCode;

   _result := LocalData.SaveCDRomToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemLogicDiskToDll;
var
_hashCode : string;
_values : array[0..7] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := LogicDiskCaption;
   _values[1] := LogicDiskDescription;
   _values[2] := LogicDiskFileSystem;
   _values[3] := LogicDiskVolumeSize;
   _values[4] := LogicDiskFreeSpace;
   _values[5] := LogicDiskVolumeName;
   _values[6] := LogicDiskVolumeSerialNumber;
   _values[7] := LogicDiskHashCode;
   _hashCode := LogicDiskTotalHashCode;

   _result := LocalData.SaveLogicDiskToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemMemoryToDll;
var
_hashCode : string;
_values : array[0..3] of LocalData.TStringArray;
_result :integer;
begin

  _values[0] := MemoryBankLabel;

  _values[1] := MemoryCapacity;

  _values[2] := MemorySpeed;

  _values[3] := MemoryHashCode;

  _hashCode := MemoryTotalHashCode;

   _result := LocalData.SaveMemoryToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemModemToDll;
var
_hashCode : string;
_values :  array[0..1] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := ModemModemName;
   _values[1] := ModemHashCode;
   _hashCode := ModemTotalHashCode;

   _result := LocalData.SaveModemToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemNetworkAdapterToDll;
var
_hashCode : string;
_values : array[0..7] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := NetworkAdapterDescription;
   _values[1] := NetworkAdapterAdapterType;
   _values[2] := NetworkAdapterMACAddress;
   _values[3] := NetworkAdapterManufacturer;
   _values[4] := NetworkAdapterNetConnectionID;
   _values[5] := NetworkAdapterPNPDeviceID;
   _values[6] := NetworkAdapterTimeOfLastReset;
   _values[7] := NetworkAdapterHashCode;
   _hashCode := NetworkAdapterTotalHashCode;

   _result := LocalData.SaveNetworkAdapterToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemPrinterToDll;
var
_hashCode : string;
_values : array[0..2] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := PrinterPrinterName;
   _values[1] := PrinterNetwork;
   _values[2] := PrinterHashCode;
   _hashCode := PrinterTotalHashCode;

   _result := LocalData.SavePrinterToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemPublicDevicesToDll;
var
_values : array[0..4] of string;
_result :integer;
begin
   _values[0] := PublicDevicesMonitor;
   _values[1] := PublicDevicesKeyboard;
   _values[2] := PublicDevicesMouse;
   _values[3] := PublicDevicesCamera;
   _values[4] := PublicDevicesHashCode;

   _result := LocalData.SavePublicDevicesToDll(_values);

end;

procedure TMyAgent.SaveSystemSoftwareToDll;
var
_hashCode : string;
_values : array of string;
_result,len,i :integer;
begin
   len := length(SoftwareName);
   setlength(_values,len);
   i := 0;
   while i < len do
   begin
      _values[i] :=  SoftwareName[i];
      inc(i);
   end;

   _hashCode := SoftwareHashCode;

   _result := LocalData.FirstSaveSoftwareToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemUserAccountToDll;
var
_hashCode : string;
_values : array[0..4] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := UserAccountUserName;
   _values[1] := UserAccountSID;
   _values[2] := UserAccountDescription;
   _values[3] := UserAccountStatus;
   _values[4] := UserAccountHashCode;
   _hashCode := UserAccountTotalHashCode;

   _result := LocalData.FirstSaveUserAccountToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemGroupAccountToDll;
var
_hashCode : string;
_values : array[0..4] of LocalData.TStringArray;
_result :integer;
begin
   _values[0] := GroupAccountGroupName;
   _values[1] := GroupAccountGID;
   _values[2] := GroupAccountDescription;
   _values[3] := GroupAccountStatus;
   _values[4] := GroupAccountHashCode;
   _hashCode := GroupAccountTotalHashCode;

   _result := LocalData.FirstSaveGroupNameToDll(_values,_hashcode);

end;

procedure TMyAgent.SaveSystemActiveNetworkSettingToDll;
var
_hashCode : string;
_values : array[0..8] of GetActiveNetworkSetting.TNewStringArray;
_result :integer;
begin
   _values[0] := ActiveNetworkSettingCaption;
   _values[1] := ActiveNetworkSettingIPAddress;
   _values[2] := ActiveNetworkSettingSubnetMask;
   _values[3] := ActiveNetworkSettingDefaultGateway;
   _values[4] := ActiveNetworkSettingDNSServer;
   _values[5] := ActiveNetworkSettingDHCPActive;
   _values[6] := ActiveNetworkSettingDHCPServer;
   _values[7] := ActiveNetworkSettingMACAddress;
   _values[8] := ActiveNetworkSettingHashCode;
   _hashCode := ActiveNetworkSettingTotalHashCode;

   _result := LocalData.SaveActiveNetworkSettingToDll(_values,_hashcode);

end;


procedure TMyAgent.SaveSystemInfoToDll();
begin
   SaveSystemAgentToDll;
   SaveSystemCPUToDll;
   SaveSystemMainboardToDll;
   SaveSystemBiosToDll;
   SaveSystemChassisToDll;
   SaveSystemOSToDll;
   SaveSystemSysToDll;
   SaveSystemHardDisksToDll;
   SaveSystmVideoCardToDll;
   SaveSystemCDRomToDll;
   SaveSystemLogicDiskToDll;
   SaveSystemMemoryToDll;
   SaveSystemModemToDll;
   SaveSystemNetworkAdapterToDll;
   SaveSystemPrinterToDll;
   SaveSystemPublicDevicesToDll;
   SaveSystemSoftwareToDll;
   SaveSystemUserAccountToDll;
   SaveSystemGroupAccountToDll;
   SaveSystemActiveNetworkSettingToDll;


end;

procedure TMyAgent.GetAllPropertiesFromDll;
begin
   GetSystemAgentFromDll;
   GetSystemCPUFromDll;
   GetSystemMainboardFromDll;
   GetSystemBiosFromDll;
   GetSystemChassisFromDll;
   GetSystemOSFromDll;
   GetSystemSysFromDll;
   GetSystemHardDisksFromDll;
   GetSystmVideoCardFromDll;
   GetSystemCDRomFromDll;
   GetSystemLogicDiskFromDll;
   GetSystemMemoryFromDll;
   GetSystemModemFromDll;
   GetSystemNetworkAdapterFromDll;
   GetSystemPrinterFromDll;
   GetSystemPublicDevicesFromDll;
   GetSystemSoftwareFromDll;
   GetSystemUserAccountFromDll;
   GetSystemGroupAccountFromDll;
   GetSystemActiveNetworkSettingFromDll;


end;

procedure TMyAgent.SaveAllPropertiesToSql;
begin
     if _SendToSql = '0' Then SaveSystemAgentToSql;
     if _CpuSendToSql = '0' Then SaveSystemCPUToSql;
     if _MainboardSendToSql = '0' Then SaveSystemMainboardToSql;
     if _BiosSendToSql = '0' Then SaveSystemBiosToSql;
     if _ChassisSendToSql = '0' Then SaveSystemChassisToSql;
     if _OSSendToSql = '0' Then SaveSystemOSFromToSql;
     SaveSystemHardDisksToSql;
     SaveSystmVideoCardToSql;
     SaveSystemCDRomToSql;
     SaveSystemLogicDiskToSql;
     SaveSystemMemoryToSql;
     SaveSystemModemToSql;
     SaveSystemNetworkAdapterToSql;
     SaveSystemPrinterToSql;
     if _PublicDevicesSendToSql = '0' Then SaveSystemPublicDevicesToSql;
     SaveSystemSoftwareToSql;
     SaveSystemUserAccountToSql;
     SaveSystemGroupAccountToSql;
     SaveSystemActiveNetworkSettingToSql;
end;

procedure TMyAgent.GetSystemAgentFromDll;
begin
    _AgentID := LocalData.GetDataFromDll('AgentDetails','AgentID','1');
    _ComputerName := LocalData.GetDataFromDll('AgentDetails','ComputerName','1');
    _Organization := LocalData.GetDataFromDll('AgentDetails','Organization','1');
    _CurrentUser := LocalData.GetDataFromDll('AgentDetails','CurrentUser','1');
    _RegisterCompany := LocalData.GetDataFromDll('AgentDetails','RegisterCompany','1');
    _RegisterUser := LocalData.GetDataFromDll('AgentDetails','RegisterUser','1');
    _LastBootupTime := LocalData.GetDataFromDll('AgentDetails','LastBootupTime','1');
    _AgentFingerPrint := LocalData.GetDataFromDll('AgentDetails','SystemFootprint','1');
    _SendToSql := LocalData.GetDataFromDll('AgentDetails','SendToSql','1');
    _HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','10');
    _SystemHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','1');

end;

procedure TMyAgent.GetSystemCPUFromDll;
begin
     _CpuVendorid := LocalData.GetDataFromDll('Processors','VendorID','1');
     _CpuSteppingid := LocalData.GetDataFromDll('Processors','SteppingID','1');
     _CpuModelnumber := LocalData.GetDataFromDll('Processors','ModelNumber','1');
     _CpuFamilycode := LocalData.GetDataFromDll('Processors','FamilyCode','1');
     _CpuProcessortype := LocalData.GetDataFromDll('Processors','ProcessorType','1');;
     _CpuExtendedModel:= LocalData.GetDataFromDll('Processors','ExtendedModel','1');
     _CpuExtendedfamily:= LocalData.GetDataFromDll('Processors','ExtendedFamily','1');
     _CpuBrandid := LocalData.GetDataFromDll('Processors','BrandID','1');
     _CpuChunks := LocalData.GetDataFromDll('Processors','Chunks','1');
     _CpuCount := LocalData.GetDataFromDll('Processors','Counts','1');
     _CpuAPICID := LocalData.GetDataFromDll('Processors','APICID','1');
     _CpuSerialnumber:= LocalData.GetDataFromDll('Processors','SerialNumber','1');
     _CpuMMX := LocalData.GetDataFromDll('Processors','MMX','1');
     _CpuFXSAVE_FXRSTOR_Instructions := LocalData.GetDataFromDll('Processors','FxsaveFxrstorInstructions','1');
     _CpuSSE := LocalData.GetDataFromDll('Processors','SSE','1');
     _CpuSSE2:= LocalData.GetDataFromDll('Processors','SSE2','1');
     _CpuExtendedCPUID := LocalData.GetDataFromDll('Processors','ExtendedCPUID','1');
     _CpuLargest_Function_Supported := LocalData.GetDataFromDll('Processors','LargestFunctionSupported','1');
     _CpuBrand_String := LocalData.GetDataFromDll('Processors','Brand','1');
     _CpuSendToSql := LocalData.GetDataFromDll('Processors','SendToSql','1');
     _CpuHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','2');

end;

procedure TMyAgent.GetSystemMainboardFromDll;
begin
    _MainboardManufacter := LocalData.GetDataFromDll('Motherboard','Manufacturer','1');
    _MainboardProduct := LocalData.GetDataFromDll('Motherboard','Product','1');
    _MainboardVersion := LocalData.GetDataFromDll('Motherboard','Version','1');
    _MainboardSerialNumber := LocalData.GetDataFromDll('Motherboard','SerialNumber','1');
    _MainboardSendToSql := LocalData.GetDataFromDll('Motherboard','SendToSql','1');
    _MainboardHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','3');

end;

procedure TMyAgent.GetSystemBiosFromDll;
begin
   _BiosVendor := LocalData.GetDataFromDll('BIOS','Vendor','1');
   _BiosStartSegment := LocalData.GetDataFromDll('BIOS','StartSegment','1');
   _BiosVersion := LocalData.GetDataFromDll('BIOS','Version','1');
   _BiosReleaseDate := LocalData.GetDataFromDll('BIOS','ReleaseDate','1');
   _BiosBiosRomSize := LocalData.GetDataFromDll('BIOS','BiosRomSize','1');
   _BiosSendToSql := LocalData.GetDataFromDll('BIOS','SendToSql','1');
   _BiosHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','4');

end;

procedure TMyAgent.GetSystemChassisFromDll;
begin
   _ChassisAssetTagNumber := LocalData.GetDataFromDll('Chassis','AssetTagNumber','1');
   _ChassisChassisType := LocalData.GetDataFromDll('Chassis','ChassisType','1');
   _ChassisSendToSql := LocalData.GetDataFromDll('Chassis','SendToSql','1');
   _ChassisHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','9');

end;

procedure TMyAgent.GetSystemOSFromDll;
begin
   _OsSerialNumber := LocalData.GetDataFromDll('OperatingSystem','SerialNumber','1');
   _OsBuildNumber := LocalData.GetDataFromDll('OperatingSystem','BuildNumber','1');
   _OsCaption := LocalData.GetDataFromDll('OperatingSystem','Caption','1');
   _OsFreePhysicalMemory := LocalData.GetDataFromDll('OperatingSystem','FreePhysicalMemory','1');
   _OsInstallDate := LocalData.GetDataFromDll('OperatingSystem','InstallDate','1');
   _OsVersion := LocalData.GetDataFromDll('OperatingSystem','Version','1');
   _OsLastBootUpTime := LocalData.GetDataFromDll('AgentDetails','LastBootupTime','1');
   _OsSendToSql := LocalData.GetDataFromDll('OperatingSystem','SendToSql','1');
   _OsHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','11');

end;

procedure TMyAgent.GetSystemSysFromDll;
begin
   _SysUUID := LocalData.GetDataFromDll('Sys','UUID','1');
   _SysSendToSql := LocalData.GetDataFromDll('Sys','SendToSql','1');
   _SysHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','12');

end;

procedure TMyAgent.GetSystemHardDisksFromDll;
begin
  _HardCaption := LocalData.GetDataArrayFromDll('HardDisk','Caption');
  _HardSignature := LocalData.GetDataArrayFromDll('HardDisk','Signature');
  _HardSize  := LocalData.GetDataArrayFromDll('HardDisk','HardSize');
  _HardPartitions := LocalData.GetDataArrayFromDll('HardDisk','Partitions');
  _HardPNPDeviceID := LocalData.GetDataArrayFromDll('HardDisk','PNPDeviceID');
  _HardSendToSql := LocalData.GetDataArrayFromDll('HardDisk','SendToSql');
  _HardHashCode := LocalData.GetDataArrayFromDll('HardDisk','HashCode');
  _HardTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','6');
end;

procedure TMyAgent.GetSystmVideoCardFromDll;
begin
  _VideoCardCaption := LocalData.GetDataArrayFromDll('VideoCard','Caption');
  _VideoCardDriverDate := LocalData.GetDataArrayFromDll('VideoCard','DriverDate');
  _VideoCardDriverVersion  := LocalData.GetDataArrayFromDll('VideoCard','DriverVersion');
  _VideoCardVideoProcessor := LocalData.GetDataArrayFromDll('VideoCard','VideoProcessor');
  _VideoCardVideoMode := LocalData.GetDataArrayFromDll('VideoCard','VideoMode');
  _VideoCardAdapterRam := LocalData.GetDataArrayFromDll('VideoCard','AdapterRam');
  _VideoCardSendToSql := LocalData.GetDataArrayFromDll('VideoCard','SendToSql');
  _VideoCardHashCode := LocalData.GetDataArrayFromDll('VideoCard','HashCode');
  _VideoCardTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','13');


end;

procedure TMyAgent.GetSystemCDRomFromDll;
begin
  _CDRomName := LocalData.GetDataArrayFromDll('CDROM','CdromName');
  _CDRomDrive := LocalData.GetDataArrayFromDll('CDROM','CdromDrive');
  _CDRomSendToSql := LocalData.GetDataArrayFromDll('CDROM','SendToSql');
  _CDRomHashCode := LocalData.GetDataArrayFromDll('CDROM','HashCode');
  _CDRomTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','14');
end;

procedure TMyAgent.GetSystemLogicDiskFromDll;
begin
     _LogicDiskCaption := LocalData.GetDataArrayFromDll('LogicDisk','Caption');
     _LogicDiskDescription := LocalData.GetDataArrayFromDll('LogicDisk','Description');
     _LogicDiskFileSystem  := LocalData.GetDataArrayFromDll('LogicDisk','FileSystem');
     _LogicDiskVolumeSize := LocalData.GetDataArrayFromDll('LogicDisk','VolumeSize');
     _LogicDiskFreeSpace := LocalData.GetDataArrayFromDll('LogicDisk','FreeSpace');
     _LogicDiskVolumeName := LocalData.GetDataArrayFromDll('LogicDisk','VolumeName');
     _LogicDiskVolumeSerialNumber := LocalData.GetDataArrayFromDll('LogicDisk','VolumeSerialNumber');
     _LogicDiskSendToSql := LocalData.GetDataArrayFromDll('LogicDisk','SendToSql');
     _LogicDiskHashCode := LocalData.GetDataArrayFromDll('LogicDisk','HashCode');
     _LogicDiskTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','7');

end;

procedure TMyAgent.GetSystemMemoryFromDll;
begin
  _MemoryBankLabel := LocalData.GetDataArrayFromDll('Memory','BankLabel');
  _MemoryCapacity := LocalData.GetDataArrayFromDll('Memory','Capacity');
  _MemorySpeed  := LocalData.GetDataArrayFromDll('Memory','Speed');
  _MemorySendToSql := LocalData.GetDataArrayFromDll('Memory','SendToSql');
  _MemoryHashCode := LocalData.GetDataArrayFromDll('Memory','HashCode');
  _MemoryTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','5');

end;

procedure TMyAgent.GetSystemModemFromDll;
begin
  _ModemModemName := LocalData.GetDataArrayFromDll('Modem','ModemName');
  _ModemHashCode := LocalData.GetDataArrayFromDll('Modem','HashCode');
  _ModemSendToSql := LocalData.GetDataArrayFromDll('Modem','SendToSql');
  _ModemTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','15');

end;

procedure TMyAgent.GetSystemNetworkAdapterFromDll;
begin
  _NetworkAdapterDescription := LocalData.GetDataArrayFromDll('NetworkAdapter','Description');
  _NetworkAdapterAdapterType := LocalData.GetDataArrayFromDll('NetworkAdapter','AdapterType');
  _NetworkAdapterMACAddress  := LocalData.GetDataArrayFromDll('NetworkAdapter','MACAddress');
  _NetworkAdapterManufacturer := LocalData.GetDataArrayFromDll('NetworkAdapter','Manufacturer');
  _NetworkAdapterNetConnectionID := LocalData.GetDataArrayFromDll('NetworkAdapter','NetConnectionID');
  _NetworkAdapterPNPDeviceID := LocalData.GetDataArrayFromDll('NetworkAdapter','PNPDeviceID');
  _NetworkAdapterTimeOfLastReset := LocalData.GetDataArrayFromDll('NetworkAdapter','TimeOfLastReset');
  _NetworkAdapterSendToSql := LocalData.GetDataArrayFromDll('NetworkAdapter','SendToSql');
  _NetworkAdapterHashCode := LocalData.GetDataArrayFromDll('NetworkAdapter','HashCode');
  _NetworkAdapterTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','16');

end;

procedure TMyAgent.GetSystemPrinterFromDll;
begin
     _PrinterPrinterName := LocalData.GetDataArrayFromDll('Printer','PrinterName');
     _PrinterNetwork := LocalData.GetDataArrayFromDll('Printer','Network');
     _PrinterSendToSql := LocalData.GetDataArrayFromDll('Printer','SendToSql');
     _PrinterHashCode := LocalData.GetDataArrayFromDll('Printer','HashCode');
     _PrinterTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','17');
end;

procedure TMyAgent.GetSystemPublicDevicesFromDll;
begin
     _PublicDevicesMonitor := LocalData.GetDataFromDll('PublicDevices','Monitor','1');
     _PublicDevicesKeyboard := LocalData.GetDataFromDll('PublicDevices','Keyboard','1');
     _PublicDevicesMouse  := LocalData.GetDataFromDll('PublicDevices','Mouse','1');
     _PublicDevicesCamera := LocalData.GetDataFromDll('PublicDevices','Camera','1');
     _PublicDevicesSendToSql := LocalData.GetDataFromDll('PublicDevices','SendToSql','1');
     _PublicDevicesHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','18');

end;

procedure TMyAgent.GetSystemSoftwareFromDll;
begin
     _SoftwareName := LocalData.GetSoftwaresFromDll;
     _SoftwareSendToSql := LocalData.GetDataArrayFromDll('Software','SendToSql');
     _SoftwareHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','8');
end;

procedure TMyAgent.GetSystemUserAccountFromDll;
begin
  _UserAccountUserName := LocalData.GetDataArrayFromDll('UserAccount','UserName');
  _UserAccountSID := LocalData.GetDataArrayFromDll('UserAccount','SID');
  _UserAccountDescription  := LocalData.GetDataArrayFromDll('UserAccount','Description');
  _UserAccountStatus := LocalData.GetDataArrayFromDll('UserAccount','Status');
  _UserAccountSendToSql := LocalData.GetDataArrayFromDll('UserAccount','SendToSql');
  _UserAccountHashCode := LocalData.GetDataArrayFromDll('UserAccount','HashCode');
  _UserAccountTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','19');
end;

procedure TMyAgent.GetSystemGroupAccountFromDll;
begin
  _GroupAccountGroupName := LocalData.GetDataArrayFromDll('UserGroup','GroupName');
  _GroupAccountGID := LocalData.GetDataArrayFromDll('UserGroup','GID');
  _GroupAccountDescription  := LocalData.GetDataArrayFromDll('UserGroup','Description');
  _GroupAccountStatus := LocalData.GetDataArrayFromDll('UserGroup','Status');
  _GroupAccountSendToSql := LocalData.GetDataArrayFromDll('UserGroup','SendToSql');
  _GroupAccountHashCode := LocalData.GetDataArrayFromDll('UserGroup','HashCode');
  _GroupAccountTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','20');

end;

procedure TMyAgent.GetSystemActiveNetworkSettingFromDll;
begin
  _ActiveNetworkSettingCaption := LocalData.GetActiveNetworkArrayFromDll('Caption');
  _ActiveNetworkSettingIPAddress := LocalData.GetActiveNetworkArrayFromDll('IPAddress');
  _ActiveNetworkSettingSubnetMask := LocalData.GetActiveNetworkArrayFromDll('SubnetMask');
  _ActiveNetworkSettingDefaultGateway  := LocalData.GetActiveNetworkArrayFromDll('DefaultGateway');
  _ActiveNetworkSettingDNSServer := LocalData.GetActiveNetworkArrayFromDll('DNSServer');
  _ActiveNetworkSettingDHCPActive := LocalData.GetActiveNetworkArrayFromDll('DHCPActive');
  _ActiveNetworkSettingDHCPServer := LocalData.GetActiveNetworkArrayFromDll('DHCPServer');
  _ActiveNetworkSettingMACAddress := LocalData.GetActiveNetworkArrayFromDll('MACAddress');
  _ActiveNetworkSettingSendToSql := LocalData.GetActiveNetworkArrayFromDll('SendToSql');
  _ActiveNetworkSettingHashCode := LocalData.GetActiveNetworkArrayFromDll('HashCode');
  _ActiveNetworkSettingTotalHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','21');

end;



function TMyAgent.SaveEventToSql(EventId:string;LastValue:string;CurrentValue:string;LevelId:string;SubjectId:string):integer;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
Date_Time : string;
begin
  Date_Time := LocalData.ConvertToday;
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

try

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertEvent';

  SetLength(ParName,8);
  SetLength(ParValue,8);

  ParName[0] := '@AgentID';
  ParValue[0] := _AgentId;

  ParName[1] := '@EventId';
  ParValue[1] := EventId;

  ParName[2] := '@EventDateTime';
  ParValue[2] := Date_Time;

  ParName[3] := '@LastValue';
  ParValue[3] := LastValue;

  ParName[4] := '@CurrentValue';
  ParValue[4] := CurrentValue;

  ParName[5] := '@Shown';
  ParValue[5] := '0';

  ParName[6] := '@SubjectId';
  ParValue[6] := SubjectId;

  ParName[7] := '@LevelId';
  ParValue[7] := LevelId;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  Result := res;
except
  Result := 0;
end;
end;



procedure TMyAgent.SaveSystemStatusToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertNowStatus';

  SetLength(ParName,4);
  SetLength(ParValue,4);

  ParName[0] := '@AgentID';
  ParValue[0] := _AgentId;

  ParName[1] := '@CurrentLogin';
  ParValue[1] := _CurrentUser;

  ParName[2] := '@StartupDuration';
  ParValue[2] := _LastBootupTime;

  ParName[3] := '@NowStatus';
  ParValue[3] := '1';


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('AgentDetails','SendToSql','1','ID = 1');

end;

procedure TMyAgent.UpdateAgentStatusInSql(AgentID:string;CurrentUser:string;
                Status:string;IdleDuration:string);
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcUpdateAgentNowStatus';

  SetLength(ParName,5);
  SetLength(ParValue,5);

  ParName[0] := '@AgentID';
  ParValue[0] := _AgentID;

  ParName[1] := '@CurrentLogin';
  ParValue[1] := _CurrentUser;

  ParName[2] := '@StartupDuration';
  ParValue[2] := _OsLastBootUpTime;

  ParName[3] := '@NowStatus';
  ParValue[3] := Status;

  ParName[4] := '@IdleDuration';
  ParValue[4] := IdleDuration;


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('AgentDetails','SendToSql','1','ID = 1');

end;

procedure TMyAgent.SaveSystemAgentToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertAgentDetails';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@ComputerName';
  ParValue[1] := _ComputerName;

  ParName[2] := '@Organization';
  ParValue[2] := _Organization;

  ParName[3] := '@RegisterCompany';
  ParValue[3] := _RegisterCompany;

  ParName[4] := '@RegisterUser';
  ParValue[4] := _RegisterUser;

  ParName[5] := '@Uuid';
  ParValue[5] := _SysUUID;

  ParName[6] := '@LastUpdate';
  ParValue[6] := _LastBootupTime;


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('AgentDetails','SendToSql','1','ID = 1');

end;

procedure TMyAgent.DeleteAgentInfoFromSql(SpName:string);
var
MySql : SQLAccess;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.DeleteAgentInfo(_AgentId,SpName);

end;


procedure TMyAgent.SaveSystemCPUToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertProcessors';

  SetLength(ParName,20);
  SetLength(ParValue,20);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@VendorId';
  ParValue[1] := _CpuVendorId;

  ParName[2] := '@SteppingId';
  ParValue[2] := _CpuSteppingId;

  ParName[3] := '@ModelNumber';
  ParValue[3] := _CpuModelNumber;

  ParName[4] := '@FamilyCode';
  ParValue[4] := _CpuFamilyCode;

  ParName[5] := '@ProcessorType';
  ParValue[5] := _CpuProcessorType;

  ParName[6] := '@ExtendedModel';
  ParValue[6] := _CpuExtendedModel;

   ParName[7] := '@ExtendedFamily';
  ParValue[7] := _CpuExtendedFamily;

  ParName[8] := '@BrandId';
  ParValue[8] := _CpuBrandId;

  ParName[9] := '@Counts';
  ParValue[9] := _CpuCount;

  ParName[10] := '@Chunks';
  ParValue[10] := _CpuChunks;

  ParName[11] := '@Mmx';
  ParValue[11] := _CpuMmx;

  ParName[12] := '@ApicId';
  ParValue[12] := _CpuApicId;

   ParName[13] := '@SerialNumber';
  ParValue[13] := _CpuSerialNumber;

  ParName[14] := '@FxSaveFxStorinStructions';
  ParValue[14] := _CpuFXSAVE_FXRSTOR_Instructions;

  ParName[15] := '@Sse';
  ParValue[15] := _CpuSse;

  ParName[16] := '@Sse2';
  ParValue[16] := _CpuSse2;

  ParName[17] := '@LargestFunctionSupported';
  ParValue[17] := _CpuLargest_Function_Supported;

  ParName[18] := '@Brand';
  ParValue[18] := _CpuBrand_String;

  ParName[19] := '@LastUpdateDate';
  ParValue[19] := lastUpDate;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('Processors','SendToSql','1','ID = 1');

end;

procedure TMyAgent.SaveSystemMainboardToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertMotherboard';

  SetLength(ParName,6);
  SetLength(ParValue,6);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@Manufacturer';
  ParValue[1] := _MainboardManufacter;

  ParName[2] := '@SerialNumber';
  ParValue[2] := _MainboardSerialNumber;

  ParName[3] := '@Product';
  ParValue[3] := _MainboardProduct;

  ParName[4] := '@Vesrion';
  ParValue[4] := _MainboardVersion;

  ParName[5] := '@LastUpdateDate';
  ParValue[5] := lastUpDate;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('Motherboard','SendToSql','1','ID = 1');


end;

procedure TMyAgent.SaveSystemBiosToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertBios';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@Vendor';
  ParValue[1] := _BiosVendor;

  ParName[2] := '@Version';
  ParValue[2] := _BiosVersion;

  ParName[3] := '@StartSegment';
  ParValue[3] := _BiosStartSegment;

  ParName[4] := '@ReleasDate';
  ParValue[4] := _BiosReleaseDate;

  ParName[5] := '@BiosRomSize';
  ParValue[5] := _BiosBiosRomSize;

  ParName[6] := '@LastUpdateDate';
  ParValue[6] := lastUpDate;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('BIOS','SendToSql','1','ID = 1');


end;

procedure TMyAgent.SaveSystemChassisToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertChassis';

  SetLength(ParName,4);
  SetLength(ParValue,4);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@AssetTagNumber';
  ParValue[1] := _ChassisAssetTagNumber;

  ParName[2] := '@ChassisType';
  ParValue[2] := _ChassisChassisType;

  ParName[3] := '@LastUpdateDate';
  ParValue[3] := lastUpDate;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('Chassis','SendToSql','1','ID = 1');


end;

procedure TMyAgent.SaveSystemOSFromToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertOperatingSystem';

  SetLength(ParName,8);
  SetLength(ParValue,8);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@SerialNumber';
  ParValue[1] := _OsSerialNumber;

  ParName[2] := '@BuildNumber';
  ParValue[2] := _OsBuildNumber;

  ParName[3] := '@Caption';
  ParValue[3] := _OsCaption;

  ParName[4] := '@FreePhysicalMemory';
  ParValue[4] := _OsFreePhysicalMemory;

  ParName[5] := '@InstallDate';
  ParValue[5] := _OsInstallDate;

  ParName[6] := '@Versions';
  ParValue[6] := _OsVersion;

  ParName[7] := '@LastUpdate';
  ParValue[7] := lastUpDate;

  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 1  then LocalData.UpdateFieldToDll('OperatingSystem','SendToSql','1','ID = 1');


end;

procedure TMyAgent.SaveSystemHardDisksToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertHardDisk';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_HardCaption);
  index := 0;

  while index < len do
  begin
    if _HardSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@Caption';
    ParValue[1] := _HardCaption[index];

    ParName[2] := '@Signature';
    ParValue[2] := _HardSignature[index];

    ParName[3] := '@HardSize';
    ParValue[3] := _HardSize[index];

    ParName[4] := '@Partitiones';
    ParValue[4] := _HardPartitions[index];

    ParName[5] := '@PNPDevice';
    ParValue[5] := _HardPNPDeviceID[index];

    ParName[6] := '@LastUpdateDate';
    ParValue[6] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);

    if res = 1  then LocalData.UpdateFieldToDll('HardDisk','SendToSql','1','ID = '+IntToStr(index+1));

    end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystmVideoCardToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertVideoCard';

  SetLength(ParName,8);
  SetLength(ParValue,8);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_VideoCardCaption);
  index := 0;

  while index < len do
  begin
    if _VideoCardSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@Caption';
    ParValue[1] := _VideoCardCaption[index];

    ParName[2] := '@DriverDate';
    ParValue[2] := _VideoCardDriverDate[index];

    ParName[3] := '@DriverVersion';
    ParValue[3] := _VideoCardDriverVersion[index];

    ParName[4] := '@VideoProcessor';
    ParValue[4] := _VideoCardVideoProcessor[index];

    ParName[5] := '@VideoMode';
    ParValue[5] := _VideoCardVideoMode[index];

    ParName[6] := '@AdapterRam';
    ParValue[6] := _VideoCardAdapterRam[index];

    ParName[7] := '@LastUpdateDate';
    ParValue[7] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);

    if res = 1  then LocalData.UpdateFieldToDll('VideoCard','SendToSql','1','ID = '+IntToStr(index+1));

    end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemCDRomToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  SetLength(ParName,4);
  SetLength(ParValue,4);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_CDRomName);
  index := 0;


  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  while index < len do
  begin
    if _CDRomSendToSql[index] = '0' then
    begin
    MySql := SQLAccess.Create(_SQLConnString);
    MySql.StoredProcedureName := 'prcInsertCdrom';




    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@CdRomName';
    ParValue[1] := _CDRomName[index];

    ParName[2] := '@CdRomDrive';
    ParValue[2] := _CDRomDrive[index];

    ParName[3] := '@LastUpdateDate';
    ParValue[3] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('CDROM','SendToSql','1','ID = '+IntToStr(index+1));

    MySql.Free;
    end;

     inc(index);
  end;

end;

procedure TMyAgent.SaveSystemLogicDiskToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertLogicDisk';

  SetLength(ParName,9);
  SetLength(ParValue,9);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_LogicDiskCaption);
  index := 0;

  while index < len do
  begin
    if _LogicDiskSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@Caption';
    ParValue[1] := _LogicDiskCaption[index];

    ParName[2] := '@Description';
    ParValue[2] := _LogicDiskDescription[index];

    ParName[3] := '@FileSystem';
    ParValue[3] := _LogicDiskFileSystem[index];

    ParName[4] := '@VolumeSize';
    ParValue[4] := _LogicDiskVolumeSize[index];

    ParName[5] := '@FreeSpace';
    ParValue[5] := _LogicDiskFreeSpace[index];

    ParName[6] := '@VolumeName';
    ParValue[6] := _LogicDiskVolumeName[index];

    ParName[7] := '@VolumeSerialNumber';
    ParValue[7] := _LogicDiskVolumeSerialNumber[index];

    ParName[8] := '@LastUpdateDate';
    ParValue[8] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('LogicDisk','SendToSql','1','ID = '+IntToStr(index+1));

    end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemMemoryToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertMemory';

  SetLength(ParName,5);
  SetLength(ParValue,5);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_MemoryBankLabel);
  index := 0;

  while index < len do
  begin
    if _MemorySendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@BankLabel';
    ParValue[1] := _MemoryBankLabel[index];

    ParName[2] := '@Capacity';
    ParValue[2] := _MemoryCapacity[index];

    ParName[3] := '@Speed';
    ParValue[3] := _MemorySpeed[index];

    ParName[4] := '@LastUpdateDate';
    ParValue[4] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('Memory','SendToSql','1','ID = '+IntToStr(index+1));

    end;

     inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemModemToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertModem';

  SetLength(ParName,3);
  SetLength(ParValue,3);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_ModemModemName);
  index := 0;

  while index < len do
  begin
    if _ModemSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@ModemName';
    ParValue[1] := _ModemModemName[index];

    ParName[2] := '@LastUpdateDate';
    ParValue[2] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('Modem','SendToSql','1','ID = '+IntToStr(index+1));

    end;

     inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemNetworkAdapterToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertNetworkAdapter';

  SetLength(ParName,9);
  SetLength(ParValue,9);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_NetworkAdapterDescription);
  index := 0;

  while index < len do
  begin
    if _NetworkAdapterSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@Description';
    ParValue[1] := _NetworkAdapterDescription[index];

    ParName[2] := '@AdapterType';
    ParValue[2] := _NetworkAdapterAdapterType[index];

    ParName[3] := '@MacAddress';
    ParValue[3] := _NetworkAdapterMACAddress[index];

    ParName[4] := '@Manufacturer';
    ParValue[4] := _NetworkAdapterManufacturer[index];

    ParName[5] := '@Netconnectionid';
    ParValue[5] := _NetworkAdapterNetConnectionID[index];

    ParName[6] := '@PnpDeviceId';
    ParValue[6] := _NetworkAdapterPNPDeviceID[index];

    ParName[7] := '@TimeOfLastReset';
    ParValue[7] := _NetworkAdapterTimeOfLastReset[index];

    ParName[8] := '@LastUpdateDate';
    ParValue[8] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('NetworkAdapter','SendToSql','1','ID = '+IntToStr(index+1));

    end;

     inc(index);
  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemPrinterToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertPrinter';

  SetLength(ParName,4);
  SetLength(ParValue,4);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_PrinterPrinterName);
  index := 0;

  while index < len do
  begin
    if _PrinterSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@PrinterName';
    ParValue[1] := _PrinterPrinterName[index];

    ParName[2] := '@Network';
    if _PrinterNetwork[index] = 'True' then  ParValue[2] := 'Network'
    else if _PrinterNetwork[index] = 'False' then ParValue[2] := 'Local';


    ParName[3] := '@LastUpdateDate';
    ParValue[3] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



   if res = 1  then LocalData.UpdateFieldToDll('Printer','SendToSql','1','ID = '+IntToStr(index+1));

   end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemPublicDevicesToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertPublicDevices';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  ParName[0] := '@AgentId';
  ParValue[0] := _AgentId;

  ParName[1] := '@Monitor';
  ParValue[1] := _PublicDevicesMonitor;

  ParName[2] := '@Keyboard';
  ParValue[2] := _PublicDevicesKeyboard;

  ParName[3] := '@Mouse';
  ParValue[3] := _PublicDevicesMouse;

  ParName[4] := '@Scanner';
  ParValue[4] := ' ';

  ParName[5] := '@Camera';
  ParValue[5] := _PublicDevicesCamera;

  ParName[6] := '@LastUpdateDate';
  ParValue[6] := _LastBootupTime;


  res := MySql.IntExcuteSP(ParName,ParValue);

  if res = 1  then LocalData.UpdateFieldToDll('PublicDevices','SendToSql','1','ID = 1');


  MySql.Free;

end;

procedure TMyAgent.SaveSystemSoftwareToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertSoftwares';

  SetLength(ParName,3);
  SetLength(ParValue,3);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_SoftwareName);
  index := 0;

  while index < len do
  begin
    if _SoftwareSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@SoftwareName';
    ParValue[1] := _SoftwareName[index];

    ParName[2] := '@LastUpdateDate';
    ParValue[2] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('Software','SendToSql','1','SoftwareName = "'+ParValue[1]+'"');

    end;

     inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemUserAccountToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;

begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertUserAccount';

  SetLength(ParName,5);
  SetLength(ParValue,5);

  len := length(_UserAccountUserName);
  index := 0;

  while index < len do
  begin
    if _UserAccountSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@UserName';
    ParValue[1] := _UserAccountUserName[index];

    ParName[2] := '@Sids';
    ParValue[2] := _UserAccountSID[index];

    ParName[3] := '@Descriptions';
    ParValue[3] := _UserAccountDescription[index];

    ParName[4] := '@Statuss';
    ParValue[4] := _UserAccountStatus[index];


    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('UserAccount','SendToSql','1','SID = "'+ParValue[2]+'"');

    end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemGroupAccountToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;

begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertUserGroups';

  SetLength(ParName,5);
  SetLength(ParValue,5);

  len := length(_GroupAccountGroupName);
  index := 0;

  while index < len do
  begin
    if _GroupAccountSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@GroupName';
    ParValue[1] := _GroupAccountGroupName[index];

    ParName[2] := '@Sids';
    ParValue[2] := _GroupAccountGID[index];

    ParName[3] := '@Description';
    ParValue[3] := _GroupAccountDescription[index];

    ParName[4] := '@Status';
    ParValue[4] := _GroupAccountStatus[index];

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('UserGroup','SendToSql','1','GID = "'+ParValue[2]+'"');

    end;

    inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.SaveSystemActiveNetworkSettingToSql;
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res,index,len : integer;
today : TDateTime;
lastUpDate : string;
begin
  _SQLConnString := 'Provider=SQLOLEDB;Data Source='+Trim(_SQLServerAddress)+
                    ';Initial Catalog='+Trim(_SQLDatabaseName)+
                    ';User Id='+Trim(_SQLUsername)+
                    ';Password='+Trim(_SQLPassword);

  MySql := SQLAccess.Create(_SQLConnString);
  MySql.StoredProcedureName := 'prcInsertActiveNetworkSetting';

  SetLength(ParName,10);
  SetLength(ParValue,10);

  today := Now;
  lastUpDate := DateToStr(today)+' '+TimeToStr(today);

  len := length(_ActiveNetworkSettingCaption);
  index := 0;

  while index < len do
  begin
    if _ActiveNetworkSettingSendToSql[index] = '0' then
    begin
    ParName[0] := '@AgentId';
    ParValue[0] := _AgentId;

    ParName[1] := '@Caption';
    ParValue[1] := _ActiveNetworkSettingCaption[index];

    ParName[2] := '@IPAddress';
    ParValue[2] := _ActiveNetworkSettingIPAddress[index];

    ParName[3] := '@SubnetMask';
    ParValue[3] := _ActiveNetworkSettingSubnetMask[index];

    ParName[4] := '@DefaultGateway';
    ParValue[4] := _ActiveNetworkSettingDefaultGateway[index];

    ParName[5] := '@DNSServer';
    ParValue[5] := _ActiveNetworkSettingDNSServer[index];

    ParName[6] := '@DHCPActive';
    ParValue[6] := _ActiveNetworkSettingDHCPActive[index];

    ParName[7] := '@DHCPServer';
    ParValue[7] := _ActiveNetworkSettingDHCPServer[index];

    ParName[8] := '@MACAddress';
    ParValue[8] := _ActiveNetworkSettingMACAddress[index];

    ParName[9] := '@LastUpdateDate';
    ParValue[9] := lastUpDate;

    res := MySql.IntExcuteSP(ParName,ParValue);



    if res = 1  then LocalData.UpdateFieldToDll('ActiveNetworkSetting','SendToSql','1','ID = '+IntToStr(index+1));

    end;

     inc(index);

  end;

  MySql.Free;

end;

procedure TMyAgent.GetHashCodesFromDll;
begin
   _Dll_Total_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','1');
   _Dll_CPU_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','2');
   _Dll_Mainboard_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','3');
   _Dll_Bios_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','4');
   _Dll_TotalMemory_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','5');
   _Dll_TotalHardDisks_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','6');
   _Dll_TotalLogicHards_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','7');
   _Dll_TotalSoftwares_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','8');
   _Dll_Chassis_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','9');
   _Dll_AgentProperties_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','10');
   _Dll_OS_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','11');
   _Dll_Sys_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','12');
   _Dll_TotalVideoCards_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','13');
   _Dll_TotalCdRom_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','14');
   _Dll_TotalModems_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','15');
   _Dll_TotalNetworkAdapters_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','16');
   _Dll_TotalPrinters_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','17');
   _Dll_PublicDevices_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','18');
   _Dll_TotalUserAccounts_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','19');
   _Dll_TotalGroupAccounts_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','20');
   _Dll_TotalActiveNetworkSetting_HashCode := LocalData.GetDataFromDll('HashCodes','HashCode','21');
end;

function TMyAgent.CompareHashCodes(HashCode1:string;HashCode2:string):boolean;
begin
   if(HashCode1 = HashCode2) then Result := false
   else Result := true;
end;
end.


