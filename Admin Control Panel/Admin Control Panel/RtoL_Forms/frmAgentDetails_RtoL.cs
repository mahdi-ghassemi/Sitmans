using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmAgentDetails_RtoL : Telerik.WinControls.UI.RadForm
    {
        private Agents _agent;
        string _langCode;

        public frmAgentDetails_RtoL(Agents agent)
        {
            _agent = agent;
            _langCode = Convert.ToString(Program.LangCode);
            InitializeComponent();
        }

        private void frmAgentDetails_RtoL_Load(object sender, EventArgs e)
        {
            tviAgentDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            LogicLayer log = new LogicLayer();
            this.Text = log.GetMessageFromDll(_langCode, "SystemDetails");
            tviAgentDetails.Nodes["nodSystem"].Text = _agent.ComputerName.Trim();
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Text = log.GetMessageFromDll(_langCode, "Hardware");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Text = log.GetMessageFromDll(_langCode, "Software");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Text = log.GetMessageFromDll(_langCode, "Network");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Text = log.GetMessageFromDll(_langCode, "Accounts");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Text = log.GetMessageFromDll(_langCode, "Groups");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Text = log.GetMessageFromDll(_langCode, "CPU");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Text = log.GetMessageFromDll(_langCode, "Motherboard");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Text = log.GetMessageFromDll(_langCode, "Bios");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMemory"].Text = log.GetMessageFromDll(_langCode, "Memory");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Text = log.GetMessageFromDll(_langCode, "HardDisk");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Text = log.GetMessageFromDll(_langCode, "LogicDisk");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Text = log.GetMessageFromDll(_langCode, "VideoCard");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCdRom"].Text = log.GetMessageFromDll(_langCode, "CdRom");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Text = log.GetMessageFromDll(_langCode, "Chassis");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMonitor"].Text = log.GetMessageFromDll(_langCode, "Monitor");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodKeyboard"].Text = log.GetMessageFromDll(_langCode, "Keyboard");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMouse"].Text = log.GetMessageFromDll(_langCode, "Mouse");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodPrinter"].Text = log.GetMessageFromDll(_langCode, "Printer");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCamera"].Text = log.GetMessageFromDll(_langCode, "Camera");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodScanner"].Text = log.GetMessageFromDll(_langCode, "Scanner");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodModem"].Text = log.GetMessageFromDll(_langCode, "Modem");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Text = log.GetMessageFromDll(_langCode, "NetAdapter");

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodApplication"].Text = log.GetMessageFromDll(_langCode, "Application");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodSecurityUpdate"].Text = log.GetMessageFromDll(_langCode, "SecurityUpdate");
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Text = log.GetMessageFromDll(_langCode, "OS");



            tviAgentDetails.Nodes["nodSystem"].Image = imageList1.Images[0];
            if (_agent.AgentType == "Notebook")
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Image = imageList1.Images[1];
            if (_agent.AgentType == "Desktop")
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Image = imageList1.Images[2];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Image = imageList1.Images[3];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Image = imageList1.Images[4];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Image = imageList1.Images[5];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMemory"].Image = imageList1.Images[6];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Image = imageList1.Images[7];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Image = imageList1.Images[8];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Image = imageList1.Images[9];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCdRom"].Image = imageList1.Images[10];

            if (_agent.AgentType == "Notebook")
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Image = imageList1.Images[1];
            if (_agent.AgentType == "Desktop")
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Image = imageList1.Images[2];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMonitor"].Image = imageList1.Images[11];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodKeyboard"].Image = imageList1.Images[12];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMouse"].Image = imageList1.Images[13];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodPrinter"].Image = imageList1.Images[14];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCamera"].Image = imageList1.Images[15];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodScanner"].Image = imageList1.Images[16];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodModem"].Image = imageList1.Images[17];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Image = imageList1.Images[18];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Image = imageList1.Images[19];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Image = imageList1.Images[20];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodApplication"].Image = imageList1.Images[21];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodSecurityUpdate"].Image = imageList1.Images[22];

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Image = imageList1.Images[23];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Image = imageList1.Images[24];
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Image = imageList1.Images[25];

            FillTreeView();


        }

        private void FillTreeView()
        {
            FillCpu();
            FillMainboard();
            FillBios();
            FillMemory();
            FillHardDisk();
            FillLogicDisk();
            FillVideoCard();
            FillCdrom();
            FillChassis();
            FillMonitor();
            FillKeyboard();
            FillMouse();
            FillPrinter();
            FillCamera();
            FillScanner();
            FillModem();
            FillNetAdapter();
            FillOS();
            FillApplication();
            FillSecUpdate();
            FillAxtiveNet();
            FillUserAccounts();
            FillGroupAccounts();



            
        }

        private void FillGroupAccounts()
        {
            int index = _agent.UserGroupName.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Nodes.Add(_agent.UserGroupName[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Nodes[_agent.UserGroupName[i]].Nodes.Add("GID : "+_agent.UserGroupSID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Nodes[_agent.UserGroupName[i]].Nodes.Add("Description : " + _agent.UserGroupDescription[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodGroups"].Nodes[_agent.UserGroupName[i]].Nodes.Add("Status : " + _agent.UserGroupStatus[i]);
            }

        }

        

        private void FillUserAccounts()
        {
            int index = _agent.UserAccountName.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Nodes.Add(_agent.UserAccountName[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Nodes[_agent.UserAccountName[i]].Nodes.Add("SID : " + _agent.UserAccountSID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Nodes[_agent.UserAccountName[i]].Nodes.Add("Description : " + _agent.UserAccountDescription[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodAccounts"].Nodes[_agent.UserAccountName[i]].Nodes.Add("Status : " + _agent.UserAccountStatus[i]);
            }
        }      

        private void FillAxtiveNet()
        {
            int index = _agent.ActiveNetworkAdapterCaption.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes.Add(_agent.ActiveNetworkAdapterCaption[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("IP Address : " + _agent.IPAddress[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("MAC Address : " + _agent.MacAddress[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("Default Gateway : " + _agent.DefaultGW[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("Subnet Mask : " + _agent.SubnetMask[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("DNS Server Address : " + _agent.DNSServer[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("DHCP Enabled : " + _agent.DHCPEnabled[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodNetwork"].Nodes[i].Nodes.Add("DHCP Server Address : " + _agent.DHCPServer[i]);

            }
        }      

        private void FillSecUpdate()
        {
            int index = _agent.UpdateName.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodSecurityUpdate"].Nodes.Add(_agent.UpdateName[i]);
            }
        }

        private void FillApplication()
        {
            int index = _agent.SoftwareName.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodApplication"].Nodes.Add(_agent.SoftwareName[i]);
            }
        }

        private void FillOS()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Nodes.Add(_agent.Caption);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Nodes[_agent.Caption].Nodes.Add("Serial Number : " + _agent.OSSerialNumber);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Nodes[_agent.Caption].Nodes.Add("Build Number : " + _agent.OSBuildNumber);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Nodes[_agent.Caption].Nodes.Add("Install Date : " + _agent.InstallDate);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodSoftware"].Nodes["nodOS"].Nodes[_agent.Caption].Nodes.Add("Free Physical Memory : " + _agent.FreePhysicalMemory);


        }

        private void FillNetAdapter()
        {
            int index = _agent.NetDescription.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Nodes.Add(_agent.NetDescription[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Nodes[i].Nodes.Add("Adapter Type : " + _agent.NetAdapterType[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Nodes[i].Nodes.Add("MAC Address : " + _agent.NetMACAddress[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Nodes[i].Nodes.Add("Manufacturer : " + _agent.NetManufacturer[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodNetAdapter"].Nodes[i].Nodes.Add("Connection ID : " + _agent.NetConnectionID[i]);

            }
        }

       

        private void FillModem()
        {
            int index = _agent.Modem.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodModem"].Nodes.Add(_agent.Modem[i]);
            }
        }

        private void FillScanner()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodScanner"].Nodes.Add(_agent.Scanner);
        }

        private void FillCamera()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCamera"].Nodes.Add(_agent.Camera);
        }

        private void FillPrinter()
        {
            int index = _agent.PrinterName.Length;
            for (int i = 0; i < index; i++)
            {

                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodPrinter"].Nodes.Add(_agent.PrinterName[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodPrinter"].Nodes[i].Nodes.Add(_agent.PrinterName[i]);
            }
        }

        private void FillMouse()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMouse"].Nodes.Add(_agent.Mouse);
        }

        private void FillKeyboard()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodKeyboard"].Nodes.Add(_agent.Keyboard);
        }

        private void FillMonitor()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMonitor"].Nodes.Add(_agent.Monitor);
        }

        private void FillChassis()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Nodes.Add("System Type: " + _agent.AgentType);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Nodes.Add("Asset Tag Number: " + _agent.AssetTagNumber);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodChassis"].Nodes.Add("UUID: " + _agent.UUID);

        }

        private void FillCdrom()
        {
            int index = _agent.CdromDrive.Length;
            for (int i = 0; i < index; i++)
            {

                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCdRom"].Nodes.Add(_agent.CDRomName[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodCdRom"].Nodes[i].Nodes.Add("Drive: " + _agent.CdromDrive[i]);
                 

            }
        }

       

        private void FillVideoCard()
        {
            int index = _agent.VideoCard.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes.Add(_agent.VideoCard[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes[i].Nodes.Add("Driver Date: " + _agent.DriverDate[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes[i].Nodes.Add("Driver Version: " + _agent.DriverVersion[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes[i].Nodes.Add("Video Processor: " + _agent.VideoProcessor[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes[i].Nodes.Add("Video Mod: " + _agent.VideoModeDescription[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodVideoCard"].Nodes[i].Nodes.Add("Adapter RAM: " + _agent.AdapterRAM[i]);

            }
        }


        private void FillLogicDisk()
        {
            int index = _agent.LogicDiskCaption.Length;
            for (int i = 0; i < index; i++)
            {
                if (_agent.LogicDiskDescription[i].Contains("CD-ROM") == false)
                {

                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes.Add("Drive :" + _agent.LogicDiskCaption[i]);
                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("Description :" + _agent.LogicDiskDescription[i]);
                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("File System :" + _agent.LogicDiskFileSystem[i]);
                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("Size :" + _agent.LogicDiskSize[i]);
                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("Free Space :" + _agent.LogicDiskFreeSpace[i]);
                    if (_agent.LogicDiskVolumeName[i] != "")
                        tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("VolumeName :" + _agent.LogicDiskVolumeName[i]);
                    tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodLogicDisk"].Nodes["Drive :" + _agent.LogicDiskCaption[i]].Nodes.Add("Serial Number :" + _agent.LogicDiskVolumeSerialNumber[i]);
                }

            }
           

        }

  

        private void FillHardDisk()
        {
            int index = _agent.HardDisk.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Nodes.Add(_agent.HardDisk[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Nodes[i].Nodes.Add("Serial Number :" + _agent.HardDiskSignature[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Nodes[i].Nodes.Add("Size :" + _agent.HardDiskSize[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodHardDisk"].Nodes[i].Nodes.Add("Partitions :" + _agent.HardDiskPartitions[i]);              
            }
        }       

        private void FillMemory()
        {
            int index = _agent.BankLabel.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMemory"].Nodes.Add("Slat" + Convert.ToString(i));
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMemory"].Nodes["Slat" + Convert.ToString(i)].Nodes.Add("Capacity: " + _agent.Memory[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMemory"].Nodes["Slat" + Convert.ToString(i)].Nodes.Add("Speed: " + _agent.Speed[i]);

            }
        }

        private void FillBios()
        {          

            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Nodes.Add("Vendor : " + _agent.BiosVendor);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Nodes.Add("Version : " + _agent.BiosVersion);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Nodes.Add("Start Segment : " + _agent.BiosStartSegment);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Nodes.Add("Release Date : " + _agent.BiosReleaseDate);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodBios"].Nodes.Add("RomSize : " + _agent.BiosRomSize);            
        }       

        private void FillMainboard()
        {
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Nodes.Add("Brand : " + _agent.MotherboardCaption);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Nodes.Add("Model : " + _agent.MotherboardModel);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Nodes.Add("Serial Number : " + _agent.MotherboardSerialNumber);
            tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodMainboard"].Nodes.Add("Version : " + _agent.MotherboardVersion);

        }



        private void FillCpu()
        {
            int index = _agent.CpuBrand.Length;
            for (int i = 0; i < index; i++)
            {
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes.Add(_agent.CpuBrand[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Vendor ID : " + _agent.VendorID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Stepping ID : " + _agent.SteppingID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Model Number : " + _agent.CpuModelNumber[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Family Code : " + _agent.FamilyCode[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Processor Type : " + _agent.ProcessorType[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Extended Model : " + _agent.ExtendedModel[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Extended Family : " + _agent.ExtendedFamily[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Brand ID : " + _agent.BrandID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Chunks : " + _agent.Chunks[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Counts : " + _agent.Counts[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("APICID : " + _agent.APICID[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("SerialNumber : " + _agent.CpuSerialNumber[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("MMX : " + _agent.MMX[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("Fxsave Fxrstor Instructions : " + _agent.FxsaveFxrstorInstructions[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("SSE : " + _agent.SSE[i]);
                tviAgentDetails.Nodes["nodSystem"].Nodes["nodHardware"].Nodes["nodProcessor"].Nodes[i].Nodes.Add("SSE2 : " + _agent.SSE2[i]);
                
            }
            
      
       
        }



        
    }
}
