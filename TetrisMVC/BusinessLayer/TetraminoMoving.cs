using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using TetrisMVC.Controller;
using TetrisMVC.DTO;

namespace TetrisMVC.BusinessLayer
{
    public class TetraminoMoving
    {
        private Tetramino tetramino;

        public TetraminoMoving(Tetramino tetramino)
        {
            this.tetramino = tetramino;
        }


        // Hàm xoay khối 
        public void shapeRotation(ref int _rotation, int currentShapeNumber,ref int[,] currentTetromino)
        {
            if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("I_") == 0)
            {
                if (_rotation > 90) { _rotation = 0; }
                currentTetromino = tetramino.getVariableByString("I_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("T_") == 0)
            {
                currentTetromino = tetramino.getVariableByString("T_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("S_") == 0)
            {
                if (_rotation > 90) { _rotation = 0; }
                currentTetromino = tetramino.getVariableByString("S_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("Z_") == 0)
            {
                if (_rotation > 90) { _rotation = 0; }
                currentTetromino = tetramino.getVariableByString("Z_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("J_") == 0)
            {
                currentTetromino = tetramino.getVariableByString("J_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("L_") == 0)
            {
                currentTetromino = tetramino.getVariableByString("L_Tetromino_" + _rotation);
            }
            else if (tetramino.getArrayTetrominos()[currentShapeNumber].IndexOf("O_") == 0) // Do not rotate this
            {
                return;
            }

        }

        // Hàm dừng khối
        public void shapeStoped(Grid MainGrid, int downPos)
        {
            int index = 0;
            while (index < MainGrid.Children.Count)
            {
                UIElement element = MainGrid.Children[index];
                if (element is Rectangle)
                {
                    Rectangle square = (Rectangle)element;
                    if (square.Name.IndexOf("moving_") == 0)
                    {
                        string newName = square.Name.Replace("moving_", "arrived_");
                        square.Name = newName;
                    }
                }
                index++;
            }
            
        }


    }
}
