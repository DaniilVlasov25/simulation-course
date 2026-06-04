using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        private Random _rng = new Random();
        private double ExpRV(double rate) => -Math.Log(_rng.NextDouble()) / rate;

        public Form1() { InitializeComponent(); }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!TryParseInputs(out double lambda, out double mu, out double T,
                                out int servers, out int queueMax))
                return;

            // serviceEnd[i] — когда освободится i-й прибор
            double[] serviceEnd = new double[servers];

            // очередь: храним время прихода каждой заявки
            var queue = new Queue<double>();

            int served = 0, refused = 0, refusedBreakdown = 0, refusedQueue = 0;

            const double breakdownPeriod = 200.0;
            const double breakdownDuration = 20.0;

            double totalWaitTime = 0;      // Суммарное время ожидания в очереди
            double queueLengthSum = 0;     // Сумма длин очереди (для средней)
            int eventsCount = 0;           // Количество событий (для усреднения)

            double t = ExpRV(lambda);

            while (t <= T)
            {
                eventsCount++;
                queueLengthSum += queue.Count; 

                double cyclePos = t % breakdownPeriod;
                bool isBroken = cyclePos >= (breakdownPeriod - breakdownDuration);

                if (isBroken)
                { 
                    refused++;
                    refusedBreakdown++;
                }
                else
                {
                    for (int i = 0; i < servers; i++)
                    {
                        if (serviceEnd[i] <= t && queue.Count > 0)
                        {
                            double arrivalTime = queue.Dequeue();
                            double waitTime = t - arrivalTime;
                            totalWaitTime += waitTime;

                            serviceEnd[i] = t + ExpRV(mu);
                            served++;
                        }
                    }

                    int freeServer = -1;
                    for (int i = 0; i < servers; i++)
                    {
                        if (serviceEnd[i] <= t)
                        {
                            freeServer = i;
                            break;
                        }
                    }

                    if (freeServer >= 0)
                    {
                        serviceEnd[freeServer] = t + ExpRV(mu);
                        served++;
                    }
                    else if (queue.Count < queueMax)
                    {
                        queue.Enqueue(t);
                    }
                    else
                    {
                        refused++;
                        refusedQueue++;
                    }
                }

                t += ExpRV(lambda);
            }
                
            int total = served + refused;
            double pServed = total > 0 ? (double)served / total : 0;
            double pRefused = total > 0 ? (double)refused / total : 0;

            double throughput = served / T;

            double avgQueueLength = eventsCount > 0 ? queueLengthSum / eventsCount : 0;
            double avgWaitTime = served > 0 ? totalWaitTime / served : 0;

            txtOutput.Text =
                $"Параметры:\r\n" +
                $"  λ={lambda}  μ={mu}  T={T}\r\n" +
                $"  Приборов: {servers}  Очередь: {queueMax}\r\n\r\n" +
                $"Всего заявок:            {total}\r\n" +
                $"Обслужено:               {served}\r\n" +
                $"Отказов всего:           {refused}\r\n" +
                $"  из-за поломки:         {refusedBreakdown}\r\n" +
                $"  очередь переполнена:   {refusedQueue}\r\n\r\n" +
                $"Вероятность успеха:      {pServed:F4}\r\n" +
                $"Вероятность отказа:      {pRefused:F4}\r\n" +
                $"Пропускная способность:  {throughput:F4} заявок/мин\r\n" +
                $"Средняя длина очереди:   {avgQueueLength:F4}\r\n" +
                $"Ср. время ожидания:      {avgWaitTime:F4} мин\r\n";
        }

        private bool TryParseInputs(out double lambda, out double mu, out double T,
                                    out int servers, out int queueMax)
        {
            lambda = mu = T = 0;
            servers = queueMax = 0;

            if (!double.TryParse(txtLambda.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out lambda) || lambda <= 0)
            { MessageBox.Show("Введите корректное значение λ (> 0)", "Ошибка"); return false; }

            if (!double.TryParse(txtMu.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out mu) || mu <= 0)
            { MessageBox.Show("Введите корректное значение μ (> 0)", "Ошибка"); return false; }

            if (!double.TryParse(txtT.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out T) || T <= 0)
            { MessageBox.Show("Введите корректное значение T (> 0)", "Ошибка"); return false; }

            if (!int.TryParse(txtServers.Text, out servers) || servers < 1)
            { MessageBox.Show("Введите корректное число приборов (≥ 1)", "Ошибка"); return false; }

            if (!int.TryParse(txtQueue.Text, out queueMax) || queueMax < 0)
            { MessageBox.Show("Введите корректную длину очереди (≥ 0)", "Ошибка"); return false; }

            return true;
        }
    }
}