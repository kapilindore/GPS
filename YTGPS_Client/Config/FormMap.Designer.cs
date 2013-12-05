namespace YTGPS_Client
{
    partial class FormMap
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
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMapFile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.buttonCanel = new DevComponents.DotNetBar.ButtonX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listViewLayers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMod = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDefaultLayers = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(324, 285);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOK_MouseDown);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX6.Location = new System.Drawing.Point(466, 70);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(28, 22);
            this.buttonX6.TabIndex = 2;
            this.buttonX6.Text = "...";
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(19, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 45;
            this.label10.Text = "索引文件";
            // 
            // textBoxMapFile
            // 
            this.textBoxMapFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMapFile.Location = new System.Drawing.Point(78, 70);
            this.textBoxMapFile.Name = "textBoxMapFile";
            this.textBoxMapFile.Size = new System.Drawing.Size(382, 21);
            this.textBoxMapFile.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(43, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "名称";
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Location = new System.Drawing.Point(78, 42);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(180, 21);
            this.textBoxMapName.TabIndex = 0;
            // 
            // buttonCanel
            // 
            this.buttonCanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCanel.Location = new System.Drawing.Point(419, 285);
            this.buttonCanel.Name = "buttonCanel";
            this.buttonCanel.Size = new System.Drawing.Size(75, 23);
            this.buttonCanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonCanel.TabIndex = 6;
            this.buttonCanel.Text = "取消";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "GST文件|*.gst";
            // 
            // listViewLayers
            // 
            this.listViewLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewLayers.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewLayers.FullRowSelect = true;
            this.listViewLayers.GridLines = true;
            this.listViewLayers.Location = new System.Drawing.Point(12, 133);
            this.listViewLayers.MultiSelect = false;
            this.listViewLayers.Name = "listViewLayers";
            this.listViewLayers.Size = new System.Drawing.Size(489, 146);
            this.listViewLayers.SmallImageList = this.imageList1;
            this.listViewLayers.TabIndex = 4;
            this.listViewLayers.UseCompatibleStateImageBehavior = false;
            this.listViewLayers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图层名";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "信息列名";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "图层类型";
            this.columnHeader3.Width = 64;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "搜索范围(米)";
            this.columnHeader4.Width = 87;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "信息附加头";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "信息附加尾";
            this.columnHeader6.Width = 77;
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
            this.ToolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 14);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "获取地理信息需查询的图层";
            // 
            // buttonDefaultLayers
            // 
            this.buttonDefaultLayers.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDefaultLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDefaultLayers.Location = new System.Drawing.Point(367, 107);
            this.buttonDefaultLayers.Name = "buttonDefaultLayers";
            this.buttonDefaultLayers.Size = new System.Drawing.Size(134, 23);
            this.buttonDefaultLayers.TabIndex = 3;
            this.buttonDefaultLayers.Text = "导入系统默认图层设置";
            this.buttonDefaultLayers.Click += new System.EventHandler(this.buttonDefaultLayers_Click);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(513, 329);
            this.Controls.Add(this.buttonDefaultLayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewLayers);
            this.Controls.Add(this.buttonCanel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxMapFile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxMapName);
            this.KeyPreview = true;
            this.Name = "FormMap";
            this.ShowInTaskbar = false;
            this.Text = "设置地图";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMap_KeyPress);
            this.Controls.SetChildIndex(this.textBoxMapName, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.textBoxMapFile, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.buttonX6, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.Controls.SetChildIndex(this.buttonCanel, 0);
            this.Controls.SetChildIndex(this.listViewLayers, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.buttonDefaultLayers, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonX6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxMapFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxMapName;
        private DevComponents.DotNetBar.ButtonX buttonCanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listViewLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMod;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX buttonDefaultLayers;
    }
}