using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        static BigInteger M = BigInteger.Pow(2, 63);
        static BigInteger Beta = BigInteger.Pow(2, 32) + 3;
        static BigInteger X = DateTime.Now.Ticks;

        static double NextDouble()
        {
            X = (Beta * X) % M;
            return (double)X / (double)M;
        }

        static double GenerateExponential(double lambda)
        {
            double alpha = NextDouble();
            if (alpha == 0) alpha = 1e-15;  // защита от Log(0)
            return -Math.Log(alpha) / lambda;
        }

        // Хранит результаты последнего моделирования
        private double[] empiricalFreq;   
        private double[] theoreticalFreq;
        private int maxK;
        private double lambdaT; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            int N = (int)numN.Value;  
            double T = (double)numT.Value;          // Длина интервала наблюдения (сек)
            double lam = (double)numLambda.Value;   // Интенсивность потока (запросов/сек)
            lambdaT = lam * T;                      // Параметр Пуассона: ожидаемое число событий за T

            var counts = new int[N];

            for (int n = 0; n < N; n++)
            {
                double t = 0;   
                int cnt = 0; 
                while (true)
                {
                    // интервал между событиями ~ Exp(λ)
                    double interval = GenerateExponential(lam);
                    t += interval;
                    if (t > T) break;
                    cnt++;
                }
                counts[n] = cnt;
            }

            // Вычисление среднего: M[X] = (1/N) * Σxᵢ
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += counts[i];
            }
            double mean = sum / N;

            // Вычисление дисперсии: D[X] = (1/N) * Σ(xᵢ - M[X])²
            double sumSquaredDiff = 0;
            for (int i = 0; i < N; i++)
            {
                double diff = counts[i] - mean;
                sumSquaredDiff += diff * diff;
            }
            double variance = sumSquaredDiff / N;

            // Вывод статистик 
            lblMeanVal.Text = mean.ToString("F4");
            lblVarianceVal.Text = variance.ToString("F4");
            lblMeanTheorVal.Text = lambdaT.ToString("F4");
            lblVarianceTheorVal.Text = lambdaT.ToString("F4");

            // Эмпирическое распределение 
            maxK = counts.Max();
            empiricalFreq = new double[maxK + 1];
            theoreticalFreq = new double[maxK + 1];

            foreach (int c in counts)
                empiricalFreq[c]++;

            for (int k = 0; k <= maxK; k++)
                empiricalFreq[k] /= N;

            //  Теоретическое (Пуассон): P(X=k) = e^{-λT}·(λT)^k / k!
            double logLambdaT = Math.Log(lambdaT);
            for (int k = 0; k <= maxK; k++)
                theoreticalFreq[k] = Math.Exp(-lambdaT + k * logLambdaT - LogFactorial(k));

            FillTable();

            panelChart.Invalidate();

 
            GenerateConclusion(mean, variance, lam, T, N);
        }

        // Вычисление ln(k!) 
        private double LogFactorial(int k)
        {
            double s = 0;
            for (int i = 2; i <= k; i++) s += Math.Log(i);
            return s;
        }

        private void FillTable()
        {
            dgvDistribution.Rows.Clear();
            for (int k = 0; k <= maxK; k++)
            {
                double emp = empiricalFreq[k];
                double th = theoreticalFreq[k];
                if (emp < 1e-6 && th < 1e-6) continue;    // пропускаем почти нулевые

                int idx = dgvDistribution.Rows.Add(k, emp.ToString("F6"), th.ToString("F6"));
                // Подсветим строки с заметным расхождением
                double diff = Math.Abs(emp - th);
                if (diff > 0.01)
                    dgvDistribution.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240);
            }
        }

        // Отрисовка гистограммы 
        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (empiricalFreq == null || empiricalFreq.Length == 0) return;

            int W = panelChart.Width;
            int H = panelChart.Height;
            int marginL = 60, marginR = 20, marginT = 20, marginB = 50;

            int chartW = W - marginL - marginR;
            int chartH = H - marginT - marginB;

            double maxVal = Math.Max(empiricalFreq.Max(), theoreticalFreq.Max()) * 1.1;

            // Оси
            var axisPen = new Pen(Color.FromArgb(60, 60, 60), 2);
            g.DrawLine(axisPen, marginL, marginT, marginL, marginT + chartH);          // Y
            g.DrawLine(axisPen, marginL, marginT + chartH, W - marginR, marginT + chartH); // X

            var tickFont = new Font("Segoe UI", 7.5f);
            var labelFont = new Font("Segoe UI", 8.5f, FontStyle.Bold);

            // Метки Y
            int yTicks = 5;
            for (int i = 0; i <= yTicks; i++)
            {
                double val = maxVal * i / yTicks;
                int y = marginT + chartH - (int)(chartH * val / maxVal);
                g.DrawLine(Pens.LightGray, marginL + 1, y, W - marginR, y);
                g.DrawString(val.ToString("F3"), tickFont, Brushes.Gray,
                    marginL - 50, y - 7);
            }

            // Название осей
            g.DrawString("P(X=k)", labelFont, Brushes.Black, 2, marginT + chartH / 2 - 20,
                new StringFormat { FormatFlags = StringFormatFlags.DirectionVertical });
            g.DrawString("k (число запросов за T)", labelFont, Brushes.Black,
                marginL + chartW / 2 - 80, H - 18);

            // Столбцы
            int barCount = maxK + 1;
            double slotW = (double)chartW / barCount;
            double barW = slotW * 0.35;

            var brushEmp = new SolidBrush(Color.FromArgb(0, 120, 215));
            var brushTheor = new SolidBrush(Color.FromArgb(0, 180, 100));

            for (int k = 0; k < barCount; k++)
            {
                double slotX = marginL + k * slotW;

                // Эмпирический столбец
                int hEmp = (int)(chartH * empiricalFreq[k] / maxVal);
                int xEmp = (int)(slotX + slotW * 0.05);
                g.FillRectangle(brushEmp, xEmp, marginT + chartH - hEmp, (int)barW, hEmp);

                // Теоретический столбец
                int hTheor = (int)(chartH * theoreticalFreq[k] / maxVal);
                int xTh = (int)(slotX + slotW * 0.50);
                g.FillRectangle(brushTheor, xTh, marginT + chartH - hTheor, (int)barW, hTheor);

                // Метка k
                if (barCount <= 40 || k % 2 == 0)
                    g.DrawString(k.ToString(), tickFont, Brushes.Gray,
                        (float)(slotX + slotW / 2 - 4), marginT + chartH + 5);
            }

            // Легенда
            int lx = W - marginR - 250, ly = marginT + 5;
            g.FillRectangle(brushEmp, lx, ly, 14, 14);
            g.DrawString("Эмпирическое", tickFont, Brushes.Black, lx + 18, ly);
            g.FillRectangle(brushTheor, lx, ly + 18, 14, 14);
            g.DrawString("Теоретическое (Пуассон)", tickFont, Brushes.Black, lx + 18, ly + 18);
        }

        // Генерация текстового вывода 
        private void GenerateConclusion(double mean, double variance, double lam, double T, int N)
        {
            double theorMean = lam * T;
            double theorVar = lam * T;
            double diffMean = Math.Abs(mean - theorMean) / theorMean * 100;
            double diffVar = Math.Abs(variance - theorVar) / theorVar * 100;

            lblConclusion.ForeColor = Color.FromArgb(30, 30, 60);
            lblConclusion.Text =
                $"Параметры: λ={lam}, T={T}, N={N}\n\n" +
                $"Теоретическое M[X] = λ·T = {theorMean:F4}\n" +
                $"Эмпирическое  M[X] = {mean:F4}\n" +
                $"Расхождение: {diffMean:F2}%\n\n" +
                $"Теоретическое D[X] = λ·T = {theorVar:F4}\n" +
                $"Эмпирическое  D[X] = {variance:F4}\n" +
                $"Расхождение: {diffVar:F2}%\n\n";
        }
    }
}