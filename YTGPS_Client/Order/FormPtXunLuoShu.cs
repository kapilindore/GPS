using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormPtXunLuoShu : FormUntitle
    {
        private const String CMD = "ABCDEFGHIJKLMabcd";
        private List<Panel> panels = new List<Panel>();
        private Panel selPanel = null;
        private FormMain mainFrm;
        private List<Team> teamList;

        public FormPtXunLuoShu(FormMain frm, List<Team> list, int cid)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
            mainFrm = frm;
            panels.Add(panel5); panels.Add(panel7); 
            
            panels.Add(panel6); 
           // panels.Add(panel3);速度限制 
            
          //  panels.Add(panel1); 监控中心辅助号码

         // panels.Add(panel2); 监控中心IP
        //    panels.Add(panel4);速度
          //panels.Add(panel10); 自定义报警
            
           //  panels.Add(panel8);监听电话
          //  panels.Add(panel9);断电断油
          //  panels.Add(panel10); 
           // panels.Add(panel11); 
           // panels.Add(panel12); 开关门

            teamList = list;
            foreach(Team team in teamList)
            {
                TreeNode ttn = treeView1.Nodes.Add(team.TeamName);
                ttn.Tag = team;
                foreach(Car car in team.Cars)
                {
                    TreeNode ctn = ttn.Nodes.Add(car.CarNO + "[" + car.Driver + "]");
                    ctn.Tag = car;
                    if(car.CarID == cid)
                    {
                        treeView1.SelectedNode = ctn;
                        ctn.Checked = true;
                    }
                }
            }
            treeView1.ExpandAll();
            comboBox51.SelectedIndex = 0;
            comboBox61.SelectedIndex = 0;
            comboBox90.SelectedIndex = 0;
            comboBox91.SelectedIndex = 1;
            comboBox100.SelectedIndex = 0;
            comboBox101.SelectedIndex = 0;
            comboBox110.SelectedIndex = 0;
            comboBox121.SelectedIndex = 0;
            listBox1.SelectedIndex = 0;
            frm.onGetSettingResponse += new FormMain.onGetSettingResponseDelegate(frm_onGetSettingResponse);
        }

        private void FormPtXunLuoShu_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainFrm.onGetSettingResponse -= frm_onGetSettingResponse;
            mainFrm.ClearTempLayer();
        }
        /*
         * 
         */
        public static String CoverLoToStr(double lo)
        {
            String s = lo.ToString("f0");
            while(s.Length < 3)
                s = "0" + s;
            lo = (lo - (int)lo) * 60;
            String s1 = lo.ToString("f3");
            while(s1.Length < 6)
                s1 = "0" + s1;
            return s + s1;
        }
        /*
         * 
         */
        public static String CoverLaToStr(double la)
        {
            String s = la.ToString("f0");
            while(s.Length < 2)
                s = "0" + s;
            la = (la - (int)la) * 60;
            String s1 = la.ToString("f3");
            while(s1.Length < 6)
                s1 = "0" + s1;
            return s + s1;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请在主界面地图上画取矩形框区域,中间注意不要进行其他的地图操作,所画矩形不要跨越0度经线和纬线");
            mainFrm.MapControl.Tools.LeftButtonTool = MapToolkit.DrawFenceRect;
            mainFrm.onMapDrawRect += new FormMain.mapDrawRect(mainFrm_onMapDrawRect);
            mainFrm.Activate();
        }

        void mainFrm_onMapDrawRect(MapInfo.Geometry.DPoint dpt1, MapInfo.Geometry.DPoint dpt2)
        {
            mainFrm.MapControl.Tools.LeftButtonTool = MapToolkit.Default;
            textBox52.Text = dpt1.x.ToString();
            textBox53.Text = dpt1.y.ToString();
            textBox54.Text = dpt2.x.ToString();
            textBox55.Text = dpt2.y.ToString();
            mainFrm.onMapDrawRect -= mainFrm_onMapDrawRect;
            this.Activate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selPanel != null)
                selPanel.Left = 300;
            if(listBox1.SelectedIndex < panels.Count)
            {
                panels[listBox1.SelectedIndex].Left = 3;
                selPanel = panels[listBox1.SelectedIndex];
            }
            else 
            {
                panelnone.Left = 3;
                selPanel = panelnone;
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag.GetType().Name == Team.ClassName)
            {
                foreach(TreeNode tn in e.Node.Nodes)
                    if(tn.Checked != e.Node.Checked)
                        tn.Checked = e.Node.Checked;
            }
        }

        private void addTextLine(String s)
        {
            String[] temp = null;
            temp = new String[richTextBoxInfo.Lines.Length + 1];
            richTextBoxInfo.Lines.CopyTo(temp, 0);
            temp.SetValue(s, richTextBoxInfo.Lines.Length);
            richTextBoxInfo.Lines = temp;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                if(treeView1.SelectedNode.Tag.GetType().Name == Car.ClassName)
                {
                    Car car = treeView1.SelectedNode.Tag as Car;
                    labelCNO.Text = car.CarNO;
                    if(car.SettingStr == "")
                    {
                        richTextBoxInfo.Text = "请先获取次车辆的终端设置";
                    }
                    else
                    {
                        String[][] control_stat = new String[][]{
                        new String[]{ "", "" },
                        new String[]{ "关闭GPS信息输出", "开启GPS信息输出" },
                        new String[]{ "关闭条件打入打出", "开启条件打入打出" },
                        new String[]{ "动态断油电方式", "静态断油电方式" },
                        new String[]{ "越界不触发自动回传", "越界触发自动回传" },
                        new String[]{ "速度限制在定位时有效", "速度限制总是有效" },
                        new String[]{ "允许打出电话", "禁止打出电话" },
                        new String[]{ "允许打入电话", "禁止打入电话" }
                    };

                        richTextBoxInfo.Text = car.CarNO + "的终端设置如下：";
                        String[] para = car.SettingStr.Split(',');
                        String setflag = Pub.HexToBin(para[0]);
                        String temp = "";
                        if(setflag[6] == '0')
                            temp += "开启自动回传，";
                        else temp += "关闭自动回传，";
                        if(setflag[7] == '0')
                            temp += "允许断油电";
                        else temp += "不允许断油电";
                        addTextLine(temp);
                        addTextLine("自动监控时间" + para[1] + "秒");
                        addTextLine("速度上限" + para[3] + "km/h，速度下限" + para[4] + "km/h，超速报警持续时间" + para[5] + "秒");
                        addTextLine("越界报警持续时间" + para[6] + "秒");
                        String cs = Pub.HexToBin(para[7]);
                        for(int i = 1; i < 8; i++)
                        {
                            addTextLine(control_stat[i][Int16.Parse(cs.Substring(i, 1))]);
                        }
                        String ca = Pub.HexToBin(para[8]);
                        temp = "";
                        for(int i = 0; i < 8; i++)
                            if(ca[i] == '0')
                                temp += ("A" + (i + 1).ToString() + "，");
                        if(temp == "")
                            addTextLine("未开启自定义报警");
                        else addTextLine("已开启自定义报警：" + temp);
                        temp = "";
                        String bf = Pub.HexToBin(para[16]) + Pub.HexToBin(para[15])
                            + Pub.HexToBin(para[14]) + Pub.HexToBin(para[13])
                            + Pub.HexToBin(para[12]) + Pub.HexToBin(para[11])
                            + Pub.HexToBin(para[10]) + Pub.HexToBin(para[9]);
                        for(int i = 63; i >= 0; i--)
                        {
                            if(bf[i] == '0')
                                temp += ((64 - i).ToString() + "，");
                        }
                        if(temp == "")
                            addTextLine("未开启围栏");
                        else addTextLine("已开启围栏：" + temp);
                        addTextLine("监控中心IP：" + para[17]);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择车辆");
                return;
            }
            else
            {
             

                labelInfo.Text = "获取终端设置成功";
                pictureBox1.Visible = false;
                treeView1_AfterSelect(treeView1, new TreeViewEventArgs(treeView1.SelectedNode));
                FormMain.C_Set_GetSet(treeView1.SelectedNode.Tag as Car);
            }
        }

        void frm_onGetSettingResponse(Car car)
        {
            if(car.SettingStr != "")
            {
                labelInfo.Text = "获取" + car.CarNO + "的终端设置成功";
                treeView1_AfterSelect(treeView1, new TreeViewEventArgs(treeView1.SelectedNode));
            }
            else labelInfo.Text = "获取" + car.CarNO + "的终端设置失败";
            pictureBox1.Visible = false;
        }

        private void textBox00_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ',' || e.KeyChar == ';' || e.KeyChar == '|')
                e.KeyChar = (char)0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stb = new StringBuilder(Constant.PROTOCOL_XUNLUOSHU.ToString()).Append(Constant.SPLIT1);
            foreach(TreeNode ttn in treeView1.Nodes)
                foreach(TreeNode ctn in ttn.Nodes)
                    if(ctn.Checked)
                    {
                        if(stb.Length == 2)
                            stb.Append((ctn.Tag as Car).CarID);
                        else stb.Append(Constant.SPLIT2).Append((ctn.Tag as Car).CarID);
                    }
            if(stb.Length == 2)
            {
                MessageBox.Show(this, "没有选择任何车辆");
                return;
            }
            stb.Append(Constant.SPLIT1).Append(CMD[listBox1.SelectedIndex]).Append(Constant.SPLIT1);
            switch(listBox1.SelectedIndex)
            {
               // case 0:
                 //   if(textBox00.Text == "")
               //     {
                 //       MessageBox.Show(this, "请填写中心短信号码");
                //        return;
                //    }
                 //   stb.Append(textBox00.Text);
//break;
                //case 1:
                 //   if(textBox10.Text == "")
                  //  {
                 //       MessageBox.Show(this, "请填写中心辅助短信号码");
                 //       return;
                 //   }
//stb.Append(textBox10.Text);
                  //  break;
                case 2:
                    stb.Append(this.numericUpDown60.Value);
                    break;
                case 3:
                    stb.Append(this.numericUpDown60.Value);
                   
                    break;
                case 4:
                    stb.Append(numericUpDown40.Value);
                    break;
                case 0:
                   if(comboBox51.SelectedIndex == 0 || numericUpDown50.Value == 0)
                    {
                        stb.Append(numericUpDown50.Value).Append(",");
                       // stb.Append(comboBox51.SelectedIndex).Append(",0,0,0,0,0,0"); //目前没用
                    }
                    if(textBox52.Text == "")
                    {
                        MessageBox.Show(this, "请选取围栏");
                        return;
                    }
                    else
                    {
                       // stb.Append(numericUpDown50.Value).Append(",");
                      //  stb.Append(comboBox51.SelectedIndex).Append(",");

                        double x1 = Double.Parse(textBox52.Text);
                         double  y1 = Double.Parse(textBox53.Text);
                         double  x2 = Double.Parse(textBox54.Text);
                          double y2 = Double.Parse(textBox55.Text);
                          String[] ss = x1.ToString().Split('.');
                          string xa = ss[0];
                          string x1_1 = ss[1];

                          string x1_1_str = "0" + "." + x1_1;

                          double x1_n = System.Convert.ToDouble(x1_1_str) * 60;
                       string[] ss_1 = x1_n.ToString("#0.0000").Split('.');
                          string x1_1_1 = ss_1[0];
                          string x1_1_1_1 = ss_1[1];
                          string x1_1_1_1_1 = x1_1_1 + x1_1_1_1;
                          string x1_re = xa +x1_1_1_1_1;
                     
                        //    MessageBox.Show(x1_re);    // 左下精度1

                         
                        /////////////////////////////////////////////////
                        
                        String[] ss_a = y1.ToString().Split('.');
                          string ya = ss_a[0];
                          string y1_1 = ss_a[1];

                          string y1_1_str = "0" + "." + y1_1;

                          double y1_n = System.Convert.ToDouble(y1_1_str) * 60;
                          string[] ss_1_a = y1_n.ToString("#0.0000").Split('.');
                          string y1_1_1 = ss_1_a[0];
                          string y1_1_1_1 = ss_1_a[1];
                          string y1_1_1_1_1 = y1_1_1 + y1_1_1_1;
                          string y1_re = ya + y1_1_1_1_1;
                         // MessageBox.Show(y1_re);    // 左下伟度1
                        ///////////////////////////////////////////////
                          String[] ss_b = x2.ToString().Split('.');
                          string yaa = ss_b[0];
                          string y1_1a = ss_b[1];

                          string y1_1_stra = "0" + "." + y1_1a;

                          double y1_na = System.Convert.ToDouble(y1_1_stra) * 60;
                          string[] ss_1_b = y1_na.ToString("#0.0000").Split('.');
                          string y1_1_1a = ss_1_b[0];
                          string y1_1_1_1a = ss_1_b[1];
                          string y1_1_1_1_1a = y1_1_1a + y1_1_1_1a;
                          string y1_rea = yaa + y1_1_1_1_1a;
                       //   MessageBox.Show(y1_rea);    
                                                                       
                       //////////////////////////////////////////////////

                          String[] ss_ba = y2.ToString().Split('.');
                          string yaaa = ss_ba[0];
                          string y1_1aa = ss_ba[1];

                          string y1_1_straa = "0" + "." + y1_1aa;

                          double y1_naa = System.Convert.ToDouble(y1_1_straa) * 60;
                          string[] ss_1_ba = y1_naa.ToString("#0.0000").Split('.');
                          string y1_1_1ab = ss_1_ba[0];
                          string y1_1_1_1ab = ss_1_ba[1];
                          string y1_1_1_1_1ab = y1_1_1ab + y1_1_1_1ab;
                          string y1_reab = yaaa + y1_1_1_1_1ab;
                        //  MessageBox.Show(y1_reab);

                          stb.Append(y1_re).Append("0").Append(x1_re).Append(y1_reab).Append("0").Append(y1_rea);
                                                       

                        /*
                         1.只要求保留N位不四舍五入

        float f = 0.55555f;
        int i =(int)(f * 100);
        f = (float)(i*1.0)/100;

2.保留N位，并且四舍五入    

        decimal d= decimal.Round(decimal.Parse("0.55555"),2);

3.保留N位，并且四舍五入

        Math.Round(0.55555,2)

4.保留N位，并且四舍五入

        double dbdata = 0.55555;
        string str1 = dbdata.ToString("f2");//fN 保留N位，四舍五入

5.保留N位，并且四舍五入

        string result = String.Format("{0:N2}", 0.55555);//2位
        string result = String.Format("{0:N3}", 0.55555);//3位

6.保留N位，并且四舍五入

        double s=0.55555;
        result=s.ToString("#0.00");//点后面几个0就保留几位

或者(求圆的面积和周长)

                double s = Convert.ToDouble(textBox1.Text);
                double mianji = Math.PI * s * s;
                textBox2.Text = mianji.ToString("F3");
                double zhouchang = 2 * Math.PI * s;
                textBox3.Text = zhouchang.ToString("F3");
 


                         
                         
                         */




                        /*
                        if(y1 < 0)
                            stb.Append("S,");
                        else stb.Append("N,");
                        y1 = Math.Abs(y1); y2 = Math.Abs(y2);
                        if(y1 > y2) //小的放前面
                        {
                            temp = y1;
                            y1 = y2;
                            y2 = temp;
                        }
                        stb.Append(CoverLaToStr(y1)).Append(",");
                        stb.Append(CoverLaToStr(y2)).Append(",");

                        if(x1 < 0)
                            stb.Append("E,");
                        else stb.Append("W,");
                        x1 = Math.Abs(x1); x2 = Math.Abs(x2);
                        if(x1 > x2)//小的放前面
                        {
                            temp = x1;
                            x1 = x2;
                            x2 = temp;
                        }
                        stb.Append(CoverLoToStr(x1)).Append(",");
                        stb.Append(CoverLoToStr(x2));
                   
                         */
                    }
                    break;
                case 6:
                    stb.Append(numericUpDown60.Value).Append(",");
                    stb.Append(comboBox61.SelectedIndex + 1).Append(",");
                    stb.Append(textBox62.Text);
                    break;
                case 1:
                    

                    stb.Append(this.numericUpDown70.Value);

                    

                    break;
                case 8:
                    if(textBox80.Text == "")
                    {
                        MessageBox.Show(this, "请填写监听电话");
                        return;
                    }
                    stb.Append(textBox80.Text);
                    break;
                case 9:
                    stb.Append(comboBox91.SelectedIndex).Append(",");
                    if(comboBox90.SelectedIndex == 1)//解除断电
                        stb.Append("0");
                    else if(FormMain.CheckPw())//断电，需密码确认
                    {
                        stb.Append(numericUpDown92.Value).Append(",");
                        stb.Append(numericUpDown92.Value).Append(",");
                        stb.Append(numericUpDown92.Value).Append(",");
                        stb.Append(numericUpDown92.Value);
                    }
                    else return;
                    break;
                case 10:
                    if(comboBox100.SelectedIndex == 0)
                    {
                        stb.Append("A0,0,0,0");
                    }
                    else
                    {
                        stb.Append("A").Append(comboBox100.SelectedIndex + 4).Append(",");
                        if(comboBox101.SelectedIndex == 0)
                        {
                            stb.Append("0,0,");
                        }
                        else
                        {
                            stb.Append(comboBox101.SelectedIndex).Append(",");
                            stb.Append(numericUpDown102.Value).Append(",");
                        }
                        stb.Append(checkBox103.Checked ? "1" : "0");
                    }
                    break;
                case 11:
                    String bin = "1111111";
                    if(comboBox110.SelectedIndex == 0)//允许断油
                        bin += "0";
                    else bin += "1";
                    stb.Append(Pub.BinToHex(bin));
                    break;
                case 12://远程开关门
                    stb.Append(comboBox121.SelectedIndex);
                    break;
                default:
                    break;
            }
            if(FormMain.dataSocket.Connected)
                FormMain.C_Set_Order(stb.ToString());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}