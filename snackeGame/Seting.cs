using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snackeGame
{
    public enum Direction {
        Up,Down,Right,Left
    };
    class Seting
    {
        public static int width { set; get; }
        public static int hight { set; get; }
        public static int speed { set; get; }
        public static int score { set; get; }
        public static int points { set; get; }
        public static bool gameOver { set; get; }
        public static Direction dir { set; get; }
        public  Seting()
        {
            width = 16;
            hight = 16;
            speed = 10;
            score = 0;
            points = 100;
            gameOver = false;
            dir = Direction.Down;


        }
    }
}
