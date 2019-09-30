namespace JoyStick
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblError = new System.Windows.Forms.Label();
            this.lblRD = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.lblLU = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.lblRU = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.lstRaw = new System.Windows.Forms.ListBox();
            this.MyGrid = new System.Windows.Forms.DataGridView();
            this.lstRU = new System.Windows.Forms.ListBox();
            this.lstLU = new System.Windows.Forms.ListBox();
            this.lstRD = new System.Windows.Forms.ListBox();
            this.lstLD = new System.Windows.Forms.ListBox();
            this.lstSep = new System.Windows.Forms.ListBox();
            this.lblSpeedR = new System.Windows.Forms.Label();
            this.lblSpeedL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff;
            this.serialPort1.ReadTimeout = 50;
            this.serialPort1.WriteTimeout = 50;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lblRD);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSaveLog);
            this.panel1.Controls.Add(this.lblLU);
            this.panel1.Controls.Add(this.btnEnd);
            this.panel1.Controls.Add(this.lblRU);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.cmbPort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 110);
            this.panel1.TabIndex = 0;
            // 
            // lblLD
            // 
            this.lblLD.AutoSize = true;
            this.lblLD.Location = new System.Drawing.Point(988, 90);
            this.lblLD.Name = "lblLD";
            this.lblLD.Size = new System.Drawing.Size(42, 13);
            this.lblLD.TabIndex = 12;
            this.lblLD.Text = "no text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 878F));
            this.tableLayoutPanel1.Controls.Add(this.lblError, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSpeedR, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSpeedL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(738, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(363, 65);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Location = new System.Drawing.Point(-624, 42);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(872, 20);
            this.lblError.TabIndex = 1;
            // 
            // lblRD
            // 
            this.lblRD.AutoSize = true;
            this.lblRD.Location = new System.Drawing.Point(735, 90);
            this.lblRD.Name = "lblRD";
            this.lblRD.Size = new System.Drawing.Size(42, 13);
            this.lblRD.TabIndex = 12;
            this.lblRD.Text = "no text";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(939, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 23);
            this.button4.TabIndex = 9;
            this.button4.Tag = "LD";
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.list_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(685, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 9;
            this.button3.Tag = "RD";
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.list_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(425, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 23);
            this.button2.TabIndex = 9;
            this.button2.Tag = "LU";
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.list_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(153, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 9;
            this.button1.Tag = "RU";
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.list_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(67, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(42, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLog.Location = new System.Drawing.Point(3, 80);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(58, 23);
            this.btnSaveLog.TabIndex = 9;
            this.btnSaveLog.Text = "SaveLog";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // lblLU
            // 
            this.lblLU.AutoSize = true;
            this.lblLU.Location = new System.Drawing.Point(509, 90);
            this.lblLU.Name = "lblLU";
            this.lblLU.Size = new System.Drawing.Size(42, 13);
            this.lblLU.TabIndex = 12;
            this.lblLU.Text = "no text";
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(1205, 34);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(42, 23);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lblRU
            // 
            this.lblRU.AutoSize = true;
            this.lblRU.Location = new System.Drawing.Point(236, 90);
            this.lblRU.Name = "lblRU";
            this.lblRU.Size = new System.Drawing.Size(42, 13);
            this.lblRU.TabIndex = 12;
            this.lblRU.Text = "no text";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1205, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(42, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPort.DisplayMember = "COM5";
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPort.Location = new System.Drawing.Point(1148, 8);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(51, 21);
            this.cmbPort.TabIndex = 7;
            // 
            // lstRaw
            // 
            this.lstRaw.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstRaw.FormattingEnabled = true;
            this.lstRaw.Location = new System.Drawing.Point(0, 110);
            this.lstRaw.Name = "lstRaw";
            this.lstRaw.Size = new System.Drawing.Size(154, 289);
            this.lstRaw.TabIndex = 1;
            // 
            // MyGrid
            // 
            this.MyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyGrid.Location = new System.Drawing.Point(0, 0);
            this.MyGrid.Name = "MyGrid";
            this.MyGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MyGrid.Size = new System.Drawing.Size(1252, 399);
            this.MyGrid.TabIndex = 3;
            // 
            // lstRU
            // 
            this.lstRU.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstRU.FormattingEnabled = true;
            this.lstRU.Location = new System.Drawing.Point(154, 110);
            this.lstRU.Name = "lstRU";
            this.lstRU.Size = new System.Drawing.Size(274, 289);
            this.lstRU.TabIndex = 4;
            // 
            // lstLU
            // 
            this.lstLU.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLU.FormattingEnabled = true;
            this.lstLU.Location = new System.Drawing.Point(428, 110);
            this.lstLU.Name = "lstLU";
            this.lstLU.Size = new System.Drawing.Size(267, 289);
            this.lstLU.TabIndex = 5;
            // 
            // lstRD
            // 
            this.lstRD.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstRD.FormattingEnabled = true;
            this.lstRD.Location = new System.Drawing.Point(695, 110);
            this.lstRD.Name = "lstRD";
            this.lstRD.Size = new System.Drawing.Size(254, 289);
            this.lstRD.TabIndex = 6;
            // 
            // lstLD
            // 
            this.lstLD.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLD.FormattingEnabled = true;
            this.lstLD.Location = new System.Drawing.Point(949, 110);
            this.lstLD.Name = "lstLD";
            this.lstLD.Size = new System.Drawing.Size(250, 289);
            this.lstLD.TabIndex = 7;
            // 
            // lstSep
            // 
            this.lstSep.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSep.FormattingEnabled = true;
            this.lstSep.Location = new System.Drawing.Point(1199, 110);
            this.lstSep.Name = "lstSep";
            this.lstSep.Size = new System.Drawing.Size(182, 289);
            this.lstSep.TabIndex = 8;
            // 
            // lblSpeedR
            // 
            this.lblSpeedR.AutoSize = true;
            this.lblSpeedR.Location = new System.Drawing.Point(213, 22);
            this.lblSpeedR.Name = "lblSpeedR";
            this.lblSpeedR.Size = new System.Drawing.Size(35, 13);
            this.lblSpeedR.TabIndex = 2;
            this.lblSpeedR.Text = "label1";
            // 
            // lblSpeedL
            // 
            this.lblSpeedL.AutoSize = true;
            this.lblSpeedL.Location = new System.Drawing.Point(213, 3);
            this.lblSpeedL.Name = "lblSpeedL";
            this.lblSpeedL.Size = new System.Drawing.Size(35, 13);
            this.lblSpeedL.TabIndex = 2;
            this.lblSpeedL.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "موتور راست";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "موتور چپ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "وضعیت پورت";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 399);
            this.Controls.Add(this.lstSep);
            this.Controls.Add(this.lstLD);
            this.Controls.Add(this.lstRD);
            this.Controls.Add(this.lstLU);
            this.Controls.Add(this.lstRU);
            this.Controls.Add(this.lstRaw);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MyGrid);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "Form1";
            this.Text = "راروس";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ListBox lstRaw;
        private System.Windows.Forms.DataGridView MyGrid;
        private System.Windows.Forms.ListBox lstRU;
        private System.Windows.Forms.ListBox lstLU;
        private System.Windows.Forms.ListBox lstRD;
        private System.Windows.Forms.ListBox lstLD;
        private System.Windows.Forms.ListBox lstSep;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblLD;
        private System.Windows.Forms.Label lblRD;
        private System.Windows.Forms.Label lblLU;
        private System.Windows.Forms.Label lblRU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSpeedR;
        private System.Windows.Forms.Label lblSpeedL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

