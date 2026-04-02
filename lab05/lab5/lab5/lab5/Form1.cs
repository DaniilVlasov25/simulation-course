using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace lab5
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

        const double P_YES = 0.5;
        int countYes = 0;
        int countNo = 0;

        string[] answers = {
            "Определённо да",
            "Без сомнений",
            "Можешь быть уверен",
            "Скорее всего да",
            "Спроси позже",
            "Лучше не говорить сейчас",
            "Точно нет",
            "Знаки указывают на нет",
            "Не рассчитывай на это",
        };

        double[] probabilities = { 0.10, 0.15, 0.06, 0.09, 0.12, 0.08, 0.14, 0.16, 0.10 };

        int[] countAnswers;

        public Form1()
        {
            InitializeComponent();
            countAnswers = new int[answers.Length];
        }

        private void btnAsk1_Click(object sender, EventArgs e)
        {
            double alpha = NextDouble();

            if (alpha < P_YES)
            {
                countYes++;
                labelAnswer1.Text = "ДА!";
                labelAnswer1.ForeColor = Color.Green;
            }
            else
            {
                countNo++;
                labelAnswer1.Text = "НЕТ!";
                labelAnswer1.ForeColor = Color.Red;
            }

            int total = countYes + countNo;
            labelStats1.Text = $"Да: {countYes}    Нет: {countNo}    Всего: {total}";
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            countYes = 0;
            countNo = 0;
            labelAnswer1.Text = "?";
            labelAnswer1.ForeColor = Color.DarkBlue;
            labelStats1.Text = "Да: 0    Нет: 0    Всего: 0";
        }

        private void btnAsk2_Click(object sender, EventArgs e)
        {
            double alpha = NextDouble();
            double A = alpha;
            int k = 0;

            while (k < probabilities.Length)
            {
                A = A - probabilities[k];
                if (A <= 0)
                {
                    labelAnswer2.Text = answers[k];
                    countAnswers[k]++;
                    break;
                }
                k++;
            }

            int total = 0;
            foreach (int c in countAnswers) total += c;

            string stats = $"Всего вопросов: {total}\n";
            for (int i = 0; i < answers.Length; i++)
            {
                double freq = total > 0 ? (double)countAnswers[i] / total : 0;
                stats += $"{answers[i]}: {countAnswers[i]} ({freq:P1})\n";
            }
            labelStats2.Text = stats;
        }
    }
}