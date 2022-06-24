namespace Admin_Control_Panel.LtoR_Forms
{
    partial class frmLogin_LtoR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin_LtoR));
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.txbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.lblPassword = new Telerik.WinControls.UI.RadLabel();
            this.lblUsername = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.txbUsername = new Telerik.WinControls.UI.RadTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(123, 118);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.ForeColor = System.Drawing.Color.Navy;
            this.txbPassword.Location = new System.Drawing.Point(123, 70);
            this.txbPassword.MaxLength = 32;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPassword.Size = new System.Drawing.Size(154, 19);
            this.txbPassword.TabIndex = 8;
            this.txbPassword.TabStop = false;
            this.txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPassword_KeyDown);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbPassword.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(129)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = false;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPassword.Location = new System.Drawing.Point(0, 71);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(117, 18);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "lblPassword";
            this.lblPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = false;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsername.Location = new System.Drawing.Point(0, 35);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(117, 18);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "lblUsername";
            this.lblUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(266, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.ForeColor = System.Drawing.Color.Navy;
            this.txbUsername.Location = new System.Drawing.Point(123, 34);
            this.txbUsername.MaxLength = 32;
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbUsername.Size = new System.Drawing.Size(154, 19);
            this.txbUsername.TabIndex = 7;
            this.txbUsername.TabStop = false;
            this.txbUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbUsername_KeyDown);
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbUsername.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbUsername.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(24)))), ((int)(((byte)(129)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbUsername.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin_LtoR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 159);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin_LtoR";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin_LtoR";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmLogin_LtoR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadTextBox txbPassword;
        private Telerik.WinControls.UI.RadLabel lblPassword;
        private Telerik.WinControls.UI.RadLabel lblUsername;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadTextBox txbUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
