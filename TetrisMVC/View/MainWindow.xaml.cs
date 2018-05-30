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
        public delegate void EqualHandler(object sender, EventArgs e);
        public event EqualHandler Equal;
       
        Board myBoard;
        MainWindowController mainWindowController;
        public int id;
        public string fullname;

        public MainWindow(int level, int color, int id, string fullname)
        {
            InitializeComponent();
            this.id = id;
            this.fullname = fullname;
            NameTxt.Text = "Hello : " + fullname;
            myBoard = new Board(MainGrid, nextShapeCanvas, scoreTxt, color);
            mainWindowController = new MainWindowController(myBoard, this, level);

        }
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            mainWindowController.HandleKeyPress(e.Key.ToString());
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindowController.HandleStartPause(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mainWindowController.ShowRestart(this);
            MainGrid.Children.Clear();
            nextShapeCanvas.Children.Clear();
            mainWindowController.reStart();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindowController mainWindowController = new MainWindowController(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
        
    }
}

