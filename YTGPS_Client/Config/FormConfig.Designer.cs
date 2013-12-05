namespace YTGPS_Client
{
    partial class FormConfig
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
            if(disposing && (components != null))
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
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMod = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxpw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxuser = new System.Windows.Forms.TextBox();
            this.textBoxport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxhost = new System.Windows.Forms.TextBox();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonCanel = new DevComponents.DotNetBar.ButtonX();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.checkBoxautoStartGis = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxtelPort = new System.Windows.Forms.TextBox();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.checkBoxautoLogin = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxuserType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewMaps = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.checkBoxautoGetCarGeoInfo = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxautoChatForm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxautoWatchOnHandleAlarm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxautoWatchOnPoint = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxautoAlarmList = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxautoReconn = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.Location = new System.Drawing.Point(425, 4);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.Size = new System.Drawing.Size(75, 23);
            this.buttonX7.TabIndex = 8;
            this.buttonX7.Text = "添加";
            this.buttonX7.Click += new System.EventHandler(this.buttonAddMap_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAdd,
            this.ToolStripMenuItemMod,
            this.ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 70);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItemAdd.Text = "添加";
            this.ToolStripMenuItemAdd.Click += new System.EventHandler(this.buttonAddMap_Click);
            // 
            // ToolStripMenuItemMod
            // 
            this.ToolStripMenuItemMod.Name = "ToolStripMenuItemMod";
            this.ToolStripMenuItemMod.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItemMod.Text = "修改";
            this.ToolStripMenuItemMod.Click += new System.EventHandler(this.ToolStripMenuItemMod_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItem.Text = "删除";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(20, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "地图列表";
            // 
            // textBoxpw
            // 
            this.textBoxpw.Location = new System.Drawing.Point(319, 157);
            this.textBoxpw.Name = "textBoxpw";
            this.textBoxpw.PasswordChar = '*';
            this.textBoxpw.Size = new System.Drawing.Size(151, 21);
            this.textBoxpw.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(284, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "密码";
            // 
            // textBoxuser
            // 
            this.textBoxuser.Location = new System.Drawing.Point(102, 157);
            this.textBoxuser.Name = "textBoxuser";
            this.textBoxuser.Size = new System.Drawing.Size(156, 21);
            this.textBoxuser.TabIndex = 4;
            // 
            // textBoxport
            // 
            this.textBoxport.Location = new System.Drawing.Point(319, 74);
            this.textBoxport.Name = "textBoxport";
            this.textBoxport.Size = new System.Drawing.Size(151, 21);
            this.textBoxport.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(284, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "端口";
            // 
            // textBoxhost
            // 
            this.textBoxhost.Location = new System.Drawing.Point(102, 74);
            this.textBoxhost.Name = "textBoxhost";
            this.textBoxhost.Size = new System.Drawing.Size(156, 21);
            this.textBoxhost.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(323, 295);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(83, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonOK.TabIndex = 43;
            this.buttonOK.Text = "确定";
            this.buttonOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOK_MouseDown);
            // 
            // buttonCanel
            // 
            this.buttonCanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCanel.Location = new System.Drawing.Point(423, 295);
            this.buttonCanel.Name = "buttonCanel";
            this.buttonCanel.Size = new System.Drawing.Size(80, 23);
            this.buttonCanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonCanel.TabIndex = 44;
            this.buttonCanel.Text = "取消";
            // 
            // tabControl2
            // 
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel4);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Controls.Add(this.tabControlPanel3);
            this.tabControl2.Location = new System.Drawing.Point(4, 28);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(520, 256);
            this.tabControl2.TabIndex = 45;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Tabs.Add(this.tabItem4);
            this.tabControl2.Tabs.Add(this.tabItem3);
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.checkBoxautoStartGis);
            this.tabControlPanel4.Controls.Add(this.label6);
            this.tabControlPanel4.Controls.Add(this.textBoxtelPort);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(520, 230);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // checkBoxautoStartGis
            // 
            this.checkBoxautoStartGis.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoStartGis.Location = new System.Drawing.Point(88, 34);
            this.checkBoxautoStartGis.Name = "checkBoxautoStartGis";
            this.checkBoxautoStartGis.Size = new System.Drawing.Size(137, 23);
            this.checkBoxautoStartGis.TabIndex = 12;
            this.checkBoxautoStartGis.Text = "登陆成功后自动启动";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(86, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "通讯端口";
            // 
            // textBoxtelPort
            // 
            this.textBoxtelPort.Location = new System.Drawing.Point(152, 71);
            this.textBoxtelPort.Name = "textBoxtelPort";
            this.textBoxtelPort.Size = new System.Drawing.Size(136, 21);
            this.textBoxtelPort.TabIndex = 0;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "GIS扩展端口";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.checkBoxautoLogin);
            this.tabControlPanel2.Controls.Add(this.label3);
            this.tabControlPanel2.Controls.Add(this.label2);
            this.tabControlPanel2.Controls.Add(this.label1);
            this.tabControlPanel2.Controls.Add(this.comboBoxuserType);
            this.tabControlPanel2.Controls.Add(this.textBoxhost);
            this.tabControlPanel2.Controls.Add(this.label7);
            this.tabControlPanel2.Controls.Add(this.textBoxpw);
            this.tabControlPanel2.Controls.Add(this.textBoxport);
            this.tabControlPanel2.Controls.Add(this.label5);
            this.tabControlPanel2.Controls.Add(this.textBoxuser);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(520, 230);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // checkBoxautoLogin
            // 
            this.checkBoxautoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoLogin.Location = new System.Drawing.Point(54, 34);
            this.checkBoxautoLogin.Name = "checkBoxautoLogin";
            this.checkBoxautoLogin.Size = new System.Drawing.Size(140, 23);
            this.checkBoxautoLogin.TabIndex = 28;
            this.checkBoxautoLogin.Text = "自动登陆后台服务器";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(49, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(37, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "用户类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(49, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "服务器";
            // 
            // comboBoxuserType
            // 
            this.comboBoxuserType.DisplayMember = "Text";
            this.comboBoxuserType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxuserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxuserType.FormattingEnabled = true;
            this.comboBoxuserType.Items.AddRange(new object[] {
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.comboBoxuserType.Location = new System.Drawing.Point(101, 115);
            this.comboBoxuserType.Name = "comboBoxuserType";
            this.comboBoxuserType.Size = new System.Drawing.Size(156, 22);
            this.comboBoxuserType.TabIndex = 24;
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "系统管理员";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "分控管理员";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "车队管理员";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "车辆管理员";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "自动登陆设置";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.buttonX7);
            this.tabControlPanel1.Controls.Add(this.listViewMaps);
            this.tabControlPanel1.Controls.Add(this.label9);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(520, 230);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // listViewMaps
            // 
            // 
            // 
            // 
            this.listViewMaps.Border.Class = "ListViewBorder";
            this.listViewMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMaps.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewMaps.FullRowSelect = true;
            this.listViewMaps.GridLines = true;
            this.listViewMaps.Location = new System.Drawing.Point(20, 33);
            this.listViewMaps.MultiSelect = false;
            this.listViewMaps.Name = "listViewMaps";
            this.listViewMaps.Size = new System.Drawing.Size(480, 182);
            this.listViewMaps.SmallImageList = this.imageList1;
            this.listViewMaps.TabIndex = 9;
            this.listViewMaps.UseCompatibleStateImageBehavior = false;
            this.listViewMaps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "索引文件";
            this.columnHeader2.Width = 350;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 14);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "地图设置";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.checkBoxautoGetCarGeoInfo);
            this.tabControlPanel3.Controls.Add(this.checkBoxautoChatForm);
            this.tabControlPanel3.Controls.Add(this.checkBoxautoWatchOnHandleAlarm);
            this.tabControlPanel3.Controls.Add(this.checkBoxautoWatchOnPoint);
            this.tabControlPanel3.Controls.Add(this.checkBoxautoAlarmList);
            this.tabControlPanel3.Controls.Add(this.checkBoxautoReconn);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(520, 230);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // checkBoxautoGetCarGeoInfo
            // 
            this.checkBoxautoGetCarGeoInfo.AutoSize = true;
            this.checkBoxautoGetCarGeoInfo.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoGetCarGeoInfo.Location = new System.Drawing.Point(76, 162);
            this.checkBoxautoGetCarGeoInfo.Name = "checkBoxautoGetCarGeoInfo";
            this.checkBoxautoGetCarGeoInfo.Size = new System.Drawing.Size(248, 18);
            this.checkBoxautoGetCarGeoInfo.TabIndex = 5;
            this.checkBoxautoGetCarGeoInfo.Text = "车辆监控信息更新时自动获取其地理位置";
            // 
            // checkBoxautoChatForm
            // 
            this.checkBoxautoChatForm.AutoSize = true;
            this.checkBoxautoChatForm.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoChatForm.Location = new System.Drawing.Point(76, 138);
            this.checkBoxautoChatForm.Name = "checkBoxautoChatForm";
            this.checkBoxautoChatForm.Size = new System.Drawing.Size(161, 18);
            this.checkBoxautoChatForm.TabIndex = 4;
            this.checkBoxautoChatForm.Text = "收到信息时弹出信息窗口";
            // 
            // checkBoxautoWatchOnHandleAlarm
            // 
            this.checkBoxautoWatchOnHandleAlarm.AutoSize = true;
            this.checkBoxautoWatchOnHandleAlarm.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoWatchOnHandleAlarm.Location = new System.Drawing.Point(76, 114);
            this.checkBoxautoWatchOnHandleAlarm.Name = "checkBoxautoWatchOnHandleAlarm";
            this.checkBoxautoWatchOnHandleAlarm.Size = new System.Drawing.Size(174, 18);
            this.checkBoxautoWatchOnHandleAlarm.TabIndex = 3;
            this.checkBoxautoWatchOnHandleAlarm.Text = "接警成功时自动监控此车辆";
            // 
            // checkBoxautoWatchOnPoint
            // 
            this.checkBoxautoWatchOnPoint.AutoSize = true;
            this.checkBoxautoWatchOnPoint.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoWatchOnPoint.Location = new System.Drawing.Point(76, 91);
            this.checkBoxautoWatchOnPoint.Name = "checkBoxautoWatchOnPoint";
            this.checkBoxautoWatchOnPoint.Size = new System.Drawing.Size(149, 18);
            this.checkBoxautoWatchOnPoint.TabIndex = 2;
            this.checkBoxautoWatchOnPoint.Text = "定位时自动监控此车辆";
            // 
            // checkBoxautoAlarmList
            // 
            this.checkBoxautoAlarmList.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoAlarmList.Location = new System.Drawing.Point(76, 66);
            this.checkBoxautoAlarmList.Name = "checkBoxautoAlarmList";
            this.checkBoxautoAlarmList.Size = new System.Drawing.Size(198, 21);
            this.checkBoxautoAlarmList.TabIndex = 1;
            this.checkBoxautoAlarmList.Text = "收到新报警信息时弹出报警列表";
            // 
            // checkBoxautoReconn
            // 
            this.checkBoxautoReconn.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxautoReconn.Location = new System.Drawing.Point(76, 42);
            this.checkBoxautoReconn.Name = "checkBoxautoReconn";
            this.checkBoxautoReconn.Size = new System.Drawing.Size(125, 21);
            this.checkBoxautoReconn.TabIndex = 0;
            this.checkBoxautoReconn.Text = "意外断线自动重连";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "其他";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 336);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.buttonCanel);
            this.Controls.Add(this.buttonOK);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.ShowInTaskbar = false;
            this.Text = "程序设置";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormConfig_KeyPress);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.Controls.SetChildIndex(this.buttonCanel, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel4.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxpw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxuser;
        private System.Windows.Forms.TextBox textBoxport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxhost;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonCanel;
        private DevComponents.DotNetBar.ButtonX buttonX7;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewMaps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxuserType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoReconn;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoAlarmList;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoLogin;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoWatchOnHandleAlarm;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoWatchOnPoint;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoChatForm;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxtelPort;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMod;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoGetCarGeoInfo;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxautoStartGis;
    }
}