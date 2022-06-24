namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmRepAgentsId_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepAgentsId_RtoL));
            this.grvAgentsId = new Telerik.WinControls.UI.RadGridView();
            this.tlsAgentList = new Telerik.WinControls.UI.RadStatusStrip();
            this.tsbPrint = new Telerik.WinControls.UI.RadButtonElement();
            this.imgPersonel = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvAgentsId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grvAgentsId
            // 
            this.grvAgentsId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvAgentsId.AutoSizeRows = true;
            this.grvAgentsId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvAgentsId.Location = new System.Drawing.Point(1, 12);
            // 
            // grvAgentsId
            // 
            this.grvAgentsId.MasterTemplate.AllowAddNewRow = false;
            this.grvAgentsId.MasterTemplate.AllowCellContextMenu = false;
            this.grvAgentsId.MasterTemplate.AllowDeleteRow = false;
            this.grvAgentsId.Name = "grvAgentsId";
            this.grvAgentsId.Size = new System.Drawing.Size(1157, 652);
            this.grvAgentsId.TabIndex = 0;
            this.grvAgentsId.Text = "radGridView1";
            this.grvAgentsId.ValueChanged += new System.EventHandler(this.grvAgentsId_ValueChanged);
            // 
            // tlsAgentList
            // 
            this.tlsAgentList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsAgentList.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tsbPrint});
            this.tlsAgentList.Location = new System.Drawing.Point(0, 651);
            this.tlsAgentList.Name = "tlsAgentList";
            this.tlsAgentList.Size = new System.Drawing.Size(1160, 47);
            this.tlsAgentList.TabIndex = 4;
            this.tlsAgentList.Text = "radStatusStrip1";
            // 
            // tsbPrint
            // 
            this.tsbPrint.AccessibleDescription = "tsbAgentSetting";
            this.tsbPrint.AccessibleName = "tsbAgentSetting";
            this.tsbPrint.AutoSize = false;
            this.tsbPrint.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbPrint.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.tsbPrint.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tsbPrint.Name = "tsbPrint";
            this.tlsAgentList.SetSpring(this.tsbPrint, false);
            this.tsbPrint.Text = "tsbPrint";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbPrint.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // imgPersonel
            // 
            this.imgPersonel.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgPersonel.ImageSize = new System.Drawing.Size(64, 64);
            this.imgPersonel.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmRepAgentsId_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 698);
            this.Controls.Add(this.tlsAgentList);
            this.Controls.Add(this.grvAgentsId);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRepAgentsId_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRepAgentsId_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRepAgentsId_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvAgentsId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grvAgentsId;
        private Telerik.WinControls.UI.RadStatusStrip tlsAgentList;
        private Telerik.WinControls.UI.RadButtonElement tsbPrint;
        private System.Windows.Forms.ImageList imgPersonel;
    }
}
