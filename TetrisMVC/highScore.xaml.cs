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

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for highScore.xaml
    /// </summary>
    public partial class highScore : Window
    {
        int id;
        string fullname;
        public highScore(int id , string fullname)
        {
            InitializeComponent();
            this.id = id;
            this.fullname = fullname;
            string _str = ConfigurationManager.ConnectionStrings["TetrisMVC.Properties.Settings.DataTetrisConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);
            String _query = "SELECT fullname,score FROM ThanhVien ORDER BY score DESC";
            SqlCommand command = new SqlCommand(_query, connect);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("ThanhVien");
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window1 mainmenu = new Window1(id, fullname);
            this.Close();
            mainmenu.Show();
        }
    }
}
