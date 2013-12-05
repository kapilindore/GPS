using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormConfig : FormUntitle
    {
        private List<MapFile> mlist = null;

        public FormConfig()
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);

            checkBoxautoLogin.Checked = Config.AutoLogin;
            textBoxhost.Text = Config.Host;
            textBoxport.Text = Config.Port.ToString();
            textBoxport.KeyPress += Pub.KeyPress_NumInput;
            comboBoxuserType.SelectedIndex = Config.UserType;
            textBoxuser.Text = Config.User;
            textBoxpw.Text = Config.Pw;

            textBoxtelPort.Text = Config.GisPort.ToString();
            textBoxtelPort.KeyPress += Pub.KeyPress_NumInput;
            checkBoxautoStartGis.Checked = Config.AutoStartGis;

            checkBoxautoReconn.Checked = Config.AutoReconn;
            checkBoxautoAlarmList.Checked = Config.AutoAlarmList;
            checkBoxautoWatchOnPoint.Checked = Config.AutoWatchOnPoint;
            checkBoxautoWatchOnHandleAlarm.Checked = Config.AutoWatchOnHandleAlarm;
            checkBoxautoChatForm.Checked = Config.AutoChatForm;
            checkBoxautoGetCarGeoInfo.Checked = Config.AutoGetCarGeoInfo;

            mlist = new List<MapFile>();
            foreach(MapFile mf in Config.MapList)
            {
                ListViewItem item = new ListViewItem(mf.Name);
                item.SubItems.Add(mf.File);
                listViewMaps.Items.Add(item);
                mlist.Add(new MapFile(mf));
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listViewMaps.SelectedItems.Count == 0)
                return;
            if(MessageBox.Show(this, StrConst.WARN_DELETE, StrConst.TITLE_WARN, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                mlist.RemoveAt(listViewMaps.SelectedItems[0].Index);
                listViewMaps.Items.RemoveAt(listViewMaps.SelectedItems[0].Index);
            }
        }

        private void buttonAddMap_Click(object sender, EventArgs e)
        {
            MapFile mf = new MapFile("", "");
            FormMap frm = new FormMap(mf);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem(mf.Name);
                item.SubItems.Add(mf.File);
                listViewMaps.Items.Add(item);
                mlist.Add(mf);
            }
        }

        private void ToolStripMenuItemMod_Click(object sender, EventArgs e)
        {
            if(listViewMaps.SelectedItems.Count == 0)
                return;
            MapFile mf = mlist[listViewMaps.SelectedItems[0].Index];
            FormMap frm = new FormMap(mf);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                listViewMaps.SelectedItems[0].SubItems[0].Text = mf.Name;
                listViewMaps.SelectedItems[0].SubItems[1].Text = mf.File;
            }
        }

        private void buttonOK_MouseDown(object sender, MouseEventArgs e)
        {
            buttonOK.DialogResult = DialogResult.None;
            if(listViewMaps.Items.Count == 0)
            {
                MessageBox.Show(this, StrConst.ERR_NONE_MAP, StrConst.TITLE_WARN);
                return;
            }
            Config.Host = textBoxhost.Text;
            Config.Port = Int32.Parse(textBoxport.Text);
            Config.UserType = comboBoxuserType.SelectedIndex;
            Config.User = textBoxuser.Text;
            Config.Pw = textBoxpw.Text;
            Config.GisPort = Int32.Parse(textBoxtelPort.Text);
            Config.AutoStartGis = checkBoxautoStartGis.Checked;
            Config.AutoLogin = checkBoxautoLogin.Checked;
            Config.AutoReconn = checkBoxautoReconn.Checked;
            Config.AutoAlarmList = checkBoxautoAlarmList.Checked;
            Config.AutoWatchOnPoint = checkBoxautoWatchOnPoint.Checked;
            Config.AutoWatchOnHandleAlarm = checkBoxautoWatchOnHandleAlarm.Checked;
            Config.AutoChatForm = checkBoxautoChatForm.Checked;
            Config.AutoGetCarGeoInfo = checkBoxautoGetCarGeoInfo.Checked;
            Config.MapList = mlist;
            buttonOK.DialogResult = DialogResult.OK;
        }

        private void FormConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.buttonOK.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.buttonCanel.PerformClick();
        }
    }
}