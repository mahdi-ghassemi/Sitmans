using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.RtoL_Forms
{
    public partial class frmUser_RtoL : Telerik.WinControls.UI.RadForm
    {
        private DataTable dt;
        private string _langCode;
        private bool _new;
        private bool _edit;
        private int _position;
        private bool _haveError;
        private LogicLayer lg;
        private string Id;
        private string Name;
        private string Password;
        private string Email;
        private string Family;
        private string JobTitle;
        private string Number;
        private string PersonelCode;
        private string UserName;
        private byte[] UserImage;
        private int SecLevel;
        private string AclProfileId;
        

        public frmUser_RtoL()
        {
            _langCode = Convert.ToString(Program.LangCode);
            lg = new LogicLayer();
            _new = false;
            _edit = false;
            InitializeComponent();
        }

        private void frmUser_RtoL_Load(object sender, EventArgs e)
        {
            FillForm();
            FillAclProfileComboList();
            FillDataTable();          
            EnDisControls(false);
            FirstNavigatorButtomControl();
            
        }

        private void FillAclProfileComboList()
        {
            string _default = lg.GetMessageFromDll(_langCode, "DefaultProfile");
            lg.GetAclObjectsHeaderProfile();
            int _rowCount = Program.AclObjectsProfileList.Count;

            cmbAcl.Items.Add(_default);
       

            for (int i = 1; i < _rowCount; i++)
            {
                cmbAcl.Items.Add(Program.AclObjectsProfileList[i].ProfileName);             
            }

            //cmbAcl.SelectedIndex = 0;
          
        }

        private void FirstNavigatorButtomControl()
        {
            saveToolStripButton.Enabled = false;
            addNewToolStripButton.Enabled = true;
            openToolStripButton.Enabled = true;
            deleteToolStripButton.Enabled = true;
        }      
      
        private void FillForm()
        {
            this.Text = lg.GetMessageFromDll(_langCode, "ITmanDefine");
            lblName.Text = lg.GetMessageFromDll(_langCode, "Firstname");
            lblFamily.Text = lg.GetMessageFromDll(_langCode, "Lastname");
            lblJobTitle.Text = lg.GetMessageFromDll(_langCode, "JobTitle");
            lblPersonelCode.Text = lg.GetMessageFromDll(_langCode, "UserPersonnelCode");
            lblUsername.Text = lg.GetMessageFromDll(_langCode, "lblSqlUsername");
            lblPassword.Text = lg.GetMessageFromDll(_langCode, "lblSqlPassword");
            lblPassConf.Text = lg.GetMessageFromDll(_langCode, "lblReRemotePassword");
            lblSecLevel.Text = lg.GetMessageFromDll(_langCode, "AclLevel");
            lblEmail.Text = lg.GetMessageFromDll(_langCode, "EmailAddress");
            lblNumber.Text = lg.GetMessageFromDll(_langCode, "InternalContact");
            grbUser.Text = lg.GetMessageFromDll(_langCode, "UserAccountInfo");
            btnBrowse.Text = lg.GetMessageFromDll(_langCode, "BrowseImage");
            lblId.Text = lg.GetMessageFromDll(_langCode, "Code");
            lblAclProfile.Text = lg.GetMessageFromDll(_langCode, "AclProfile");

             
            

            cmbSecLevel.Items[0] = lg.GetMessageFromDll(_langCode, "Unclassified");
            cmbSecLevel.Items[1] = lg.GetMessageFromDll(_langCode, "Restricted");
            cmbSecLevel.Items[2] = lg.GetMessageFromDll(_langCode, "Confidential");
            cmbSecLevel.Items[3] = lg.GetMessageFromDll(_langCode, "Secret");
            cmbSecLevel.Items[4] = lg.GetMessageFromDll(_langCode, "TopSecret");
        }

        private void FillDataTable()
        {
            dt = new DataTable();
            dt.Clear();
            TextBoxClear();
            dt = lg.GetUserList();
           
            bindingSource1.DataSource = dt;
            bindingNavigator1.BindingSource = this.bindingSource1;
            txbId.DataBindings.Add(new Binding("Text", bindingSource1, "UserID", true));
            txbName.DataBindings.Add(new Binding("Text", bindingSource1, "Firstname", true));
            txbConfirmPass.DataBindings.Add(new Binding("Text", bindingSource1, "PassW", true));
            txbEmail.DataBindings.Add(new Binding("Text", bindingSource1, "Email", true));
            txbFamily.DataBindings.Add(new Binding("Text", bindingSource1, "Lastname", true));
            txbJobTitle.DataBindings.Add(new Binding("Text", bindingSource1, "JobTitle", true));
            txbNumber.DataBindings.Add(new Binding("Text", bindingSource1, "Number", true));
            txbPassword.DataBindings.Add(new Binding("Text", bindingSource1, "PassW", true));
            txbPersonelCode.DataBindings.Add(new Binding("Text", bindingSource1, "PersonelCode", true));
            txbUserName.DataBindings.Add(new Binding("Text", bindingSource1, "Username", true));
            Binding imageBinding = new Binding("Image", bindingSource1, "UserImage", true);
            imageBinding.Format += new ConvertEventHandler(imageBinding_Format);            
            this.imgUser.DataBindings.Add(imageBinding);
            cmbSecLevel.DataBindings.Add(new Binding("Text", bindingSource1, "ClassifyID", true));
            cmbAcl.DataBindings.Add(new Binding("Text", bindingSource1, "AclProfileTitle", true));
        }
        
        private void imageBinding_Format(object sender, ConvertEventArgs e)
        {
            Byte[] imgBytesArray = (Byte[])e.Value;
            MemoryStream ms = new MemoryStream(imgBytesArray);
            Image img = Image.FromStream(ms);
            e.Value = img;
        }
        
        private void EnDisControls(bool Action)
        {

            txbName.Enabled = Action;
            txbConfirmPass.Enabled = Action;
            txbEmail.Enabled = Action;
            txbFamily.Enabled = Action;
            txbJobTitle.Enabled = Action;
            txbNumber.Enabled = Action;
            txbPassword.Enabled = Action;
            txbPersonelCode.Enabled = Action;
            txbUserName.Enabled = Action;
            btnBrowse.Enabled = Action;
            cmbSecLevel.Enabled = Action;
            cmbAcl.Enabled = Action;
        }

        private void frmUser_RtoL_Shown(object sender, EventArgs e)
        {           
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
            addNewToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "New");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");
            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            openToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Edit");
           
            bindingNavigatorMoveFirstItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveFirstItem");
            bindingNavigatorMoveLastItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveLastItem");
            bindingNavigatorMoveNextItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveNextItem");
            bindingNavigatorMovePreviousItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MovePreviousItem");
            bindingNavigatorPositionItem.ToolTipText = lg.GetMessageFromDll(_langCode, "PositionItem");
            bindingNavigatorCountItem.ToolTipText = lg.GetMessageFromDll(_langCode, "CountItem");
        }

        private void bindingNavigatorCountItem_TextChanged(object sender, EventArgs e)
        {
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
        }

        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(52))
            {
                addNewToolStripButton.Enabled = false;
                deleteToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = true;
                openToolStripButton.Enabled = false;
              
                _new = false;
                _edit = true;
                EnDisControls(true);
                txbName.Focus();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            CheckError();
            if (!_haveError)
            {
                if (_new == true)
                {
                    SaveNewRecordToSql();                    
                }
                if (_edit == true)
                {
                    UpdateRecordInSql();
                }
            }
        }

        private void CheckError()
        {
            _haveError = false;
            if (txbName.Text == "")
            {
                erpAll.SetError(txbName, lg.GetMessageFromDll(_langCode, "EnterFirstName"));
                _haveError = true;
                
            }
            if (txbFamily.Text == "")
            {
                erpAll.SetError(txbFamily, lg.GetMessageFromDll(_langCode, "EnterFamily"));
                _haveError = true;

            }
            if (txbUserName.Text == "")
            {
                erpAll.SetError(txbUserName, lg.GetMessageFromDll(_langCode, "EnterUsername"));
                _haveError = true;  
            }
            if (txbPassword.Text == "")
            {
                erpAll.SetError(txbPassword, lg.GetMessageFromDll(_langCode, "EnterPassword"));
                _haveError = true; 
            }
            if (txbPassword.Text != txbConfirmPass.Text)
            {
                erpAll.SetError(txbConfirmPass, lg.GetMessageFromDll(_langCode, "ErrorPasswordConfirm"));
                _haveError = true; 
            }
            if (txbEmail.Text.Trim() != "")
            {
                if (txbEmail.Text.IndexOf('@') == -1 || txbEmail.Text.IndexOf('.') == -1)
                {
                    erpAll.SetError(txbEmail, lg.GetMessageFromDll(_langCode, "ErrorMailAddress"));
                    _haveError = true;
                }
            }
            if (_edit != true)
            {
                if (lg.CheckUsername(txbUserName.Text.ToLower().Trim()))
                {
                    erpAll.SetError(txbUserName, lg.GetMessageFromDll(_langCode, "ErrorUsernameRep"));
                    _haveError = true;
                }
            }

        }

        private void SaveNewRecordToSql()
        {
           
            SetVaribles();

            int res = lg.SaveUserToSql(UserName, Name, Family, Password, PersonelCode, UserImage, JobTitle, Email, Number, "1", SecLevel.ToString(),AclProfileId);
            if (res == 1)
            {
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);

            }
            if (res == 0)
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);
            }
        }

        private void SetVaribles()
        {
            
            Name = txbName.Text.Trim();
            Password = lg.Encrypt(txbPassword.Text.Trim(), true, "");
            Email = txbEmail.Text.Trim();
            Family = txbFamily.Text.Trim();
            JobTitle = txbJobTitle.Text.Trim();
            Number = txbNumber.Text.Trim();
            PersonelCode = txbPersonelCode.Text.Trim();
            UserName = lg.Encrypt(txbUserName.Text.Trim(), true, "");
            if (imgUser.ImageLocation != null)
                UserImage = lg.ReadFile(imgUser.ImageLocation);
            else
            {
                if (imgUser.Image != null)
                {
                    UserImage = lg.imageToByteArray2(imgUser.Image);
                }
                else
                {
                    UserImage = lg.imageToByteArray2(Properties.Resources.unknown);
                }                
            }
            SecLevel = cmbSecLevel.SelectedIndex + 1;
            
        }

        private void UpdateRecordInSql()
        {
            SetVaribles();
           
            int res = lg.UpdateUserInSql(txbId.Text.Trim(),UserName, Name, Family, Password, PersonelCode, UserImage, JobTitle, Email, Number, "1", SecLevel.ToString(),AclProfileId);
            if (res == 1)
            {
                string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);
                FirstNavigatorButtomControl();

                if (Convert.ToInt32(txbId.Text.Trim()) == User.UserID)
                {
                    UpdateCurrentUser();
                }

            }
            if (res == 0)
            {
                string mes = lg.GetErrorMessage(19);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);
                FirstNavigatorButtomControl();
            }
        }

        private void UpdateCurrentUser()
        {
            User.UserFirstName = Name;
            User.UserLastName = Family;
            User.UserJobTitleName = JobTitle;
            User.UserUsername = UserName;
            User.UserEmail = Email;
            User.UserClassifyID = SecLevel;
            User.UserImageData = UserImage;
            User.UserImageDataChange = true;
            User.AclProfileId = Convert.ToInt32(AclProfileId);
            lg.SetUserAclObjects();
        }
        
        private void EscapKey()
        {
            FirstNavigatorButtomControl();
            EnDisControls(false);
            FillDataTable();
            bindingSource1.Position = bindingSource1.Position;
            bindingNavigatorPositionItem.Text = Convert.ToString(bindingSource1.Position + 1);
        }

        private void txbName_KeyDown(object sender, KeyEventArgs e)
        {
            erpAll.Clear();
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();                
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbFamily_KeyDown(object sender, KeyEventArgs e)
        {
            erpAll.Clear();
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbJobTitle_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbPersonelCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            erpAll.Clear();
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            erpAll.Clear();
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            erpAll.Clear();
            if (e.KeyCode == Keys.Escape)
            {
                EscapKey();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void txbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(53))
            {
                if (_position > 0 && User.UserID != Convert.ToInt32(txbId.Text.Trim()))
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteNotification");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 3);
                    DialogResult dr = frms.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        DeleteRecordFromSql();
                    }
                }
                else
                {
                    string mes = lg.GetErrorMessage(32);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    DialogResult dr = frms.ShowDialog();
                }
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void DeleteRecordFromSql()
        {           
            int res = lg.DeleteUserFromSql(txbId.Text.Trim());
            if (res == 1)
            {
                string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);

            }
            if (res == 0)
            {
                string mes = lg.GetErrorMessage(20);
                frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                frms.ShowDialog();
                FillDataTable();
                EnDisControls(false);
            }


        }

        private void addNewToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(51))
            {
                addNewToolStripButton.Enabled = false;
                deleteToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = false;
                openToolStripButton.Enabled = false;
               
                _new = true;
                _edit = false;
                EnDisControls(true);
                TextBoxClear();
                imgUser.Image = Properties.Resources.unknown;

                txbName.Focus();
            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void TextBoxClear()
        {
            txbId.DataBindings.Clear();
            txbName.DataBindings.Clear();
            txbConfirmPass.DataBindings.Clear();
            txbEmail.DataBindings.Clear();
            txbFamily.DataBindings.Clear();
            txbJobTitle.DataBindings.Clear();
            txbNumber.DataBindings.Clear();
            txbPassword.DataBindings.Clear();
            txbPersonelCode.DataBindings.Clear();
            txbUserName.DataBindings.Clear();
            imgUser.DataBindings.Clear();
            cmbSecLevel.DataBindings.Clear();
            cmbAcl.DataBindings.Clear();
            txbId.Text = "";
            txbName.Text = "";
            txbConfirmPass.Text = "";
            txbEmail.Text = "";
            txbFamily.Text = "";
            txbJobTitle.Text = "";
            txbNumber.Text = "";
            txbPassword.Text = "";
            txbPersonelCode.Text = "";
            txbUserName.Text = "";
            imgUser.Image = null;
            cmbSecLevel.SelectedIndex = 0;
            cmbAcl.SelectedIndex = 0;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            _position = bindingNavigator1.BindingSource.Position;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            _position = bindingNavigator1.BindingSource.Position;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            _position = bindingNavigator1.BindingSource.Position;                       
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            _position = bindingNavigator1.BindingSource.Position;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Ask user to select file.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.AutoUpgradeEnabled = false;
            
            openFileDialog1.Title = "Select a picture";
            openFileDialog1.Filter = "Image File|*.jpg";
            openFileDialog1.FileName = "";

            DialogResult dlgRes = openFileDialog1.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {              

                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Length > 50000)
                {
                    LogicLayer lg = new LogicLayer();
                    frmShowInfoSmall_RtoL fm = new frmShowInfoSmall_RtoL(lg.GetErrorMessage(27), 2);
                    fm.ShowDialog();
                    imgUser.ImageLocation = null;
                }
                else
                {
                    //Set image in picture box
                    imgUser.ImageLocation = openFileDialog1.FileName;
                }
            }
            else
                imgUser.ImageLocation = null;        
        }

        private void cmbAcl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string profile_name = cmbAcl.SelectedItem.ToString();
            int index = Program.AclObjectsProfileList.FindIndex(item => item.ProfileName == profile_name);
            if (index == -1)
                index = Program.AclObjectsProfileList.FindIndex(item => item.ProfileName == "Default");
            AclProfileId = Program.AclObjectsProfileList[index].ProfileId;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (lg.CheckPermission(54))
            {

            }
            else
            {
                frmShowInfoSmall_RtoL frmmsg = new frmShowInfoSmall_RtoL(Program.AccessDeniedMsg, 2);
                frmmsg.ShowDialog();
            }
        }

        private void frmUser_RtoL_FormClosing(object sender, FormClosingEventArgs e)
        {
            imgUser.Dispose();
            GC.Collect();
        }

     
    }
}
