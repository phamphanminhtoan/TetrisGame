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
        private Grid MainGrid;
        private Canvas nextShapeCanvas;
        private TextBlock scoreTxt;
        private int shapeColor;
        public Board(Grid Main_Grid, Canvas next_ShapeCanvas, TextBlock scoreTxt, int shapeColor)
        {
            this.MainGrid = Main_Grid;
            this.nextShapeCanvas = next_ShapeCanvas;
            this.scoreTxt = scoreTxt;
            this.shapeColor = shapeColor;
        }

        public Grid getMainGrid()
        {
            return MainGrid;
        }
        public Canvas getNextShapeCanvas()
        {
            return nextShapeCanvas;
        }
        public int getTetrisGridColumn()
        {
            return MainGrid.ColumnDefinitions.Count;
        }
        public int getTetrisGridRow()
        {
            return MainGrid.RowDefinitions.Count;
        }

        public TextBlock getScoreTxt()
        {
            return scoreTxt;
        }
        public int getColor()
        {
            return shapeColor;
        }

    }
}
