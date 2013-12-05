using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
//using Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace YTGPS_Client
{
    class Pub
    {
        //16*5���ַ�
        private static String CODE = "AaBbl0FfGg2:,3CcDHh4^&7]IiJjKkLM5.!@6mNn89[OoPpsTvWyZYQq{};#1dEe$tUuV%wXx*()RrSz";
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="source">ԭʼ����</param>
        /// <returns>�����ַ���</returns>
        public static String encode(String source)
        {
            if (source == null)
                return "";
            
            Random rd = new Random();
            String ret = "";
            int head = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);
            int foot = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);

            for (int i = 0; i < head; i++)
                ret = ret + CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)];

            for (int i = 0; i < source.Length; i++)
                ret = ret + CODE[source[i] / 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)] + CODE[source[i] % 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)];

            for (int i = 0; i < foot; i++)
                ret = ret + CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)];

            ret = ret + CODE[head];
            ret = ret + CODE[foot];

            return ret;
        }
        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="source">�����ַ���</param>
        /// <returns>ԭʼ����</returns>
        public static String decode(String source)
        {
            if (source == null)
                return "";
            String ret = "";
            int head = CODE.IndexOf(source[source.Length - 2]) % 16;
            int foot = CODE.IndexOf(source[source.Length - 1]) % 16;
            source = source.Substring(head);
            source = source.Substring(0, source.Length - 2 - foot);

            for (int i = 0; i < source.Length; i += 2)
            {
                ret = ret + (char)(CODE.IndexOf(source[i]) % 16 * 16 + CODE.IndexOf(source[i + 1]) % 16);
            }
            return ret;
        }

       
        
        
        
        
        
        /// <summary>
        /// ������Excel
        /// </summary>
        /// <param name="dt">�������ݵ�Datetable</param>
        /// <param name="fileName">���浽���ļ�</param>
        public static void ExportExcel(System.Data.DataTable dt, String fileName)
        {
            bool fileSaved = false;
            try
            {
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);

                for(int i = 0; i < dt.Columns.Count; i++)
                {
                    strLine = strLine + dt.Columns[i].ColumnName.ToString() + Convert.ToChar(9);
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    for(int j = 0; j < dt.Columns.Count; j++)
                    {
                        strLine = strLine + dt.Rows[i][j].ToString() + Convert.ToChar(9);
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                fileSaved = true;
            }
            catch { }
            if(fileSaved && File.Exists(fileName))
            {
                System.Diagnostics.Process.Start(fileName); //��EXCEL
            }
            else
            {
                MessageBox.Show("�����ļ�ʧ��!");
            }

        }
        /// <summary>
        /// ִ���ⲿ����
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="name">�ļ���</param>
        /// <param name="para">����</param>
        /// <returns></returns>
        public static bool Execute(String path, String name, String para)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.WorkingDirectory = path;
            info.FileName = name;
            info.Arguments = para;
            try
            {
                System.Diagnostics.Process.Start(info);
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ʱ���
        /// </summary>
        /// <param name="dt1">ʱ��1</param>
        /// <param name="dt2">ʱ��2</param>
        /// <returns>��������</returns>
        public static long DateDiff(DateTime dt1, DateTime dt2)
        {
            if(dt2.CompareTo(dt1) < 0)
                return -1;
            else
            {
                TimeSpan ts = dt2 - dt1;
                long n = ts.Days * 24 * 3600;
                n += ts.Hours * 3600;
                n += ts.Minutes * 60;
                n += ts.Seconds;
                return n;
            }
        }
        /// <summary>
        /// ������ ת���� ʮ������ ʮ�������ַ���д
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static String BinToHex(String bin)
        {
            String hexs = "0123456789ABCDEF";
            String[] bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            while(bin.Length % 4 > 0)
                bin = "0" + bin;
            String hex = "";
            for(int i = 0; i < bin.Length - 3; i+=4)
            {
                for(int j = 0; j < 16; j++)
                    if(bins[j] == bin.Substring(i, 4))
                        hex += hexs[j];
            }
            return hex;
        }
        /// <summary>
        /// ʮ������ ת���� ������ ʮ�������ַ���д
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String HexToBin(String hex)
        {
            String[] bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            String bin = "";
            for(int i = 0; i < hex.Length; i++)
            {
                char ch = hex[i];
                int indent = (ch >= 'A') ? (ch - 'A' + 10) : (ch - '0');
                bin = bin + bins[indent];
            }
            return bin;
        }
        /// <summary>
        /// ��ǰ����ʱ���ַ���
        /// </summary>
        public static String DateTimeStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// ��ǰ�����ַ���
        /// </summary>
        public static String DateStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        ///  �������� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress_NumInput(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.KeyChar = (char)0;
        }
        /// <summary>
        /// ����/Сʱ ת�� ��
        /// </summary>
        /// <param name="kms"></param>
        /// <returns></returns>
        public static int KmsToKts(int kms)
        {
            return (int)(kms / 1.852);
        }
        /// <summary>
        /// �� ת���� ����/Сʱ
        /// </summary>
        /// <param name="kts"></param>
        /// <returns></returns>
        public static int KtsToKms(int kts)
        {
            return (int)(kts * 1.852);
        }

        [DllImport("user32 ")]
        /// <summary> 
        /// ϵͳ���� �� ע����Windows��½ 
        /// </summary> 
        public static extern bool LockWorkStation(); //ϵͳ���� 
    }
}
