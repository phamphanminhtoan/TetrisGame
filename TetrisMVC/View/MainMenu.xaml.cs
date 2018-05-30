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
using System.Windows.Shapes;
using TetrisMVC.Controller;

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public int id = -1;
        public string fullname = "Guest";
        public int indexW;

        public delegate void EqualHandler(object sender, EventArgs e);
        public event EqualHandler Equal;

        public Window1()
        {
            InitializeComponent();
        }
        public Window1(int id, string fullname)
        {
            InitializeComponent();
            this.id = id;
            this.fullname = fullname;
            if (id == -1)
            {
                fullname = "Guest";
            }
            else
            {
                button_Signin.Visibility = Visibility.Collapsed;
                button_Signup.Visibility = Visibility.Collapsed;
                button_Signout.Visibility = Visibility.Visible;
            }
        }

        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            indexW = 1;
            MainMenuController mainMenuController = new MainMenuController(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
        private void button_Click2(object sender, RoutedEventArgs e)
        {
            indexW = 2;
            MainMenuController mainMenuController = new MainMenuController(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }

        private void button_Click3(object sender, RoutedEventArgs e)
        {
            indexW = 3;
            MainMenuController mainMenuController = new MainMenuController(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }

        private void button_Click4(object sender, RoutedEventArgs e)
        {
            id = -1;
            fullname = "Guest";
            button_Signin.Visibility = button_Signup.Visibility = Visibility.Visible;
            button_Signout.Visibility = Visibility.Collapsed;
        }

        private void button_Click5(object sender, RoutedEventArgs e)
        {
            indexW = 5;
            MainMenuController mainMenuController = new MainMenuController(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
    }
}
