using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using TetrisMVC.BusinessLayer;
using TetrisMVC.DTO;
using TetrisMVC.TetrisService;

namespace TetrisMVC.Controller
{
    class MainWindowController
    {
        public MainWindowController(MainWindow mainWindow)
        {
            mainWindow.Equal += (object sender, EventArgs e) =>
            {
                this.ShowMainMenu(mainWindow);
            };   
        }

        public void HandleKeyPress(string keyString)
        {
            if (!timer.IsEnabled) { return; }

            switch (keyString)
            {
                case "Up":
                    rotation += 90;
                    if (rotation > 270) { rotation = 0; }
                    shapeRotation(ref rotation);
                    break;
                case "Down":
                    setDownposinc();
                    break;
                case "Right":
                    setKeyright();
                    break;
                case "Left":
                    setKeyleft();
                    break;
                default:
                    break;
            }

            int result = moveShape(timer);
            if (result == -1)
                gameOver(mainWindowControl);
            if (result == 0)
            {
                reset();
                timer.Start();
            }
        }

        public void ShowMainMenu(MainWindow mainWindow)
        {
            Window1 win1 = new Window1(mainWindow.id, mainWindow.fullname);
            mainWindow.Close();
            win1.Show();
        }

        public void ShowRestart(MainWindow mainWindow)
        {
            reset();
        }

        public void HandleStartPause(MainWindow mainWindow)
        {
            if (isGameOver)
            {
                mainWindow.MainGrid.Children.Clear();
                mainWindow.nextShapeCanvas.Children.Clear();
                mainWindow.txtfinish.Visibility = Visibility.Collapsed;
                isGameOver = false;
            }
            if (!timer.IsEnabled)
            {
                if (!gameActive)
                {
                    mainWindow.scoreTxt.Text = "0";
                    Medthod_inButton();
                }
                mainWindow.levelTxt.Text = "Level : " + gameLevel.ToString();
                timer.Start();
                mainWindow.startStopBtn.Content = "Pause";
                mainWindow.restartStopBtn.Visibility = Visibility.Visible;
                mainWindow.scoreTxt.Visibility = mainWindow.nextTxt.Visibility = mainWindow.restartStopBtn.Visibility = mainWindow.levelTxt.Visibility = Visibility.Visible;
                gameActive = true;
            }
            else
            {
                timer.Stop();
                mainWindow.startStopBtn.Content = "Start";
                mainWindow.restartStopBtn.Visibility = Visibility.Collapsed;
            }
        }


        private int currentTetrominoWidth;
        private int currentTetrominoHeigth;
        private int currentShapeNumber;
        private int nextShapeNumber;
        List<int> currentTetrominoRow = null;
        List<int> currentTetrominoColumn = null;
        private int[,] currentTetromino = null;
        private int rowCount = 0;
        private int columnCount = 0;
        private int leftPos = 0;
        private int downPos = 0;
        private bool nextShapeDrawed = false;
        private bool isRotated = false;
        private bool bottomCollided = false;
        private bool leftCollided = false;
        private bool rightCollided = false;
        private int gameScore = 0;
        Random shapeRandom;
        Board board;
        TetraminoMoving te_moving;
        Tetramino tetramino;

        private int GAMESPEED = 700;// millisecond
        private int gameSpeed;
        private int gameLevel = 1;
        DispatcherTimer timer;
        private bool isGameOver = false;
        private int rotation = 0;
        private int levelScale = 60;// every 60 second increase level by 1 until 10
        private double gameSpeedCounter = 0;
        private bool gameActive = false;
        private MainWindow mainWindowControl;


        public MainWindowController(Board BOARD, MainWindow mainWindow, int level)
        {
            this.board = BOARD;
            mainWindowControl = mainWindow;

            tetramino = new Tetramino();
            te_moving = new TetraminoMoving(tetramino);
            shapeRandom = new Random();
            currentShapeNumber = shapeRandom.Next(1, 8);
            nextShapeNumber = shapeRandom.Next(1, 8);

            this.gameSpeed = GAMESPEED;
            setLevel(level);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
            timer.Tick += Timer_Tick;

            mainWindow.txtfinish.Visibility = Visibility.Collapsed;
            mainWindow.scoreTxt.Visibility = mainWindow.nextTxt.Visibility = mainWindow.restartStopBtn.Visibility = mainWindow.levelTxt.Visibility = Visibility.Hidden;
            startGame(mainWindow);
        }

        public void setLevel(int level)
        {
            for (int i = 0; i < 12; i++)
            {
                if (i == level)
                {
                    gameLevel = i + 1;
                    break;
                }
                gameSpeed = gameSpeed - 50;
            }
        }

        public void startGame(MainWindow mainWindow)
        {
            if (!gameActive)
            {
                mainWindow.scoreTxt.Text = "0";
                Medthod_inButton();
            }
            mainWindow.levelTxt.Text = "Level : " + gameLevel.ToString();
            timer.Start();
            mainWindow.startStopBtn.Content = "Pause";
            mainWindow.restartStopBtn.Visibility = Visibility.Visible;
            mainWindow.scoreTxt.Visibility = mainWindow.nextTxt.Visibility = mainWindow.restartStopBtn.Visibility = mainWindow.levelTxt.Visibility = Visibility.Visible;
            gameActive = true;
        }

        private void reset()
        {
            resetControl(isGameOver);
            rotation = 0;
        }


        private void gameOver(MainWindow mainWindow)
        {
            saveScore(mainWindow);
            isGameOver = true;
            reset();
            mainWindow.startStopBtn.Content = "Start";
            mainWindow.restartStopBtn.Visibility = Visibility.Collapsed;
            gameSpeedCounter = 0;
            mainWindow.txtfinish.Visibility = Visibility.Visible;
            gameSpeed = GAMESPEED;
            gameLevel = 1;
            gameActive = false;
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
        }

        public void saveScore(MainWindow mainWindow)
        {
            if (mainWindow.id == -1)
                return;
            else
            {
                UserServiceSoapClient reader = new UserServiceSoapClient();
                int userScore = reader.getScore(mainWindow.id);
                int currentScore = getValueScore();
                if (currentScore > userScore)
                    reader.updateScore(mainWindow.id, currentScore);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            setDownposinc();
            int result = moveShape(timer);
            if (result == -1)
                gameOver(mainWindowControl);
            if (result == 0)
            {
                reset();
                timer.Start();
            }
            if (gameSpeedCounter >= levelScale)
            {
                if (gameSpeed >= 50)
                {
                    gameSpeed -= 50;
                    gameLevel++;
                    mainWindowControl.levelTxt.Text = "Level : " + gameLevel.ToString();
                }
                else { gameSpeed = 50; }
                timer.Stop();
                timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
                timer.Start();
                gameSpeedCounter = 0;
            }
            gameSpeedCounter += (gameSpeed / 1000f);

        }

        


        // Hàm tạo 1 khối mới
        private void addShape(int shapeNumber, int _left = 0, int _down = 0)
        {
            removeShape();
            currentTetrominoRow = new List<int>();
            currentTetrominoColumn = new List<int>();
            Rectangle square = null;
            if (!isRotated)
            {
                currentTetromino = null;
                currentTetromino = tetramino.getVariableByString(tetramino.getArrayTetrominos()[shapeNumber].ToString());
            }
            int firstDim = currentTetromino.GetLength(0);
            int secondDim = currentTetromino.GetLength(1);
            currentTetrominoWidth = secondDim;
            currentTetrominoHeigth = firstDim;
            if (currentTetromino == tetramino.I_Tetromino_90)
            {
                currentTetrominoWidth = 1;
            }
            else if (currentTetromino == tetramino.I_Tetromino_0) { currentTetrominoHeigth = 1; }
            for (int row = 0; row < firstDim; row++)
            {
                for (int column = 0; column < secondDim; column++)
                {
                    int bit = currentTetromino[row, column];
                    if (bit == 1)
                    {
                        square = tetramino.getBasicSquare(handleColor(board.getColor(), shapeNumber));
                        board.getMainGrid().Children.Add(square);
                        square.Name = "moving_" + Grid.GetRow(square) + "_" + Grid.GetColumn(square);
                        if (_down >= board.getMainGrid().RowDefinitions.Count - currentTetrominoHeigth)
                        {
                            _down = board.getMainGrid().RowDefinitions.Count - currentTetrominoHeigth;
                        }
                        Grid.SetRow(square, rowCount + _down);
                        Grid.SetColumn(square, columnCount + _left);
                        currentTetrominoRow.Add(rowCount + _down);
                        currentTetrominoColumn.Add(columnCount + _left);

                    }
                    columnCount++;
                }
                columnCount = 0;
                rowCount++;
            }
            columnCount = 0;
            rowCount = 0;
            if (!nextShapeDrawed)
            {
                drawNextShape(nextShapeNumber);
            }
        }

        // Hàm di chuyển khối mới tạo vào grid
        public int moveShape(DispatcherTimer timer)
        {
            leftCollided = false;
            rightCollided = false;
            TetroCollided();
            if (leftPos > (board.getTetrisGridColumn() - currentTetrominoWidth))
            {
                leftPos = (board.getTetrisGridColumn() - currentTetrominoWidth);
            }
            else if (leftPos < 0) { leftPos = 0; }

            if (bottomCollided)
            {
                timer.Stop();
                if (downPos <= 2)
                {
                    return -1;
                }
                te_moving.shapeStoped(board.getMainGrid(), downPos);
                checkComplete();
                return 0;
            }
            addShape(currentShapeNumber, leftPos, downPos);
            return 1;
        }


        // Hàm tạo một khối tiếp theo
        private void drawNextShape(int shapeNumber)
        {
            board.getNextShapeCanvas().Children.Clear();
            int[,] nextShapeTetromino = null;
            nextShapeTetromino = tetramino.getVariableByString(tetramino.getArrayTetrominos()[shapeNumber]);
            int firstDim = nextShapeTetromino.GetLength(0);
            int secondDim = nextShapeTetromino.GetLength(1);
            int x = 0;
            int y = 0;
            Rectangle square;
            for (int row = 0; row < firstDim; row++)
            {
                for (int column = 0; column < secondDim; column++)
                {
                    int bit = nextShapeTetromino[row, column];
                    if (bit == 1)
                    {
                        square = tetramino.getBasicSquare(handleColor(board.getColor(), shapeNumber));
                        board.getNextShapeCanvas().Children.Add(square);
                        Canvas.SetLeft(square, x);
                        Canvas.SetTop(square, y);
                    }
                    x += 30;
                }
                x = 0;
                y += 30;
            }
            nextShapeDrawed = true;
        }


        // Hàm
        private void checkComplete()
        {
            int gridRow = board.getMainGrid().RowDefinitions.Count;
            int gridColumn = board.getMainGrid().ColumnDefinitions.Count;
            int squareCount = 0;
            for (int row = gridRow; row >= 0; row--)
            {
                squareCount = 0;
                for (int column = gridColumn; column >= 0; column--)
                {
                    Rectangle square;
                    square = (Rectangle)board.getMainGrid().Children
                   .Cast<UIElement>()
                   .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
                    if (square != null)
                    {
                        if (square.Name.IndexOf("arrived") == 0)
                        {
                            squareCount++;
                        }
                    }
                }

                // If squareCount == gridColumn this means tha the line is completed and must to be delete
                if (squareCount == gridColumn)
                {
                    deleteLine(row);
                    board.getScoreTxt().Text = "Your Score: " + getScore().ToString();
                    checkComplete();
                }
            }
        }

        private int getScore()
        {
            gameScore += 10;
            return gameScore;
        }


        // Hàm xoá dòng đã hoàn thành trên grid
        private void deleteLine(int row)
        {
            for (int i = 0; i < board.getMainGrid().ColumnDefinitions.Count; i++)
            {
                Rectangle square;
                try
                {
                    square = (Rectangle)board.getMainGrid().Children
                   .Cast<UIElement>()
                   .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == i);
                    board.getMainGrid().Children.Remove(square);
                }
                catch { }
            }
            foreach (UIElement element in board.getMainGrid().Children)
            {
                Rectangle square = (Rectangle)element;
                if (square.Name.IndexOf("arrived") == 0 && Grid.GetRow(square) <= row)
                {
                    Grid.SetRow(square, Grid.GetRow(square) + 1);
                }
            }
        }


        // Xoá khối 
        private void removeShape()
        {

            //error board null
            int index = 0;
            while (index < board.getMainGrid().Children.Count)
            {
                UIElement element = board.getMainGrid().Children[index];
                if (element is Rectangle)
                {
                    Rectangle square = (Rectangle)element;
                    if (square.Name.IndexOf("moving_") == 0)
                    {
                        board.getMainGrid().Children.Remove(element);
                        index = -1;
                    }
                }
                index++;
            }

        }

        //Kiểm tra va chạm của khối khi xoay
        private bool rotationCollided(int _rotation)
        {
            if (checkCollided(0, currentTetrominoWidth - 1)) { return true; }
            else if (checkCollided(0, -(currentTetrominoWidth - 1))) { return true; }
            else if (checkCollided(0, -1)) { return true; }
            else if (checkCollided(-1, currentTetrominoWidth - 1)) { return true; }
            else if (checkCollided(1, currentTetrominoWidth - 1)) { return true; }
            return false;
        }


        private void TetroCollided()
        {
            bottomCollided = checkCollided(0, 1);
            leftCollided = checkCollided(-1, 0);
            rightCollided = checkCollided(1, 0);
        }


        //  Hàm kiểm tra va chạm
        private bool checkCollided(int _leftRightOffset, int _bottomOffset)
        {
            Rectangle movingSquare;
            int squareRow = 0;
            int squareColumn = 0;
            for (int i = 0; i <= 3; i++)
            {
                squareRow = currentTetrominoRow[i];
                squareColumn = currentTetrominoColumn[i];
                try
                {
                    movingSquare = (Rectangle)board.getMainGrid().Children
                    .Cast<UIElement>()
                    .FirstOrDefault(e => Grid.GetRow(e) == squareRow + _bottomOffset && Grid.GetColumn(e) == squareColumn + _leftRightOffset);
                    if (movingSquare != null)
                    {
                        if (movingSquare.Name.IndexOf("arrived") == 0)
                        {
                            return true;
                        }
                    }
                }
                catch { }
            }
            if (downPos > (board.getTetrisGridRow() - currentTetrominoHeigth)) { return true; }
            return false;
        }

        public void setDownposinc()
        {
            downPos++;
        }

        // Hàm xoay khối
        public void shapeRotation(ref int rotation)
        {
            if (rotationCollided(rotation))
            {
                rotation -= 90;
                return;
            }
            te_moving.shapeRotation(ref rotation, currentShapeNumber, ref currentTetromino);
            isRotated = true;
            addShape(currentShapeNumber, leftPos, downPos);
        }

        public void setKeyright()
        {
            TetroCollided();
            if (!rightCollided) { leftPos++; }
            rightCollided = false;
        }

        public void setKeyleft()
        {
            TetroCollided();
            if (!leftCollided) { leftPos--; }
            leftCollided = false;
        }

        public void resetControl(bool isGameOver)
        {
            downPos = 0;
            leftPos = 3;
            isRotated = false;
            currentShapeNumber = nextShapeNumber;
            if (!isGameOver) { addShape(currentShapeNumber, leftPos); }
            nextShapeDrawed = false;
            shapeRandom = new Random();
            nextShapeNumber = shapeRandom.Next(1, 8);
            bottomCollided = false;
            leftCollided = false;
            rightCollided = false;
        }

        public void Medthod_inButton()
        {
            leftPos = 3;
            addShape(currentShapeNumber, leftPos);
        }

        //public void gameOver()
        //{
        //    rowCount = 0;
        //    columnCount = 0;
        //    leftPos = 0;
        //    nextShapeDrawed = false;
        //    currentTetromino = null;
        //    currentShapeNumber = shapeRandom.Next(1, 8);
        //    nextShapeNumber = shapeRandom.Next(1, 8);
        //    gameScore = 0;
        //}


        public void reStart()
        {
            gameScore = 0;
            board.getScoreTxt().Text = "Your Score : 0";
        }

        public int getValueScore()
        {
            return gameScore;
        }

        public Color handleColor(int color, int shapeNumber)
        {
            if (color == 1)
                return Colors.GreenYellow;
            if (color == 2)
                return Colors.Red;
            if (color == 3)
                return Colors.Gold;
            if (color == 4)
                return Colors.Violet;
            if (color == 5)
                return Colors.DeepSkyBlue;
            if (color == 6)
                return Colors.Cyan;
            if (color == 7)
                return Colors.LightSeaGreen;
            return tetramino.getShapecolor()[shapeNumber - 1];

        }

    }
}
