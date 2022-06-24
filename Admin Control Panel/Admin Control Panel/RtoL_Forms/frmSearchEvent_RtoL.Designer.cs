namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmSearchEvent_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchEvent_RtoL));
            this.lblFromDate = new Telerik.WinControls.UI.RadLabel();
            this.lblToDate = new Telerik.WinControls.UI.RadLabel();
            this.erpDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.dapFrom = new FarsiCalendarComponent.FarsiDatePicker();
            this.dapTo = new FarsiCalendarComponent.FarsiDatePicker();
            this.grbDate = new Telerik.WinControls.UI.RadGroupBox();
            this.grbAgent = new Telerik.WinControls.UI.RadGroupBox();
            this.ddlAgentName = new Telerik.WinControls.UI.RadDropDownList();
            this.lblAgentName = new Telerik.WinControls.UI.RadLabel();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDate)).BeginInit();
            this.grbDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbAgent)).BeginInit();
            this.grbAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAgentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFromDate
            // 
            this.lblFromDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Navy;
            this.lblFromDate.Location = new System.Drawing.Point(430, 47);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 17);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "lblFromDate";
            this.lblFromDate.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblToDate
            // 
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Navy;
            this.lblToDate.Location = new System.Drawing.Point(196, 47);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(54, 17);
            this.lblToDate.TabIndex = 12;
            this.lblToDate.Text = "lblToDate";
            this.lblToDate.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // erpDate
            // 
            this.erpDate.ContainerControl = this;
            this.erpDate.RightToLeft = true;
            // 
            // dapFrom
            // 
            this.dapFrom.AutoSize = true;
            this.dapFrom.ForeColor = System.Drawing.Color.Navy;
            this.dapFrom.GeoDate = new System.DateTime(2013, 9, 4, 0, 0, 0, 0);
            this.dapFrom.Location = new System.Drawing.Point(295, 43);
            this.dapFrom.MaximumSize = new System.Drawing.Size(1000, 21);
            this.dapFrom.Name = "dapFrom";
            this.dapFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dapFrom.Size = new System.Drawing.Size(92, 21);
            this.dapFrom.TabIndex = 0;
            // 
            // dapTo
            // 
            this.dapTo.AutoSize = true;
            this.dapTo.GeoDate = new System.DateTime(2013, 9, 4, 0, 0, 0, 0);
            this.dapTo.Location = new System.Drawing.Point(49, 43);
            this.dapTo.MaximumSize = new System.Drawing.Size(1000, 21);
            this.dapTo.Name = "dapTo";
            this.dapTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dapTo.Size = new System.Drawing.Size(92, 21);
            this.dapTo.TabIndex = 1;
            // 
            // grbDate
            // 
            this.grbDate.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grbDate.Controls.Add(this.lblFromDate);
            this.grbDate.Controls.Add(this.dapTo);
            this.grbDate.Controls.Add(this.dapFrom);
            this.grbDate.Controls.Add(this.lblToDate);
            this.grbDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDate.ForeColor = System.Drawing.Color.DarkRed;
            this.grbDate.HeaderText = "grbDate";
            this.grbDate.Location = new System.Drawing.Point(27, 12);
            this.grbDate.Name = "grbDate";
            // 
            // 
            // 
            this.grbDate.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grbDate.Size = new System.Drawing.Size(512, 100);
            this.grbDate.TabIndex = 11;
            this.grbDate.Text = "grbDate";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbDate.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "grbDate";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbDate.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).ForeColor = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbDate.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbAgent
            // 
            this.grbAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grbAgent.Controls.Add(this.ddlAgentName);
            this.grbAgent.Controls.Add(this.lblAgentName);
            this.grbAgent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAgent.ForeColor = System.Drawing.Color.Crimson;
            this.grbAgent.HeaderText = "grbAgent";
            this.grbAgent.Location = new System.Drawing.Point(27, 118);
            this.grbAgent.Name = "grbAgent";
            // 
            // 
            // 
            this.grbAgent.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grbAgent.Size = new System.Drawing.Size(512, 76);
            this.grbAgent.TabIndex = 13;
            this.grbAgent.Text = "grbAgent";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.grbAgent.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(0))).ForeColor = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.grbAgent.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbAgent.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Text = "grbAgent";
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbAgent.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).ForeColor = System.Drawing.Color.Crimson;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.grbAgent.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlAgentName
            // 
            this.ddlAgentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAgentName.Location = new System.Drawing.Point(49, 31);
            this.ddlAgentName.Name = "ddlAgentName";
            this.ddlAgentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlAgentName.Size = new System.Drawing.Size(212, 19);
            this.ddlAgentName.TabIndex = 2;
            this.ddlAgentName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlAgentName_SelectedIndexChanged);
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlAgentName.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.ddlAgentName.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.Navy;
            // 
            // lblAgentName
            // 
            this.lblAgentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentName.ForeColor = System.Drawing.Color.Navy;
            this.lblAgentName.Location = new System.Drawing.Point(295, 33);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(76, 17);
            this.lblAgentName.TabIndex = 14;
            this.lblAgentName.Text = "lblAgentName";
            this.lblAgentName.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(157, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(41, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSearchEvent_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 242);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grbAgent);
            this.Controls.Add(this.grbDate);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearchEvent_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchEvent_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmSearchEvent_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbDate)).EndInit();
            this.grbDate.ResumeLayout(false);
            this.grbDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbAgent)).EndInit();
            this.grbAgent.ResumeLayout(false);
            this.grbAgent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAgentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblFromDate;
        private Telerik.WinControls.UI.RadLabel lblToDate;
        private System.Windows.Forms.ErrorProvider erpDate;
        private FarsiCalendarComponent.FarsiDatePicker dapFrom;
        private FarsiCalendarComponent.FarsiDatePicker dapTo;
        private Telerik.WinControls.UI.RadGroupBox grbDate;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadGroupBox grbAgent;
        private Telerik.WinControls.UI.RadDropDownList ddlAgentName;
        private Telerik.WinControls.UI.RadLabel lblAgentName;
    }
}
