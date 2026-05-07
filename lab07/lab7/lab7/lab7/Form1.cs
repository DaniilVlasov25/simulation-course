using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace lab7
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
            if (alpha == 0) alpha = 1e-15; 
            return -Math.Log(alpha) / lambda;
        }

        int numStates = 3;
        string[] stateNames = { "Ясно", "Облачно", "Пасмурно" };
        Color[] stateColors = { Color.Yellow, Color.LightGray, Color.DarkGray };

        double[,] qOffDiagonal = {
            { 0.0, 0.3, 0.1 },  
            { 0.4, 0.0, 0.4 },  
            { 0.1, 0.4, 0.0 }   
        };

        double[,] Q; 

        List<double> eventTimes = new List<double>(); // Моменты переходов
        List<int> stateSequence = new List<int>();    // Состояния в эти моменты
        double[] totalTimeInState;                    // Общее время пребывания
        int[,] transitionCounts;                      // Матрица переходов (для анализа)

        public Form1()
        {
            InitializeComponent();

            totalTimeInState = new double[numStates];
            transitionCounts = new int[numStates, numStates];

            ComputeFullMatrix();
        }

        // Вычисление диагональных элементов: q_ii = -Σ q_ij
        void ComputeFullMatrix()
        {
            Q = new double[numStates, numStates];
            for (int i = 0; i < numStates; i++)
            {
                double sumOffDiag = 0;
                for (int j = 0; j < numStates; j++)
                {
                    if (i != j)
                    {
                        Q[i, j] = qOffDiagonal[i, j];
                        sumOffDiag += qOffDiagonal[i, j];
                    }
                }
                Q[i, i] = -sumOffDiag; // Диагональный элемент!
            }
        }

        void Simulate(double Tmax)
        {
            eventTimes.Clear();
            stateSequence.Clear();
            Array.Clear(totalTimeInState, 0, numStates);
            Array.Clear(transitionCounts, 0, transitionCounts.Length);

            //Выбор начального состояния
            int currentState = (int)(numStates * NextDouble());

            double currentTime = 0.0;
            double lastEventTime = 0.0;

            eventTimes.Add(currentTime);
            stateSequence.Add(currentState);

            //Основной цикл моделирования
            while (currentTime < Tmax)
            {
                // Интенсивность выхода из текущего состояния
                double lambda = -Q[currentState, currentState];

                // Генерируем время пребывания в текущем состоянии
                double tau = GenerateExponential(lambda);
                currentTime += tau;

                if (currentTime > Tmax)
                {
                    totalTimeInState[currentState] += (Tmax - lastEventTime);
                    break;
                }

                totalTimeInState[currentState] += (currentTime - lastEventTime);
                lastEventTime = currentTime;

                double[] probs = new double[numStates];
                double sumProbs = 0;

                for (int j = 0; j < numStates; j++)
                {
                    if (j != currentState)
                    {
                        probs[j] = Q[currentState, j] / lambda;
                        sumProbs += probs[j];
                    }
                }

                for (int j = 0; j < numStates; j++)
                    probs[j] /= sumProbs;

                // Генерируем следующее состояние
                double alpha = NextDouble();
                double cumulative = 0;
                int nextState = currentState;

                for (int j = 0; j < numStates; j++)
                {
                    if (j != currentState)
                    {
                        cumulative += probs[j];
                        if (alpha < cumulative)
                        {
                            nextState = j;
                            break;
                        }
                    }
                }

                // Обновляем состояние и фиксируем переход
                transitionCounts[currentState, nextState]++;
                currentState = nextState;

                eventTimes.Add(currentTime);
                stateSequence.Add(currentState);
            }
        }
        double[] GetEmpiricalDistribution()
        {
            double totalSimulatedTime = totalTimeInState.Sum();
            double[] freq = new double[numStates];
            for (int i = 0; i < numStates; i++)
            {
                freq[i] = totalTimeInState[i] / totalSimulatedTime;
            }
            return freq;
        }

        // Расчет теоретического стационарного распределения (Метод Гаусса)
        double[] CalculateStationaryDistribution()
        {
            int n = numStates;
            double[,] A = new double[n, n];
            double[] b = new double[n];

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = Q[j, i];
                }
                b[i] = 0;
            }

            for (int j = 0; j < n; j++)
            {
                A[n - 1, j] = 1.0;
            }
            b[n - 1] = 1.0;

            return SolveGauss(A, b, n);
        }

        // Метод Гаусса для решения СЛАУ
        double[] SolveGauss(double[,] A, double[] b, int n)
        {
            // Прямой ход
            for (int k = 0; k < n; k++)
            {
                // Поиск ведущего элемента
                int maxRow = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(A[i, k]) > Math.Abs(A[maxRow, k]))
                        maxRow = i;
                }

                // Обмен строк
                for (int j = k; j < n; j++)
                {
                    double temp = A[k, j];
                    A[k, j] = A[maxRow, j];
                    A[maxRow, j] = temp;
                }
                double tempB = b[k];
                b[k] = b[maxRow];
                b[maxRow] = tempB;

                // Исключение переменных
                for (int i = k + 1; i < n; i++)
                {
                    double factor = A[i, k] / A[k, k];
                    for (int j = k; j < n; j++)
                    {
                        A[i, j] -= factor * A[k, j];
                    }
                    b[i] -= factor * b[k];
                }
            }

            // Обратный ход
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= A[i, j] * x[j];
                }
                x[i] /= A[i, i];
            }
                
            return x;
        }

        private void DrawChart()
        {
            if (eventTimes.Count == 0) return;

            int width = pictureBoxChart.Width;
            int height = pictureBoxChart.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                double T_max = eventTimes.Max();

                // Отступы для осей
                int startX = 60;
                int endX = width - 30;
                int startY = 30;
                int endY = height - 40;

                // Оси
                Pen axisPen = new Pen(Color.Black, 1.5f);
                g.DrawLine(axisPen, startX, startY, startX, endY); // Ось Y
                g.DrawLine(axisPen, startX, endY, endX, endY);     // Ось X

                // Подписи осей
                g.DrawString("Время (дни)", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, width / 2 - 30, height - 20);
                g.DrawString("Состояние", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 5, 10);

                // Разметка по оси Y (состояния)
                int stateHeight = (endY - startY) / (numStates + 1);
                for (int i = 0; i < numStates; i++)
                {
                    int y = endY - (i + 1) * stateHeight;
                    g.DrawString(stateNames[i], new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5, y - 5);
                }

                // Промежуточные отметки на оси X (каждые 10% времени)
                int numXDivisions = 10;
                Pen gridPen = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

                for (int i = 0; i <= numXDivisions; i++)
                {
                    double timeValue = (T_max / numXDivisions) * i;
                    int x = startX + (int)((timeValue / T_max) * (endX - startX));

                    // Вертикальная сетка
                    if (i > 0 && i < numXDivisions)
                    {
                        g.DrawLine(gridPen, x, startY, x, endY);
                    }

                    // Риска на оси X
                    g.DrawLine(Pens.Black, x, endY, x, endY + 4);

                    // Подпись времени (округляем до целого)
                    string label = Math.Round(timeValue).ToString();
                    SizeF labelSize = g.MeasureString(label, Font);
                    g.DrawString(label, Font, Brushes.Black, x - labelSize.Width / 2, endY + 6);
                }

                // Отрисовка траектории с ЦВЕТАМИ состояний
                for (int k = 0; k < eventTimes.Count - 1; k++)
                {
                    double t1 = eventTimes[k];
                    double t2 = eventTimes[k + 1];
                    int state = stateSequence[k];

                    int x1 = startX + (int)((t1 / T_max) * (endX - startX));
                    int x2 = startX + (int)((t2 / T_max) * (endX - startX));
                    int y = endY - (state + 1) * stateHeight;

                    // Используем ЦВЕТ состояния (не синий!)
                    Pen linePen = new Pen(stateColors[state], 4);
                    g.DrawLine(linePen, x1, y, x2, y);

                    // Точки переходов (красные)
                    g.FillEllipse(Brushes.Red, x2 - 3, y - 3, 6, 6);
                }

                // Легенда цветов (справа сверху)
                int legendX = endX - 70;
                int legendY = startY - 20;
                g.DrawString("Цвет состояний:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, legendX, legendY);

                for (int i = 0; i < numStates; i++)
                {
                    int y = legendY + 20 + i * 15;
                    g.FillRectangle(new SolidBrush(stateColors[i]), legendX, y, 15, 12);
                    g.DrawRectangle(Pens.Black, legendX, y, 15, 12);
                    g.DrawString(stateNames[i], new Font("Arial", 8), Brushes.Black, legendX + 20, y - 2);
                }
            }

            pictureBoxChart.Image = bmp;
        }

        private void SaveToCSV(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                // Заголовки
                sw.WriteLine("Time;State;StateName");

                // Данные траектории
                for (int i = 0; i < eventTimes.Count; i++)
                {
                    sw.WriteLine($"{eventTimes[i]:F4};{stateSequence[i]};{stateNames[stateSequence[i]]}");
                }

                sw.WriteLine();
                sw.WriteLine("Statistics;TotalTime;EmpiricalFreq;TheoreticalFreq;AbsError;RelError(%)");

                double[] empirical = GetEmpiricalDistribution();
                double[] theoretical = CalculateStationaryDistribution();

                for (int i = 0; i < numStates; i++)
                {
                    double absErr = Math.Abs(empirical[i] - theoretical[i]);
                    double relErr = (theoretical[i] != 0) ? (absErr / theoretical[i]) * 100 : 0;
                    sw.WriteLine($"{stateNames[i]};{totalTimeInState[i]:F4};{empirical[i]:F4};{theoretical[i]:F4};{absErr:F4};{relErr:F2}");
                }
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                double Tmax = double.Parse(txtTime.Text, System.Globalization.CultureInfo.InvariantCulture);

                // Запуск моделирования
                Simulate(Tmax);

                // Отрисовка
                DrawChart();

                // Расчет статистики
                double[] empirical = GetEmpiricalDistribution();
                double[] theoretical = CalculateStationaryDistribution();

                // Вывод текста
                string statsText = "=== СТАТИСТИЧЕСКАЯ ОБРАБОТКА ===\n\n";

                for (int i = 0; i < numStates; i++)
                {
                    double relError = (theoretical[i] != 0) ? Math.Abs((empirical[i] - theoretical[i]) / theoretical[i] * 100) : 0;
                    statsText += $"{stateNames[i]}:\n";
                    statsText += $"  Эмпирическая частота: {empirical[i]:F3}\n";
                    statsText += $"  Теоретическая (π):   {theoretical[i]:F3}\n";
                    statsText += $"  Погрешность:         {relError:F1}%\n\n";
                }

                statsText += $"Общее время: {eventTimes.Max():F1} дней\n";
                statsText += $"Количество переходов: {eventTimes.Count - 1}";

                lblStats.Text = statsText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (eventTimes.Count == 0)
            {
                MessageBox.Show("Сначала запустите моделирование!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.FileName = "WeatherSimulation.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveToCSV(sfd.FileName);
                    MessageBox.Show("Данные успешно сохранены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            eventTimes.Clear();
            stateSequence.Clear();
            Array.Clear(totalTimeInState, 0, numStates);
            Array.Clear(transitionCounts, 0, transitionCounts.Length);
            pictureBoxChart.Image = null;
            lblStats.Text = "";
        }
    }
}