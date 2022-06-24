namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmSelectAgentForId_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectAgentForId_RtoL));
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.grbAgent = new Telerik.WinControls.UI.RadGroupBox();
            this.ddlAgentName = new Telerik.WinControls.UI.RadDropDownList();
            this.lblAgentName = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbAgent)).BeginInit();
            this.grbAgent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAgentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(36, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(152, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "btnOk";
            // 
            // grbAgent
            // 
            this.grbAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grbAgent.Controls.Add(this.ddlAgentName);
            this.grbAgent.Controls.Add(this.lblAgentName);
            this.grbAgent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAgent.ForeColor = System.Drawing.Color.Crimson;
            this.grbAgent.HeaderText = "";
            this.grbAgent.Location = new System.Drawing.Point(26, 14);
            this.grbAgent.Name = "grbAgent";
            // 
            // 
            // 
            this.grbAgent.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grbAgent.Size = new System.Drawing.Size(512, 76);
            this.grbAgent.TabIndex = 16;
            // 
            // ddlAgentName
            // 
            this.ddlAgentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAgentName.Location = new System.Drawing.Point(49, 31);
            this.ddlAgentName.Name = "ddlAgentName";
            this.ddlAgentName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ddlAgentName.Size = new System.Drawing.Size(212, 19);
            this.ddlAgentName.TabIndex = 2;
            this.ddlAgentName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlAgentName_SelectedIndexChanged);
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
            // frmSelectAgentForId_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 250);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grbAgent);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSelectAgentForId_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectAgentForId_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmSelectAgentForId_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbAgent)).EndInit();
            this.grbAgent.ResumeLayout(false);
            this.grbAgent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAgentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadGroupBox grbAgent;
        private Telerik.WinControls.UI.RadDropDownList ddlAgentName;
        private Telerik.WinControls.UI.RadLabel lblAgentName;
    }
}
