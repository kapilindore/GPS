namespace YTGPS_Client
{
    partial class FormAlarmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlarmList));
            this.label100 = new System.Windows.Forms.Label();
            this.listView1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader0 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelCount = new System.Windows.Forms.Label();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.Location = new System.Drawing.Point(14, 33);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(143, 12);
            this.label100.TabIndex = 16;
            this.label100.Text = "报警列表 共有　　　　条";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listView1.Border.Class = "ListViewBorder";
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader11,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader9});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(16, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(562, 349);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "ID";
            this.columnHeader0.Width = 1;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "车牌";
            this.columnHeader11.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "所属车队";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "GPS时间";
            this.columnHeader1.Width = 128;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "车辆状态";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "报警信息";
            this.columnHeader9.Width = 160;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 14);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelCount
            // 
            this.labelCount.BackColor = System.Drawing.Color.Transparent;
            this.labelCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCount.Location = new System.Drawing.Point(96, 33);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(45, 12);
            this.labelCount.TabIndex = 20;
            this.labelCount.Text = "0";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(584, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button2.TabIndex = 42;
            this.button2.Text = "关闭";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(584, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 43;
            this.button1.Text = "接警";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAlarmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 410);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.label100);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlarmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报警列表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAlarmList_FormClosing);
            this.Controls.SetChildIndex(this.label100, 0);
            this.Controls.SetChildIndex(this.labelCount, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label100;
        private DevComponents.DotNetBar.Controls.ListViewEx listView1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.ButtonX button2;
        private DevComponents.DotNetBar.ButtonX button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}