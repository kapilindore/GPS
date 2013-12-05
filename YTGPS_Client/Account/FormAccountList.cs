using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormAccountList : FormUntitle
    {
        public FormAccountList()
        {
            InitializeComponent();
            this.SetFormStyle(false, false, true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAccountList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public void RefeshList()
        {
            listView1.Items.Clear();
            labelCount.Text = FormMain.accountList.Count.ToString();
            foreach(Account accout in FormMain.accountList)
            {
                ListViewItem item = new ListViewItem(accout.Name);
                item.SubItems.Add(accout.Pw);
                item.SubItems.Add(Account.TYPE[accout.Type]);
                item.SubItems.Add(accout.Tel);
                item.SubItems.Add(accout.Email);
                item.SubItems.Add(accout.JoinTime);
                String t = "";
                foreach(int i in accout.Teams)
                {
                    try
                    {
                        t = t + FormMain.user.GetTeamByID(i).TeamName + ",";
                    }
                    catch { }
                }
                item.SubItems.Add(t);
                String p = "";
                if(accout.Type == Account.ADMIN)
                    p = "��ȫ����";
                else
                {
                    if(accout.PolicyModTeam == 1)
                        p = Account.POLICY[0];
                    if(accout.PolicyModCar == 1)
                        p = p + "," + Account.POLICY[1];
                    if(accout.PolicyOrder == 1)
                        p = p + "," + Account.POLICY[2];/*
                if(accout.PolicyRegion == 1)
                    p = Account.POLICY[3];
                if(accout.PolicyRegionAlarm == 1)
                    p = Account.POLICY[4];*/
                    if(accout.PolicyAlarmList == 1)
                        p = p + "," + Account.POLICY[5];
                    if(accout.PolicyOverTime == 1)
                        p = p + "," + Account.POLICY[6];
                }
                item.SubItems.Add(p);
                listView1.Items.Add(item);
            }
            button1.Enabled = true;
        }
        //����
        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.C_Info_AccountList();
            button1.Enabled = false;
        }
        //���
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Account accout = new Account();
            FormAccount frm = new FormAccount(accout);
            if(frm.ShowDialog(this) == DialogResult.OK)
                FormMain.C_Info_AddAccount(accout);
        }
        //�޸�
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Account accout = contextMenuStrip1.Tag as Account;
            if(accout.Id == FormMain.user.Id)
            {
                MessageBox.Show(this, "�뵽�û���Ϣ�޸���������!");
                return;
            }
            Account accout1 = new Account(accout);
            FormAccount frm = new FormAccount(accout1);
            if(frm.ShowDialog(this) == DialogResult.OK)
                FormMain.C_Info_ModifyAccount(accout1);
        }
        //ɾ��
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Account accout = contextMenuStrip1.Tag as Account;
            if(accout.Id == FormMain.user.Id)
            {
                MessageBox.Show(this, "����ɾ�����Լ�!");
                return;
            }
            if(MessageBox.Show(this, "ȷʵҪɾ���ʺ�" + accout.Name + "?", "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormMain.C_Info_DelAccount(accout.Id);
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewItem item = listView1.GetItemAt(e.X, e.Y);
                if(item != null)
                {
                    contextMenuStrip1.Tag = FormMain.accountList[item.Index];
                    ToolStripMenuItem2.Enabled = true;
                    ToolStripMenuItem3.Enabled = true;
                    return;
                }
            }
            ToolStripMenuItem2.Enabled = false;
            ToolStripMenuItem3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show(this, "û���κ���Ŀ");
                return;
            }
            DataTable dt = new DataTable();
            foreach(ColumnHeader ch in listView1.Columns)
                dt.Columns.Add(ch.Text);
            foreach(ListViewItem item in listView1.Items)
            {
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, 
                    item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text, item.SubItems[7].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, "ϵͳ�ʺ��б�.xls");
        }

        private void FormAccountList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
    }
}