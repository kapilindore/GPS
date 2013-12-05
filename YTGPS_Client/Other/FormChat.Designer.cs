namespace YTGPS_Client
{
    partial class FormChat
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonSend = new DevComponents.DotNetBar.ButtonX();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(12, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(588, 368);
            this.listBox1.TabIndex = 0;
            // 
            // textBoxContent
            // 
            // 
            // 
            // 
            this.textBoxContent.Border.Class = "TextBoxBorder";
            this.textBoxContent.Location = new System.Drawing.Point(6, 42);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(399, 21);
            this.textBoxContent.TabIndex = 3;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(22, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 16);
            this.labelX1.TabIndex = 45;
            this.labelX1.Text = "发送给";
            // 
            // buttonSend
            // 
            this.buttonSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSend.Location = new System.Drawing.Point(411, 42);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(55, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "发送";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.Location = new System.Drawing.Point(497, 458);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(103, 23);
            this.buttonClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "关  闭";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.Location = new System.Drawing.Point(72, 18);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(63, 18);
            this.checkBoxX1.TabIndex = 0;
            this.checkBoxX1.Text = "所有人";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBoxX3);
            this.groupBox1.Controls.Add(this.checkBoxX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.checkBoxX1);
            this.groupBox1.Controls.Add(this.textBoxContent);
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送信息";
            // 
            // checkBoxX3
            // 
            this.checkBoxX3.AutoSize = true;
            this.checkBoxX3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxX3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX3.Location = new System.Drawing.Point(280, 18);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.Size = new System.Drawing.Size(75, 18);
            this.checkBoxX3.TabIndex = 2;
            this.checkBoxX3.Text = "所有用户";
            // 
            // checkBoxX2
            // 
            this.checkBoxX2.AutoSize = true;
            this.checkBoxX2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxX2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX2.Checked = true;
            this.checkBoxX2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX2.CheckValue = "Y";
            this.checkBoxX2.Location = new System.Drawing.Point(163, 18);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(87, 18);
            this.checkBoxX2.TabIndex = 1;
            this.checkBoxX2.Text = "所有管理员";
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(612, 505);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.KeyPreview = true;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormChat_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.Controls.SetChildIndex(this.buttonClose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.listBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxContent;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonSend;
        private DevComponents.DotNetBar.ButtonX buttonClose;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
    }
}