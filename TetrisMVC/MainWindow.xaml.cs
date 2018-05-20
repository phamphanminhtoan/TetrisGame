using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TetrisMVC.DTO;
using TetrisMVC.Controller;
using TetrisMVC.DataLayer;

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int GAMESPEED = 700;// millisecond
        private int rotation = 0;
        private bool gameActive = false;
        private int gameSpeed;
        private int levelScale = 60;// every 60 second increase level by 1 until 10
        private double gameSpeedCounter = 0;
        private int gameLevel = 1;
        private bool isGameOver = false;

        DispatcherTimer timer;
        Board myBoard;
        TetrisController te_controller;
        int id;
        string fullname;

        public MainWindow(int level, int color,int id , string fullname)
        {
            InitializeComponent();
            this.id = id;
            this.fullname = fullname;
            NameTxt.Text = "Hello : " + fullname;
            myBoard = new Board(MainGrid, nextShapeCanvas, scoreTxt,color);
            te_controller = new TetrisController(myBoard);
            gameSpeed = GAMESPEED;
            setLevel(level);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed); 
            timer.Tick += Timer_Tick;
            txtfinish.Visibility = Visibility.Collapsed;
            scoreTxt.Visibility=nextTxt.Visibility = restartStopBtn.Visibility = levelTxt.Visibility = Visibility.Hidden;
            startGame();
        }
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {

            if (!timer.IsEnabled) { return; }
            switch (e.Key.ToString())
            {
                case "Up":
                    rotation += 90;
                    if (rotation > 270) { rotation = 0; }
                    te_controller.shapeRotation(ref rotation);
                    break;
                case "Down":
                    te_controller.setDownposinc();
                    break;
                case "Right":
                    te_controller.setKeyright();
                    break;
                case "Left":
                    te_controller.setKeyleft();
                    break;
            }
            int result = te_controller.moveShape(timer);
            if (result == -1)
                gameOver();
            if (result == 0)
            {
                reset();
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            te_controller.setDownposinc();
            int result = te_controller.moveShape(timer);
            if (result == -1)
                gameOver();
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
                    levelTxt.Text = "Level : " + gameLevel.ToString();
                }
                else { gameSpeed = 50; }
                timer.Stop();
                timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
                timer.Start();
                gameSpeedCounter = 0;
            }
            gameSpeedCounter += (gameSpeed / 1000f);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (isGameOver)
            {
                MainGrid.Children.Clear();
                nextShapeCanvas.Children.Clear();
                txtfinish.Visibility = Visibility.Collapsed;
                isGameOver = false;
            }
            if (!timer.IsEnabled)
            {
                if (!gameActive)
                {
                    scoreTxt.Text = "0";
                    te_controller.Medthod_inButton();
                }
                levelTxt.Text = "Level : " + gameLevel.ToString();
                timer.Start();
                startStopBtn.Content = "Pause";
                restartStopBtn.Visibility = Visibility.Visible;
                scoreTxt.Visibility = nextTxt.Visibility = restartStopBtn.Visibility = levelTxt.Visibility = Visibility.Visible;
                gameActive = true;
            }
            else
            {
                timer.Stop();
                startStopBtn.Content = "Start";
                restartStopBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            reset();
            MainGrid.Children.Clear();
            nextShapeCanvas.Children.Clear();
            te_controller.reStart();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1(id, fullname);
            this.Close();
            win1.Show();
        }

        private void reset()
        {
            te_controller.reset(isGameOver);
            rotation = 0;
        }

        private void gameOver()
        {
            saveScore();
            isGameOver = true;
            reset();
            startStopBtn.Content = "Start";
            restartStopBtn.Visibility = Visibility.Collapsed;
            gameSpeedCounter = 0;
            txtfinish.Visibility = Visibility.Visible;
            gameSpeed = GAMESPEED;
            gameLevel = 1;
            gameActive = false;
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
        }

        public void setLevel(int level)
        {
            for(int i=0;i<12;i++)
            {
                if (i == level)
                {
                    gameLevel = i+1;
                    break;
                }
                gameSpeed = gameSpeed - 50;
            }
        }

        public void startGame()
        {
            if (!gameActive)
            {
                scoreTxt.Text = "0";
                te_controller.Medthod_inButton();
            }
            levelTxt.Text = "Level : " + gameLevel.ToString();
            timer.Start();
            startStopBtn.Content = "Pause";
            restartStopBtn.Visibility = Visibility.Visible;
            scoreTxt.Visibility = nextTxt.Visibility = restartStopBtn.Visibility = levelTxt.Visibility = Visibility.Visible;
            gameActive = true;
        }

        public void saveScore()
        {
            if (id == -1)
                return;
            else
            {
                DataReader reader = new DataReader();
                int userScore = reader.getScore(id);
                int currentScore = te_controller.getValueScore();
                if (currentScore > userScore)
                reader.updateScore(id, currentScore);
            }
        }

    }
}

