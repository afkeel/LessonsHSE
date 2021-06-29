using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public const int maxLenght = 50;
        public const int startLenght = 3;
        public Point[] Point { get; set;}
        public int Lenght { get; set; }
        public Direction Direct { get; set; }
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        };
        public Snake()
        {
            Point = new Point[maxLenght+1];
            Lenght = 1;
        }
        public void ClearPoint()
        {
            Array.Clear(Point, 0, Point.Length);
        }
    }
}
