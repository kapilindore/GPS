using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormTeam : FormUntitle
    {
        private Team temp;
        private FormMain frmMain;

        public FormTeam(FormMain fMain, Team team)
        {
            InitializeComponent();
            frmMain = fMain;
            if(team.TeamName == "")
                this.Text = "添加车队";
            else textBox1.Enabled = false;
            this.SetFormStyle(false, false, false, false);
            this.temp = team;
            textBox1.Text = team.TeamName;
            textBox2.Text = team.TeamLinkman;
            textBox3.Text = team.TeamTel;
            textBox3.KeyPress += Pub.KeyPress_NumInput;
            textBox4.Text = team.TeamAddress;
            textBox5.Text = team.Password;
            checkBox1.Checked = team.PolicyModCar == 1;
            checkBox2.Checked = team.PolicyOrder == 1;
            checkBox3.Checked = team.PolicyRegion == 1;
            checkBox4.Checked = team.PolicyRegionAlarm == 1;
            frmMain.onModifyTeam += new FormMain.onModifyTeamDelegate(frmMain_onModifyTeam);
        }

        private void FormTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.onModifyTeam -= frmMain_onModifyTeam;
        }

        void frmMain_onModifyTeam(bool suc, string s)
        {
            if(suc)
                Close();
            else
            {
                if(this.Text == "添加车队")
                    MessageBox.Show(StrConst.INFO_TEAM_ADD_FAIL + s);
                else MessageBox.Show(StrConst.INFO_TEAM_MOD_FAIL + s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.TeamName = textBox1.Text;
            temp.TeamLinkman = textBox2.Text;
            temp.TeamTel = textBox3.Text;
            temp.TeamAddress = textBox4.Text;
            temp.Password = textBox5.Text;
            temp.PolicyModCar = checkBox1.Checked ? 1 : 0;
            temp.PolicyOrder = checkBox2.Checked ? 1 : 0;
            temp.PolicyRegion = checkBox3.Checked ? 1 : 0;
            temp.PolicyRegionAlarm = checkBox4.Checked ? 1 : 0;
            if(this.Text == "添加车队")
                FormMain.C_Info_AddTeam(temp);
            else FormMain.C_Info_ModifyTeam(temp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox5.Text != ""
                && (temp.TeamName != textBox1.Text || temp.Password != textBox5.Text || temp.TeamLinkman != textBox2.Text
                || temp.TeamTel != textBox3.Text || temp.TeamAddress != textBox4.Text))
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void FormTeam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
    }
}