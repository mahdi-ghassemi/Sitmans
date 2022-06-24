namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmAssignAcl_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignAcl_RtoL));
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOk = new Telerik.WinControls.UI.RadButton();
            this.cmbProfileList = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(24, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(140, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbProfileList
            // 
            this.cmbProfileList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfileList.ForeColor = System.Drawing.Color.Navy;
            this.cmbProfileList.FormattingEnabled = true;
            this.cmbProfileList.Location = new System.Drawing.Point(24, 67);
            this.cmbProfileList.Name = "cmbProfileList";
            this.cmbProfileList.Size = new System.Drawing.Size(364, 21);
            this.cmbProfileList.TabIndex = 8;
            this.cmbProfileList.SelectedIndexChanged += new System.EventHandler(this.cmbProfileList_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(24, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(367, 48);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "label1";
            // 
            // frmAssignAcl_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 153);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbProfileList);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAssignAcl_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAssignAcl_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmAssignAcl_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOk;
        private System.Windows.Forms.ComboBox cmbProfileList;
        private System.Windows.Forms.Label lblTitle;
    }
}
