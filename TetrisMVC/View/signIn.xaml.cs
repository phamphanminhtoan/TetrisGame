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
    /// Interaction logic for signIn.xaml
    /// </summary>
    public partial class signIn : Window
    {
        public delegate void EqualHandler(object sender, EventArgs e);
        public event EqualHandler Equal;
        signInController signInController = new signInController();

        public string fullname;
        public int id;
        public signIn()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            signInController.HandleSignIn(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            signInController.HandleBack(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
    }
}
