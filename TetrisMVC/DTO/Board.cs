using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TetrisMVC.BusinessLayer;

namespace TetrisMVC.DTO
{
    public class Board
    {
        private int row;
        private int col;
        private int score;
        private int lineFilled;
        private Tetramino curTetramino;
        private System.Windows.Controls.Label[,] blockControl;

        HandlePlaying handlePlaying = new HandlePlaying();


        //xoa static, chuyen private thanh public
         public Brush NoBrush = Brushes.Transparent;
         public Brush SiverBrush = Brushes.Gray;

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public int LineFilled { get => lineFilled; set => lineFilled = value; }
        public System.Windows.Controls.Label[,] BlockControl { get => blockControl; set => blockControl = value; }
        public int Score { get => score; set => score = value; }
        public int LineFilled1 { get => lineFilled; set => lineFilled = value; }

        public Board(Grid TetrisGrid)
        {
            row = TetrisGrid.RowDefinitions.Count;
            col = TetrisGrid.ColumnDefinitions.Count;
            score = 0;
            lineFilled = 0;

            blockControl = new System.Windows.Controls.Label[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    blockControl[i, j] = new System.Windows.Controls.Label();
                    blockControl[i, j].Background = NoBrush;
                    blockControl[i, j].BorderBrush = SiverBrush;
                    blockControl[i, j].BorderThickness = new Thickness(1, 1, 1, 1);
                    Grid.SetRow(blockControl[i, j], j);
                    Grid.SetColumn(blockControl[i, j], i);
                    TetrisGrid.Children.Add(blockControl[i, j]);
                }
            }
            curTetramino = new Tetramino();
            curTetraminoDraw();
        }
        public int getScore()
        {
            return score;
        }
        public int getLine()
        {
            return lineFilled;
        }
        private void curTetraminoDraw()
        {
            Point position = curTetramino.getCurPosition();
            Point[] shape = curTetramino.getCurShape();
            Brush color = curTetramino.getCurColor();
            foreach (Point S in shape)
            {
                blockControl[(int)(S.X + position.X) + ((col / 2) - 1), (int)(S.Y + position.Y) + 2].Background = color;
            }
        }
        private void curTetraminoErase()
        {
            Point position = curTetramino.getCurPosition();
            Point[] shape = curTetramino.getCurShape();
            foreach (Point S in shape)
            {
                blockControl[(int)(S.X + position.X) + ((col / 2) - 1), (int)(S.Y + position.Y) + 2].Background = NoBrush;
            }
        }

        //private void CheckRow()
        //{
        //    bool full;
        //    for (int i = row - 1; i > 0; i--)
        //    {
        //        full = true;
        //        for (int j = 0; j < col; j++)
        //        {
        //            if (blockControl[j, i].Background == NoBrush)
        //            {
        //                full = false;
        //            }
        //        }
        //        if (full)
        //        {
        //            RemoveRow(i);
        //            score += 10;
        //            lineFilled += 1;
        //        }
        //    }
        //}
        //private void RemoveRow(int row)
        //{
        //    for (int i = row; i > 2; i--)
        //    {
        //        for (int j = 0; j < col; j++)
        //        {
        //            blockControl[j, i].Background = blockControl[j, i - 1].Background;
        //        }
        //    }
        //}

        public void CurTetraminoMoveLeft()
        {
            Point position = curTetramino.getCurPosition();
            Point[] shape = curTetramino.getCurShape();
            bool move = true;
            curTetraminoErase();
            foreach (Point S in shape)
            {
                if (((int)(S.X + position.X) + ((col / 2) - 1) - 1) < 0)
                {
                    move = false;
                }
                else if (blockControl[((int)(S.X + position.X) + ((col / 2) - 1) - 1), (int)(S.Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                curTetramino.moveLeft();
                curTetramino.moveDown();
            }
            else
            {
                curTetraminoDraw();
            }
        }
        public void CurTetraminoMoveRight()
        {
            Point position = curTetramino.getCurPosition();
            Point[] shape = curTetramino.getCurShape();
            bool move = true;
            curTetraminoErase();
            foreach (Point S in shape)
            {
                if (((int)(S.X + position.X) + ((col / 2) - 1) + 1) >= col)
                {
                    move = false;
                }
                else if (blockControl[((int)(S.X + position.X) + ((col / 2) - 1) + 1), (int)(S.Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                curTetramino.moveRight();
                curTetramino.moveDown();
            }
            else
            {
                curTetraminoDraw();
            }
        }
        public void CurTetraminoMoveDown()
        {
            Point position = curTetramino.getCurPosition();
            Point[] shape = curTetramino.getCurShape();
            bool move = true;
            curTetraminoErase();
            foreach (Point S in shape)
            {
                if (((int)(S.Y + position.Y) + 2 + 1) >= row)
                {
                    move = false;
                }
                else if (blockControl[((int)(S.X + position.X) + ((col / 2) - 1)), (int)(S.Y + position.Y) + 2 + 1].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                curTetramino.moveDown();
                curTetraminoDraw();
            }
            else
            {
                curTetraminoDraw();
                handlePlaying.CheckRow(this);
                curTetramino = new Tetramino();
            }
        }
        public void CurTetraminoMoveRotate()
        {
            Point position = curTetramino.getCurPosition();
            Point[] S = new Point[4];
            Point[] shape = curTetramino.getCurShape();
            bool move = true;
            shape.CopyTo(S, 0);
            curTetraminoErase();
            for (int i = 0; i < S.Length; i++)
            {
                double x = S[i].X;
                S[i].X = S[i].Y - 1;
                S[i].Y = x;
                if (((int)((S[i].Y + position.Y) + 2)) >= row)
                {
                    move = false;
                }
                else if (((int)(S[i].X + position.X) + ((col / 2) - 1)) < 0)
                {
                    move = false;
                }
                else if (((int)(S[i].X + position.X) + ((col / 2) - 1)) >= row)
                {
                    move = false;
                }
                else if (blockControl[((int)(S[i].X + position.X) + ((col / 2) - 1)), (int)(S[i].Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                curTetramino.moveRotate();
                curTetraminoDraw();
            }
            else
            {
                curTetraminoDraw();
            }
        }
    }
}
