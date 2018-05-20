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

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int id = -1;
        string fullname = "Guest";
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
            MainWindow main = new MainWindow(comboBox.SelectedIndex,comboBox_shapeColor.SelectedIndex,id,fullname);
            this.Close();
            main.Show();
        }
        private void button_Click2(object sender, RoutedEventArgs e)
        {
            signUp signup = new signUp();
            this.Close();
            signup.Show();
        }

        private void button_Click3(object sender, RoutedEventArgs e)
        {
            signIn signin = new signIn();
            this.Close();
            signin.Show();

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
            highScore bxh = new highScore(id,fullname);
            this.Close();
            bxh.Show();
        }
    }
}
