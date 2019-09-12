using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace JoyStick
{
    public partial class Form1 : Form
    {
        string GetValue = "", DBStr = "";
        bool ValueCompleted = false;
        bool SendStop = false;
        DataTable tbl = new DataTable();

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
        }


        private void OpenCom()
        {
            try
            {
                serialPort1.Close();
                serialPort1.BaudRate = 5300;
                serialPort1.DataBits = 7;
                serialPort1.PortName = cmbPort.Text;
                serialPort1.Open();
                serialPort1.DtrEnable = true;

                serialPort1.RtsEnable = true;

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

        private void LoadUserList()
        {
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
            var getinfo = true;
            var i = 0;
            LoadUserList();
            var err = "";
            while (true)
            {
                var isportnamechanged = false;

                Invoke(new MethodInvoker(delegate { isportnamechanged = serialPort1.PortName != cmbPort.Text; }));
                if (!serialPort1.IsOpen || isportnamechanged)
                {
                    Invoke(new MethodInvoker(OpenCom));
                    getinfo = true;
                }
                if (serialPort1.IsOpen)
                {
                    var data = JoyStickDataReader.GetValues(serialPort1, ref err);

                    Invoke(new MethodInvoker(delegate
                    {
                        listBox1.Items.Add(data.Code + "==" + data.Direction);
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }));
                }
                i++;
                //
                if (i > 60)
                    i = 0;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            End();
            Application.ExitThread();
        }
    }
}