using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snackeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();

        public Form1()
        {
            
            InitializeComponent();
            new Seting();
            gameTimer.Interval = 1000 / Seting.speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            StartGame();
        }

        private void UpdateScreen(object sender,EventArgs e)
        {

            if (Seting.gameOver == true)
            {


                if (Input.keyPress(Keys.Enter))
                {
                    StartGame();
                }

            }
            else
            {

                if (Input.keyPress(Keys.Right) && Seting.dir != Direction.Left)
                    Seting.dir = Direction.Right;
                else if (Input.keyPress(Keys.Left) && Seting.dir != Direction.Right)
                    Seting.dir = Direction.Left;
                else if (Input.keyPress(Keys.Up) && Seting.dir != Direction.Down)
                    Seting.dir = Direction.Up;
                else if (Input.keyPress(Keys.Down) && Seting.dir != Direction.Up)
                    Seting.dir = Direction.Down;

                movePlayer();
            }
            pictureBox1.Invalidate();
        }

        private void StartGame()
        {
            label3.Visible = false;
            new Seting();
            snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            snake.Add(head);
            label2.Text = Seting.score.ToString();
            GenreateFood();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics canv = e.Graphics;
            Brush snakecolor;
            if (Seting.gameOver == false) {
                for (int i = 0; i < snake.Count; i++) {
                    if (i == 0)
                        snakecolor = Brushes.Blue;
                    else
                        
                        snakecolor = Brushes.Black;
                    canv.FillEllipse(snakecolor, new Rectangle(snake[i].X*Seting.width,snake[i].Y*Seting.hight,Seting.width,Seting.hight));
                    canv.FillEllipse(Brushes.Red, new Rectangle(food.X * Seting.width, food.Y * Seting.hight, Seting.width, Seting.hight));

                }
            }
            else {
                ///create message game over
                string s = "GAME OVER!!!!!\n" + Seting.score + "\nPRESS ENTER TO GET ANOTHER GAME";
                label3.Text = s;
                label3.Visible = true;
            }
        }
        private void movePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Seting.dir)
                    {
                        case Direction.Right:
                            snake[i].X++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;
                            break;



                    }
                    int maxXpos = pictureBox1.Size.Width / Seting.width;
                    int maxYPos = pictureBox1.Size.Height / Seting.hight;

                    if (snake[i].X == -1 || snake[i].Y == -1 || snake[i].X == maxXpos+1 || snake[i].Y == maxYPos+1)
                    { Die(); }

                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[j].X == snake[i].X && snake[j].Y == snake[i].Y)
                            Die();
                    }
                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        eat();

                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;

                }
                
            }
        }

        private void Die()
        {
            Seting.gameOver = true;
        }

        private void eat()
        {
            Circle C = new Circle { X = snake[snake.Count - 1].X, Y = snake[snake.Count - 1].Y };
            snake.Add(C);
            Seting.score += Seting.points;
            label2.Text = Seting.score.ToString();
            GenreateFood();
        }

        private void GenreateFood()
        {
            int maxXPos = pictureBox1.Size.Width / Seting.width;
            int maxYPos = pictureBox1.Size.Height / Seting.hight;
            Random ran = new Random();
            food = new Circle();
            food.X = ran.Next(0, maxXPos);
            food.Y = ran.Next(0, maxYPos);



        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
    }
}
