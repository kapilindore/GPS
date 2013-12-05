namespace YTGPS_Client
{
    partial class FormLayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTableName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxColName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.textBoxDistance = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxFoot = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxHead = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCanel = new DevComponents.DotNetBar.ButtonX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(47, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "图层名*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(226, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "信息列名*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(35, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "图层类型*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(226, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "搜索范围                     米";
            // 
            // textBoxTableName
            // 
            // 
            // 
            // 
            this.textBoxTableName.Border.Class = "TextBoxBorder";
            this.textBoxTableName.Location = new System.Drawing.Point(94, 49);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(111, 21);
            this.textBoxTableName.TabIndex = 47;
            // 
            // textBoxColName
            // 
            // 
            // 
            // 
            this.textBoxColName.Border.Class = "TextBoxBorder";
            this.textBoxColName.Location = new System.Drawing.Point(285, 49);
            this.textBoxColName.Name = "textBoxColName";
            this.textBoxColName.Size = new System.Drawing.Size(111, 21);
            this.textBoxColName.TabIndex = 48;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DisplayMember = "Text";
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.comboBoxType.Location = new System.Drawing.Point(94, 85);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(111, 22);
            this.comboBoxType.TabIndex = 49;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "面图层";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "点图层";
            // 
            // textBoxDistance
            // 
            // 
            // 
            // 
            this.textBoxDistance.Border.Class = "TextBoxBorder";
            this.textBoxDistance.Location = new System.Drawing.Point(285, 85);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(111, 21);
            this.textBoxDistance.TabIndex = 50;
            // 
            // textBoxFoot
            // 
            // 
            // 
            // 
            this.textBoxFoot.Border.Class = "TextBoxBorder";
            this.textBoxFoot.Location = new System.Drawing.Point(285, 122);
            this.textBoxFoot.Name = "textBoxFoot";
            this.textBoxFoot.Size = new System.Drawing.Size(111, 21);
            this.textBoxFoot.TabIndex = 54;
            // 
            // textBoxHead
            // 
            // 
            // 
            // 
            this.textBoxHead.Border.Class = "TextBoxBorder";
            this.textBoxHead.Location = new System.Drawing.Point(94, 122);
            this.textBoxHead.Name = "textBoxHead";
            this.textBoxHead.Size = new System.Drawing.Size(111, 21);
            this.textBoxHead.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(214, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "附加信息尾";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(23, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "附加信息头";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(23, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "注：搜索范围在点图层时为必选";
            // 
            // buttonCanel
            // 
            this.buttonCanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCanel.Location = new System.Drawing.Point(337, 160);
            this.buttonCanel.Name = "buttonCanel";
            this.buttonCanel.Size = new System.Drawing.Size(80, 23);
            this.buttonCanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonCanel.TabIndex = 57;
            this.buttonCanel.Text = "取消";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(237, 160);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(83, 23);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonOK.TabIndex = 56;
            this.buttonOK.Text = "确定";
            this.buttonOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOK_MouseDown);
            // 
            // FormLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(437, 198);
            this.Controls.Add(this.buttonCanel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxFoot);
            this.Controls.Add(this.textBoxHead);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxColName);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FormLayer";
            this.ShowInTaskbar = false;
            this.Text = "地理信息查询图层设置";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLayer_KeyPress);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBoxTableName, 0);
            this.Controls.SetChildIndex(this.textBoxColName, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.textBoxDistance, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBoxHead, 0);
            this.Controls.SetChildIndex(this.textBoxFoot, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.Controls.SetChildIndex(this.buttonCanel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxTableName;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxColName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxDistance;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxFoot;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX buttonCanel;
        private DevComponents.DotNetBar.ButtonX buttonOK;
    }
}