using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormMap : FormUntitle
    {
        private MapFile mf = null;
        private List<GeoInfoLayer> gList = null;
        private static String[] LAYER_TYPE = {"面图层", "点图层"};

        public FormMap(MapFile m)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);
            mf = m;
            textBoxMapName.Text = mf.Name;
            textBoxMapFile.Text = mf.File;
            gList = new List<GeoInfoLayer>();
            foreach(GeoInfoLayer gl in mf.GeoInfoList)
            {
                ListViewItem item = new ListViewItem(gl.TableName);
                item.SubItems.Add(gl.ColName);
                item.SubItems.Add(LAYER_TYPE[gl.Type]);
                item.SubItems.Add(gl.Distance.ToString());
                item.SubItems.Add(gl.Head);
                item.SubItems.Add(gl.Foot);
                listViewLayers.Items.Add(item);
                gList.Add(gl);
            }
        }
        //打开文件对话框
        private void buttonX6_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxMapFile.Text = openFileDialog1.FileName;
            }
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            GeoInfoLayer gl = new GeoInfoLayer();
            FormLayer frm = new FormLayer(gl);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem(gl.TableName);
                item.SubItems.Add(gl.ColName);
                item.SubItems.Add(LAYER_TYPE[gl.Type]);
                item.SubItems.Add(gl.Distance.ToString());
                item.SubItems.Add(gl.Head);
                item.SubItems.Add(gl.Foot);
                listViewLayers.Items.Add(item);
                gList.Add(gl);
            }
        }

        private void ToolStripMenuItemMod_Click(object sender, EventArgs e)
        {
            if(listViewLayers.SelectedItems.Count == 0)
                return;
            GeoInfoLayer gl = gList[listViewLayers.SelectedItems[0].Index];
            FormLayer frm = new FormLayer(gl);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                listViewLayers.SelectedItems[0].SubItems[0].Text = gl.TableName;
                listViewLayers.SelectedItems[0].SubItems[1].Text = gl.ColName;
                listViewLayers.SelectedItems[0].SubItems[2].Text = LAYER_TYPE[gl.Type];
                listViewLayers.SelectedItems[0].SubItems[3].Text = gl.Distance.ToString();
                listViewLayers.SelectedItems[0].SubItems[4].Text = gl.Head;
                listViewLayers.SelectedItems[0].SubItems[5].Text = gl.Foot;
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listViewLayers.SelectedItems.Count == 0)
                return;
            if(MessageBox.Show(this, StrConst.WARN_DELETE, StrConst.TITLE_WARN, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                gList.RemoveAt(listViewLayers.SelectedItems[0].Index);
                listViewLayers.Items.RemoveAt(listViewLayers.SelectedItems[0].Index);
            }
        }

        private void buttonDefaultLayers_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this, StrConst.WARN_IMPORT_DEFAULT_LAYER_SET, StrConst.TITLE_WARN, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                gList.Clear();
                listViewLayers.Items.Clear();
                foreach(GeoInfoLayer gl in Config.DefaultMap.GeoInfoList)
                {
                    ListViewItem item = new ListViewItem(gl.TableName);
                    item.SubItems.Add(gl.ColName);
                    item.SubItems.Add(LAYER_TYPE[gl.Type]);
                    item.SubItems.Add(gl.Distance.ToString());
                    item.SubItems.Add(gl.Head);
                    item.SubItems.Add(gl.Foot);
                    listViewLayers.Items.Add(item);
                    gList.Add(gl);
                }
            }
        }

        private void buttonOK_MouseDown(object sender, MouseEventArgs e)
        {
            buttonOK.DialogResult = DialogResult.None;
            if(textBoxMapName.Text == "" || textBoxMapFile.Text == "")
            {
                MessageBox.Show(this, StrConst.MSG_EMPTY_INFO, StrConst.TITLE_MSG);
                return;
            }
            mf.Name = textBoxMapName.Text;
            mf.File = textBoxMapFile.Text;
            mf.GeoInfoList = gList;
            buttonOK.DialogResult = DialogResult.OK;
        }

        private void FormMap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.buttonOK.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.buttonCanel.PerformClick();
        }
    }
}