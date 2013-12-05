using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    class Pub
    {
        //16*5个字符
        private static String CODE = "lfG:,3CaAb0FBcDHh4^&7]Iig2M5.TkLvW!@6mKNJ8Pjnp9[OuZosy$tUYQq{};dE#1eV%wXx*()RrSz";
        private static String hText = "0123456789ABCDEF";
        private static String[] Bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="source">原始内容</param>
        /// <returns>加密字符串</returns>
        public static String Encode(String source)
        {
            if(source == null || source == "")
                return "";
            
            Random rd = new Random();
            StringBuilder stb = new StringBuilder();
            int head = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);
            int foot = CODE.Length / 16 + (int)(rd.NextDouble() * CODE.Length / 16);

            for(int i = 0; i < head; i++)
                stb.Append(CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            for (int i = 0; i < source.Length; i++)
                stb.Append(CODE[source[i] / 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]).Append(CODE[source[i] % 16 + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            for(int i = 0; i < foot; i++)
                stb.Append(CODE[(int)(rd.NextDouble() * 16) + 16 * (int)(rd.NextDouble() * CODE.Length / 16)]);

            stb.Append(CODE[head]).Append(CODE[foot]);

            return stb.ToString();
        }
        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="source">加密字符串</param>
        /// <returns>原始内容</returns>
        public static String Decode(String source)
        {
            if(source == null || source == "")
                return "";
            String ret = "";
            StringBuilder stb = new StringBuilder();
            int head = CODE.IndexOf(source[source.Length - 2]) % 16;
            int foot = CODE.IndexOf(source[source.Length - 1]) % 16;
            source = source.Substring(head);
            source = source.Substring(0, source.Length - 2 - foot);

            for (int i = 0; i < source.Length; i += 2)
            {
                stb.Append((char)(CODE.IndexOf(source[i]) % 16 * 16 + CODE.IndexOf(source[i + 1]) % 16));
            }
            return stb.ToString();
        }
        /// <summary>
        /// 十进制 转换到 十六进制, 十六进制字符大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static String DecToHex(int num)
        {
            String hex = "";
            do
            {
                hex = hText[num % 16-1].ToString() + hex;
                num /= 16;
            }
            while(num > 16);
            return hex;
        }
        /// <summary>
        /// 十进制 转换到 十六进到,返回定长字符,十六进制字符大写
        /// </summary>
        /// <param name="num"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static String DecToHexFix(int num, int len)
        {
            String hex = DecToHex(num);
            if(hex.Length > len)
                hex = hex.Substring(hex.Length - len, len);
            else
            {
                while(hex.Length < len)
                    hex = "0" + hex;
            }
            return hex;
        }
        /// <summary>
        /// 十六进制 转换到 十进制,十六进制字符大写
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToDec(String hex)
        {
            int num = 0;
            for(int i = 1; i <= hex.Length; i++)
            {
                char ch = hex[hex.Length - i];
                int indent = hText.IndexOf(ch);
                for(int j = 1; j < i; j++)
                    indent *= 16;
                num += indent;
            }
            return num;
        }
        /// <summary>
        /// 十六进制 转换到 二进制 十六进制字符大写
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String HexToBin(String hex)
        {
            StringBuilder stb = new StringBuilder();
            for(int i = 0; i < hex.Length; i++)
                stb.Append(Bins[hText.IndexOf(hex[i])]);
            return stb.ToString();
        }
        /// <summary>
        /// 六十进制 转换 百进制, 30 = 0.5
        /// </summary>
        /// <param name="sixty"></param>
        /// <returns></returns>
        public static double SixtyToHundred(double sixty)
        {
            return sixty / 60;
        }
        /// <summary>
        /// 公里/小时 转换 节
        /// </summary>
        /// <param name="kms"></param>
        /// <returns></returns>
        public static int KmsToKts(int kms)
        {
            return (int)(kms / 1.852);
        }
        /// <summary>
        /// 节 转换到 公里/小时
        /// </summary>
        /// <param name="kts"></param>
        /// <returns></returns>
        public static int KtsToKms(int kts)
        {
            return (int)(kts * 1.852);
        }
        /// <summary>
        /// 实十六进制 转换到 十六进制字符串， 每个字节两位
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RealHexToHex(String str)
        {
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < str.Length; i++ )
            {
                bin.Append(hText[str[i] / 16]).Append(hText[str[i] % 16]);
            }
            return bin.ToString();
        }
        /// <summary>
        /// 实十六进制 转换到 十六进制字符串， 每个字节两位
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RealHexToStr(String str)
        {
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                bin.Append(hText[str[i] / 16]).Append(hText[str[i] % 16]).Append(' ');
            }
            return bin.ToString();
        }
        /// <summary>
        /// 实十六进制 转换到 十进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static long RealHexToDec(String hex)
        {
            long ret = 0;
            while(hex.Length > 0)
            {
                ret = ret * 16 + hex[1];
                hex.Remove(1, 1);
            }
            return ret;
        }
        /// <summary>
        /// 实十六进制 转换到 二进制字符串
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static String RealHexToBin(String hex)
        {
            String[] bins = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            StringBuilder bin = new StringBuilder();
            for(int i = 0; i < hex.Length; i++)
                bin.Append(bins[hex[i] / 16]).Append(bins[hex[i] % 16]);
            return bin.ToString();
        }
        /// <summary>
        /// 时间差
        /// </summary>
        /// <param name="dt1">时间1</param>
        /// <param name="dt2">时间2</param>
        /// <returns>相差的秒数</returns>
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
        /// 当前日期时间字符串
        /// </summary>
        public static String DateTimeStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 当前日期字符串
        /// </summary>
        public static String DateStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 字符到BCD数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int CharToBCD(char c)
        {
            return c / 16 * 10 + c % 16;
        }
        /// <summary>
        /// 字符串到BCD数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long StrToBCD(string s)
        {
            long m = 0;
            int x = 1;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                m = s[i] % 16 * x;
                x *= 10;
                m = s[i] / 16 * x;
                x *= 10;
            }
            return m;
        }

   
        
        /// <summary>
        /// BCD转换到字符串
        /// </summary>
        /// <param name="s">BCD字符串</param>
        /// <returns>转换后字符串</returns>
        public static String BCDToStr(String s)
        {
            StringBuilder stb = new StringBuilder();
            foreach(char c in s)
                stb.Append((char)(c / 256)).Append((char)(c % 256));
            return stb.ToString();
        }
    }
}
