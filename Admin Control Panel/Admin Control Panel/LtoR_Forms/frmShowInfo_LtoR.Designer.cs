namespace Admin_Control_Panel.LtoR_Forms
{
    partial class frmShowInfo_LtoR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowInfo_LtoR));
            this.btn1 = new Telerik.WinControls.UI.RadButton();
            this.btn2 = new Telerik.WinControls.UI.RadButton();
            this.btn3 = new Telerik.WinControls.UI.RadButton();
            this.lblInfo1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(19, 88);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(117, 24);
            this.btn1.TabIndex = 10;
            this.btn1.Text = "btn1";
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(160, 88);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(117, 24);
            this.btn2.TabIndex = 9;
            this.btn2.Text = "btn2";
            this.btn2.Visible = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(297, 88);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(117, 24);
            this.btn3.TabIndex = 8;
            this.btn3.Text = "btn3";
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = false;
            this.lblInfo1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInfo1.Location = new System.Drawing.Point(19, 10);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInfo1.Size = new System.Drawing.Size(395, 49);
            this.lblInfo1.TabIndex = 7;
            this.lblInfo1.Text = "lblInfo1";
            this.lblInfo1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmShowInfo_LtoR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 122);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.lblInfo1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmShowInfo_LtoR";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowInfo_LtoR";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmShowInfo_LtoR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn1;
        private Telerik.WinControls.UI.RadButton btn2;
        private Telerik.WinControls.UI.RadButton btn3;
        private Telerik.WinControls.UI.RadLabel lblInfo1;
    }
}
