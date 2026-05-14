namespace lab8
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
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.lblLambdaVal = new System.Windows.Forms.Label();
            this.lblTVal = new System.Windows.Forms.Label();
            this.lblNVal = new System.Windows.Forms.Label();
            this.numN = new System.Windows.Forms.NumericUpDown();
            this.numT = new System.Windows.Forms.NumericUpDown();
            this.numLambda = new System.Windows.Forms.NumericUpDown();
            this.lblN = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.lblLambda = new System.Windows.Forms.Label();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.lblVarianceTheorVal = new System.Windows.Forms.Label();
            this.lblMeanTheorVal = new System.Windows.Forms.Label();
            this.lblVarianceVal = new System.Windows.Forms.Label();
            this.lblMeanVal = new System.Windows.Forms.Label();
            this.lblVarianceTheor = new System.Windows.Forms.Label();
            this.lblMeanTheor = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.groupBoxChart = new System.Windows.Forms.GroupBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.groupBoxTable = new System.Windows.Forms.GroupBox();
            this.dgvDistribution = new System.Windows.Forms.DataGridView();
            this.colK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblConclusion = new System.Windows.Forms.Label();
            this.groupBoxConclusion = new System.Windows.Forms.GroupBox();

            // groupBoxParams
            this.groupBoxParams.Controls.Add(this.lblLambdaVal);
            this.groupBoxParams.Controls.Add(this.lblTVal);
            this.groupBoxParams.Controls.Add(this.lblNVal);
            this.groupBoxParams.Controls.Add(this.numN);
            this.groupBoxParams.Controls.Add(this.numT);
            this.groupBoxParams.Controls.Add(this.numLambda);
            this.groupBoxParams.Controls.Add(this.lblN);
            this.groupBoxParams.Controls.Add(this.lblT);
            this.groupBoxParams.Controls.Add(this.lblLambda);
            this.groupBoxParams.Location = new System.Drawing.Point(12, 50);
            this.groupBoxParams.Size = new System.Drawing.Size(320, 150);
            this.groupBoxParams.Text = "Параметры моделирования";
            this.groupBoxParams.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // lblLambda
            this.lblLambda.Text = "λ (интенсивность потока):";
            this.lblLambda.Location = new System.Drawing.Point(10, 30);
            this.lblLambda.Size = new System.Drawing.Size(185, 20);
            this.lblLambda.Font = new System.Drawing.Font("Segoe UI", 9F);

            // numLambda
            this.numLambda.Location = new System.Drawing.Point(200, 28);
            this.numLambda.Size = new System.Drawing.Size(70, 23);
            this.numLambda.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLambda.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numLambda.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.numLambda.DecimalPlaces = 0;
            this.numLambda.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblLambdaVal
            this.lblLambdaVal.Text = "зап/сек";
            this.lblLambdaVal.Location = new System.Drawing.Point(275, 30);
            this.lblLambdaVal.Size = new System.Drawing.Size(40, 20);
            this.lblLambdaVal.Font = new System.Drawing.Font("Segoe UI", 8F);

            // lblT
            this.lblT.Text = "T (интервал времени):";
            this.lblT.Location = new System.Drawing.Point(10, 65);
            this.lblT.Size = new System.Drawing.Size(185, 20);
            this.lblT.Font = new System.Drawing.Font("Segoe UI", 9F);

            // numT
            this.numT.Location = new System.Drawing.Point(200, 63);
            this.numT.Size = new System.Drawing.Size(70, 23);
            this.numT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numT.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numT.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.numT.DecimalPlaces = 0;
            this.numT.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblTVal
            this.lblTVal.Text = "сек";
            this.lblTVal.Location = new System.Drawing.Point(275, 65);
            this.lblTVal.Size = new System.Drawing.Size(40, 20);
            this.lblTVal.Font = new System.Drawing.Font("Segoe UI", 8F);

            // lblN
            this.lblN.Text = "N (число экспериментов):";
            this.lblN.Location = new System.Drawing.Point(10, 100);
            this.lblN.Size = new System.Drawing.Size(185, 20);
            this.lblN.Font = new System.Drawing.Font("Segoe UI", 9F);

            // numN
            this.numN.Location = new System.Drawing.Point(200, 98);
            this.numN.Size = new System.Drawing.Size(70, 23);
            this.numN.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numN.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numN.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numN.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numN.DecimalPlaces = 0;
            this.numN.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblNVal
            this.lblNVal.Text = "шт";
            this.lblNVal.Location = new System.Drawing.Point(275, 100);
            this.lblNVal.Size = new System.Drawing.Size(40, 20);
            this.lblNVal.Font = new System.Drawing.Font("Segoe UI", 8F);

            // btnSimulate
            this.btnSimulate.Text = "▶  Запустить моделирование";
            this.btnSimulate.Location = new System.Drawing.Point(12, 210);
            this.btnSimulate.Size = new System.Drawing.Size(320, 40);
            this.btnSimulate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSimulate.ForeColor = System.Drawing.Color.White;
            this.btnSimulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);

            // groupBoxResults
            this.groupBoxResults.Controls.Add(this.lblVarianceTheorVal);
            this.groupBoxResults.Controls.Add(this.lblMeanTheorVal);
            this.groupBoxResults.Controls.Add(this.lblVarianceVal);
            this.groupBoxResults.Controls.Add(this.lblMeanVal);
            this.groupBoxResults.Controls.Add(this.lblVarianceTheor);
            this.groupBoxResults.Controls.Add(this.lblMeanTheor);
            this.groupBoxResults.Controls.Add(this.lblVariance);
            this.groupBoxResults.Controls.Add(this.lblMean);
            this.groupBoxResults.Location = new System.Drawing.Point(12, 260);
            this.groupBoxResults.Size = new System.Drawing.Size(320, 120);
            this.groupBoxResults.Text = "Результаты";
            this.groupBoxResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // lblMean
            this.lblMean.Text = "Среднее (эмп.):";
            this.lblMean.Location = new System.Drawing.Point(10, 25);
            this.lblMean.Size = new System.Drawing.Size(130, 20);
            this.lblMean.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblMeanVal
            this.lblMeanVal.Text = "—";
            this.lblMeanVal.Location = new System.Drawing.Point(145, 25);
            this.lblMeanVal.Size = new System.Drawing.Size(80, 20);
            this.lblMeanVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMeanVal.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);

            // lblMeanTheor
            this.lblMeanTheor.Text = "Среднее (теор.):";
            this.lblMeanTheor.Location = new System.Drawing.Point(10, 50);
            this.lblMeanTheor.Size = new System.Drawing.Size(130, 20);
            this.lblMeanTheor.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblMeanTheorVal
            this.lblMeanTheorVal.Text = "—";
            this.lblMeanTheorVal.Location = new System.Drawing.Point(145, 50);
            this.lblMeanTheorVal.Size = new System.Drawing.Size(80, 20);
            this.lblMeanTheorVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMeanTheorVal.ForeColor = System.Drawing.Color.FromArgb(0, 153, 76);

            // lblVariance
            this.lblVariance.Text = "Дисперсия (эмп.):";
            this.lblVariance.Location = new System.Drawing.Point(10, 75);
            this.lblVariance.Size = new System.Drawing.Size(130, 20);
            this.lblVariance.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblVarianceVal
            this.lblVarianceVal.Text = "—";
            this.lblVarianceVal.Location = new System.Drawing.Point(145, 75);
            this.lblVarianceVal.Size = new System.Drawing.Size(80, 20);
            this.lblVarianceVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVarianceVal.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);

            // lblVarianceTheor
            this.lblVarianceTheor.Text = "Дисперсия (теор.):";
            this.lblVarianceTheor.Location = new System.Drawing.Point(10, 100);
            this.lblVarianceTheor.Size = new System.Drawing.Size(130, 20);
            this.lblVarianceTheor.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblVarianceTheorVal - we'll add it differently since groupBox size is 120
            // Adjusting groupBox size
            this.groupBoxResults.Size = new System.Drawing.Size(320, 135);

            // lblVarianceTheorVal
            this.lblVarianceTheorVal.Text = "—";
            this.lblVarianceTheorVal.Location = new System.Drawing.Point(145, 100);
            this.lblVarianceTheorVal.Size = new System.Drawing.Size(80, 20);
            this.lblVarianceTheorVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVarianceTheorVal.ForeColor = System.Drawing.Color.FromArgb(0, 153, 76);

            // groupBoxChart
            this.groupBoxChart.Controls.Add(this.panelChart);
            this.groupBoxChart.Location = new System.Drawing.Point(345, 50);
            this.groupBoxChart.Size = new System.Drawing.Size(730, 345);
            this.groupBoxChart.Text = "Эмпирическое и теоретическое распределение числа запросов за интервал T";
            this.groupBoxChart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // panelChart
            this.panelChart.Location = new System.Drawing.Point(10, 20);
            this.panelChart.Size = new System.Drawing.Size(710, 315);
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);

            // groupBoxTable
            this.groupBoxTable.Controls.Add(this.dgvDistribution);
            this.groupBoxTable.Location = new System.Drawing.Point(345, 405);
            this.groupBoxTable.Size = new System.Drawing.Size(730, 220);
            this.groupBoxTable.Text = "Таблица распределения";
            this.groupBoxTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // dgvDistribution
            this.dgvDistribution.Location = new System.Drawing.Point(10, 20);
            this.dgvDistribution.Size = new System.Drawing.Size(710, 190);
            this.dgvDistribution.AllowUserToAddRows = false;
            this.dgvDistribution.ReadOnly = true;
            this.dgvDistribution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDistribution.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDistribution.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDistribution.Columns.Add(this.colK);
            this.dgvDistribution.Columns.Add(this.colFreq);
            this.dgvDistribution.Columns.Add(this.colTheor);

            // colK
            this.colK.HeaderText = "k (число запросов)";
            this.colK.Name = "colK";

            // colFreq
            this.colFreq.HeaderText = "P(X=k) эмпирическое";
            this.colFreq.Name = "colFreq";

            // colTheor
            this.colTheor.HeaderText = "P(X=k) теоретическое (Пуассон)";
            this.colTheor.Name = "colTheor";

            // groupBoxConclusion
            this.groupBoxConclusion.Controls.Add(this.lblConclusion);
            this.groupBoxConclusion.Location = new System.Drawing.Point(12, 405);
            this.groupBoxConclusion.Size = new System.Drawing.Size(320, 220);
            this.groupBoxConclusion.Text = "Вывод";
            this.groupBoxConclusion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // lblConclusion
            this.lblConclusion.Text = "Запустите моделирование\nдля получения вывода.";
            this.lblConclusion.Location = new System.Drawing.Point(10, 20);
            this.lblConclusion.Size = new System.Drawing.Size(300, 190);
            this.lblConclusion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConclusion.ForeColor = System.Drawing.Color.Gray;

            // lblTitle
            this.lblTitle.Text = "Лабораторная работа №8 — Пуассоновский поток. События на сервере";
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(900, 28);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxParams);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxChart);
            this.Controls.Add(this.groupBoxTable);
            this.Controls.Add(this.groupBoxConclusion);
            this.Text = "Лаб. №8 — Пуассоновский поток";
            this.MinimumSize = new System.Drawing.Size(1090, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            ((System.ComponentModel.ISupportInitialize)(this.numN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribution)).EndInit();
        }

        // Controls
        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Label lblLambda, lblT, lblN;
        private System.Windows.Forms.Label lblLambdaVal, lblTVal, lblNVal;
        private System.Windows.Forms.NumericUpDown numLambda, numT, numN;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label lblMean, lblMeanVal, lblMeanTheor, lblMeanTheorVal;
        private System.Windows.Forms.Label lblVariance, lblVarianceVal, lblVarianceTheor, lblVarianceTheorVal;
        private System.Windows.Forms.GroupBox groupBoxChart;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.GroupBox groupBoxTable;
        private System.Windows.Forms.DataGridView dgvDistribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn colK, colFreq, colTheor;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblConclusion;
        private System.Windows.Forms.GroupBox groupBoxConclusion;
    }
}