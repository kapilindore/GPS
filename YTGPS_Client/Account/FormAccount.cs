using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormAccount : FormUntitle
    {
        private Account temp;
        public FormAccount(Account accout)
        {
            InitializeComponent();
            if(accout.Name == "")
                this.Text = "ÃÌº”’ ∫≈";
            else textBox1.ReadOnly = true;
            this.SetFormStyle(false, false, false, false);
            this.temp = accout;
            textBox1.Text = temp.Name;
            textBox2.Text = temp.Pw;
            comboBox1.SelectedIndex = temp.Type;
            textBox3.Text = temp.Tel;
            textBox4.Text = temp.Email;
            foreach(Team team in FormMain.user.TeamList)
            {
                checkedListBox1.Items.Add(team.TeamName);
                foreach(int tid in accout.Teams)
                    if(team.TeamID == tid)
                    {
                        checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);
                    }
            }
            checkBox0.Checked = temp.PolicyModTeam == 1;
            checkBox1.Checked = temp.PolicyModCar == 1;
            checkBox2.Checked = temp.PolicyOrder == 1;
            checkBox3.Checked = temp.PolicyExportCars == 1;
            checkBox4.Checked = temp.PolicyDeclare == 1;
            checkBox5.Checked = temp.PolicyAlarmList == 1;
            checkBox6.Checked = temp.PolicyOverTime == 1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ',' || e.KeyChar == ';' || e.KeyChar == '|')
                e.KeyChar = (char)0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            button1.Enabled = true;
        }
        //
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.Name = textBox1.Text;
            temp.Pw = textBox2.Text;
            temp.Type = comboBox1.SelectedIndex;
            temp.Tel = textBox3.Text;
            temp.Email = textBox4.Text;
            temp.Teams.Clear();
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
                if(checkedListBox1.GetItemChecked(i))
                    temp.Teams.Add(FormMain.user.TeamList[i].TeamID);
            if(temp.Type == Account.ADMIN)
            {
                temp.PolicyModTeam = 1;
                temp.PolicyModCar = 1;
                temp.PolicyOrder = 1;
                temp.PolicyExportCars = 1;
                temp.PolicyDeclare = 1;
                temp.PolicyAlarmList = 1;
                temp.PolicyOverTime = 1;
            }
            else
            {
                temp.PolicyModTeam = checkBox0.Checked ? 1 : 0;
                temp.PolicyModCar = checkBox1.Checked ? 1 : 0;
                temp.PolicyOrder = checkBox2.Checked ? 1 : 0;
                temp.PolicyExportCars = checkBox3.Checked ? 1 : 0;
                temp.PolicyDeclare = checkBox4.Checked ? 1 : 0;
                temp.PolicyAlarmList = checkBox5.Checked ? 1 : 0;
                temp.PolicyOverTime = checkBox6.Checked ? 1 : 0;
            }
        }

        private void FormAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedListBox1.Enabled = (comboBox1.SelectedIndex == 1);
            groupBox1.Enabled = (comboBox1.SelectedIndex == 1);
        }
    }
}