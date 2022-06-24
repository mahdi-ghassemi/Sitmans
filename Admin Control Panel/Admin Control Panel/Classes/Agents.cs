using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

namespace Admin_Control_Panel.Classes
{
    public class Agents
    {

        // Public info
        public int AgentMainIndex {get; set;}
        public string ComputerName { get; set; }
        public string AgentID { get; set; }
        public string AgentNumber { get; set; }
        public string ImagePath { get; set; }
        public string CurrentAccount { get; set; }
        public string AgentType { get; set; }
        public string StartupDate { get; set; }
        public string StartupTime { get; set; }
        public string Status { get; set; }
        public string RegisterCompany { get; set; }
        public string Alias { get; set; }
        public string IdleDuration { get; set; }

        // Personnel
        public string PersonnelFName { get; set; }
        public string PersonnelLName { get; set; }
        public string PersonnelCode { get; set; }
        public Image PersonnelImage { get; set; }
        public string PersonnelTitle { get; set; }
        public string PersonnelInterNum { get; set; }
        public string PersonnelGender { get; set; }
        public string PersonnelTellNum { get; set; }
        public string PersonnelCellNum { get; set; }
        public string PersonnelAddress { get; set; }
        public string PersonnelMail { get; set; }


        // AllDevices

        public string Monitor { get; set; }
        public string MonitorSerialNumber { get; set; }
        public string AllDevicesTableId { get; set; }
        public string Mouse { get; set; }
        public string MouseSerialNumber { get; set; }
        public string Keyboard { get; set; }
        public string KeyboardSerialNumber { get; set; }
        public string Camera { get; set; }
        public string CameraSerialNumber { get; set; }
        public string Scanner { get; set; }
        public string ScannerSerialNumber { get; set; }
        public string[] Modem { get; set; }
        public string[] ModemSerialNumber { get; set; }
        public string[] ModemTableId { get; set; }


        // HardDisk
        public string[] HardDisk { get; set; }
        public string[] HardDiskSignature { get; set; }
        public string[] HardDiskSize { get; set; }
        public string[] HardDiskPartitions { get; set; }
        public string[] HardDiskPNPDeviceID { get; set; }
        public string[] HardDiskSerialNumber { get; set; }
        public string[] HardDiskTableId { get; set; }


        // LogicDisk

        public string[] LogicDiskCaption { get; set; }
        public string[] LogicDiskDescription { get; set; }
        public string[] LogicDiskFileSystem { get; set; }
        public string[] LogicDiskSize { get; set; }
        public string[] LogicDiskFreeSpace { get; set; }
        public string[] LogicDiskVolumeName { get; set; }
        public string[] LogicDiskVolumeSerialNumber { get; set; }


        // Memory

        public string[] Memory { get; set; } //capacity
        public string[] BankLabel { get; set; }
        public string[] Speed { get; set; }
        public string[] MemorySerialNumber { get; set; }
        public string[] MemoryTableId { get; set; }
        public string[] MemoryModel { get; set; }


        // Motherboard

        public string MotherboardModel { get; set; }
        public string MotherboardCaption { get; set; }
        public string MotherboardSerialNumber { get; set; }
        public string MotherboardVersion { get; set; }



        // NetworkAdepter

        public string[] NetDescription { get; set; }
        public string[] NetAdapterType { get; set; }
        public string[] NetMACAddress { get; set; }
        public string[] NetManufacturer { get; set; }
        public string[] NetConnectionID { get; set; }
        public string[] NetPNPDeviceID { get; set; }
        public string[] NetTimeOfLastReset { get; set; }
        public string[] NetDefaultIPGateway { get; set; }
        public string[] NetSerialNumber { get; set; }
        public string[] NetTableId { get; set; }


        // ActiveNetworkAdapter

        public string[] ActiveNetworkAdapterCaption { get; set; }
        public string[] IPAddress { get; set; }
        public string[] MacAddress { get; set; }
        public string[] DefaultGW { get; set; }
        public string[] SubnetMask { get; set; }
        public string[] DNSServer { get; set; }
        public string[] DHCPEnabled { get; set; }
        public string[] DHCPServer { get; set; }



        // OperatingSystem

        public string OSSerialNumber { get; set; }
        public string OSBuildNumber { get; set; }
        public string Caption { get; set; }
        public string InstallDate { get; set; }
        public string LastBootUpTime { get; set; }
        public string FreePhysicalMemory { get; set; }
        public string Organization { get; set; }
        public string RegisteredUser { get; set; }
        public string Version { get; set; }


        // Printer

        public string[] PrinterName { get; set; }
        public string[] PrinterNetwork { get; set; }
        public string[] PrinterSerialNumber { get; set; }
        public string[] PrinterTableId { get; set; }


        // Processor

        public string[] VendorID { get; set; }
        public string[] SteppingID { get; set; }
        public string[] CpuModelNumber { get; set; }
        public string[] FamilyCode { get; set; }
        public string[] ProcessorType { get; set; }
        public string[] ExtendedModel { get; set; }
        public string[] ExtendedFamily { get; set; }
        public string[] BrandID { get; set; }
        public string[] Chunks { get; set; }
        public string[] Counts { get; set; }
        public string[] APICID { get; set; }
        public string[] CpuSerialNumber { get; set; }
        public string[] MMX { get; set; }
        public string[] FxsaveFxrstorInstructions { get; set; }
        public string[] SSE { get; set; }
        public string[] SSE2 { get; set; }
        public string[] ExtendedCPUID { get; set; }
        public string[] LargestFunctionSupported { get; set; }
        public string[] CpuBrand { get; set; }


        // Software

        public string[] SoftwareName { get; set; }



        // UserAccount

        public string[] UserAccountName { get; set; }
        public string[] UserAccountSID { get; set; }
        public string[] UserAccountDescription { get; set; }
        public string[] UserAccountStatus { get; set; }


        // UserGroup

        public string[] UserGroupName { get; set; }
        public string[] UserGroupSID { get; set; }
        public string[] UserGroupDescription { get; set; }
        public string[] UserGroupStatus { get; set; }


        // VideoCard

        public string[] VideoCard { get; set; }
        public string[] DriverDate { get; set; }
        public string[] DriverVersion { get; set; }
        public string[] VideoProcessor { get; set; }
        public string[] VideoModeDescription { get; set; }
        public string[] AdapterRAM { get; set; }
        public string[] VideoCardSerialNumber { get; set; }
        public string[] VideoCardTableId { get; set; }

        // CDROM

        public string[] CDRomName { get; set; }
        public string[] CdromDrive { get; set; }
        public string[] CDRomSerialNumber { get; set; }
        public string[] CDRomTableId { get; set; }

        // Updates

        public string[] UpdateName { get; set; }

        // Bios

        public string BiosVendor { get; set; }
        public string BiosVersion { get; set; }
        public string BiosStartSegment { get; set; }
        public string BiosReleaseDate { get; set; }
        public string BiosRomSize { get; set; }


        // Chassis

        public string AssetTagNumber { get; set; }
        public string ChassisType { get; set; }
        public string UUID { get; set; }

        // Events 


        //public List<Events> EventList;

        //Location

        public int BuildingId { get; set; }
        public int ClassId { get; set; }
        public int RoomId { get; set; }
        public int DepartmentId { get; set; }
        public string BuildingTitle { get; set; }
        public string ClassTitle { get; set; }
        public string RoomTitle { get; set; }
        public string DepartmentTitle { get; set; }

        //Asset Numbering and External devices 

        public string[] AssetTableId { get; set; }
        public string[] DeviceAssetNumber { get; set; }
        public int[] DeviceId { get; set; }
        public string[] DeviceModel { get; set; }
        public string[] DeviceSerialNumber { get; set; }
       

        // Setting

        public string SettingProfileId { get; set; }
        public string SettingProfileName { get; set; }
        public string LastSettingProfileId { get; set; }

        // Alert

        public string AlertProfileId { get; set; }
        public string AlertProfileName { get; set; }
        public string[] AlertSubjectId { get; set; }
        public string[] AlertId { get; set; }
        public string[] Sound { get; set; }
        public string[] SoundFileLocation { get; set; }
        public string AlertLevelId { get; set; }

        // Acl Profile Details

        public string AclProfileId { get; set; }
        public string AclProfileName { get; set; }
        public int acl1 { get; set; }
        public int acl2 { get; set; }
        public int acl3 { get; set; }
        public int acl4 { get; set; }
        public int acl5 { get; set; }
        public int acl6 { get; set; }
        public int acl7 { get; set; }
        public int acl8 { get; set; }
        public int acl9 { get; set; }
        public int acl10 { get; set; }
        public int acl11 { get; set; }
        public int acl12 { get; set; }
        public int acl13 { get; set; }
        public int acl14 { get; set; }
        public int acl15 { get; set; }
        public int acl16 { get; set; }
        public int acl17 { get; set; }
        public int acl18 { get; set; }
        public int acl19 { get; set; }
        public int acl20 { get; set; }
        public int acl21 { get; set; }
        public int acl22 { get; set; }
        public int acl23 { get; set; }
        public int acl24 { get; set; }
        public int acl42 { get; set; }
        public int acl43 { get; set; }

              
    }
}
