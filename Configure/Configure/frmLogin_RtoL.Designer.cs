namespace Configure
{
    partial class frmLogin_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin_RtoL));
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.txbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.erpPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(27, 93);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 24);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "btnExit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(164, 93);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.AutoSize = false;
            this.txbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txbPassword.Location = new System.Drawing.Point(27, 43);
            this.txbPassword.MaxLength = 32;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.txbPassword.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txbPassword.Size = new System.Drawing.Size(247, 22);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.TabStop = false;
            this.txbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbPassword.ThemeName = "ControlDefault";
            this.txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPassword_KeyDown);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(283, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // erpPassword
            // 
            this.erpPassword.ContainerControl = this;
            this.erpPassword.RightToLeft = true;
            // 
            // frmLogin_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(367, 129);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmLogin_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnOk;
        private Telerik.WinControls.UI.RadTextBox txbPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider erpPassword;
    }
}
