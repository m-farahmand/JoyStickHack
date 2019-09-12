using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JoyStick
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct TJoyStickData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)] public string Direction;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)] public string Code;
    }

    public class JoyStickDataReader
    {
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
    }
}