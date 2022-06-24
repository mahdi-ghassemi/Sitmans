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
    public partial class frmSoftAlertSetting_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private DataTable objDataTable;
        private Agents[] _agents;
        private Agents _agent;
        private int _settingFor;  //0 = all ; 1 = for one ; 2 = for many


        private int AppAlertId;
        private int OsAlertId;
        private int UpdatesAlertId;

        private int AppSoundId;
        private int OsSoundId;
        private int UpdatesSoundId;

        private string AppSoundPath;
        private string OsSoundPath;
        private string UpdatesSoundPath;

        private string AllSoundPath;

        public frmSoftAlertSetting_RtoL()
        {
            AppAlertId = 0;
            OsAlertId = 0;
            UpdatesAlertId = 0;

            AppSoundId = 0;
            OsSoundId = 0;
            UpdatesSoundId = 0;


            AppSoundPath = "";
            OsSoundPath = "";
            UpdatesSoundPath = "";

            _settingFor = 0;
            InitializeComponent();
        }

         public frmSoftAlertSetting_RtoL(Agents agent)
        {
            _agent = agent;
            _settingFor = 1; 
            InitializeComponent();

        }

         public frmSoftAlertSetting_RtoL(Agents[] agents)
        {
            _agents = agents;
            _settingFor = 2;
            InitializeComponent();
        }

         private void frmSoftAlertSetting_RtoL_Load(object sender, EventArgs e)
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
             chbAppEmail.Enabled = true;
             chbOsEmail.Enabled = true;
             chbUpdatesEmail.Enabled = true;            
         }

         private void SilverSet()
         {
             chbSendSMSAll.Enabled = true;
             chbAppSms.Enabled = true;
             chbOsSms.Enabled = true;             
             chbUpdatesSms.Enabled = true;            
         }
        */
         private void SetCheckBoxes()
         {
             SetAppAlertId();
             SetOsAlertId();
             SetUpdatesAlertId();
             SetSoundCheckBoxes();
         }

         private void SetSoundCheckBoxes()
         {
             if (AppSoundId == 1)
                 chbAppSound.Checked = true;
             else
                 chbAppSound.Checked = false;

             if (OsSoundId == 1)
                 chbOsSound.Checked = true;
             else
                 chbOsSound.Checked = false;

             if (UpdatesSoundId == 1)
                 chbUpdatesSound.Checked = true;
             else
                 chbUpdatesSound.Checked = false;
         }

         private void SetAppAlertId()
         {
             int _AppAlertId = AppAlertId;
             AppAlertId = 0;
             switch (_AppAlertId)
             {
                 case 0:
                     {
                         chbAppNo.Checked = true;
                         break;
                     }
                 case 1:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 2:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 3:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 4:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 5:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 6:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 7:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = false;
                         break;
                     }
                 case 8:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 9:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 10:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 11:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = false;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 12:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 13:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = false;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 14:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = false;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = true;
                         break;
                     }
                 case 15:
                     {
                         chbAppNo.Checked = false;
                         chbAppDesktop.Checked = true;
                         chbAppIcon.Checked = true;
                         chbAppEmail.Checked = true;
                         chbAppSms.Checked = true;
                         break;
                     }
             }
         }

         private void SetOsAlertId()
         {
             int _OsAlertId = OsAlertId;
             OsAlertId = 0;
             switch (_OsAlertId)
             {
                 case 0:
                     {
                         chbOsNo.Checked = true;
                         break;
                     }
                 case 1:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 2:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 3:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 4:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 5:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 6:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 7:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = false;
                         break;
                     }
                 case 8:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 9:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 10:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 11:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = false;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 12:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 13:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = false;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 14:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = false;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = true;
                         break;
                     }
                 case 15:
                     {
                         chbOsNo.Checked = false;
                         chbOsDesktop.Checked = true;
                         chbOsIcon.Checked = true;
                         chbOsEmail.Checked = true;
                         chbOsSms.Checked = true;
                         break;
                     }
             }
         }

         private void SetUpdatesAlertId()
         {
             int _UpdatesAlertId = UpdatesAlertId;
             UpdatesAlertId = 0;
             switch (_UpdatesAlertId)
             {
                 case 0:
                     {
                         chbUpdatesNo.Checked = true;
                         break;
                     }
                 case 1:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 2:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 3:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 4:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 5:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 6:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 7:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = false;
                         break;
                     }
                 case 8:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 9:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 10:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 11:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = false;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 12:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 13:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = false;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 14:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = false;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
                 case 15:
                     {
                         chbUpdatesNo.Checked = false;
                         chbUpdatesDesktop.Checked = true;
                         chbUpdatesIcon.Checked = true;
                         chbUpdatesEmail.Checked = true;
                         chbUpdatesSms.Checked = true;
                         break;
                     }
             }
         }

         private void SetData()
         {
             SQLAccess sql = new SQLAccess();

             sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAllSystemAlertList.ToString();
             string[,] newparams = new string[1, 2];
             newparams[0, 0] = "@GroupId";
             newparams[0, 1] = "2";

             objDataTable = new DataTable("Table");
             objDataTable = sql.ExcecuteQueryToDataTable(newparams);

             AppAlertId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[2].ToString());
             OsAlertId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[2].ToString());
             UpdatesAlertId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[2].ToString());

             AppSoundId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[5].ToString());
             OsSoundId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[5].ToString());
             UpdatesSoundId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[5].ToString());

             AppSoundPath = objDataTable.Rows[0].ItemArray[6].ToString();
             OsSoundPath = objDataTable.Rows[1].ItemArray[6].ToString();
             UpdatesSoundPath = objDataTable.Rows[2].ItemArray[6].ToString();

         }

         private void FillForm()
         {
             LogicLayer l1 = new LogicLayer();

             this.Text = l1.GetMessageFromDll(_langCode, "AlertSetting");
             grbSoftAlert.Text = l1.GetMessageFromDll(_langCode, "Softwares");
             lblEvents.Text = l1.GetMessageFromDll(_langCode, "Event");
             chbDesktopAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmDesktop");
             chbNotifyIconAll.Text = l1.GetMessageFromDll(_langCode, "clmNotifyIcon");
             chbSendEmailAll.Text = l1.GetMessageFromDll(_langCode, "clmEmail");
             chbSendSMSAll.Text = l1.GetMessageFromDll(_langCode, "clmSMS");
             chbNoAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmNoAlert");
             chbSoundAll.Text = l1.GetMessageFromDll(_langCode, "Sound");

             lblAppChanges.Text = l1.GetMessageFromDll(_langCode, "ApplicationChanges");
             lblOs.Text = l1.GetMessageFromDll(_langCode, "OsChanges");
             lblUpdates.Text = l1.GetMessageFromDll(_langCode, "UpdatesChanges");
            

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

         private void chbNoAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbNoAlertAll.Checked == true)
             {
                 chbAppNo.Checked = true;
                 chbUpdatesNo.Checked = true;
                 chbOsNo.Checked = true;
                 chbSendSMSAll.Checked = false;
                 chbSendEmailAll.Checked = false;
                 chbNotifyIconAll.Checked = false;
                 chbDesktopAlertAll.Checked = false;
                 chbAppSound.Checked = false;
                 chbOsSound.Checked = false;
                 chbUpdatesSound.Checked = false;
             }
             if (chbNoAlertAll.Checked == false)
             {
                 chbAppNo.Checked = false;
                 chbUpdatesNo.Checked = false;
                 chbOsNo.Checked = false;                
             }


         }

         private void chbDesktopAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbDesktopAlertAll.Checked == true)
             {
                 chbNoAlertAll.Checked = false;
                 chbAppDesktop.Checked = true;
                 chbOsDesktop.Checked = true;
                 chbUpdatesDesktop.Checked = true;
             }
             if (chbDesktopAlertAll.Checked == false)
             {
                 chbAppDesktop.Checked = false;
                 chbOsDesktop.Checked = false;
                 chbUpdatesDesktop.Checked = false;
             }
         }

         private void chbNotifyIconAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbNotifyIconAll.Checked == true)
             {
                 chbNoAlertAll.Checked = false;
                 chbAppIcon.Checked = true;
                 chbOsIcon.Checked = true;
                 chbUpdatesIcon.Checked = true;
             }
             if (chbNotifyIconAll.Checked == false)
             {
                 chbAppIcon.Checked = false;
                 chbOsIcon.Checked = false;
                 chbUpdatesIcon.Checked = false;
             }
         }

         private void chbSendEmailAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbSendEmailAll.Checked == true)
             {
                 chbNoAlertAll.Checked = false;
                 chbAppEmail.Checked = true;
                 chbOsEmail.Checked = true;
                 chbUpdatesEmail.Checked = true;
             }
             if (chbSendEmailAll.Checked == false)
             {
                 chbAppEmail.Checked = false;
                 chbOsEmail.Checked = false;
                 chbUpdatesEmail.Checked = false;
             }
         }

         private void chbSendSMSAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbSendSMSAll.Checked == true)
             {
                 chbNoAlertAll.Checked = false;
                 chbAppSms.Checked = true;
                 chbOsSms.Checked = true;
                 chbUpdatesSms.Checked = true;
             }
             if (chbSendSMSAll.Checked == false)
             {
                 chbAppSms.Checked = false;
                 chbOsSms.Checked = false;
                 chbUpdatesSms.Checked = false;
             }
         }

         private void chbAppNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppNo.Checked == true)
             {
                 chbAppDesktop.Checked = false;
                 chbAppIcon.Checked = false;
                 chbAppEmail.Checked = false;
                 chbAppSms.Checked = false;
                 chbAppSound.Checked = false;
             }
         }

         private void chbOsNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsNo.Checked == true)
             {
                 chbOsDesktop.Checked = false;
                 chbOsIcon.Checked = false;
                 chbOsEmail.Checked = false;
                 chbOsSms.Checked = false;
                 chbOsSound.Checked = false;
             }
         }

         private void chbUpdatesNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesNo.Checked == true)
             {
                 chbUpdatesDesktop.Checked = false;
                 chbUpdatesIcon.Checked = false;
                 chbUpdatesEmail.Checked = false;
                 chbUpdatesSms.Checked = false;
                 chbUpdatesSound.Checked = false;
             }
         }

         private void chbAppDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppDesktop.Checked == true)
             {
                 chbAppNo.Checked = false;
                 AppAlertId = AppAlertId + 1;
             }
             if (chbAppDesktop.Checked == false)
             {
                 AppAlertId = AppAlertId - 1;
             }
         }

         private void chbAppIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppIcon.Checked == true)
             {
                 chbAppNo.Checked = false;
                 AppAlertId = AppAlertId + 2;
             }
             if (chbAppIcon.Checked == false)
             {
                 AppAlertId = AppAlertId - 2;
             }
         }

         private void chbAppEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppEmail.Checked == true)
             {
                 chbAppNo.Checked = false;
                 AppAlertId = AppAlertId + 4;
             }
             if (chbAppEmail.Checked == false)
             {
                 AppAlertId = AppAlertId - 4;
             }
         }

         private void chbAppSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppSms.Checked == true)
             {
                 chbAppNo.Checked = false;
                 AppAlertId = AppAlertId + 8;
             }
             if (chbAppSms.Checked == false)
             {
                 AppAlertId = AppAlertId - 8;
             }
         }

         private void chbOsDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsDesktop.Checked == true)
             {
                 chbOsNo.Checked = false;
                 OsAlertId = OsAlertId + 1;
             }
             if (chbOsDesktop.Checked == false)
             {
                 OsAlertId = OsAlertId - 1;
             }
         }

         private void chbOsIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsIcon.Checked == true)
             {
                 chbOsNo.Checked = false;
                 OsAlertId = OsAlertId + 2;
             }
             if (chbOsIcon.Checked == false)
             {
                 OsAlertId = OsAlertId - 2;
             }
         }

         private void chbOsEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsEmail.Checked == true)
             {
                 chbOsNo.Checked = false;
                 OsAlertId = OsAlertId + 4;
             }
             if (chbOsEmail.Checked == false)
             {
                 OsAlertId = OsAlertId - 4;
             }
         }

         private void chbOsSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsSms.Checked == true)
             {
                 chbOsNo.Checked = false;
                 OsAlertId = OsAlertId + 8;
             }
             if (chbOsSms.Checked == false)
             {
                 OsAlertId = OsAlertId - 8;
             }
         }

         private void chbUpdatesDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesDesktop.Checked == true)
             {
                 chbUpdatesNo.Checked = false;
                 UpdatesAlertId = UpdatesAlertId + 1;
             }
             if (chbUpdatesDesktop.Checked == false)
             {
                 UpdatesAlertId = UpdatesAlertId - 1;
             }
         }

         private void chbUpdatesIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesIcon.Checked == true)
             {
                 chbUpdatesNo.Checked = false;
                 UpdatesAlertId = UpdatesAlertId + 2;
             }
             if (chbUpdatesIcon.Checked == false)
             {
                 UpdatesAlertId = UpdatesAlertId - 2;
             }
         }

         private void chbUpdatesEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesEmail.Checked == true)
             {
                 chbUpdatesNo.Checked = false;
                 UpdatesAlertId = UpdatesAlertId + 4;
             }
             if (chbUpdatesEmail.Checked == false)
             {
                 UpdatesAlertId = UpdatesAlertId - 4;
             }
         }

         private void chbUpdatesSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesSms.Checked == true)
             {
                 chbUpdatesNo.Checked = false;
                 UpdatesAlertId = UpdatesAlertId + 8;
             }
             if (chbUpdatesSms.Checked == false)
             {
                 UpdatesAlertId = UpdatesAlertId - 8;
             }
         }

         private void tsbSave_Click(object sender, EventArgs e)
         {
             SaveSettingToSql("17", AppAlertId, AppSoundId, AppSoundPath);
             SaveSettingToSql("18", OsAlertId, OsSoundId, OsSoundPath);
             SaveSettingToSql("19", UpdatesAlertId, UpdatesSoundId, UpdatesSoundPath);
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
                 chbAppSound.Checked = true;
                 chbOsSound.Checked = true;
                 chbUpdatesSound.Checked = true;                
             }
             if (chbSoundAll.Checked == false)
             {
                 chbNoAlertAll.Checked = false;
                 chbAppSound.Checked = false;
                 chbOsSound.Checked = false;
                 chbUpdatesSound.Checked = false;                

             }
         }

         private void chbAppSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbAppSound.Checked == true)
                 AppSoundId = 1;
             if (chbAppSound.Checked == false)
             {
                 AppSoundId = 0;
                 AppSoundPath = "";
             }
         }

         private void chbOsSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbOsSound.Checked == true)
                 OsSoundId = 1;
             if (chbOsSound.Checked == false)
             {
                 OsSoundId = 0;
                 OsSoundPath = "";
             }
         }

         private void chbUpdatesSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
         {
             if (chbUpdatesSound.Checked == true)
                 UpdatesSoundId = 1;
             if (chbUpdatesSound.Checked == false)
             {
                 UpdatesSoundId = 0;
                 UpdatesSoundPath = "";
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

         private void btnAppSound_Click(object sender, EventArgs e)
         {
             openFileDialog1.FileName = "";

             openFileDialog1.Title = "";

             openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

             openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

             DialogResult result = openFileDialog1.ShowDialog();
             if (result == DialogResult.OK) // Test result.
             {
                 AppSoundPath = openFileDialog1.FileName;
                 chbAppSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

             }
             else
                 AppSoundPath = "";
         }

         private void btnOsSound_Click(object sender, EventArgs e)
         {
             openFileDialog1.FileName = "";

             openFileDialog1.Title = "";

             openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

             openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

             DialogResult result = openFileDialog1.ShowDialog();
             if (result == DialogResult.OK) // Test result.
             {
                 OsSoundPath = openFileDialog1.FileName;
                 chbOsSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
             }
             else
                 OsSoundPath = "";
         }

         private void btnUpdatesSound_Click(object sender, EventArgs e)
         {
             openFileDialog1.FileName = "";

             openFileDialog1.Title = "";

             openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

             openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

             DialogResult result = openFileDialog1.ShowDialog();
             if (result == DialogResult.OK) // Test result.
             {
                 UpdatesSoundPath = openFileDialog1.FileName;
                 chbUpdatesSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
             }
             else
                 UpdatesSoundPath = "";
         }




    }
}
