namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmAgentUpdate_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentUpdate_RtoL));
            this.lblPath = new System.Windows.Forms.Label();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txbIPAddress = new Telerik.WinControls.UI.RadMaskedEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbIPAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(273, 75);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(39, 13);
            this.lblPath.TabIndex = 10;
            this.lblPath.Text = "lblPath";
            // 
            // txbPath
            // 
            this.txbPath.Location = new System.Drawing.Point(81, 68);
            this.txbPath.Name = "txbPath";
            this.txbPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath.Size = new System.Drawing.Size(152, 20);
            this.txbPath.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(138, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(12, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(273, 35);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(66, 13);
            this.lblIPAddress.TabIndex = 11;
            this.lblIPAddress.Text = "lblIPAddress";
            // 
            // txbIPAddress
            // 
            this.txbIPAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIPAddress.ForeColor = System.Drawing.Color.Navy;
            this.txbIPAddress.Location = new System.Drawing.Point(81, 29);
            this.txbIPAddress.MaskType = Telerik.WinControls.UI.MaskType.IP;
            this.txbIPAddress.Name = "txbIPAddress";
            this.txbIPAddress.Size = new System.Drawing.Size(152, 19);
            this.txbIPAddress.TabIndex = 12;
            this.txbIPAddress.TabStop = false;
            this.txbIPAddress.Text = "   .   .   .   ";
            // 
            // frmAgentUpdate_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 157);
            this.Controls.Add(this.txbIPAddress);
            this.Controls.Add(this.lblIPAddress);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txbPath);
            this.Controls.Add(this.lblPath);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAgentUpdate_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgentUpdate_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmAgentUpdate_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbIPAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txbPath;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.Label lblIPAddress;
        private Telerik.WinControls.UI.RadMaskedEditBox txbIPAddress;
    }
}
