namespace lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inputL = new System.Windows.Forms.NumericUpDown();
            this.inputTLeft = new System.Windows.Forms.NumericUpDown();
            this.inputTRight = new System.Windows.Forms.NumericUpDown();
            this.inputT0 = new System.Windows.Forms.NumericUpDown();
            this.inputTau = new System.Windows.Forms.NumericUpDown();
            this.inputH = new System.Windows.Forms.NumericUpDown();
            this.btStart = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.labCenter = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputT0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(220, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(650, 380);
            this.chart1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(220, 400);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(650, 160);
            this.dataGridView1.TabIndex = 1;
            // 
            // inputL
            // 
            this.inputL.DecimalPlaces = 3;
            this.inputL.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.inputL.Location = new System.Drawing.Point(12, 38);
            this.inputL.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inputL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.inputL.Name = "inputL";
            this.inputL.Size = new System.Drawing.Size(100, 22);
            this.inputL.TabIndex = 3;
            this.inputL.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // inputTLeft
            // 
            this.inputTLeft.Location = new System.Drawing.Point(12, 93);
            this.inputTLeft.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.inputTLeft.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.inputTLeft.Name = "inputTLeft";
            this.inputTLeft.Size = new System.Drawing.Size(100, 22);
            this.inputTLeft.TabIndex = 5;
            // 
            // inputTRight
            // 
            this.inputTRight.Location = new System.Drawing.Point(12, 148);
            this.inputTRight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.inputTRight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.inputTRight.Name = "inputTRight";
            this.inputTRight.Size = new System.Drawing.Size(100, 22);
            this.inputTRight.TabIndex = 7;
            // 
            // inputT0
            // 
            this.inputT0.Location = new System.Drawing.Point(12, 203);
            this.inputT0.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.inputT0.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.inputT0.Name = "inputT0";
            this.inputT0.Size = new System.Drawing.Size(100, 22);
            this.inputT0.TabIndex = 9;
            // 
            // inputTau
            // 
            this.inputTau.Location = new System.Drawing.Point(12, 258);
            this.inputTau.Name = "inputTau";
            this.inputTau.Size = new System.Drawing.Size(100, 22);
            this.inputTau.TabIndex = 11;
            // 
            // inputH
            // 
            this.inputH.Location = new System.Drawing.Point(12, 313);
            this.inputH.Name = "inputH";
            this.inputH.Size = new System.Drawing.Size(100, 22);
            this.inputH.TabIndex = 13;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 355);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 30);
            this.btStart.TabIndex = 14;
            this.btStart.Text = "Запуск";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(12, 395);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(100, 30);
            this.btClear.TabIndex = 15;
            this.btClear.Text = "Очистить";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // labCenter
            // 
            this.labCenter.Location = new System.Drawing.Point(12, 440);
            this.labCenter.Name = "labCenter";
            this.labCenter.Size = new System.Drawing.Size(200, 20);
            this.labCenter.TabIndex = 16;
            this.labCenter.Text = "T в центре: —";
            // 
            // labTime
            // 
            this.labTime.Location = new System.Drawing.Point(12, 465);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(200, 20);
            this.labTime.TabIndex = 17;
            this.labTime.Text = "Реальное время счёта: —";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Толщина L (м):";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тем-ра слева Tл (°C):";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тем-ра справа Tп (°C):";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Нач. температура T0 (°C):";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Шаг по времени τ (с):";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Шаг по простр. h (м):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(653, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 77);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(890, 580);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputTLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputTRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputT0);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputTau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputH);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.labCenter);
            this.Controls.Add(this.labTime);
            this.Name = "Form1";
            this.Text = "Теплопроводность — Алюминий";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputT0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown inputL;
        private System.Windows.Forms.NumericUpDown inputTLeft;
        private System.Windows.Forms.NumericUpDown inputTRight;
        private System.Windows.Forms.NumericUpDown inputT0;
        private System.Windows.Forms.NumericUpDown inputTau;
        private System.Windows.Forms.NumericUpDown inputH;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label labCenter;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}