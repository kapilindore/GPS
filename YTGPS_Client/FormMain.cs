using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using MapInfo.Data;
using MapInfo.Geometry;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Styles;

namespace YTGPS_Client
{
    public partial class FormMain : Form
    {    
        public static Color COLOR_CAR_NORMAL = Color.Black;
        public static Color COLOR_CAR_IN_WATCH = Color.Blue;
        public static Color COLOR_CAR_OVER_SERVICE = Color.Orange;
        public static Color COLOR_CAR_STOP = Color.Red;
        public static Color COLOR_NORMAL = Color.Green;
        public static Color COLOR_ALARM = Color.Red;


        public static Car alarmHandleCar = null;
        public static bool inAlarmHandle = false;
        public static bool hasLogin = false;
    

        public static User user = null;//new User();
        public static List<Account> accountList = null;//new List<Account>();
        public static List<AlarmPosition> alarmList = null;//new List<AlarmPosition>();

        public static FormStartup frmStartup = null;//new FormStartup();
        public static FormTeamInfo frmTeamInfo = null;//new FormTeamInfo();
        public static FormCarInfo frmCarInfo = null;//new FormCarInfo();
        public static FormHisPos frmHisPos = null;//new FormHisPos();
        public static FormHisAlarm frmHisAlarm = null;//new FormHisAlarm();
        public static FormAccountList frmAccountList = null;//new FormAccountList();
        public static FormAlarmList frmAlarmList = null;//new FormAlarmList();
        public static FormOverSvrList frmOverServiceList = null;//new FormOverSvrList();
        public static FormCarList frmCarList = null;//new FormCarList();
        private FormDeclareListHis frmDeclareListHis = null;
        public static FormChat frmChat = null;//new FormChat();
        public static FormOrderHis frmOrderHis = null;//new FormOrderHis();
        public static FormOperationHis frmOperationHis = null;//new FormOperationHis();
       
        public static List<Position> hisPosList = null;//new List<Position>();
        public static List<HisAlarmPosition> hisAlarmList = null;//new List<HisAlarmPosition>();
        public static List<Mileage> mileageList = null;//new List<Mileage>();
        public static List<Place> placeList = null;//new List<Place>();
        public static CarList regionQueryCarList = null;//new CarList();
        public static DateTime dateTimeRegionQuery1;//new DateTime();
        public static DateTime dateTimeRegionQuery2;//new DateTime();


        public const int DATA_MSG = 0x0400;
            public const int DATA_CONN = 0;
            public const int DATA_DISCONN = 1;
            public const int DATA_REV = 2;
        //public const int TEL_MSG = 0x0401;
       


    // [ DllImport("user32.dll",EntryPoint="PostMessage",CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
          


          


      
          [ DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]

        public static extern IntPtr PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
   
      delegate void MessageToMainForm(int para1, int para2);
       public void f_MessageToMainForm(int para1, int para2)
      {
        
            PostMessage(this.Handle, DATA_MSG, new IntPtr(para1), new IntPtr(para2));
  
 }
 
 

  //��ͼ����ֻ�������߳���ɣ����socket�¼�ͨ����Ϣ���ݵ����̣߳������̲߳���
 
 protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            if(m.Msg == DATA_MSG)
            {
                switch(m.WParam.ToInt32())
                {
                    case DATA_CONN:
                        DataOnConn(m.LParam.ToInt32() == 1);
                        break;
                    case DATA_DISCONN:
                        DataOnDisConn();
                        break;
                    case DATA_REV:
                        DataOnReceive();
                        break;
                }
           
        
 }
            else base.DefWndProc(ref m);///���û��ຯ��������Զ�����Ϣ��
       
            
        }
        
       

        public FormMain()
        {



            


            frmStartup = new FormStartup();
            frmStartup.Show();
            frmStartup.Refresh();

            InitializeComponent();

            user = new User();
            accountList = new List<Account>();
            alarmList = new List<AlarmPosition>();

            frmTeamInfo = new FormTeamInfo();
            frmCarInfo = new FormCarInfo();
            frmHisPos = new FormHisPos();
            frmHisAlarm = new FormHisAlarm();
            frmAccountList = new FormAccountList();
            frmAlarmList = new FormAlarmList();
            frmOverServiceList = new FormOverSvrList();
            frmCarList = new FormCarList();
            frmDeclareListHis = new FormDeclareListHis();
            frmChat = new FormChat();
            frmOrderHis = new FormOrderHis();
            frmOperationHis = new FormOperationHis();

            hisPosList = new List<Position>();
            hisAlarmList = new List<HisAlarmPosition>();
            mileageList = new List<Mileage>();
            placeList = new List<Place>();
            regionQueryCarList = new CarList();
            dateTimeRegionQuery1 = new DateTime();
            dateTimeRegionQuery2 = new DateTime();
            buttonItemDefault.Tag = MapToolkit.Default;
            buttonItemZoomin.Tag = MapToolkit.Zoomin;
            buttonItemZoomout.Tag = MapToolkit.Zoomout;
            buttonItemCenter.Tag = MapToolkit.Center;
            buttonItemPan.Tag = MapToolkit.Pan;
            buttonItemDistance.Tag = MapToolkit.Distance;
            buttonItemGeoInfo.Tag = MapToolkit.GeoInfo;

            frmAlarmList.OnShowPos += new FormAlarmList.ShowPosDelegate(OnShowAlarmPos);
            dataSocket.OnConnect += new ClientSocket.conncetDelegate(dataSocket_OnConnect);
            dataSocket.OnDisconnect += new ClientSocket.disconncetDelegate(dataSocket_OnDisconnect);
            dataSocket.OnReceive += new ClientSocket.receiveDelegeate(dataSocket_OnReceive);

            gisServer.OnActive += new ServerSocket.activeDelegate(gisServer_OnActive);
            gisServer.OnDeactive += new ServerSocket.deactiveDelegate(gisServer_OnDeactive);
            gisServer.OnConnect += new ServerSocket.conncetDelegate(gisSocket_OnConnect);
            gisServer.OnDisconnect += new ServerSocket.disconncetDelegate(gisServer_OnDisconnect);
            gisServer.OnReceive += new ServerSocket.receiveDelegeate(gisSocket_OnReceive);
        }
        //��ʼ��
        private void FormMain_Load(object sender, EventArgs e)
        {
         

            Config.APP_PATH = Application.StartupPath + "\\";
            Config.loadFromFile();
            if(!CheckMap())
                AppConfig();
            else frmStartup.Close();
            if (Config.myzoom != 0)
            {
                //Random c = new Random();
                //int a = c.Next(200, 500);
               // int b = c.Next(700, 990);
               // double lo = 116 + a * 0.001;
               // double la = c.Next(39, 40) + b * 0.001;
                  MapControl.Map.Zoom = new MapInfo.Geometry.Distance(Config.myzoom, MapInfo.Geometry.DistanceUnit.Mile);
                mapControl.Map.SetView(new DPoint(Config.lo, Config.la), mapControl.Map.GetDisplayCoordSys(), mapControl.Map.Zoom);
               
            }
            else
            {

                //  MessageBox.Show(mapControl.Map.Zoom.Value.ToString());
                Random c = new Random();
                int a = c.Next(200, 500);
                int b = c.Next(700, 990);
                double lo = 116 + a * 0.001;
                double la = c.Next(39, 40) + b * 0.001;


                MapControl.Map.Zoom = new MapInfo.Geometry.Distance(mapControl.Map.Zoom.Value * 1.609 / mapControl.Width, MapInfo.Geometry.DistanceUnit.Mile);
                mapControl.Map.SetView(new DPoint(lo, la), mapControl.Map.GetDisplayCoordSys(), mapControl.Map.Zoom);
            }


            timerTime.Enabled = true;
        }
        //
        private void FormMain_Shown(object sender, EventArgs e)
        {
            if(Config.AutoLogin)
            {
                user.Host = Config.Host;
                user.Port = Config.Port;
                user.Type = Config.UserType;
                user.Name = Config.User;
                user.Pw = Config.Pw;
                Login();
            }
            expandablePanelMapQuery.Expanded = true;
            SetLogoutStatus();
        }
        //�˳��ͷ���Դ
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataSocket.Connected)
            {
                MessageBox.Show(this, StrConst.WARN_EXIT, StrConst.TITLE_MSG);
                e.Cancel = true;
            }
            else gisServer.Active = false;
        }
        //���� �������
        private void timerTest_Tick(object sender, EventArgs e)
        {
            timerTest.Enabled = false;
            timerCheckConn.Enabled = false;
            if(dataSocket.Connected)
            {
                connOK = false;
                C_Conn_Test();
                timerCheckConn.Enabled = true;
            }
        }
        //�������
        private void timerCheckConn_Tick(object sender, EventArgs e)
        {
            timerCheckConn.Enabled = false;
            if(!connOK)
            {
                dataSocket.DisConnect();
            }
        }
        //�Զ�����
        private void timerReconn_Tick(object sender, EventArgs e)
        {
            timerReconn.Enabled = false;
            if(reconnCount < Config.MaxReconnInc)
                reconnCount++;
            timerReconn.Interval = timerReconn.Interval + 250 * reconnCount;
            Log(StrConst.CONN_RECONN);
            Login();
        }
        #region f
        private void FormMain_ResizeBegin(object sender, EventArgs e)
        {
            mapControl.Visible = false;
        }
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            mapControl.Visible = true;
        }
        //��½
        public void Login()
        {
            ToolStripMenuItem0Login.Enabled = false;
            ToolStripMenuItem0Logout.Enabled = true;
            buttonItemLogin.Enabled = false;
            buttonItemLogout.Enabled = true;
            dataSocket.ConnectServer(user.Host, user.Port);
            buttonItemLogout.Enabled = true;
        }
        //����ͼ
        private bool CheckMap()
        {
            if(Config.MapList.Count == 0 || !File.Exists(Config.MapList[0].File))
            {
                try
                {
                    frmStartup.Close();
                }
                catch { }
                MessageBox.Show(this, StrConst.ERR_LOAD_MAP, StrConst.TITLE_ERR);
                return false;
            }
            else
            {
                //�����һ����ͼ
                try
                {
                    ToolStripMenuItem2ChangeMap.DropDownItems.Clear();
                    for(int i=0; i<Config.MapList.Count; i++)
                    {
                        MapFile mf = Config.MapList[i];
                        ToolStripMenuItem item = ToolStripMenuItem2ChangeMap.DropDownItems.Add(mf.Name) as ToolStripMenuItem;
                        item.Tag = mf;
                        item.Click += new EventHandler(MapMenuItemClick);
                        if(i == 0)
                        {
                            item.Checked = true;
                            item.PerformClick();
                        }
                    }
                    return true;
                }
                catch { }
                try
                {
                    frmStartup.Close();
                }
                catch { }
                MessageBox.Show(this, StrConst.ERR_LOAD_MAP, StrConst.TITLE_ERR);
                return false;
            }
        }
        //��������
        public void AppConfig()
        {
            FormConfig frm = new FormConfig();
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                Config.saveToFile();
                if(!CheckMap())
                    AppConfig();
            }
        }
        //��֤���
        public static bool CheckPw()
        {
            FormCheckPw frm = new FormCheckPw();
            if(frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }
        //��������
        public void PlaySound(string FileName)
        {
            try
            {
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(FileName);
                sp.Play();
            }
            catch { }
        }
        #endregion
        //----------------------------------------------------------------------------//
        #region ϵͳ�˵�
        private void ToolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            AppConfig();
        }
        //�˳�����
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
           

            this.Close();
        }
        //��½
        private void ToolStripMenuItemLogin_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin(this);
            frm.ShowDialog();
        }
        //�绰��չ����
        private void ToolStripMenuItemGisServer_Click(object sender, EventArgs e)
        {
            gisServer.Port = Config.GisPort;
            gisServer.Active = !gisServer.Active;
        }
        //����windows
        private void ToolStripMenuItemLockDown_Click(object sender, EventArgs e)
        {
            Pub.LockWorkStation();
        }
        //�˳���½
        public void Logout()
        {
            Config.myzoom = mapControl.Map.Zoom.Value;
           
            Config.saveToFile();

            dataSocket.ReConn = false;
            dataSocket.DisConnect();
        }
        private void ToolStripMenuItemLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        //������Ϣ
        private void ToolStripMenuItemUserInfo_Click(object sender, EventArgs e)
        {
            if(CheckPw())
            {
                Account at = new Account(user as Account);
                FormUserInfo frm = new FormUserInfo(at);
                if(frm.ShowDialog() == DialogResult.OK)
                    C_Info_ModifyAccount(at);
            }
        }
        //ϵͳ�ʺŹ���
        private void ToolStripMenuItemAccoutList_Click(object sender, EventArgs e)
        {
            frmAccountList.Show();
            frmAccountList.Activate();
        }
        //������¼
        private void ToolStripMenuItemQueryOperation_Click(object sender, EventArgs e)
        {
            frmOperationHis.Show();
            frmOperationHis.Activate();
        }
        //ָ���¼
        private void ToolStripMenuItemQueryOrder_Click(object sender, EventArgs e)
        {
            frmOrderHis.Show();
            frmOrderHis.Activate();
        }
        //Ͷ�ߡ����ϼ�¼
        private void ToolStripMenuItemQueryDeclare_Click(object sender, EventArgs e)
        {
            frmDeclareListHis.Show();
            frmDeclareListHis.Activate();
        }
        //��ʷ�켣
        private void ToolStripMenuItemHisPos_Click(object sender, EventArgs e)
        {
            frmHisPos.Show();
            frmHisPos.Activate();
        }
        //��ʷ����
        private void ToolStripMenuItemHisAlarm_Click(object sender, EventArgs e)
        {
            frmHisAlarm.Show();
            frmHisAlarm.Activate();
        }
        //���촰��
        private void ToolStripMenuItemChatForm_Click(object sender, EventArgs e)
        {
            frmChat.Show();
        }
        //����
        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            if(!Pub.Execute(Config.APP_PATH, Constant.FILE_HELP_DOC, ""))
                MessageBox.Show(this, StrConst.ERR_NONE_HELP_DOC, StrConst.TITLE_WARN);
        }
        //���ڳ���
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog(this);
        }
        //ʱ������
        private void timerTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = Pub.DateTimeStr;
        }
        //ϵͳ��Ϣ
        private void Log(String s)
        {
            listBoxMessage.Items.Add(DateTime.Now.ToString("[" + Pub.DateTimeStr + "]") + s);
            listBoxMessage.SelectedIndex = listBoxMessage.Items.Count - 1;
        }
        //�����
        private void buttonItemSidebar_Click(object sender, EventArgs e)
        {
            panelEx1.Visible = buttonItemSidebar.Checked;
        }
        #endregion

        #region ��ͼ����
        public delegate void mapDrawRect(DPoint dpt1, DPoint dpt2);
        public event mapDrawRect onMapDrawRect;
        public MapInfo.Windows.Controls.MapControl MapControl
        {
            get { return this.mapControl; }
        }
        //������ͼ
        private void MapMenuItemClick(object sender, EventArgs e)
        {
            foreach(ToolStripMenuItem tsi in ToolStripMenuItem2ChangeMap.DropDownItems)
                tsi.Checked = false;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;
            MapFile mf = item.Tag as MapFile;
            InitMap(mf);
            toolStripStatusLabelMap.Text = mf.Name;
        }
        //���ӥ��ͼ
        private void mapControlOver_MouseClick(object sender, MouseEventArgs e)
        {
            MoveMap(GetOverviewCoordPt(e.X, e.Y));
        }
        //��ͼ����
        private void itemButtonMap_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem bi = sender as DevComponents.DotNetBar.ButtonItem;
            mapControl.Tools.LeftButtonTool = (String)bi.Tag;
            if(mapControl.Tools.LeftButtonTool == MapToolkit.Distance)//������
                disPtList.Clear();
        }
        //ȫͼ
        private void buttonItemFullMap_Click(object sender, EventArgs e)
        {
            FullMap();
        }
        //����
        private void buttonItemClearMap_Click(object sender, EventArgs e)
        {
            ClearMap();
        }
        //��ʾ/����ӥ��ͼ
        private void buttonItemMinimap_Click(object sender, EventArgs e)
        {
            panelOverview.Visible = buttonItemMimiMap.Checked;
        }
        //��ͼ�����
        private void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                mapControl.Tools.LeftButtonTool = MapToolkit.Default;
                ClearDistance();
                disPtList.Clear();
            }
            else if(mapControl.Tools.LeftButtonTool == MapToolkit.Distance)
            {
                if(e.Button == MouseButtons.Left)
                {
                    disPtList.Add(new System.Drawing.Point(e.X, e.Y));
                    double minPix = mapControl.Map.Zoom.Value * 1.609 / mapControl.Width;
                    double dis = 0, disAll = 0;
                    for(int i = 0; i < disPtList.Count - 1; i++)
                    {
                        dis = Math.Sqrt((disPtList[i].X - disPtList[i + 1].X) * (disPtList[i].X - disPtList[i + 1].X)
                                    + (disPtList[i].Y - disPtList[i + 1].Y) * (disPtList[i].Y - disPtList[i + 1].Y)) * minPix;
                        disAll += dis;
                    }
                    StringBuilder stb = new StringBuilder(50);
                    stb.Append("��ǰ����:");
                    stb.Append(dis.ToString("f3"));
                    stb.Append("km,�ܾ���:");
                    stb.Append(disAll.ToString("f3"));
                    stb.Append("km");
                    toolStripStatusLabelMousePos.Text = stb.ToString();
                    RefreshDistance();
                }
            }
            else if(mapControl.Tools.LeftButtonTool == MapToolkit.PickPoint)//ѡ���ע����
            {
                DPoint dpt = GetCoordPt(e.X, e.Y);
                textBoxMarkLo.Text = dpt.x.ToString();
                textBoxMarkLa.Text = dpt.y.ToString();
                mapControl.Tools.LeftButtonTool = MapToolkit.Default;
                //MessageBox.Show(GetPosInfo(dpt.x, dpt.y));
            }
            else if(mapControl.Tools.LeftButtonTool == MapToolkit.DrawQueryRegion)//����鳵
            {
                queryPtList.Add(GetCoordPt(e.X, e.Y));
                RefreshRegionQuery();
            }
            else if(mapControl.Tools.LeftButtonTool == MapToolkit.GeoInfo)//������Ϣ
            {
                DPoint dpt = GetCoordPt(e.X, e.Y);
                MessageBox.Show(GetPosInfo(dpt.x, dpt.y));
            }
        }
        //��ͼ����������
        private void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                startPoint = GetCoordPt(e.X, e.Y);
                mouseDowned = true;
            }
        }
        //��ͼ����������
        private void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                endPoint = GetCoordPt(e.X, e.Y);
                if(mapControl.Tools.LeftButtonTool == MapToolkit.DrawQueryRect)//��ѯͼ�����
                {
                    ClearTempLayer();
                    List<String> list = GetPlacesInRect(startPoint, endPoint, (String)comboBoxLayers.SelectedItem);
                    foreach(String s in list)
                        listBoxLayerPlace.Items.Add(s);
                    mapControl.Tools.LeftButtonTool = MapToolkit.Default;
                }
                if(mapControl.Tools.LeftButtonTool == MapToolkit.DrawFenceRect && startPoint.x != endPoint.x && startPoint.y != endPoint.y)//����Χ��
                {
                    if(onMapDrawRect != null)
                        onMapDrawRect(startPoint, endPoint);
                }
                mouseDowned = false;
            }
        }
        //��ͼ����ƶ�
        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(mapControl.Tools.LeftButtonTool != MapToolkit.Distance)
            {
                DPoint dpt = GetCoordPt(e.X, e.Y);
                StringBuilder stb = new StringBuilder(50);
                stb.Append(dpt.x.ToString("f8"));
                stb.Append(",");
                stb.Append(dpt.y.ToString("f8"));
                stb.Append(",");
                stb.Append((mapControl.Map.Zoom.Value * 1.609).ToString("f3"));
                stb.Append("km");
                
                toolStripStatusLabelMousePos.Text = stb.ToString();
                Config.lo = dpt.x;
                Config.la = dpt.y;

                if(e.Button == MouseButtons.Left && mouseDowned
                    && (mapControl.Tools.LeftButtonTool == MapToolkit.DrawFenceRect || mapControl.Tools.LeftButtonTool == MapToolkit.DrawQueryRect))//������
                {
                    ClearTempLayer();
                    DrawRect(startPoint, GetCoordPt(e.X, e.Y));
                }
            }
        }
        #endregion

        #region �����б�
        //�����߼���ѯ
        private void buttonQueryCar_Click(object sender, EventArgs e)
        {
            frmCarList.Show();
        }
        //��������,�ؼ��ֱ䶯ʱ�Զ����³����б�.
        private void comboBoxExKey_TextChanged(object sender, EventArgs e)
        {
            RefreshCarList();
        }
        //���³����б�
        private void RefreshCarList()
        {
            String key = comboBoxExKey.Text.ToLower();
            treeViewCars.Nodes.Clear();
            bool osAll = false;
            foreach(Team team in user.TeamList)
            {
                TreeNode tn = new TreeNode(team.TeamName + "[" + team.Cars.Count + "]");
                foreach(Car car in team.Cars)
                {
                    bool os = false;
                    try
                    {
                        if(DateTime.Parse(car.OverServiceTime) < DateTime.Now)
                        {
                            os = true;
                            osAll = true;
                        }
                    }
                    catch { }
                    if(key != "" && !(car.CarNO.ToLower().IndexOf(key) >= 0 || car.Driver.ToLower().IndexOf(key) >= 0))
                                       // || car.SimNO.IndexOf(key) >= 0 || car.MachineNO.IndexOf(key) >= 0))
                        continue;
                    TreeNode tn1 = new TreeNode(car.CarNO + "[" + car.Driver + "]");
                    if(os)
                    {
                        tn1.Text = tn1.Text + StrConst.CAR_OVER_TIME;
                        tn1.ForeColor = COLOR_CAR_OVER_SERVICE;
                    }
                    if(car.Stoped == 1)
                    {
                        tn1.Text = tn1.Text + StrConst.CAR_STOPED;
                        if(car.ItemInWatch != null)
                            listViewWatching.Items.Remove(car.ItemInWatch);
                        tn1.ForeColor = COLOR_CAR_STOP;
                    }
                    if(car.DeclareCount > 0)
                        tn1.Text = tn1.Text + StrConst.CAR_DECLARE_1 + car.DeclareCount + StrConst.CAR_DECLARE_2;
                    tn1.Tag = car;
                    car.ItemInList = tn1;
                    tn.Nodes.Add(tn1);
                }
                tn.Tag = team;
                treeViewCars.Nodes.Add(tn);
            }
            foreach(Team team in user.TeamList)
                foreach(Car car in team.Cars)
                    if(car.IsWatched)
                        car.ItemInList.Checked = true;
            for(int i = 0; i < listViewWatching.Items.Count; i++)
            {
                if(user.GetCarByID((listViewWatching.Items[i].Tag as Car).CarID) == null)
                {
                    listViewWatching.Items.RemoveAt(i);
                    i--;
                }
            }
            if((user.Type == User.USER_ADMIN || user.Type == User.USER_OP) && user.PolicyOverTime == 1)
            {
                if(osAll)
                {
                    toolStripStatusLabelOverService.ForeColor = COLOR_ALARM;
                    toolStripStatusLabelOverService.Text = StrConst.STATUS_HAS_OVER_TIME;
                    frmOverServiceList.RefreshList(user.TeamList);
                }
                else
                {
                    toolStripStatusLabelOverService.ForeColor = COLOR_NORMAL;
                    toolStripStatusLabelOverService.Text = StrConst.STATUS_NO_OVER_TIME;
                }
            }
            if(key != "")
                treeViewCars.ExpandAll();
        }
        //�����
        private void RefreshWatching()
        {
            if(!hasLogin)
                return;
            foreach(TreeNode tn in treeViewCars.Nodes)
            {
                foreach(TreeNode tn1 in tn.Nodes)
                {
                    try
                    {
                        Car car = tn1.Tag as Car;
                        if(car.IsWatched && !tn1.Checked)
                        {
                            car.IsWatched = false;
                            if(car.Stoped == 0 ||
                                (user.Type != User.USER_TEAM && user.Type != User.USER_CAR))
                                C_Pos_StopWatch(car);
                        }
                        else if(!car.IsWatched && tn1.Checked)
                        {
                            if(car.Stoped == 1 &&
                                (user.Type == User.USER_TEAM || user.Type == User.USER_CAR))
                            {
                                MessageBox.Show(this, StrConst.MSG_CAR_STOPED, StrConst.TITLE_MSG);
                                return;
                            }
                            car.IsWatched = true;
                            C_Pos_Watch(car);
                        }
                    }
                    catch { }
                }
            }
        }
        //������ʾ���ӡ�������ϸ��Ϣ
        private void treeViewCars_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                TreeNode tn = treeViewCars.GetNodeAt(e.X, e.Y);
                if(tn != null)
                {
                    System.Drawing.Point pt = treeViewCars.PointToScreen(new System.Drawing.Point(10, 0));
                    if(tn.Tag.GetType().Name == Car.ClassName)
                    {
                        frmTeamInfo.Hide();
                        frmCarInfo.ShowInfo(tn.Tag as Car, pt.X, MousePosition.Y);
                    }
                    else if(user.Type != User.USER_CAR)
                    {
                        frmCarInfo.Hide();
                        frmTeamInfo.ShowInfo(tn.Tag as Team, pt.X, MousePosition.Y);
                    }
                }
                RefreshWatching();
            }
        }
        //���س��ӡ�������ϸ��Ϣ
        private void treeViewCars_MouseLeave(object sender, EventArgs e)
        {
            frmTeamInfo.Hide();
            frmCarInfo.Hide();
        }
        private void treeViewCars_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                TreeNode item = treeViewCars.GetNodeAt(e.X, e.Y);
                if(item != null)
                {
                    treeViewCars.SelectedNode = item;
                    if(item.Tag.GetType().Name == Car.ClassName)
                    {
                        Car car = item.Tag as Car;
                        if(user.Type == User.USER_CAR)
                        {
                            contextMenuStripCars.Enabled = false;
                            toolStripMenuItemCarPoint.Enabled = true;
                            toolStripMenuItemCarNewDeclare.Enabled = true;
                            toolStripMenuItemCarDeclareHis.Enabled = true;
                            return;
                        }
                        else if(user.Type == User.USER_TEAM)
                        {
                            toolStripMenuItemCarSetStoped.Enabled = false;
                            toolStripMenuItemCarSetServiceTime.Enabled = false;
                            toolStripMenuItemCarNotify.Enabled = false;
                            toolStripMenuItemCarNewDeclare.Enabled = true;
                            toolStripMenuItemCarDeclareHis.Enabled = true;
                            toolStripMenuItemCarModify.Enabled = user.TeamList[0].PolicyModCar == 1;
                            toolStripMenuItemCarOrder.Enabled = user.TeamList[0].PolicyOrder == 1;
                            toolStripMenuItemCarDel.Enabled = user.TeamList[0].PolicyModCar == 1;
                        }
                        else
                        {
                            toolStripMenuItemCarOrder.Enabled = user.PolicyOrder == 1;
                            toolStripMenuItemCarModify.Enabled = user.PolicyModCar == 1;
                            toolStripMenuItemCarSetStoped.Enabled = user.PolicyOverTime == 1;
                            toolStripMenuItemCarSetServiceTime.Enabled = user.PolicyOverTime == 1;
                            toolStripMenuItemCarNotify.Enabled = user.PolicyNotify == 1;
                            toolStripMenuItemCarDel.Enabled = user.PolicyModCar == 1;
                            toolStripMenuItemCarNewDeclare.Enabled = true;
                            toolStripMenuItemCarDeclareHis.Enabled = true;
                            toolStripMenuItemCarDeclareList.Enabled = user.PolicyDeclare == 1;
                        }
                        if(car.Stoped == 1 &&
                            (user.Type == User.USER_TEAM || user.Type == User.USER_CAR))
                        {
                            toolStripMenuItemCarPoint.Enabled = false;
                            toolStripMenuItemCarOrder.Enabled = false;
                        }
                        else
                        {
                            toolStripMenuItemCarPoint.Enabled = true;
                            toolStripMenuItemCarOrder.Enabled = true;
                        }
                        toolStripMenuItemCarAddCar.Enabled = false;
                        contextMenuStripCars.Tag = car;
                    }
                    else
                    {
                        toolStripMenuItemCarPoint.Enabled = false;
                        toolStripMenuItemCarOrder.Enabled = false;
                        toolStripMenuItemCarSetStoped.Enabled = false;
                        toolStripMenuItemCarSetServiceTime.Enabled = false;
                        toolStripMenuItemCarNotify.Enabled = false;
                        toolStripMenuItemCarNewDeclare.Enabled = false;
                        toolStripMenuItemCarDeclareHis.Enabled = false;
                        toolStripMenuItemCarDeclareList.Enabled = false;
                        if(user.Type != User.USER_ADMIN && user.Type != User.USER_OP)
                        {
                            toolStripMenuItemCarModify.Enabled = false;
                            toolStripMenuItemCarDel.Enabled = false;
                            if(user.Type == User.USER_TEAM)
                                toolStripMenuItemCarAddCar.Enabled = user.PolicyModCar == 1;
                            else 
                                toolStripMenuItemCarAddCar.Enabled = false;
                        }
                        else
                        {
                            toolStripMenuItemCarModify.Enabled = user.PolicyModTeam == 1;
                            toolStripMenuItemCarDel.Enabled = user.PolicyModTeam == 1;
                            toolStripMenuItemCarAddCar.Enabled = user.PolicyModCar == 1;
                        }
                        contextMenuStripCars.Tag = item.Tag;
                    }
                }
                else
                {
                    toolStripMenuItemCarPoint.Enabled = false;
                    toolStripMenuItemCarOrder.Enabled = false;
                    toolStripMenuItemCarModify.Enabled = false;
                    toolStripMenuItemCarDel.Enabled = false;
                    toolStripMenuItemCarAddCar.Enabled = false;
                    toolStripMenuItemCarSetStoped.Enabled = false;
                    toolStripMenuItemCarNewDeclare.Enabled = false;
                    toolStripMenuItemCarDeclareHis.Enabled = false;
                    toolStripMenuItemCarDeclareList.Enabled = false;
                }
                toolStripMenuItemCarAddTeam.Enabled = ((user.Type == User.USER_ADMIN || user.Type == User.USER_OP) && user.PolicyModTeam == 1);//��ӳ���
            }
        }
        //��� ��ѡ�г��ӻ�����
        private void treeViewCars_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag.GetType().Name == Team.ClassName)
                foreach(TreeNode tn in e.Node.Nodes)
                    tn.Checked = e.Node.Checked;
        }
        //��λ
        private void toolStripMenuItemCarPointed_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                Car car = contextMenuStripCars.Tag as Car;
                if (Config.AutoWatchOnPoint)
                    C_Pos_Watch(car);

                   
                C_Pos_Point(car);
                
            }
        }
        //��λ����ͼ(˫���б�)
        private void treeViewCars_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag.GetType().Name == Car.ClassName)
                MoveMap(e.Node.Tag as Car);
        }
        /*
         * ���������б��Ҽ�����
         */
        //�·�ָ��
        private void toolStripMenuItemCarOrder_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                Car car = contextMenuStripCars.Tag as Car;
                CheckCarNotify(car);
                if(car.Protocol == Constant.PROTOCOL_XUNLUOSHU)
                {
                    FormPtXunLuoShu frm = new FormPtXunLuoShu(this, user.TeamList, car.CarID);
                    frm.Show();
                }
               else if(car.Protocol == Constant.PROTOCOL_TIANHE)
                {
                 //   FormPtTianHe frm = new FormPtTianHe(this, user.TeamList, car.CarID);
                //    frm.Show();
                }
            }
        }
        //�޸���Ϣ
        private void ToolStripMenuItemCarModify_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Team.ClassName)
            {
                Team temp = new Team(contextMenuStripCars.Tag as Team);
                FormTeam frm = new FormTeam(this, temp);
                frm.ShowDialog(this);
            }
            else if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                Car car = new Car(contextMenuStripCars.Tag as Car);
                FormCar frm = new FormCar(this, car);
                frm.ShowDialog(this);
            }
        }
        //�޸ķ���״̬
        private void toolStripMenuItemCarStoped_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                CheckCarNotify(contextMenuStripCars.Tag as Car);
                FormCarStoped frm = new FormCarStoped(contextMenuStripCars.Tag as Car);
                frm.ShowDialog(this);
            }
        }
        //�޸ķ���������
        private void toolStripMenuItemCarSetServiceTime_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                CheckCarNotify(contextMenuStripCars.Tag as Car);
                FormCarServiceTime frm = new FormCarServiceTime(contextMenuStripCars.Tag as Car);
                frm.ShowDialog(this);
            }
        }
        //�޸Ĳ�����ʾ
        private void toolStripMenuItemCarNotify_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                FormCarNotify frm = new FormCarNotify(contextMenuStripCars.Tag as Car);
                frm.ShowDialog(this);
            }
        }
        //ɾ��
        private void ToolStripMenuItemCarDel_Click(object sender, EventArgs e)
        {
            if(contextMenuStripCars.Tag.GetType().Name == Team.ClassName)
            {
                Team team = contextMenuStripCars.Tag as Team;
                if(MessageBox.Show(this, "ȷʵҪɾ��" + team.TeamName + "?ɾ�����ӽ�ͬʱɾ�����µ����г������䶨λ��Ϣ!!!", "����", MessageBoxButtons.OKCancel) == DialogResult.OK
                    && MessageBox.Show(this, "���ٴ�ȷ��ɾ������"+team.TeamName, "����", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    C_Info_DelTeam(team.TeamID);
                }
            }
            else if(contextMenuStripCars.Tag.GetType().Name == Car.ClassName)
            {
                Car car = contextMenuStripCars.Tag as Car;
                if(MessageBox.Show(this, "ȷʵҪɾ��" + car.CarNO + "?ɾ��������ͬʱɾ���������䶨λ��Ϣ!!!", "����", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    C_Info_DelCar(car.CarID);
                }
            }
        }
        //��ӳ���
        private void toolStripMenuItemCarAddTeam_Click(object sender, EventArgs e)
        {
            Team team = new Team();
            FormTeam frm = new FormTeam(this, team);
            frm.ShowDialog(this);
        }
        //��ӳ���
        private void toolStripMenuItemCarAddCar_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Team = contextMenuStripCars.Tag as Team;
            FormCar frm = new FormCar(this, car);
            frm.ShowDialog(this);
        }
        //��Ͷ�ߡ�����
        private void ToolStripMenuItemNewDeclare_Click(object sender, EventArgs e)
        {
            Declare dec = new Declare();
            dec.CarID = (contextMenuStripCars.Tag as Car).CarID;
            FormDeclare frm = new FormDeclare(this, dec);
            frm.ShowDialog(this);
        }
        //Ͷ�ߡ�������ʷ
        private void ToolStripMenuItemDeclareHis_Click(object sender, EventArgs e)
        {
            String para = ";;;;0;;0;;;;0;;";
            para = para.Replace(';', Constant.SPLIT1);
            C_DeclareListHis(para + (contextMenuStripCars.Tag as Car).CarID.ToString());
        }
        //����Ͷ�ߡ�����
        private void ToolStripMenuItemDeclareList_Click(object sender, EventArgs e)
        {
            C_DeclareList(contextMenuStripCars.Tag as Car);
        }
        #endregion

        #region ����б�
        private void listViewWatching_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewItem item = listViewWatching.GetItemAt(e.X, e.Y);
                bool eb = (item != null);
                toolStripMenuItemWatchingGeo.Enabled = eb;
                toolStripMenuItemWatchingShow.Enabled = eb;
                toolStripMenuItemWatchingCancel.Enabled = eb;
                if(item != null)
                    contextMenuStripWatching.Tag = item.Tag as Car;
            }
            else contextMenuStripWatching.Tag = null;
        }
        //��ȡ������Ϣ
        private void toolStripMenuItemWatchingGeo_Click(object sender, EventArgs e)
        {
            Car car = contextMenuStripWatching.Tag as Car;
            car.ItemInWatch.SubItems[8].Text = GetPosInfo(car.Pos.Lo, car.Pos.La);
        }
        //�ڵ�ͼ����ʾ
        private void toolStripMenuItemWatchingShow_Click(object sender, EventArgs e)
        {
            if(contextMenuStripWatching.Tag.GetType().Name == Car.ClassName)
                MoveMap(contextMenuStripWatching.Tag as Car);
        }
        //ȡ�����
        private void toolStripMenuItemWatchingCancel_Click(object sender, EventArgs e)
        {
            if(contextMenuStripWatching.Tag.GetType().Name == Car.ClassName)
                C_Pos_StopWatch(contextMenuStripWatching.Tag as Car);
        }
        //ȡ�����м��
        private void toolStripMenuItemWatchingCancelAll_Click(object sender, EventArgs e)
        {
            if(listViewWatching.Items.Count > 0)
                C_Pos_StopWatch();
        }
        //�ڵ�ͼ����ʾ(˫���б�)
        private void listViewPos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listViewWatching.GetItemAt(e.X, e.Y);
            if(item != null)
                MoveMap(item.Tag as Car);
        }
        //��ռ���б�
        private void ClearWatchingList()
        {
            foreach(ListViewItem item in listViewWatching.Items)
                (item.Tag as Car).ItemInWatch = null;
            listViewWatching.Items.Clear();
        }
        #endregion

        #region ����
        //
        private void expandablePanelExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            DevComponents.DotNetBar.ExpandablePanel ep = sender as DevComponents.DotNetBar.ExpandablePanel;
            if(ep.Expanded)
            {
                ep.Height = panelEx1.Height - 7 * ep.TitleHeight;
                ep.TitleStyle.BackColor2.Color = Color.Orange;
                DevComponents.DotNetBar.ExpandablePanel[] ePanels = { 
                    expandablePanelCarList, expandablePanelHisPos, expandablePanelHisAlarm, expandablePanelMileage,
                    expandablePanelRegionQuery, expandablePanelMapQuery, expandablePanelMarkPlace, expandablePanelQueryPlace 
                };
                foreach(DevComponents.DotNetBar.ExpandablePanel ep1 in ePanels)
                    if(ep != ep1)
                    {
                        ep1.Expanded = false;
                        ep1.TitleStyle.BackColor2.Color = Color.SteelBlue;
                    }
            }
            else
            {
                //ep.Height = ep.TitleHeight;
                ep.TitleStyle.BackColor2.Color = Color.SteelBlue;
            }
        }
        //��ʷ�켣��ѡ�񳵶�
        private void comboBoxExHisTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxExHisTeam.SelectedIndex >= 0)
            {
                try
                {
                    comboBoxExHisCar.Items.Clear();
                    Team team = user.TeamList[comboBoxExHisTeam.SelectedIndex];
                    foreach(Car car in team.Cars)
                        comboBoxExHisCar.Items.Add(car.CarNO + "[" + car.Driver + "]");
                    if(comboBoxExHisCar.Items.Count > 0)
                        comboBoxExHisCar.SelectedIndex = 0;
                }
                catch { }
            }
        }
        //��ʷ�켣
        private void buttonHis_Click(object sender, EventArgs e)
        {
            if(comboBoxExHisTeam.SelectedIndex >= 0 && comboBoxExHisCar.SelectedIndex >= 0)
            {
                try
                {
                    Car car = user.TeamList[comboBoxExHisTeam.SelectedIndex].Cars[comboBoxExHisCar.SelectedIndex];
                    C_Pos_HisPos(car, dateTimePickerHisTime1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePickerHisTime2.Value.ToString("yyyy-MM-dd HH:mm"));
                    hisPosList.Clear();
                    frmHisPos.RefreshList();
                    frmHisPos.RefreshInfo(car.CarNO, dateTimePickerHisTime1.Value, dateTimePickerHisTime2.Value);
                }
                catch { }
            }
            else MessageBox.Show(this, StrConst.MSG_NONE_SELECTED_CAR, StrConst.TITLE_MSG);
        }
        //��ʷ�켣�б�
        private void buttonHisPosList_Click(object sender, EventArgs e)
        {
            frmHisPos.Show();
            frmHisPos.Activate();
        }
        //��ʾ��ʷ�켣��
        private void listBoxHisPos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBoxHisPos.SelectedIndex >= 0 && listBoxHisPos.SelectedIndex < hisPosList.Count)
                MoveMap(new DPoint(hisPosList[listBoxHisPos.SelectedIndex].Lo, hisPosList[listBoxHisPos.SelectedIndex].La));
        }
        //��ʼ�켣�ط�
        private void buttonHisPosPlayStart_Click(object sender, EventArgs e)
        {
            if(hisPosList.Count <= 1)
                return;
            buttonHisPosPlayStart.Enabled = false;
            buttonHisPosPlayEnd.Enabled = true;
            hisPosListTemp = new Position[hisPosList.Count];
            hisPosList.CopyTo(hisPosListTemp, 0);
            SetFirstHisPlay();
            timerHisPlay.Enabled = true;
        }
        //ֹͣ�켣�ط�
        private void buttonHisPosPlayEnd_Click(object sender, EventArgs e)
        {
            timerHisPlay.Enabled = false;
            buttonHisPosPlayStart.Enabled = true;
            buttonHisPosPlayEnd.Enabled = false;
            ClearHisPlay();
        }
        //�켣�ط�
        private void timerHisPlay_Tick(object sender, EventArgs e)
        {
            timerHisPlay.Enabled = false;
            if(!UpdateHisPlayPos())
                timerHisPlay.Enabled = true;
            else
            {
                buttonHisPosPlayStart.Enabled = true;
                buttonHisPosPlayEnd.Enabled = false;
                ClearHisPlay();
            }
        }
        //�ط��ٶ�
        private void sliderHisPosPlay_ValueChanged(object sender, EventArgs e)
        {
            timerHisPlay.Interval = 250 / sliderHisPosPlay.Value;
        }
        //�ؼ��ֹ���
        private void comboBoxExHisAlarmKey_TextChanged(object sender, EventArgs e)
        {
            SetHisAlarmCarList();
        }
        //ȫѡ����
        private void treeViewHisAlarm_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag.GetType().Name == Team.ClassName)
                foreach(TreeNode tn in e.Node.Nodes)
                    if(tn.Checked != e.Node.Checked)
                        tn.Checked = e.Node.Checked;
        }
        //��ʷ����
        private void buttonHisAlarm_Click(object sender, EventArgs e)
        {
            StringBuilder ids = new StringBuilder();
            foreach(TreeNode node in treeViewHisAlarm.Nodes)
                foreach(TreeNode snode in node.Nodes)
                    if(snode.Checked)
                        ids.Append((snode.Tag as Car).CarID).Append(Constant.SPLIT2);
            if(ids.Length > 0)
            {
                C_Pos_HisAlarm(ids.ToString(0, ids.Length - 1), dateTimePickerAlarmTime1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePickerAlarmTime2.Value.ToString("yyyy-MM-dd HH:mm"));
                hisAlarmList.Clear();
                frmHisAlarm.RefreshList();
                frmHisAlarm.RefreshInfo(dateTimePickerAlarmTime1.Value, dateTimePickerAlarmTime2.Value);
            }
            else MessageBox.Show(this, StrConst.MSG_NONE_SELECTED_CAR, StrConst.TITLE_MSG);
        }
        //��ʷ�����б�
        private void buttonHisAlarmList_Click(object sender, EventArgs e)
        {
            frmHisAlarm.Show();
            frmHisAlarm.Activate();
        }
        //��ʾ��ʷ������
        private void listBoxHisAlarm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBoxHisAlarm.SelectedIndex >= 0)
                MoveMap(new DPoint(hisAlarmList[listBoxHisAlarm.SelectedIndex].Lo, hisAlarmList[listBoxHisAlarm.SelectedIndex].La));
        }
        //���ͳ�ƣ�ѡ�񳵶�
        private void comboBoxExMileageTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxExMileageTeam.SelectedIndex >= 0)
            {
                try
                {
                    comboBoxExMileageCar.Items.Clear();
                    Team team = user.TeamList[comboBoxExMileageTeam.SelectedIndex];
                    foreach(Car car in team.Cars)
                        comboBoxExMileageCar.Items.Add(car.CarNO + "[" + car.Driver + "]");
                    if(comboBoxExMileageCar.Items.Count > 0)
                        comboBoxExMileageCar.SelectedIndex = 0;
                }
                catch { }
            }
        }
        //���ͳ��
        private void buttonHisMileage_Click(object sender, EventArgs e)
        {
            if(comboBoxExMileageTeam.SelectedIndex >= 0 && comboBoxExMileageCar.SelectedIndex >= 0)
            {
                try
                {



                    Car car = user.TeamList[comboBoxExMileageTeam.SelectedIndex].Cars[comboBoxExMileageCar.SelectedIndex];
                    C_Pos_Mileage(car.CarID.ToString(), dateTimePickerHisMileage1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePickerHisMileage2.Value.ToString("yyyy-MM-dd HH:mm"));
               
                
                }
                catch { }
            }
            else MessageBox.Show(this, StrConst.MSG_NONE_SELECTED_CAR, StrConst.TITLE_MSG);
        }
        //��ע��ѯ
        private void buttonPlaceQuery_Click(object sender, EventArgs e)
        {
            if(comboBoxExPlaceKey.Text == "")
            {
                MessageBox.Show(this, StrConst.MSG_NONE_KEY_WORD, StrConst.TITLE_MSG);
                return;
            }
            C_Pos_PlaceQuery(comboBoxExPlaceKey.Text);
        }
        //��ʾ��ע
        private void listBoxPlaces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBoxPlaces.SelectedIndex >= 0)
                RefreshPlace(placeList[listBoxPlaces.SelectedIndex]);
        }
        //ѡȡ����
        private void buttonMarkPoint_Click(object sender, EventArgs e)
        {
            mapControl.Tools.LeftButtonTool = MapToolkit.PickPoint;
        }
        //��ע
        private void buttonMark_Click(object sender, EventArgs e)
        {
            if(textBoxMarkLo.Text == "" || textBoxMarkName.Text == "")
            {
                MessageBox.Show(this, StrConst.MSG_EMPTY_INFO, StrConst.TITLE_MSG);
                return;
            }
            C_Pos_PlaceMark(textBoxMarkName.Text, textBoxMarkLo.Text, textBoxMarkLa.Text);
        }
        //��ͼ�����ѯ
        private void buttonQueryLayer_Click(object sender, EventArgs e)
        {
            mapControl.Tools.LeftButtonTool = MapToolkit.DrawQueryRect;
            ClearRegionQuery();
            queryPtList.Clear();
            listBoxLayerPlace.Items.Clear();
        }
        //����鳵_ѡȡ����
        private void buttonRegionQuery1_Click(object sender, EventArgs e)
        {
            mapControl.Tools.LeftButtonTool = MapToolkit.DrawQueryRegion;
            ClearRegionQuery();
        }
        //����鳵_˫���б�,��ѯ��ʷ�켣
        private void listBoxRegionQuery_DoubleClick(object sender, EventArgs e)
        {
            if(listBoxRegionQuery.SelectedIndex >= 0)
            {
                Team t = regionQueryCarList.Cars[listBoxRegionQuery.SelectedIndex].Team;
                for(int i = 0; i < user.TeamList.Count; i++ )
                    if(t == user.TeamList[i])
                    {
                        comboBoxExHisTeam.SelectedIndex = i;
                        for(int j = 0; j < t.Cars.Count; j++ )
                            if(t.Cars[j] == regionQueryCarList.Cars[listBoxRegionQuery.SelectedIndex])
                            {
                                comboBoxExHisCar.SelectedIndex = j;
                                break;
                            }
                        break;
                    }
                dateTimePickerHisTime1.Value = dateTimeRegionQuery1;
                dateTimePickerHisTime2.Value = dateTimeRegionQuery2;
                expandablePanelHisPos.Expanded = true;
                buttonHis.PerformClick();
            }
        }
        //����鳵
        private void buttonRegionQuery2_Click(object sender, EventArgs e)
        {
            if(mapControl.Tools.LeftButtonTool != MapToolkit.DrawQueryRegion)//δ����ѡȡ����ģʽ
            {
                MessageBox.Show(this, StrConst.MSG_REGION_QUERY);
                return;
            }
            if(queryPtList.Count < 3)//ѡȡ��������
            {
                if(MessageBox.Show(this, StrConst.WARN_REGION_QUERY, StrConst.TITLE_WARN, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return;
                else
                {
                    ClearRegionQuery();
                    mapControl.Tools.LeftButtonTool = MapToolkit.Default;
                    return;
                }
            }
            String tid = "";
            if(comboBoxExRegionQueryTeam.SelectedIndex > 0)//����
                tid = user.TeamList[comboBoxExRegionQueryTeam.SelectedIndex - 1].TeamID.ToString();
            StringBuilder ptstb = new StringBuilder();
            foreach(DPoint dpt in queryPtList)
                ptstb.Append(dpt.x).Append(Constant.SPLIT_EX_1).Append(dpt.y).Append(Constant.SPLIT_EX_1);
            ptstb.Remove(ptstb.Length - 1, 1);
            C_Pos_Region_Query(tid, dateTimePickerRegionQuery1.Value.ToString("yyyy-MM-dd HH:mm"), dateTimePickerRegionQuery2.Value.ToString("yyyy-MM-dd HH:mm"), ptstb.ToString());
            ClearRegionQuery();
            mapControl.Tools.LeftButtonTool = MapToolkit.Default;
            
        }
        //����ѡ��
        private void listBoxLayerPlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {/*
            if(e.Button == MouseButtons.Left && listBoxLayerPlace.SelectedIndex >= 0)
            {
                SelectPlace(comboBoxLayers.Text, listBoxLayerPlace.SelectedItem as String);
            }*/
        }
        #endregion

        #region ͼ����ʾ

        private void ToolStripMenuItemMap_Click(object sender, EventArgs e)
        {
            try
            {
                watchingToolStripMenuItem.Checked = mapControl.Map.Layers["Watching"].Enabled;
                alarmToolStripMenuItem.Checked = mapControl.Map.Layers["Alarm"].Enabled;
                hisPosToolStripMenuItem.Checked = mapControl.Map.Layers["HisPos"].Enabled;
                hisLineToolStripMenuItem.Checked = mapControl.Map.Layers["HisLine"].Enabled;
                hisAlarmToolStripMenuItem.Checked = mapControl.Map.Layers["HisAlarm"].Enabled;
                placeToolStripMenuItem.Checked = mapControl.Map.Layers["Place"].Enabled;
            }
            catch { }
        }

        private void watchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["Watching"].Enabled = !mapControl.Map.Layers["Watching"].Enabled;
            mapControl.Map.Layers["Watching_L"].Enabled = mapControl.Map.Layers["Watching"].Enabled;
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["Alarm"].Enabled = !mapControl.Map.Layers["Alarm"].Enabled;
            mapControl.Map.Layers["Alarm_L"].Enabled = mapControl.Map.Layers["Alarm"].Enabled;
        }

        private void hisPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["HisPos"].Enabled = !mapControl.Map.Layers["HisPos"].Enabled;
            mapControl.Map.Layers["HisPos_L"].Enabled = mapControl.Map.Layers["HisPos"].Enabled;
        }

        private void hisLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["HisLine"].Enabled = !mapControl.Map.Layers["HisLine"].Enabled;
        }

        private void hisAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["HisAlarm"].Enabled = !mapControl.Map.Layers["HisAlarm"].Enabled;
            mapControl.Map.Layers["HisAlarm_L"].Enabled = mapControl.Map.Layers["HisAlarm"].Enabled;
        }

        private void placeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapControl.Map.Layers["Place"].Enabled = !mapControl.Map.Layers["Place"].Enabled;
            mapControl.Map.Layers["Place_L"].Enabled = mapControl.Map.Layers["Place"].Enabled;
        }
        #endregion

        #region �������� �� �����ڴ���
        //�����б�
        private void toolStripStatusLabelAlarm_Click(object sender, EventArgs e)
        {
            if(alarmList.Count > 0 && !inAlarmHandle && (user.Type == User.USER_ADMIN || user.Type == User.USER_OP) && user.PolicyAlarmList == 1)
            {
                frmAlarmList.ShowList(this);
                frmAlarmList.Activate();
            }
        }
        //��ʾ������
        void OnShowAlarmPos(AlarmPosition apos)
        {
            RefreshAlarm(apos);
        }
        //�������б�
        private void toolStripStatusLabelOverService_Click(object sender, EventArgs e)
        {
            if((user.Type == User.USER_ADMIN || user.Type == User.USER_OP) && user.PolicyOverTime == 1 && toolStripStatusLabelOverService.Text == StrConst.STATUS_HAS_OVER_TIME)
            {
                frmOverServiceList.Show();
                frmOverServiceList.Activate();
            }
        }
        //��������
        private void timerAlarmSound_Tick(object sender, EventArgs e)
        {
            if(Config.AlarmSound)
            {
                if(!inAlarmHandle)
                    PlaySound(Config.APP_PATH + Constant.FILE_SOUND_ALARM);
            }
            else timerAlarmSound.Enabled = false;
        }
        #endregion

        #region ��������
        private void alarmSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.AlarmSound = ToolStripMenuItem3AlarmSound.Checked;
        }
        private void notifySoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.NotifySound = ToolStripMenuItem3NotifySound.Checked;
        }
        private void ToolStripMenuItemSystemWarnSound_Click(object sender, EventArgs e)
        {
            Config.ServWarnSound = ToolStripMenuItemSystemWarnSound.Checked;
        }
        private void ToolStripMenuItem3ErrDownSound_Click(object sender, EventArgs e)
        {
            Config.ConnDownSound = ToolStripMenuItem3ErrDownSound.Checked;
        }
        #endregion

    }
}