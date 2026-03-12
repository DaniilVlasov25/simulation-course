using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        const int EMPTY = 0;
        const int TREE = 1;
        const int BURNING = 2;
        const int BURNED = 3;
        const int WATER = 4;

        static readonly Color COLOR_EMPTY = Color.SandyBrown;
        static readonly Color COLOR_TREE = Color.ForestGreen;
        static readonly Color COLOR_BURNING = Color.OrangeRed;
        static readonly Color COLOR_BURNED = Color.DimGray;
        static readonly Color COLOR_WATER = Color.DodgerBlue;

        int rows, cols;
        const int CELL = 8;

        int[,] grid;
        int[,] newGrid;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            cols = pictureBox1.Width / CELL;
            rows = pictureBox1.Height / CELL;

            grid = new int[rows, cols];
            newGrid = new int[rows, cols];

            double density = trackDensity.Value / 100.0;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    grid[r, c] = (rnd.NextDouble() < density) ? TREE : EMPTY;

            GenerateWater();

            grid[rows / 2, cols / 2] = BURNING;

            DrawGrid(); 
            UpdateStats();
        }

        private void GenerateWater()
        {
            for (int w = 0; w < trackWater.Value; w++)
            {
                if (rnd.NextDouble() < 0.5) GenerateRiver();
                else GenerateLake();
            }
        }

        private void GenerateRiver()
        {
            bool horizontal = rnd.NextDouble() < 0.5;
            int r = horizontal ? rnd.Next(rows) : 0;
            int c = horizontal ? 0 : rnd.Next(cols);
            int width = rnd.Next(2, 4);

            for (int step = 0; step < (horizontal ? cols : rows); step++)
            {
                if (rnd.NextDouble() < 0.3)
                {
                    if (horizontal) r += rnd.Next(-1, 2);
                    else c += rnd.Next(-1, 2);
                }

                for (int i = -width / 2; i <= width / 2; i++)
                {
                    int wr = horizontal ? r + i : r;
                    int wc = horizontal ? c : c + i;
                    if (wr >= 0 && wr < rows && wc >= 0 && wc < cols)
                        grid[wr, wc] = WATER;
                }

                if (horizontal) c++;
                else r++;
            }
        }

        private void GenerateLake()
        {
            int cr = rnd.Next(rows);
            int cc = rnd.Next(cols);
            int radius = rnd.Next(3, 9);

            for (int r = cr - radius; r <= cr + radius; r++)
                for (int c = cc - radius; c <= cc + radius; c++)
                {
                    if (r < 0 || r >= rows || c < 0 || c >= cols) continue;
                    double dist = Math.Sqrt((r - cr) * (r - cr) + (c - cc) * (c - cc));
                    if (dist <= radius * (0.7 + rnd.NextDouble() * 0.4))
                        grid[r, c] = WATER;
                }
        }

        private void Step()
        {
            double pGrow = trackGrow.Value / 1000.0;
            double pFire = trackFire.Value / 1000.0;
            double pWind = trackWind.Value / 100.0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int state = grid[r, c];

                    if (state == WATER)
                        newGrid[r, c] = WATER;
                    else if (state == BURNING)
                        newGrid[r, c] = BURNED;
                    else if (state == BURNED)
                        newGrid[r, c] = EMPTY;
                    else if (state == TREE)
                    {
                        if (HasBurningNeighbor(r, c, pWind))
                            newGrid[r, c] = BURNING;
                        else if (rnd.NextDouble() < pFire)
                            newGrid[r, c] = BURNING;
                        else
                            newGrid[r, c] = TREE;
                    }
                    else // EMPTY
                    {
                        newGrid[r, c] = (rnd.NextDouble() < pGrow) ? TREE : EMPTY;
                    }
                }
            }

            Array.Copy(newGrid, grid, grid.Length);
            DrawGrid();
            UpdateStats();
        }

        private bool HasBurningNeighbor(int r, int c, double pWind)
        {
            int[] dr = { -1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };

            for (int d = 0; d < 4; d++)
            {
                int nr = r + dr[d];
                int nc = c + dc[d];

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
                if (grid[nr, nc] == WATER) continue;
                if (grid[nr, nc] == BURNING)
                {
                    if (d == 2) return true;
                    if (rnd.NextDouble() > pWind) return true;
                }
            }
            return false;
        }

        private void DrawGrid()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(COLOR_EMPTY);
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        Color color;
                        switch (grid[r, c])
                        {
                            case TREE: color = COLOR_TREE; break;
                            case BURNING: color = COLOR_BURNING; break;
                            case BURNED: color = COLOR_BURNED; break;
                            case WATER: color = COLOR_WATER; break;
                            default: color = COLOR_EMPTY; break;
                        }
                        g.FillRectangle(new SolidBrush(color), c * CELL, r * CELL, CELL - 1, CELL - 1);
                    }
            }
            pictureBox1.Image = bmp;
        }

        private void UpdateStats()
        {
            int trees = 0, burning = 0, burned = 0, empty = 0, water = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    switch (grid[r, c])
                    {
                        case TREE: trees++; break;
                        case BURNING: burning++; break;
                        case BURNED: burned++; break;
                        case WATER: water++; break;
                        default: empty++; break;
                    }
            labStats.Text = string.Format(
                "Деревьев: {0}    Горит: {1}    Сгорело: {2}    Вода: {3}    Пусто: {4}",
                trees, burning, burned, water, empty);
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) { timer1.Stop(); btStart.Text = "Старт"; }
            else { timer1.Interval = trackSpeed.Value; timer1.Start(); btStart.Text = "Стоп"; }
        }

        private void btStep_Click(object sender, EventArgs e) { Step(); }

        private void btReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btStart.Text = "Старт";
            InitGrid();
        }

        private void timer1_Tick(object sender, EventArgs e) { Step(); }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int c = e.X / CELL;
            int r = e.Y / CELL;
            if (r < 0 || r >= rows || c < 0 || c >= cols) return;

            if (e.Button == MouseButtons.Left) grid[r, c] = BURNING;
            else if (e.Button == MouseButtons.Right) grid[r, c] = WATER;
            else if (e.Button == MouseButtons.Middle) grid[r, c] = TREE;

            DrawGrid();
            UpdateStats();
        }

        private void trackSpeed_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackSpeed.Value;
            labSpeed.Text = "Скорость: " + trackSpeed.Value + " мс";
        }
    }
}