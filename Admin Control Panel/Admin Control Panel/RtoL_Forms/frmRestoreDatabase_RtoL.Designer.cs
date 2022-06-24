namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmRestoreDatabase_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestoreDatabase_RtoL));
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.prbRestore = new Telerik.WinControls.UI.RadProgressBar();
            this.btnRestore = new Telerik.WinControls.UI.RadButton();
            this.grbSQL = new Telerik.WinControls.UI.RadGroupBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.chbSql = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbSQL)).BeginInit();
            this.grbSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(251, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(135, 178);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 24);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txbPath
            // 
            this.txbPath.Location = new System.Drawing.Point(16, 17);
            this.txbPath.Name = "txbPath";
            this.txbPath.ReadOnly = true;
            this.txbPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath.Size = new System.Drawing.Size(400, 20);
            this.txbPath.TabIndex = 10;
            // 
            // lblPath
            // 
            this.lblPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPath.Location = new System.Drawing.Point(422, 17);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(100, 23);
            this.lblPath.TabIndex = 9;
            this.lblPath.Text = "lblPath";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prbRestore
            // 
            this.prbRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbRestore.Location = new System.Drawing.Point(19, 145);
            this.prbRestore.Name = "prbRestore";
            this.prbRestore.Size = new System.Drawing.Size(511, 20);
            this.prbRestore.Step = 1;
            this.prbRestore.TabIndex = 11;
            this.prbRestore.Visible = false;
            // 
            // btnRestore
            // 
            this.btnRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Location = new System.Drawing.Point(19, 178);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(110, 24);
            this.btnRestore.TabIndex = 8;
            this.btnRestore.Text = "btnRestore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // grbSQL
            // 
            this.grbSQL.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grbSQL.Controls.Add(this.chbSql);
            this.grbSQL.Controls.Add(this.txbPassword);
            this.grbSQL.Controls.Add(this.txbUsername);
            this.grbSQL.Controls.Add(this.lblPassword);
            this.grbSQL.Controls.Add(this.lblUsername);
            this.grbSQL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSQL.ForeColor = System.Drawing.Color.Maroon;
            this.grbSQL.HeaderText = "grbSQL";
            this.grbSQL.Location = new System.Drawing.Point(19, 58);
            this.grbSQL.Name = "grbSQL";
            // 
            // 
            // 
            this.grbSQL.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grbSQL.Size = new System.Drawing.Size(508, 73);
            this.grbSQL.TabIndex = 12;
            this.grbSQL.Text = "grbSQL";
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.grbSQL.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            // 
            // txbPassword
            // 
            this.txbPassword.Enabled = false;
            this.txbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.txbPassword.Location = new System.Drawing.Point(8, 29);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPassword.Size = new System.Drawing.Size(137, 20);
            this.txbPassword.TabIndex = 13;
            // 
            // txbUsername
            // 
            this.txbUsername.Enabled = false;
            this.txbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.txbUsername.Location = new System.Drawing.Point(232, 29);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbUsername.Size = new System.Drawing.Size(158, 20);
            this.txbUsername.TabIndex = 12;
            this.txbUsername.Text = "sa";
            // 
            // lblPassword
            // 
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPassword.Location = new System.Drawing.Point(149, 27);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "lblPassword";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblUsername.Location = new System.Drawing.Point(403, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "lblUsername";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbSql
            // 
            this.chbSql.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSql.Location = new System.Drawing.Point(488, 34);
            this.chbSql.Name = "chbSql";
            this.chbSql.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chbSql.Size = new System.Drawing.Size(15, 15);
            this.chbSql.TabIndex = 13;
            this.chbSql.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chbSql_ToggleStateChanged);
            // 
            // frmRestoreDatabase_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 212);
            this.Controls.Add(this.grbSQL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txbPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.prbRestore);
            this.Controls.Add(this.btnRestore);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRestoreDatabase_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRestoreDatabase_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRestoreDatabase_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prbRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbSQL)).EndInit();
            this.grbSQL.ResumeLayout(false);
            this.grbSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chbSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Label lblPath;
        private Telerik.WinControls.UI.RadProgressBar prbRestore;
        private Telerik.WinControls.UI.RadButton btnRestore;
        private Telerik.WinControls.UI.RadGroupBox grbSQL;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private Telerik.WinControls.UI.RadCheckBox chbSql;
    }
}
