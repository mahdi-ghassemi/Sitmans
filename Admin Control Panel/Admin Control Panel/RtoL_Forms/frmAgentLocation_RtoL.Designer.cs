namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmAgentLocation_RtoL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentLocation_RtoL));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lblBuilding = new Telerik.WinControls.UI.RadLabel();
            this.cmbBuilding = new System.Windows.Forms.ComboBox();
            this.lblClass = new Telerik.WinControls.UI.RadLabel();
            this.lblRoom = new Telerik.WinControls.UI.RadLabel();
            this.lblDepartment = new Telerik.WinControls.UI.RadLabel();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.deleteToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 209);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(453, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton1";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Visible = false;
            // 
            // lblBuilding
            // 
            this.lblBuilding.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuilding.ForeColor = System.Drawing.Color.Navy;
            this.lblBuilding.Location = new System.Drawing.Point(347, 41);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(57, 17);
            this.lblBuilding.TabIndex = 1;
            this.lblBuilding.Text = "lblBuilding";
            this.lblBuilding.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbBuilding
            // 
            this.cmbBuilding.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuilding.ForeColor = System.Drawing.Color.Navy;
            this.cmbBuilding.FormattingEnabled = true;
            this.cmbBuilding.Location = new System.Drawing.Point(68, 37);
            this.cmbBuilding.Name = "cmbBuilding";
            this.cmbBuilding.Size = new System.Drawing.Size(216, 21);
            this.cmbBuilding.TabIndex = 2;
            this.cmbBuilding.SelectedIndexChanged += new System.EventHandler(this.cmbBuilding_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.ForeColor = System.Drawing.Color.Navy;
            this.lblClass.Location = new System.Drawing.Point(347, 77);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(43, 17);
            this.lblClass.TabIndex = 3;
            this.lblClass.Text = "lblClass";
            this.lblClass.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRoom
            // 
            this.lblRoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.ForeColor = System.Drawing.Color.Navy;
            this.lblRoom.Location = new System.Drawing.Point(347, 115);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(46, 17);
            this.lblRoom.TabIndex = 4;
            this.lblRoom.Text = "lblRoom";
            this.lblRoom.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Navy;
            this.lblDepartment.Location = new System.Drawing.Point(347, 150);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(77, 17);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "lblDepartment";
            this.lblDepartment.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Navy;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(68, 73);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(216, 21);
            this.cmbClass.TabIndex = 6;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // cmbRoom
            // 
            this.cmbRoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoom.ForeColor = System.Drawing.Color.Navy;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(68, 111);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(216, 21);
            this.cmbRoom.TabIndex = 7;
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.ForeColor = System.Drawing.Color.Navy;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(68, 146);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(216, 21);
            this.cmbDepartment.TabIndex = 8;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // frmAgentLocation_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 234);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.cmbBuilding);
            this.Controls.Add(this.lblBuilding);
            this.Controls.Add(this.bindingNavigator1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximizeBox = false;
            this.Name = "frmAgentLocation_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgentLocation_RtoL";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentLocation_RtoL_FormClosing);
            this.Load += new System.EventHandler(this.frmAgentLocation_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private Telerik.WinControls.UI.RadLabel lblBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private Telerik.WinControls.UI.RadLabel lblClass;
        private Telerik.WinControls.UI.RadLabel lblRoom;
        private Telerik.WinControls.UI.RadLabel lblDepartment;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
    }
}
