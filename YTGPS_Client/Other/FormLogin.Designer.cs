namespace YTGPS_Client
{
    partial class FormLogin
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
            this.textBoxpw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxhost = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxtype = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxuser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfo = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxpw
            // 
            this.textBoxpw.Location = new System.Drawing.Point(279, 87);
            this.textBoxpw.Name = "textBoxpw";
            this.textBoxpw.PasswordChar = '*';
            this.textBoxpw.Size = new System.Drawing.Size(139, 21);
            this.textBoxpw.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(244, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "用户名";
            // 
            // textBoxport
            // 
            this.textBoxport.Location = new System.Drawing.Point(279, 12);
            this.textBoxport.Name = "textBoxport";
            this.textBoxport.Size = new System.Drawing.Size(139, 21);
            this.textBoxport.TabIndex = 2;
            this.textBoxport.Text = "8800";
            this.textBoxport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxport_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(244, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "端口";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(15, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "服务器";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "用户类型";
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Location = new System.Drawing.Point(244, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button1.TabIndex = 1;
            this.button1.Text = "登陆";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(340, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxhost
            // 
            this.comboBoxhost.DisplayMember = "Text";
            this.comboBoxhost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxhost.FormattingEnabled = true;
            this.comboBoxhost.Location = new System.Drawing.Point(63, 12);
            this.comboBoxhost.Name = "comboBoxhost";
            this.comboBoxhost.Size = new System.Drawing.Size(152, 22);
            this.comboBoxhost.TabIndex = 1;
            // 
            // comboBoxtype
            // 
            this.comboBoxtype.DisplayMember = "Text";
            this.comboBoxtype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxtype.FormattingEnabled = true;
            this.comboBoxtype.Location = new System.Drawing.Point(63, 50);
            this.comboBoxtype.Name = "comboBoxtype";
            this.comboBoxtype.Size = new System.Drawing.Size(152, 22);
            this.comboBoxtype.TabIndex = 3;
            // 
            // comboBoxuser
            // 
            this.comboBoxuser.DisplayMember = "Text";
            this.comboBoxuser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxuser.FormattingEnabled = true;
            this.comboBoxuser.Location = new System.Drawing.Point(63, 87);
            this.comboBoxuser.Name = "comboBoxuser";
            this.comboBoxuser.Size = new System.Drawing.Size(152, 22);
            this.comboBoxuser.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.comboBoxuser);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBoxtype);
            this.panel1.Controls.Add(this.comboBoxhost);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxpw);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 123);
            this.panel1.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelInfo.Location = new System.Drawing.Point(16, 192);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(413, 17);
            this.labelInfo.TabIndex = 46;
            this.labelInfo.Text = "欢迎使用GPS监控系统，请登陆";
            this.labelInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTGPS_Client.Properties.Resources.fbk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(445, 218);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.Text = "登  陆";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLogin_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.labelInfo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxpw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX button1;
        private DevComponents.DotNetBar.ButtonX button2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxhost;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxtype;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxuser;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelInfo;
    }
}