using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace lab2
{
    public partial class Form1 : Form
    {
        // Значения меди
        const double rho = 8960;
        const double c = 385;     
        const double lambda = 385;

        // Параметры пластины
        double L;   
        double TL;  
        double TR;  
        double T0;


        double tau; 
        double h;   


        double[] T;     
        double[] alpha; 
        double[] beta;  

        int N;          
        double modelTime;  
        double targetTime; 
        Stopwatch realTimer;

        public Form1()
        {
            InitializeComponent();
            SetupChart();
            SetupGrid();
            SetDefaults();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "x, м";
            chart1.ChartAreas[0].AxisY.Title = "T, °C";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor =
                System.Drawing.Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor =
                System.Drawing.Color.LightGray;
        }

        private void SetupGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("tau", "Шаг по времени τ, с");
            dataGridView1.Columns.Add("h", "Шаг по х h, м");
            dataGridView1.Columns.Add("Tcenter", "T в центре, °C");
            dataGridView1.Columns.Add("realT", "Реал. время счёта, с");

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.Width = 170;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void SetDefaults()
        {
            inputL.Value = (decimal)0.1;
            inputTLeft.Value = 100;
            inputTRight.Value = -30;
            inputT0.Value = 20;

            inputTau.Value = (decimal)0.01;
            inputTau.DecimalPlaces = 4;
            inputTau.Increment = (decimal)0.001;
            inputTau.Minimum = (decimal)0.0001;
            inputTau.Maximum = (decimal)1;

            inputH.Value = (decimal)0.01;
            inputH.DecimalPlaces = 4;
            inputH.Increment = (decimal)0.001;
            inputH.Minimum = (decimal)0.0001;
            inputH.Maximum = (decimal)1;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                realTimer.Stop();
            }

            L = (double)inputL.Value;
            TL = (double)inputTLeft.Value;
            TR = (double)inputTRight.Value;
            T0 = (double)inputT0.Value;
            tau = (double)inputTau.Value;
            h = (double)inputH.Value;

            N = (int)(L / h);
            h = L / N;

            T = new double[N + 1];
            alpha = new double[N + 1];
            beta = new double[N + 1];

            for (int i = 0; i <= N; i++)
                T[i] = T0;

            T[0] = TL;
            T[N] = TR;

            modelTime = 0;
            targetTime = 2.0;

            realTimer = Stopwatch.StartNew();


            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int stepsPerTick = 50;

            for (int step = 0; step < stepsPerTick; step++)
            {
                if (modelTime >= targetTime) break;
                StepForward();
                modelTime += tau;
            }

            labCenter.Text = string.Format(
                "T в центре: {0:F4} °C   |   t = {1:F4} с",
                T[N / 2], modelTime);
            DrawHeatStrip();

            if (modelTime >= targetTime)
            {
                timer1.Stop();
                realTimer.Stop();

                DrawTemperature(string.Format(
                    "τ={0} h={1}",
                    tau.ToString("F4"),
                    h.ToString("F4")));

                double Tcenter = T[N / 2];

                double realSec = realTimer.Elapsed.TotalSeconds;

                labTime.Text = string.Format(
                    "Реальное время счёта: {0:F3} с", realSec);

                dataGridView1.Rows.Add(
                    tau.ToString("F4"),
                    h.ToString("F4"),
                    Tcenter.ToString("F4"),
                    realSec.ToString("F3")
                );
            }
        }

        private void StepForward()
        {
            double A = lambda / (h * h);
            double B = 2.0 * lambda / (h * h) + rho * c / tau;
            double C = lambda / (h * h);

            alpha[1] = 0;
            beta[1] = TL;

            for (int i = 1; i <= N - 1; i++)
            {
                double D = (rho * c / tau) * T[i];

                double denom = B - A * alpha[i];

                alpha[i + 1] = C / denom;
                beta[i + 1] = (D + A * beta[i]) / denom;
            }

            T[N] = TR;

            for (int i = N - 1; i >= 1; i--)
                T[i] = alpha[i + 1] * T[i + 1] + beta[i + 1];

            T[0] = TL;
            T[N] = TR;
        }


        private void DrawTemperature(string name)
        {
            if (chart1.Series.IndexOf(name) >= 0)
                chart1.Series.Remove(chart1.Series[name]);

            var series = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Name = name
            };

            for (int i = 0; i <= N; i++)
                series.Points.AddXY(i * h, T[i]);

            chart1.Series.Add(series);
        }

        private Color GetTemperatureColor(double temp)
        {
            double min = (double)inputT0.Value;
            double max = Math.Max((double)inputTLeft.Value, (double)inputTRight.Value);

            if (Math.Abs(max - min) < 0.01) max = min + 1;

            double ratio = (temp - min) / (max - min);
            if (ratio < 0) ratio = 0;
            if (ratio > 1) ratio = 1;

            int r = (int)Math.Max(0, 255 * (2 * ratio - 1));
            int b = (int)Math.Max(0, 255 * (1 - 2 * ratio));
            int g = 255 - r - b;

            return Color.FromArgb(r, g, b);
        }

        private void DrawHeatStrip()
        {
            if (pictureBox1 == null || pictureBox1.Width <= 0 || T == null) return;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                double stepWidth = (double)pictureBox1.Width / (N + 1);
                for (int i = 0; i <= N; i++)
                {
                    Color c = GetTemperatureColor(T[i]);
                    using (Brush brush = new SolidBrush(c))
                    {
                        g.FillRectangle(brush, (float)(i * stepWidth), 0, (float)stepWidth + 1, pictureBox1.Height);
                    }
                }
            }

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;
        }
        private void btClear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (realTimer != null) realTimer.Stop();
            chart1.Series.Clear();
            dataGridView1.Rows.Clear();
            labCenter.Text = "T в центре: —";
            labTime.Text = "Реальное время счёта: —";
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}