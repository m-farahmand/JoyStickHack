using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.InteropServices;

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

        public static List<TJoyStickData> GetValues(SerialPort comport, ref string err)
        {
            List<TJoyStickData> lstprsn = new List<TJoyStickData>();
            int structsize = Marshal.SizeOf(typeof(TJoyStickData));
            try
            {
                string buf = "";
                while (true)
                {
                    buf = strTail + ReadString(comport);
                    if (string.IsNullOrEmpty(buf))
                        break;
                    strTail = "";
                    if (structsize / 2 >= buf.Length) continue;
                    var pbuf = Marshal.StringToBSTR(buf);
                    var prsn = (TJoyStickData) Marshal.PtrToStructure(pbuf, typeof(TJoyStickData));
                    lstprsn.Add(prsn);

                    Marshal.FreeBSTR(pbuf);
                }
            }
            catch (Exception exerr)
            {
                err = exerr.Message;
            }
            return lstprsn;
        }

        public static string strTail = "";

        public static string ReadString(SerialPort st)
        {
            string res = "";

            int i = 0;
            while (i != 10)
            {
                i = st.BaseStream.ReadByte();
                if (i == -1)
                {
                    strTail = res;
                    res = null;
                    break;
                }
                res += (char) i;
            }
            return res;
        }
    }
}