using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
namespace TetrisMVC.DTO
{
    public class Tetramino
    {

        private static Color O_TetrominoColor = Colors.GreenYellow;
        private static Color I_TetrominoColor = Colors.Red;
        private static Color T_TetrominoColor = Colors.Gold;
        private static Color S_TetrominoColor = Colors.Violet;
        private static Color Z_TetrominoColor = Colors.DeepSkyBlue;
        private static Color J_TetrominoColor = Colors.Cyan;
        private static Color L_TetrominoColor = Colors.LightSeaGreen;

        //Chuỗi tên các khối chữ
        string[] arrayTetrominos = { "","O_Tetromino" , "I_Tetromino_0",
                                        "T_Tetromino_0","S_Tetromino_0",
                                        "Z_Tetromino_0","J_Tetromino_0",
                                        "L_Tetromino_0"
                                   };



        // Chuỗi tên các màu
        Color[] shapeColor = {  O_TetrominoColor,I_TetrominoColor,
                                T_TetrominoColor,S_TetrominoColor,
                                Z_TetrominoColor,J_TetrominoColor,
                                L_TetrominoColor
                             };
        //---- Khối chữ O và các góc quay------------
        public int[,] O_Tetromino = new int[2, 2] { { 1, 1 },
                                                    { 1, 1 }};

        //---- Khối chữ I và các góc quay------------
        public int[,] I_Tetromino_0 = new int[2, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };

        public int[,] I_Tetromino_90 = new int[4, 2] {{ 1,0 },
                                                       { 1,0 },
                                                       { 1,0 },
                                                       { 1,0 }};
        //---- Khối chữ T và các góc quay------------
        public int[,] T_Tetromino_0 = new int[2, 3] {{0,1,0},
                                                     {1,1,1}};

        public int[,] T_Tetromino_90 = new int[3, 2] {{1,0},
                                                      {1,1},
                                                      {1,0}};

        public int[,] T_Tetromino_180 = new int[2, 3] {{1,1,1},
                                                       {0,1,0}};

        public int[,] T_Tetromino_270 = new int[3, 2] {{0,1},
                                                       {1,1},
                                                       {0,1}};
        //---- Khối chữ S và các góc quay------------
        public int[,] S_Tetromino_0 = new int[2, 3] {{0,1,1},
                                                     {1,1,0}};

        public int[,] S_Tetromino_90 = new int[3, 2] {{1,0},
                                                      {1,1},
                                                      {0,1}};
        //---- Khối chữ Z và các góc quay------------
        public int[,] Z_Tetromino_0 = new int[2, 3] {{1,1,0},
                                                     {0,1,1}};

        public int[,] Z_Tetromino_90 = new int[3, 2] {{0,1},
                                                      {1,1},
                                                      {1,0}};
        //---- Khối chữ J và các góc quay------------
        public int[,] J_Tetromino_0 = new int[2, 3] {{1,0,0},
                                                     {1,1,1}};

        public int[,] J_Tetromino_90 = new int[3, 2] {{1,1},
                                                      {1,0},
                                                      {1,0}};

        public int[,] J_Tetromino_180 = new int[2, 3] {{1,1,1},
                                                       {0,0,1}};

        public int[,] J_Tetromino_270 = new int[3, 2] {{0,1},
                                                       {0,1},
                                                       {1,1 }};

        //---- Khối chữ L và các góc quay------------
        public int[,] L_Tetromino_0 = new int[2, 3] {{0,0,1},
                                                     {1,1,1}};

        public int[,] L_Tetromino_90 = new int[3, 2] {{1,0},
                                                      {1,0},
                                                      {1,1}};

        public int[,] L_Tetromino_180 = new int[2, 3] {{1,1,1},
                                                       {1,0,0}};

        public int[,] L_Tetromino_270 = new int[3, 2] {{1,1},
                                                       {0,1},
                                                       {0,1 }};


        //Hàm vẽ khối
        public Rectangle getBasicSquare(Color rectColor)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 30;
            rectangle.Height = 30;
            rectangle.StrokeThickness = 1;
            rectangle.Stroke = Brushes.White;
            rectangle.Fill = getGradientColor(rectColor);
            return rectangle;
        }


        // Hàm đặt màu sắc cho các khối
        private LinearGradientBrush getGradientColor(Color clr)
        {
            LinearGradientBrush gradientColor = new LinearGradientBrush();
            gradientColor.StartPoint = new Point(0, 0);
            gradientColor.EndPoint = new Point(1, 1.5);
            GradientStop black = new GradientStop();
            black.Color = Colors.Black;
            black.Offset = -1.5;
            gradientColor.GradientStops.Add(black);
            GradientStop other = new GradientStop();
            other.Color = clr;
            other.Offset = 0.70;
            gradientColor.GradientStops.Add(other);
            return gradientColor;
        }

        public string[] getArrayTetrominos()
        {
            return arrayTetrominos;
        }
        public Color[] getShapecolor()
        {
            return shapeColor;
        }

        public int[,] getVariableByString(string variable)
        {
            return (int[,])this.GetType().GetField(variable).GetValue(this);
        }


    }
}
