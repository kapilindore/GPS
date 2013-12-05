namespace YTGPS_Server
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxDataPw = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDataTest = new System.Windows.Forms.Button();
            this.textBoxDataPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxDataAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxSmsAutoStart = new System.Windows.Forms.CheckBox();
            this.listViewSmsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonTestDB = new System.Windows.Forms.Button();
            this.textBoxDBPw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDBUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDBHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGprsTest = new System.Windows.Forms.Button();
            this.textBoxGprsPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxGprsAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxAllowChat = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxModemPw = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonModemTest = new System.Windows.Forms.Button();
            this.textBoxModemPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxModemAutoStart = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownTcpCutTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcpCutTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxDataPw);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.buttonDataTest);
            this.groupBox4.Controls.Add(this.textBoxDataPort);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.checkBoxDataAutoStart);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 301);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(455, 49);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据服务";
            // 
            // textBoxDataPw
            // 
            this.textBoxDataPw.Location = new System.Drawing.Point(183, 18);
            this.textBoxDataPw.Name = "textBoxDataPw";
            this.textBoxDataPw.Size = new System.Drawing.Size(63, 21);
            this.textBoxDataPw.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Web验证码";
            // 
            // buttonDataTest
            // 
            this.buttonDataTest.Location = new System.Drawing.Point(353, 19);
            this.buttonDataTest.Name = "buttonDataTest";
            this.buttonDataTest.Size = new System.Drawing.Size(75, 23);
            this.buttonDataTest.TabIndex = 3;
            this.buttonDataTest.Text = "测试";
            this.buttonDataTest.UseVisualStyleBackColor = true;
            this.buttonDataTest.Click += new System.EventHandler(this.buttonTestData_Click);
            // 
            // textBoxDataPort
            // 
            this.textBoxDataPort.Location = new System.Drawing.Point(44, 18);
            this.textBoxDataPort.Name = "textBoxDataPort";
            this.textBoxDataPort.Size = new System.Drawing.Size(63, 21);
            this.textBoxDataPort.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "端口";
            // 
            // checkBoxDataAutoStart
            // 
            this.checkBoxDataAutoStart.AutoSize = true;
            this.checkBoxDataAutoStart.Location = new System.Drawing.Point(268, 23);
            this.checkBoxDataAutoStart.Name = "checkBoxDataAutoStart";
            this.checkBoxDataAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxDataAutoStart.TabIndex = 2;
            this.checkBoxDataAutoStart.Text = "自动启动";
            this.checkBoxDataAutoStart.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxSmsAutoStart);
            this.groupBox3.Controls.Add(this.listViewSmsList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 94);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "移动专线服务";
            // 
            // checkBoxSmsAutoStart
            // 
            this.checkBoxSmsAutoStart.AutoSize = true;
            this.checkBoxSmsAutoStart.Location = new System.Drawing.Point(353, 71);
            this.checkBoxSmsAutoStart.Name = "checkBoxSmsAutoStart";
            this.checkBoxSmsAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxSmsAutoStart.TabIndex = 1;
            this.checkBoxSmsAutoStart.Text = "自动启动";
            this.checkBoxSmsAutoStart.UseVisualStyleBackColor = true;
            // 
            // listViewSmsList
            // 
            this.listViewSmsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewSmsList.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewSmsList.FullRowSelect = true;
            this.listViewSmsList.GridLines = true;
            this.listViewSmsList.Location = new System.Drawing.Point(11, 20);
            this.listViewSmsList.Name = "listViewSmsList";
            this.listViewSmsList.Size = new System.Drawing.Size(336, 67);
            this.listViewSmsList.TabIndex = 0;
            this.listViewSmsList.UseCompatibleStateImageBehavior = false;
            this.listViewSmsList.View = System.Windows.Forms.View.Details;
            this.listViewSmsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewSmsList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "服务器";
            this.columnHeader2.Width = 129;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "端口";
            this.columnHeader3.Width = 47;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "验证码";
            this.columnHeader4.Width = 52;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem2.Text = "修改";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem3.Text = "删除";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem4.Text = "测试";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonTestDB);
            this.groupBox2.Controls.Add(this.textBoxDBPw);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxDBUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxDBName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxDBHost);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库设置";
            // 
            // buttonTestDB
            // 
            this.buttonTestDB.Location = new System.Drawing.Point(353, 47);
            this.buttonTestDB.Name = "buttonTestDB";
            this.buttonTestDB.Size = new System.Drawing.Size(75, 23);
            this.buttonTestDB.TabIndex = 8;
            this.buttonTestDB.Text = "测试";
            this.buttonTestDB.UseVisualStyleBackColor = true;
            this.buttonTestDB.Click += new System.EventHandler(this.buttonTestDB_Click);
            // 
            // textBoxDBPw
            // 
            this.textBoxDBPw.Location = new System.Drawing.Point(240, 47);
            this.textBoxDBPw.Name = "textBoxDBPw";
            this.textBoxDBPw.PasswordChar = '*';
            this.textBoxDBPw.Size = new System.Drawing.Size(100, 21);
            this.textBoxDBPw.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码";
            // 
            // textBoxDBUser
            // 
            this.textBoxDBUser.Location = new System.Drawing.Point(56, 47);
            this.textBoxDBUser.Name = "textBoxDBUser";
            this.textBoxDBUser.Size = new System.Drawing.Size(100, 21);
            this.textBoxDBUser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(240, 20);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(100, 21);
            this.textBoxDBName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库";
            // 
            // textBoxDBHost
            // 
            this.textBoxDBHost.Location = new System.Drawing.Point(56, 20);
            this.textBoxDBHost.Name = "textBoxDBHost";
            this.textBoxDBHost.Size = new System.Drawing.Size(100, 21);
            this.textBoxDBHost.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(266, 407);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(365, 407);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownTcpCutTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buttonGprsTest);
            this.groupBox1.Controls.Add(this.textBoxGprsPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxGprsAutoStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPRS/CDMA服务";
            // 
            // buttonGprsTest
            // 
            this.buttonGprsTest.Location = new System.Drawing.Point(350, 17);
            this.buttonGprsTest.Name = "buttonGprsTest";
            this.buttonGprsTest.Size = new System.Drawing.Size(75, 23);
            this.buttonGprsTest.TabIndex = 2;
            this.buttonGprsTest.Text = "测试";
            this.buttonGprsTest.UseVisualStyleBackColor = true;
            this.buttonGprsTest.Click += new System.EventHandler(this.buttonGprsTest_Click);
            // 
            // textBoxGprsPort
            // 
            this.textBoxGprsPort.Location = new System.Drawing.Point(44, 17);
            this.textBoxGprsPort.Name = "textBoxGprsPort";
            this.textBoxGprsPort.Size = new System.Drawing.Size(63, 21);
            this.textBoxGprsPort.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "端口";
            // 
            // checkBoxGprsAutoStart
            // 
            this.checkBoxGprsAutoStart.AutoSize = true;
            this.checkBoxGprsAutoStart.Location = new System.Drawing.Point(265, 21);
            this.checkBoxGprsAutoStart.Name = "checkBoxGprsAutoStart";
            this.checkBoxGprsAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxGprsAutoStart.TabIndex = 1;
            this.checkBoxGprsAutoStart.Text = "自动启动";
            this.checkBoxGprsAutoStart.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxAllowChat);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 350);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(455, 46);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "其他设置";
            // 
            // checkBoxAllowChat
            // 
            this.checkBoxAllowChat.AutoSize = true;
            this.checkBoxAllowChat.Location = new System.Drawing.Point(23, 20);
            this.checkBoxAllowChat.Name = "checkBoxAllowChat";
            this.checkBoxAllowChat.Size = new System.Drawing.Size(96, 16);
            this.checkBoxAllowChat.TabIndex = 0;
            this.checkBoxAllowChat.Text = "允许聊天信息";
            this.checkBoxAllowChat.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxModemPw);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.buttonModemTest);
            this.groupBox6.Controls.Add(this.textBoxModemPort);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.checkBoxModemAutoStart);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 253);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(455, 48);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "短信猫服务";
            // 
            // textBoxModemPw
            // 
            this.textBoxModemPw.Location = new System.Drawing.Point(183, 18);
            this.textBoxModemPw.Name = "textBoxModemPw";
            this.textBoxModemPw.Size = new System.Drawing.Size(63, 21);
            this.textBoxModemPw.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "验证码";
            // 
            // buttonModemTest
            // 
            this.buttonModemTest.Location = new System.Drawing.Point(353, 16);
            this.buttonModemTest.Name = "buttonModemTest";
            this.buttonModemTest.Size = new System.Drawing.Size(75, 23);
            this.buttonModemTest.TabIndex = 3;
            this.buttonModemTest.Text = "测试";
            this.buttonModemTest.UseVisualStyleBackColor = true;
            this.buttonModemTest.Click += new System.EventHandler(this.buttonModemTest_Click);
            // 
            // textBoxModemPort
            // 
            this.textBoxModemPort.Location = new System.Drawing.Point(44, 18);
            this.textBoxModemPort.Name = "textBoxModemPort";
            this.textBoxModemPort.Size = new System.Drawing.Size(63, 21);
            this.textBoxModemPort.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "端口";
            // 
            // checkBoxModemAutoStart
            // 
            this.checkBoxModemAutoStart.AutoSize = true;
            this.checkBoxModemAutoStart.Location = new System.Drawing.Point(268, 20);
            this.checkBoxModemAutoStart.Name = "checkBoxModemAutoStart";
            this.checkBoxModemAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxModemAutoStart.TabIndex = 2;
            this.checkBoxModemAutoStart.Text = "自动启动";
            this.checkBoxModemAutoStart.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(275, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "TCP连接自动切断无数据连接时间:           分钟";
            // 
            // numericUpDownTcpCutTime
            // 
            this.numericUpDownTcpCutTime.Location = new System.Drawing.Point(195, 50);
            this.numericUpDownTcpCutTime.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownTcpCutTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTcpCutTime.Name = "numericUpDownTcpCutTime";
            this.numericUpDownTcpCutTime.Size = new System.Drawing.Size(52, 21);
            this.numericUpDownTcpCutTime.TabIndex = 16;
            this.numericUpDownTcpCutTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(461, 447);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "程序设置";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcpCutTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonDataTest;
        private System.Windows.Forms.TextBox textBoxDataPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTestDB;
        private System.Windows.Forms.TextBox textBoxDBPw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDBUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDBHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxDataAutoStart;
        private System.Windows.Forms.CheckBox checkBoxSmsAutoStart;
        private System.Windows.Forms.ListView listViewSmsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGprsTest;
        private System.Windows.Forms.TextBox textBoxGprsPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxGprsAutoStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxAllowChat;
        private System.Windows.Forms.TextBox textBoxDataPw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonModemTest;
        private System.Windows.Forms.TextBox textBoxModemPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxModemAutoStart;
        private System.Windows.Forms.TextBox textBoxModemPw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownTcpCutTime;
        private System.Windows.Forms.Label label10;
    }
}