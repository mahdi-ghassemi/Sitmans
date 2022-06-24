namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmWaiting_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaiting_RtoL));
            this.timProgress = new System.Windows.Forms.Timer(this.components);
            this.wabWait = new Telerik.WinControls.UI.RadWaitingBar();
            ((System.ComponentModel.ISupportInitialize)(this.wabWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // timProgress
            // 
            this.timProgress.Tick += new System.EventHandler(this.timProgress_Tick);
            // 
            // wabWait
            // 
            this.wabWait.BackColor = System.Drawing.Color.White;
            this.wabWait.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wabWait.ForeColor = System.Drawing.Color.Maroon;
            this.wabWait.Location = new System.Drawing.Point(0, 1);
            this.wabWait.Name = "wabWait";
            this.wabWait.ShowText = true;
            this.wabWait.Size = new System.Drawing.Size(322, 33);
            this.wabWait.TabIndex = 3;
            this.wabWait.Text = "radWaitingBar1";
            this.wabWait.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.Throbber;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.wabWait.GetChildAt(0))).BackColor2 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.wabWait.GetChildAt(0))).BackColor3 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.wabWait.GetChildAt(0))).BackColor4 = System.Drawing.Color.White;
            ((Telerik.WinControls.UI.RadWaitingBarElement)(this.wabWait.GetChildAt(0))).BackColor = System.Drawing.Color.White;
            // 
            // frmWaiting_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(323, 35);
            this.ControlBox = false;
            this.Controls.Add(this.wabWait);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaiting_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWaiting_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmWaiting_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wabWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timProgress;
        private Telerik.WinControls.UI.RadWaitingBar wabWait;
    }
}
