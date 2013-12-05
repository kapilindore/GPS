using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCarList : FormUntitle
    {
        private List<QueryCondition> qcList = new List<QueryCondition>();
        private CarList cList = new CarList();

        public FormCarList()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, true, true);
        }

        private void FormCarList_Shown(object sender, EventArgs e)
        {
            button3.Visible = FormMain.user.PolicyExportCars == 1;
        }

        private void FormCarList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryCondition qc = new QueryCondition();
            FormQueryCondition frm = new FormQueryCondition(qc);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                qcList.Add(qc);
                listBox1.Items.Add(QueryCondition.LABEL[qc.Label] + " " + QueryCondition.TYPE[qc.Type] + " " + qc.Keyword.ToLower());
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                qcList.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            qcList.Clear();
        }

        public bool CheckCar(Car car)
        {
            if(qcList.Count == 0)
                return true;
            foreach(QueryCondition qc in qcList)
            {
                String value = "";
                if(qc.Label == 0)
                    value = car.CarNO;
                else if(qc.Label == 1)
                    value = car.SimNO;
                else if(qc.Label == 2)
                    value = car.MachineNO;
                else if(qc.Label == 3)
                    value = car.ControlPassword;
                else if(qc.Label == 4)
                    value = car.MachineType;
                else if(qc.Label == 5)
                    value = car.CarBrand;
                else if(qc.Label == 6)
                    value = car.CarType;
                else if(qc.Label == 7)
                    value = car.CarColor;
                else if(qc.Label == 8)
                    value = car.InstallPlace;
                else if(qc.Label == 9)
                    value = car.InstallPerson;
                else if(qc.Label == 10)
                    value = car.BusinessPerson;
                else if(qc.Label == 11)
                    value = car.JoinTime;
                else if(qc.Label == 12)
                    value = car.OverServiceTime;
                else if(qc.Label == 13)
                    value = car.CarRemark;
                else if(qc.Label == 14)
                    value = car.Driver;
                else if(qc.Label == 15)
                    value = car.DriverTel;
                else if(qc.Label == 16)
                    value = car.DriverMobile;
                else if(qc.Label == 17)
                    value = car.Driver2;
                else if(qc.Label == 18)
                    value = car.Driver2Tel;
                else if(qc.Label == 19)
                    value = car.Driver2Mobile;
                else if(qc.Label == 20)
                    value = car.Password;
                else if(qc.Label == 21)
                    value = car.DriverAddress;
                else if(qc.Label == 22)
                    value = car.DriverTel;
                else if(qc.Label == 23)
                    value = car.DriverCompany;
                else if(qc.Label == 24)
                    value = car.BuyTime;
                else if(qc.Label == 25)
                    value = car.SpecialRequest;
                else if(qc.Label == 26)
                    value = car.DriverRemark;
                else if(qc.Label == 27)
                    value = car.SimNO;
                value = value.ToLower();
                if(qc.Type == 0)
                {
                    if(value.ToLower().IndexOf(qc.Keyword) >= 0)
                        return true;
                }
                else if(qc.Type == 1)
                {
                    if(value.ToLower() == qc.Keyword)
                        return true;
                }
                else
                {
                    if(value.ToLower().IndexOf(qc.Keyword) < 0)
                        return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarList temp = new CarList();
            if(checkBox1.Checked)
            {
                foreach(Car car in cList.Cars)
                    if(CheckCar(car))
                        temp.Cars.Add(car);
            }
            else
            {
                foreach(Team team in FormMain.user.TeamList)
                    foreach(Car car in team.Cars)
                    {
                        if(CheckCar(car))
                            temp.Cars.Add(car);
                    }
            }
            cList = temp;
            checkBox1.Enabled = cList.Cars.Count > 0;
            checkBox1.Checked = false;

            labelCount.Text = cList.Cars.Count.ToString();
            listView1.Items.Clear();
            foreach(Car car in cList.Cars)
            {
                ListViewItem item = new ListViewItem(car.CarNO);
                item.SubItems.Add(car.SimNO);
                item.SubItems.Add(car.MachineNO);
                item.SubItems.Add(car.ControlPassword);
                item.SubItems.Add(car.MachineType);
                item.SubItems.Add(car.CarBrand);
                item.SubItems.Add(car.CarType);
                item.SubItems.Add(car.CarColor);
                item.SubItems.Add(car.InstallPlace);
                item.SubItems.Add(car.InstallPerson);
                item.SubItems.Add(car.BusinessPerson);
                item.SubItems.Add(car.JoinTime);
                item.SubItems.Add(car.OverServiceTime);
                item.SubItems.Add(car.CarRemark);
                item.SubItems.Add(car.Driver);
                item.SubItems.Add(car.DriverTel);
                item.SubItems.Add(car.DriverMobile);
                item.SubItems.Add(car.Driver2);
                item.SubItems.Add(car.Driver2Tel);
                item.SubItems.Add(car.Driver2Mobile);
                item.SubItems.Add(car.Password);
                item.SubItems.Add(car.DriverAddress);
                item.SubItems.Add(car.DriverTel);
                item.SubItems.Add(car.DriverCompany);
                item.SubItems.Add(car.BuyTime);
                item.SubItems.Add(car.SpecialRequest);
                item.SubItems.Add(car.DriverRemark);
                listView1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show(this, "没有任何项目");
                return;
            }
            if(listView1.Items.Count > 500)
            {
                if(MessageBox.Show(this, "项目过多，导出可能会花较多时间，要继续吗？", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
            }
            DataTable dt = new DataTable();
            foreach(ColumnHeader ch in listView1.Columns)
                dt.Columns.Add(ch.Text);
            foreach(ListViewItem item in listView1.Items)
            {
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, 
                    item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                    item.SubItems[7].Text,item.SubItems[8].Text, item.SubItems[9].Text,
                    item.SubItems[10].Text,item.SubItems[11].Text, item.SubItems[12].Text,
                    item.SubItems[13].Text,item.SubItems[14].Text, item.SubItems[15].Text,
                    item.SubItems[16].Text,item.SubItems[17].Text, item.SubItems[18].Text,
                    item.SubItems[19].Text,item.SubItems[20].Text, item.SubItems[21].Text,
                    item.SubItems[22].Text,item.SubItems[23].Text, item.SubItems[24].Text,
                    item.SubItems[25].Text,item.SubItems[26].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, Application.StartupPath + "\\车辆列表[" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + "].xls");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}