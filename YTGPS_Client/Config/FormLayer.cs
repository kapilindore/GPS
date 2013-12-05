using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormLayer : FormUntitle
    {
        private GeoInfoLayer gl = null;

        public FormLayer(GeoInfoLayer gil)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);
            gl = gil;
            textBoxTableName.Text = gl.TableName;
            textBoxColName.Text = gl.ColName;
            comboBoxType.SelectedIndex = gl.Type;
            textBoxDistance.Text = gl.Distance.ToString();
            textBoxDistance.KeyPress += Pub.KeyPress_NumInput;
            textBoxHead.Text = gl.Head;
            textBoxFoot.Text = gl.Foot;
        }

        private void FormLayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.buttonOK.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.buttonCanel.PerformClick();
        }

        private void buttonOK_MouseDown(object sender, MouseEventArgs e)
        {
            buttonOK.DialogResult = DialogResult.None;
            if(textBoxTableName.Text == "" || textBoxColName.Text == ""
                 || (comboBoxType.SelectedIndex == GeoInfoLayer.POINT_LAYER && textBoxColName.Text == ""))
            {
                MessageBox.Show(this, StrConst.MSG_EMPTY_INFO, StrConst.TITLE_MSG);
                return;
            }
            gl.TableName = textBoxTableName.Text;
            gl.ColName = textBoxColName.Text;
            gl.Type = comboBoxType.SelectedIndex;
            if(textBoxDistance.Text != "")
                gl.Distance = Int32.Parse(textBoxDistance.Text);
            gl.Head = textBoxHead.Text;
            gl.Foot = textBoxFoot.Text;
            buttonOK.DialogResult = DialogResult.OK;
        }
    }
}