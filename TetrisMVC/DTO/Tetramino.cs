using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TetrisMVC.DTO
{
    public class Tetramino
    {
        private Point curPosition;
        private Point[] curShape;
        private Brush curColor;
        private bool rotate;
        public Tetramino()
        {
            curPosition = new Point(0, 0);
            curColor = Brushes.Transparent;
            curShape = setRandomShape();
        }
        public Brush getCurColor()
        {
            return curColor;
        }
        public Point getCurPosition()
        {
            return curPosition;
        }
        public Point[] getCurShape()
        {
            return curShape;
        }
        public void moveLeft()
        {
            curPosition.X -= 1;
        }
        public void moveRight()
        {
            curPosition.X += 1;
        }
        public void moveDown()
        {
            curPosition.Y += 1;
        }
        public void moveRotate()
        {
            if (rotate)
            {
                for (int i = 0; i < curShape.Length; i++)
                {
                    double x = curShape[i].X;
                    curShape[i].X = curShape[i].Y * (-1);
                    curShape[i].Y = x;
                }
            }
        }
        private Point[] setRandomShape()
        {
            Random rand = new Random();
            switch (rand.Next() % 6)
            {
                case 0:     //I
                    rotate = true;
                    curColor = Brushes.Cyan;
                    return new Point[]
                    {
                            new Point(0,0),
                            new Point(-1,0),
                            new Point(1,0),
                            new Point(2,0)
                    };
                case 1:     //J
                    rotate = true;
                    curColor = Brushes.Blue;
                    return new Point[]
                    {
                            new Point(-1, 0),
                            new Point(0, 0),
                            new Point(0, 1),
                            new Point(0, 2)
                    };
                case 2:     //L
                    rotate = true;
                    curColor = Brushes.Orange;
                    return new Point[]
                    {
                            new Point(0, 2),
                            new Point(0, 1),
                            new Point(0, 0),
                            new Point(1, 0)
                    };
                case 3:     //O
                    rotate = false;
                    curColor = Brushes.Yellow;
                    return new Point[]
                    {
                            new Point(0,0),
                            new Point(0,1),
                            new Point(1,0),
                            new Point(1,1)
                    };
                case 4:     //T
                    rotate = true;
                    curColor = Brushes.Purple;
                    return new Point[]
                    {
                            new Point(0,0),
                            new Point(-1,0),
                            new Point(0,-1),
                            new Point(1, 0)
                    };
                case 5:     //Z
                    rotate = true;
                    curColor = Brushes.Red;
                    return new Point[]
                    {
                            new Point(0,0),
                            new Point(-1,0),
                            new Point(0,1),
                            new Point(1,1)
                    };
                default:
                    return null;
            }
        }
    }
}
