using System;
using System.Windows.Forms;

namespace lab9_1
{
    public partial class Form1 : Form
    {
        private Random _rng = new Random();

        private double ExpRV(double rate) => -Math.Log(_rng.NextDouble()) / rate;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!TryParseInputs(out double lambda, out double mu, out double T))
                return;

            int served = 0;
            int refused = 0;
            int refusedBreakdown = 0; // отказы именно из-за поломки

            const double breakdownPeriod = 200.0;
            const double breakdownDuration = 20.0;

            double t = 0;
            double serviceEnd = 0;

            t = ExpRV(lambda); // время первого клиента

            while (t <= T)
            {
                double cyclePos = t % breakdownPeriod;
                bool isBroken = cyclePos >= (breakdownPeriod - breakdownDuration);

                if (isBroken)
                {
                    refusedBreakdown++;
                    refused++;
                }
                else if (t >= serviceEnd)
                {
                    double serviceDuration = ExpRV(mu);
                    serviceEnd = t + serviceDuration;
                    served++;
                }
                else
                {
                    refused++;
                }

                t += ExpRV(lambda);
            }

            int total = served + refused;
            double pServed = total > 0 ? (double)served / total : 0;
            double pRefused = total > 0 ? (double)refused / total : 0;

            txtOutput.Text =
                $"Параметры:\r\n" +
                $"  λ = {lambda}  μ = {mu}  T = {T}\r\n\r\n" +
                $"Всего клиентов:         {total}\r\n" +
                $"Обслужено:              {served}\r\n" +
                $"Отказов всего:          {refused}\r\n" +
                $"  из них из-за поломки: {refusedBreakdown}\r\n\r\n" +
                $"Вероятность успеха:     {pServed:F4}\r\n" +
                $"Вероятность отказа:     {pRefused:F4}\r\n";
        }

        private bool TryParseInputs(out double lambda, out double mu, out double T)
        {
            lambda = mu = T = 0;

            if (!double.TryParse(txtLambda.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out lambda) || lambda <= 0)
            {
                MessageBox.Show("Введите корректное значение λ (> 0)", "Ошибка");
                return false;
            }
            if (!double.TryParse(txtMu.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out mu) || mu <= 0)
            {
                MessageBox.Show("Введите корректное значение μ (> 0)", "Ошибка");
                return false;
            }
            if (!double.TryParse(txtT.Text.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out T) || T <= 0)
            {
                MessageBox.Show("Введите корректное значение T (> 0)", "Ошибка");
                return false;
            }
            return true;
        }
    }
}