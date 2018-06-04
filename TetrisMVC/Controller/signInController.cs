using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TetrisMVC.TetrisService;

namespace TetrisMVC.Controller
{
    class signInController
    {
        public void HandleSignIn(signIn signIn)
        {
            UserServiceSoapClient reader = new UserServiceSoapClient();
            if (!reader.login(signIn.txtUsername.Text, signIn.txtPassword.Password.ToString()))
            {
                signIn.fullname = reader.getfullname(signIn.txtUsername.Text, signIn.txtPassword.Password.ToString());
                signIn.id = reader.getid(signIn.txtUsername.Text, signIn.txtPassword.Password.ToString());
                MessageBox.Show("Đăng nhập thành công !");
                Window1 mainmenu = new Window1(signIn.id, signIn.fullname);
                signIn.Close();
                mainmenu.Show();
            }
            else
                MessageBox.Show("Đăng nhập thất bại");
        }

        public void HandleBack(signIn signIn)
        {
            Window1 mainWindow = new Window1();
            signIn.Close();
            mainWindow.Show();
        }
    }
}
