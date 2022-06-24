namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmBackupDatabase_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupDatabase_RtoL));
            this.btnBackup = new Telerik.WinControls.UI.RadButton();
            this.prbBackup = new Telerik.WinControls.UI.RadProgressBar();
            this.lblPath = new System.Windows.Forms.Label();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(23, 73);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(110, 24);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "btnBackup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // prbBackup
            // 
            this.prbBackup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbBackup.Location = new System.Drawing.Point(23, 47);
            this.prbBackup.Name = "prbBackup";
            this.prbBackup.Size = new System.Drawing.Size(493, 20);
            this.prbBackup.Step = 1;
            this.prbBackup.TabIndex = 5;
            this.prbBackup.Visible = false;
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(429, 21);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(100, 23);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "lblPath";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbPath
            // 
            this.txbPath.Location = new System.Drawing.Point(23, 21);
            this.txbPath.Name = "txbPath";
            this.txbPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath.Size = new System.Drawing.Size(400, 20);
            this.txbPath.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(139, 73);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(255, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBackupDatabase_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 111);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txbPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.prbBackup);
            this.Controls.Add(this.btnBackup);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBackupDatabase_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBackupDatabase_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmBackupDatabase_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnBackup;
        private Telerik.WinControls.UI.RadProgressBar prbBackup;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txbPath;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
