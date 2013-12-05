using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Server
{
    public partial class FormSmsConfig : Form
    {
        private SmsConfig config;

        public FormSmsConfig(SmsConfig cf)
        {
            InitializeComponent();
            config = cf;
            textBox1.Text = config.SmsName;
            textBox2.Text = config.SmsHost;
            textBox3.Text = config.SmsPort.ToString();
            textBox4.Text = config.SmsPw;
            textBox3.KeyPress += PubEvent.KeyPress_NumInput;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && (textBox1.Text != config.SmsName || textBox2.Text != config.SmsHost
                || textBox3.Text != config.SmsPort.ToString() || textBox4.Text != config.SmsPw))
                button4.Enabled = true;
            else button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            config.SmsName = textBox1.Text;
            config.SmsHost = textBox2.Text;
            config.SmsPort = Int32.Parse(textBox3.Text);
            config.SmsPw = textBox4.Text;
        }
    }
}