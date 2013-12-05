namespace YTGPS_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelModemCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonModemStop = new System.Windows.Forms.Button();
            this.buttonModemStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonUdpStop = new System.Windows.Forms.Button();
            this.buttonUdpStart = new System.Windows.Forms.Button();
            this.labelGprsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTcpStop = new System.Windows.Forms.Button();
            this.buttonTcpStart = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelDataCount = new System.Windows.Forms.Label();
            this.groupBoxSend = new System.Windows.Forms.GroupBox();
            this.comboBoxContent = new System.Windows.Forms.ComboBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDataStop = new System.Windows.Forms.Button();
            this.buttonDataStart = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewSmsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripSmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSmsStop = new System.Windows.Forms.Button();
            this.buttonSmsStart = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timerTest = new System.Windows.Forms.Timer(this.components);
            this.timerSmsTest = new System.Windows.Forms.Timer(this.components);
            this.timerSmsReconn = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timerTCP = new System.Windows.Forms.Timer(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxSend.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStripSmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelModemCount);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.buttonModemStop);
            this.groupBox5.Controls.Add(this.buttonModemStart);
            this.groupBox5.Location = new System.Drawing.Point(12, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(428, 56);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "短信猫服务";
            // 
            // labelModemCount
            // 
            this.labelModemCount.AutoSize = true;
            this.labelModemCount.Location = new System.Drawing.Point(385, 25);
            this.labelModemCount.Name = "labelModemCount";
            this.labelModemCount.Size = new System.Drawing.Size(11, 12);
            this.labelModemCount.TabIndex = 5;
            this.labelModemCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "已连接";
            // 
            // buttonModemStop
            // 
            this.buttonModemStop.Enabled = false;
            this.buttonModemStop.Location = new System.Drawing.Point(225, 20);
            this.buttonModemStop.Name = "buttonModemStop";
            this.buttonModemStop.Size = new System.Drawing.Size(97, 23);
            this.buttonModemStop.TabIndex = 1;
            this.buttonModemStop.Text = "停止服务";
            this.buttonModemStop.UseVisualStyleBackColor = true;
            this.buttonModemStop.Click += new System.EventHandler(this.buttonModemStop_Click);
            // 
            // buttonModemStart
            // 
            this.buttonModemStart.Location = new System.Drawing.Point(92, 20);
            this.buttonModemStart.Name = "buttonModemStart";
            this.buttonModemStart.Size = new System.Drawing.Size(97, 23);
            this.buttonModemStart.TabIndex = 0;
            this.buttonModemStart.Text = "启动服务";
            this.buttonModemStart.UseVisualStyleBackColor = true;
            this.buttonModemStart.Click += new System.EventHandler(this.buttonModemStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonUdpStop);
            this.groupBox2.Controls.Add(this.buttonUdpStart);
            this.groupBox2.Controls.Add(this.labelGprsCount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonTcpStop);
            this.groupBox2.Controls.Add(this.buttonTcpStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 90);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GPRS/CDMA服务";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "UDP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "TCP";
            // 
            // buttonUdpStop
            // 
            this.buttonUdpStop.Enabled = false;
            this.buttonUdpStop.Location = new System.Drawing.Point(225, 58);
            this.buttonUdpStop.Name = "buttonUdpStop";
            this.buttonUdpStop.Size = new System.Drawing.Size(97, 23);
            this.buttonUdpStop.TabIndex = 5;
            this.buttonUdpStop.Text = "停止服务";
            this.buttonUdpStop.UseVisualStyleBackColor = true;
            this.buttonUdpStop.Click += new System.EventHandler(this.buttonUdpStop_Click);
            // 
            // buttonUdpStart
            // 
            this.buttonUdpStart.Location = new System.Drawing.Point(92, 58);
            this.buttonUdpStart.Name = "buttonUdpStart";
            this.buttonUdpStart.Size = new System.Drawing.Size(97, 23);
            this.buttonUdpStart.TabIndex = 4;
            this.buttonUdpStart.Text = "启动服务";
            this.buttonUdpStart.UseVisualStyleBackColor = true;
            this.buttonUdpStart.Click += new System.EventHandler(this.buttonUdpStart_Click);
            // 
            // labelGprsCount
            // 
            this.labelGprsCount.AutoSize = true;
            this.labelGprsCount.Location = new System.Drawing.Point(385, 25);
            this.labelGprsCount.Name = "labelGprsCount";
            this.labelGprsCount.Size = new System.Drawing.Size(11, 12);
            this.labelGprsCount.TabIndex = 3;
            this.labelGprsCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "已连接";
            // 
            // buttonTcpStop
            // 
            this.buttonTcpStop.Enabled = false;
            this.buttonTcpStop.Location = new System.Drawing.Point(225, 20);
            this.buttonTcpStop.Name = "buttonTcpStop";
            this.buttonTcpStop.Size = new System.Drawing.Size(97, 23);
            this.buttonTcpStop.TabIndex = 1;
            this.buttonTcpStop.Text = "停止服务";
            this.buttonTcpStop.UseVisualStyleBackColor = true;
            this.buttonTcpStop.Click += new System.EventHandler(this.buttonGprsStop_Click);
            // 
            // buttonTcpStart
            // 
            this.buttonTcpStart.Location = new System.Drawing.Point(92, 20);
            this.buttonTcpStart.Name = "buttonTcpStart";
            this.buttonTcpStart.Size = new System.Drawing.Size(97, 23);
            this.buttonTcpStart.TabIndex = 0;
            this.buttonTcpStart.Text = "启动服务";
            this.buttonTcpStart.UseVisualStyleBackColor = true;
            this.buttonTcpStart.Click += new System.EventHandler(this.buttonGprsStart_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelDataCount);
            this.groupBox4.Controls.Add(this.groupBoxSend);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.buttonDataStop);
            this.groupBox4.Controls.Add(this.buttonDataStart);
            this.groupBox4.Location = new System.Drawing.Point(10, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 104);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据服务";
            // 
            // labelDataCount
            // 
            this.labelDataCount.AutoSize = true;
            this.labelDataCount.Location = new System.Drawing.Point(385, 25);
            this.labelDataCount.Name = "labelDataCount";
            this.labelDataCount.Size = new System.Drawing.Size(11, 12);
            this.labelDataCount.TabIndex = 4;
            this.labelDataCount.Text = "0";
            // 
            // groupBoxSend
            // 
            this.groupBoxSend.Controls.Add(this.comboBoxContent);
            this.groupBoxSend.Controls.Add(this.buttonSend);
            this.groupBoxSend.Controls.Add(this.label3);
            this.groupBoxSend.Enabled = false;
            this.groupBoxSend.Location = new System.Drawing.Point(8, 49);
            this.groupBoxSend.Name = "groupBoxSend";
            this.groupBoxSend.Size = new System.Drawing.Size(414, 48);
            this.groupBoxSend.TabIndex = 9;
            this.groupBoxSend.TabStop = false;
            this.groupBoxSend.Text = "发送警告信息";
            // 
            // comboBoxContent
            // 
            this.comboBoxContent.FormattingEnabled = true;
            this.comboBoxContent.Items.AddRange(new object[] {
            "服务器程序更新一下，需要断一下线",
            "服务器程序需要更新一下，请大家先退出登陆，稍等一下再登陆",
            "服务器遇到问题，需要重启一下，请大家先退出登陆，稍等一下再登陆"});
            this.comboBoxContent.Location = new System.Drawing.Point(41, 18);
            this.comboBoxContent.Name = "comboBoxContent";
            this.comboBoxContent.Size = new System.Drawing.Size(316, 20);
            this.comboBoxContent.TabIndex = 2;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(363, 16);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(45, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "已连接";
            // 
            // buttonDataStop
            // 
            this.buttonDataStop.Enabled = false;
            this.buttonDataStop.Location = new System.Drawing.Point(225, 20);
            this.buttonDataStop.Name = "buttonDataStop";
            this.buttonDataStop.Size = new System.Drawing.Size(97, 23);
            this.buttonDataStop.TabIndex = 1;
            this.buttonDataStop.Text = "停止服务";
            this.buttonDataStop.UseVisualStyleBackColor = true;
            this.buttonDataStop.Click += new System.EventHandler(this.buttonDataStop_Click);
            // 
            // buttonDataStart
            // 
            this.buttonDataStart.Location = new System.Drawing.Point(92, 20);
            this.buttonDataStart.Name = "buttonDataStart";
            this.buttonDataStart.Size = new System.Drawing.Size(97, 23);
            this.buttonDataStart.TabIndex = 0;
            this.buttonDataStart.Text = "启动服务";
            this.buttonDataStart.UseVisualStyleBackColor = true;
            this.buttonDataStart.Click += new System.EventHandler(this.buttonDataStart_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewSmsList);
            this.groupBox3.Controls.Add(this.buttonSmsStop);
            this.groupBox3.Controls.Add(this.buttonSmsStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 122);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "移动短信专线接口";
            // 
            // listViewSmsList
            // 
            this.listViewSmsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5});
            this.listViewSmsList.ContextMenuStrip = this.contextMenuStripSmsList;
            this.listViewSmsList.FullRowSelect = true;
            this.listViewSmsList.GridLines = true;
            this.listViewSmsList.Location = new System.Drawing.Point(11, 20);
            this.listViewSmsList.Name = "listViewSmsList";
            this.listViewSmsList.Size = new System.Drawing.Size(404, 70);
            this.listViewSmsList.TabIndex = 0;
            this.listViewSmsList.UseCompatibleStateImageBehavior = false;
            this.listViewSmsList.View = System.Windows.Forms.View.Details;
            this.listViewSmsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSmsList_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "连接状态";
            this.columnHeader5.Width = 239;
            // 
            // contextMenuStripSmsList
            // 
            this.contextMenuStripSmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStart,
            this.toolStripMenuItemStop});
            this.contextMenuStripSmsList.Name = "contextMenuStripSmsList";
            this.contextMenuStripSmsList.Size = new System.Drawing.Size(95, 48);
            // 
            // toolStripMenuItemStart
            // 
            this.toolStripMenuItemStart.Enabled = false;
            this.toolStripMenuItemStart.Name = "toolStripMenuItemStart";
            this.toolStripMenuItemStart.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItemStart.Text = "连接";
            this.toolStripMenuItemStart.Click += new System.EventHandler(this.toolStripMenuItemStart_Click);
            // 
            // toolStripMenuItemStop
            // 
            this.toolStripMenuItemStop.Enabled = false;
            this.toolStripMenuItemStop.Name = "toolStripMenuItemStop";
            this.toolStripMenuItemStop.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItemStop.Text = "断开";
            this.toolStripMenuItemStop.Click += new System.EventHandler(this.toolStripMenuItemStop_Click);
            // 
            // buttonSmsStop
            // 
            this.buttonSmsStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSmsStop.Location = new System.Drawing.Point(225, 95);
            this.buttonSmsStop.Name = "buttonSmsStop";
            this.buttonSmsStop.Size = new System.Drawing.Size(97, 23);
            this.buttonSmsStop.TabIndex = 2;
            this.buttonSmsStop.Text = "停止所有连接";
            this.buttonSmsStop.UseVisualStyleBackColor = true;
            this.buttonSmsStop.Click += new System.EventHandler(this.buttonSmsStop_Click);
            // 
            // buttonSmsStart
            // 
            this.buttonSmsStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSmsStart.Location = new System.Drawing.Point(92, 95);
            this.buttonSmsStart.Name = "buttonSmsStart";
            this.buttonSmsStart.Size = new System.Drawing.Size(97, 23);
            this.buttonSmsStart.TabIndex = 1;
            this.buttonSmsStart.Text = "启动所有连接";
            this.buttonSmsStart.UseVisualStyleBackColor = true;
            this.buttonSmsStart.Click += new System.EventHandler(this.buttonSmsStart_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(15, 403);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "程序设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(345, 403);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "退出程序";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(257, 403);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "隐藏";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(118, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "关于程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerTest
            // 
            this.timerTest.Interval = 1000;
            this.timerTest.Tick += new System.EventHandler(this.timerTest_Tick);
            // 
            // timerSmsTest
            // 
            this.timerSmsTest.Enabled = true;
            this.timerSmsTest.Interval = 2000;
            this.timerSmsTest.Tick += new System.EventHandler(this.timerSmsTest_Tick);
            // 
            // timerSmsReconn
            // 
            this.timerSmsReconn.Interval = 8000;
            this.timerSmsReconn.Tick += new System.EventHandler(this.timerSmsReconn_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 383);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(673, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "*RS,123456789,V1,160121,A,2301.4564,N,11343.3193,E,031.00,139,220408,EEFFFBFF#,EF" +
                "#";
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(455, 351);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 21);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "13312345678";
            this.textBox2.Visible = false;
            // 
            // timerTCP
            // 
            this.timerTCP.Interval = 60000;
            this.timerTCP.Tick += new System.EventHandler(this.timerTCP_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 438);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运通GPS车辆监控系统_服务器端";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBoxSend.ResumeLayout(false);
            this.groupBoxSend.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStripSmsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonDataStop;
        private System.Windows.Forms.Button buttonDataStart;
        private System.Windows.Forms.Button buttonSmsStop;
        private System.Windows.Forms.Button buttonSmsStart;
        private System.Windows.Forms.ListView listViewSmsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSmsList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStart;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerTest;
        private System.Windows.Forms.Timer timerSmsTest;
        private System.Windows.Forms.Timer timerSmsReconn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTcpStop;
        private System.Windows.Forms.Button buttonTcpStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonModemStop;
        private System.Windows.Forms.Button buttonModemStart;
        private System.Windows.Forms.Label labelGprsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDataCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelModemCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBoxSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBoxContent;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUdpStop;
        private System.Windows.Forms.Button buttonUdpStart;
        private System.Windows.Forms.Timer timerTCP;
    }
}

