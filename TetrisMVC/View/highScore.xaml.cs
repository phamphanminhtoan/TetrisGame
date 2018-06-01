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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using TetrisMVC.Controller;

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for highScore.xaml
    /// </summary>
    public partial class highScore : Window
    {
        public delegate void EqualHandler(object sender, EventArgs e);
        public event EqualHandler Equal;

        HighScoreController highScoreController = new HighScoreController();
        public int id;
        public string fullname;
        public highScore(int id , string fullname)
        {
            InitializeComponent();
            this.id = id;
            this.fullname = fullname;
            highScoreController.SetDataTable(this);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            highScoreController.ShowMainMenu(this);
            if (this.Equal != null)
            {
                this.Equal(this, new EventArgs());
            }
        }
    }
}
