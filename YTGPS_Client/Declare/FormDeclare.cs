using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormDeclare : FormUntitle
    {
        private static  Color COLOR_BK = Color.White;
        private static Color COLOR_FR = Color.Black;
        private static float LINE_W = (float)0.1;
        private static Pen PEN = new Pen(Color.Black, LINE_W);
        private static Font Font_H = new Font("����", 16, FontStyle.Bold);
        private static Font Font_B = new Font("����", 11, FontStyle.Bold);
        private static Font Font_N = new Font("����", 11, FontStyle.Regular);
        private static Brush BRUSH = Brushes.Black;

        private static int OFFSET_X = 55;
        private static int OFFSET_Y = 70;
        private static int WIDTH = 720;
        private static int HEIGHT = 1000;
        private static int HEAD_H = 50;
        private static int ROW_H = 30;
        private static int TEXT_H = 20;
        private static int MARGIN = 10;
        private static int COL_W_1 = 70;
        private static int COL_W_2 = WIDTH / 2 - COL_W_1 - MARGIN * 2;
        private static int MAX_TEXT = 44;

        private Declare dec = null;
        private Car car = null;
        private FormMain fMain;
        private bool hasD = false;
        private bool suc = false;

        public FormDeclare(FormMain frmMain, Declare d)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);
            fMain = frmMain;
            dec = d;
            car = FormMain.user.GetCarByID(dec.CarID);
            textBox1.Text = dec.DeclareID.ToString();
            try
            {
                dateTimePicker1.Value = DateTime.Parse(dec.ReferDate);
            }catch{}
            textBox2.Text = car.CarType;
            textBox3.Text = car.Driver;
            textBox4.Text = car.CarNO;
            textBox5.Text = car.DriverMobile;
            textBox6.Text = car.CarBrand;
            textBox7.Text = car.BusinessPerson;
            textBox8.Text = car.DriverAddress;
            textBox9.Text = dec.DeclareContent;
            if(dec.ReferUser != "")
                textBox15.Text = dec.ReferUser;
            else textBox15.Text = FormMain.user.Name;
            comboBox2.SelectedIndex = 1;
            if(dec.OpUser != "")
            {
                textBox10.Text = dec.Operation;
                textBox11.Text = dec.Fittings;
                try
                {
                    dateTimePicker2.Value = DateTime.Parse(dec.OpDate);
                }
                catch { }
                textBox12.Text = dec.Mechanic;
                comboBox2.SelectedIndex = dec.Satisfaction;
                textBox13.Text = dec.Opinion;
                textBox14.Text = dec.OpUser;
                groupBox1.Enabled = false;
                //groupBox2.Enabled = false;
                //button1.Enabled = false;
            }
            else if(dec.DeclareID != 0)
            {
                textBox14.Text = FormMain.user.Name;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
            }
            fMain.onDeclareHisContent += new FormMain.onDeclareHisContentdelegate(fMain_onDeclareHis);
            FormMain.C_DeclareCarHis(car.CarID.ToString(), dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
        }

        void fMain_onDeclareHis(string s)
        {
            String[] ss = s.Split(Constant.SPLIT1);
            foreach(String sss in ss)
            {
                if(sss != "")
                    comboBox1.Items.Add(sss);
            }
        }

        private void FormDeclare_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(hasD)
                fMain.onDeclareModed -= fMain_onDeclareModed;
            fMain.onDeclareHisContent -= fMain_onDeclareHis;
        }

        void fMain_onDeclareModed(bool s)
        {
            suc = s;
            if(suc)
            {
                this.Close();
            }
            else MessageBox.Show("�ύʧ��");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ',' || e.KeyChar == ';' || e.KeyChar == '|')
                e.KeyChar = (char)0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dec.DeclareID == 0)
            {
                dec.ReferUser = FormMain.user.Name;
                dec.ReferDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
                dec.DeclareContent = textBox9.Text;
                if(!hasD) 
                fMain.onDeclareModed += new FormMain.onDeclareModedDelegate(fMain_onDeclareModed);
                    FormMain.C_NewDeclare(dec);
            }
            else// if(dec.OpUser == "")
            {
                dec.OpUser = textBox14.Text;
                dec.Operation = textBox10.Text;
                dec.Fittings = textBox11.Text;
                dec.OpDate = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");//DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                dec.Mechanic = textBox12.Text;
                dec.Satisfaction = comboBox2.SelectedIndex;
                dec.Opinion = textBox13.Text;
                if(!hasD) 
                    fMain.onDeclareModed += new FormMain.onDeclareModedDelegate(fMain_onDeclareModed);
                FormMain.C_ModDeclare(dec);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pageSetupDialog1.ShowDialog();
                printPreviewDialog1.Height = 600;
                printPreviewDialog1.Width = 800;
                printPreviewDialog1.ShowDialog();
            }
            catch(Exception e1)
            {
                MessageBox.Show("����:" + e1.Message);
            }
        }

        private void DrawLongString(Graphics gr, String s, float height, int maxRow)
        {
            int i = 0;
            while(s.Length > MAX_TEXT)
            {
                String temp = "";
                if(i >= maxRow - 1)
                {
                    if(s.Length > MAX_TEXT - 3)
                        temp = s.Substring(0, MAX_TEXT - 3) + "...";
                    else temp = s;
                    s = "";
                }
                else
                {
                    temp = s.Substring(0, MAX_TEXT);
                    s = s.Remove(0, MAX_TEXT);
                }
                gr.DrawString(temp, Font_N, BRUSH, new RectangleF(OFFSET_X + MARGIN, height + TEXT_H * i, WIDTH - MARGIN * 2, TEXT_H));
                i++;
            }
            if(s.Length > 0)
                gr.DrawString(s, Font_N, BRUSH, new RectangleF(OFFSET_X + MARGIN, height + TEXT_H * i, WIDTH - MARGIN * 2, TEXT_H));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawLine(PEN, new Point(OFFSET_X, OFFSET_Y), new Point(WIDTH + OFFSET_X, OFFSET_Y));
            gr.DrawLine(PEN, new Point(WIDTH + OFFSET_X, OFFSET_Y), new Point(WIDTH + OFFSET_X, HEIGHT + OFFSET_Y));
            gr.DrawLine(PEN, new Point(WIDTH + OFFSET_X, HEIGHT + OFFSET_Y), new Point(OFFSET_X, HEIGHT + OFFSET_Y));
            gr.DrawLine(PEN, new Point(OFFSET_X, HEIGHT + OFFSET_Y), new Point(OFFSET_X, OFFSET_Y));

            gr.DrawString("�ͻ�Ͷ�߻���ϴ���", Font_H, BRUSH, new RectangleF(OFFSET_X + 250, OFFSET_Y + 15, 250, TEXT_H + 5));
            gr.DrawString("���ţ�" + ((dec.DeclareID == 0) ? "" : dec.DeclareID.ToString()), Font_N, BRUSH, new RectangleF(OFFSET_X + 550, OFFSET_Y + 25, 120, TEXT_H));

            int MARGIN_1 = OFFSET_X + MARGIN, MARGIN_2 = MARGIN_1 + COL_W_1 + MARGIN,
                MARGIN_3 = MARGIN_1 + WIDTH / 2, MARGIN_4 = MARGIN_3 + COL_W_1 + MARGIN;

            int incY = OFFSET_Y + HEAD_H;
            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("Ͷ��ʱ��", Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), Font_N, BRUSH, new RectangleF(MARGIN_2, incY + MARGIN, COL_W_2, TEXT_H));
            gr.DrawString("��  ��", Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox2.Text, Font_N, BRUSH, new RectangleF(MARGIN_4, incY + MARGIN, COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("��  ��", Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox3.Text, Font_N, BRUSH, new RectangleF(MARGIN_2, incY + MARGIN, COL_W_2, TEXT_H));
            gr.DrawString("��  ��", Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox4.Text, Font_N, BRUSH, new RectangleF(MARGIN_4, incY + MARGIN, COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("��  ��", Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox5.Text, Font_N, BRUSH, new RectangleF(MARGIN_2, incY + MARGIN, COL_W_2, TEXT_H));
            gr.DrawString("����Ʒ��", Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox6.Text, Font_N, BRUSH, new RectangleF(MARGIN_4, incY + MARGIN, COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("ҵ��Ա", Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox7.Text, Font_N, BRUSH, new RectangleF(MARGIN_2, incY + MARGIN, COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("��ϵ��ַ", Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1, TEXT_H));
            gr.DrawString(textBox8.Text, Font_N, BRUSH, new RectangleF(MARGIN_2, incY + MARGIN, COL_W_1 + COL_W_2 * 2 + MARGIN * 3, TEXT_H));
            incY += ROW_H;

            //����
            gr.DrawLine(PEN, new Point(MARGIN_1 + COL_W_1, OFFSET_Y + 50), new Point(MARGIN_1 + COL_W_1, incY));
            gr.DrawLine(PEN, new Point(MARGIN_2 + COL_W_2, OFFSET_Y + 50), new Point(MARGIN_2 + COL_W_2, incY - ROW_H));
            gr.DrawLine(PEN, new Point(MARGIN_3 + COL_W_1, OFFSET_Y + 50), new Point(MARGIN_3 + COL_W_1, incY - ROW_H * 2));

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("Ͷ�߻�������ݣ�", Font_B, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_2, TEXT_H));
            String dc = textBox9.Text;
            DrawLongString(gr, dc, incY += ROW_H, 5);
            incY += (TEXT_H * 5 + MARGIN);
            gr.DrawString("Ͷ�߻������ʷ��", Font_B, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_2, TEXT_H));
            incY += MARGIN;
            for(int i = 0; i < comboBox1.Items.Count; i++)
                gr.DrawString(comboBox1.Items[i] as String, Font_N, BRUSH, new RectangleF(MARGIN_1, incY + TEXT_H * (i + 1), WIDTH - MARGIN * 2, TEXT_H));
            
            incY += (TEXT_H * 5 + MARGIN * 2);
            gr.DrawString("�ӵ��ˣ�" + textBox15.Text, Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1 + COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("���������", Font_B, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_2, TEXT_H));
            String opc = (dec.OpUser != "") ? textBox10.Text : "";
            DrawLongString(gr, opc, incY += ROW_H, 5);
            incY += (TEXT_H * 5 + MARGIN * 2);
            gr.DrawString("ά�޻���������", Font_B, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_2, TEXT_H));
            String ftc = (dec.OpUser != "") ? textBox11.Text : "";
            DrawLongString(gr, ftc, incY += ROW_H, 5);
            incY += (TEXT_H * 5 + MARGIN * 2);
            gr.DrawString("�������ڣ�" + ((dec.OpUser != "") ? dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm") : ""), Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1 + COL_W_2, TEXT_H));
            gr.DrawString("���켼��Ա��" + ((dec.OpUser != "") ? textBox12.Text : ""), Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1 + COL_W_2, TEXT_H));
            incY += ROW_H;

            gr.DrawLine(PEN, new Point(OFFSET_X, incY), new Point(WIDTH + OFFSET_X, incY));
            gr.DrawString("�ͻ�����ȣ�" + ((dec.OpUser != "") ? comboBox2.Text : ""), Font_N, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_1 + COL_W_2, TEXT_H));
            incY += ROW_H;
            gr.DrawString("�ͻ������", Font_B, BRUSH, new RectangleF(MARGIN_1, incY + MARGIN, COL_W_2, TEXT_H));
            String oc = (dec.OpUser != "") ? textBox13.Text : "";
            DrawLongString(gr, oc, incY += ROW_H, 3);
            incY += (TEXT_H * 3 + MARGIN * 2);
            gr.DrawString("�����ˣ�" + ((dec.OpUser != "") ? textBox14.Text : ""), Font_N, BRUSH, new RectangleF(MARGIN_3, incY + MARGIN, COL_W_1 + COL_W_2, TEXT_H));
        }

        private void FormDeclare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.buttonOK.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.buttonCancel.PerformClick();
        }
    }
}