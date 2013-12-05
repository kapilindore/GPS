using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormTeamInfo : Form
    {
        public FormTeamInfo()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        //车队信息
        public void ShowInfo(Team team, int x, int y)
        {
            label0.Text = team.TeamID.ToString();
            label1.Text = team.TeamName;
            label13.Text = team.Password;
            label2.Text = team.TeamLinkman;
            label3.Text = team.TeamTel;
            label4.Text = team.TeamAddress;
            label5.Text = team.JoinTime;
            this.Text = team.TeamName;
            this.Left = x - this.Width - 15;
            this.Top = y;
            this.Show();
        }
    }
}