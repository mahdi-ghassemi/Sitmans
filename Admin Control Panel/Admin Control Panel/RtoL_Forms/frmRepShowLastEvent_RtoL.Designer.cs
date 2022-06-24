namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmRepShowLastEvent_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepShowLastEvent_RtoL));
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.tlsAgentList = new Telerik.WinControls.UI.RadStatusStrip();
            this.tsbPrint = new Telerik.WinControls.UI.RadButtonElement();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.AutoSizeRows = true;
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGridView1.ForeColor = System.Drawing.Color.Navy;
            this.radGridView1.Location = new System.Drawing.Point(12, 12);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.Size = new System.Drawing.Size(966, 465);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.GroupByChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.radGridView1_GroupByChanged);
            // 
            // tlsAgentList
            // 
            this.tlsAgentList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsAgentList.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tsbPrint});
            this.tlsAgentList.Location = new System.Drawing.Point(0, 482);
            this.tlsAgentList.Name = "tlsAgentList";
            this.tlsAgentList.Size = new System.Drawing.Size(990, 47);
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
            // frmRepShowLastEvent_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 529);
            this.Controls.Add(this.tlsAgentList);
            this.Controls.Add(this.radGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmRepShowLastEvent_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRepShowLastEvent_RtoL";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRepShowLastEvent_RtoL_FormClosing);
            this.Load += new System.EventHandler(this.frmRepShowLastEvent_RtoL_Load);
            this.Shown += new System.EventHandler(this.frmRepShowLastEvent_RtoL_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadStatusStrip tlsAgentList;
        private Telerik.WinControls.UI.RadButtonElement tsbPrint;
    }
}
