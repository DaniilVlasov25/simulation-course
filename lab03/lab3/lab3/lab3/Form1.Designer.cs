namespace lab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.btStep = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            this.trackDensity = new System.Windows.Forms.TrackBar();
            this.trackGrow = new System.Windows.Forms.TrackBar();
            this.trackFire = new System.Windows.Forms.TrackBar();
            this.trackWater = new System.Windows.Forms.TrackBar();
            this.trackWind = new System.Windows.Forms.TrackBar();
            this.labStats = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labBasic = new System.Windows.Forms.Label();
            this.labExtra = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWind)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SandyBrown;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(668, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(120, 32);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Старт";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStep
            // 
            this.btStep.Location = new System.Drawing.Point(668, 52);
            this.btStep.Name = "btStep";
            this.btStep.Size = new System.Drawing.Size(120, 32);
            this.btStep.TabIndex = 2;
            this.btStep.Text = "Шаг";
            this.btStep.Click += new System.EventHandler(this.btStep_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(668, 92);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(120, 32);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "Сброс";
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // trackSpeed
            // 
            this.trackSpeed.Location = new System.Drawing.Point(663, 153);
            this.trackSpeed.Maximum = 1000;
            this.trackSpeed.Minimum = 50;
            this.trackSpeed.Name = "trackSpeed";
            this.trackSpeed.Size = new System.Drawing.Size(130, 56);
            this.trackSpeed.TabIndex = 5;
            this.trackSpeed.TickFrequency = 100;
            this.trackSpeed.Value = 100;
            this.trackSpeed.Scroll += new System.EventHandler(this.trackSpeed_Scroll);
            // 
            // trackDensity
            // 
            this.trackDensity.Location = new System.Drawing.Point(663, 246);
            this.trackDensity.Maximum = 90;
            this.trackDensity.Minimum = 10;
            this.trackDensity.Name = "trackDensity";
            this.trackDensity.Size = new System.Drawing.Size(130, 56);
            this.trackDensity.TabIndex = 8;
            this.trackDensity.TickFrequency = 10;
            this.trackDensity.Value = 60;
            // 
            // trackGrow
            // 
            this.trackGrow.Location = new System.Drawing.Point(663, 316);
            this.trackGrow.Maximum = 20;
            this.trackGrow.Name = "trackGrow";
            this.trackGrow.Size = new System.Drawing.Size(130, 56);
            this.trackGrow.TabIndex = 10;
            this.trackGrow.TickFrequency = 2;
            this.trackGrow.Value = 5;
            // 
            // trackFire
            // 
            this.trackFire.Location = new System.Drawing.Point(663, 411);
            this.trackFire.Name = "trackFire";
            this.trackFire.Size = new System.Drawing.Size(130, 56);
            this.trackFire.TabIndex = 13;
            this.trackFire.Value = 1;
            // 
            // trackWater
            // 
            this.trackWater.Location = new System.Drawing.Point(663, 481);
            this.trackWater.Name = "trackWater";
            this.trackWater.Size = new System.Drawing.Size(130, 56);
            this.trackWater.TabIndex = 15;
            this.trackWater.Value = 3;
            // 
            // trackWind
            // 
            this.trackWind.Location = new System.Drawing.Point(663, 551);
            this.trackWind.Maximum = 90;
            this.trackWind.Name = "trackWind";
            this.trackWind.Size = new System.Drawing.Size(130, 56);
            this.trackWind.TabIndex = 17;
            this.trackWind.TickFrequency = 10;
            // 
            // labStats
            // 
            this.labStats.Font = new System.Drawing.Font("Consolas", 9F);
            this.labStats.Location = new System.Drawing.Point(12, 520);
            this.labStats.Name = "labStats";
            this.labStats.Size = new System.Drawing.Size(640, 20);
            this.labStats.TabIndex = 19;
            this.labStats.Text = "Деревьев: —    Горит: —    Сгорело: —    Вода: —    Пусто: —";
            // 
            // labSpeed
            // 
            this.labSpeed.Location = new System.Drawing.Point(668, 135);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(140, 18);
            this.labSpeed.TabIndex = 4;
            this.labSpeed.Text = "Скорость: 100 мс";
            // 
            // labBasic
            // 
            this.labBasic.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labBasic.ForeColor = System.Drawing.Color.DarkGreen;
            this.labBasic.Location = new System.Drawing.Point(663, 205);
            this.labBasic.Name = "labBasic";
            this.labBasic.Size = new System.Drawing.Size(145, 18);
            this.labBasic.TabIndex = 6;
            this.labBasic.Text = "── ОСНОВНЫЕ ПРАВИЛА ──";
            // 
            // labExtra
            // 
            this.labExtra.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labExtra.ForeColor = System.Drawing.Color.DarkRed;
            this.labExtra.Location = new System.Drawing.Point(663, 366);
            this.labExtra.Name = "labExtra";
            this.labExtra.Size = new System.Drawing.Size(145, 18);
            this.labExtra.TabIndex = 11;
            this.labExtra.Text = "── ДОППР. ПРАВИЛА ──";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(668, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Плотность леса (%):";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(668, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Рост деревьев (x0.001):";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(668, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Молния (x0.001):";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(668, 463);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Водоёмы (кол-во):";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(668, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ветер вправо (%):";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(12, 500);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "ЛКМ — огонь   ПКМ — вода   СКМ — дерево";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(940, 682);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btStep);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.trackSpeed);
            this.Controls.Add(this.labBasic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackDensity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackGrow);
            this.Controls.Add(this.labExtra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackFire);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackWater);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackWind);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labStats);
            this.Name = "Form1";
            this.Text = "Лабораторная 3 — Лесные пожары";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackWind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStep;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.TrackBar trackSpeed;
        private System.Windows.Forms.TrackBar trackDensity;
        private System.Windows.Forms.TrackBar trackGrow;
        private System.Windows.Forms.TrackBar trackFire;
        private System.Windows.Forms.TrackBar trackWater;
        private System.Windows.Forms.TrackBar trackWind;
        private System.Windows.Forms.Label labStats;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labBasic;
        private System.Windows.Forms.Label labExtra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}