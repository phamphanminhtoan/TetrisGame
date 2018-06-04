using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TetrisMVC.DTO;
using TetrisMVC.TetrisService;

namespace TetrisMVC.Controller
{
    class signUpController
    {

        public void HandleSignUp(signUp signUp)
        {
            if (checkInput(signUp))
            {
                
                UserServiceSoapClient reader = new UserServiceSoapClient();
                User newuser = reader.setSignUp(signUp.txtUsername.Text, signUp.txtPassword.Password.ToString(), signUp.txtFullname.Text, 0);
                
                if (reader.checkTV(signUp.txtUsername.Text))
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

        private bool checkInput(signUp signUp)
        {
            char[] error = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '[', ']', '|', '\\', '/', '?', '=', '+', ' ' };
            int index = signUp.txtUsername.Text.IndexOfAny(error);
            if (index != -1)
            {
                MessageBox.Show("Username chứa các kí tự đặc biệt và không hợp lệ ");
                return false;
            }
            if (signUp.txtPassword.Password.ToString().Length < 6)
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 6 kí tự ");
                return false;
            }
            if (String.Compare(signUp.txtPassword.Password.ToString(), signUp.txtRePassword.Password.ToString()) != 0)
            {
                MessageBox.Show("Nhập lại mật khẩu chưa chính xác ");
                return false;
            }
            if (signUp.txtFullname.Text.Trim() == "" || signUp.txtUsername.Text == "" || signUp.txtPassword.Password.ToString() == "")
            {
                MessageBox.Show("Các ô không được để trống");
                return false;
            }
            return true;
        }

        public void ShowMainMenu(signUp signUp)
        {
            Window1 win = new Window1();
            signUp.Close();
            win.Show();
        }
    }
}
