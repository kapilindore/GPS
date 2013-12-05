namespace YTGPS_Client
{
    public partial class FormCarStoped
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarStoped));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStoped = new System.Windows.Forms.Label();
            this.labelCNO = new System.Windows.Forms.Label();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.comboBox1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(55, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目前服务状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(104, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "车牌";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(69, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新服务状态";
            // 
            // labelStoped
            // 
            this.labelStoped.AutoSize = true;
            this.labelStoped.BackColor = System.Drawing.Color.Transparent;
            this.labelStoped.Location = new System.Drawing.Point(138, 87);
            this.labelStoped.Name = "labelStoped";
            this.labelStoped.Size = new System.Drawing.Size(0, 12);
            this.labelStoped.TabIndex = 14;
            // 
            // labelCNO
            // 
            this.labelCNO.AutoSize = true;
            this.labelCNO.BackColor = System.Drawing.Color.Transparent;
            this.labelCNO.Location = new System.Drawing.Point(139, 52);
            this.labelCNO.Name = "labelCNO";
            this.labelCNO.Size = new System.Drawing.Size(0, 12);
            this.labelCNO.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(232, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button2.TabIndex = 49;
            this.button2.Text = "取消";
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(136, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 48;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(140, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 50;
            // 
            // FormCarStoped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(328, 199);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStoped);
            this.Controls.Add(this.labelCNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCarStoped";
            this.ShowInTaskbar = false;
            this.Text = "设置服务状态";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormCarStoped_KeyPress);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.labelCNO, 0);
            this.Controls.SetChildIndex(this.labelStoped, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStoped;
        private System.Windows.Forms.Label labelCNO;
        private DevComponents.DotNetBar.ButtonX button2;
        private DevComponents.DotNetBar.ButtonX button1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBox1;
    }
}