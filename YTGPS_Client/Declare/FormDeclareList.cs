using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormDeclareList : FormUntitle
    {
        private List<Declare> decList = null;
        private FormMain fMain;

        public FormDeclareList(FormMain frmMain, List<Declare> list)
        {
            InitializeComponent();
            this.SetFormStyle(true, true, true, true);
            fMain = frmMain;
            decList = list;
            foreach(Declare dec in decList)
            {
                ListViewItem item = new ListViewItem(dec.DeclareID.ToString());
                item.SubItems.Add(dec.ReferDate);
                item.SubItems.Add(dec.DeclareContent);
                item.Tag = dec;
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                FormDeclare frm = new FormDeclare(fMain, listView1.SelectedItems[0].Tag as Declare);
                fMain.onDeclareModed += new FormMain.onDeclareModedDelegate(fMain_onDeclareModed);
                frm.ShowDialog(this);
                fMain.onDeclareModed -= fMain_onDeclareModed;
            }
        }

        void fMain_onDeclareModed(bool suc)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}