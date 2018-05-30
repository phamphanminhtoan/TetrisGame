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
using TetrisMVC.DataLayer;

namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for signIn.xaml
    /// </summary>
    public partial class signIn : Window
    {
        string fullname;
        int id;
        public signIn()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataReader reader = new DataReader();
            if (!reader.login(txtUsername.Text, txtPassword.Password.ToString()))
            {
                 fullname = reader.getfullname(txtUsername.Text, txtPassword.Password.ToString());
                id= reader.getid(txtUsername.Text, txtPassword.Password.ToString());
                MessageBox.Show("Đăng nhập thành công !");
                Window1 mainmenu = new Window1(id, fullname);
                this.Close();
                mainmenu.Show();
            }
            else
                MessageBox.Show("Đăng nhập thất bại");
        }
    }
}
