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

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Board myBoard;

        public MainWindow()
        {
            InitializeComponent();
        }
        void MainWindow_Initilized(object sender, EventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(GameTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            GameStart();
        }
        private void GameStart()
        {
            MainGrid.Children.Clear();
            myBoard = new Board(MainGrid);
            timer.Start();
        }
        private void GamePause()
        {
            if (timer.IsEnabled) timer.Stop();
            else timer.Start();
        }
        void GameTick(object sender, EventArgs e)
        {
            Scores.Content = myBoard.getScore().ToString("0000");
            Lines.Content = myBoard.getLine().ToString("0000");
            myBoard.CurTetraminoMoveDown();
        }
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (timer.IsEnabled) myBoard.CurTetraminoMoveLeft();
                    break;
                case Key.Right:
                    if (timer.IsEnabled) myBoard.CurTetraminoMoveRight();
                    break;

                case Key.Down:
                    if (timer.IsEnabled) myBoard.CurTetraminoMoveDown();
                    break;

                case Key.Up:
                    if (timer.IsEnabled) myBoard.CurTetraminoMoveRotate();
                    break;

                case Key.F2:
                    GameStart();
                    break;
                case Key.F3:
                    GamePause();
                    break;

                default:
                    break;
            }
        }
    }
}
