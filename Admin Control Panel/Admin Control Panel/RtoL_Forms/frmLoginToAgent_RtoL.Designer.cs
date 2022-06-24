namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmLoginToAgent_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginToAgent_RtoL));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.txbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.erpPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(289, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(33, 78);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 24);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "btnExit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.AutoSize = false;
            this.txbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.ForeColor = System.Drawing.Color.Maroon;
            this.txbPassword.Location = new System.Drawing.Point(33, 41);
            this.txbPassword.MaxLength = 30;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.txbPassword.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txbPassword.Size = new System.Drawing.Size(247, 22);
            this.txbPassword.TabIndex = 5;
            this.txbPassword.TabStop = false;
            this.txbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbPassword.ThemeName = "ControlDefault";
            this.txbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPassword_KeyDown);
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.txbPassword.GetChildAt(0).GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(170, 78);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // erpPassword
            // 
            this.erpPassword.ContainerControl = this;
            this.erpPassword.RightToLeft = true;
            // 
            // frmLoginToAgent_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 117);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLoginToAgent_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoginToAgent_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmLoginToAgent_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadTextBox txbPassword;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.ErrorProvider erpPassword;
    }
}
