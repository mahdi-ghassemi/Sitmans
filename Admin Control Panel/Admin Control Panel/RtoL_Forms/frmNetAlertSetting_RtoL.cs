using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;
using Admin_Control_Panel.RtoL_Forms;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmNetAlertSetting_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private DataTable objDataTable;
        private Agents[] _agents;
        private Agents _agent;
        private int _settingFor;  //0 = all ; 1 = for one ; 2 = for many


        private int IpAlertId;
        private int SubnetAlertId;
        private int GwAlertId;
        private int MacAlertId;
        private int DnsAlertId;
        private int DhcpAlertId;

        private int IpSoundId;
        private int SubnetSoundId;
        private int GwSoundId;
        private int MacSoundId;
        private int DnsSoundId;
        private int DhcpSoundId;

        private string IpSoundPath;
        private string SubnetSoundPath;
        private string GwSoundPath;
        private string MacSoundPath;
        private string DnsSoundPath;
        private string DhcpSoundPath;

        private string AllSoundPath;

        public frmNetAlertSetting_RtoL()
        {
            IpAlertId = 0;
            SubnetAlertId = 0;
            GwAlertId = 0;
            MacAlertId = 0;
            DnsAlertId = 0;
            DhcpAlertId = 0;
            _settingFor = 0;

            IpSoundId = 0;
            SubnetSoundId = 0;
            GwSoundId = 0;
            MacSoundId = 0;
            DnsSoundId = 0;
            DhcpSoundId = 0;

            IpSoundPath = "";
            SubnetSoundPath = "";
            GwSoundPath = "";
            MacSoundPath = "";
            DnsSoundPath = "";
            DhcpSoundPath = "";

            AllSoundPath = "";

            InitializeComponent();
        }

           public frmNetAlertSetting_RtoL(Agents agent)
        {
            _agent = agent;
            _settingFor = 1; 
            InitializeComponent();

        }

           public frmNetAlertSetting_RtoL(Agents[] agents)
        {
            _agents = agents;
            _settingFor = 2;
            InitializeComponent();
        }

           private void frmNetAlertSetting_RtoL_Load(object sender, EventArgs e)
           {
               _langCode = Convert.ToString(Program.LangCode);

               FillForm();
               SetData();
               //ModelControl();
               SetCheckBoxes();
           }
        /*
           private void ModelControl()
           {
               if (Program.Model == "Boronze")
               {
                   BoronzeSet();
               }
               if (Program.Model == "Silver" || Program.Model == "Gold")
               {
                   BoronzeSet();
                   SilverSet();
               }
           }

           private void BoronzeSet()
           {
               chbSendEmailAll.Enabled = true;
               chbIpEmail.Enabled = true;
               chbSubnetEmail.Enabled = true;
               chbGwEmail.Enabled = true;
               chbMacEmail.Enabled = true;
               chbDnsEmail.Enabled = true;
               chbDhcpEmail.Enabled = true;
           }

           private void SilverSet()
           {
               chbSendSMSAll.Enabled = true;
               chbIpSms.Enabled = true;
               chbSubnetSms.Enabled = true;
               chbGwSms.Enabled = true;
               chbMacSms.Enabled = true;
               chbDnsSms.Enabled = true;
               chbDhcpSms.Enabled = true;             
           }
        */
           private void SetCheckBoxes()
           {
               SetIpAlertId();
               SetSubnetAlertId();
               SetGwAlertId();
               SetMacAlertId();
               SetDnsAlertId();
               SetDhcpAlertId();
               SetSoundCheckBoxes();

           }

           private void SetSoundCheckBoxes()
           {
               if (IpSoundId == 1)
                   chbIpSound.Checked = true;
               else
                   chbIpSound.Checked = false;

               if (SubnetSoundId == 1)
                   chbSubnetSound.Checked = true;
               else
                   chbSubnetSound.Checked = false;

               if (GwSoundId == 1)
                   chbGWSound.Checked = true;
               else
                   chbGWSound.Checked = false;

               if (MacSoundId == 1)
                   chbMacSound.Checked = true;
               else
                   chbMacSound.Checked = false;

               if (DnsSoundId == 1)
                   chbDnsSound.Checked = true;
               else
                   chbDnsSound.Checked = false;

               if (DhcpSoundId == 1)
                   chbDhcpSound.Checked = true;
               else
                   chbDhcpSound.Checked = false;
           }

           private void SetIpAlertId()
           {
               int _IpAlertId = IpAlertId;
               IpAlertId = 0;
               switch (_IpAlertId)
               {
                   case 0:
                       {
                           chbIpNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = false;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = false;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = false;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbIpNo.Checked = false;
                           chbIpDesktop.Checked = true;
                           chbIpIcon.Checked = true;
                           chbIpEmail.Checked = true;
                           chbIpSms.Checked = true;
                           break;
                       }
               }
           }

           private void SetSubnetAlertId()
           {
               int _SubnetAlertId = SubnetAlertId;
               SubnetAlertId = 0;
               switch (_SubnetAlertId)
               {
                   case 0:
                       {
                           chbSubnetNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = false;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = false;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = false;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbSubnetNo.Checked = false;
                           chbSubnetDesktop.Checked = true;
                           chbSubnetIcon.Checked = true;
                           chbSubnetEmail.Checked = true;
                           chbSubnetSms.Checked = true;
                           break;
                       }
               }
           }

           private void SetGwAlertId()
           {
               int _GwAlertId = GwAlertId;
               GwAlertId = 0;
               switch (_GwAlertId)
               {
                   case 0:
                       {
                           chbGwNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = false;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = false;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = false;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbGwNo.Checked = false;
                           chbGwDesktop.Checked = true;
                           chbGwIcon.Checked = true;
                           chbGwEmail.Checked = true;
                           chbGwSms.Checked = true;
                           break;
                       }
               }
           }

           private void SetMacAlertId()
           {
               int _MacAlertId = MacAlertId;
               MacAlertId = 0;
               switch (_MacAlertId)
               {
                   case 0:
                       {
                           chbMacNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = false;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = false;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = false;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbMacNo.Checked = false;
                           chbMacDesktop.Checked = true;
                           chbMacIcon.Checked = true;
                           chbMacEmail.Checked = true;
                           chbMacSms.Checked = true;
                           break;
                       }
               }
           }

           private void SetDnsAlertId()
           {
               int _DnsAlertId = DnsAlertId;
               DnsAlertId = 0;
               switch (_DnsAlertId)
               {
                   case 0:
                       {
                           chbDnsNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = false;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = false;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = false;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbDnsNo.Checked = false;
                           chbDnsDesktop.Checked = true;
                           chbDnsIcon.Checked = true;
                           chbDnsEmail.Checked = true;
                           chbDnsSms.Checked = true;
                           break;
                       }
               }
           }

           private void SetDhcpAlertId()
           {
               int _DhcpAlertId = DhcpAlertId;
               DhcpAlertId = 0;
               switch (_DhcpAlertId)
               {
                   case 0:
                       {
                           chbDhcpNo.Checked = true;
                           break;
                       }
                   case 1:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 2:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 3:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 4:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 5:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 6:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 7:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = false;
                           break;
                       }
                   case 8:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 9:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 10:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 11:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = false;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 12:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 13:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = false;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 14:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = false;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = true;
                           break;
                       }
                   case 15:
                       {
                           chbDhcpNo.Checked = false;
                           chbDhcpDesktop.Checked = true;
                           chbDhcpIcon.Checked = true;
                           chbDhcpEmail.Checked = true;
                           chbDhcpSms.Checked = true;
                           break;
                       }
               }
           }

           private void FillForm()
           {
               LogicLayer l1 = new LogicLayer();

               this.Text = l1.GetMessageFromDll(_langCode, "AlertSetting");
               grbNetwork.Text = l1.GetMessageFromDll(_langCode, "Network");
               lblEvents.Text = l1.GetMessageFromDll(_langCode, "Event");
               chbDesktopAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmDesktop");
               chbNotifyIconAll.Text = l1.GetMessageFromDll(_langCode, "clmNotifyIcon");
               chbSendEmailAll.Text = l1.GetMessageFromDll(_langCode, "clmEmail");
               chbSendSMSAll.Text = l1.GetMessageFromDll(_langCode, "clmSMS");
               chbNoAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmNoAlert");

               lblIp.Text = l1.GetMessageFromDll(_langCode, "IpChanges");
               lblSubnet.Text = l1.GetMessageFromDll(_langCode, "SubnetChanges");
               lblGw.Text = l1.GetMessageFromDll(_langCode, "GwChanges");
               lblMac.Text = l1.GetMessageFromDll(_langCode, "MacChanges");
               lblDhcp.Text = l1.GetMessageFromDll(_langCode, "DhcpChanges");
               lblDns.Text = l1.GetMessageFromDll(_langCode, "DnsChanges");

               chbSoundAll.Text = l1.GetMessageFromDll(_langCode, "Sound");
              

               tsbSave.Text = l1.GetMessageFromDll(_langCode, "Save");
               if (_settingFor == 0)
               {
                   lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus0");
               }
               if (_settingFor == 1)
               {
                   lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus1") + " " + _agent.ComputerName + " " + l1.GetMessageFromDll(_langCode, "AlertSettingStatus3");
               }
               if (_settingFor == 2)
               {
                   lblStatus.Text = l1.GetMessageFromDll(_langCode, "AlertSettingStatus2");
               }
           }

           private void SetData()
           {
               SQLAccess sql = new SQLAccess();

               sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAllSystemAlertList.ToString();
               string[,] newparams = new string[1, 2];
               newparams[0, 0] = "@GroupId";
               newparams[0, 1] = "3";

               objDataTable = new DataTable("Table");
               objDataTable = sql.ExcecuteQueryToDataTable(newparams);

               IpAlertId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[2].ToString());
               SubnetAlertId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[2].ToString());
               GwAlertId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[2].ToString());
               MacAlertId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[2].ToString());
               DnsAlertId = Convert.ToInt32(objDataTable.Rows[4].ItemArray[2].ToString());
               DhcpAlertId = Convert.ToInt32(objDataTable.Rows[5].ItemArray[2].ToString());

               IpSoundId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[5].ToString());
               SubnetSoundId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[5].ToString());
               GwSoundId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[5].ToString());
               MacSoundId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[5].ToString());
               DnsSoundId = Convert.ToInt32(objDataTable.Rows[4].ItemArray[5].ToString());
               DhcpSoundId = Convert.ToInt32(objDataTable.Rows[5].ItemArray[5].ToString());

               IpSoundPath = objDataTable.Rows[0].ItemArray[6].ToString();
               SubnetSoundPath = objDataTable.Rows[1].ItemArray[6].ToString();
               GwSoundPath = objDataTable.Rows[2].ItemArray[6].ToString();
               MacSoundPath = objDataTable.Rows[3].ItemArray[6].ToString();
               DnsSoundPath = objDataTable.Rows[4].ItemArray[6].ToString();
               DhcpSoundPath = objDataTable.Rows[5].ItemArray[6].ToString();
               
           }

           private void chbNoAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbNoAlertAll.Checked == true)
               {
                   chbIpNo.Checked = true;
                   chbSubnetNo.Checked = true;
                   chbGwNo.Checked = true;
                   chbMacNo.Checked = true;
                   chbDnsNo.Checked = true;
                   chbDhcpNo.Checked = true;
                   chbSendSMSAll.Checked = false;
                   chbSendEmailAll.Checked = false;
                   chbNotifyIconAll.Checked = false;
                   chbDesktopAlertAll.Checked = false;

                   chbIpSound.Checked = false;
                   chbSubnetSound.Checked = false;
                   chbGWSound.Checked = false;
                   chbMacSound.Checked = false;
                   chbDnsSound.Checked = false;
                   chbDhcpSound.Checked = false;
               }
               if (chbNoAlertAll.Checked == false)
               {
                   chbIpNo.Checked = false;
                   chbSubnetNo.Checked = false;
                   chbGwNo.Checked = false;
                   chbMacNo.Checked = false;
                   chbDnsNo.Checked = false;
                   chbDhcpNo.Checked = false;
               }
                 
           }

           private void chbDesktopAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDesktopAlertAll.Checked == true)
               {
                   chbNoAlertAll.Checked = false;
                   chbIpDesktop.Checked = true;
                   chbSubnetDesktop.Checked = true;
                   chbGwDesktop.Checked = true;
                   chbMacDesktop.Checked = true;
                   chbDnsDesktop.Checked = true;
                   chbDhcpDesktop.Checked = true;

               }
               if (chbDesktopAlertAll.Checked == false)
               {
                   chbIpDesktop.Checked = false;
                   chbSubnetDesktop.Checked = false;
                   chbGwDesktop.Checked = false;
                   chbMacDesktop.Checked = false;
                   chbDnsDesktop.Checked = false;
                   chbDhcpDesktop.Checked = false;
               }
           }

           private void chbNotifyIconAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbNotifyIconAll.Checked == true)
               {
                   chbNoAlertAll.Checked = false;
                   chbIpIcon.Checked = true;
                   chbSubnetIcon.Checked = true;
                   chbGwIcon.Checked = true;
                   chbMacIcon.Checked = true;
                   chbDnsIcon.Checked = true;
                   chbDhcpIcon.Checked = true;
               }
               if (chbNotifyIconAll.Checked == false)
               {
                   chbIpIcon.Checked = false;
                   chbSubnetIcon.Checked = false;
                   chbGwIcon.Checked = false;
                   chbMacIcon.Checked = false;
                   chbDnsIcon.Checked = false;
                   chbDhcpIcon.Checked = false;
               }
           }

           private void chbSendEmailAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSendEmailAll.Checked == true)
               {
                   chbNoAlertAll.Checked = false;
                   chbIpEmail.Checked = true;
                   chbSubnetEmail.Checked = true;
                   chbGwEmail.Checked = true;
                   chbMacEmail.Checked = true;
                   chbDnsEmail.Checked = true;
                   chbDhcpEmail.Checked = true;
               }
               if (chbSendEmailAll.Checked == false)
               {
                   chbIpEmail.Checked = false;
                   chbSubnetEmail.Checked = false;
                   chbGwEmail.Checked = false;
                   chbMacEmail.Checked = false;
                   chbDnsEmail.Checked = false;
                   chbDhcpEmail.Checked = false;
               }
           }

           private void chbSendSMSAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSendSMSAll.Checked == true)
               {
                   chbNoAlertAll.Checked = false;
                   chbIpSms.Checked = true;
                   chbSubnetSms.Checked = true;
                   chbGwSms.Checked = true;
                   chbMacSms.Checked = true;
                   chbDnsSms.Checked = true;
                   chbDhcpSms.Checked = true;
               }
               if (chbSendSMSAll.Checked == false)
               {
                   chbIpSms.Checked = false;
                   chbSubnetSms.Checked = false;
                   chbGwSms.Checked = false;
                   chbMacSms.Checked = false;
                   chbDnsSms.Checked = false;
                   chbDhcpSms.Checked = false;
               }
           }

           private void chbIpNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpNo.Checked == true)
               {
                   chbIpDesktop.Checked = false;
                   chbIpIcon.Checked = false;
                   chbIpEmail.Checked = false;
                   chbIpSms.Checked = false;
               }
           }

           private void chbSubnetNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetNo.Checked == true)
               {
                   chbSubnetDesktop.Checked = false;
                   chbSubnetIcon.Checked = false;
                   chbSubnetEmail.Checked = false;
                   chbSubnetSms.Checked = false;
               }
           }

           private void chbGwNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGwNo.Checked == true)
               {
                   chbGwDesktop.Checked = false;
                   chbGwIcon.Checked = false;
                   chbGwEmail.Checked = false;
                   chbGwSms.Checked = false;
               }
           }

           private void chbMacNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacNo.Checked == true)
               {
                   chbMacDesktop.Checked = false;
                   chbMacIcon.Checked = false;
                   chbMacEmail.Checked = false;
                   chbMacSms.Checked = false;
               }
           }

           private void chbDnsNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsNo.Checked == true)
               {
                   chbDnsDesktop.Checked = false;
                   chbDnsIcon.Checked = false;
                   chbDnsEmail.Checked = false;
                   chbDnsSms.Checked = false;
               }
           }

           private void chbDhcpNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpNo.Checked == true)
               {
                   chbDhcpDesktop.Checked = false;
                   chbDhcpIcon.Checked = false;
                   chbDhcpEmail.Checked = false;
                   chbDhcpSms.Checked = false;
               }
           }

           private void chbIpDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpDesktop.Checked == true)
               {
                   chbIpNo.Checked = false;
                   IpAlertId = IpAlertId + 1;
               }
               if (chbIpDesktop.Checked == false)
               {
                   IpAlertId = IpAlertId - 1;
               }
           }

           private void chbIpIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpIcon.Checked == true)
               {
                   chbIpNo.Checked = false;
                   IpAlertId = IpAlertId + 2;
               }
               if (chbIpIcon.Checked == false)
               {
                   IpAlertId = IpAlertId - 2;
               }
           }

           private void chbIpEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpEmail.Checked == true)
               {
                   chbIpNo.Checked = false;
                   IpAlertId = IpAlertId + 4;
               }
               if (chbIpEmail.Checked == false)
               {
                   IpAlertId = IpAlertId - 4;
               }
           }

           private void chbIpSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpSms.Checked == true)
               {
                   chbIpNo.Checked = false;
                   IpAlertId = IpAlertId + 8;
               }
               if (chbIpSms.Checked == false)
               {
                   IpAlertId = IpAlertId - 8;
               }
           }

           private void chbSubnetDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetDesktop.Checked == true)
               {
                   chbSubnetNo.Checked = false;
                   SubnetAlertId = SubnetAlertId + 1;
               }
               if (chbSubnetDesktop.Checked == false)
               {
                   SubnetAlertId = SubnetAlertId - 1;
               }
           }

           private void chbSubnetIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetIcon.Checked == true)
               {
                   chbSubnetNo.Checked = false;
                   SubnetAlertId = SubnetAlertId + 2;
               }
               if (chbSubnetIcon.Checked == false)
               {
                   SubnetAlertId = SubnetAlertId - 2;
               }
           }

           private void chbSubnetEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetEmail.Checked == true)
               {
                   chbSubnetNo.Checked = false;
                   SubnetAlertId = SubnetAlertId + 4;
               }
               if (chbSubnetEmail.Checked == false)
               {
                   SubnetAlertId = SubnetAlertId - 4;
               }
           }

           private void chbSubnetSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetSms.Checked == true)
               {
                   chbSubnetNo.Checked = false;
                   SubnetAlertId = SubnetAlertId + 8;
               }
               if (chbSubnetSms.Checked == false)
               {
                   SubnetAlertId = SubnetAlertId - 8;
               }
           }

           private void chbGwDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGwDesktop.Checked == true)
               {
                   chbGwNo.Checked = false;
                   GwAlertId = GwAlertId + 1;
               }
               if (chbGwDesktop.Checked == false)
               {
                   GwAlertId = GwAlertId - 1;
               }
           }

           private void chbGwIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGwIcon.Checked == true)
               {
                   chbGwNo.Checked = false;
                   GwAlertId = GwAlertId + 2;
               }
               if (chbGwIcon.Checked == false)
               {
                   GwAlertId = GwAlertId - 2;
               }
           }

           private void chbGwEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGwEmail.Checked == true)
               {
                   chbGwNo.Checked = false;
                   GwAlertId = GwAlertId + 4;
               }
               if (chbGwEmail.Checked == false)
               {
                   GwAlertId = GwAlertId - 4;
               }
           }

           private void chbGwSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGwSms.Checked == true)
               {
                   chbGwNo.Checked = false;
                   GwAlertId = GwAlertId + 8;
               }
               if (chbGwSms.Checked == false)
               {
                   GwAlertId = GwAlertId - 8;
               }
           }

           private void chbMacDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacDesktop.Checked == true)
               {
                   chbMacNo.Checked = false;
                   MacAlertId = MacAlertId + 1;
               }
               if (chbMacDesktop.Checked == false)
               {
                   MacAlertId = MacAlertId - 1;
               }
           }

           private void chbMacIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacIcon.Checked == true)
               {
                   chbMacNo.Checked = false;
                   MacAlertId = MacAlertId + 2;
               }
               if (chbMacIcon.Checked == false)
               {
                   MacAlertId = MacAlertId - 2;
               }
           }

           private void chbMacEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacEmail.Checked == true)
               {
                   chbMacNo.Checked = false;
                   MacAlertId = MacAlertId + 4;
               }
               if (chbMacEmail.Checked == false)
               {
                   MacAlertId = MacAlertId - 4;
               }
           }

           private void chbMacSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacSms.Checked == true)
               {
                   chbMacNo.Checked = false;
                   MacAlertId = MacAlertId + 8;
               }
               if (chbMacSms.Checked == false)
               {
                   MacAlertId = MacAlertId - 8;
               }
           }

           private void chbDnsDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsDesktop.Checked == true)
               {
                   chbDnsNo.Checked = false;
                   DnsAlertId = DnsAlertId + 1;
               }
               if (chbDnsDesktop.Checked == false)
               {
                   DnsAlertId = DnsAlertId - 1;
               }
           }

           private void chbDnsIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsIcon.Checked == true)
               {
                   chbDnsNo.Checked = false;
                   DnsAlertId = DnsAlertId + 2;
               }
               if (chbDnsIcon.Checked == false)
               {
                   DnsAlertId = DnsAlertId - 2;
               }
           }

           private void chbDnsEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsEmail.Checked == true)
               {
                   chbDnsNo.Checked = false;
                   DnsAlertId = DnsAlertId + 4;
               }
               if (chbDnsEmail.Checked == false)
               {
                   DnsAlertId = DnsAlertId - 4;
               }
           }

           private void chbDnsSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsSms.Checked == true)
               {
                   chbDnsNo.Checked = false;
                   DnsAlertId = DnsAlertId + 8;
               }
               if (chbDnsSms.Checked == false)
               {
                   DnsAlertId = DnsAlertId - 8;
               }
           }

           private void chbDhcpDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpDesktop.Checked == true)
               {
                   chbDhcpNo.Checked = false;
                   DhcpAlertId = DhcpAlertId + 1;
               }
               if (chbDhcpDesktop.Checked == false)
               {
                   DhcpAlertId = DhcpAlertId - 1;
               }
           }

           private void chbDhcpIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpIcon.Checked == true)
               {
                   chbDhcpNo.Checked = false;
                   DhcpAlertId = DhcpAlertId + 2;
               }
               if (chbDhcpIcon.Checked == false)
               {
                   DhcpAlertId = DhcpAlertId - 2;
               }
           }

           private void chbDhcpEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpEmail.Checked == true)
               {
                   chbDhcpNo.Checked = false;
                   DhcpAlertId = DhcpAlertId + 4;
               }
               if (chbDhcpEmail.Checked == false)
               {
                   DhcpAlertId = DhcpAlertId - 4;
               }
           }

           private void chbDhcpSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpSms.Checked == true)
               {
                   chbDhcpNo.Checked = false;
                   DhcpAlertId = DhcpAlertId + 8;
               }
               if (chbDhcpSms.Checked == false)
               {
                   DhcpAlertId = DhcpAlertId - 8;
               }
           }

           private void tsbSave_Click(object sender, EventArgs e)
           {
               SaveSettingToSql("20", IpAlertId, IpSoundId, IpSoundPath);
               SaveSettingToSql("21", SubnetAlertId, SubnetSoundId, SubnetSoundPath);
               SaveSettingToSql("22", GwAlertId, GwSoundId, GwSoundPath);
               SaveSettingToSql("23", MacAlertId, MacSoundId, MacSoundPath);
               SaveSettingToSql("24", DnsAlertId, DnsSoundId, DnsSoundPath);
               SaveSettingToSql("25", DhcpAlertId, DhcpSoundId, DhcpSoundPath);
               this.Close();
           }

           private void SaveSettingToSql(string SubjectId, int AlertId)
           {
               SQLAccess sql = new SQLAccess();

               sql.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAllSystemAlertSubjects.ToString();
               string[,] newparams = new string[2, 2];
               newparams[0, 0] = "@AlertId";
               newparams[1, 0] = "@SubjectId";

               newparams[0, 1] = Convert.ToString(AlertId);
               newparams[1, 1] = SubjectId;
               int r = sql.IntExcuteSP(newparams);
           }

           private void SaveSettingToSql(string SubjectId, int AlertId, int SoundId, string SoundPath)
           {
               SQLAccess sql = new SQLAccess();

               sql.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAllSystemAlertSubjects.ToString();
               string[,] newparams = new string[4, 2];
               newparams[0, 0] = "@AlertId";
               newparams[1, 0] = "@SubjectId";
               newparams[2, 0] = "@SoundId";
               newparams[3, 0] = "@SoundPath";

               newparams[0, 1] = Convert.ToString(AlertId);
               newparams[1, 1] = SubjectId;
               newparams[2, 1] = Convert.ToString(SoundId);
               if (SoundId == 1 && SoundPath == "")
               {
                   newparams[3, 1] = AllSoundPath;
               }
               else
                   newparams[3, 1] = SoundPath;

               int r = sql.IntExcuteSP(newparams);
           }

           private void chbSoundAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSoundAll.Checked == true)
               {
                   chbNoAlertAll.Checked = false;
                   chbIpSound.Checked = true;
                   chbSubnetSound.Checked = true;
                   chbMacSound.Checked = true;
                   chbGWSound.Checked = true;
                   chbDnsSound.Checked = true;
                   chbDhcpSound.Checked = true;                  
               }
               if (chbSoundAll.Checked == false)
               {
                   chbDhcpSound.Checked = false;
                   chbIpSound.Checked = false;
                   chbSubnetSound.Checked = false;
                   chbMacSound.Checked = false;
                   chbGWSound.Checked = false;
                   chbDnsSound.Checked = false;
               }
           }

           private void chbIpSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbIpSound.Checked == true)
                   IpSoundId = 1;
               if (chbIpSound.Checked == false)
               {
                   IpSoundId = 0;
                   IpSoundPath = "";
               }
           }

           private void chbSubnetSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbSubnetSound.Checked == true)
                   SubnetSoundId = 1;
               if (chbSubnetSound.Checked == false)
               {
                   SubnetSoundId = 0;
                   SubnetSoundPath = "";
               }
           }

           private void chbGWSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbGWSound.Checked == true)
                   GwSoundId = 1;
               if (chbGWSound.Checked == false)
               {
                   GwSoundId = 0;
                   GwSoundPath = "";
               }
           }

           private void chbMacSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbMacSound.Checked == true)
                   MacSoundId = 1;
               if (chbMacSound.Checked == false)
               {
                   MacSoundId = 0;
                   MacSoundPath = "";
               }
           }

           private void chbDnsSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDnsSound.Checked == true)
                   DnsSoundId = 1;
               if (chbDnsSound.Checked == false)
               {
                   DnsSoundId = 0;
                   DnsSoundPath = "";
               }
           }

           private void chbDhcpSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
           {
               if (chbDhcpSound.Checked == true)
                   DhcpSoundId = 1;
               if (chbDhcpSound.Checked == false)
               {
                   DhcpSoundId = 0;
                   DhcpSoundPath = "";
               }
           }

           private void btnSoundAll_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   AllSoundPath = openFileDialog1.FileName;
                   chbSoundAll.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   AllSoundPath = "";
           }

           private void btnIpSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   IpSoundPath = openFileDialog1.FileName;
                   chbIpSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   IpSoundPath = "";
           }

           private void btnSubnetSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   SubnetSoundPath = openFileDialog1.FileName;
                   chbSubnetSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   SubnetSoundPath = "";
           }

           private void btnGWSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   GwSoundPath = openFileDialog1.FileName;
                   chbGWSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   GwSoundPath = "";
           }

           private void btnMacSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   MacSoundPath = openFileDialog1.FileName;
                   chbMacSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   MacSoundPath = "";
           }

           private void btnDnsSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   DnsSoundPath = openFileDialog1.FileName;
                   chbDnsSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   DnsSoundPath = "";
           }

           private void btnDhcpSound_Click(object sender, EventArgs e)
           {
               openFileDialog1.FileName = "";

               openFileDialog1.Title = "";

               openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

               openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK) // Test result.
               {
                   DhcpSoundPath = openFileDialog1.FileName;
                   chbDhcpSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

               }
               else
                   DhcpSoundPath = "";
           }











    }
}
