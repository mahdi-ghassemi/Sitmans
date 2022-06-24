namespace Admin_Control_Panel.RtoL_Forms
{
    partial class frmAgentsView_RtoL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentsView_RtoL));
            this.tlsAgentList = new Telerik.WinControls.UI.RadStatusStrip();
            this.tsbAgentCheckStatus = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbRefreshList = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbAgentSetting = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbAgentAlarm = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbACL = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbAgentsId = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbView = new Telerik.WinControls.UI.RadSplitButtonElement();
            this.mniList = new Telerik.WinControls.UI.RadMenuItem();
            this.mniIcon = new Telerik.WinControls.UI.RadMenuItem();
            this.mniDetails = new Telerik.WinControls.UI.RadMenuItem();
            this.tsbSendFile = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbVideo = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbSendCommand = new Telerik.WinControls.UI.RadButtonElement();
            this.tsbAgentChat = new Telerik.WinControls.UI.RadButtonElement();
            this.livAgentList = new Telerik.WinControls.UI.RadListView();
            this.imlPerssonel = new System.Windows.Forms.ImageList(this.components);
            this.commandBarRowElement3 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.imlLargeImage = new System.Windows.Forms.ImageList(this.components);
            this.imlAlert = new System.Windows.Forms.ImageList(this.components);
            this.cmlSort = new Telerik.WinControls.UI.CommandBarLabel();
            this.commandBarStripElement2 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarRowElement2 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslSort = new System.Windows.Forms.ToolStripLabel();
            this.tcmSort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslGroup = new System.Windows.Forms.ToolStripLabel();
            this.tcmGroup = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslFilter = new System.Windows.Forms.ToolStripLabel();
            this.txbSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCountTitle = new System.Windows.Forms.ToolStripLabel();
            this.lblCount = new System.Windows.Forms.ToolStripLabel();
            this.cmsAgent = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.cmiEvents = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiAlertAssign = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiSettingAssign = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.cmiSendCommand = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiChatToAgent = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiRD = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiCommandBox = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiShutdown = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiRestart = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.cmiMonitorOff = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiMonitorOn = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem3 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.cmiOpenCD = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiCloseCD = new Telerik.WinControls.UI.RadMenuItem();
            this.cmiVC = new Telerik.WinControls.UI.RadMenuItem();
            this.timRefreshList = new System.Windows.Forms.Timer(this.components);
            this.timReportCheck = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livAgentList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsAgentList
            // 
            this.tlsAgentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlsAgentList.Dock = System.Windows.Forms.DockStyle.None;
            this.tlsAgentList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlsAgentList.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.tsbAgentCheckStatus,
            this.tsbRefreshList,
            this.tsbAgentSetting,
            this.tsbAgentAlarm,
            this.tsbACL,
            this.tsbAgentsId,
            this.tsbView,
            this.tsbSendFile,
            this.tsbVideo,
            this.tsbSendCommand,
            this.tsbAgentChat});
            this.tlsAgentList.Location = new System.Drawing.Point(0, 573);
            this.tlsAgentList.Name = "tlsAgentList";
            this.tlsAgentList.Size = new System.Drawing.Size(1142, 47);
            this.tlsAgentList.TabIndex = 2;
            this.tlsAgentList.Text = "radStatusStrip1";
            // 
            // tsbAgentCheckStatus
            // 
            this.tsbAgentCheckStatus.AccessibleDescription = "tsbAgentCheckStatus";
            this.tsbAgentCheckStatus.AccessibleName = "tsbAgentCheckStatus";
            this.tsbAgentCheckStatus.AutoSize = false;
            this.tsbAgentCheckStatus.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbAgentCheckStatus.DisplayStyle = Telerik.WinControls.DisplayStyle.ImageAndText;
            this.tsbAgentCheckStatus.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgentCheckStatus.Image")));
            this.tsbAgentCheckStatus.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAgentCheckStatus.Name = "tsbAgentCheckStatus";
            this.tlsAgentList.SetSpring(this.tsbAgentCheckStatus, false);
            this.tsbAgentCheckStatus.Text = "tsbAgentCheckStatus";
            this.tsbAgentCheckStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAgentCheckStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbAgentCheckStatus.Click += new System.EventHandler(this.tsbAgentCheckStatus_Click);
            // 
            // tsbRefreshList
            // 
            this.tsbRefreshList.AccessibleDescription = "tsbRefreshList";
            this.tsbRefreshList.AccessibleName = "tsbRefreshList";
            this.tsbRefreshList.AutoSize = false;
            this.tsbRefreshList.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshList.Image")));
            this.tsbRefreshList.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbRefreshList.Name = "tsbRefreshList";
            this.tlsAgentList.SetSpring(this.tsbRefreshList, false);
            this.tsbRefreshList.Text = "tsbRefreshList";
            this.tsbRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefreshList.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbRefreshList.Click += new System.EventHandler(this.tsbRefreshList_Click);
            // 
            // tsbAgentSetting
            // 
            this.tsbAgentSetting.AccessibleDescription = "tsbAgentSetting";
            this.tsbAgentSetting.AccessibleName = "tsbAgentSetting";
            this.tsbAgentSetting.AutoSize = false;
            this.tsbAgentSetting.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbAgentSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgentSetting.Image")));
            this.tsbAgentSetting.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAgentSetting.Name = "tsbAgentSetting";
            this.tlsAgentList.SetSpring(this.tsbAgentSetting, false);
            this.tsbAgentSetting.Text = "tsbAgentSetting";
            this.tsbAgentSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAgentSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbAgentSetting.Click += new System.EventHandler(this.tsbAgentSetting_Click);
            // 
            // tsbAgentAlarm
            // 
            this.tsbAgentAlarm.AccessibleDescription = "tsbAgentAlarm";
            this.tsbAgentAlarm.AccessibleName = "tsbAgentAlarm";
            this.tsbAgentAlarm.AutoSize = false;
            this.tsbAgentAlarm.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbAgentAlarm.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgentAlarm.Image")));
            this.tsbAgentAlarm.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAgentAlarm.Name = "tsbAgentAlarm";
            this.tlsAgentList.SetSpring(this.tsbAgentAlarm, false);
            this.tsbAgentAlarm.Text = "tsbAgentAlarm";
            this.tsbAgentAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAgentAlarm.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbAgentAlarm.Click += new System.EventHandler(this.tsbAgentFilter_Click);
            // 
            // tsbACL
            // 
            this.tsbACL.AccessibleDescription = "tsbACL";
            this.tsbACL.AccessibleName = "tsbACL";
            this.tsbACL.AutoSize = false;
            this.tsbACL.Bounds = new System.Drawing.Rectangle(0, 0, 95, 41);
            this.tsbACL.Image = ((System.Drawing.Image)(resources.GetObject("tsbACL.Image")));
            this.tsbACL.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbACL.Name = "tsbACL";
            this.tlsAgentList.SetSpring(this.tsbACL, false);
            this.tsbACL.Text = "tsbACL";
            this.tsbACL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbACL.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbACL.Click += new System.EventHandler(this.tsbACL_Click);
            // 
            // tsbAgentsId
            // 
            this.tsbAgentsId.AccessibleDescription = "tsbAgentId";
            this.tsbAgentsId.AccessibleName = "tsbAgentId";
            this.tsbAgentsId.AutoSize = false;
            this.tsbAgentsId.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbAgentsId.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgentsId.Image")));
            this.tsbAgentsId.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAgentsId.Name = "tsbAgentsId";
            this.tlsAgentList.SetSpring(this.tsbAgentsId, false);
            this.tsbAgentsId.Text = "tsbAgentsId";
            this.tsbAgentsId.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAgentsId.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.tsbAgentsId.Click += new System.EventHandler(this.tsbAgentsId_Click);
            // 
            // tsbView
            // 
            this.tsbView.AccessibleDescription = "tsbView";
            this.tsbView.AccessibleName = "tsbView";
            this.tsbView.ArrowButtonMinSize = new System.Drawing.Size(12, 12);
            this.tsbView.AutoSize = false;
            this.tsbView.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbView.DefaultItem = null;
            this.tsbView.DropDownDirection = Telerik.WinControls.UI.RadDirection.Up;
            this.tsbView.ExpandArrowButton = false;
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbView.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mniList,
            this.mniIcon,
            this.mniDetails});
            this.tsbView.Name = "tsbView";
            this.tlsAgentList.SetSpring(this.tsbView, false);
            this.tsbView.Text = "tsbView";
            this.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbView.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mniList
            // 
            this.mniList.AccessibleDescription = "list";
            this.mniList.AccessibleName = "list";
            this.mniList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mniList.ForeColor = System.Drawing.Color.Navy;
            this.mniList.IsChecked = true;
            this.mniList.Name = "mniList";
            this.mniList.Text = "list";
            this.mniList.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.mniList.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mniIcon
            // 
            this.mniIcon.AccessibleDescription = "radMenuItem1";
            this.mniIcon.AccessibleName = "radMenuItem1";
            this.mniIcon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mniIcon.ForeColor = System.Drawing.Color.Navy;
            this.mniIcon.Name = "mniIcon";
            this.mniIcon.Text = "radMenuItem1";
            this.mniIcon.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mniDetails
            // 
            this.mniDetails.AccessibleDescription = "radMenuItem1";
            this.mniDetails.AccessibleName = "radMenuItem1";
            this.mniDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mniDetails.ForeColor = System.Drawing.Color.Navy;
            this.mniDetails.Name = "mniDetails";
            this.mniDetails.Text = "radMenuItem1";
            this.mniDetails.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // tsbSendFile
            // 
            this.tsbSendFile.AccessibleDescription = "tsbSendFile";
            this.tsbSendFile.AccessibleName = "tsbSendFile";
            this.tsbSendFile.AutoSize = false;
            this.tsbSendFile.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbSendFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbSendFile.Image")));
            this.tsbSendFile.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbSendFile.Name = "tsbSendFile";
            this.tlsAgentList.SetSpring(this.tsbSendFile, false);
            this.tsbSendFile.Text = "tsbSendFile";
            this.tsbSendFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSendFile.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.tsbSendFile.Click += new System.EventHandler(this.tsbSendFile_Click);
            // 
            // tsbVideo
            // 
            this.tsbVideo.AccessibleDescription = "tsbvideo";
            this.tsbVideo.AccessibleName = "tsbvideo";
            this.tsbVideo.AutoSize = false;
            this.tsbVideo.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbVideo.Image = ((System.Drawing.Image)(resources.GetObject("tsbVideo.Image")));
            this.tsbVideo.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbVideo.Name = "tsbVideo";
            this.tlsAgentList.SetSpring(this.tsbVideo, false);
            this.tsbVideo.Text = "tsbvideo";
            this.tsbVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVideo.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // tsbSendCommand
            // 
            this.tsbSendCommand.AccessibleDescription = "tsbSendCommand";
            this.tsbSendCommand.AccessibleName = "tsbSendCommand";
            this.tsbSendCommand.AutoSize = false;
            this.tsbSendCommand.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbSendCommand.Image = ((System.Drawing.Image)(resources.GetObject("tsbSendCommand.Image")));
            this.tsbSendCommand.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbSendCommand.Name = "tsbSendCommand";
            this.tlsAgentList.SetSpring(this.tsbSendCommand, false);
            this.tsbSendCommand.Text = "tsbSendCommand";
            this.tsbSendCommand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSendCommand.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // tsbAgentChat
            // 
            this.tsbAgentChat.AccessibleDescription = "tsbAgentChat";
            this.tsbAgentChat.AccessibleName = "tsbAgentChat";
            this.tsbAgentChat.AutoSize = false;
            this.tsbAgentChat.Bounds = new System.Drawing.Rectangle(0, 0, 90, 41);
            this.tsbAgentChat.Image = ((System.Drawing.Image)(resources.GetObject("tsbAgentChat.Image")));
            this.tsbAgentChat.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAgentChat.Name = "tsbAgentChat";
            this.tlsAgentList.SetSpring(this.tsbAgentChat, false);
            this.tsbAgentChat.Text = "tsbAgentChat";
            this.tsbAgentChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAgentChat.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.tsbAgentChat.Click += new System.EventHandler(this.tsbAgentChat_Click);
            // 
            // livAgentList
            // 
            this.livAgentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.livAgentList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livAgentList.ImageList = this.imlPerssonel;
            this.livAgentList.ImageScalingSize = new System.Drawing.Size(200, 100);
            this.livAgentList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.livAgentList.ItemSize = new System.Drawing.Size(200, 100);
            this.livAgentList.Location = new System.Drawing.Point(12, 59);
            this.livAgentList.Name = "livAgentList";
            this.livAgentList.Size = new System.Drawing.Size(1118, 484);
            this.livAgentList.TabIndex = 3;
            this.livAgentList.Text = "radListView1";
            this.livAgentList.ViewTypeChanged += new System.EventHandler(this.livAgentList_ViewTypeChanged);
            this.livAgentList.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.livAgentList_ItemMouseDoubleClick);
            this.livAgentList.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(this.livAgentList_VisualItemFormatting);
            this.livAgentList.VisualItemCreating += new Telerik.WinControls.UI.ListViewVisualItemCreatingEventHandler(this.livAgentList_VisualItemCreating);
            this.livAgentList.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(this.livAgentList_CellFormatting);
            this.livAgentList.ItemDataBound += new Telerik.WinControls.UI.ListViewItemEventHandler(this.livAgentList_ItemDataBound);
            this.livAgentList.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.livAgentList_ColumnCreating);
            this.livAgentList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.livAgentList_MouseUp);
            // 
            // imlPerssonel
            // 
            this.imlPerssonel.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlPerssonel.ImageSize = new System.Drawing.Size(200, 100);
            this.imlPerssonel.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // commandBarRowElement3
            // 
            this.commandBarRowElement3.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement3.Text = "";
            // 
            // imlLargeImage
            // 
            this.imlLargeImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlLargeImage.ImageSize = new System.Drawing.Size(128, 128);
            this.imlLargeImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imlAlert
            // 
            this.imlAlert.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlAlert.ImageSize = new System.Drawing.Size(16, 16);
            this.imlAlert.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmlSort
            // 
            this.cmlSort.AccessibleDescription = "Sort by:";
            this.cmlSort.AccessibleName = "Sort by:";
            this.cmlSort.DisplayName = "commandBarLabel1";
            this.cmlSort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmlSort.ForeColor = System.Drawing.Color.Navy;
            this.cmlSort.Name = "cmlSort";
            this.cmlSort.Text = "Sort by:";
            this.cmlSort.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarStripElement2
            // 
            this.commandBarStripElement2.DisplayName = "commandBarStripElement2";
            this.commandBarStripElement2.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmlSort});
            this.commandBarStripElement2.Name = "commandBarStripElement2";
            // 
            // commandBarRowElement2
            // 
            this.commandBarRowElement2.MinSize = new System.Drawing.Size(25, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSort,
            this.tcmSort,
            this.toolStripSeparator1,
            this.tslGroup,
            this.tcmGroup,
            this.toolStripSeparator2,
            this.toolStripSeparator3,
            this.tslFilter,
            this.txbSearch,
            this.toolStripSeparator5,
            this.toolStripSeparator4,
            this.lblCountTitle,
            this.lblCount});
            this.toolStrip1.Location = new System.Drawing.Point(12, 13);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1121, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslSort
            // 
            this.tslSort.Name = "tslSort";
            this.tslSort.Size = new System.Drawing.Size(47, 22);
            this.tslSort.Text = "Sort by:";
            // 
            // tcmSort
            // 
            this.tcmSort.ForeColor = System.Drawing.Color.Navy;
            this.tcmSort.Name = "tcmSort";
            this.tcmSort.Size = new System.Drawing.Size(121, 25);
            this.tcmSort.SelectedIndexChanged += new System.EventHandler(this.tcmSort_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslGroup
            // 
            this.tslGroup.Name = "tslGroup";
            this.tslGroup.Size = new System.Drawing.Size(59, 22);
            this.tslGroup.Text = "Group by:";
            // 
            // tcmGroup
            // 
            this.tcmGroup.ForeColor = System.Drawing.Color.Navy;
            this.tcmGroup.Name = "tcmGroup";
            this.tcmGroup.Size = new System.Drawing.Size(121, 25);
            this.tcmGroup.SelectedIndexChanged += new System.EventHandler(this.tcmGroup_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tslFilter
            // 
            this.tslFilter.Name = "tslFilter";
            this.tslFilter.Size = new System.Drawing.Size(39, 22);
            this.tslFilter.Text = "Filter :";
            // 
            // txbSearch
            // 
            this.txbSearch.AutoSize = false;
            this.txbSearch.ForeColor = System.Drawing.Color.Navy;
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(300, 25);
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCountTitle
            // 
            this.lblCountTitle.Name = "lblCountTitle";
            this.lblCountTitle.Size = new System.Drawing.Size(76, 22);
            this.lblCountTitle.Text = "lblCountTitle";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(53, 22);
            this.lblCount.Text = "lblCount";
            // 
            // cmsAgent
            // 
            this.cmsAgent.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.cmiEvents,
            this.cmiAlertAssign,
            this.cmiSettingAssign,
            this.radMenuSeparatorItem1,
            this.cmiSendCommand,
            this.cmiChatToAgent,
            this.cmiRD,
            this.cmiCommandBox,
            this.cmiVC});
            // 
            // cmiEvents
            // 
            this.cmiEvents.AccessibleDescription = "cmiEvents";
            this.cmiEvents.AccessibleName = "cmiEvents";
            this.cmiEvents.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiEvents.Image = ((System.Drawing.Image)(resources.GetObject("cmiEvents.Image")));
            this.cmiEvents.Name = "cmiEvents";
            this.cmiEvents.RightToLeft = true;
            this.cmiEvents.Text = "cmiEvents";
            this.cmiEvents.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiAlertAssign
            // 
            this.cmiAlertAssign.AccessibleDescription = "cmiAlertAssign";
            this.cmiAlertAssign.AccessibleName = "cmiAlertAssign";
            this.cmiAlertAssign.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiAlertAssign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiAlertAssign.Image = ((System.Drawing.Image)(resources.GetObject("cmiAlertAssign.Image")));
            this.cmiAlertAssign.Name = "cmiAlertAssign";
            this.cmiAlertAssign.RightToLeft = true;
            this.cmiAlertAssign.Text = "cmiAlertAssign";
            this.cmiAlertAssign.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiSettingAssign
            // 
            this.cmiSettingAssign.AccessibleDescription = "cmiSettingAssign";
            this.cmiSettingAssign.AccessibleName = "cmiSettingAssign";
            this.cmiSettingAssign.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiSettingAssign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiSettingAssign.Image = ((System.Drawing.Image)(resources.GetObject("cmiSettingAssign.Image")));
            this.cmiSettingAssign.Name = "cmiSettingAssign";
            this.cmiSettingAssign.RightToLeft = true;
            this.cmiSettingAssign.Text = "cmiSettingAssign";
            this.cmiSettingAssign.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.RightToLeft = true;
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiSendCommand
            // 
            this.cmiSendCommand.AccessibleDescription = "cmiSendCommand";
            this.cmiSendCommand.AccessibleName = "cmiSendCommand";
            this.cmiSendCommand.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiSendCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiSendCommand.Image = ((System.Drawing.Image)(resources.GetObject("cmiSendCommand.Image")));
            this.cmiSendCommand.Name = "cmiSendCommand";
            this.cmiSendCommand.RightToLeft = true;
            this.cmiSendCommand.Text = "cmiSendCommand";
            this.cmiSendCommand.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiChatToAgent
            // 
            this.cmiChatToAgent.AccessibleDescription = "cmiChatToAgent";
            this.cmiChatToAgent.AccessibleName = "cmiChatToAgent";
            this.cmiChatToAgent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiChatToAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiChatToAgent.Image = ((System.Drawing.Image)(resources.GetObject("cmiChatToAgent.Image")));
            this.cmiChatToAgent.Name = "cmiChatToAgent";
            this.cmiChatToAgent.RightToLeft = true;
            this.cmiChatToAgent.Text = "cmiChatToAgent";
            this.cmiChatToAgent.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiRD
            // 
            this.cmiRD.AccessibleDescription = "cmiRD";
            this.cmiRD.AccessibleName = "cmiRD";
            this.cmiRD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiRD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiRD.Image = ((System.Drawing.Image)(resources.GetObject("cmiRD.Image")));
            this.cmiRD.Name = "cmiRD";
            this.cmiRD.RightToLeft = true;
            this.cmiRD.Text = "cmiRD";
            this.cmiRD.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiCommandBox
            // 
            this.cmiCommandBox.AccessibleDescription = "cmiCommandBox";
            this.cmiCommandBox.AccessibleName = "cmiCommandBox";
            this.cmiCommandBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiCommandBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiCommandBox.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.cmiShutdown,
            this.cmiRestart,
            this.radMenuSeparatorItem2,
            this.cmiMonitorOff,
            this.cmiMonitorOn,
            this.radMenuSeparatorItem3,
            this.cmiOpenCD,
            this.cmiCloseCD});
            this.cmiCommandBox.Name = "cmiCommandBox";
            this.cmiCommandBox.RightToLeft = true;
            this.cmiCommandBox.Text = "cmiCommandBox";
            this.cmiCommandBox.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // cmiShutdown
            // 
            this.cmiShutdown.AccessibleDescription = "cmiShutdown";
            this.cmiShutdown.AccessibleName = "cmiShutdown";
            this.cmiShutdown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmiShutdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiShutdown.Name = "cmiShutdown";
            this.cmiShutdown.Text = "cmiShutdown";
            this.cmiShutdown.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiRestart
            // 
            this.cmiRestart.AccessibleDescription = "cmiRestart";
            this.cmiRestart.AccessibleName = "cmiRestart";
            this.cmiRestart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiRestart.Name = "cmiRestart";
            this.cmiRestart.Text = "cmiRestart";
            this.cmiRestart.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiMonitorOff
            // 
            this.cmiMonitorOff.AccessibleDescription = "cmiMonitorOff";
            this.cmiMonitorOff.AccessibleName = "cmiMonitorOff";
            this.cmiMonitorOff.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiMonitorOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiMonitorOff.Name = "cmiMonitorOff";
            this.cmiMonitorOff.Text = "cmiMonitorOff";
            this.cmiMonitorOff.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiMonitorOn
            // 
            this.cmiMonitorOn.AccessibleDescription = "cmiMonitorOn";
            this.cmiMonitorOn.AccessibleName = "cmiMonitorOn";
            this.cmiMonitorOn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiMonitorOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiMonitorOn.Name = "cmiMonitorOn";
            this.cmiMonitorOn.Text = "cmiMonitorOn";
            this.cmiMonitorOn.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem3
            // 
            this.radMenuSeparatorItem3.AccessibleDescription = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.AccessibleName = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.Name = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.Text = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiOpenCD
            // 
            this.cmiOpenCD.AccessibleDescription = "cmiOpenCD";
            this.cmiOpenCD.AccessibleName = "cmiOpenCD";
            this.cmiOpenCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmiOpenCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiOpenCD.Name = "cmiOpenCD";
            this.cmiOpenCD.Text = "cmiOpenCD";
            this.cmiOpenCD.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiCloseCD
            // 
            this.cmiCloseCD.AccessibleDescription = "cmiCloseCD";
            this.cmiCloseCD.AccessibleName = "cmiCloseCD";
            this.cmiCloseCD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiCloseCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiCloseCD.Name = "cmiCloseCD";
            this.cmiCloseCD.Text = "cmiCloseCD";
            this.cmiCloseCD.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // cmiVC
            // 
            this.cmiVC.AccessibleDescription = "cmiVC";
            this.cmiVC.AccessibleName = "cmiVC";
            this.cmiVC.Enabled = false;
            this.cmiVC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmiVC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(129)))));
            this.cmiVC.Image = ((System.Drawing.Image)(resources.GetObject("cmiVC.Image")));
            this.cmiVC.Name = "cmiVC";
            this.cmiVC.RightToLeft = true;
            this.cmiVC.Text = "cmiVC";
            this.cmiVC.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            // 
            // timRefreshList
            // 
            this.timRefreshList.Enabled = true;
            this.timRefreshList.Interval = 15000;
            this.timRefreshList.Tick += new System.EventHandler(this.timRefreshList_Tick);
            // 
            // timReportCheck
            // 
            this.timReportCheck.Tick += new System.EventHandler(this.timReportCheck_Tick);
            // 
            // frmAgentsView_RtoL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1142, 620);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.livAgentList);
            this.Controls.Add(this.tlsAgentList);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1150, 650);
            this.Name = "frmAgentsView_RtoL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(1150, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgentsView_RtoL";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentsView_RtoL_FormClosing);
            this.Load += new System.EventHandler(this.frmAgentsView_RtoL_Load);
            this.Shown += new System.EventHandler(this.frmAgentsView_RtoL_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tlsAgentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livAgentList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadStatusStrip tlsAgentList;
        private Telerik.WinControls.UI.RadButtonElement tsbAgentCheckStatus;
        private Telerik.WinControls.UI.RadButtonElement tsbRefreshList;
        private Telerik.WinControls.UI.RadButtonElement tsbAgentSetting;
        private Telerik.WinControls.UI.RadButtonElement tsbAgentAlarm;
        private Telerik.WinControls.UI.RadButtonElement tsbAgentsId;
        private Telerik.WinControls.UI.RadButtonElement tsbAgentChat;
        private Telerik.WinControls.UI.RadButtonElement tsbSendCommand;
        private Telerik.WinControls.UI.RadSplitButtonElement tsbView;
        private Telerik.WinControls.UI.RadButtonElement tsbSendFile;
        private Telerik.WinControls.UI.RadButtonElement tsbVideo;
        private Telerik.WinControls.UI.RadListView livAgentList;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement3;
        private System.Windows.Forms.ImageList imlPerssonel;
        private System.Windows.Forms.ImageList imlLargeImage;
        private System.Windows.Forms.ImageList imlAlert;
        private Telerik.WinControls.UI.CommandBarLabel cmlSort;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement2;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslSort;
        private System.Windows.Forms.ToolStripComboBox tcmSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslGroup;
        private System.Windows.Forms.ToolStripComboBox tcmGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox txbSearch;
        private Telerik.WinControls.UI.RadMenuItem mniList;
        private Telerik.WinControls.UI.RadMenuItem mniIcon;
        private Telerik.WinControls.UI.RadMenuItem mniDetails;
        private System.Windows.Forms.ToolStripLabel tslFilter;
        private Telerik.WinControls.UI.RadContextMenu cmsAgent;
        private Telerik.WinControls.UI.RadMenuItem cmiEvents;
        private Telerik.WinControls.UI.RadMenuItem cmiAlertAssign;
        private Telerik.WinControls.UI.RadMenuItem cmiSettingAssign;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem cmiSendCommand;
        private Telerik.WinControls.UI.RadMenuItem cmiChatToAgent;
        private Telerik.WinControls.UI.RadMenuItem cmiCommandBox;
        private Telerik.WinControls.UI.RadMenuItem cmiRD;
        private Telerik.WinControls.UI.RadMenuItem cmiVC;
        private System.Windows.Forms.Timer timRefreshList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblCountTitle;
        private System.Windows.Forms.ToolStripLabel lblCount;
        private Telerik.WinControls.UI.RadMenuItem cmiShutdown;
        private Telerik.WinControls.UI.RadMenuItem cmiRestart;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem cmiMonitorOff;
        private Telerik.WinControls.UI.RadMenuItem cmiMonitorOn;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem3;
        private Telerik.WinControls.UI.RadMenuItem cmiOpenCD;
        private Telerik.WinControls.UI.RadMenuItem cmiCloseCD;
        private System.Windows.Forms.Timer timReportCheck;
        private Telerik.WinControls.UI.RadButtonElement tsbACL;
    }
}
