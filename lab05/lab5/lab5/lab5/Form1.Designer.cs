using System.Drawing;
using System.Windows.Forms;

namespace lab5
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();

            labelQuestion1 = new Label();
            labelP1 = new Label();
            labelAnswer1 = new Label();
            btnAsk1 = new Button();
            btnReset1 = new Button();
            labelStats1 = new Label();

            labelTitle2 = new Label();
            labelAnswer2 = new Label();
            btnAsk2 = new Button();
            labelStats2 = new Label();

            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();

            // tabControl1
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Size = new Size(484, 411);

            // tabPage1
            tabPage1.Text = "Да или нет";
            tabPage1.Controls.AddRange(new Control[] {
                labelQuestion1, labelP1, labelAnswer1, btnAsk1, btnReset1, labelStats1
            });

            // labelQuestion1
            labelQuestion1.Text = "Пойти сегодня в университет?";
            labelQuestion1.Font = new Font("Arial", 14, FontStyle.Bold);
            labelQuestion1.AutoSize = false;
            labelQuestion1.TextAlign = ContentAlignment.MiddleCenter;
            labelQuestion1.Size = new Size(460, 40);
            labelQuestion1.Location = new Point(10, 20);

            // labelP1
            labelP1.Text = "P(да) = 0.5     P(нет) = 0.5";
            labelP1.Font = new Font("Arial", 10);
            labelP1.AutoSize = false;
            labelP1.TextAlign = ContentAlignment.MiddleCenter;
            labelP1.Size = new Size(460, 25);
            labelP1.Location = new Point(10, 65);

            // labelAnswer1
            labelAnswer1.Text = "?";
            labelAnswer1.Font = new Font("Arial", 48, FontStyle.Bold);
            labelAnswer1.ForeColor = Color.DarkBlue;
            labelAnswer1.AutoSize = false;
            labelAnswer1.TextAlign = ContentAlignment.MiddleCenter;
            labelAnswer1.Size = new Size(460, 100);
            labelAnswer1.Location = new Point(10, 100);

            // btnAsk1
            btnAsk1.Text = "Спросить";
            btnAsk1.Font = new Font("Arial", 13);
            btnAsk1.Size = new Size(150, 45);
            btnAsk1.Location = new Point(160, 215);
            btnAsk1.Click += btnAsk1_Click;

            // labelStats1
            labelStats1.Text = "Да: 0    Нет: 0    Всего: 0";
            labelStats1.Font = new Font("Arial", 10);
            labelStats1.AutoSize = false;
            labelStats1.TextAlign = ContentAlignment.MiddleCenter;
            labelStats1.Size = new Size(460, 25);
            labelStats1.Location = new Point(10, 275);

            // btnReset1
            btnReset1.Text = "Сброс";
            btnReset1.Font = new Font("Arial", 10);
            btnReset1.Size = new Size(100, 30);
            btnReset1.Location = new Point(185, 310);
            btnReset1.Click += btnReset1_Click;

            // tabPage2
            tabPage2.Text = "Шар предсказаний";
            tabPage2.Controls.AddRange(new Control[] {
                labelTitle2, labelAnswer2, btnAsk2, labelStats2
            });

            // labelTitle2
            labelTitle2.Text = "Шар предсказаний";
            labelTitle2.Font = new Font("Arial", 16, FontStyle.Bold);
            labelTitle2.AutoSize = false;
            labelTitle2.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle2.Size = new Size(460, 40);
            labelTitle2.Location = new Point(10, 15);

            // labelAnswer2
            labelAnswer2.Text = "Задай вопрос...";
            labelAnswer2.Font = new Font("Arial", 15, FontStyle.Bold);
            labelAnswer2.ForeColor = Color.DarkBlue;
            labelAnswer2.AutoSize = false;
            labelAnswer2.TextAlign = ContentAlignment.MiddleCenter;
            labelAnswer2.Size = new Size(460, 60);
            labelAnswer2.Location = new Point(10, 65);

            // btnAsk2
            btnAsk2.Text = "Спросить шар";
            btnAsk2.Font = new Font("Arial", 13);
            btnAsk2.Size = new Size(180, 45);
            btnAsk2.Location = new Point(145, 140);
            btnAsk2.Click += btnAsk2_Click;

            // labelStats2
            labelStats2.Text = "";
            labelStats2.Font = new Font("Arial", 8);
            labelStats2.AutoSize = false;
            labelStats2.TextAlign = ContentAlignment.TopLeft;
            labelStats2.Size = new Size(460, 190);
            labelStats2.Location = new Point(10, 200);

            // Form1
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 411);
            Controls.Add(tabControl1);
            Text = "Лабораторная 5 — Моделирование случайных событий";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ResumeLayout(false);
        }

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;

        private Label labelQuestion1;
        private Label labelP1;
        private Label labelAnswer1;
        private Button btnAsk1;
        private Button btnReset1;
        private Label labelStats1;

        private Label labelTitle2;
        private Label labelAnswer2;
        private Button btnAsk2;
        private Label labelStats2;
    }
}