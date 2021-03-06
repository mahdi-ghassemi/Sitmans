unit TAgent_Class;

interface
uses
    GetActiveNetworkSetting,LocalData;
{
  System.SysUtils, System.Types, System.UITypes,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,
  System.Variants, System.Classes,LocalData,
  GetCPU,GetMainboard,GetBIOS,GetSys,GetChassis,GetOS,GetHardDisk,
  GetVideoCard,GetCDRom,GetLogicDisk,GetMemory,GetModem,GetNetworkAdapter,
  GetPrinter,GetPublicDevices,GetSoftwares,GetUserAccount,SQLData,
  GetGroupAccount,GetActiveNetworkSetting,GetAgentProperties;
}


type
  TAgent = class
    private
    _AgentID : string;
    _ComputerName : string;
    _Organization : string;
    _CurrentUser : string;
    _RegisterCompany : string;
    _RegisterUser : string;
    _AgentFingerPrint : string;
    _HashCode : string;
    _SystemHashCode : string;

    _SQLServerAddress : string;
    _SQLUsername : string;
    _SQLPassword : string;
    _SQLDatabaseName : string;
    _AgentPassword : string;
    _SQLConnString : string;
    _RunOnce : string;
    _IsRegister : string;
    _ControlSoftware : string;
    _ControlHardware : string;
    _ControlNetwork : string;
    _ControlAccounts : string;
    _SendSMS : string;
    _TCPPort : string;
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

     _BiosVendor : string;
     _BiosStartSegment : string;
     _BiosVersion : string;
     _BiosReleaseDate : string;
     _BiosBiosRomSize : string;
     _BiosHashCode : string;

     _ChassisAssetTagNumber : string;
     _ChassisChassisType : string;
     _ChassisHashCode : string;

     _MainboardManufacter : string;
     _MainboardProduct : string;
     _MainboardVersion : string;
     _MainboardSerialNumber : string;
     _MainboardHashCode : string;

     _OsSerialNumber : string;
     _OsBuildNumber : string;
     _OsCaption : string;
     _OsFreePhysicalMemory : string;
     _OsInstallDate : string;
     _OsVersion : string;
     _OsLastBootUpTime :string;
     _OsHashCode : string;

     _SysUUID : string;
     _SysHashCode : string;

     _VideoCardCaption :  LocalData.TStringArray;
     _VideoCardDriverDate : LocalData.TStringArray;
     _VideoCardDriverVersion  : LocalData.TStringArray;
     _VideoCardVideoProcessor : LocalData.TStringArray;
     _VideoCardVideoMode : LocalData.TStringArray;
     _VideoCardAdapterRam : LocalData.TStringArray;
     _VideoCardHashCode : LocalData.TStringArray;
     _VideoCardTotalHashCode : string;

     _CDRomName :  LocalData.TStringArray;
     _CDRomDrive :  LocalData.TStringArray;
     _CDRomHashCode : LocalData.TStringArray;
     _CDRomTotalHashCode : string;

     _LogicDiskCaption :  LocalData.TStringArray;
     _LogicDiskDescription : LocalData.TStringArray;
     _LogicDiskFileSystem  : LocalData.TStringArray;
     _LogicDiskVolumeSize : LocalData.TStringArray;
     _LogicDiskFreeSpace : LocalData.TStringArray;
     _LogicDiskVolumeName : LocalData.TStringArray;
     _LogicDiskVolumeSerialNumber : LocalData.TStringArray;
     _LogicDiskHashCode : LocalData.TStringArray;
     _LogicDiskTotalHashCode : string;

     _MemoryBankLabel :  LocalData.TStringArray;
     _MemoryCapacity : LocalData.TStringArray;
     _MemorySpeed  : LocalData.TStringArray;
     _MemoryHashCode : LocalData.TStringArray;
     _MemoryTotalHashCode : string;

     _ModemModemName :  LocalData.TStringArray;
     _ModemHashCode : LocalData.TStringArray;
     _ModemTotalHashCode : string;

     _NetworkAdapterDescription :  LocalData.TStringArray;
     _NetworkAdapterAdapterType : LocalData.TStringArray;
     _NetworkAdapterMACAddress  : LocalData.TStringArray;
     _NetworkAdapterManufacturer : LocalData.TStringArray;
     _NetworkAdapterNetConnectionID : LocalData.TStringArray;
     _NetworkAdapterPNPDeviceID : LocalData.TStringArray;
     _NetworkAdapterTimeOfLastReset : LocalData.TStringArray;
     _NetworkAdapterHashCode : LocalData.TStringArray;
     _NetworkAdapterTotalHashCode : string;

     _PrinterPrinterName :  LocalData.TStringArray;
     _PrinterNetwork : LocalData.TStringArray;
     _PrinterHashCode : LocalData.TStringArray;
     _PrinterTotalHashCode : string;

     _PublicDevicesMonitor : string;
     _PublicDevicesKeyboard : string;
     _PublicDevicesMouse  : string;
     _PublicDevicesCamera : string;
     _PublicDevicesHashCode : string;

     _SoftwareName : LocalData.TName;
     _SoftwareHashCode : string;

     _UserAccountUserName :  LocalData.TStringArray;
     _UserAccountSID : LocalData.TStringArray;
     _UserAccountDescription  : LocalData.TStringArray;
     _UserAccountStatus : LocalData.TStringArray;
     _UserAccountHashCode : LocalData.TStringArray;
     _UserAccountTotalHashCode : string;

     _GroupAccountGroupName :  LocalData.TStringArray;
     _GroupAccountGID : LocalData.TStringArray;
     _GroupAccountDescription  : LocalData.TStringArray;
     _GroupAccountStatus : LocalData.TStringArray;
     _GroupAccountHashCode : LocalData.TStringArray;
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
     {
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
     }
     procedure GetAgentSettingFromDll;




     property AgentID : string read _AgentID write _AgentID;
     property ComputerName : string read _ComputerName write _ComputerName;
     property Organization : string read _Organization write _Organization;
     property CurrentUser : string read _CurrentUser write _CurrentUser;
     property RegisterCompany : string read _RegisterCompany write _RegisterCompany;
     property RegisterUser : string read _RegisterUser write _RegisterUser;
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
     property TCPPort : string read _TCPPort write _TCPPort;
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
 uses
   GetCPU,System.SysUtils;
constructor TAgent.Create;
begin
 GetAgentSettingFromDll;
end;

procedure TAgent.GetAgentSettingFromDll;
begin

  _SQLServerAddress := LocalData.GetDataFromDll('AgentSetting','SQLServerAddress','1');
  _SQLUsername := LocalData.GetDataFromDll('AgentSetting','SQLUsername','1');
  _SQLPassword := LocalData.GetDataFromDll('AgentSetting','SQLPassword','1');
  _SQLDatabaseName := LocalData.GetDataFromDll('AgentSetting','SQLDatabaseName','1');
  _AgentPassword := LocalData.GetDataFromDll('AgentSetting','AgentPassword','1');
  _RunOnce := LocalData.GetDataFromDll('AgentSetting','RunOnce','1');
  _IsRegister := LocalData.GetDataFromDll('AgentSetting','IsRegister','1');
  _ControlSoftware := LocalData.GetDataFromDll('AgentSetting','ControlSoftware','1');
  _ControlHardware := LocalData.GetDataFromDll('AgentSetting','ControlHardware','1');
  _ControlNetwork := LocalData.GetDataFromDll('AgentSetting','ControlNetwork','1');
  _ControlAccounts := LocalData.GetDataFromDll('AgentSetting','ControlAccounts','1');
  _SendSMS := LocalData.GetDataFromDll('AgentSetting','SendSMS','1');
  _TCPPort := LocalData.GetDataFromDll('AgentSetting','TCPPort','1');
  _UDPPort := LocalData.GetDataFromDll('AgentSetting','UDPPort','1');
  _AdminMachineIPAddress := LocalData.GetDataFromDll('AgentSetting','AdminMachineIPAddress','1');
  _Version := LocalData.GetDataFromDll('AgentSetting','Version','1');
  _LanguageCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
  _RigthToLeft := LocalData.GetDataFromDll('AgentSetting','RigthToLeft','1');
  _StepNumber := LocalData.GetDataFromDll('AgentSetting','StepNumber','1');

end;


procedure TAgent.GetSystemInfo;
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

end;


procedure TAgent.GetSystemHashCode;
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

{

procedure TAgent.SaveSystemAgentToDll;
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

procedure  TAgent.SaveSystemCPUToDll;
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

procedure TAgent.SaveSystemMainboardToDll;
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

procedure TAgent.SaveSystemBiosToDll();
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


procedure TAgent.SaveSystemChassisToDll;
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

procedure TAgent.SaveSystemOSToDll;
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

procedure TAgent.SaveSystemSysToDll;
var
_values : array[0..1] of string;
_result :integer;
begin
   _values[0] := SysUUID;
   _values[1] := SysHashCode;

   _result := LocalData.SaveSysToDll(_values);

end;

procedure TAgent.SaveSystemHardDisksToDll;
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

procedure TAgent.SaveSystmVideoCardToDll;
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

procedure TAgent.SaveSystemCDRomToDll;
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

procedure TAgent.SaveSystemLogicDiskToDll;
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

procedure TAgent.SaveSystemMemoryToDll;
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

procedure TAgent.SaveSystemModemToDll;
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

procedure TAgent.SaveSystemNetworkAdapterToDll;
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

procedure TAgent.SaveSystemPrinterToDll;
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

procedure TAgent.SaveSystemPublicDevicesToDll;
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

procedure TAgent.SaveSystemSoftwareToDll;
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

procedure TAgent.SaveSystemUserAccountToDll;
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

procedure TAgent.SaveSystemGroupAccountToDll;
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

procedure TAgent.SaveSystemActiveNetworkSettingToDll;
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


procedure TAgent.SaveSystemInfoToDll();
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
 }

end.

