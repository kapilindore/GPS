using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormQueryCondition : FormUntitle
    {
        private QueryCondition temp;

        public FormQueryCondition(QueryCondition qc)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);
            temp = qc;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.Label = comboBox1.SelectedIndex;
            temp.Type = comboBox2.SelectedIndex;
            temp.Keyword = textBox1.Text.ToLower();
        }
    }
}