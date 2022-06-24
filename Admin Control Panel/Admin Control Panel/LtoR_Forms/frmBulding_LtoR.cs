using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Admin_Control_Panel.Classes;

namespace Admin_Control_Panel.LtoR_Forms
{
    public partial class frmBulding_LtoR : Telerik.WinControls.UI.RadForm
    {
        private DataTable dt;
        private string _langCode;
        private bool _new;
        private bool _edit;
        private int _position;

        public frmBulding_LtoR()
        {
            _langCode = Convert.ToString(Program.LangCode);
            _new = false;
            _edit = false;
            InitializeComponent();
        }

        private void frmBulding_LtoR_Load(object sender, EventArgs e)
        {
            FillForm();
            FillDataTable();
            SetControls();
        }

      

        private void SetControls()
        {
            if (bindingSource1.Count != 0)
            {
                bindingNavigator1.BindingSource.MoveLast();
                addNewToolStripButton.Enabled = true;
                deleteToolStripButton.Enabled = true;
                saveToolStripButton.Enabled = false;
                openToolStripButton.Enabled = true;
                printToolStripButton.Enabled = true;
                txbTitle.Enabled = false;
            }
            if (bindingSource1.Count == 0)
            {
                addNewToolStripButton.Enabled = true;
                deleteToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = false;
                openToolStripButton.Enabled = false;
                printToolStripButton.Enabled = false;
                txbTitle.Enabled = false;
            }

        }

        private void FillDataTable()
        {
            LogicLayer lg = new LogicLayer();
            dt = new DataTable();
            dt.Clear();
            txbId.DataBindings.Clear();
            txbTitle.DataBindings.Clear();
            txbId.Text = "";
            txbTitle.Text = "";

            if (chbBuilding.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                dt = lg.GetBuldingList();
                bindingSource1.DataSource = dt;
                bindingNavigator1.BindingSource = this.bindingSource1;
                txbId.DataBindings.Add(new Binding("Text", bindingSource1, "BuildingID", true));
                txbTitle.DataBindings.Add(new Binding("Text", bindingSource1, "BuildingTitle", true));
            }
            if (chbClass.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                dt = lg.GetClassList();
                bindingSource1.DataSource = dt;
                bindingNavigator1.BindingSource = this.bindingSource1;
                txbId.DataBindings.Add(new Binding("Text", bindingSource1, "ClassID", true));
                txbTitle.DataBindings.Add(new Binding("Text", bindingSource1, "ClassTitle", true));
            }
            if (chbDepartment.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                dt = lg.GetDepartmentList();
                bindingSource1.DataSource = dt;
                bindingNavigator1.BindingSource = this.bindingSource1;
                txbId.DataBindings.Add(new Binding("Text", bindingSource1, "DepartmentID", true));
                txbTitle.DataBindings.Add(new Binding("Text", bindingSource1, "DepartmentTitle", true));
            }
            if (chbRoom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                dt = lg.GetRoomList();
                bindingSource1.DataSource = dt;
                bindingNavigator1.BindingSource = this.bindingSource1;
                txbId.DataBindings.Add(new Binding("Text", bindingSource1, "RoomID", true));
                txbTitle.DataBindings.Add(new Binding("Text", bindingSource1, "RoomTitle", true));
            }

        }

        private void FillForm()
        {
            LogicLayer lg = new LogicLayer();
            this.Text = lg.GetMessageFromDll(_langCode, "LocalAddressDefine");
            lblId.Text = lg.GetMessageFromDll(_langCode, "Code");
            lblTitle.Text = lg.GetMessageFromDll(_langCode, "Description");
            grbSelect.HeaderText = lg.GetMessageFromDll(_langCode, "Position");
            chbBuilding.Text = lg.GetMessageFromDll(_langCode, "Building");
            chbClass.Text = lg.GetMessageFromDll(_langCode, "Class");
            chbDepartment.Text = lg.GetMessageFromDll(_langCode, "Department");
            chbRoom.Text = lg.GetMessageFromDll(_langCode, "Room");
        }

        private void SaveNewRecordToSql()
        {
            LogicLayer lg = new LogicLayer();
            if (chbBuilding.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.SaveBuildingToSql(txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbClass.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.SaveClassToSql(txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbRoom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.SaveRoomToSql(txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbDepartment.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.SaveDepartmentToSql(txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
        }

        private void UpdateRecordInSql()
        {
            LogicLayer lg = new LogicLayer();
            if (chbBuilding.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.EditBuildingInSql(txbId.Text.Trim(), txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19); 
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbClass.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.EditClassInSql(txbId.Text.Trim(), txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbRoom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.EditRoomInSql(txbId.Text.Trim(), txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbDepartment.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.EditDepartmentInSql(txbId.Text.Trim(), txbTitle.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "SaveRecordSucsses");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(19);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
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

        private void txbTitle_TextChanged(object sender, EventArgs e)
        {
            if (txbTitle.Text == "")
            {
                saveToolStripButton.Enabled = false;
            }
        }

        private void txbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txbTitle.Text = "";
                txbTitle.Enabled = false;
                bindingSource1.Position = bindingSource1.Position - 1;
                bindingNavigatorPositionItem.Text = bindingSource1.Position.ToString();
                SetControls();
            }
            else
            {
                saveToolStripButton.Enabled = true;
            }
        }

        private void frmBulding_LtoR_Shown(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
            addNewToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "New");
            deleteToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Delete");
            saveToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Save");
            openToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Edit");
            printToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Print");
            helpToolStripButton.ToolTipText = lg.GetMessageFromDll(_langCode, "Help");
            bindingNavigatorMoveFirstItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveFirstItem");
            bindingNavigatorMoveLastItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveLastItem");
            bindingNavigatorMoveNextItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MoveNextItem");
            bindingNavigatorMovePreviousItem.ToolTipText = lg.GetMessageFromDll(_langCode, "MovePreviousItem");
            bindingNavigatorPositionItem.ToolTipText = lg.GetMessageFromDll(_langCode, "PositionItem");
            bindingNavigatorCountItem.ToolTipText = lg.GetMessageFromDll(_langCode, "CountItem");
        }

        private void bindingNavigatorCountItem_TextChanged(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
        }

        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = lg.GetMessageFromDll(_langCode, "From") + " " + string.Format("{0}", count);
        }

        private void chbBuilding_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbBuilding.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                chbClass.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbRoom.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbDepartment.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                FillDataTable();
                SetControls();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            addNewToolStripButton.Enabled = false;
            deleteToolStripButton.Enabled = false;
            saveToolStripButton.Enabled = false;
            openToolStripButton.Enabled = false;
            printToolStripButton.Enabled = false;
            _new = false;
            _edit = true;
            txbTitle.Enabled = true;
            txbTitle.Focus();
        }

        private void DeleteRecordFromSql()
        {
            LogicLayer lg = new LogicLayer();
            if (chbBuilding.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.DeleteBuildingFromSql(txbId.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(20);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbClass.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.DeleteClassFromSql(txbId.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(20);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbRoom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.DeleteRoomFromSql(txbId.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(20);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }
            if (chbDepartment.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int res = lg.DeleteDepartmentFromSql(txbId.Text.Trim());
                if (res == 1)
                {
                    string mes = lg.GetMessageFromDll(_langCode, "DeleteSuccessfull");
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();

                }
                if (res == 0)
                {
                    string mes = lg.GetErrorMessage(20);
                    frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 2);
                    frms.ShowDialog();
                    txbTitle.Text = "";
                    FillDataTable();
                    SetControls();
                }

            }

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

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            string mes = lg.GetMessageFromDll(_langCode, "DeleteNotification");
            frmShowInfoSmall_RtoL frms = new frmShowInfoSmall_RtoL(mes, 3);
            DialogResult dr = frms.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteRecordFromSql();
            }
        }

        private void chbClass_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbClass.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                chbBuilding.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbRoom.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbDepartment.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                FillDataTable();
                SetControls();
            }
        }

        private void chbRoom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbRoom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                chbBuilding.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbClass.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbDepartment.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                FillDataTable();
                SetControls();
            }
        }

        private void chbDepartment_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chbDepartment.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                chbBuilding.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbClass.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                chbRoom.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
                FillDataTable();
                SetControls();
            }
        }

        private void addNewToolStripButton_Click(object sender, EventArgs e)
        {
            addNewToolStripButton.Enabled = false;
            deleteToolStripButton.Enabled = false;
            saveToolStripButton.Enabled = false;
            openToolStripButton.Enabled = false;
            printToolStripButton.Enabled = false;
            _new = true;
            _edit = false;
            txbTitle.Enabled = true;
            txbTitle.Focus();
        }






    }
}
