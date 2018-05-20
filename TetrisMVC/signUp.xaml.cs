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
using TetrisMVC.DataLayer;
namespace TetrisMVC
{
    /// <summary>
    /// Interaction logic for signUp.xaml
    /// </summary>
    public partial class signUp : Window
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (checkInput())
            {
                User newuser = new User();
                DataReader reader = new DataReader();
                newuser.setUsername(txtUsername.Text);
                newuser.setPassword(txtPassword.Password.ToString());
                newuser.setFullname(txtFullname.Text);
                newuser.setScore(0);
                if (reader.checkTV(txtUsername.Text))
                {
                    if (reader.insertTV(newuser))
                        MessageBox.Show("Thêm thành công !");
                    else
                        MessageBox.Show("Thất bại");
                }
                else
                {
                    MessageBox.Show("Username bị trùng !");
                }
            }
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            this.Close();
            win.Show();
        }
        public bool checkInput()
        {
            char[] error = {'!','@','#','$','%','^','&','*','(',')','{','}','[',']','|','\\','/','?','=','+',' '};
            int index = txtUsername.Text.IndexOfAny(error);
            if(index != -1)
            {
                MessageBox.Show("Username chứa các kí tự đặc biệt và không hợp lệ ");
                return false;
            }
            if(txtPassword.Password.ToString().Length < 6)
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 6 kí tự ");
                return false;
            }
            if (String.Compare(txtPassword.Password.ToString(), txtRePassword.Password.ToString()) != 0)
            {
                MessageBox.Show("Nhập lại mật khẩu chưa chính xác ");
                return false;
            }
            if (txtFullname.Text.Trim() == "" || txtUsername.Text =="" || txtPassword.Password.ToString() == "")
            {
                MessageBox.Show("Các ô không được để trống");
                return false;
            }
            
            return true;
        }
    }
}
