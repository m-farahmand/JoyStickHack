﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace JoyStick
{
    /*5A 5B 1B = Left Down(LD) yellow 
5A 5B 13 = Right Down(RD) green

5A 5B 5B = Right Up(RU) red 
5A 5B 53 = Left Up(LU) blue

1A 5B 5A = Seperator
1A 5B 52 = Seperator*/

        
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct TJoyStickData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)] public string Sign;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)] public string Code;
    }

    public class DataItem
    {
        public string Title { get; set; }
        public byte[] Value { get; set; }
    }

    public class DataMap
    {
        public byte From { get; set; }
        public byte To { get; set; }
    }
    public class JoyStickDataReader
    {
        public DataItem[] List { get; set; }
        public  DataMap[] MapList{ get; set; }
        public JoyStickDataReader()
        {
            InitDataStructure();
        }

        public void InitDataStructure()
        {
            List = new[]
            {
                new DataItem {Title = "LU", Value = new byte[] {0x5a, 0x5b, 0x53}},
                new DataItem {Title = "RU", Value = new byte[] {0x5a, 0x5b, 0x5b}},
                new DataItem {Title = "LD", Value = new byte[] {0x5a, 0x5b, 0x1b}},
                new DataItem {Title = "RD", Value = new byte[] {0x5a, 0x5b, 0x13}},
                new DataItem {Title = "S1", Value = new byte[] {0x1a, 0x5b, 0x5a}},
                new DataItem {Title = "S2", Value = new byte[] {0x1a, 0x5b, 0x52}},
            };
            MapList = new[]
            {
                new DataMap{From = 0x12,To=0x1},new DataMap{From = 0x52,To=0x2},new DataMap{From = 0x1a,To=0x3},new DataMap{From = 0x5a,To=0x4},
                new DataMap{From = 0x13,To=0x8},new DataMap{From = 0x53,To=0xA},new DataMap{From = 0x1B,To=0xB},new DataMap{From = 0x5B,To=0xC},
            };
        }

        public string CalculateData(string data)
        {
            var res = "";
            foreach (var dataItem in List)
            {
                if (IsContain(data, dataItem.Value))
                    res = dataItem.Title;
            }
            return res;
        }

        public string GetHexString(string data)
        {
            var bytes = Encoding.Default.GetBytes(data);
            for (var i = 0; i < bytes.Length; i++)
            {
               var mapItem= MapList.SingleOrDefault(x => x.From == bytes[i]);
                if (mapItem != null)
                    bytes[i] = mapItem.To;
            }
            return BitConverter.ToString(bytes);
        }

         public static string StringToBinary(string data)
        {
            var sb = new StringBuilder();

            foreach (var c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
                sb.Append('-');
            }
            return sb.ToString();
        }

        public static bool IsContain(string data, byte[] substr)
        {
            return data.StartsWith(Encoding.ASCII.GetString(substr));
        }

        public static int Cnv_ToInt(string stritm)
        {
            int i = -1;
            try
            {
                i = Convert.ToInt16(stritm);
            }
            catch
            {
            }
            return i;
        }

        public static long Cnv_ToLong(string stritm)
        {
            long i = -1;
            try
            {
                i = Convert.ToInt64(stritm);
            }
            catch
            {
            }
            return i;
        }

        string strtail = "";

        public static TJoyStickData GetValues(SerialPort comport, ref string err)
        {
            var code = new TJoyStickData();
            int structsize = Marshal.SizeOf(typeof(TJoyStickData));
            try
            {
                var buf = ReadString(comport);
                if (buf.Length < structsize / 2 || string.IsNullOrEmpty(buf)) return code;
                var pbuf = Marshal.StringToBSTR(buf);
                code = (TJoyStickData) Marshal.PtrToStructure(pbuf, typeof(TJoyStickData));
                Marshal.FreeBSTR(pbuf);
            }
            catch (Exception exerr)
            {
                err = exerr.Message;
            }
            return code;
        }

        public static string strTail = "";

        public static string ReadString(SerialPort st)
        {
            string res = "";

            int i = 0;
            while (true)
            {
                i = st.BaseStream.ReadByte();
                if (i == 0)
                    break;
                res += (char) i;
            }
            return res;
        }

        public static void WriteLog(string str, bool append , ref string err)
        {
            try
            {
                string apppath = Application.ExecutablePath;
                DateTime dt = DateTime.Now;
                string logaddr = Path.GetDirectoryName(apppath) + "\\" + Path.GetFileName(apppath) + "_" +
                                 dt.ToString("yyyy-mm-dd") + "_Log.txt";
                StreamWriter sw = new StreamWriter(logaddr, append);
                sw.Write(str);
                sw.Flush();
                sw.Close();
                err = "";
            }
            catch (Exception exerr)
            {
                err = "خطا در لاگ اطلاعات: " + exerr.Message;
            }
        }
    }
}