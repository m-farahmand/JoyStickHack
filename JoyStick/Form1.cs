using System;
using System.Data;
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
            cmbPort.SelectedIndex = 0;
            DataColumn col = new DataColumn();
            col.Caption = "شخص";
            tbl.Columns.Add(col);
            col = new DataColumn();
            col.Caption = "کد کارت";
            tbl.Columns.Add(col);
            col = new DataColumn();
            col.Caption = "تاریخ";
            tbl.Columns.Add(col);
            col = new DataColumn();
            col.Caption = "زمان";
            tbl.Columns.Add(col);
            /* col = new DataColumn();
             col.Caption = "کد متمایز کننده";
             tbl.Columns.Add(col);*/
            col = new DataColumn();
            col.Caption = "ثبت";
            tbl.Columns.Add(col);
            for (int i = 0; i < tbl.Columns.Count; i++)
            {
                DataColumn col2 = tbl.Columns[i];
                DataGridViewColumn colgrd = new DataGridViewColumn();
                colgrd.CellTemplate = new DataGridViewTextBoxCell();
                colgrd.HeaderText = col2.Caption;
                colgrd.Name = "col" + i;
                MyGrid.Columns.Add(colgrd);
            }
            CleanLabel();
        }

        private void CleanLabel(string txtRU = "", string txtLU = "", string txtRD = "", string txtLD = "")
        {
            if (lblLU.Text != txtLU)
                lblLU.Text = txtLU;
            if (lblLD.Text != txtLD)
                lblLD.Text = txtLD;
            if (lblRD.Text != txtRD)
                lblRD.Text = txtRD;
            if (lblRU.Text != txtRU)
                lblRU.Text = txtRU;
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
                        var title = _joyStickDataReader.CalculateData(data.Sign);
                        var caption = title + "=" + _joyStickDataReader.GetHexString(data.Code);
                        lstRaw.Items.Add(caption);
                        lstRaw.TopIndex = lstRaw.Items.Count - 1;
                        var listData = (ListBox) null;
                        switch (title)
                        {
                            case "RU":
                                listData = lstRU;
                                break;
                            case "LU":
                                listData = lstLU;
                                break;
                            case "RD":
                                listData = lstRD;
                                break;
                            case "LD":
                                listData = lstLD;
                                break;
                            case "S1":
                            case "S2":
                                listData = lstSep;
                                break;
                        }
                        if (title != "S1" || title != "S2")
                            CleanLabel(title == "RU" ? caption : "", title == "LU" ? caption : "",
                                title == "RD" ? caption : "", title == "LD" ? caption : "");

                        if (listData != null)
                        {
                            if (listData.Items.Count >0 &&
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
                case "RU": listTemp = lstRU;
                    break;
                case "LU": listTemp = lstLU;
                    break;
                case "RD": listTemp = lstRD;
                    break;
                case "LD": listTemp = lstLD;
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