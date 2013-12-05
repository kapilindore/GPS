namespace YTGPS_Client
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAlarm = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOverService = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMap = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMousePos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripWatching = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemWatchingShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWatchingGeo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWatchingCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWatchingCancelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewCars = new System.Windows.Forms.TreeView();
            this.contextMenuStripCars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCarPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarModify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarSetServiceTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarSetStoped = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarNotify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarAddTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarAddCar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarNewDeclare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarDeclareHis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCarDeclareList = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxHisAlarm = new System.Windows.Forms.ListBox();
            this.dateTimePickerAlarmTime2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAlarmTime1 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.listBoxHisPos = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerHisTime2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerHisTime1 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxPlaces = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxLayerPlace = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelOverview = new System.Windows.Forms.Panel();
            this.mapControlOver = new MapInfo.Windows.Controls.MapControl();
            this.mapControl = new MapInfo.Windows.Controls.MapControl();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonItemDefault = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemZoomin = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemZoomout = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemCenter = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemPan = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemDistance = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemFullMap = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemClearMap = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemMimiMap = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemGeoInfo = new DevComponents.DotNetBar.ButtonItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemApp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem0Login = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem0Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem0Config = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGisServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemLockDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem0Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1ModUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1AccoutList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryDeclare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemCarList = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHisPos = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHisAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMap = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2ChangeMap = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2LayerControl = new System.Windows.Forms.ToolStripMenuItem();
            this.watchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hisPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hisLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hisAlarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSound = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3AlarmSound = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3NotifySound = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSystemWarnSound = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3ErrDownSound = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemForm = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChatForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewWatching = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timerAlarmSound = new System.Windows.Forms.Timer(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.expandablePanelQueryPlace = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonPlaceQuery = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxExPlaceKey = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.expandablePanelMarkPlace = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonMark = new DevComponents.DotNetBar.ButtonX();
            this.buttonMarkPoint = new DevComponents.DotNetBar.ButtonX();
            this.textBoxMarkLa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxMarkLo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxMarkName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.expandablePanelMapQuery = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonQueryLayer = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxLayers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.expandablePanelRegionQuery = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonRegionQuery2 = new DevComponents.DotNetBar.ButtonX();
            this.listBoxRegionQuery = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonRegionQuery1 = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerRegionQuery2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRegionQuery1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxExRegionQueryTeam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.expandablePanelMileage = new DevComponents.DotNetBar.ExpandablePanel();
            this.richTextBoxMileage = new System.Windows.Forms.RichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.buttonHisMileage = new DevComponents.DotNetBar.ButtonX();
            this.dateTimePickerHisMileage2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHisMileage1 = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBoxExMileageCar = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxExMileageTeam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.expandablePanelHisAlarm = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonHisAlarmList = new DevComponents.DotNetBar.ButtonX();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonHisAlarm = new DevComponents.DotNetBar.ButtonX();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxExHisAlarmKey = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.treeViewHisAlarm = new System.Windows.Forms.TreeView();
            this.label22 = new System.Windows.Forms.Label();
            this.expandablePanelHisPos = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonHisPosList = new DevComponents.DotNetBar.ButtonX();
            this.groupBoxHisPlay = new System.Windows.Forms.GroupBox();
            this.buttonHisPosPlayEnd = new DevComponents.DotNetBar.ButtonX();
            this.buttonHisPosPlayStart = new DevComponents.DotNetBar.ButtonX();
            this.sliderHisPosPlay = new DevComponents.DotNetBar.Controls.Slider();
            this.buttonHis = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxExHisCar = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxExHisTeam = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.expandablePanelCarList = new DevComponents.DotNetBar.ExpandablePanel();
            this.buttonQueryCar = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxExKey = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.timerHisPlay = new System.Windows.Forms.Timer(this.components);
            this.timerTest = new System.Windows.Forms.Timer(this.components);
            this.timerCheckConn = new System.Windows.Forms.Timer(this.components);
            this.timerReconn = new System.Windows.Forms.Timer(this.components);
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.buttonItemLogin = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemLogout = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemExit = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItemSidebar = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemConfig = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItemAbout = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemHelp = new DevComponents.DotNetBar.ButtonItem();
            this.statusStrip.SuspendLayout();
            this.contextMenuStripWatching.SuspendLayout();
            this.contextMenuStripCars.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.expandablePanelQueryPlace.SuspendLayout();
            this.expandablePanelMarkPlace.SuspendLayout();
            this.expandablePanelMapQuery.SuspendLayout();
            this.expandablePanelRegionQuery.SuspendLayout();
            this.expandablePanelMileage.SuspendLayout();
            this.expandablePanelHisAlarm.SuspendLayout();
            this.expandablePanelHisPos.SuspendLayout();
            this.groupBoxHisPlay.SuspendLayout();
            this.expandablePanelCarList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip.BackgroundImage")));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLogin,
            this.toolStripStatusLabelAlarm,
            this.toolStripStatusLabelOverService,
            this.toolStripStatusLabelMap,
            this.toolStripStatusLabelMousePos,
            this.toolStripStatusLabelTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 613);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(913, 25);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLogin
            // 
            this.toolStripStatusLabelLogin.AutoSize = false;
            this.toolStripStatusLabelLogin.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelLogin.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelLogin.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelLogin.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabelLogin.Name = "toolStripStatusLabelLogin";
            this.toolStripStatusLabelLogin.Size = new System.Drawing.Size(120, 20);
            // 
            // toolStripStatusLabelAlarm
            // 
            this.toolStripStatusLabelAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelAlarm.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelAlarm.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelAlarm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelAlarm.Name = "toolStripStatusLabelAlarm";
            this.toolStripStatusLabelAlarm.Size = new System.Drawing.Size(4, 20);
            this.toolStripStatusLabelAlarm.Click += new System.EventHandler(this.toolStripStatusLabelAlarm_Click);
            // 
            // toolStripStatusLabelOverService
            // 
            this.toolStripStatusLabelOverService.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelOverService.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelOverService.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelOverService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelOverService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabelOverService.Name = "toolStripStatusLabelOverService";
            this.toolStripStatusLabelOverService.Size = new System.Drawing.Size(4, 20);
            this.toolStripStatusLabelOverService.Click += new System.EventHandler(this.toolStripStatusLabelOverService_Click);
            // 
            // toolStripStatusLabelMap
            // 
            this.toolStripStatusLabelMap.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelMap.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelMap.Name = "toolStripStatusLabelMap";
            this.toolStripStatusLabelMap.Size = new System.Drawing.Size(4, 20);
            this.toolStripStatusLabelMap.ToolTipText = "当前地图";
            // 
            // toolStripStatusLabelMousePos
            // 
            this.toolStripStatusLabelMousePos.AutoSize = false;
            this.toolStripStatusLabelMousePos.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelMousePos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelMousePos.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelMousePos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelMousePos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabelMousePos.Name = "toolStripStatusLabelMousePos";
            this.toolStripStatusLabelMousePos.Size = new System.Drawing.Size(250, 20);
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(516, 20);
            this.toolStripStatusLabelTime.Spring = true;
            this.toolStripStatusLabelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabelTime.ToolTipText = "当前时间";
            // 
            // contextMenuStripWatching
            // 
            this.contextMenuStripWatching.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemWatchingShow,
            this.toolStripMenuItemWatchingGeo,
            this.toolStripMenuItemWatchingCancel,
            this.toolStripMenuItemWatchingCancelAll});
            this.contextMenuStripWatching.Name = "contextMenuStripListPos";
            this.contextMenuStripWatching.Size = new System.Drawing.Size(164, 92);
            // 
            // toolStripMenuItemWatchingShow
            // 
            this.toolStripMenuItemWatchingShow.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuItemWatchingShow.Name = "toolStripMenuItemWatchingShow";
            this.toolStripMenuItemWatchingShow.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemWatchingShow.Text = "在地图中央显示";
            this.toolStripMenuItemWatchingShow.Click += new System.EventHandler(this.toolStripMenuItemWatchingShow_Click);
            // 
            // toolStripMenuItemWatchingGeo
            // 
            this.toolStripMenuItemWatchingGeo.Name = "toolStripMenuItemWatchingGeo";
            this.toolStripMenuItemWatchingGeo.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemWatchingGeo.Text = "获取地理信息";
            this.toolStripMenuItemWatchingGeo.Click += new System.EventHandler(this.toolStripMenuItemWatchingGeo_Click);
            // 
            // toolStripMenuItemWatchingCancel
            // 
            this.toolStripMenuItemWatchingCancel.Name = "toolStripMenuItemWatchingCancel";
            this.toolStripMenuItemWatchingCancel.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemWatchingCancel.Text = "取消监控";
            this.toolStripMenuItemWatchingCancel.Click += new System.EventHandler(this.toolStripMenuItemWatchingCancel_Click);
            // 
            // toolStripMenuItemWatchingCancelAll
            // 
            this.toolStripMenuItemWatchingCancelAll.Name = "toolStripMenuItemWatchingCancelAll";
            this.toolStripMenuItemWatchingCancelAll.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemWatchingCancelAll.Text = "取消所有监控";
            this.toolStripMenuItemWatchingCancelAll.Click += new System.EventHandler(this.toolStripMenuItemWatchingCancelAll_Click);
            // 
            // treeViewCars
            // 
            this.treeViewCars.BackColor = System.Drawing.Color.White;
            this.treeViewCars.CheckBoxes = true;
            this.treeViewCars.ContextMenuStrip = this.contextMenuStripCars;
            this.treeViewCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCars.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewCars.FullRowSelect = true;
            this.treeViewCars.ItemHeight = 17;
            this.treeViewCars.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeViewCars.Location = new System.Drawing.Point(3, 56);
            this.treeViewCars.Name = "treeViewCars";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点2";
            treeNode2.Text = "节点2";
            treeNode3.Name = "节点3";
            treeNode3.Text = "节点3";
            treeNode4.Name = "节点0";
            treeNode4.Text = "节点0";
            this.treeViewCars.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeViewCars.Size = new System.Drawing.Size(250, 0);
            this.treeViewCars.TabIndex = 3;
            this.treeViewCars.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCars_NodeMouseDoubleClick);
            this.treeViewCars.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCars_AfterCheck);
            this.treeViewCars.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewCars_MouseClick);
            this.treeViewCars.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewCars_MouseDown);
            this.treeViewCars.MouseLeave += new System.EventHandler(this.treeViewCars_MouseLeave);
            // 
            // contextMenuStripCars
            // 
            this.contextMenuStripCars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCarPoint,
            this.toolStripMenuItemCarOrder,
            this.toolStripMenuItemCarModify,
            this.toolStripMenuItemCarSetServiceTime,
            this.toolStripMenuItemCarSetStoped,
            this.toolStripMenuItemCarNotify,
            this.toolStripMenuItemCarDel,
            this.toolStripMenuItemCarAddTeam,
            this.toolStripMenuItemCarAddCar,
            this.toolStripMenuItemCarNewDeclare,
            this.toolStripMenuItemCarDeclareHis,
            this.toolStripMenuItemCarDeclareList});
            this.contextMenuStripCars.Name = "contextMenuStripCars";
            this.contextMenuStripCars.Size = new System.Drawing.Size(159, 268);
            // 
            // toolStripMenuItemCarPoint
            // 
            this.toolStripMenuItemCarPoint.Name = "toolStripMenuItemCarPoint";
            this.toolStripMenuItemCarPoint.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarPoint.Text = "定位";
            this.toolStripMenuItemCarPoint.Click += new System.EventHandler(this.toolStripMenuItemCarPointed_Click);
            // 
            // toolStripMenuItemCarOrder
            // 
            this.toolStripMenuItemCarOrder.Name = "toolStripMenuItemCarOrder";
            this.toolStripMenuItemCarOrder.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarOrder.Text = "下发指令";
            this.toolStripMenuItemCarOrder.Click += new System.EventHandler(this.toolStripMenuItemCarOrder_Click);
            // 
            // toolStripMenuItemCarModify
            // 
            this.toolStripMenuItemCarModify.Name = "toolStripMenuItemCarModify";
            this.toolStripMenuItemCarModify.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarModify.Text = "修改信息";
            this.toolStripMenuItemCarModify.Click += new System.EventHandler(this.ToolStripMenuItemCarModify_Click);
            // 
            // toolStripMenuItemCarSetServiceTime
            // 
            this.toolStripMenuItemCarSetServiceTime.Name = "toolStripMenuItemCarSetServiceTime";
            this.toolStripMenuItemCarSetServiceTime.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarSetServiceTime.Text = "修改服务日期";
            this.toolStripMenuItemCarSetServiceTime.Click += new System.EventHandler(this.toolStripMenuItemCarSetServiceTime_Click);
            // 
            // toolStripMenuItemCarSetStoped
            // 
            this.toolStripMenuItemCarSetStoped.Name = "toolStripMenuItemCarSetStoped";
            this.toolStripMenuItemCarSetStoped.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarSetStoped.Text = "修改服务状态";
            this.toolStripMenuItemCarSetStoped.Click += new System.EventHandler(this.toolStripMenuItemCarStoped_Click);
            // 
            // toolStripMenuItemCarNotify
            // 
            this.toolStripMenuItemCarNotify.Name = "toolStripMenuItemCarNotify";
            this.toolStripMenuItemCarNotify.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarNotify.Text = "修改操作提示";
            this.toolStripMenuItemCarNotify.Click += new System.EventHandler(this.toolStripMenuItemCarNotify_Click);
            // 
            // toolStripMenuItemCarDel
            // 
            this.toolStripMenuItemCarDel.Name = "toolStripMenuItemCarDel";
            this.toolStripMenuItemCarDel.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarDel.Text = "删除";
            this.toolStripMenuItemCarDel.Click += new System.EventHandler(this.ToolStripMenuItemCarDel_Click);
            // 
            // toolStripMenuItemCarAddTeam
            // 
            this.toolStripMenuItemCarAddTeam.Name = "toolStripMenuItemCarAddTeam";
            this.toolStripMenuItemCarAddTeam.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarAddTeam.Text = "添加车队";
            this.toolStripMenuItemCarAddTeam.Click += new System.EventHandler(this.toolStripMenuItemCarAddTeam_Click);
            // 
            // toolStripMenuItemCarAddCar
            // 
            this.toolStripMenuItemCarAddCar.Name = "toolStripMenuItemCarAddCar";
            this.toolStripMenuItemCarAddCar.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarAddCar.Text = "添加车辆";
            this.toolStripMenuItemCarAddCar.Click += new System.EventHandler(this.toolStripMenuItemCarAddCar_Click);
            // 
            // toolStripMenuItemCarNewDeclare
            // 
            this.toolStripMenuItemCarNewDeclare.Name = "toolStripMenuItemCarNewDeclare";
            this.toolStripMenuItemCarNewDeclare.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarNewDeclare.Text = "投诉、故障申报";
            this.toolStripMenuItemCarNewDeclare.Click += new System.EventHandler(this.ToolStripMenuItemNewDeclare_Click);
            // 
            // toolStripMenuItemCarDeclareHis
            // 
            this.toolStripMenuItemCarDeclareHis.Name = "toolStripMenuItemCarDeclareHis";
            this.toolStripMenuItemCarDeclareHis.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarDeclareHis.Text = "投诉、故障历史";
            this.toolStripMenuItemCarDeclareHis.Click += new System.EventHandler(this.ToolStripMenuItemDeclareHis_Click);
            // 
            // toolStripMenuItemCarDeclareList
            // 
            this.toolStripMenuItemCarDeclareList.Name = "toolStripMenuItemCarDeclareList";
            this.toolStripMenuItemCarDeclareList.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCarDeclareList.Text = "处理投诉、故障";
            this.toolStripMenuItemCarDeclareList.Click += new System.EventHandler(this.ToolStripMenuItemDeclareList_Click);
            // 
            // listBoxHisAlarm
            // 
            this.listBoxHisAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHisAlarm.FormattingEnabled = true;
            this.listBoxHisAlarm.HorizontalScrollbar = true;
            this.listBoxHisAlarm.Location = new System.Drawing.Point(3, 258);
            this.listBoxHisAlarm.Name = "listBoxHisAlarm";
            this.listBoxHisAlarm.Size = new System.Drawing.Size(250, 4);
            this.listBoxHisAlarm.TabIndex = 13;
            this.listBoxHisAlarm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxHisAlarm_MouseDoubleClick);
            // 
            // dateTimePickerAlarmTime2
            // 
            this.dateTimePickerAlarmTime2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerAlarmTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAlarmTime2.Location = new System.Drawing.Point(64, 217);
            this.dateTimePickerAlarmTime2.Name = "dateTimePickerAlarmTime2";
            this.dateTimePickerAlarmTime2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerAlarmTime2.TabIndex = 10;
            // 
            // dateTimePickerAlarmTime1
            // 
            this.dateTimePickerAlarmTime1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerAlarmTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAlarmTime1.Location = new System.Drawing.Point(64, 186);
            this.dateTimePickerAlarmTime1.Name = "dateTimePickerAlarmTime1";
            this.dateTimePickerAlarmTime1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerAlarmTime1.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(3, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(250, 30);
            this.label14.TabIndex = 6;
            this.label14.Text = " 轨迹列表(最多1000项)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // listBoxHisPos
            // 
            this.listBoxHisPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHisPos.FormattingEnabled = true;
            this.listBoxHisPos.HorizontalScrollbar = true;
            this.listBoxHisPos.Location = new System.Drawing.Point(3, 178);
            this.listBoxHisPos.Name = "listBoxHisPos";
            this.listBoxHisPos.Size = new System.Drawing.Size(250, 4);
            this.listBoxHisPos.TabIndex = 5;
            this.listBoxHisPos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxHisPos_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 26);
            this.label7.TabIndex = 3;
            this.label7.Text = " 结束时间";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerHisTime2
            // 
            this.dateTimePickerHisTime2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerHisTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHisTime2.Location = new System.Drawing.Point(68, 121);
            this.dateTimePickerHisTime2.Name = "dateTimePickerHisTime2";
            this.dateTimePickerHisTime2.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerHisTime2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = " 开始时间";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerHisTime1
            // 
            this.dateTimePickerHisTime1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerHisTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHisTime1.Location = new System.Drawing.Point(68, 91);
            this.dateTimePickerHisTime1.Name = "dateTimePickerHisTime1";
            this.dateTimePickerHisTime1.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerHisTime1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(250, 43);
            this.label15.TabIndex = 8;
            this.label15.Text = " 关键字:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxPlaces
            // 
            this.listBoxPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPlaces.FormattingEnabled = true;
            this.listBoxPlaces.Location = new System.Drawing.Point(3, 68);
            this.listBoxPlaces.Name = "listBoxPlaces";
            this.listBoxPlaces.Size = new System.Drawing.Size(250, 4);
            this.listBoxPlaces.TabIndex = 7;
            this.listBoxPlaces.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPlaces_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "纬度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "经度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "名称";
            // 
            // listBoxLayerPlace
            // 
            this.listBoxLayerPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLayerPlace.FormattingEnabled = true;
            this.listBoxLayerPlace.Location = new System.Drawing.Point(3, 100);
            this.listBoxLayerPlace.Name = "listBoxLayerPlace";
            this.listBoxLayerPlace.Size = new System.Drawing.Size(250, 4);
            this.listBoxLayerPlace.TabIndex = 14;
            this.listBoxLayerPlace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxLayerPlace_MouseDoubleClick);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(3, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(250, 74);
            this.label13.TabIndex = 5;
            this.label13.Text = " 查询图层:\r\n\r\n";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panelOverview);
            this.panel2.Controls.Add(this.mapControl);
            this.panel2.Controls.Add(this.bar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 434);
            this.panel2.TabIndex = 1;
            // 
            // panelOverview
            // 
            this.panelOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOverview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOverview.Controls.Add(this.mapControlOver);
            this.panelOverview.Location = new System.Drawing.Point(494, 317);
            this.panelOverview.Name = "panelOverview";
            this.panelOverview.Size = new System.Drawing.Size(156, 111);
            this.panelOverview.TabIndex = 3;
            this.panelOverview.Visible = false;
            // 
            // mapControlOver
            // 
            this.mapControlOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControlOver.IgnoreLostFocusEvent = false;
            this.mapControlOver.Location = new System.Drawing.Point(0, 0);
            this.mapControlOver.Name = "mapControlOver";
            this.mapControlOver.Size = new System.Drawing.Size(154, 109);
            this.mapControlOver.TabIndex = 0;
            this.mapControlOver.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapControlOver_MouseClick);
            this.mapControlOver.Tools.LeftButtonTool = "AddPoint";
            this.mapControlOver.Tools.MiddleButtonTool = null;
            this.mapControlOver.Tools.RightButtonTool = null;
            // 
            // mapControl
            // 
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.IgnoreLostFocusEvent = false;
            this.mapControl.Location = new System.Drawing.Point(0, 25);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(653, 405);
            this.mapControl.TabIndex = 1;
            this.mapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseMove);
            this.mapControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseClick);
            this.mapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseDown);
            this.mapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseUp);
            this.mapControl.Tools.LeftButtonTool = "Arrow";
            this.mapControl.Tools.MiddleButtonTool = null;
            this.mapControl.Tools.RightButtonTool = null;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.BackColor = System.Drawing.Color.White;
            this.bar1.CanCustomize = false;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItemDefault,
            this.buttonItemZoomin,
            this.buttonItemZoomout,
            this.buttonItemCenter,
            this.buttonItemPan,
            this.buttonItemDistance,
            this.buttonItemFullMap,
            this.buttonItemClearMap,
            this.buttonItemMimiMap,
            this.buttonItemGeoInfo});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bar1.Size = new System.Drawing.Size(653, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            // 
            // buttonItemDefault
            // 
            this.buttonItemDefault.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemDefault.Image = global::YTGPS_Client.Properties.Resources.btn1;
            this.buttonItemDefault.Name = "buttonItemDefault";
            this.buttonItemDefault.Text = "默认";
            this.buttonItemDefault.Tooltip = "默认";
            this.buttonItemDefault.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemZoomin
            // 
            this.buttonItemZoomin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemZoomin.Image = global::YTGPS_Client.Properties.Resources.btn2;
            this.buttonItemZoomin.Name = "buttonItemZoomin";
            this.buttonItemZoomin.Text = "放大";
            this.buttonItemZoomin.Tooltip = "放大";
            this.buttonItemZoomin.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemZoomout
            // 
            this.buttonItemZoomout.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemZoomout.Image = global::YTGPS_Client.Properties.Resources.btn3;
            this.buttonItemZoomout.Name = "buttonItemZoomout";
            this.buttonItemZoomout.Text = "缩小";
            this.buttonItemZoomout.Tooltip = "缩小";
            this.buttonItemZoomout.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemCenter
            // 
            this.buttonItemCenter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemCenter.Image = global::YTGPS_Client.Properties.Resources.btn4;
            this.buttonItemCenter.Name = "buttonItemCenter";
            this.buttonItemCenter.Text = "中置";
            this.buttonItemCenter.Tooltip = "中置";
            this.buttonItemCenter.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemPan
            // 
            this.buttonItemPan.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemPan.Image = global::YTGPS_Client.Properties.Resources.btn5;
            this.buttonItemPan.Name = "buttonItemPan";
            this.buttonItemPan.Text = "漫游";
            this.buttonItemPan.Tooltip = "漫游";
            this.buttonItemPan.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemDistance
            // 
            this.buttonItemDistance.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemDistance.Image = global::YTGPS_Client.Properties.Resources.btn6;
            this.buttonItemDistance.Name = "buttonItemDistance";
            this.buttonItemDistance.Text = "测距";
            this.buttonItemDistance.Tooltip = "测距";
            this.buttonItemDistance.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // buttonItemFullMap
            // 
            this.buttonItemFullMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemFullMap.Image = global::YTGPS_Client.Properties.Resources.btn7;
            this.buttonItemFullMap.Name = "buttonItemFullMap";
            this.buttonItemFullMap.Text = "全图";
            this.buttonItemFullMap.Tooltip = "全图";
            this.buttonItemFullMap.Click += new System.EventHandler(this.buttonItemFullMap_Click);
            // 
            // buttonItemClearMap
            // 
            this.buttonItemClearMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemClearMap.Image = global::YTGPS_Client.Properties.Resources.btn8;
            this.buttonItemClearMap.Name = "buttonItemClearMap";
            this.buttonItemClearMap.Text = "清屏";
            this.buttonItemClearMap.Tooltip = "清屏";
            this.buttonItemClearMap.Click += new System.EventHandler(this.buttonItemClearMap_Click);
            // 
            // buttonItemMimiMap
            // 
            this.buttonItemMimiMap.AutoCheckOnClick = true;
            this.buttonItemMimiMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemMimiMap.Image = global::YTGPS_Client.Properties.Resources.btn9;
            this.buttonItemMimiMap.Name = "buttonItemMimiMap";
            this.buttonItemMimiMap.Text = "鹰眼图";
            this.buttonItemMimiMap.Tooltip = "鹰眼图";
            this.buttonItemMimiMap.Click += new System.EventHandler(this.buttonItemMinimap_Click);
            // 
            // buttonItemGeoInfo
            // 
            this.buttonItemGeoInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemGeoInfo.Image = global::YTGPS_Client.Properties.Resources.btn1;
            this.buttonItemGeoInfo.Name = "buttonItemGeoInfo";
            this.buttonItemGeoInfo.Text = "地理信息";
            this.buttonItemGeoInfo.Tooltip = "地理信息";
            this.buttonItemGeoInfo.Click += new System.EventHandler(this.itemButtonMap_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::YTGPS_Client.Properties.Resources.bk3;
            this.menuStrip1.Font = new System.Drawing.Font("SimSun", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemApp,
            this.ToolStripMenuItemSystem,
            this.ToolStripMenuItemQuery,
            this.ToolStripMenuItemMap,
            this.ToolStripMenuItemSound,
            this.ToolStripMenuItemForm,
            this.ToolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemApp
            // 
            this.ToolStripMenuItemApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem0Login,
            this.ToolStripMenuItem0Logout,
            this.ToolStripMenuItem0Config,
            this.ToolStripMenuItemGisServer,
            this.toolStripMenuItem6,
            this.ToolStripMenuItemLockDown,
            this.toolStripMenuItem3,
            this.ToolStripMenuItem0Exit});
            this.ToolStripMenuItemApp.Name = "ToolStripMenuItemApp";
            this.ToolStripMenuItemApp.Size = new System.Drawing.Size(59, 20);
            this.ToolStripMenuItemApp.Text = " 程 序 ";
            // 
            // ToolStripMenuItem0Login
            // 
            this.ToolStripMenuItem0Login.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem0Login.Image")));
            this.ToolStripMenuItem0Login.Name = "ToolStripMenuItem0Login";
            this.ToolStripMenuItem0Login.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem0Login.Text = "登陆后台";
            this.ToolStripMenuItem0Login.Click += new System.EventHandler(this.ToolStripMenuItemLogin_Click);
            // 
            // ToolStripMenuItem0Logout
            // 
            this.ToolStripMenuItem0Logout.Image = global::YTGPS_Client.Properties.Resources.btlogout;
            this.ToolStripMenuItem0Logout.Name = "ToolStripMenuItem0Logout";
            this.ToolStripMenuItem0Logout.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem0Logout.Text = "取消登陆";
            this.ToolStripMenuItem0Logout.Click += new System.EventHandler(this.ToolStripMenuItemLogout_Click);
            // 
            // ToolStripMenuItem0Config
            // 
            this.ToolStripMenuItem0Config.Image = global::YTGPS_Client.Properties.Resources.btconfig;
            this.ToolStripMenuItem0Config.Name = "ToolStripMenuItem0Config";
            this.ToolStripMenuItem0Config.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem0Config.Text = "程序设置";
            this.ToolStripMenuItem0Config.Click += new System.EventHandler(this.ToolStripMenuItemConfig_Click);
            // 
            // ToolStripMenuItemGisServer
            // 
            this.ToolStripMenuItemGisServer.Name = "ToolStripMenuItemGisServer";
            this.ToolStripMenuItemGisServer.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemGisServer.Text = "GIS扩展端口";
            this.ToolStripMenuItemGisServer.Click += new System.EventHandler(this.ToolStripMenuItemGisServer_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(133, 6);
            // 
            // ToolStripMenuItemLockDown
            // 
            this.ToolStripMenuItemLockDown.Name = "ToolStripMenuItemLockDown";
            this.ToolStripMenuItemLockDown.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemLockDown.Text = "锁定Windows";
            this.ToolStripMenuItemLockDown.Click += new System.EventHandler(this.ToolStripMenuItemLockDown_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
            // 
            // ToolStripMenuItem0Exit
            // 
            this.ToolStripMenuItem0Exit.Image = global::YTGPS_Client.Properties.Resources.btexit;
            this.ToolStripMenuItem0Exit.Name = "ToolStripMenuItem0Exit";
            this.ToolStripMenuItem0Exit.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem0Exit.Text = "退出程序";
            this.ToolStripMenuItem0Exit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemSystem
            // 
            this.ToolStripMenuItemSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1ModUserInfo,
            this.ToolStripMenuItem1AccoutList});
            this.ToolStripMenuItemSystem.Name = "ToolStripMenuItemSystem";
            this.ToolStripMenuItemSystem.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemSystem.Text = "系统管理";
            // 
            // ToolStripMenuItem1ModUserInfo
            // 
            this.ToolStripMenuItem1ModUserInfo.Name = "ToolStripMenuItem1ModUserInfo";
            this.ToolStripMenuItem1ModUserInfo.Size = new System.Drawing.Size(142, 22);
            this.ToolStripMenuItem1ModUserInfo.Text = "修改个人信息";
            this.ToolStripMenuItem1ModUserInfo.Click += new System.EventHandler(this.ToolStripMenuItemUserInfo_Click);
            // 
            // ToolStripMenuItem1AccoutList
            // 
            this.ToolStripMenuItem1AccoutList.Enabled = false;
            this.ToolStripMenuItem1AccoutList.Name = "ToolStripMenuItem1AccoutList";
            this.ToolStripMenuItem1AccoutList.Size = new System.Drawing.Size(142, 22);
            this.ToolStripMenuItem1AccoutList.Text = "系统账户管理";
            this.ToolStripMenuItem1AccoutList.Click += new System.EventHandler(this.ToolStripMenuItemAccoutList_Click);
            // 
            // ToolStripMenuItemQuery
            // 
            this.ToolStripMenuItemQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemQueryOperation,
            this.ToolStripMenuItemQueryOrder,
            this.ToolStripMenuItemQueryDeclare,
            this.toolStripMenuItem2,
            this.ToolStripMenuItemCarList,
            this.ToolStripMenuItemHisPos,
            this.ToolStripMenuItemHisAlarm});
            this.ToolStripMenuItemQuery.Name = "ToolStripMenuItemQuery";
            this.ToolStripMenuItemQuery.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemQuery.Text = "统计查询";
            // 
            // ToolStripMenuItemQueryOperation
            // 
            this.ToolStripMenuItemQueryOperation.Name = "ToolStripMenuItemQueryOperation";
            this.ToolStripMenuItemQueryOperation.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemQueryOperation.Text = "操作记录";
            this.ToolStripMenuItemQueryOperation.Click += new System.EventHandler(this.ToolStripMenuItemQueryOperation_Click);
            // 
            // ToolStripMenuItemQueryOrder
            // 
            this.ToolStripMenuItemQueryOrder.Name = "ToolStripMenuItemQueryOrder";
            this.ToolStripMenuItemQueryOrder.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemQueryOrder.Text = "指令下发记录";
            this.ToolStripMenuItemQueryOrder.Click += new System.EventHandler(this.ToolStripMenuItemQueryOrder_Click);
            // 
            // ToolStripMenuItemQueryDeclare
            // 
            this.ToolStripMenuItemQueryDeclare.Name = "ToolStripMenuItemQueryDeclare";
            this.ToolStripMenuItemQueryDeclare.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemQueryDeclare.Text = "投诉、故障记录";
            this.ToolStripMenuItemQueryDeclare.Click += new System.EventHandler(this.ToolStripMenuItemQueryDeclare_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // ToolStripMenuItemCarList
            // 
            this.ToolStripMenuItemCarList.Name = "ToolStripMenuItemCarList";
            this.ToolStripMenuItemCarList.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemCarList.Text = "车辆信息列表";
            this.ToolStripMenuItemCarList.Click += new System.EventHandler(this.buttonQueryCar_Click);
            // 
            // ToolStripMenuItemHisPos
            // 
            this.ToolStripMenuItemHisPos.Name = "ToolStripMenuItemHisPos";
            this.ToolStripMenuItemHisPos.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemHisPos.Text = "历史轨迹列表";
            this.ToolStripMenuItemHisPos.Click += new System.EventHandler(this.ToolStripMenuItemHisPos_Click);
            // 
            // ToolStripMenuItemHisAlarm
            // 
            this.ToolStripMenuItemHisAlarm.Name = "ToolStripMenuItemHisAlarm";
            this.ToolStripMenuItemHisAlarm.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemHisAlarm.Text = "历史报警列表";
            this.ToolStripMenuItemHisAlarm.Click += new System.EventHandler(this.ToolStripMenuItemHisAlarm_Click);
            // 
            // ToolStripMenuItemMap
            // 
            this.ToolStripMenuItemMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem2ChangeMap,
            this.ToolStripMenuItem2LayerControl});
            this.ToolStripMenuItemMap.Name = "ToolStripMenuItemMap";
            this.ToolStripMenuItemMap.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemMap.Text = "地图控制";
            this.ToolStripMenuItemMap.Click += new System.EventHandler(this.ToolStripMenuItemMap_Click);
            // 
            // ToolStripMenuItem2ChangeMap
            // 
            this.ToolStripMenuItem2ChangeMap.Name = "ToolStripMenuItem2ChangeMap";
            this.ToolStripMenuItem2ChangeMap.Size = new System.Drawing.Size(142, 22);
            this.ToolStripMenuItem2ChangeMap.Text = "更换地图";
            // 
            // ToolStripMenuItem2LayerControl
            // 
            this.ToolStripMenuItem2LayerControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchingToolStripMenuItem,
            this.alarmToolStripMenuItem,
            this.hisPosToolStripMenuItem,
            this.hisLineToolStripMenuItem,
            this.hisAlarmToolStripMenuItem,
            this.placeToolStripMenuItem});
            this.ToolStripMenuItem2LayerControl.Name = "ToolStripMenuItem2LayerControl";
            this.ToolStripMenuItem2LayerControl.Size = new System.Drawing.Size(142, 22);
            this.ToolStripMenuItem2LayerControl.Text = "系统图层控制";
            // 
            // watchingToolStripMenuItem
            // 
            this.watchingToolStripMenuItem.Name = "watchingToolStripMenuItem";
            this.watchingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.watchingToolStripMenuItem.Text = "监控点图层";
            this.watchingToolStripMenuItem.Click += new System.EventHandler(this.watchingToolStripMenuItem_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.alarmToolStripMenuItem.Text = "报警点图层";
            this.alarmToolStripMenuItem.Click += new System.EventHandler(this.alarmToolStripMenuItem_Click);
            // 
            // hisPosToolStripMenuItem
            // 
            this.hisPosToolStripMenuItem.Name = "hisPosToolStripMenuItem";
            this.hisPosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hisPosToolStripMenuItem.Text = "历史轨迹点图层";
            this.hisPosToolStripMenuItem.Click += new System.EventHandler(this.hisPosToolStripMenuItem_Click);
            // 
            // hisLineToolStripMenuItem
            // 
            this.hisLineToolStripMenuItem.Name = "hisLineToolStripMenuItem";
            this.hisLineToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hisLineToolStripMenuItem.Text = "历史轨迹线图层";
            this.hisLineToolStripMenuItem.Click += new System.EventHandler(this.hisLineToolStripMenuItem_Click);
            // 
            // hisAlarmToolStripMenuItem
            // 
            this.hisAlarmToolStripMenuItem.Name = "hisAlarmToolStripMenuItem";
            this.hisAlarmToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hisAlarmToolStripMenuItem.Text = "历史报警点图层";
            this.hisAlarmToolStripMenuItem.Click += new System.EventHandler(this.hisAlarmToolStripMenuItem_Click);
            // 
            // placeToolStripMenuItem
            // 
            this.placeToolStripMenuItem.Name = "placeToolStripMenuItem";
            this.placeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.placeToolStripMenuItem.Text = "自定义标注图层";
            this.placeToolStripMenuItem.Click += new System.EventHandler(this.placeToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemSound
            // 
            this.ToolStripMenuItemSound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem3AlarmSound,
            this.ToolStripMenuItem3NotifySound,
            this.ToolStripMenuItemSystemWarnSound,
            this.ToolStripMenuItem3ErrDownSound});
            this.ToolStripMenuItemSound.Name = "ToolStripMenuItemSound";
            this.ToolStripMenuItemSound.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemSound.Text = "声音控制";
            // 
            // ToolStripMenuItem3AlarmSound
            // 
            this.ToolStripMenuItem3AlarmSound.Checked = true;
            this.ToolStripMenuItem3AlarmSound.CheckOnClick = true;
            this.ToolStripMenuItem3AlarmSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem3AlarmSound.Name = "ToolStripMenuItem3AlarmSound";
            this.ToolStripMenuItem3AlarmSound.Size = new System.Drawing.Size(226, 22);
            this.ToolStripMenuItem3AlarmSound.Text = "报警声";
            this.ToolStripMenuItem3AlarmSound.Click += new System.EventHandler(this.alarmSoundToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem3NotifySound
            // 
            this.ToolStripMenuItem3NotifySound.Checked = true;
            this.ToolStripMenuItem3NotifySound.CheckOnClick = true;
            this.ToolStripMenuItem3NotifySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem3NotifySound.Name = "ToolStripMenuItem3NotifySound";
            this.ToolStripMenuItem3NotifySound.Size = new System.Drawing.Size(226, 22);
            this.ToolStripMenuItem3NotifySound.Text = "收到新信息提示声";
            this.ToolStripMenuItem3NotifySound.Click += new System.EventHandler(this.notifySoundToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemSystemWarnSound
            // 
            this.ToolStripMenuItemSystemWarnSound.Checked = true;
            this.ToolStripMenuItemSystemWarnSound.CheckOnClick = true;
            this.ToolStripMenuItemSystemWarnSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItemSystemWarnSound.Name = "ToolStripMenuItemSystemWarnSound";
            this.ToolStripMenuItemSystemWarnSound.Size = new System.Drawing.Size(226, 22);
            this.ToolStripMenuItemSystemWarnSound.Text = "服务器警告、错误信息提示声";
            this.ToolStripMenuItemSystemWarnSound.Click += new System.EventHandler(this.ToolStripMenuItemSystemWarnSound_Click);
            // 
            // ToolStripMenuItem3ErrDownSound
            // 
            this.ToolStripMenuItem3ErrDownSound.Checked = true;
            this.ToolStripMenuItem3ErrDownSound.CheckOnClick = true;
            this.ToolStripMenuItem3ErrDownSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem3ErrDownSound.Name = "ToolStripMenuItem3ErrDownSound";
            this.ToolStripMenuItem3ErrDownSound.Size = new System.Drawing.Size(226, 22);
            this.ToolStripMenuItem3ErrDownSound.Text = "异常断线提示声";
            this.ToolStripMenuItem3ErrDownSound.Click += new System.EventHandler(this.ToolStripMenuItem3ErrDownSound_Click);
            // 
            // ToolStripMenuItemForm
            // 
            this.ToolStripMenuItemForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemChatForm,
            this.toolStripMenuItem1});
            this.ToolStripMenuItemForm.Name = "ToolStripMenuItemForm";
            this.ToolStripMenuItemForm.Size = new System.Drawing.Size(41, 20);
            this.ToolStripMenuItemForm.Text = "其他";
            // 
            // ToolStripMenuItemChatForm
            // 
            this.ToolStripMenuItemChatForm.Name = "ToolStripMenuItemChatForm";
            this.ToolStripMenuItemChatForm.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItemChatForm.Text = "信息窗口";
            this.ToolStripMenuItemChatForm.Click += new System.EventHandler(this.ToolStripMenuItemChatForm_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem31,
            this.ToolStripMenuItem32});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(41, 20);
            this.ToolStripMenuItemHelp.Text = "帮助";
            // 
            // ToolStripMenuItem31
            // 
            this.ToolStripMenuItem31.Image = global::YTGPS_Client.Properties.Resources.bthelp;
            this.ToolStripMenuItem31.Name = "ToolStripMenuItem31";
            this.ToolStripMenuItem31.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItem31.Text = "帮助";
            this.ToolStripMenuItem31.Click += new System.EventHandler(this.ToolStripMenuItemHelp_Click);
            // 
            // ToolStripMenuItem32
            // 
            this.ToolStripMenuItem32.Image = global::YTGPS_Client.Properties.Resources.btabout;
            this.ToolStripMenuItem32.Name = "ToolStripMenuItem32";
            this.ToolStripMenuItem32.Size = new System.Drawing.Size(118, 22);
            this.ToolStripMenuItem32.Text = "关于程序";
            this.ToolStripMenuItem32.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // timerTime
            // 
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.splitContainer2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(657, 127);
            this.panel5.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Silver;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewWatching);
            this.splitContainer2.Panel1.Controls.Add(this.labelX1);
            this.splitContainer2.Panel1MinSize = 5;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.listBoxMessage);
            this.splitContainer2.Panel2.Controls.Add(this.labelX2);
            this.splitContainer2.Panel2MinSize = 5;
            this.splitContainer2.Size = new System.Drawing.Size(653, 123);
            this.splitContainer2.SplitterDistance = 467;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewWatching
            // 
            this.listViewWatching.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewWatching.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.listViewWatching.Border.Class = "Office2007StatusBarBackground2";
            this.listViewWatching.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listViewWatching.ContextMenuStrip = this.contextMenuStripWatching;
            this.listViewWatching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWatching.FullRowSelect = true;
            this.listViewWatching.GridLines = true;
            this.listViewWatching.Location = new System.Drawing.Point(0, 22);
            this.listViewWatching.MultiSelect = false;
            this.listViewWatching.Name = "listViewWatching";
            this.listViewWatching.Size = new System.Drawing.Size(467, 101);
            this.listViewWatching.SmallImageList = this.imageList1;
            this.listViewWatching.TabIndex = 5;
            this.listViewWatching.UseCompatibleStateImageBehavior = false;
            this.listViewWatching.View = System.Windows.Forms.View.Details;
            this.listViewWatching.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPos_MouseDoubleClick);
            this.listViewWatching.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewWatching_MouseDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "车牌";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "GPS时间";
            this.columnHeader3.Width = 126;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "间隔(s)";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "定位";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "方向";
            this.columnHeader10.Width = 41;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "速度(km/h)";
            this.columnHeader12.Width = 75;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "车辆状态";
            this.columnHeader13.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "报警信息";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "地理位置";
            this.columnHeader15.Width = 300;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 14);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.BackgroundImage = global::YTGPS_Client.Properties.Resources.bk3;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(467, 22);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "监控车辆列表";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMessage.HorizontalScrollbar = true;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 22);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(183, 95);
            this.listBoxMessage.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.BackgroundImage = global::YTGPS_Client.Properties.Resources.bk3;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelX2.Location = new System.Drawing.Point(0, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(183, 22);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "系统信息";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2MinSize = 5;
            this.splitContainer1.Size = new System.Drawing.Size(657, 564);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // timerAlarmSound
            // 
            this.timerAlarmSound.Interval = 5000;
            this.timerAlarmSound.Tick += new System.EventHandler(this.timerAlarmSound_Tick);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.expandablePanelQueryPlace);
            this.panelEx1.Controls.Add(this.expandablePanelMarkPlace);
            this.panelEx1.Controls.Add(this.expandablePanelMapQuery);
            this.panelEx1.Controls.Add(this.expandablePanelRegionQuery);
            this.panelEx1.Controls.Add(this.expandablePanelMileage);
            this.panelEx1.Controls.Add(this.expandablePanelHisAlarm);
            this.panelEx1.Controls.Add(this.expandablePanelHisPos);
            this.panelEx1.Controls.Add(this.expandablePanelCarList);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx1.Location = new System.Drawing.Point(657, 49);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(256, 564);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // expandablePanelQueryPlace
            // 
            this.expandablePanelQueryPlace.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelQueryPlace.Controls.Add(this.listBoxPlaces);
            this.expandablePanelQueryPlace.Controls.Add(this.buttonPlaceQuery);
            this.expandablePanelQueryPlace.Controls.Add(this.comboBoxExPlaceKey);
            this.expandablePanelQueryPlace.Controls.Add(this.label15);
            this.expandablePanelQueryPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelQueryPlace.ExpandButtonVisible = false;
            this.expandablePanelQueryPlace.Expanded = false;
            this.expandablePanelQueryPlace.ExpandedBounds = new System.Drawing.Rectangle(0, 161, 256, 203);
            this.expandablePanelQueryPlace.ExpandOnTitleClick = true;
            this.expandablePanelQueryPlace.Location = new System.Drawing.Point(0, 182);
            this.expandablePanelQueryPlace.Name = "expandablePanelQueryPlace";
            this.expandablePanelQueryPlace.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelQueryPlace.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelQueryPlace.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelQueryPlace.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelQueryPlace.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelQueryPlace.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelQueryPlace.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelQueryPlace.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelQueryPlace.Style.GradientAngle = 90;
            this.expandablePanelQueryPlace.TabIndex = 5;
            this.expandablePanelQueryPlace.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelQueryPlace.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelQueryPlace.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelQueryPlace.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelQueryPlace.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelQueryPlace.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelQueryPlace.TitleStyle.GradientAngle = 90;
            this.expandablePanelQueryPlace.TitleText = "自定义标注查询";
            this.expandablePanelQueryPlace.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonPlaceQuery
            // 
            this.buttonPlaceQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPlaceQuery.Location = new System.Drawing.Point(196, 35);
            this.buttonPlaceQuery.Name = "buttonPlaceQuery";
            this.buttonPlaceQuery.Size = new System.Drawing.Size(52, 24);
            this.buttonPlaceQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonPlaceQuery.TabIndex = 17;
            this.buttonPlaceQuery.Text = "搜索";
            this.buttonPlaceQuery.Click += new System.EventHandler(this.buttonPlaceQuery_Click);
            // 
            // comboBoxExPlaceKey
            // 
            this.comboBoxExPlaceKey.DisplayMember = "Text";
            this.comboBoxExPlaceKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExPlaceKey.DropDownWidth = 120;
            this.comboBoxExPlaceKey.FormattingEnabled = true;
            this.comboBoxExPlaceKey.ItemHeight = 14;
            this.comboBoxExPlaceKey.Location = new System.Drawing.Point(52, 35);
            this.comboBoxExPlaceKey.Name = "comboBoxExPlaceKey";
            this.comboBoxExPlaceKey.Size = new System.Drawing.Size(136, 20);
            this.comboBoxExPlaceKey.TabIndex = 16;
            // 
            // expandablePanelMarkPlace
            // 
            this.expandablePanelMarkPlace.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelMarkPlace.Controls.Add(this.buttonMark);
            this.expandablePanelMarkPlace.Controls.Add(this.buttonMarkPoint);
            this.expandablePanelMarkPlace.Controls.Add(this.textBoxMarkLa);
            this.expandablePanelMarkPlace.Controls.Add(this.textBoxMarkLo);
            this.expandablePanelMarkPlace.Controls.Add(this.textBoxMarkName);
            this.expandablePanelMarkPlace.Controls.Add(this.label8);
            this.expandablePanelMarkPlace.Controls.Add(this.label9);
            this.expandablePanelMarkPlace.Controls.Add(this.label10);
            this.expandablePanelMarkPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelMarkPlace.ExpandButtonVisible = false;
            this.expandablePanelMarkPlace.Expanded = false;
            this.expandablePanelMarkPlace.ExpandedBounds = new System.Drawing.Rectangle(0, 138, 256, 224);
            this.expandablePanelMarkPlace.ExpandOnTitleClick = true;
            this.expandablePanelMarkPlace.Location = new System.Drawing.Point(0, 156);
            this.expandablePanelMarkPlace.Name = "expandablePanelMarkPlace";
            this.expandablePanelMarkPlace.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelMarkPlace.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelMarkPlace.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMarkPlace.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMarkPlace.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelMarkPlace.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelMarkPlace.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelMarkPlace.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelMarkPlace.Style.GradientAngle = 90;
            this.expandablePanelMarkPlace.TabIndex = 4;
            this.expandablePanelMarkPlace.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMarkPlace.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMarkPlace.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelMarkPlace.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelMarkPlace.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelMarkPlace.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelMarkPlace.TitleStyle.GradientAngle = 90;
            this.expandablePanelMarkPlace.TitleText = "添加自定义标注";
            this.expandablePanelMarkPlace.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonMark
            // 
            this.buttonMark.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonMark.Location = new System.Drawing.Point(136, 191);
            this.buttonMark.Name = "buttonMark";
            this.buttonMark.Size = new System.Drawing.Size(75, 25);
            this.buttonMark.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonMark.TabIndex = 14;
            this.buttonMark.Text = "提交标注";
            this.buttonMark.Click += new System.EventHandler(this.buttonMark_Click);
            // 
            // buttonMarkPoint
            // 
            this.buttonMarkPoint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonMarkPoint.Location = new System.Drawing.Point(48, 191);
            this.buttonMarkPoint.Name = "buttonMarkPoint";
            this.buttonMarkPoint.Size = new System.Drawing.Size(75, 25);
            this.buttonMarkPoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonMarkPoint.TabIndex = 13;
            this.buttonMarkPoint.Text = "选取坐标";
            this.buttonMarkPoint.Click += new System.EventHandler(this.buttonMarkPoint_Click);
            // 
            // textBoxMarkLa
            // 
            this.textBoxMarkLa.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBoxMarkLa.Border.Class = "TextBoxBorder";
            this.textBoxMarkLa.Location = new System.Drawing.Point(72, 135);
            this.textBoxMarkLa.Name = "textBoxMarkLa";
            this.textBoxMarkLa.ReadOnly = true;
            this.textBoxMarkLa.Size = new System.Drawing.Size(148, 20);
            this.textBoxMarkLa.TabIndex = 12;
            // 
            // textBoxMarkLo
            // 
            this.textBoxMarkLo.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBoxMarkLo.Border.Class = "TextBoxBorder";
            this.textBoxMarkLo.Location = new System.Drawing.Point(72, 105);
            this.textBoxMarkLo.Name = "textBoxMarkLo";
            this.textBoxMarkLo.ReadOnly = true;
            this.textBoxMarkLo.Size = new System.Drawing.Size(148, 20);
            this.textBoxMarkLo.TabIndex = 11;
            // 
            // textBoxMarkName
            // 
            // 
            // 
            // 
            this.textBoxMarkName.Border.Class = "TextBoxBorder";
            this.textBoxMarkName.Location = new System.Drawing.Point(72, 66);
            this.textBoxMarkName.Name = "textBoxMarkName";
            this.textBoxMarkName.Size = new System.Drawing.Size(148, 20);
            this.textBoxMarkName.TabIndex = 10;
            // 
            // expandablePanelMapQuery
            // 
            this.expandablePanelMapQuery.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelMapQuery.Controls.Add(this.buttonQueryLayer);
            this.expandablePanelMapQuery.Controls.Add(this.comboBoxLayers);
            this.expandablePanelMapQuery.Controls.Add(this.listBoxLayerPlace);
            this.expandablePanelMapQuery.Controls.Add(this.label13);
            this.expandablePanelMapQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelMapQuery.ExpandButtonVisible = false;
            this.expandablePanelMapQuery.Expanded = false;
            this.expandablePanelMapQuery.ExpandedBounds = new System.Drawing.Rectangle(0, 120, 256, 341);
            this.expandablePanelMapQuery.ExpandOnTitleClick = true;
            this.expandablePanelMapQuery.Location = new System.Drawing.Point(0, 130);
            this.expandablePanelMapQuery.Name = "expandablePanelMapQuery";
            this.expandablePanelMapQuery.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelMapQuery.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelMapQuery.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMapQuery.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMapQuery.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelMapQuery.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelMapQuery.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelMapQuery.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelMapQuery.Style.GradientAngle = 90;
            this.expandablePanelMapQuery.TabIndex = 3;
            this.expandablePanelMapQuery.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMapQuery.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMapQuery.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelMapQuery.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelMapQuery.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelMapQuery.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelMapQuery.TitleStyle.GradientAngle = 90;
            this.expandablePanelMapQuery.TitleText = "地图搜索";
            this.expandablePanelMapQuery.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonQueryLayer
            // 
            this.buttonQueryLayer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonQueryLayer.Location = new System.Drawing.Point(88, 65);
            this.buttonQueryLayer.Name = "buttonQueryLayer";
            this.buttonQueryLayer.Size = new System.Drawing.Size(100, 25);
            this.buttonQueryLayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonQueryLayer.TabIndex = 16;
            this.buttonQueryLayer.Text = "选取查询区域";
            this.buttonQueryLayer.Click += new System.EventHandler(this.buttonQueryLayer_Click);
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DisplayMember = "Text";
            this.comboBoxLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.DropDownWidth = 120;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(64, 35);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(176, 21);
            this.comboBoxLayers.TabIndex = 15;
            // 
            // expandablePanelRegionQuery
            // 
            this.expandablePanelRegionQuery.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelRegionQuery.Controls.Add(this.buttonRegionQuery2);
            this.expandablePanelRegionQuery.Controls.Add(this.listBoxRegionQuery);
            this.expandablePanelRegionQuery.Controls.Add(this.label12);
            this.expandablePanelRegionQuery.Controls.Add(this.buttonRegionQuery1);
            this.expandablePanelRegionQuery.Controls.Add(this.label5);
            this.expandablePanelRegionQuery.Controls.Add(this.dateTimePickerRegionQuery2);
            this.expandablePanelRegionQuery.Controls.Add(this.dateTimePickerRegionQuery1);
            this.expandablePanelRegionQuery.Controls.Add(this.label1);
            this.expandablePanelRegionQuery.Controls.Add(this.label2);
            this.expandablePanelRegionQuery.Controls.Add(this.comboBoxExRegionQueryTeam);
            this.expandablePanelRegionQuery.Controls.Add(this.label4);
            this.expandablePanelRegionQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelRegionQuery.ExpandButtonVisible = false;
            this.expandablePanelRegionQuery.Expanded = false;
            this.expandablePanelRegionQuery.ExpandedBounds = new System.Drawing.Rectangle(0, 96, 256, 336);
            this.expandablePanelRegionQuery.ExpandOnTitleClick = true;
            this.expandablePanelRegionQuery.Location = new System.Drawing.Point(0, 104);
            this.expandablePanelRegionQuery.Name = "expandablePanelRegionQuery";
            this.expandablePanelRegionQuery.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelRegionQuery.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelRegionQuery.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelRegionQuery.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelRegionQuery.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelRegionQuery.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelRegionQuery.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelRegionQuery.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelRegionQuery.Style.GradientAngle = 90;
            this.expandablePanelRegionQuery.TabIndex = 9;
            this.expandablePanelRegionQuery.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelRegionQuery.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelRegionQuery.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelRegionQuery.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelRegionQuery.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelRegionQuery.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelRegionQuery.TitleStyle.GradientAngle = 90;
            this.expandablePanelRegionQuery.TitleText = "区域查车";
            this.expandablePanelRegionQuery.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonRegionQuery2
            // 
            this.buttonRegionQuery2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRegionQuery2.Location = new System.Drawing.Point(133, 117);
            this.buttonRegionQuery2.Name = "buttonRegionQuery2";
            this.buttonRegionQuery2.Size = new System.Drawing.Size(95, 24);
            this.buttonRegionQuery2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonRegionQuery2.TabIndex = 38;
            this.buttonRegionQuery2.Text = "查 询";
            this.buttonRegionQuery2.Click += new System.EventHandler(this.buttonRegionQuery2_Click);
            // 
            // listBoxRegionQuery
            // 
            this.listBoxRegionQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRegionQuery.FormattingEnabled = true;
            this.listBoxRegionQuery.Location = new System.Drawing.Point(3, 163);
            this.listBoxRegionQuery.Name = "listBoxRegionQuery";
            this.listBoxRegionQuery.Size = new System.Drawing.Size(250, 4);
            this.listBoxRegionQuery.TabIndex = 37;
            this.listBoxRegionQuery.DoubleClick += new System.EventHandler(this.listBoxRegionQuery_DoubleClick);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(3, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(250, 22);
            this.label12.TabIndex = 36;
            this.label12.Text = " 查询结果(双击项目查询历史轨迹)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonRegionQuery1
            // 
            this.buttonRegionQuery1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRegionQuery1.Location = new System.Drawing.Point(32, 117);
            this.buttonRegionQuery1.Name = "buttonRegionQuery1";
            this.buttonRegionQuery1.Size = new System.Drawing.Size(95, 24);
            this.buttonRegionQuery1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonRegionQuery1.TabIndex = 34;
            this.buttonRegionQuery1.Text = "选取查询区域";
            this.buttonRegionQuery1.Click += new System.EventHandler(this.buttonRegionQuery1_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 28);
            this.label5.TabIndex = 35;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerRegionQuery2
            // 
            this.dateTimePickerRegionQuery2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerRegionQuery2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRegionQuery2.Location = new System.Drawing.Point(68, 87);
            this.dateTimePickerRegionQuery2.Name = "dateTimePickerRegionQuery2";
            this.dateTimePickerRegionQuery2.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerRegionQuery2.TabIndex = 30;
            // 
            // dateTimePickerRegionQuery1
            // 
            this.dateTimePickerRegionQuery1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerRegionQuery1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRegionQuery1.Location = new System.Drawing.Point(68, 60);
            this.dateTimePickerRegionQuery1.Name = "dateTimePickerRegionQuery1";
            this.dateTimePickerRegionQuery1.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerRegionQuery1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 26);
            this.label1.TabIndex = 31;
            this.label1.Text = " 结束时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 30);
            this.label2.TabIndex = 29;
            this.label2.Text = " 开始时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxExRegionQueryTeam
            // 
            this.comboBoxExRegionQueryTeam.DisplayMember = "Text";
            this.comboBoxExRegionQueryTeam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExRegionQueryTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExRegionQueryTeam.DropDownWidth = 120;
            this.comboBoxExRegionQueryTeam.FormattingEnabled = true;
            this.comboBoxExRegionQueryTeam.Location = new System.Drawing.Point(68, 29);
            this.comboBoxExRegionQueryTeam.Name = "comboBoxExRegionQueryTeam";
            this.comboBoxExRegionQueryTeam.Size = new System.Drawing.Size(132, 21);
            this.comboBoxExRegionQueryTeam.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 30);
            this.label4.TabIndex = 32;
            this.label4.Text = " 选择车队";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expandablePanelMileage
            // 
            this.expandablePanelMileage.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelMileage.Controls.Add(this.richTextBoxMileage);
            this.expandablePanelMileage.Controls.Add(this.label29);
            this.expandablePanelMileage.Controls.Add(this.buttonHisMileage);
            this.expandablePanelMileage.Controls.Add(this.dateTimePickerHisMileage2);
            this.expandablePanelMileage.Controls.Add(this.dateTimePickerHisMileage1);
            this.expandablePanelMileage.Controls.Add(this.label25);
            this.expandablePanelMileage.Controls.Add(this.label26);
            this.expandablePanelMileage.Controls.Add(this.comboBoxExMileageCar);
            this.expandablePanelMileage.Controls.Add(this.comboBoxExMileageTeam);
            this.expandablePanelMileage.Controls.Add(this.label27);
            this.expandablePanelMileage.Controls.Add(this.label28);
            this.expandablePanelMileage.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelMileage.ExpandButtonVisible = false;
            this.expandablePanelMileage.Expanded = false;
            this.expandablePanelMileage.ExpandedBounds = new System.Drawing.Rectangle(0, 72, 256, 349);
            this.expandablePanelMileage.ExpandOnTitleClick = true;
            this.expandablePanelMileage.Location = new System.Drawing.Point(0, 78);
            this.expandablePanelMileage.Name = "expandablePanelMileage";
            this.expandablePanelMileage.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelMileage.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelMileage.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMileage.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMileage.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelMileage.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelMileage.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelMileage.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelMileage.Style.GradientAngle = 90;
            this.expandablePanelMileage.TabIndex = 8;
            this.expandablePanelMileage.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelMileage.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelMileage.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelMileage.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelMileage.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelMileage.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelMileage.TitleStyle.GradientAngle = 90;
            this.expandablePanelMileage.TitleText = "里程及油耗查询";
            this.expandablePanelMileage.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // richTextBoxMileage
            // 
            this.richTextBoxMileage.BackColor = System.Drawing.Color.White;
            this.richTextBoxMileage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMileage.Location = new System.Drawing.Point(3, 169);
            this.richTextBoxMileage.Name = "richTextBoxMileage";
            this.richTextBoxMileage.ReadOnly = true;
            this.richTextBoxMileage.Size = new System.Drawing.Size(250, 0);
            this.richTextBoxMileage.TabIndex = 30;
            this.richTextBoxMileage.Text = "";
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Top;
            this.label29.Location = new System.Drawing.Point(3, 147);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(250, 22);
            this.label29.TabIndex = 29;
            this.label29.Text = " 查询结果";
            this.label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonHisMileage
            // 
            this.buttonHisMileage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisMileage.Location = new System.Drawing.Point(204, 121);
            this.buttonHisMileage.Name = "buttonHisMileage";
            this.buttonHisMileage.Size = new System.Drawing.Size(48, 22);
            this.buttonHisMileage.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonHisMileage.TabIndex = 24;
            this.buttonHisMileage.Text = "确定";
            this.buttonHisMileage.Click += new System.EventHandler(this.buttonHisMileage_Click);
            // 
            // dateTimePickerHisMileage2
            // 
            this.dateTimePickerHisMileage2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerHisMileage2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHisMileage2.Location = new System.Drawing.Point(68, 121);
            this.dateTimePickerHisMileage2.Name = "dateTimePickerHisMileage2";
            this.dateTimePickerHisMileage2.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerHisMileage2.TabIndex = 22;
            // 
            // dateTimePickerHisMileage1
            // 
            this.dateTimePickerHisMileage1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerHisMileage1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHisMileage1.Location = new System.Drawing.Point(68, 91);
            this.dateTimePickerHisMileage1.Name = "dateTimePickerHisMileage1";
            this.dateTimePickerHisMileage1.Size = new System.Drawing.Size(132, 20);
            this.dateTimePickerHisMileage1.TabIndex = 20;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Location = new System.Drawing.Point(3, 121);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(250, 26);
            this.label25.TabIndex = 23;
            this.label25.Text = " 结束时间";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Location = new System.Drawing.Point(3, 91);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(250, 30);
            this.label26.TabIndex = 21;
            this.label26.Text = " 开始时间";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxExMileageCar
            // 
            this.comboBoxExMileageCar.DisplayMember = "Text";
            this.comboBoxExMileageCar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExMileageCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExMileageCar.DropDownWidth = 120;
            this.comboBoxExMileageCar.FormattingEnabled = true;
            this.comboBoxExMileageCar.Location = new System.Drawing.Point(68, 61);
            this.comboBoxExMileageCar.Name = "comboBoxExMileageCar";
            this.comboBoxExMileageCar.Size = new System.Drawing.Size(132, 21);
            this.comboBoxExMileageCar.TabIndex = 28;
            // 
            // comboBoxExMileageTeam
            // 
            this.comboBoxExMileageTeam.DisplayMember = "Text";
            this.comboBoxExMileageTeam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExMileageTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExMileageTeam.DropDownWidth = 120;
            this.comboBoxExMileageTeam.FormattingEnabled = true;
            this.comboBoxExMileageTeam.Location = new System.Drawing.Point(68, 30);
            this.comboBoxExMileageTeam.Name = "comboBoxExMileageTeam";
            this.comboBoxExMileageTeam.Size = new System.Drawing.Size(132, 21);
            this.comboBoxExMileageTeam.TabIndex = 27;
            this.comboBoxExMileageTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxExMileageTeam_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Top;
            this.label27.Location = new System.Drawing.Point(3, 56);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(250, 35);
            this.label27.TabIndex = 26;
            this.label27.Text = " 选择车辆";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.label28.Location = new System.Drawing.Point(3, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(250, 30);
            this.label28.TabIndex = 25;
            this.label28.Text = " 选择车队";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expandablePanelHisAlarm
            // 
            this.expandablePanelHisAlarm.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelHisAlarm.Controls.Add(this.buttonHisAlarmList);
            this.expandablePanelHisAlarm.Controls.Add(this.label24);
            this.expandablePanelHisAlarm.Controls.Add(this.buttonHisAlarm);
            this.expandablePanelHisAlarm.Controls.Add(this.dateTimePickerAlarmTime2);
            this.expandablePanelHisAlarm.Controls.Add(this.listBoxHisAlarm);
            this.expandablePanelHisAlarm.Controls.Add(this.dateTimePickerAlarmTime1);
            this.expandablePanelHisAlarm.Controls.Add(this.label17);
            this.expandablePanelHisAlarm.Controls.Add(this.label18);
            this.expandablePanelHisAlarm.Controls.Add(this.label23);
            this.expandablePanelHisAlarm.Controls.Add(this.comboBoxExHisAlarmKey);
            this.expandablePanelHisAlarm.Controls.Add(this.treeViewHisAlarm);
            this.expandablePanelHisAlarm.Controls.Add(this.label22);
            this.expandablePanelHisAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelHisAlarm.ExpandButtonVisible = false;
            this.expandablePanelHisAlarm.Expanded = false;
            this.expandablePanelHisAlarm.ExpandedBounds = new System.Drawing.Rectangle(0, 48, 256, 380);
            this.expandablePanelHisAlarm.ExpandOnTitleClick = true;
            this.expandablePanelHisAlarm.Location = new System.Drawing.Point(0, 52);
            this.expandablePanelHisAlarm.Name = "expandablePanelHisAlarm";
            this.expandablePanelHisAlarm.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelHisAlarm.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelHisAlarm.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelHisAlarm.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelHisAlarm.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelHisAlarm.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelHisAlarm.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelHisAlarm.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelHisAlarm.Style.GradientAngle = 90;
            this.expandablePanelHisAlarm.TabIndex = 7;
            this.expandablePanelHisAlarm.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelHisAlarm.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelHisAlarm.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelHisAlarm.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelHisAlarm.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelHisAlarm.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelHisAlarm.TitleStyle.GradientAngle = 90;
            this.expandablePanelHisAlarm.TitleText = "历史报警";
            this.expandablePanelHisAlarm.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonHisAlarmList
            // 
            this.buttonHisAlarmList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisAlarmList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHisAlarmList.Location = new System.Drawing.Point(93, -4);
            this.buttonHisAlarmList.Name = "buttonHisAlarmList";
            this.buttonHisAlarmList.Size = new System.Drawing.Size(75, 25);
            this.buttonHisAlarmList.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonHisAlarmList.TabIndex = 23;
            this.buttonHisAlarmList.Text = "详细列表";
            this.buttonHisAlarmList.Click += new System.EventHandler(this.buttonHisAlarmList_Click);
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label24.Location = new System.Drawing.Point(3, -9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(250, 35);
            this.label24.TabIndex = 22;
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonHisAlarm
            // 
            this.buttonHisAlarm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisAlarm.Location = new System.Drawing.Point(192, 212);
            this.buttonHisAlarm.Name = "buttonHisAlarm";
            this.buttonHisAlarm.Size = new System.Drawing.Size(48, 22);
            this.buttonHisAlarm.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonHisAlarm.TabIndex = 18;
            this.buttonHisAlarm.Text = "确定";
            this.buttonHisAlarm.Click += new System.EventHandler(this.buttonHisAlarm_Click);
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Location = new System.Drawing.Point(3, 241);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(250, 17);
            this.label17.TabIndex = 21;
            this.label17.Text = " 历史报警列表(最多1000项)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Location = new System.Drawing.Point(3, 215);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(250, 26);
            this.label18.TabIndex = 20;
            this.label18.Text = " 结束时间";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.label23.Location = new System.Drawing.Point(3, 184);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(250, 30);
            this.label23.TabIndex = 19;
            this.label23.Text = " 开始时间";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxExHisAlarmKey
            // 
            this.comboBoxExHisAlarmKey.DisplayMember = "Text";
            this.comboBoxExHisAlarmKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExHisAlarmKey.FormattingEnabled = true;
            this.comboBoxExHisAlarmKey.ItemHeight = 14;
            this.comboBoxExHisAlarmKey.Location = new System.Drawing.Point(184, 30);
            this.comboBoxExHisAlarmKey.Name = "comboBoxExHisAlarmKey";
            this.comboBoxExHisAlarmKey.Size = new System.Drawing.Size(68, 20);
            this.comboBoxExHisAlarmKey.TabIndex = 17;
            this.comboBoxExHisAlarmKey.TextChanged += new System.EventHandler(this.comboBoxExHisAlarmKey_TextChanged);
            // 
            // treeViewHisAlarm
            // 
            this.treeViewHisAlarm.BackColor = System.Drawing.Color.White;
            this.treeViewHisAlarm.CheckBoxes = true;
            this.treeViewHisAlarm.ContextMenuStrip = this.contextMenuStripCars;
            this.treeViewHisAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeViewHisAlarm.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewHisAlarm.FullRowSelect = true;
            this.treeViewHisAlarm.ItemHeight = 17;
            this.treeViewHisAlarm.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.treeViewHisAlarm.Location = new System.Drawing.Point(3, 61);
            this.treeViewHisAlarm.Name = "treeViewHisAlarm";
            this.treeViewHisAlarm.Size = new System.Drawing.Size(250, 123);
            this.treeViewHisAlarm.TabIndex = 15;
            this.treeViewHisAlarm.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewHisAlarm_AfterCheck);
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Top;
            this.label22.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(3, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(250, 35);
            this.label22.TabIndex = 16;
            this.label22.Text = " 选择车辆　　　　  关键字过滤:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expandablePanelHisPos
            // 
            this.expandablePanelHisPos.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelHisPos.Controls.Add(this.buttonHisPosList);
            this.expandablePanelHisPos.Controls.Add(this.groupBoxHisPlay);
            this.expandablePanelHisPos.Controls.Add(this.listBoxHisPos);
            this.expandablePanelHisPos.Controls.Add(this.label14);
            this.expandablePanelHisPos.Controls.Add(this.buttonHis);
            this.expandablePanelHisPos.Controls.Add(this.dateTimePickerHisTime2);
            this.expandablePanelHisPos.Controls.Add(this.dateTimePickerHisTime1);
            this.expandablePanelHisPos.Controls.Add(this.label7);
            this.expandablePanelHisPos.Controls.Add(this.label6);
            this.expandablePanelHisPos.Controls.Add(this.comboBoxExHisCar);
            this.expandablePanelHisPos.Controls.Add(this.comboBoxExHisTeam);
            this.expandablePanelHisPos.Controls.Add(this.label21);
            this.expandablePanelHisPos.Controls.Add(this.label20);
            this.expandablePanelHisPos.Controls.Add(this.label11);
            this.expandablePanelHisPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelHisPos.ExpandButtonVisible = false;
            this.expandablePanelHisPos.Expanded = false;
            this.expandablePanelHisPos.ExpandedBounds = new System.Drawing.Rectangle(0, 24, 256, 388);
            this.expandablePanelHisPos.ExpandOnTitleClick = true;
            this.expandablePanelHisPos.Location = new System.Drawing.Point(0, 26);
            this.expandablePanelHisPos.Name = "expandablePanelHisPos";
            this.expandablePanelHisPos.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelHisPos.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelHisPos.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelHisPos.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelHisPos.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelHisPos.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelHisPos.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelHisPos.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelHisPos.Style.GradientAngle = 90;
            this.expandablePanelHisPos.TabIndex = 6;
            this.expandablePanelHisPos.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelHisPos.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelHisPos.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelHisPos.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelHisPos.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelHisPos.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelHisPos.TitleStyle.GradientAngle = 90;
            this.expandablePanelHisPos.TitleText = "历史轨迹";
            this.expandablePanelHisPos.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonHisPosList
            // 
            this.buttonHisPosList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisPosList.Location = new System.Drawing.Point(176, 151);
            this.buttonHisPosList.Name = "buttonHisPosList";
            this.buttonHisPosList.Size = new System.Drawing.Size(75, 22);
            this.buttonHisPosList.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonHisPosList.TabIndex = 14;
            this.buttonHisPosList.Text = "详细列表";
            this.buttonHisPosList.Click += new System.EventHandler(this.buttonHisPosList_Click);
            // 
            // groupBoxHisPlay
            // 
            this.groupBoxHisPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxHisPlay.Controls.Add(this.buttonHisPosPlayEnd);
            this.groupBoxHisPlay.Controls.Add(this.buttonHisPosPlayStart);
            this.groupBoxHisPlay.Controls.Add(this.sliderHisPosPlay);
            this.groupBoxHisPlay.Enabled = false;
            this.groupBoxHisPlay.Location = new System.Drawing.Point(5, -56);
            this.groupBoxHisPlay.Name = "groupBoxHisPlay";
            this.groupBoxHisPlay.Size = new System.Drawing.Size(248, 74);
            this.groupBoxHisPlay.TabIndex = 20;
            this.groupBoxHisPlay.TabStop = false;
            this.groupBoxHisPlay.Text = "动态回放";
            // 
            // buttonHisPosPlayEnd
            // 
            this.buttonHisPosPlayEnd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisPosPlayEnd.Location = new System.Drawing.Point(140, 43);
            this.buttonHisPosPlayEnd.Name = "buttonHisPosPlayEnd";
            this.buttonHisPosPlayEnd.Size = new System.Drawing.Size(75, 25);
            this.buttonHisPosPlayEnd.TabIndex = 2;
            this.buttonHisPosPlayEnd.Text = "停止回放";
            this.buttonHisPosPlayEnd.Click += new System.EventHandler(this.buttonHisPosPlayEnd_Click);
            // 
            // buttonHisPosPlayStart
            // 
            this.buttonHisPosPlayStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHisPosPlayStart.Location = new System.Drawing.Point(40, 43);
            this.buttonHisPosPlayStart.Name = "buttonHisPosPlayStart";
            this.buttonHisPosPlayStart.Size = new System.Drawing.Size(75, 25);
            this.buttonHisPosPlayStart.TabIndex = 1;
            this.buttonHisPosPlayStart.Text = "开始回放";
            this.buttonHisPosPlayStart.Click += new System.EventHandler(this.buttonHisPosPlayStart_Click);
            // 
            // sliderHisPosPlay
            // 
            this.sliderHisPosPlay.BackColor = System.Drawing.Color.Transparent;
            this.sliderHisPosPlay.LabelWidth = 60;
            this.sliderHisPosPlay.Location = new System.Drawing.Point(8, 17);
            this.sliderHisPosPlay.Maximum = 5;
            this.sliderHisPosPlay.Minimum = 1;
            this.sliderHisPosPlay.Name = "sliderHisPosPlay";
            this.sliderHisPosPlay.Size = new System.Drawing.Size(236, 25);
            this.sliderHisPosPlay.TabIndex = 0;
            this.sliderHisPosPlay.Text = "回放速度";
            this.sliderHisPosPlay.Value = 2;
            this.sliderHisPosPlay.ValueChanged += new System.EventHandler(this.sliderHisPosPlay_ValueChanged);
            // 
            // buttonHis
            // 
            this.buttonHis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHis.Location = new System.Drawing.Point(204, 121);
            this.buttonHis.Name = "buttonHis";
            this.buttonHis.Size = new System.Drawing.Size(48, 22);
            this.buttonHis.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonHis.TabIndex = 13;
            this.buttonHis.Text = "确定";
            this.buttonHis.Click += new System.EventHandler(this.buttonHis_Click);
            // 
            // comboBoxExHisCar
            // 
            this.comboBoxExHisCar.DisplayMember = "Text";
            this.comboBoxExHisCar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExHisCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExHisCar.DropDownWidth = 120;
            this.comboBoxExHisCar.FormattingEnabled = true;
            this.comboBoxExHisCar.Location = new System.Drawing.Point(68, 61);
            this.comboBoxExHisCar.Name = "comboBoxExHisCar";
            this.comboBoxExHisCar.Size = new System.Drawing.Size(132, 21);
            this.comboBoxExHisCar.TabIndex = 19;
            // 
            // comboBoxExHisTeam
            // 
            this.comboBoxExHisTeam.DisplayMember = "Text";
            this.comboBoxExHisTeam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExHisTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExHisTeam.DropDownWidth = 120;
            this.comboBoxExHisTeam.FormattingEnabled = true;
            this.comboBoxExHisTeam.Location = new System.Drawing.Point(68, 30);
            this.comboBoxExHisTeam.Name = "comboBoxExHisTeam";
            this.comboBoxExHisTeam.Size = new System.Drawing.Size(132, 21);
            this.comboBoxExHisTeam.TabIndex = 18;
            this.comboBoxExHisTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxExHisTeam_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Location = new System.Drawing.Point(3, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(250, 35);
            this.label21.TabIndex = 17;
            this.label21.Text = " 选择车辆";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Location = new System.Drawing.Point(3, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(250, 30);
            this.label20.TabIndex = 16;
            this.label20.Text = " 选择车队";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, -52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 78);
            this.label11.TabIndex = 15;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expandablePanelCarList
            // 
            this.expandablePanelCarList.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelCarList.Controls.Add(this.buttonQueryCar);
            this.expandablePanelCarList.Controls.Add(this.comboBoxExKey);
            this.expandablePanelCarList.Controls.Add(this.treeViewCars);
            this.expandablePanelCarList.Controls.Add(this.label3);
            this.expandablePanelCarList.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelCarList.ExpandButtonVisible = false;
            this.expandablePanelCarList.Expanded = false;
            this.expandablePanelCarList.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 256, 376);
            this.expandablePanelCarList.ExpandOnTitleClick = true;
            this.expandablePanelCarList.Location = new System.Drawing.Point(0, 0);
            this.expandablePanelCarList.Name = "expandablePanelCarList";
            this.expandablePanelCarList.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.expandablePanelCarList.Size = new System.Drawing.Size(256, 26);
            this.expandablePanelCarList.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelCarList.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelCarList.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.expandablePanelCarList.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelCarList.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelCarList.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelCarList.Style.GradientAngle = 90;
            this.expandablePanelCarList.TabIndex = 2;
            this.expandablePanelCarList.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelCarList.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandablePanelCarList.TitleStyle.BackColor2.Color = System.Drawing.Color.SteelBlue;
            this.expandablePanelCarList.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelCarList.TitleStyle.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelCarList.TitleStyle.ForeColor.Color = System.Drawing.Color.LavenderBlush;
            this.expandablePanelCarList.TitleStyle.GradientAngle = 90;
            this.expandablePanelCarList.TitleText = "车队、车辆列表";
            this.expandablePanelCarList.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.expandablePanelExpandedChanged);
            // 
            // buttonQueryCar
            // 
            this.buttonQueryCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonQueryCar.Location = new System.Drawing.Point(180, 30);
            this.buttonQueryCar.Name = "buttonQueryCar";
            this.buttonQueryCar.Size = new System.Drawing.Size(72, 22);
            this.buttonQueryCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonQueryCar.TabIndex = 14;
            this.buttonQueryCar.Text = "高级查询";
            this.buttonQueryCar.Click += new System.EventHandler(this.buttonQueryCar_Click);
            // 
            // comboBoxExKey
            // 
            this.comboBoxExKey.DisplayMember = "Text";
            this.comboBoxExKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExKey.FormattingEnabled = true;
            this.comboBoxExKey.ItemHeight = 14;
            this.comboBoxExKey.Location = new System.Drawing.Point(72, 30);
            this.comboBoxExKey.Name = "comboBoxExKey";
            this.comboBoxExKey.Size = new System.Drawing.Size(104, 20);
            this.comboBoxExKey.TabIndex = 5;
            this.comboBoxExKey.TextChanged += new System.EventHandler(this.comboBoxExKey_TextChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "关键字过滤:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerHisPlay
            // 
            this.timerHisPlay.Interval = 250;
            this.timerHisPlay.Tick += new System.EventHandler(this.timerHisPlay_Tick);
            // 
            // timerTest
            // 
            this.timerTest.Interval = 10000;
            this.timerTest.Tick += new System.EventHandler(this.timerTest_Tick);
            // 
            // timerCheckConn
            // 
            this.timerCheckConn.Interval = 30000;
            this.timerCheckConn.Tick += new System.EventHandler(this.timerCheckConn_Tick);
            // 
            // timerReconn
            // 
            this.timerReconn.Interval = 10000;
            this.timerReconn.Tick += new System.EventHandler(this.timerReconn_Tick);
            // 
            // bar2
            // 
            this.bar2.AccessibleDescription = "DotNetBar Bar (bar2)";
            this.bar2.AccessibleName = "DotNetBar Bar";
            this.bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar2.BackColor = System.Drawing.Color.Transparent;
            this.bar2.BackgroundImage = global::YTGPS_Client.Properties.Resources.bk;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItemLogin,
            this.buttonItemLogout,
            this.buttonItemExit,
            this.labelItem1,
            this.buttonItemSidebar,
            this.buttonItemConfig,
            this.labelItem3,
            this.buttonItemAbout,
            this.buttonItemHelp});
            this.bar2.Location = new System.Drawing.Point(0, 24);
            this.bar2.Name = "bar2";
            this.bar2.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bar2.Size = new System.Drawing.Size(913, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar2.TabIndex = 5;
            this.bar2.TabStop = false;
            // 
            // buttonItemLogin
            // 
            this.buttonItemLogin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemLogin.Image = ((System.Drawing.Image)(resources.GetObject("buttonItemLogin.Image")));
            this.buttonItemLogin.Name = "buttonItemLogin";
            this.buttonItemLogin.Text = "登陆";
            this.buttonItemLogin.Click += new System.EventHandler(this.ToolStripMenuItemLogin_Click);
            // 
            // buttonItemLogout
            // 
            this.buttonItemLogout.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemLogout.Image = global::YTGPS_Client.Properties.Resources.btlogout;
            this.buttonItemLogout.Name = "buttonItemLogout";
            this.buttonItemLogout.Text = "取消登陆";
            this.buttonItemLogout.Click += new System.EventHandler(this.ToolStripMenuItemLogout_Click);
            // 
            // buttonItemExit
            // 
            this.buttonItemExit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemExit.Image = global::YTGPS_Client.Properties.Resources.btexit;
            this.buttonItemExit.Name = "buttonItemExit";
            this.buttonItemExit.Text = "退出";
            this.buttonItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "|";
            // 
            // buttonItemSidebar
            // 
            this.buttonItemSidebar.AutoCheckOnClick = true;
            this.buttonItemSidebar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemSidebar.Checked = true;
            this.buttonItemSidebar.Image = global::YTGPS_Client.Properties.Resources.btsidebar;
            this.buttonItemSidebar.Name = "buttonItemSidebar";
            this.buttonItemSidebar.Text = "侧边栏";
            this.buttonItemSidebar.Click += new System.EventHandler(this.buttonItemSidebar_Click);
            // 
            // buttonItemConfig
            // 
            this.buttonItemConfig.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemConfig.Image = global::YTGPS_Client.Properties.Resources.btconfig;
            this.buttonItemConfig.Name = "buttonItemConfig";
            this.buttonItemConfig.Text = "程序设置";
            this.buttonItemConfig.Click += new System.EventHandler(this.ToolStripMenuItemConfig_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "|";
            // 
            // buttonItemAbout
            // 
            this.buttonItemAbout.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemAbout.Image = global::YTGPS_Client.Properties.Resources.btabout;
            this.buttonItemAbout.Name = "buttonItemAbout";
            this.buttonItemAbout.Text = "关于程序";
            this.buttonItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // buttonItemHelp
            // 
            this.buttonItemHelp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemHelp.Image = global::YTGPS_Client.Properties.Resources.bthelp;
            this.buttonItemHelp.Name = "buttonItemHelp";
            this.buttonItemHelp.Text = "帮助";
            this.buttonItemHelp.Visible = false;
            this.buttonItemHelp.Click += new System.EventHandler(this.ToolStripMenuItemHelp_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 625);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS车辆监控系统客户端";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResizeBegin += new System.EventHandler(this.FormMain_ResizeBegin);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStripWatching.ResumeLayout(false);
            this.contextMenuStripCars.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.expandablePanelQueryPlace.ResumeLayout(false);
            this.expandablePanelMarkPlace.ResumeLayout(false);
            this.expandablePanelMarkPlace.PerformLayout();
            this.expandablePanelMapQuery.ResumeLayout(false);
            this.expandablePanelRegionQuery.ResumeLayout(false);
            this.expandablePanelMileage.ResumeLayout(false);
            this.expandablePanelHisAlarm.ResumeLayout(false);
            this.expandablePanelHisPos.ResumeLayout(false);
            this.groupBoxHisPlay.ResumeLayout(false);
            this.expandablePanelCarList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripWatching;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWatchingGeo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWatchingShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWatchingCancel;
        private System.Windows.Forms.Panel panel2;
        private MapInfo.Windows.Controls.MapControl mapControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemApp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0Config;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1AccoutList;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem31;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem32;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerHisTime2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerHisTime1;
        private System.Windows.Forms.ListBox listBoxPlaces;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLogin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMousePos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAlarm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.TreeView treeViewCars;
        private System.Windows.Forms.Panel panelOverview;
        private MapInfo.Windows.Controls.MapControl mapControlOver;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0Login;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0Logout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWatchingCancelAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCars;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarModify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarAddTeam;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarAddCar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarPoint;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarNewDeclare;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarDeclareList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarDeclareHis;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBoxHisPos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.ListBox listBoxHisAlarm;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlarmTime2;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlarmTime1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1ModUserInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarDel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarOrder;
        private System.Windows.Forms.ListBox listBoxLayerPlace;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOverService;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarSetStoped;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarSetServiceTime;
        private System.Windows.Forms.Timer timerAlarmSound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCarNotify;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewWatching;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelCarList;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelMapQuery;
        private DevComponents.DotNetBar.ButtonX buttonQueryLayer;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxLayers;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelQueryPlace;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelMarkPlace;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxMarkLa;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxMarkLo;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxMarkName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExPlaceKey;
        private DevComponents.DotNetBar.ButtonX buttonPlaceQuery;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExKey;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX buttonMark;
        private DevComponents.DotNetBar.ButtonX buttonMarkPoint;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelHisAlarm;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelHisPos;
        private DevComponents.DotNetBar.ButtonX buttonHisPosList;
        private DevComponents.DotNetBar.ButtonX buttonHis;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelMileage;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelRegionQuery;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExHisCar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExHisTeam;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExHisAlarmKey;
        private System.Windows.Forms.TreeView treeViewHisAlarm;
        private System.Windows.Forms.Label label22;
        private DevComponents.DotNetBar.ButtonX buttonHisAlarm;
        private DevComponents.DotNetBar.ButtonX buttonHisAlarmList;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private DevComponents.DotNetBar.ButtonX buttonHisMileage;
        private System.Windows.Forms.DateTimePicker dateTimePickerHisMileage2;
        private System.Windows.Forms.DateTimePicker dateTimePickerHisMileage1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExMileageCar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExMileageTeam;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RichTextBox richTextBoxMileage;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBoxHisPlay;
        private DevComponents.DotNetBar.Controls.Slider sliderHisPosPlay;
        private DevComponents.DotNetBar.ButtonX buttonHisPosPlayEnd;
        private DevComponents.DotNetBar.ButtonX buttonHisPosPlayStart;
        private System.Windows.Forms.Timer timerHisPlay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMap;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSound;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3AlarmSound;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3NotifySound;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonItemDefault;
        private DevComponents.DotNetBar.ButtonItem buttonItemZoomin;
        private DevComponents.DotNetBar.ButtonItem buttonItemZoomout;
        private DevComponents.DotNetBar.ButtonItem buttonItemCenter;
        private DevComponents.DotNetBar.ButtonItem buttonItemPan;
        private DevComponents.DotNetBar.ButtonItem buttonItemDistance;
        private DevComponents.DotNetBar.ButtonItem buttonItemFullMap;
        private DevComponents.DotNetBar.ButtonItem buttonItemClearMap;
        private DevComponents.DotNetBar.ButtonItem buttonItemMimiMap;
        private DevComponents.DotNetBar.ButtonItem buttonItemGeoInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2ChangeMap;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2LayerControl;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hisPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hisLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hisAlarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMap;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer timerTest;
        private System.Windows.Forms.Timer timerCheckConn;
        private DevComponents.DotNetBar.ButtonX buttonQueryCar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystemWarnSound;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3ErrDownSound;
        private System.Windows.Forms.Timer timerReconn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemForm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChatForm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuery;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryOperation;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryOrder;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQueryDeclare;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHisPos;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHisAlarm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGisServer;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem buttonItemLogin;
        private DevComponents.DotNetBar.ButtonItem buttonItemLogout;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItemExit;
        private DevComponents.DotNetBar.ButtonItem buttonItemSidebar;
        private DevComponents.DotNetBar.ButtonItem buttonItemAbout;
        private DevComponents.DotNetBar.ButtonItem buttonItemHelp;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItemConfig;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCarList;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLockDown;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.DateTimePicker dateTimePickerRegionQuery2;
        private System.Windows.Forms.DateTimePicker dateTimePickerRegionQuery1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExRegionQueryTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxRegionQuery;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.ButtonX buttonRegionQuery1;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.ButtonX buttonRegionQuery2;
    }
}

