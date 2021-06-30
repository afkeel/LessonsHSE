using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
        private Snake snake;
        private SolidBrush blackBrush;
        private SolidBrush greenBrush;
        private SolidBrush whiteBrush;
        private Point apple;
        private Random rnd;
        private Pen grayPen;
        private Pen blackPen;
        private int width;
        private int height;
        
        public MainForm()
        {            
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            snake = new Snake();
            width = pictureBox1.Width/10;
            height = pictureBox1.Height/10;
            snake.Point[0].X = width / 2;
            snake.Point[0].Y = height / 2;
            whiteBrush = new SolidBrush(Color.White);
            greenBrush = new SolidBrush(Color.Green);
            blackBrush = new SolidBrush(Color.Black);
            grayPen = new Pen(Color.LightGray);
            blackPen = new Pen(Color.Black,3);
            rnd = new Random();
            apple.X = rnd.Next(0, width - 1);
            apple.Y = rnd.Next(0, height - 1);
        }
        private void Map(ref Graphics g)
        {
            g.FillRectangle(whiteBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < width; i++)
            {
                g.DrawLine(grayPen, i * 10, 0, i * 10, height * 10);
            }
            for (int i = 0; i < height; i++)
            {
                g.DrawLine(grayPen, 0, i * 10, width * 10, i * 10);
            }
            g.DrawRectangle(blackPen, 0, 0, width * 10, height * 10);
        }
        private void NewGame()
        {
            snake.ClearPoint();
            snake.Lenght = Snake.startLenght;
            snake.Point[0].X = width / 2;
            snake.Point[0].Y = height / 2;
            apple.X = rnd.Next(0, width - 1);
            apple.Y = rnd.Next(0, height - 1);
        }
        private bool GameOver(ref int i, ref int j)
        {
            return snake.Point[i].X == snake.Point[j].X 
                && snake.Point[i].Y == snake.Point[j].Y;
        }
        private void CheckSnakeCrash()
        {
            if (snake.Lenght > 4)
            {
                for (int i = 0; i < snake.Lenght; i++)
                {
                    for (int j = i + 1; j < snake.Lenght; j++)
                    {
                        if (GameOver(ref i, ref j))
                        {
                            var result = MessageBox.Show(
                                            "Вы проиграли! Начать новую игру?",
                                            Text,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information,
                                            MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.DefaultDesktopOnly);
                            if (result == DialogResult.Yes) { NewGame(); }
                            else { Application.Exit(); }                           
                        }
                    }
                }        
            }
        }
        private bool AppleEat()
        {
            return apple.X == snake.Point[0].X && apple.Y == snake.Point[0].Y;
        }
        private void MakeSnake(ref Graphics g)
        {
            int tempLen = snake.Lenght;
            for (int i = 0; i < tempLen; i++)
            {
                if (snake.Point[i].X < 0) snake.Point[i].X += width;
                if (snake.Point[i].X >= width) snake.Point[i].X -= width;
                if (snake.Point[i].Y < 0) snake.Point[i].Y += height;
                if (snake.Point[i].Y >= height) snake.Point[i].Y -= height;
                g.FillEllipse(blackBrush, snake.Point[i].X * 10, snake.Point[i].Y * 10, 10, 10);
                if(AppleEat())
                {
                    //WMPLib.WindowsMediaPlayer wmplayer = new WMPLib.WindowsMediaPlayer();
                    //wmplayer.URL = "eat.mp3";
                    //wmplayer.controls.play();
                    apple.X = 0/*rnd.Next(0, width - 1)*/;
                    apple.Y = 0/*rnd.Next(0, height - 1)*/;
                    snake.Lenght++;
                    infoControl1.PlayerScore = 10;
                }               
            }
            CheckSnakeCrash();           
        }
        private void MakeApple(ref Graphics g)
        {
            g.FillEllipse(greenBrush, apple.X * 10, apple.Y * 10, 10, 10);
        }
        private void MoveSnake()
        {
            if (snake.Lenght < Snake.startLenght) snake.Lenght++;
            for (int i = snake.Lenght - 1; i > 0; i--)
            {
                snake.Point[i].X = snake.Point[i-1].X;
                snake.Point[i].Y = snake.Point[i-1].Y;
            }
            if (snake.Direct == Snake.Direction.UP) snake.Point[0].Y -= 1;
            if (snake.Direct == Snake.Direction.DOWN) snake.Point[0].Y += 1;
            if (snake.Direct == Snake.Direction.LEFT) snake.Point[0].X -= 1;
            if (snake.Direct == Snake.Direction.RIGHT) snake.Point[0].X += 1;
            if (snake.Lenght > Snake.maxLenght)
            {
                snake.Lenght = Snake.maxLenght;
            }            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {           
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Map(ref g);            
            MakeSnake(ref g);
            MakeApple(ref g);
            MoveSnake();           
            pictureBox1.Invalidate();           
        }        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval < 21) timer1.Interval = 21;
            timer1.Interval -= 20;
            infoControl1.PlayerLvl = 1;
        }
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutSnake();
            f.ShowDialog();
        }
        private void новаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            timer2.Enabled = !timer2.Enabled;
            if (timer1.Enabled) { button1.Text = "Pause"; }
            else { button1.Text = "Start"; }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (snake.Direct != Snake.Direction.DOWN)
                    {
                        snake.Direct = Snake.Direction.UP;
                    }                   
                    break;
                case Keys.S:
                    if (snake.Direct != Snake.Direction.UP)
                    {
                        snake.Direct = Snake.Direction.DOWN;
                    }
                    break;
                case Keys.A:
                    if (snake.Direct != Snake.Direction.RIGHT)
                    {
                        snake.Direct = Snake.Direction.LEFT;
                    }
                    break;
                case Keys.D:
                    if (snake.Direct != Snake.Direction.LEFT)
                    {
                        snake.Direct = Snake.Direction.RIGHT;
                    }
                    break;
            }
        }
    }
}