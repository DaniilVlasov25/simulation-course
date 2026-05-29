using System.Drawing;
using System.Windows.Forms;

namespace lab9_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblLambda;
        private TextBox txtLambda;
        private Label lblMu;
        private TextBox txtMu;
        private Label lblT;
        private TextBox txtT;
        private Button btnRun;
        private TextBox txtOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Text = "СМО — Отказная система";
            Size = new Size(400, 360);
            MinimumSize = new Size(400, 360);
            MaximumSize = new Size(400, 360);
            Font = new Font("Segoe UI", 10f);
            StartPosition = FormStartPosition.CenterScreen;

            // λ
            lblLambda = new Label
            {
                Text = "Интенсивность λ (заявок/мин):",
                Location = new Point(20, 20),
                Size = new Size(240, 20)
            };
            txtLambda = new TextBox
            {
                Text = "2",
                Location = new Point(270, 17),
                Size = new Size(90, 26)
            };

            // μ
            lblMu = new Label
            {
                Text = "Интенсивность μ (обсл/мин):",
                Location = new Point(20, 60),
                Size = new Size(240, 20)
            };
            txtMu = new TextBox
            {
                Text = "3",
                Location = new Point(270, 57),
                Size = new Size(90, 26)
            };

            // T
            lblT = new Label
            {
                Text = "Длительность симуляции T (мин):",
                Location = new Point(20, 100),
                Size = new Size(240, 20)
            };
            txtT = new TextBox
            {
                Text = "1000",
                Location = new Point(270, 97),
                Size = new Size(90, 26)
            };

            // Кнопка
            btnRun = new Button
            {
                Text = "Запустить",
                Location = new Point(20, 140),
                Size = new Size(340, 34),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRun.FlatAppearance.BorderSize = 0;
            btnRun.Click += btnRun_Click;

            // Вывод результатов
            txtOutput = new TextBox
            {
                Location = new Point(20, 188),
                Size = new Size(340, 130),
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.FromArgb(245, 245, 245),
                Font = new Font("Courier New", 10f),
                ScrollBars = ScrollBars.Vertical
            };

            Controls.AddRange(new Control[]
            {
                lblLambda, txtLambda,
                lblMu,     txtMu,
                lblT,      txtT,
                btnRun,
                txtOutput
            });
        }
    }
}