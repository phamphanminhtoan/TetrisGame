using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisMVC.DTO;

namespace TetrisMVC.BusinessLayer
{
    public class HandlePlaying
    {
        public void CheckRow(Board board)
        {
            bool full;
            for (int i = board.Row - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < board.Col; j++)
                {
                    if (board.BlockControl[j, i].Background == board.NoBrush)
                    {
                        full = false;
                    }
                }
                if (full)
                {
                    RemoveRow(board);
                    board.Score += 10;
                    board.LineFilled += 1;
                }
            }
        }
        private void RemoveRow(Board board)
        {
            for (int i = board.Row; i > 2; i--)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    board.BlockControl[j, i].Background = board.BlockControl[j, i - 1].Background;
                }
            }
        }
    }
}
