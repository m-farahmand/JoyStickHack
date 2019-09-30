using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace JoyStick
{
    public partial class Form1 : Form
    {
        string GetValue = "", DBStr = "";
        bool ValueCompleted = false;
        bool SendStop = false;
        DataTable tbl = new DataTable();
        private JoyStickDataReader _joyStickDataReader;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            cmbPort.SelectedIndex = 4;
            CleanLabel();
        }

        private void CleanLabel(string caption = "", DataItem dataItem = null)
        {
            if (caption != "")
                lblRD.BackColor = lblLD.BackColor = lblLU.BackColor = lblRU.BackColor = Color.Transparent;
            Label temp = null;
            if (dataItem == null || dataItem.Sign == Sign.Lp)
                temp = lblRU;
            if (dataItem == null || dataItem.Sign == Sign.Ln)
                temp = lblLD;
            if (dataItem == null || dataItem.Sign == Sign.Rn)
                temp = lblRD;
            if (dataItem == null || dataItem.Sign == Sign.Rp)
                temp = lblLU;
            if (temp == null)
                return;
            temp.Text = caption;
            temp.BackColor = Color.LimeGreen;
        }

        private void OpenCom()
        {
            try
            {
                serialPort1.Close();
                serialPort1.BaudRate = 5300;
                serialPort1.DataBits = 7;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.PortName = cmbPort.Text;
                serialPort1.Open();
                settext(lblError, string.Format("ارتباط با {0} برقرار شد.", cmbPort.Text));
            }
            catch (Exception err)
            {
                settext(lblError, err.Message);
            }
        }

        private void settext(Control ctl, string str)
        {
            Invoke(new MethodInvoker(delegate() { ctl.Text = str; }));
        }

        private void CloseCom()
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = cmbPort.Text;
                serialPort1.Close();
                settext(lblError, string.Format("ارتباط با {0} قطع شد.", cmbPort.Text));
            }
            catch (Exception err)
            {
                settext(lblError, err.Message);
            }
        }

        private void InitThread()
        {
            _joyStickDataReader = new JoyStickDataReader();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStart_Click(sender, EventArgs.Empty);
        }

        Thread thr = null;

        private void btnStart_Click(object sender, EventArgs e)
        {
            thr = new Thread(new ThreadStart(Start));
            thr.Start();
            btnEnd.Enabled = true;
            btnStart.Enabled = false;
        }

        private void Start()
        {
            InitThread();
            var err = "";
            while (true)
            {
                var isportnamechanged = false;

                Invoke(new MethodInvoker(delegate { isportnamechanged = serialPort1.PortName != cmbPort.Text; }));
                if (!serialPort1.IsOpen || isportnamechanged)
                {
                    Invoke(new MethodInvoker(OpenCom));
                }
                if (serialPort1.IsOpen)
                {
                    var data = JoyStickDataReader.GetValues(serialPort1, ref err);
                    if (string.IsNullOrEmpty(data.Sign)) continue;
                    Invoke(new MethodInvoker(delegate
                    {
                        var dataItem = _joyStickDataReader.CalculateData(data.Sign);
                        if (dataItem == null)
                            return;
                        var caption = dataItem.Title + "=" +
                                      _joyStickDataReader.GetHexString(data.SpeedHighSide, dataItem) + ":" +
                                      _joyStickDataReader.GetHexString(data.SpeedLowSide, dataItem);

                        lstRaw.Items.Add(caption);
                        lstRaw.TopIndex = lstRaw.Items.Count - 1;
                        var listData = (ListBox) null;
                        switch (dataItem.Sign)
                        {
                            case Sign.Ln:
                                listData = lstLD;
                                break;
                            case Sign.Lp:
                                listData = lstRU;
                                break;
                            case Sign.Rn:
                                listData = lstRD;
                                break;
                            case Sign.Rp:
                                listData = lstLU;
                                break;
                            case Sign.Separator:
                                listData = lstSep;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        if (dataItem.Sign != Sign.Separator)
                        {
                            CleanLabel(caption, dataItem);
                            var speed = JoyStickDataReader.ClampToSbyte(_joyStickDataReader.GetSpeed(
                                            _joyStickDataReader.GetIntString(data.SpeedHighSide + data.SpeedLowSide,
                                                dataItem)), dataItem.Sign == Sign.Rp | dataItem.Sign == Sign.Lp);

                            (dataItem.Sign == Sign.Ln | dataItem.Sign == Sign.Lp ? lblSpeedL : lblSpeedR).Text = speed.ToString();
                        }

                        if (listData != null)
                        {
                            if (listData.Items.Count > 0 &&
                                (string) listData.Items[listData.Items.Count - 1] == caption) return;
                            listData.Items.Add(caption);
                            listData.TopIndex = listData.Items.Count - 1;
                        }
                        else
                        {
                            listData = null;
                        }
                    }));
                }
                Thread.Sleep(1);
            }
        }

        private void End()
        {
            if (thr != null)
                thr.Abort();
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
            CloseCom();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            End();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            var err = "";
            foreach (var item in lstRaw.Items)
                JoyStickDataReader.WriteLog(item.ToString() + "\r\n", true, ref err);
            lstRaw.Items.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstRaw.Items.Clear();
        }

        private void list_Click(object sender, EventArgs e)
        {
            ListBox listTemp = null;
            switch ((sender as Button).Tag)
            {
                case "RU":
                    listTemp = lstRU;
                    break;
                case "LU":
                    listTemp = lstLU;
                    break;
                case "RD":
                    listTemp = lstRD;
                    break;
                case "LD":
                    listTemp = lstLD;
                    break;
            }
            listTemp.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            End();
            Application.ExitThread();
        }
    }
}