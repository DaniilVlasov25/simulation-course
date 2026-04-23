using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6_2
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

        // Генерация стандартной нормальной СВ (метод Бокса-Мюллера)
        static double GenerateNormalStandard()
        {
            double u1 = NextDouble();
            double u2 = NextDouble();

            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            return z;
        }

        // Генерация нормальной СВ с параметрами a (среднее) и sigma (стандартное отклонение)
        static double GenerateNormal(double a, double sigma)
        {
            return a + sigma * GenerateNormalStandard();
        }

        List<double> samples;

        public Form1()
        {
            InitializeComponent();
            samples = new List<double>();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                double mean = double.Parse(txtMean.Text);
                double variance = double.Parse(txtVariance.Text);
                int n = int.Parse(txtSampleSize.Text);

                double sigma = Math.Sqrt(variance);
                samples.Clear();

                // Генерируем выборку
                for (int i = 0; i < n; i++)
                {
                    samples.Add(GenerateNormal(mean, sigma));
                }

                // Статистическая обработка
                ProcessStatistics(mean, variance, n);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ProcessStatistics(double theoreticalMean, double theoreticalVariance, int n)
        {
            double empiricalMean = samples.Average();
            double empiricalVariance = samples.Average(x => Math.Pow(x - empiricalMean, 2));

            double meanError = Math.Abs(empiricalMean - theoreticalMean);
            double meanRelativeError = theoreticalMean != 0 ?
                (meanError / Math.Abs(theoreticalMean)) * 100 : 0;

            double varianceError = Math.Abs(empiricalVariance - theoreticalVariance);
            double varianceRelativeError = theoreticalVariance != 0 ?
                (varianceError / Math.Abs(theoreticalVariance)) * 100 : 0;

            // Строим гистограмму и считаем χ²
            int numIntervals = 7; // Количество интервалов
            double chiSquared = BuildHistogramAndChiSquared(theoreticalMean,
                Math.Sqrt(theoreticalVariance), n, numIntervals);

            // === НОВОЕ: Критическое значение χ² ===
            int degreesOfFreedom = numIntervals - 1; // m - 1
            double chiSquaredCritical = GetChiSquaredCritical(degreesOfFreedom);
            bool hypothesisRejected = chiSquared > chiSquaredCritical;

            // Вывод результатов
            lblResults.Text = $"Среднее (теор.): {theoreticalMean:F3}\n" +
                             $"Среднее (эмп.): {empiricalMean:F3}\n" +
                             $"Погрешность: {(theoreticalMean != 0 ? meanRelativeError.ToString("F1") + "%" : "N/A (mean=0)")}\n\n" +
                             $"Дисперсия (теор.): {theoreticalVariance:F3}\n" +
                             $"Дисперсия (эмп.): {empiricalVariance:F3}\n" +
                             $"Погрешность: {varianceRelativeError:F1}%\n\n" +
                             $"χ² = {chiSquared:F2}\n" +
                             $"χ² критическое = {chiSquaredCritical:F3}\n" +
                             $"Гипотеза {(hypothesisRejected ? "ОТВЕРГАЕТСЯ" : "ПРИНИМАЕТСЯ")}";
        }

        // Метод для получения критического значения χ² (табличные значения)
        private double GetChiSquaredCritical(int degreesOfFreedom, double alpha = 0.05)
        {
            // Табличные значения для α = 0.05 (95% доверительная вероятность)
            var table = new System.Collections.Generic.Dictionary<int, double>
    {
        { 1, 3.841 }, { 2, 5.991 }, { 3, 7.815 }, { 4, 9.488 },
        { 5, 11.070 }, { 6, 12.592 }, { 7, 14.067 }, { 8, 15.507 },
        { 9, 16.919 }, { 10, 18.307 }
    };

            return table.ContainsKey(degreesOfFreedom) ? table[degreesOfFreedom] : 0;
        }

        private double BuildHistogramAndChiSquared(double mean, double sigma, int n, int numIntervals)
        {
            // Определяем интервалы
            double minVal = samples.Min();
            double maxVal = samples.Max();

            // Расширяем границы
            double range = maxVal - minVal;
            minVal -= range * 0.01;
            maxVal += range * 0.01;
            double intervalWidth = (maxVal - minVal) / numIntervals;

            // Считаем частоты по интервалам
            int[] frequencies = new int[numIntervals];
            foreach (var x in samples)
            {
                int index = (int)((x - minVal) / intervalWidth);
                if (index >= numIntervals) index = numIntervals - 1;
                if (index < 0) index = 0;
                frequencies[index]++;
            }

            // Рисуем гистограмму
            DrawHistogram(minVal, intervalWidth, frequencies, mean, sigma, n);

            // Считаем χ²
            double chiSquared = 0;
            for (int i = 0; i < numIntervals; i++)
            {
                double left = minVal + i * intervalWidth;
                double right = left + intervalWidth;

                // Теоретическая вероятность попадания в интервал
                double theoreticalProb = NormalCDF(right, mean, sigma) -
                                        NormalCDF(left, mean, sigma);

                double expected = theoreticalProb * n;
                if (expected > 0)
                {
                    chiSquared += Math.Pow(frequencies[i] - expected, 2) / expected;
                }
            }

            return chiSquared;
        }

        // Функция распределения нормального закона (приближение)
        private double NormalCDF(double x, double mean, double sigma)
        {
            double z = (x - mean) / sigma;
            return 0.5 * (1 + Erf(z / Math.Sqrt(2)));
        }

        // Функция ошибок
        private double Erf(double x)
        {
            // Приближение Abramowitz and Stegun
            double sign = Math.Sign(x);
            x = Math.Abs(x);

            double t = 1.0 / (1.0 + 0.3275911 * x);
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return sign * y;
        }

        private void DrawHistogram(double minVal, double intervalWidth, int[] frequencies,
    double mean, double sigma, int n)
        {
            int width = chartPanel.Width;
            int height = chartPanel.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                int maxFreq = frequencies.Max();
                if (maxFreq == 0) maxFreq = 1;

                double maxVal = minVal + intervalWidth * frequencies.Length;

                int barWidth = (width - 100) / frequencies.Length;
                int startX = 50;
                int startY = height - 50;
                int maxBarHeight = height - 100;

                // Рисуем оси
                g.DrawLine(Pens.Black, startX, startY, startX + frequencies.Length * barWidth, startY);
                g.DrawLine(Pens.Black, startX, startY, startX, 10);

                // Подписи осей
                g.DrawString("Значения", Font, Brushes.Black, width / 2 - 30, height - 25);
                g.DrawString("freq.", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 5, 10);

                // Рисуем деления по оси Y
                int numYDivisions = 6;
                for (int i = 0; i <= numYDivisions; i++)
                {
                    double freqValue = (double)i / numYDivisions * maxFreq / frequencies.Length;
                    int y = startY - (i * maxBarHeight / numYDivisions);

                    g.DrawLine(Pens.Black, startX - 3, y, startX, y);
                    g.DrawString(freqValue.ToString("F2"), new Font("Arial", 7), Brushes.Black, 15, y - 6);
                }

                // Рисуем столбцы гистограммы
                for (int i = 0; i < frequencies.Length; i++)
                {
                    int barHeight = (int)((double)frequencies[i] / maxFreq * maxBarHeight);
                    Rectangle rect = new Rectangle(
                        startX + i * barWidth + 2,
                        startY - barHeight,
                        barWidth - 4,
                        barHeight
                    );

                    g.FillRectangle(Brushes.LightBlue, rect);
                    g.DrawRectangle(Pens.DarkBlue, rect);

                    // Подписи интервалов
                    double left = minVal + i * intervalWidth;
                    double right = left + intervalWidth;
                    string label = $"[{left:F0}; {right:F0})";
                    g.DrawString(label, new Font("Arial", 6), Brushes.Black,
                        startX + i * barWidth, startY + 5);
                }

                // Рисуем теоретическую кривую
                Pen curvePen = new Pen(Color.Green, 2);
                List<PointF> points = new List<PointF>();

                for (int i = 0; i <= width - 100; i += 5)
                {
                    double x = minVal + (i / (double)(width - 100)) * (maxVal - minVal);
                    double pdfValue = NormalPDF(x, mean, sigma);

                    // Масштабируем: плотность * N * ширина_интервала = ожидаемая частота
                    double expectedHeight = pdfValue * n * intervalWidth;
                    int pixelY = startY - (int)(expectedHeight / maxFreq * maxBarHeight);

                    if (pixelY >= 10 && pixelY <= startY)
                        points.Add(new PointF(startX + i, pixelY));
                }

                if (points.Count > 1)
                    g.DrawLines(curvePen, points.ToArray());
            }

            chartPanel.Image = bmp;
        }

        private double NormalPDF(double x, double mean, double sigma)
        {
            double coeff = 1.0 / (sigma * Math.Sqrt(2 * Math.PI));
            double exponent = -Math.Pow(x - mean, 2) / (2 * sigma * sigma);
            return coeff * Math.Exp(exponent);
        }
    }
}