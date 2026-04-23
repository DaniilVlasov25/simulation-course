using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6
{
    public partial class Form1 : Form
    {
        // ГСЧ из лабы 5
        static BigInteger M = BigInteger.Pow(2, 63);
        static BigInteger Beta = BigInteger.Pow(2, 32) + 3;
        static BigInteger X = DateTime.Now.Ticks;

        static double NextDouble()
        {
            X = (Beta * X) % M;
            return (double)X / (double)M;
        }

        // Параметры ДСВ
        double[] values;      // значения x₁, x₂, ..., xₘ
        double[] probabilities; // вероятности p₁, p₂, ..., pₘ
        int[] countValues;    // счётчики частот

        // Статистика
        int totalExperiments;

        public Form1()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            // Пример: 5 значений с вероятностями
            values = new double[] { 1, 2, 3, 4, 5 };
            probabilities = new double[] { 0.264, 0.128, 0.228, 0.207, 0.173 };
            countValues = new int[values.Length];
            totalExperiments = 0;

            // Заполняем TextBox вероятностями по умолчанию
            txtProb1.Text = "0.264";
            txtProb2.Text = "0.128";
            txtProb3.Text = "0.228";
            txtProb4.Text = "0.207";
            txtProb5.Text = "0.173";

            txtNumExperiments.Text = "1000";
        }

        // Генерация ДСВ по заданному распределению
        private int GenerateDSV()
        {
            double alpha = NextDouble();
            double cumulativeProb = 0;

            for (int i = 0; i < probabilities.Length; i++)
            {
                cumulativeProb += probabilities[i];
                if (alpha < cumulativeProb)
                {
                    return i; // возвращаем индекс значения
                }
            }

            return probabilities.Length - 1; // на всякий случай
        }

        // Расчёт теоретического мат. ожидания
        private double CalculateTheoreticalMean()
        {
            double mean = 0;
            for (int i = 0; i < values.Length; i++)
            {
                mean += values[i] * probabilities[i];
            }
            return mean;
        }

        // Расчёт теоретической дисперсии
        private double CalculateTheoreticalVariance()
        {
            double mean = CalculateTheoreticalMean();
            double variance = 0;
            for (int i = 0; i < values.Length; i++)
            {
                variance += Math.Pow(values[i] - mean, 2) * probabilities[i];
            }
            return variance;
        }

        // Расчёт эмпирического мат. ожидания
        private double CalculateEmpiricalMean()
        {
            if (totalExperiments == 0) return 0;

            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i] * countValues[i];
            }
            return sum / totalExperiments;
        }

        // Расчёт эмпирической дисперсии
        private double CalculateEmpiricalVariance()
        {
            if (totalExperiments == 0) return 0;

            double mean = CalculateEmpiricalMean();
            double variance = 0;
            for (int i = 0; i < values.Length; i++)
            {
                double freq = (double)countValues[i] / totalExperiments;
                variance += Math.Pow(values[i] - mean, 2) * freq;
            }
            return variance;
        }

        // Расчёт статистики хи-квадрат
        private double CalculateChiSquared()
        {
            double chiSquared = 0;
            for (int i = 0; i < values.Length; i++)
            {
                double expected = probabilities[i] * totalExperiments;
                double observed = countValues[i];
                chiSquared += Math.Pow(observed - expected, 2) / expected;
            }
            return chiSquared;
        }

        // Критическое значение хи-квадрат (табличное)
        // Для простоты используем приближённые значения
        private double GetChiSquaredCritical(int degreesOfFreedom, double alpha = 0.05)
        {
            // Табличные значения для α = 0.05
            var table = new System.Collections.Generic.Dictionary<int, double>
            {
                { 1, 3.841 }, { 2, 5.991 }, { 3, 7.815 }, { 4, 9.488 },
                { 5, 11.070 }, { 6, 12.592 }, { 7, 14.067 }, { 8, 15.507 },
                { 9, 16.919 }, { 10, 18.307 }
            };

            return table.ContainsKey(degreesOfFreedom) ? table[degreesOfFreedom] : 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Используем InvariantCulture для парсинга чисел с точкой
                probabilities = new double[]
                {
                    double.Parse(txtProb1.Text, CultureInfo.InvariantCulture),
                    double.Parse(txtProb2.Text, CultureInfo.InvariantCulture),
                    double.Parse(txtProb3.Text, CultureInfo.InvariantCulture),
                    double.Parse(txtProb4.Text, CultureInfo.InvariantCulture),
                    double.Parse(txtProb5.Text, CultureInfo.InvariantCulture)
                };

                // Нормализуем вероятности (чтобы сумма была 1)
                double sum = probabilities.Sum();
                for (int i = 0; i < probabilities.Length; i++)
                {
                    probabilities[i] /= sum;
                }

                // Считываем количество экспериментов
                int n = int.Parse(txtNumExperiments.Text);
                totalExperiments = n;

                // Сбрасываем счётчики
                countValues = new int[values.Length];

                // Проводим эксперименты
                for (int i = 0; i < n; i++)
                {
                    int index = GenerateDSV();
                    countValues[index]++;
                }

                // Расчёт статистики
                double theoreticalMean = CalculateTheoreticalMean();
                double theoreticalVariance = CalculateTheoreticalVariance();
                double empiricalMean = CalculateEmpiricalMean();
                double empiricalVariance = CalculateEmpiricalVariance();
                double chiSquared = CalculateChiSquared();

                // Погрешности
                double meanError = Math.Abs(empiricalMean - theoreticalMean);
                double meanRelativeError = theoreticalMean != 0 ?
                    (meanError / Math.Abs(theoreticalMean)) * 100 : 0;

                double varianceError = Math.Abs(empiricalVariance - theoreticalVariance);
                double varianceRelativeError = theoreticalVariance != 0 ?
                    (varianceError / Math.Abs(theoreticalVariance)) * 100 : 0;

                // Критерий хи-квадрат
                int degreesOfFreedom = values.Length - 1;
                double chiSquaredCritical = GetChiSquaredCritical(degreesOfFreedom);
                bool hypothesisRejected = chiSquared > chiSquaredCritical;

                // Вывод результатов
                lblResults.Text = $"Теоретическое среднее: {theoreticalMean:F3}\n" +
                                 $"Эмпирическое среднее: {empiricalMean:F3}\n" +
                                 $"Погрешность среднего: {meanRelativeError:F1}%\n\n" +
                                 $"Теоретическая дисперсия: {theoreticalVariance:F3}\n" +
                                 $"Эмпирическая дисперсия: {empiricalVariance:F3}\n" +
                                 $"Погрешность дисперсии: {varianceRelativeError:F1}%\n\n" +
                                 $"χ² = {chiSquared:F2}\n" +
                                 $"χ² критическое = {chiSquaredCritical:F3}\n" +
                                 $"Гипотеза {(hypothesisRejected ? "ОТВЕРГАЕТСЯ" : "ПРИНИМАЕТСЯ")}";

                // Рисуем гистограмму
                DrawHistogram();

                // Вывод частот (Таблица частот)
                string freqText = "Частоты:\n";
                for (int i = 0; i < values.Length; i++)
                {
                    double freq = (double)countValues[i] / n;
                    // Форматируем вывод: Значение: Количество (Процент)
                    freqText += $"x={values[i]}: {countValues[i]} ({freq:P2})\n";
                }
                lblFrequencies.Text = freqText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void DrawHistogram()
        {
            if (totalExperiments == 0) return;

            int width = chartPanel.Width;
            int height = chartPanel.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // 1. Находим максимальную частоту для масштабирования оси Y
                int maxCount = countValues.Max();
                double maxFreq = (double)maxCount / totalExperiments;

                // Делаем запас сверху (15%), чтобы столбцы не упирались в потолок
                double axisMax = maxFreq * 1.15;
                // Округляем до удобного шага (например, до 0.05)
                axisMax = Math.Ceiling(axisMax * 20) / 20.0;
                if (axisMax > 1.0) axisMax = 1.0; // Не больше 1

                // Параметры графика
                int barWidth = (width - 120) / values.Length;
                int startX = 70; // Отступ слева для оси Y
                int startY = height - 50;
                int maxBarHeight = height - 100;

                // 2. Рисуем оси
                g.DrawLine(Pens.Black, startX, startY, startX + values.Length * barWidth, startY); // Ось X
                g.DrawLine(Pens.Black, startX, startY, startX, 10); // Ось Y

                // Подписи осей
                g.DrawString("Значения", Font, Brushes.Black, width / 2 - 30, height - 25);
                g.DrawString("freq.", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 5, 10);

                // 3. Рисуем деления и числа по оси Y (как в лекции)
                int numYDivisions = 6; // Количество делений
                for (int i = 0; i <= numYDivisions; i++)
                {
                    // Вычисляем значение частоты для этого деления
                    double freqValue = (double)i / numYDivisions * axisMax;

                    // Координата Y на экране
                    int y = startY - (int)((freqValue / axisMax) * maxBarHeight);

                    // Рисуем риску
                    g.DrawLine(Pens.Black, startX - 4, y, startX, y);

                    // Рисуем сетку (пунктир)
                    if (i > 0)
                    {
                        using (Pen gridPen = new Pen(Color.LightGray) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                        {
                            g.DrawLine(gridPen, startX, y, startX + values.Length * barWidth, y);
                        }
                    }

                    // Рисуем число (0.00, 0.05 и т.д.)
                    g.DrawString(freqValue.ToString("F2"), new Font("Arial", 8), Brushes.Black, 15, y - 6);
                }

                // 4. Рисуем столбцы
                for (int i = 0; i < values.Length; i++)
                {
                    double currentFreq = (double)countValues[i] / totalExperiments;
                    int barHeight = (int)((currentFreq / axisMax) * maxBarHeight);

                    Rectangle rect = new Rectangle(
                        startX + i * barWidth + 5,
                        startY - barHeight,
                        barWidth - 10,
                        barHeight
                    );

                    // Закрашиваем столбец
                    g.FillRectangle(Brushes.LightBlue, rect);
                    g.DrawRectangle(Pens.Blue, rect);

                    // Подпись значения X под столбцом (1, 2, 3...)
                    g.DrawString(values[i].ToString(), Font, Brushes.Black,
                        startX + i * barWidth + barWidth / 2 - 5, startY + 5);

                    // Подпись частоты НАД столбцом (как в лекции: 0.264)
                    if (countValues[i] > 0)
                    {
                        g.DrawString(currentFreq.ToString("F3"), new Font("Arial", 8),
                            Brushes.Black, startX + i * barWidth, startY - barHeight - 15);
                    }
                }
            }

            chartPanel.Image = bmp;
        }

        private void btnAutoProb_Click(object sender, EventArgs e)
        {
            double[] probs = new double[5];
            double sum = 0;

            for (int i = 0; i < 4; i++)
            {
                probs[i] = 0.10 + 0.20 * NextDouble();
                sum += probs[i];
            }

            probs[4] = 1.0 - sum;

            if (probs[4] < 0.05 || probs[4] > 0.40)
            {
                double total = probs.Take(4).Sum();
                for (int i = 0; i < 4; i++)
                {
                    probs[i] = probs[i] / total * 0.85;
                }
                probs[4] = 1.0 - probs.Take(4).Sum();
            }

            txtProb1.Text = probs[0].ToString("F3", CultureInfo.InvariantCulture);
            txtProb2.Text = probs[1].ToString("F3", CultureInfo.InvariantCulture);
            txtProb3.Text = probs[2].ToString("F3", CultureInfo.InvariantCulture);
            txtProb4.Text = probs[3].ToString("F3", CultureInfo.InvariantCulture);
            txtProb5.Text = probs[4].ToString("F3", CultureInfo.InvariantCulture);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            countValues = new int[values.Length];
            totalExperiments = 0;
            lblResults.Text = "Нажмите Start для начала эксперимента";
            lblFrequencies.Text = "Частоты:";
            chartPanel.Image = null;
        }
    }
}