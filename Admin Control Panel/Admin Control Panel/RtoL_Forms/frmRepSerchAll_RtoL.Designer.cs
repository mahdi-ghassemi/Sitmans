namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmRepSerchAll_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepSerchAll_RtoL));
            this.grvRep = new Telerik.WinControls.UI.RadGridView();
            this.imgPersonel = new System.Windows.Forms.ImageList(this.components);
            this.tlsAgentList = new Telerik.WinControls.UI.RadStatusStrip();
            this.tsbPrint = new Telerik.WinControls.UI.RadButtonElement();
            ((System.ComponentModel.ISupportInitialize)(this.grvRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grvRep
            // 
            this.grvRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvRep.AutoSizeRows = true;
            this.grvRep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvRep.Location = new System.Drawing.Point(12, 38);
            // 
            // grvRep
            // 
            this.grvRep.MasterTemplate.AllowAddNewRow = false;
            this.grvRep.MasterTemplate.AllowCellContextMenu = false;
            this.grvRep.MasterTemplate.AllowColumnChooser = false;
            this.grvRep.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.grvRep.MasterTemplate.AllowDeleteRow = false;
            this.grvRep.MasterTemplate.AllowEditRow = false;
            this.grvRep.Name = "grvRep";
            this.grvRep.Size = new System.Drawing.Size(1160, 633);
            this.grvRep.TabIndex = 0;
            this.grvRep.Text = "radGridView1";
            this.grvRep.GroupByChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.grvRep_GroupByChanged);
            // 
            // imgPersonel
            // 
            this.imgPersonel.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgPersonel.ImageSize = new System.Drawing.Size(64, 64);
            this.imgPersonel.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tlsAgentList
            // 
            this.tlsAgentList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsAgentList.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tsbPrint});
            this.tlsAgentList.Location = new System.Drawing.Point(0, 651);
            this.tlsAgentList.Name = "tlsAgentList";
            this.tlsAgentList.Size = new System.Drawing.Size(1184, 47);
            this.tlsAgentList.TabIndex = 3;
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
            // frmRepSerchAll_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 698);
            this.Controls.Add(this.tlsAgentList);
            this.Controls.Add(this.grvRep);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRepSerchAll_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRepSerchAll_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmRepSerchAll_RtoL_Load);
            this.Shown += new System.EventHandler(this.frmRepSerchAll_RtoL_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grvRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grvRep;
        private System.Windows.Forms.ImageList imgPersonel;
        private Telerik.WinControls.UI.RadStatusStrip tlsAgentList;
        private Telerik.WinControls.UI.RadButtonElement tsbPrint;
    }
}
