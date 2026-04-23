namespace lab6_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.lblSampleSize = new System.Windows.Forms.Label();
            this.txtMean = new System.Windows.Forms.TextBox();
            this.txtVariance = new System.Windows.Forms.TextBox();
            this.txtSampleSize = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chartPanel = new System.Windows.Forms.PictureBox();
            this.lblResults = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(485, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Моделирование нормального распределения";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMean.Location = new System.Drawing.Point(15, 60);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(96, 17);
            this.lblMean.TabIndex = 1;
            this.lblMean.Text = "Mean (a) = ";
            // 
            // lblVariance
            // 
            this.lblVariance.AutoSize = true;
            this.lblVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVariance.Location = new System.Drawing.Point(15, 100);
            this.lblVariance.Name = "lblVariance";
            this.lblVariance.Size = new System.Drawing.Size(135, 17);
            this.lblVariance.TabIndex = 2;
            this.lblVariance.Text = "Variance (σ²) = ";
            // 
            // lblSampleSize
            // 
            this.lblSampleSize.AutoSize = true;
            this.lblSampleSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSampleSize.Location = new System.Drawing.Point(15, 140);
            this.lblSampleSize.Name = "lblSampleSize";
            this.lblSampleSize.Size = new System.Drawing.Size(147, 17);
            this.lblSampleSize.TabIndex = 3;
            this.lblSampleSize.Text = "Sample size (N) = ";
            // 
            // txtMean
            // 
            this.txtMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMean.Location = new System.Drawing.Point(168, 57);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new System.Drawing.Size(120, 23);
            this.txtMean.TabIndex = 4;
            this.txtMean.Text = "0";
            // 
            // txtVariance
            // 
            this.txtVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtVariance.Location = new System.Drawing.Point(168, 97);
            this.txtVariance.Name = "txtVariance";
            this.txtVariance.Size = new System.Drawing.Size(120, 23);
            this.txtVariance.TabIndex = 5;
            this.txtVariance.Text = "1";
            // 
            // txtSampleSize
            // 
            this.txtSampleSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSampleSize.Location = new System.Drawing.Point(168, 137);
            this.txtSampleSize.Name = "txtSampleSize";
            this.txtSampleSize.Size = new System.Drawing.Size(120, 23);
            this.txtSampleSize.TabIndex = 6;
            this.txtSampleSize.Text = "1000";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(18, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 40);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chartPanel
            // 
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Location = new System.Drawing.Point(350, 50);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(500, 350);
            this.chartPanel.TabIndex = 8;
            this.chartPanel.TabStop = false;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResults.Location = new System.Drawing.Point(15, 240);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(300, 250);
            this.lblResults.TabIndex = 9;
            this.lblResults.Text = "Нажмите Start для начала эксперимента\r\n\r\nПример результатов:\r\nAverage: 2.897 (error = 8%)\r\nVariance: 2.072 (error = 9%)\r\nChi-squared: 13.51 > 11.07 is true";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 520);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtSampleSize);
            this.Controls.Add(this.txtVariance);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.lblSampleSize);
            this.Controls.Add(this.lblVariance);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Лабораторная 6.2 - Моделирование нормального распределения";
            ((System.ComponentModel.ISupportInitialize)(this.chartPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label lblVariance;
        private System.Windows.Forms.Label lblSampleSize;
        private System.Windows.Forms.TextBox txtMean;
        private System.Windows.Forms.TextBox txtVariance;
        private System.Windows.Forms.TextBox txtSampleSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox chartPanel;
        private System.Windows.Forms.Label lblResults;
    }
}