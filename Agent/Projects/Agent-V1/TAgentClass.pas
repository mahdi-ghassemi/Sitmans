unit TAgentClass;

interface
uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, LocalData,GetCPU,GetMainboard,GetBIOS,GetSys,GetChassis,GetOS,GetHardDisk,
  GetVideoCard,GetCDRom,GetLogicDisk,GetMemory,GetModem,GetNetworkAdapter,
  GetPrinter,GetPublicDevices,GetSoftwares,GetUserAccount,SQLData,
  GetGroupAccount,GetActiveNetworkSetting,GetAgentProperties;



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
     procedure SaveSystemStatusToSql;



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
     if _SendToSql = '0' Then
     begin
         SaveSystemAgentToSql;
         SaveSystemStatusToSql;
     end;

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
     LocalData.UpdateFieldToDll('AgentSetting','SendToSQL','1','ID = 1');
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

  //if res = 1  then LocalData.UpdateFieldToDll('AgentDetails','SendToSql','1','ID = 1');

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

end.


