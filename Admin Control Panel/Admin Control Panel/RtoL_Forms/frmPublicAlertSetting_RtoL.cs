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
    public partial class frmPublicAlertSetting_RtoL : Telerik.WinControls.UI.RadForm
    {
        private string _langCode;
        private DataTable objDataTable;
        private Agents[] _agents;
        private Agents _agent;
        private int _settingFor;  //0 = all ; 1 = for one ; 2 = for many


        private int PowerAlertId;
        private int FlashAlertId;
        private int UserAlertId;
        private int GroupAlertId;

        private int PowerSoundId;
        private int FlashSoundId;
        private int UserSoundId;
        private int GroupSoundId;

        private string PowerSoundPath;
        private string FlashSoundPath;
        private string UserSoundPath;
        private string GroupSoundPath;

        private string AllSoundPath;

        public frmPublicAlertSetting_RtoL()
        {
            PowerAlertId = 0;
            FlashAlertId = 0;
            UserAlertId = 0;
            GroupAlertId = 0;

            PowerSoundId = 0;
            FlashSoundId = 0;
            UserSoundId = 0;
            GroupSoundId = 0;

            PowerSoundPath = "";
            FlashSoundPath = "";
            UserSoundPath = "";
            GroupSoundPath = "";

            AllSoundPath = "";
           
            _settingFor = 0;
            InitializeComponent();
        }

          public frmPublicAlertSetting_RtoL(Agents agent)
        {
            _agent = agent;
            _settingFor = 1; 
            InitializeComponent();

        }

          public frmPublicAlertSetting_RtoL(Agents[] agents)
        {
            _agents = agents;
            _settingFor = 2;
            InitializeComponent();
        }

          private void frmPublicAlertSetting_RtoL_Load(object sender, EventArgs e)
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
              chbPowerEmail.Enabled = true;
              chbFlashEmail.Enabled = true;
              chbUserEmail.Enabled = true;
              chbGroupEmail.Enabled = true;
             
          }

          private void SilverSet()
          {
              chbSendSMSAll.Enabled = true;
              chbPowerSms.Enabled = true;
              chbFlashSms.Enabled = true;
              chbUserSms.Enabled = true;
              chbGroupSms.Enabled = true;
             
          }
        */
          private void SetCheckBoxes()
          {
              SetPowerAlertId();
              SetFlashAlertId();
              SetUserAlertId();
              SetGroupAlertId();
              SetSoundCheckBoxes();
              
          }

          private void SetSoundCheckBoxes()
          {
              if (PowerSoundId == 1)
                  chbPowerSound.Checked = true;
              else
                  chbPowerSound.Checked = false;

              if (FlashSoundId == 1)
                  chbFlashSound.Checked = true;
              else
                  chbFlashSound.Checked = false;

              if (UserSoundId == 1)
                  chbUserSound.Checked = true;
              else
                  chbUserSound.Checked = false;

              if (GroupSoundId == 1)
                  chbGroupSound.Checked = true;
              else
                  chbGroupSound.Checked = false;
          }

          private void SetUserAlertId()
          {
              int _UserAlertId = UserAlertId;
              UserAlertId = 0;
              switch (_UserAlertId)
              {
                  case 0:
                      {
                          chbUserNo.Checked = true;
                          break;
                      }
                  case 1:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 2:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 3:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 4:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 5:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 6:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 7:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = false;
                          break;
                      }
                  case 8:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 9:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 10:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 11:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = false;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 12:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 13:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = false;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 14:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = false;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = true;
                          break;
                      }
                  case 15:
                      {
                          chbUserNo.Checked = false;
                          chbUserDesktop.Checked = true;
                          chbUserIcon.Checked = true;
                          chbUserEmail.Checked = true;
                          chbUserSms.Checked = true;
                          break;
                      }
              }
          }

          private void SetGroupAlertId()
          {
              int _GroupAlertId = GroupAlertId;
              GroupAlertId = 0;
              switch (_GroupAlertId)
              {
                  case 0:
                      {
                          chbGroupNo.Checked = true;
                          break;
                      }
                  case 1:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 2:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 3:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 4:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 5:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 6:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 7:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = false;
                          break;
                      }
                  case 8:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 9:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 10:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 11:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = false;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 12:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 13:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = false;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 14:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = false;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = true;
                          break;
                      }
                  case 15:
                      {
                          chbGroupNo.Checked = false;
                          chbGroupDesktop.Checked = true;
                          chbGroupIcon.Checked = true;
                          chbGroupEmail.Checked = true;
                          chbGroupSms.Checked = true;
                          break;
                      }
              }
          }

          private void SetPowerAlertId()
          {
              int _PowerAlertId = PowerAlertId;
              PowerAlertId = 0;
              switch (_PowerAlertId)
              {
                  case 0:
                      {
                          chbPowerNo.Checked = true;
                          break;
                      }
                  case 1:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 2:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 3:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 4:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 5:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 6:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 7:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = false;
                          break;
                      }
                  case 8:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 9:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 10:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 11:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = false;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 12:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 13:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = false;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 14:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = false;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = true;
                          break;
                      }
                  case 15:
                      {
                          chbPowerNo.Checked = false;
                          chbPowerDesktop.Checked = true;
                          chbPowerIcon.Checked = true;
                          chbPowerEmail.Checked = true;
                          chbPowerSms.Checked = true;
                          break;
                      }
              }
          }

          private void SetFlashAlertId()
          {
              int _FlashAlertId = FlashAlertId;
              FlashAlertId = 0;
              switch (_FlashAlertId)
              {
                  case 0:
                      {
                          chbFlashNo.Checked = true;
                          break;
                      }
                  case 1:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 2:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 3:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 4:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 5:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 6:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 7:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = false;
                          break;
                      }
                  case 8:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 9:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 10:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 11:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = false;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 12:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 13:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = false;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 14:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = false;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = true;
                          break;
                      }
                  case 15:
                      {
                          chbFlashNo.Checked = false;
                          chbFlashDesktop.Checked = true;
                          chbFlashIcon.Checked = true;
                          chbFlashEmail.Checked = true;
                          chbFlashSms.Checked = true;
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
              newparams[0, 1] = "4";

              objDataTable = new DataTable("Table");
              objDataTable = sql.ExcecuteQueryToDataTable(newparams);

              PowerAlertId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[2].ToString());
              FlashAlertId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[2].ToString());
              UserAlertId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[2].ToString());
              GroupAlertId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[2].ToString());

              PowerSoundId = Convert.ToInt32(objDataTable.Rows[0].ItemArray[5].ToString());
              FlashSoundId = Convert.ToInt32(objDataTable.Rows[1].ItemArray[5].ToString());
              UserSoundId = Convert.ToInt32(objDataTable.Rows[2].ItemArray[5].ToString());
              GroupSoundId = Convert.ToInt32(objDataTable.Rows[3].ItemArray[5].ToString());

              PowerSoundPath = objDataTable.Rows[0].ItemArray[6].ToString();
              FlashSoundPath = objDataTable.Rows[1].ItemArray[6].ToString();
              UserSoundPath = objDataTable.Rows[2].ItemArray[6].ToString();
              GroupSoundPath = objDataTable.Rows[3].ItemArray[6].ToString();             

          }

          private void FillForm()
          {
              LogicLayer l1 = new LogicLayer();

              this.Text = l1.GetMessageFromDll(_langCode, "AlertSetting");
              grbPublicAlert.Text = l1.GetMessageFromDll(_langCode, "Public");
              lblEvents.Text = l1.GetMessageFromDll(_langCode, "Event");
              chbDesktopAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmDesktop");
              chbNotifyIconAll.Text = l1.GetMessageFromDll(_langCode, "clmNotifyIcon");
              chbSendEmailAll.Text = l1.GetMessageFromDll(_langCode, "clmEmail");
              chbSendSMSAll.Text = l1.GetMessageFromDll(_langCode, "clmSMS");
              chbNoAlertAll.Text = l1.GetMessageFromDll(_langCode, "clmNoAlert");

              chbSoundAll.Text = l1.GetMessageFromDll(_langCode, "Sound");

              lblPower.Text = l1.GetMessageFromDll(_langCode, "PowerChanges");
              lblFlash.Text = l1.GetMessageFromDll(_langCode, "FlashChanges");

              lblUserAccount.Text = l1.GetMessageFromDll(_langCode, "UserAccountChange");
              lblGroupAccount.Text = l1.GetMessageFromDll(_langCode, "GroupAccountChange");
             


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
                  chbPowerNo.Checked = true;
                  chbFlashNo.Checked = true;
                  chbUserNo.Checked = true;
                  chbGroupNo.Checked = true;
                  chbSendSMSAll.Checked = false;
                  chbSendEmailAll.Checked = false;
                  chbNotifyIconAll.Checked = false;
                  chbDesktopAlertAll.Checked = false;

                  chbPowerSound.Checked = false;
                  chbFlashSound.Checked = false;
                  chbUserSound.Checked = false;
                  chbGroupSound.Checked = false;

              }
              if (chbNoAlertAll.Checked == false)
              {
                  chbPowerNo.Checked = false;
                  chbFlashNo.Checked = false;
                  chbUserNo.Checked = false;
                  chbGroupNo.Checked = false;               
              }
          }

          private void chbDesktopAlertAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbDesktopAlertAll.Checked == true)
              {
                  chbNoAlertAll.Checked = false;
                  chbPowerDesktop.Checked = true;
                  chbFlashDesktop.Checked = true;
                  chbUserDesktop.Checked = true;
                  chbGroupDesktop.Checked = true;
              }
              if (chbDesktopAlertAll.Checked == false)
              {
                  chbPowerDesktop.Checked = false;
                  chbFlashDesktop.Checked = false;
                  chbUserDesktop.Checked = false;
                  chbGroupDesktop.Checked = false;
              }
          }

          private void chbNotifyIconAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbNotifyIconAll.Checked == true)
              {
                  chbNoAlertAll.Checked = false;
                  chbPowerIcon.Checked = true;
                  chbFlashIcon.Checked = true;
                  chbUserIcon.Checked = true;
                  chbGroupIcon.Checked = true;
                 
              }
              if (chbNotifyIconAll.Checked == false)
              {
                  chbPowerIcon.Checked = false;
                  chbFlashIcon.Checked = false;
                  chbUserIcon.Checked = false;
                  chbGroupIcon.Checked = false;                
              }
          }

          private void chbSendEmailAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {

              if (chbSendEmailAll.Checked == true)
              {
                  chbNoAlertAll.Checked = false;
                  chbPowerEmail.Checked = true;
                  chbFlashEmail.Checked = true;
                  chbUserEmail.Checked = true;
                  chbGroupEmail.Checked = true;
                  
              }
              if (chbSendEmailAll.Checked == false)
              {
                  chbPowerEmail.Checked = false;
                  chbFlashEmail.Checked = false;
                  chbUserEmail.Checked = false;
                  chbGroupEmail.Checked = false;
              }
          }

          private void chbSendSMSAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbSendSMSAll.Checked == true)
              {
                  chbNoAlertAll.Checked = false;
                  chbPowerSms.Checked = true;
                  chbFlashSms.Checked = true;
                  chbUserSms.Checked = true;
                  chbGroupSms.Checked = true;
                 
              }
              if (chbSendSMSAll.Checked == false)
              {
                  chbPowerSms.Checked = false;
                  chbFlashSms.Checked = false;
                  chbUserSms.Checked = false;
                  chbGroupSms.Checked = false;
              }
          }

          private void chbPowerNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerNo.Checked == true)
              {
                  chbPowerDesktop.Checked = false;
                  chbPowerIcon.Checked = false;
                  chbPowerEmail.Checked = false;
                  chbPowerSms.Checked = false;
              }
          }

          private void chbFlashNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashNo.Checked == true)
              {
                  chbFlashDesktop.Checked = false;
                  chbFlashIcon.Checked = false;
                  chbFlashEmail.Checked = false;
                  chbFlashSms.Checked = false;
              }
          }

          private void chbPowerDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerDesktop.Checked == true)
              {
                  chbPowerNo.Checked = false;
                  PowerAlertId = PowerAlertId + 1;
              }
              if (chbPowerDesktop.Checked == false)
              {
                  PowerAlertId = PowerAlertId - 1;
              }
          }

          private void chbPowerIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerIcon.Checked == true)
              {
                  chbPowerNo.Checked = false;
                  PowerAlertId = PowerAlertId + 2;
              }
              if (chbPowerIcon.Checked == false)
              {
                  PowerAlertId = PowerAlertId - 2;
              }
          }

          private void chbPowerEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerEmail.Checked == true)
              {
                  chbPowerNo.Checked = false;
                  PowerAlertId = PowerAlertId + 4;
              }
              if (chbPowerEmail.Checked == false)
              {
                  PowerAlertId = PowerAlertId - 4;
              }
          }

          private void chbPowerSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerSms.Checked == true)
              {
                  chbPowerNo.Checked = false;
                  PowerAlertId = PowerAlertId + 8;
              }
              if (chbPowerSms.Checked == false)
              {
                  PowerAlertId = PowerAlertId - 8;
              }
          }

          private void chbFlashDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashDesktop.Checked == true)
              {
                  chbFlashNo.Checked = false;
                  FlashAlertId = FlashAlertId + 1;
              }
              if (chbFlashDesktop.Checked == false)
              {
                  FlashAlertId = FlashAlertId - 1;
              }
          }

          private void chbFlashIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashIcon.Checked == true)
              {
                  chbFlashNo.Checked = false;
                  FlashAlertId = FlashAlertId + 2;
              }
              if (chbFlashIcon.Checked == false)
              {
                  FlashAlertId = FlashAlertId - 2;
              }
          }

          private void chbFlashEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashEmail.Checked == true)
              {
                  chbFlashNo.Checked = false;
                  FlashAlertId = FlashAlertId + 4;
              }
              if (chbFlashEmail.Checked == false)
              {
                  FlashAlertId = FlashAlertId - 4;
              }
          }

          private void chbFlashSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashSms.Checked == true)
              {
                  chbFlashNo.Checked = false;
                  FlashAlertId = FlashAlertId + 8;
              }
              if (chbFlashSms.Checked == false)
              {
                  FlashAlertId = FlashAlertId - 8;
              }
          }

          private void tsbSave_Click(object sender, EventArgs e)
          {
              SaveSettingToSql("26", PowerAlertId, PowerSoundId, PowerSoundPath);
              SaveSettingToSql("27", FlashAlertId, FlashSoundId, FlashSoundPath);
              SaveSettingToSql("28", UserAlertId, UserSoundId, UserSoundPath);
              SaveSettingToSql("29", GroupAlertId, GroupSoundId, GroupSoundPath);

             
              this.Close();
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

          private void chbUserDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserDesktop.Checked == true)
              {
                  chbUserNo.Checked = false;
                  UserAlertId = UserAlertId + 1;
              }
              if (chbUserDesktop.Checked == false)
              {
                  UserAlertId = UserAlertId - 1;
              }

          }

          private void chbUserIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserIcon.Checked == true)
              {
                  chbUserNo.Checked = false;
                  UserAlertId = UserAlertId + 2;
              }
              if (chbUserIcon.Checked == false)
              {
                  UserAlertId = UserAlertId - 2;
              }

          }

          private void chbUserEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserEmail.Checked == true)
              {
                  chbUserNo.Checked = false;
                  UserAlertId = UserAlertId + 4;
              }
              if (chbUserEmail.Checked == false)
              {
                  UserAlertId = UserAlertId - 4;
              }
          }

          private void chbUserSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserSms.Checked == true)
              {
                  chbUserNo.Checked = false;
                  UserAlertId = UserAlertId + 8;
              }
              if (chbUserSms.Checked == false)
              {
                  UserAlertId = UserAlertId - 8;
              }
          }

          private void chbUserNo_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserNo.Checked == true)
              {
                  chbUserDesktop.Checked = false;
                  chbUserIcon.Checked = false;
                  chbUserEmail.Checked = false;
                  chbUserSms.Checked = false;
              }
          }

          private void chbGroupDesktop_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbGroupDesktop.Checked == true)
              {
                  chbGroupNo.Checked = false;
                  GroupAlertId = GroupAlertId + 1;
              }
              if (chbGroupDesktop.Checked == false)
              {
                  GroupAlertId = GroupAlertId - 1;
              }
          }

          private void chbGroupIcon_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbGroupIcon.Checked == true)
              {
                  chbGroupNo.Checked = false;
                  GroupAlertId = GroupAlertId + 2;
              }
              if (chbGroupIcon.Checked == false)
              {
                  GroupAlertId = GroupAlertId - 2;
              }
          }

          private void chbGroupEmail_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbGroupEmail.Checked == true)
              {
                  chbGroupNo.Checked = false;
                  GroupAlertId = GroupAlertId + 4;
              }
              if (chbGroupEmail.Checked == false)
              {
                  GroupAlertId = GroupAlertId - 4;
              }
          }

          private void chbGroupSms_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbGroupSms.Checked == true)
              {
                  chbGroupNo.Checked = false;
                  GroupAlertId = GroupAlertId + 8;
              }
              if (chbGroupSms.Checked == false)
              {
                  GroupAlertId = GroupAlertId - 8;
              }
          }

          private void chbSoundAll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbSoundAll.Checked == true)
              {
                  chbNoAlertAll.Checked = false;
                  chbPowerSound.Checked = true;
                  chbFlashSound.Checked = true;
                  chbUserSound.Checked = true;
                  chbGroupSound.Checked = true;
              }
              if (chbSoundAll.Checked == false)
              {
                  chbPowerSound.Checked = false;
                  chbFlashSound.Checked = false;
                  chbUserSound.Checked = false;
                  chbGroupSound.Checked = false;
              }
          }

          private void chbPowerSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbPowerSound.Checked == true)
                  PowerSoundId = 1;
              if (chbPowerSound.Checked == false)
              {
                  PowerSoundId = 0;
                  PowerSoundPath = "";
              }
          }

          private void chbFlashSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbFlashSound.Checked == true)
                  FlashSoundId = 1;
              if (chbFlashSound.Checked == false)
              {
                  FlashSoundId = 0;
                  FlashSoundPath = "";
              }
          }

          private void chbUserSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbUserSound.Checked == true)
                  UserSoundId = 1;
              if (chbUserSound.Checked == false)
              {
                  UserSoundId = 0;
                  UserSoundPath = "";
              }
          }

          private void chbGroupSound_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
          {
              if (chbGroupSound.Checked == true)
                  GroupSoundId = 1;
              if (chbGroupSound.Checked == false)
              {
                  GroupSoundId = 0;
                  GroupSoundPath = "";
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

          private void btnPowerSound_Click(object sender, EventArgs e)
          {
              openFileDialog1.FileName = "";

              openFileDialog1.Title = "";

              openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

              openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

              DialogResult result = openFileDialog1.ShowDialog();
              if (result == DialogResult.OK) // Test result.
              {
                  PowerSoundPath = openFileDialog1.FileName;
                  chbPowerSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

              }
              else
                  PowerSoundPath = "";
          }

          private void btnFlashSound_Click(object sender, EventArgs e)
          {
              openFileDialog1.FileName = "";

              openFileDialog1.Title = "";

              openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

              openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

              DialogResult result = openFileDialog1.ShowDialog();
              if (result == DialogResult.OK) // Test result.
              {
                  FlashSoundPath = openFileDialog1.FileName;
                  chbFlashSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

              }
              else
                  FlashSoundPath = "";
          }

          private void btnUserSound_Click(object sender, EventArgs e)
          {
              openFileDialog1.FileName = "";

              openFileDialog1.Title = "";

              openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

              openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

              DialogResult result = openFileDialog1.ShowDialog();
              if (result == DialogResult.OK) // Test result.
              {
                  UserSoundPath = openFileDialog1.FileName;
                  chbUserSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

              }
              else
                  UserSoundPath = "";
          }

          private void btnGroupSound_Click(object sender, EventArgs e)
          {
              openFileDialog1.FileName = "";

              openFileDialog1.Title = "";

              openFileDialog1.Filter = "Audio File (*.WAV)| *.wav";

              openFileDialog1.InitialDirectory = Environment.CurrentDirectory;

              DialogResult result = openFileDialog1.ShowDialog();
              if (result == DialogResult.OK) // Test result.
              {
                  GroupSoundPath = openFileDialog1.FileName;
                  chbGroupSound.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;

              }
              else
                  GroupSoundPath = "";
          }


    }
}
