namespace lab6
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
            this.lblProb1 = new System.Windows.Forms.Label();
            this.lblProb2 = new System.Windows.Forms.Label();
            this.lblProb3 = new System.Windows.Forms.Label();
            this.lblProb4 = new System.Windows.Forms.Label();
            this.lblProb5 = new System.Windows.Forms.Label();
            this.txtProb1 = new System.Windows.Forms.TextBox();
            this.txtProb2 = new System.Windows.Forms.TextBox();
            this.txtProb3 = new System.Windows.Forms.TextBox();
            this.txtProb4 = new System.Windows.Forms.TextBox();
            this.txtProb5 = new System.Windows.Forms.TextBox();
            this.btnAutoProb = new System.Windows.Forms.Button();
            this.lblNumExperiments = new System.Windows.Forms.Label();
            this.txtNumExperiments = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chartPanel = new System.Windows.Forms.PictureBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblFrequencies = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(16, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(643, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Моделирование дискретной случайной величины";
            // 
            // lblProb1
            // 
            this.lblProb1.AutoSize = true;
            this.lblProb1.Location = new System.Drawing.Point(16, 62);
            this.lblProb1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProb1.Name = "lblProb1";
            this.lblProb1.Size = new System.Drawing.Size(77, 16);
            this.lblProb1.TabIndex = 1;
            this.lblProb1.Text = "Prob 1 (x=1)";
            // 
            // lblProb2
            // 
            this.lblProb2.AutoSize = true;
            this.lblProb2.Location = new System.Drawing.Point(16, 98);
            this.lblProb2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProb2.Name = "lblProb2";
            this.lblProb2.Size = new System.Drawing.Size(77, 16);
            this.lblProb2.TabIndex = 2;
            this.lblProb2.Text = "Prob 2 (x=2)";
            // 
            // lblProb3
            // 
            this.lblProb3.AutoSize = true;
            this.lblProb3.Location = new System.Drawing.Point(16, 135);
            this.lblProb3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProb3.Name = "lblProb3";
            this.lblProb3.Size = new System.Drawing.Size(77, 16);
            this.lblProb3.TabIndex = 3;
            this.lblProb3.Text = "Prob 3 (x=3)";
            // 
            // lblProb4
            // 
            this.lblProb4.AutoSize = true;
            this.lblProb4.Location = new System.Drawing.Point(16, 172);
            this.lblProb4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProb4.Name = "lblProb4";
            this.lblProb4.Size = new System.Drawing.Size(77, 16);
            this.lblProb4.TabIndex = 4;
            this.lblProb4.Text = "Prob 4 (x=4)";
            // 
            // lblProb5
            // 
            this.lblProb5.AutoSize = true;
            this.lblProb5.Location = new System.Drawing.Point(16, 209);
            this.lblProb5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProb5.Name = "lblProb5";
            this.lblProb5.Size = new System.Drawing.Size(77, 16);
            this.lblProb5.TabIndex = 5;
            this.lblProb5.Text = "Prob 5 (x=5)";
            // 
            // txtProb1
            // 
            this.txtProb1.Location = new System.Drawing.Point(160, 58);
            this.txtProb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProb1.Name = "txtProb1";
            this.txtProb1.Size = new System.Drawing.Size(132, 22);
            this.txtProb1.TabIndex = 6;
            // 
            // txtProb2
            // 
            this.txtProb2.Location = new System.Drawing.Point(160, 95);
            this.txtProb2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProb2.Name = "txtProb2";
            this.txtProb2.Size = new System.Drawing.Size(132, 22);
            this.txtProb2.TabIndex = 7;
            // 
            // txtProb3
            // 
            this.txtProb3.Location = new System.Drawing.Point(160, 132);
            this.txtProb3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProb3.Name = "txtProb3";
            this.txtProb3.Size = new System.Drawing.Size(132, 22);
            this.txtProb3.TabIndex = 8;
            // 
            // txtProb4
            // 
            this.txtProb4.Location = new System.Drawing.Point(160, 169);
            this.txtProb4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProb4.Name = "txtProb4";
            this.txtProb4.Size = new System.Drawing.Size(132, 22);
            this.txtProb4.TabIndex = 9;
            // 
            // txtProb5
            // 
            this.txtProb5.Location = new System.Drawing.Point(160, 206);
            this.txtProb5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProb5.Name = "txtProb5";
            this.txtProb5.Size = new System.Drawing.Size(132, 22);
            this.txtProb5.TabIndex = 10;
            // 
            // btnAutoProb
            // 
            this.btnAutoProb.Location = new System.Drawing.Point(307, 203);
            this.btnAutoProb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAutoProb.Name = "btnAutoProb";
            this.btnAutoProb.Size = new System.Drawing.Size(100, 28);
            this.btnAutoProb.TabIndex = 11;
            this.btnAutoProb.Text = "auto";
            this.btnAutoProb.UseVisualStyleBackColor = true;
            this.btnAutoProb.Click += new System.EventHandler(this.btnAutoProb_Click);
            // 
            // lblNumExperiments
            // 
            this.lblNumExperiments.AutoSize = true;
            this.lblNumExperiments.Location = new System.Drawing.Point(16, 258);
            this.lblNumExperiments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumExperiments.Name = "lblNumExperiments";
            this.lblNumExperiments.Size = new System.Drawing.Size(166, 16);
            this.lblNumExperiments.TabIndex = 12;
            this.lblNumExperiments.Text = "Number of experiments (N)";
            // 
            // txtNumExperiments
            // 
            this.txtNumExperiments.Location = new System.Drawing.Point(205, 255);
            this.txtNumExperiments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumExperiments.Name = "txtNumExperiments";
            this.txtNumExperiments.Size = new System.Drawing.Size(132, 22);
            this.txtNumExperiments.TabIndex = 13;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(20, 308);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 43);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(228, 314);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chartPanel
            // 
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Location = new System.Drawing.Point(442, 62);
            this.chartPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(920, 430);
            this.chartPanel.TabIndex = 16;
            this.chartPanel.TabStop = false;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResults.Location = new System.Drawing.Point(16, 382);
            this.lblResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(292, 18);
            this.lblResults.TabIndex = 17;
            this.lblResults.Text = "Нажмите Start для начала эксперимента";
            // 
            // lblFrequencies
            // 
            this.lblFrequencies.AutoSize = true;
            this.lblFrequencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFrequencies.Location = new System.Drawing.Point(16, 640);
            this.lblFrequencies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrequencies.Name = "lblFrequencies";
            this.lblFrequencies.Size = new System.Drawing.Size(69, 17);
            this.lblFrequencies.TabIndex = 18;
            this.lblFrequencies.Text = "Частоты:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 825);
            this.Controls.Add(this.lblFrequencies);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtNumExperiments);
            this.Controls.Add(this.lblNumExperiments);
            this.Controls.Add(this.btnAutoProb);
            this.Controls.Add(this.txtProb5);
            this.Controls.Add(this.txtProb4);
            this.Controls.Add(this.txtProb3);
            this.Controls.Add(this.txtProb2);
            this.Controls.Add(this.txtProb1);
            this.Controls.Add(this.lblProb5);
            this.Controls.Add(this.lblProb4);
            this.Controls.Add(this.lblProb3);
            this.Controls.Add(this.lblProb2);
            this.Controls.Add(this.lblProb1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Лабораторная 6.1 - Моделирование ДСВ";
            ((System.ComponentModel.ISupportInitialize)(this.chartPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProb1;
        private System.Windows.Forms.Label lblProb2;
        private System.Windows.Forms.Label lblProb3;
        private System.Windows.Forms.Label lblProb4;
        private System.Windows.Forms.Label lblProb5;
        private System.Windows.Forms.TextBox txtProb1;
        private System.Windows.Forms.TextBox txtProb2;
        private System.Windows.Forms.TextBox txtProb3;
        private System.Windows.Forms.TextBox txtProb4;
        private System.Windows.Forms.TextBox txtProb5;
        private System.Windows.Forms.Button btnAutoProb;
        private System.Windows.Forms.Label lblNumExperiments;
        private System.Windows.Forms.TextBox txtNumExperiments;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox chartPanel;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblFrequencies;
    }
}