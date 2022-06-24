namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmFileTransfer_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileTransfer_RtoL));
            this.lblSender1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlSender1 = new Telerik.WinControls.UI.RadDropDownList();
            this.trvDir1 = new Telerik.WinControls.UI.RadTreeView();
            this.imlIcon = new System.Windows.Forms.ImageList(this.components);
            this.txbPath1 = new Telerik.WinControls.UI.RadTextBox();
            this.lblPath1 = new Telerik.WinControls.UI.RadLabel();
            this.lblPath2 = new Telerik.WinControls.UI.RadLabel();
            this.lblSender2 = new Telerik.WinControls.UI.RadLabel();
            this.ddlAgents2 = new Telerik.WinControls.UI.RadDropDownList();
            this.txbPath2 = new Telerik.WinControls.UI.RadTextBox();
            this.trvAgent2 = new Telerik.WinControls.UI.RadTreeView();
            this.btnCopyRtoL = new Telerik.WinControls.UI.RadButton();
            this.btnCopyLtoR = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnNewFolder = new Telerik.WinControls.UI.RadButton();
            this.btnExecute = new Telerik.WinControls.UI.RadButton();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblSender1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSender1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvDir1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSender2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgents2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvAgent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyRtoL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyLtoR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExecute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSender1
            // 
            this.lblSender1.AutoSize = false;
            this.lblSender1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSender1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblSender1.Location = new System.Drawing.Point(786, 38);
            this.lblSender1.Name = "lblSender1";
            this.lblSender1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblSender1.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSender1.Size = new System.Drawing.Size(165, 18);
            this.lblSender1.TabIndex = 3;
            this.lblSender1.Text = "lblSender";
            this.lblSender1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblSender1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblSender1.GetChildAt(0))).Text = "lblSender";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.lblSender1.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlSender1
            // 
            this.ddlSender1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlSender1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSender1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.ddlSender1.Location = new System.Drawing.Point(550, 37);
            this.ddlSender1.Name = "ddlSender1";
            this.ddlSender1.Size = new System.Drawing.Size(230, 19);
            this.ddlSender1.TabIndex = 4;
            this.ddlSender1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlSender1_SelectedIndexChanged);
            this.ddlSender1.Click += new System.EventHandler(this.ddlSender1_Click);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlSender1.GetChildAt(0))).RightToLeft = true;
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlSender1.GetChildAt(0))).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlSender1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlSender1.GetChildAt(0).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlSender1.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // trvDir1
            // 
            this.trvDir1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvDir1.Location = new System.Drawing.Point(550, 98);
            this.trvDir1.Name = "trvDir1";
            this.trvDir1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trvDir1.Size = new System.Drawing.Size(393, 438);
            this.trvDir1.SpacingBetweenNodes = -1;
            this.trvDir1.TabIndex = 5;
            this.trvDir1.Text = "radTreeView1";
            this.trvDir1.NodeMouseClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.trvDir1_NodeMouseClick);
            // 
            // imlIcon
            // 
            this.imlIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcon.ImageStream")));
            this.imlIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imlIcon.Images.SetKeyName(0, "Harddisk24.png");
            this.imlIcon.Images.SetKeyName(1, "RecycleBin24.png");
            this.imlIcon.Images.SetKeyName(2, "folder24.png");
            // 
            // txbPath1
            // 
            this.txbPath1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.txbPath1.Location = new System.Drawing.Point(550, 66);
            this.txbPath1.Name = "txbPath1";
            this.txbPath1.ReadOnly = true;
            this.txbPath1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath1.Size = new System.Drawing.Size(230, 20);
            this.txbPath1.TabIndex = 6;
            this.txbPath1.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbPath1.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbPath1.GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.txbPath1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            // 
            // lblPath1
            // 
            this.lblPath1.AutoSize = false;
            this.lblPath1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPath1.Location = new System.Drawing.Point(786, 68);
            this.lblPath1.Name = "lblPath1";
            this.lblPath1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblPath1.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPath1.Size = new System.Drawing.Size(165, 18);
            this.lblPath1.TabIndex = 7;
            this.lblPath1.Text = "lblPath";
            this.lblPath1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPath1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPath1.GetChildAt(0))).Text = "lblPath";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.lblPath1.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPath2
            // 
            this.lblPath2.AutoSize = false;
            this.lblPath2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPath2.Location = new System.Drawing.Point(257, 68);
            this.lblPath2.Name = "lblPath2";
            this.lblPath2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblPath2.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPath2.Size = new System.Drawing.Size(165, 18);
            this.lblPath2.TabIndex = 12;
            this.lblPath2.Text = "lblPath2";
            this.lblPath2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPath2.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblPath2.GetChildAt(0))).Text = "lblPath2";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.lblPath2.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSender2
            // 
            this.lblSender2.AutoSize = false;
            this.lblSender2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSender2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblSender2.Location = new System.Drawing.Point(257, 38);
            this.lblSender2.Name = "lblSender2";
            this.lblSender2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.lblSender2.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSender2.Size = new System.Drawing.Size(165, 18);
            this.lblSender2.TabIndex = 8;
            this.lblSender2.Text = "lblSender2";
            this.lblSender2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblSender2.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadLabelElement)(this.lblSender2.GetChildAt(0))).Text = "lblSender2";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.lblSender2.GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlAgents2
            // 
            this.ddlAgents2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAgents2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.ddlAgents2.Location = new System.Drawing.Point(12, 37);
            this.ddlAgents2.Name = "ddlAgents2";
            this.ddlAgents2.Size = new System.Drawing.Size(230, 19);
            this.ddlAgents2.TabIndex = 13;
            this.ddlAgents2.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlAgents2_SelectedIndexChanged);
            this.ddlAgents2.Click += new System.EventHandler(this.ddlAgents2_Click);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlAgents2.GetChildAt(0))).RightToLeft = true;
            ((Telerik.WinControls.UI.RadDropDownTextBoxElement)(this.ddlAgents2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.ddlAgents2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlAgents2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.ddlAgents2.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // txbPath2
            // 
            this.txbPath2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.txbPath2.Location = new System.Drawing.Point(12, 66);
            this.txbPath2.Name = "txbPath2";
            this.txbPath2.ReadOnly = true;
            this.txbPath2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath2.Size = new System.Drawing.Size(230, 20);
            this.txbPath2.TabIndex = 14;
            this.txbPath2.TabStop = false;
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbPath2.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.txbPath2.GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.txbPath2.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            // 
            // trvAgent2
            // 
            this.trvAgent2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvAgent2.Location = new System.Drawing.Point(12, 98);
            this.trvAgent2.Name = "trvAgent2";
            this.trvAgent2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trvAgent2.Size = new System.Drawing.Size(393, 438);
            this.trvAgent2.SpacingBetweenNodes = -1;
            this.trvAgent2.TabIndex = 15;
            this.trvAgent2.Text = "radTreeView1";
            this.trvAgent2.NodeMouseClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.trvAgent2_NodeMouseClick);
            // 
            // btnCopyRtoL
            // 
            this.btnCopyRtoL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyRtoL.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyRtoL.Image")));
            this.btnCopyRtoL.Location = new System.Drawing.Point(420, 271);
            this.btnCopyRtoL.Name = "btnCopyRtoL";
            this.btnCopyRtoL.Size = new System.Drawing.Size(110, 38);
            this.btnCopyRtoL.TabIndex = 16;
            this.btnCopyRtoL.Text = "btnCopyRtoL";
            this.btnCopyRtoL.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyRtoL.Click += new System.EventHandler(this.btnCopyRtoL_Click);
            // 
            // btnCopyLtoR
            // 
            this.btnCopyLtoR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyLtoR.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyLtoR.Image")));
            this.btnCopyLtoR.Location = new System.Drawing.Point(420, 315);
            this.btnCopyLtoR.Name = "btnCopyLtoR";
            this.btnCopyLtoR.Size = new System.Drawing.Size(110, 37);
            this.btnCopyLtoR.TabIndex = 17;
            this.btnCopyLtoR.Text = "btnCopyLtoR";
            this.btnCopyLtoR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(666, 551);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 24);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "btnDelete";
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFolder.Location = new System.Drawing.Point(550, 551);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(110, 24);
            this.btnNewFolder.TabIndex = 19;
            this.btnNewFolder.Text = "btnNewFolder";
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(782, 551);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(110, 24);
            this.btnExecute.TabIndex = 20;
            this.btnExecute.Text = "btnExecute";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(420, 412);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 33);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "btnRefresh";
            // 
            // frmFileTransfer_RtoL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 599);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopyLtoR);
            this.Controls.Add(this.btnCopyRtoL);
            this.Controls.Add(this.trvAgent2);
            this.Controls.Add(this.txbPath2);
            this.Controls.Add(this.ddlAgents2);
            this.Controls.Add(this.lblPath2);
            this.Controls.Add(this.lblSender2);
            this.Controls.Add(this.lblPath1);
            this.Controls.Add(this.txbPath1);
            this.Controls.Add(this.trvDir1);
            this.Controls.Add(this.ddlSender1);
            this.Controls.Add(this.lblSender1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmFileTransfer_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFileTransfer_RtoL";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmFileTransfer_RtoL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblSender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSender1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvDir1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPath2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSender2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAgents2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvAgent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyRtoL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyLtoR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExecute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblSender1;
        private Telerik.WinControls.UI.RadDropDownList ddlSender1;
        private Telerik.WinControls.UI.RadTreeView trvDir1;
        private System.Windows.Forms.ImageList imlIcon;
        private Telerik.WinControls.UI.RadTextBox txbPath1;
        private Telerik.WinControls.UI.RadLabel lblPath1;
        private Telerik.WinControls.UI.RadLabel lblPath2;
        private Telerik.WinControls.UI.RadLabel lblSender2;
        private Telerik.WinControls.UI.RadDropDownList ddlAgents2;
        private Telerik.WinControls.UI.RadTextBox txbPath2;
        private Telerik.WinControls.UI.RadTreeView trvAgent2;
        private Telerik.WinControls.UI.RadButton btnCopyRtoL;
        private Telerik.WinControls.UI.RadButton btnCopyLtoR;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnNewFolder;
        private Telerik.WinControls.UI.RadButton btnExecute;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
