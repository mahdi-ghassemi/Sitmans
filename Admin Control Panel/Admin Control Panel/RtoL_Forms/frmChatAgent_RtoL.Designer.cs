namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmChatAgent_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChatAgent_RtoL));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.btnSend = new Telerik.WinControls.UI.RadButton();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.lblSenderIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLog.Location = new System.Drawing.Point(12, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(502, 165);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // rtbMsg
            // 
            this.rtbMsg.Location = new System.Drawing.Point(12, 183);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMsg.Size = new System.Drawing.Size(412, 71);
            this.rtbMsg.TabIndex = 0;
            this.rtbMsg.Text = "";
            this.rtbMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbMsg_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(430, 211);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 24);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "btnSend";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(12, 268);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(78, 13);
            this.lblSenderName.TabIndex = 3;
            this.lblSenderName.Text = "lblSenderName";
            this.lblSenderName.Visible = false;
            // 
            // lblSenderIp
            // 
            this.lblSenderIp.AutoSize = true;
            this.lblSenderIp.Location = new System.Drawing.Point(180, 268);
            this.lblSenderIp.Name = "lblSenderIp";
            this.lblSenderIp.Size = new System.Drawing.Size(61, 13);
            this.lblSenderIp.TabIndex = 4;
            this.lblSenderIp.Text = "lblSenderIp";
            this.lblSenderIp.Visible = false;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(388, 268);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "lblPort";
            this.lblPort.Visible = false;
            // 
            // frmChatAgent_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 290);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblSenderIp);
            this.Controls.Add(this.lblSenderName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.rtbLog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChatAgent_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChatAgent_RtoL";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChatAgent_RtoL_FormClosing);
            this.Load += new System.EventHandler(this.frmChatAgent_RtoL_Load);
            this.Resize += new System.EventHandler(this.frmChatAgent_RtoL_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.btnSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private Telerik.WinControls.UI.RadButton btnSend;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Label lblSenderIp;
        private System.Windows.Forms.Label lblPort;
    }
}
