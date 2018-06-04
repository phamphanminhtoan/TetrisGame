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
using TetrisMVC.DTO;
using TetrisMVC.Controller;

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for signUp.xaml
    /// </summary>
    public partial class signUp : Window
    {
        public delegate void EqualHandler(object sender, EventArgs e);
        public event EqualHandler Equal;
        signUpController signUpController = new signUpController();

        public signUp()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            signUpController.HandleSignUp(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
            signUpController.ShowMainMenu(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
        
    }
}
