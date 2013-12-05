using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// Õ∂Àﬂ°¢…Í±®
    /// </summary>
    class Declare
    {
        private int declareID;
        private String referDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private String referUser = "";
        private int carID;
        private String declareContent = "";
        private String opUser = "";
        private String operation = "";
        private String fittings = "";
        private String opDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private String mechanic = "";
        private int satisfaction = 1;
        private String opinion = "";
        #region get/set
        public int DeclareID
        {
            get { return declareID; }
            set { declareID = value; }
        }
        public String ReferDate
        {
            get { return referDate; }
            set { referDate = value; }
        }
        public String ReferUser
        {
            get { return referUser; }
            set { referUser = value; }
        }
        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        public String DeclareContent
        {
            get { return declareContent; }
            set { declareContent = value; }
        }
        public String OpUser
        {
            get { return opUser; }
            set { opUser = value; }
        }
        public String Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        public String Fittings
        {
            get { return fittings; }
            set { fittings = value; }
        }
        public String OpDate
        {
            get { return opDate; }
            set { opDate = value; }
        }
        public String Mechanic
        {
            get { return mechanic; }
            set { mechanic = value; }
        }
        public int Satisfaction
        {
            get { return satisfaction; }
            set { satisfaction = value; }
        }
        public String Opinion
        {
            get { return opinion; }
            set { opinion = value; }
        }
        #endregion
        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(declareID.ToString()).Append(Constant.SPLIT2);
            stb.Append(referDate).Append(Constant.SPLIT2);
            stb.Append(referUser).Append(Constant.SPLIT2).Append(carID).Append(Constant.SPLIT2);
            stb.Append(declareContent).Append(Constant.SPLIT2).Append(opUser).Append(Constant.SPLIT2);
            stb.Append(operation).Append(Constant.SPLIT2).Append(fittings).Append(Constant.SPLIT2);
            stb.Append(opDate).Append(Constant.SPLIT2).Append(mechanic).Append(Constant.SPLIT2);
            stb.Append(satisfaction).Append(Constant.SPLIT2).Append(opinion);
            return stb.ToString();
        }

        public static Declare Parse(String s)
        {
            Declare dec = new Declare();
            String[] ss = s.Split(Constant.SPLIT2);
            dec.DeclareID = Int32.Parse(ss[0]);
            dec.ReferDate = ss[1];
            dec.ReferUser = ss[2];
            dec.CarID = Int32.Parse(ss[3]);
            dec.DeclareContent = ss[4];
            if(ss[5] != "")
            {
                dec.OpUser = ss[5];
                dec.Operation = ss[6];
                dec.Fittings = ss[7];
                dec.OpDate = ss[8];
                dec.Mechanic = ss[9];
                dec.Satisfaction = Int32.Parse(ss[10]);
                dec.Opinion = ss[11];
            }
            return dec;
        }

        public String SqlInsertStr()
        {
            StringBuilder stb = new StringBuilder("insert_declare '");
            stb.Append(ReferDate).Append("','").Append(ReferUser).Append("','");
            stb.Append(CarID).Append("','").Append(DeclareContent).Append("'");
            return stb.ToString();
        }

        public String SqlUpdateStr(int cid)
        {
            StringBuilder stb = new StringBuilder("update_declare '").Append(cid).Append("','").Append(DeclareID).Append("','");
            stb.Append(OpUser).Append("','").Append(Operation).Append("','");
            stb.Append(Fittings).Append("','").Append(Mechanic).Append("','");
            stb.Append(Satisfaction).Append("','").Append(Opinion).Append("'");
            return stb.ToString();
        }
    }
}
