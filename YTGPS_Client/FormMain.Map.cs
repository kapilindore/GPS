using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MapInfo.Data;
using MapInfo.Geometry;
using MapInfo.Mapping;
using MapInfo.Engine;
using MapInfo.Styles;

namespace YTGPS_Client
{
    public class HisPlayState
    {
        public int posIndex = 0;
        public double incX = 0;
        public double incY = 0;
        public double preX = 0;
        public double preY = 0;
        public int count = 0;
        public int index = -1;
    }

    public class MapToolkit
    {
        public static String Default = "Arrow";
        public static String Zoomin = "ZoomIn";
        public static String Zoomout = "Zoomout";
        public static String Center = "Center";
        public static String Pan = "Pan";
        public static String Distance = "AddPolyline";
        public static String DrawQueryRect = "AddPolygon";
        public static String DrawQueryRegion = "AddCircle";
        public static String DrawFenceRect = "AddEllipse";
        public static String PickPoint = "AddPoint";
        public static String GeoInfo = "AddRectangle";
    }

    public partial class FormMain : Form
    {
        private static int HIS_PLAY_MAX_MOVE_COUNT = 30;

        private List<System.Drawing.Point> disPtList = new List<System.Drawing.Point>();
        private List<DPoint> queryPtList = new List<DPoint>();

        private Table tableWatching;
        private Table tablePlace;
        private Table tableHisPos;
        private Table tableHisLine;
        private Table tableDisLine;
        private Table tableHisAlarm;
        private Table tableAlarm;
        private Table tableTemp;
        private Table tableHisPlay;
        private Table tableHisPlayLine;

        private LabelLayer labLayWatching;
        private LabelLayer labLayPlace;
        private LabelLayer labLayHisPos;
        private LabelLayer labLayHisAlarm;
        private LabelLayer labLayAlarm;
        private LabelLayer labLayHisPlayPos;

        private Position[] hisPosListTemp = null;
        private HisPlayState hisPlayState;

        private Distance initZoom = new Distance();
        private DPoint initCenter = new DPoint();

        private bool mouseDowned = false;
        private DPoint startPoint = new DPoint();
        private DPoint endPoint = new DPoint();

        private String preMap = "";
        private MapFile currentMap = null;

        //初始化地图，更换地图
        private void InitMap(MapFile mapFile)
        {
            currentMap = mapFile;
            if(preMap == mapFile.File)
                return;
            mapControl.Map.Clear();
            mapControl.Map.Load(MapInfo.Mapping.MapLoader.CreateFromFile(mapFile.File));
            mapControlOver.Map.Load(MapInfo.Mapping.MapLoader.CreateFromFile(mapFile.File));
            initZoom = mapControl.Map.Zoom;

            initCenter = mapControl.Map.Bounds.Center();
            ClearDistanceLayer();
            preMap = mapFile.File;

            comboBoxLayers.Items.Clear();
            listBoxLayerPlace.Items.Clear();
            for(int i=1; i<mapControl.Map.Layers.Count; i++)
            {
                if(mapControl.Map.Layers[i].Name != "Watching" && mapControl.Map.Layers[i].Name != "Place"
                    && mapControl.Map.Layers[i].Name != "HisPos" && mapControl.Map.Layers[i].Name != "HisLine"
                    && mapControl.Map.Layers[i].Name != "HisAlarm" && mapControl.Map.Layers[i].Name != "Alarm"
                    && mapControl.Map.Layers[i].Name != "DisLine" && mapControl.Map.Layers[i].Name != "Temp"
                    && mapControl.Map.Layers[i].Name != "HisPlayPos" && mapControl.Map.Layers[i].Name != "HisPlayLine"
                    && mapControl.Map.Layers[i].Name != "Watching_L" && mapControl.Map.Layers[i].Name != "Place_L"
                    && mapControl.Map.Layers[i].Name != "HisPos_L" && mapControl.Map.Layers[i].Name != "HisAlarm_L"
                    && mapControl.Map.Layers[i].Name != "Alarm_L" && mapControl.Map.Layers[i].Name != "HisPlayPos_L"
                    && mapControl.Map.Layers[i].Name != "Administrative")
                    comboBoxLayers.Items.Add(mapControl.Map.Layers[i].Name);
            }
            if(comboBoxLayers.Items.Count > 0)
                comboBoxLayers.SelectedIndex = 0;

            if(tableWatching == null)
            {
                //监控点图层
                TableInfo ti = TableInfoFactory.CreateTemp("Watching");
                ti.Columns.Add(ColumnFactory.CreateStringColumn("ID", 10));
                ti.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tableWatching = Session.Current.Catalog.CreateTable(ti);
                TextStyle ts = new TextStyle();
                ts.Font.Size = 8;
                ts.Font.FontWeight = FontWeight.Bold;
                ts.Font.ForeColor = Color.Green;
                labLayWatching = new LabelLayer("Watching_L", "Watching_L");
                LabelSource source = new LabelSource(tableWatching);
                source.DefaultLabelProperties.Caption = "Label";
                source.DefaultLabelProperties.Style = ts;
                source.DefaultLabelProperties.CalloutLine.Use = false;
                source.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source.DefaultLabelProperties.Layout.Offset = 10;
                source.DefaultLabelProperties.Visibility.AllowOverlap = true;
                //labLayWatching = (LabelLayer)mapControl.Map.Layers["Watching_L"];
                labLayWatching.Sources.Append(source);
                //自定义标注点图层
                TableInfo ti2 = TableInfoFactory.CreateTemp("Place");
                ti2.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tablePlace = Session.Current.Catalog.CreateTable(ti2);
                TextStyle ts2 = new TextStyle();
                ts2.Font.Size = 8;
                ts2.Font.FontWeight = FontWeight.Bold;
                ts2.Font.ForeColor = Color.Blue;
                labLayPlace = new LabelLayer("Place_L", "Place_L");
                LabelSource source2 = new LabelSource(tablePlace);
                source2.DefaultLabelProperties.Caption = "Label";
                source2.DefaultLabelProperties.Style = ts2;
                source2.DefaultLabelProperties.CalloutLine.Use = false;
                source2.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source2.DefaultLabelProperties.Layout.Offset = 10;
                source2.DefaultLabelProperties.Visibility.AllowOverlap = false;
                //labLayPlace = (LabelLayer)mapControl.Map.Layers["Place_L"];
                labLayPlace.Sources.Append(source2);
                //历史轨迹点图层
                TableInfo ti3 = TableInfoFactory.CreateTemp("HisPos");
                ti3.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tableHisPos = Session.Current.Catalog.CreateTable(ti3);
                TextStyle ts3 = new TextStyle();
                ts3.Font.Size = 8;
                ts3.Font.FontWeight = FontWeight.Bold;
                ts3.Font.ForeColor = Color.Navy;
                labLayHisPos = new LabelLayer("HisPos_L", "HisPos_L");
                LabelSource source3 = new LabelSource(tableHisPos);
                source3.DefaultLabelProperties.Caption = "Label";
                source3.DefaultLabelProperties.Style = ts3;
                source3.DefaultLabelProperties.CalloutLine.Use = false;
                source3.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source3.DefaultLabelProperties.Layout.Offset = 10;
                source3.DefaultLabelProperties.Visibility.AllowOverlap = false;
                //labLayHisPos = (LabelLayer)mapControl.Map.Layers["HisPos_L"];
                labLayHisPos.Sources.Append(source3);
                //历史轨迹线图层
                TableInfo ti4 = TableInfoFactory.CreateTemp("HisLine");
                tableHisLine = Session.Current.Catalog.CreateTable(ti4);
                //历史报警点图层
                TableInfo ti5 = TableInfoFactory.CreateTemp("HisAlarm");
                ti5.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tableHisAlarm = Session.Current.Catalog.CreateTable(ti5);
                TextStyle ts5 = new TextStyle();
                ts5.Font.Size = 8;
                ts5.Font.FontWeight = FontWeight.Bold;
                ts5.Font.ForeColor = Color.Red;
                labLayHisAlarm = new LabelLayer("HisAlarm_L", "HisAlarm_L");
                LabelSource source5 = new LabelSource(tableHisAlarm);
                source5.DefaultLabelProperties.Caption = "Label";
                source5.DefaultLabelProperties.Style = ts5;
                source5.DefaultLabelProperties.CalloutLine.Use = false;
                source5.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source5.DefaultLabelProperties.Layout.Offset = 10;
                source5.DefaultLabelProperties.Visibility.AllowOverlap = false;
                //labLayHisAlarm = (LabelLayer)mapControl.Map.Layers["HisAlarm_L"];
                labLayHisAlarm.Sources.Append(source5);
                //报警点图层
                TableInfo ti6 = TableInfoFactory.CreateTemp("Alarm");
                ti6.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tableAlarm = Session.Current.Catalog.CreateTable(ti6);
                TextStyle ts6 = new TextStyle();
                ts6.Font.Size = 8;
                ts6.Font.FontWeight = FontWeight.Bold;
                ts6.Font.ForeColor = Color.Red;
                labLayAlarm = new LabelLayer("Alarm_L", "Alarm_L");
                LabelSource source6 = new LabelSource(tableAlarm);
                source6.DefaultLabelProperties.Caption = "Label";
                source6.DefaultLabelProperties.Style = ts6;
                source6.DefaultLabelProperties.CalloutLine.Use = false;
                source6.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source6.DefaultLabelProperties.Layout.Offset = 10;
                source6.DefaultLabelProperties.Visibility.AllowOverlap = false;
                //labLayAlarm = (LabelLayer)mapControl.Map.Layers["Alarm_L"];
                labLayAlarm.Sources.Append(source6);
                //测距线图层
                TableInfo ti7 = TableInfoFactory.CreateTemp("DisLine");
                tableDisLine = Session.Current.Catalog.CreateTable(ti7);
                //临时图层
                TableInfo ti8 = TableInfoFactory.CreateTemp("Temp");
                tableTemp = Session.Current.Catalog.CreateTable(ti8);
                //轨迹回放点图层
                TableInfo ti9 = TableInfoFactory.CreateTemp("HisPlayPos");
                ti9.Columns.Add(ColumnFactory.CreateStringColumn("Label", 20));
                tableHisPlay = Session.Current.Catalog.CreateTable(ti9);
                TextStyle ts9 = new TextStyle();
                ts9.Font.Size = 8;
                ts9.Font.FontWeight = FontWeight.Bold;
                ts9.Font.ForeColor = Color.Black;
                labLayHisPlayPos = new LabelLayer("HisPlayPos_L", "HisPlayPos_L");
                LabelSource source9 = new LabelSource(tableHisPlay);
                source9.DefaultLabelProperties.Caption = "Label";
                source9.DefaultLabelProperties.Style = ts9;
                source9.DefaultLabelProperties.CalloutLine.Use = false;
                source9.DefaultLabelProperties.Layout.Alignment = MapInfo.Text.Alignment.CenterRight;
                source9.DefaultLabelProperties.Layout.Offset = 10;
                source9.DefaultLabelProperties.Visibility.AllowOverlap = false;
                labLayHisPlayPos.Sources.Append(source9);
                //轨迹回放线图层
                TableInfo ti10 = TableInfoFactory.CreateTemp("HisPlayLine");
                tableHisPlayLine = Session.Current.Catalog.CreateTable(ti10);
            }

            FeatureLayer lyr = new FeatureLayer(tableWatching);
            mapControl.Map.Layers.Insert(0, lyr);
            FeatureLayer lyr2 = new FeatureLayer(tablePlace);
            mapControl.Map.Layers.Insert(0, lyr2);

            FeatureLayer lyr3 = new FeatureLayer(tableHisPos);
            mapControl.Map.Layers.Insert(0, lyr3);
            FeatureLayer lyr4 = new FeatureLayer(tableHisLine);
            mapControl.Map.Layers.Insert(0, lyr4);

            FeatureLayer lyr5 = new FeatureLayer(tableHisAlarm);
            mapControl.Map.Layers.Insert(0, lyr5);

            FeatureLayer lyr6 = new FeatureLayer(tableAlarm);
            mapControl.Map.Layers.Insert(0, lyr6);
            FeatureLayer lyr7 = new FeatureLayer(tableDisLine);
            mapControl.Map.Layers.Insert(0, lyr7);

            FeatureLayer lyr8 = new FeatureLayer(tableTemp);
            mapControl.Map.Layers.Insert(0, lyr8);

            FeatureLayer lyr9 = new FeatureLayer(tableHisPlay);
            mapControl.Map.Layers.Insert(0, lyr9);
            FeatureLayer lyr10 = new FeatureLayer(tableHisPlayLine);
            mapControl.Map.Layers.Insert(0, lyr10);

            //标注图层
            mapControl.Map.Layers.Add(labLayWatching);
            mapControl.Map.Layers.Add(labLayPlace);
            mapControl.Map.Layers.Add(labLayHisPos);
            mapControl.Map.Layers.Add(labLayHisAlarm);
            mapControl.Map.Layers.Add(labLayAlarm);
            mapControl.Map.Layers.Add(labLayHisPlayPos);
        }
        //画面坐标转换到经纬度
        private DPoint GetCoordPt(int x, int y)
        {
            DPoint dpt = new DPoint();
            mapControl.Map.DisplayTransform.FromDisplay(new System.Drawing.Point(x, y), out dpt);
            return dpt;
        }
        //鹰眼图坐标转换到经纬度
        private DPoint GetOverviewCoordPt(int x, int y)
        {
            DPoint dpt = new DPoint();
            mapControlOver.Map.DisplayTransform.FromDisplay(new System.Drawing.Point(x, y), out dpt);
            return dpt;
        }
        //全图 
        private void FullMap()
        {
            mapControl.Map.SetView(initCenter, mapControl.Map.GetDisplayCoordSys(), initZoom);
        }
        //清屏
        private void ClearMap()
        {
            try
            {
                (tableWatching as IFeatureCollection).Clear();
                (tablePlace as IFeatureCollection).Clear();
                hisPosList.Clear();
                listBoxHisPos.Items.Clear();
                frmHisPos.RefreshList();
                (tableHisPos as IFeatureCollection).Clear();
                (tableHisLine as IFeatureCollection).Clear();
                (tableHisAlarm as IFeatureCollection).Clear();
                hisAlarmList.Clear();
                listBoxHisAlarm.Items.Clear();
                frmHisAlarm.RefreshList();
                ClearDistanceLayer();
                (tableAlarm as IFeatureCollection).Clear();
                regionQueryCarList.Cars.Clear();
                listBoxRegionQuery.Items.Clear();
                (tableTemp as IFeatureCollection).Clear();
            }
            catch { }
        }
        //清除测距
        private void ClearDistanceLayer()
        {
            if(tableDisLine != null)
            {
                try
                {
                    (tableDisLine as IFeatureCollection).Clear();
                }
                catch { }
                mapControl.Tools.LeftButtonTool = MapToolkit.Default;
                disPtList.Clear();
            }
        }
        //定位到指定经纬度
        private void MoveMap(DPoint dpt)
        {
            mapControl.Map.SetView(dpt, mapControl.Map.GetDisplayCoordSys(), mapControl.Map.Zoom);
        }
        //定位到车辆位置
        private void MoveMap(Car car)
        {
            if(car != null && car.Pos != null)
                mapControl.Map.SetView(new DPoint(car.Pos.Lo, car.Pos.La), mapControl.Map.GetDisplayCoordSys(), mapControl.Map.Zoom);
        }
        //清空临时图层
        public void ClearTempLayer()
        {
            try
            {
                queryPtList.Clear();
                (tableTemp as IFeatureCollection).Clear();
            }
            catch { }
        }
        //临时图层画矩形
        private void DrawRect(DPoint dpt1, DPoint dpt2)
        {
            if(dpt1.x == dpt2.x || dpt1.y == dpt2.y)
                return;
            Feature ftr = new Feature(tableTemp.TableInfo.Columns);
            ftr.Geometry = new MapInfo.Geometry.Rectangle(this.mapControl.Map.GetDisplayCoordSys(), new DRect(dpt1, dpt2)) as FeatureGeometry;
            ftr.Style = new AreaStyle(new SimpleLineStyle(new LineWidth(), 1), new SimpleInterior(16, Color.Red, Color.DarkRed, true));
            tableTemp.InsertFeature(ftr);
            tableTemp.Refresh();
        }
        //查询所在区域
        private String FindMapInRegion(double x, double y, String tableName, String colName)
        {
            String ret = "";
            try
            {
                MapInfo.Data.MIConnection connection = new MapInfo.Data.MIConnection();
                connection.Open();
                MapInfo.Data.MICommand command = connection.CreateCommand();
                command.CommandText = "Select * from " + tableName + " where MI_Point(@x, @y, @cs) within obj";
                command.Parameters.Add("@x", x);
                command.Parameters.Add("@y", y);
                command.Parameters.Add("@cs", this.mapControl.Map.GetDisplayCoordSys());
                command.Prepare();
                MapInfo.Data.IResultSetFeatureCollection irfc = command.ExecuteFeatureCollection();
                if(irfc.Count > 0)
                    ret = irfc[0][colName].ToString();
                command.Dispose();
                connection.Close();
            }
            catch { }
            return ret;
            /*
            Feature ftr1 = new Feature(tableTemp.TableInfo.Columns);
            ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(113.70, 23.04)) as FeatureGeometry;
            MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWithinFeature(ftr1, ContainsType.Geometry);
            si.QueryDefinition.Columns = null;
            MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search("chinagl_guide", si);
            if(irfc.Count > 0)
                MessageBox.Show(irfc[0]["Name"].ToString());
            else MessageBox.Show("null");*/
        }
        //查询附近地物
        private String FindMapNearInfo(double x, double y, String tableName, String colName, int meter)
        {
            String ret = "";
            try
            {
                MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchNearest(new DPoint(x, y), mapControl.Map.GetDisplayCoordSys(), new Distance(meter, DistanceUnit.Meter));
                si.QueryDefinition.Columns = null;
                (si.SearchResultProcessor as ClosestSearchResultProcessor).Options = ClosestSearchOptions.StopAtFirstMatch;
                MapInfo.Data.IResultSetFeatureCollection irfc = MapInfo.Engine.Session.Current.Catalog.Search(tableName, si);
                if(irfc.Count > 0)
                    ret = irfc[0][colName].ToString();
                irfc.Close();
            }
            catch { }
            return ret;
        }
        private String GetPosInfo(double x, double y)
        {
            if(currentMap == null || currentMap.GeoInfoList.Count == 0)
                return "";
            StringBuilder stb = new StringBuilder();
            foreach(GeoInfoLayer gl in currentMap.GeoInfoList)
            {
                String s = "";
                if(gl.Type == GeoInfoLayer.REGION_LAYER)
                    s = FindMapInRegion(x, y, gl.TableName, gl.ColName);
                else s = FindMapNearInfo(x, y, gl.TableName, gl.ColName, gl.Distance);
                if(s != "")
                    stb.Append(gl.Head).Append(s).Append(gl.Foot).Append(",");
            }
            if(stb.Length == 0)
                stb.Append(StrConst.MSG_NONE_GEO_INFO);
            return stb.Remove(stb.Length - 1, 1).ToString();
        }
        //查询矩形区域内的地物
        private List<String> GetPlacesInRect(DPoint dpt1, DPoint dpt2, String lName)
        {
            List<String> list = new List<string>();
            try
            {
                MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWithinRect(new DRect(dpt1, dpt2), mapControl.Map.GetDisplayCoordSys(), ContainsType.Centroid);
                si.QueryDefinition.Columns = new string[] { "*" };	
                IResultSetFeatureCollection fc = MapInfo.Engine.Session.Current.Catalog.Search(Session.Current.Catalog.GetTable(lName), si);
                foreach(Feature ftr in fc)
                    list.Add(ftr["Name"].ToString());
            }
            catch { }
            return list;
        }
        //高亮指定地点
        private void SelectPlace(String tName, String sName)
        {
            SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere("Name = '" + sName + "'");
            IResultSetFeatureCollection ifs = MapInfo.Engine.Session.Current.Catalog.Search(tName, si);
            if(ifs.Count == 1)
            {
                mapControl.Map.SetView(ifs.Envelope);
                mapControl.Map.Scale = mapControl.Map.Scale * 2;
                //缩放到选择图元范围
                //高亮显示
                MapInfo.Engine.Session.Current.Selections.DefaultSelection.Clear();
                MapInfo.Engine.Session.Current.Selections.DefaultSelection.Add(ifs);
            }
            ifs.Close();
        }
        //刷新监控车辆信息
        private void RefreshWatching(Car car)
        {
            if(car != null && car.Pos != null)
            {
                //删除原信息点
                try
                {
                    MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere("ID='" + car.CarID.ToString() + "'");
                    si.QueryDefinition.Columns = new string[] { "*" };
                    MapInfo.Data.Feature ftr = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(tableWatching, si);
                    if(ftr != null)
                        tableWatching.DeleteFeature(ftr);
                    //添加新信息点
                    Feature ftr1 = new Feature(tableWatching.TableInfo.Columns);
                    ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(car.Pos.Lo, car.Pos.La)) as FeatureGeometry;
                    //ftr1.Style = new SimpleVectorPointStyle(46, Color.Green, 16);
                    if(car.Pos.AlarmHandle != 0)
                        ftr1.Style = new MapInfo.Styles.BitmapPointStyle("red_" + car.Pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Green, 16);
                    else if(car.Pos.Pointed == 0)
                        ftr1.Style = new MapInfo.Styles.BitmapPointStyle("yellow_" + car.Pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Green, 16);
                    else ftr1.Style = new MapInfo.Styles.BitmapPointStyle("green_" + car.Pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Red, 16);
                    ftr1["ID"] = car.CarID.ToString();
                    ftr1["Label"] = car.CarNO + " [" + car.Pos.Speed.ToString() + "km/h]";
                    tableWatching.InsertFeature(ftr1);
                    tableWatching.Refresh();
                }
                catch { }
            }
        }
        //取消监控
        private void RemoveWatching(Car car)
        {
            //删除信息点
            try
            {
                try
                {
                    listViewWatching.Items.Remove(car.ItemInWatch);
                }
                catch { }
                car.ItemInWatch = null;
                car.IsWatched = false;
                if(car.ItemInList != null)
                {
                    car.ItemInList.Checked = false;
                    if(car.ItemInList.ForeColor == COLOR_CAR_IN_WATCH)
                        car.ItemInList.ForeColor = COLOR_CAR_NORMAL;
                }
                MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere("ID='" + car.CarID.ToString() + "'");
                si.QueryDefinition.Columns = new string[] { "*" };
                MapInfo.Data.Feature ftr = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(tableWatching, si);
                if(ftr != null)
                    tableWatching.DeleteFeature(ftr);
            }
            catch { }
        }
        //取消监控
        private void RemoveWatching(Team team)
        {
            //删除所有信息点
            try
            {
                StringBuilder stb = new StringBuilder("1<>0");
                foreach(Car car in team.Cars)
                {
                    stb.Append(" or ID='").Append(car.CarID).Append("'");
                    try
                    {
                        listViewWatching.Items.Remove(car.ItemInWatch);
                    }
                    catch { }
                    car.ItemInWatch = null;
                    car.IsWatched = false;
                    if(car.ItemInList != null)
                    {
                        car.ItemInList.Checked = false;
                        if(car.ItemInList.ForeColor == COLOR_CAR_IN_WATCH)
                            car.ItemInList.ForeColor = COLOR_CAR_NORMAL;
                    }
                }
                MapInfo.Data.SearchInfo si = MapInfo.Data.SearchInfoFactory.SearchWhere(stb.ToString());
                si.QueryDefinition.Columns = new string[] { "*" };
                MapInfo.Data.Feature ftr = MapInfo.Engine.Session.Current.Catalog.SearchForFeature(tableWatching, si);
                if(ftr != null)
                    tableWatching.DeleteFeature(ftr);
            }
            catch { }
        }
        //全部取消监控
        private void RemoveWatching()
        {
            //删除所有信息点
            try
            {
                foreach(ListViewItem item in listViewWatching.Items)
                {
                    Car car = item.Tag as Car;
                    try
                    {
                        listViewWatching.Items.Remove(car.ItemInWatch);
                    }
                    catch { }
                    car.IsWatched = false;
                    car.ItemInWatch = null;
                    if(car.ItemInList != null)
                    {
                        car.ItemInList.Checked = false;
                        if(car.ItemInList.ForeColor == COLOR_CAR_IN_WATCH)
                            car.ItemInList.ForeColor = COLOR_CAR_NORMAL;
                    }
                }
                (tableWatching as IFeatureCollection).Clear();
            }
            catch { }
        }
        //刷新测距显示
        private void RefreshDistance()
        {
            if(disPtList.Count > 1)
            {
                try
                {
                    DPoint[] dpt = {
                    GetCoordPt(disPtList[disPtList.Count - 1].X, disPtList[disPtList.Count - 1].Y),
                    GetCoordPt(disPtList[disPtList.Count - 2].X, disPtList[disPtList.Count - 2].Y)};
                    Feature ftr = new Feature(tableDisLine.TableInfo.Columns);
                    MapInfo.Styles.SimpleLineStyle ss = new SimpleLineStyle(new LineWidth(1, LineWidthUnit.Pixel), 2);
                    ftr.Geometry = new MapInfo.Geometry.MultiCurve(mapControl.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dpt);
                    ftr.Style = ss;
                    tableDisLine.InsertFeature(ftr);
                    tableDisLine.Refresh();
                }
                catch { }
            }
        }
        //清除测距显示
        private void ClearDistance()
        {
            try
            {
                (tableDisLine as IFeatureCollection).Clear();
            }
            catch { }
            disPtList.Clear();
        }
        //刷新区域查车显示
        private void RefreshRegionQuery()
        {
            if(queryPtList.Count > 1)
            {
                try
                {
                    DPoint[] dpt = { queryPtList[queryPtList.Count - 1], queryPtList[queryPtList.Count - 2]};
                    Feature ftr = new Feature(tableTemp.TableInfo.Columns);
                    MapInfo.Styles.SimpleLineStyle ss = new SimpleLineStyle(new LineWidth(1, LineWidthUnit.Pixel), 2);
                    ftr.Geometry = new MapInfo.Geometry.MultiCurve(mapControl.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dpt);
                    ftr.Style = ss;
                    tableTemp.InsertFeature(ftr);
                    tableTemp.Refresh();
                }
                catch { }
            }
        }
        //清除区域查车显示
        private void ClearRegionQuery()
        {
            try
            {
                (tableTemp as IFeatureCollection).Clear();
            }
            catch { }
            queryPtList.Clear();
        }
        //删除历史轨迹
        private void ClearHisPosLayer()
        {
            try
            {
                (tableHisPos as IFeatureCollection).Clear();
                (tableHisLine as IFeatureCollection).Clear();
            }
            catch { }
        }
        //刷新历史轨迹
        private void RefreshHisPos()
        {
            try
            {
                int index = 0;
                double minx = hisPosList[0].Lo, miny = hisPosList[0].La, maxx = hisPosList[0].Lo, maxy = hisPosList[0].La;
                foreach(Position pos in hisPosList)
                {
                    Feature ftr2 = new Feature(tableHisPos.TableInfo.Columns);
                    ftr2.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(pos.Lo, pos.La)) as FeatureGeometry;
                    if(pos.AlarmHandle != 0)
                        ftr2.Style = new MapInfo.Styles.BitmapPointStyle("red_" + pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Red, 16);
                    else if(pos.Pointed == 0)
                        ftr2.Style = new MapInfo.Styles.BitmapPointStyle("yellow_" + pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Yellow, 16);
                    else ftr2.Style = new MapInfo.Styles.BitmapPointStyle("green_" + pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Green, 16);
                    ftr2["Label"] = pos.GpsTime + "," + pos.Speed.ToString() + "km/h";
                    tableHisPos.InsertFeature(ftr2);
                    if(index < hisPosList.Count - 1)
                    {
                        DPoint[] dpt = {
                    new DPoint(pos.Lo, pos.La),
                    new DPoint(hisPosList[index + 1].Lo, hisPosList[index + 1].La)};
                        Feature ftr3 = new Feature(tableHisLine.TableInfo.Columns);
                        ftr3.Geometry = new MapInfo.Geometry.MultiCurve(mapControl.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dpt);
                        ftr3.Style = new SimpleLineStyle(new LineWidth(1, LineWidthUnit.Pixel), 54);
                        tableHisLine.InsertFeature(ftr3);
                    }
                    if(pos.Lo > maxx)
                        maxx = pos.Lo;
                    else if(pos.Lo < minx)
                        minx = pos.Lo;
                    if(pos.La > maxy)
                        maxy = pos.La;
                    else if(pos.La < miny)
                        miny = pos.La;
                    index++;
                }
                tableHisPos.Refresh();
                tableHisLine.Refresh();
                if(hisPosList.Count > 1)
                    mapControl.Map.SetView(new DRect(minx, miny, maxx, maxy), mapControl.Map.GetDisplayCoordSys());
                else MoveMap(new DPoint(minx, miny));
            }
            catch { }
        }
        //历史轨迹回放－插入位置点
        private void SetFirstHisPlay()
        {
            try
            {
                mapControl.Map.Layers["HisPos"].Enabled = false;
                mapControl.Map.Layers["HisPos_L"].Enabled = false;
                mapControl.Map.Layers["HisLine"].Enabled = false;
                hisPlayState = new HisPlayState();
                UpdateHisPlayLine();
                //MoveMap(new DPoint(hisPosListTemp[0].Lo, hisPosListTemp[0].La));
            }
            catch { }
        }
        //停止轨迹回放
        private void ClearHisPlay()
        {
            try
            {
                (tableHisPlay as IFeatureCollection).Clear();
                (tableHisPlayLine as IFeatureCollection).Clear();
                mapControl.Map.Layers["HisPos"].Enabled = true;
                mapControl.Map.Layers["HisPos_L"].Enabled = true;
                mapControl.Map.Layers["HisLine"].Enabled = true;
            }
            catch { }
        }
        //刷新轨迹回放
        private bool UpdateHisPlayPos()
        {
            hisPlayState.posIndex ++;
            if(hisPlayState.posIndex == hisPlayState.count)
            {
                return UpdateHisPlayLine();
            }
            else
            {
                DrawHisPlayPos();
                return false;
            }
        }

        private bool UpdateHisPlayLine()
        {
            hisPlayState.index++;
            if(hisPlayState.index >= hisPosListTemp.Length - 1)
            {
                return true;
            }
            hisPlayState.preX = hisPosListTemp[hisPlayState.index].Lo - hisPlayState.incX;
            hisPlayState.preY = hisPosListTemp[hisPlayState.index].La - hisPlayState.incY;
            double moveX = Math.Abs(mapControl.Map.Bounds.x1 - mapControl.Map.Bounds.x2) / HIS_PLAY_MAX_MOVE_COUNT,
                moveY = Math.Abs(mapControl.Map.Bounds.y1 - mapControl.Map.Bounds.y2) / HIS_PLAY_MAX_MOVE_COUNT,
                lengthX = Math.Abs(hisPosListTemp[hisPlayState.index].Lo - hisPosListTemp[hisPlayState.index + 1].Lo),
                lengthY = Math.Abs(hisPosListTemp[hisPlayState.index].La - hisPosListTemp[hisPlayState.index + 1].La);
            hisPlayState.posIndex = 0;
            if(lengthX >= lengthY)
                hisPlayState.count = (int)(lengthX / moveX) + 1;
            else hisPlayState.count = (int)(lengthY / moveY) + 1;
            hisPlayState.incX = (hisPosListTemp[hisPlayState.index].Lo < hisPosListTemp[hisPlayState.index + 1].Lo) ? lengthX / hisPlayState.count : 0 - lengthX / hisPlayState.count;
            hisPlayState.incY = (hisPosListTemp[hisPlayState.index].La < hisPosListTemp[hisPlayState.index + 1].La) ? lengthY / hisPlayState.count : 0 - lengthY / hisPlayState.count;
            DrawHisPlayPos();
            return false;
        }

        private void DrawHisPlayPos()
        {
            try
            {
                Position pos = hisPosListTemp[hisPlayState.index];
                if(hisPlayState.posIndex == 0)
                {
                    (tableHisPlay as IFeatureCollection).Clear();
                    Feature ftr1 = new Feature(tableHisPlay.TableInfo.Columns);
                    ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(pos.Lo, pos.La)) as FeatureGeometry;
                    String dir = "0";
                    if(hisPlayState.incX >= 0 && hisPlayState.incY >= 0)
                        dir = "1";
                    else if(hisPlayState.incX >= 0 && hisPlayState.incY <= 0)
                        dir = "3";
                    else if(hisPlayState.incX <= 0 && hisPlayState.incY <= 0)
                        dir = "5";
                    else if(hisPlayState.incX <= 0 && hisPlayState.incY >= 0)
                        dir = "7";
                    if(pos.AlarmHandle != 0)
                        ftr1.Style = new MapInfo.Styles.BitmapPointStyle("red_" + dir + ".bmp", BitmapStyles.NativeSize, Color.Red, 16);
                    else if(pos.Pointed == 0)
                        ftr1.Style = new MapInfo.Styles.BitmapPointStyle("yellow_" + dir + ".bmp", BitmapStyles.NativeSize, Color.Yellow, 16);
                    else ftr1.Style = new MapInfo.Styles.BitmapPointStyle("green_" + dir + ".bmp", BitmapStyles.NativeSize, Color.Green, 16);
                    //if(pos.Lo > mapControl.Map.Bounds.x2 - hisPlayState.incX || pos.Lo < mapControl.Map.Bounds.x1 - hisPlayState.incX
                    //|| pos.La > mapControl.Map.Bounds.y2 - hisPlayState.incY || pos.La < mapControl.Map.Bounds.y1 - hisPlayState.incY)
                    MoveMap(new DPoint(pos.Lo, pos.La));
                    ftr1["Label"] = pos.GpsTime + "," +  pos.Speed + "km/h";
                    tableHisPlay.InsertFeature(ftr1);
                    tableHisPlay.Refresh();
                    if(hisPlayState.index != 0)//轨迹线
                    {
                        DPoint[] dpt = {
                            new DPoint(hisPlayState.preX, hisPlayState.preY),
                            new DPoint(pos.Lo, pos.La)};
                        Feature ftr2 = new Feature(tableHisLine.TableInfo.Columns);
                        ftr2.Geometry = new MapInfo.Geometry.MultiCurve(mapControl.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dpt);
                        ftr2.Style = new SimpleLineStyle(new LineWidth(1, LineWidthUnit.Pixel), 54);
                        tableHisPlayLine.InsertFeature(ftr2);
                        tableHisPlayLine.Refresh();
                    }
                }
                else
                {
                    tableHisPlay.BeginAccess(MapInfo.Data.TableAccessMode.Write);
                    foreach(Feature ftr1 in tableHisPlay)
                    {
                        ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(pos.Lo + hisPlayState.posIndex * hisPlayState.incX, pos.La + hisPlayState.posIndex * hisPlayState.incY)) as FeatureGeometry;
                        //ftr1.Geometry.GetGeometryEditor().OffsetByXY(hisPlayState.incX, hisPlayState.incY, MapInfo.Geometry.DistanceUnit.Degree, MapInfo.Geometry.DistanceType.Spherical);
                        ftr1.Geometry.EditingComplete();
                        ftr1.Update();
                    }
                    tableHisPlay.EndAccess();
                    tableHisPlay.Refresh();
                    //轨迹线
                    DPoint[] dpt = {
                    new DPoint(pos.Lo + hisPlayState.posIndex * hisPlayState.incX - hisPlayState.incX, pos.La + hisPlayState.posIndex * hisPlayState.incY - hisPlayState.incY),
                    new DPoint(pos.Lo + hisPlayState.posIndex * hisPlayState.incX, pos.La + hisPlayState.posIndex * hisPlayState.incY)};
                    Feature ftr2 = new Feature(tableHisLine.TableInfo.Columns);
                    ftr2.Geometry = new MapInfo.Geometry.MultiCurve(mapControl.Map.GetDisplayCoordSys(), MapInfo.Geometry.CurveSegmentType.Linear, dpt);
                    ftr2.Style = new SimpleLineStyle(new LineWidth(1, LineWidthUnit.Pixel), 54);
                    tableHisPlayLine.InsertFeature(ftr2);
                    tableHisPlayLine.Refresh();
                    //if(pos.Lo + hisPlayState.posIndex * hisPlayState.incX > mapControl.Map.Bounds.x2 - hisPlayState.incX || pos.Lo + hisPlayState.posIndex * hisPlayState.incX < mapControl.Map.Bounds.x1 - hisPlayState.incX
                    //|| pos.La + hisPlayState.posIndex * hisPlayState.incY > mapControl.Map.Bounds.y2 - hisPlayState.incY || pos.La < mapControl.Map.Bounds.y1 + hisPlayState.posIndex * hisPlayState.incY - hisPlayState.incY)
                    MoveMap(new DPoint(pos.Lo + hisPlayState.posIndex * hisPlayState.incX, pos.La + hisPlayState.posIndex * hisPlayState.incY));
                }
            }
            catch { }
        }
        //删除历史报警
        private void ClearHisAlarmLayer()
        {
            try
            {
                (tableHisAlarm as IFeatureCollection).Clear();
            }
            catch { }
        }
        //刷新历史报警
        private void RefreshHisAlarm()
        {
            ClearHisAlarmLayer();
            try
            {
                int index = 0;
                double minx = hisAlarmList[0].Lo, miny = hisAlarmList[0].La, maxx = hisAlarmList[0].Lo, maxy = hisAlarmList[0].La;
                foreach(HisAlarmPosition pos in hisAlarmList)
                {
                    Feature ftr1 = new Feature(tableHisAlarm.TableInfo.Columns);
                    ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(pos.Lo, pos.La)) as FeatureGeometry;
                    ftr1.Style = new MapInfo.Styles.BitmapPointStyle("red_" + pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Red, 16);
                    ftr1["Label"] = pos.Car.CarNO + " [" + pos.GpsTime + "][" + pos.Alarm + "]";
                    tableHisAlarm.InsertFeature(ftr1);
                    if(pos.Lo > maxx)
                        maxx = pos.Lo;
                    else if(pos.Lo < minx)
                        minx = pos.Lo;
                    if(pos.La > maxy)
                        maxy = pos.La;
                    else if(pos.La < miny)
                        miny = pos.La;
                    index++;
                }
                tableHisAlarm.Refresh();
                if(hisAlarmList.Count > 1)
                    mapControl.Map.SetView(new DRect(minx, miny, maxx, maxy), mapControl.Map.GetDisplayCoordSys());
                else MoveMap(new DPoint(minx, miny));
            }
            catch { }
        }
        //删除自定义标注
        private void ClearPlaceLayer()
        {
            try
            {
                (tablePlace as IFeatureCollection).Clear();
            }
            catch { }
        }
        //刷新自定义标注
        private void RefreshPlace(Place place)
        {
            ClearPlaceLayer();
            try
            {
                Feature ftr1 = new Feature(tablePlace.TableInfo.Columns);
                ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(place.Lo, place.La)) as FeatureGeometry;
                ftr1.Style = new SimpleVectorPointStyle(46, Color.Blue, 16);
                ftr1["Label"] = place.Name;
                tablePlace.InsertFeature(ftr1);
                tableHisAlarm.Refresh();
                MoveMap(new DPoint(place.Lo, place.La));
            }
            catch { }
        }
        //删除报警
        private void ClearAlarmLayer()
        {
            try
            {
                (tableAlarm as IFeatureCollection).Clear();
            }
            catch { }
        }
        //刷新报警点
        private void RefreshAlarm(AlarmPosition pos)
        {
            ClearAlarmLayer();
            try
            {
                Feature ftr1 = new Feature(tableAlarm.TableInfo.Columns);
                ftr1.Geometry = new MapInfo.Geometry.Point(mapControl.Map.GetDisplayCoordSys(), new DPoint(pos.Lo, pos.La)) as FeatureGeometry;
                ftr1.Style = new MapInfo.Styles.BitmapPointStyle("red_" + pos.Direction.ToString() + ".bmp", BitmapStyles.NativeSize, Color.Red, 16);
                ftr1["Label"] = pos.Car.CarNO + " [" + pos.GpsTime + "][" + pos.Alarm + "]";
                tableAlarm.InsertFeature(ftr1);
                tableAlarm.Refresh();
                MoveMap(new DPoint(pos.Lo, pos.La));
            }
            catch { }
        }
    }
}