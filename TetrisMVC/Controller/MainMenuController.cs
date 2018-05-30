using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using TetrisMVC.DTO;
using TetrisMVC.BusinessLayer;
using System.Windows.Threading;
using System.Windows.Media;

namespace TetrisMVC.Controller
{
    class MainMenuController
    {
        //Xu ly hien thi cho MainMenu
        public MainMenuController(Window1 window1)
        {
            switch (window1.indexW)
            {
                case 1:
                    window1.Equal += (object sender, EventArgs e) =>
                    {
                        this.ShowMainWindow(window1);
                    };
                        break;
                case 2:
                    window1.Equal += (object sender, EventArgs e) =>
                    {
                        this.ShowSignUp(window1);
                    };
                    break;
                case 3:
                    window1.Equal += (object sender, EventArgs e) =>
                    {
                        this.ShowSignIn(window1);
                    };
                    break;
                case 5:
                    window1.Equal += (object sender, EventArgs e) =>
                    {
                        this.ShowHighScore(window1);
                    };
                    break;
                default:
                    break;
            };
        }

        public void ShowMainWindow(Window1 window1)
        {
            MainWindow mainWindow = new MainWindow(window1.comboBox.SelectedIndex, 
                window1.comboBox_shapeColor.SelectedIndex, window1.id, window1.fullname);
            window1.Close();
            mainWindow.Show();
        }
        public void ShowSignIn(Window1 window1)
        {
            signIn signin = new signIn();
            window1.Close();
            signin.Show();
        }
        public void ShowSignUp(Window1 window1)
        {
            signUp signup = new signUp();
            window1.Close();
            signup.Show();
        }

        public void ShowHighScore(Window1 window1)
        {
            highScore bxh = new highScore(window1.id, window1.fullname);
            window1.Close();
            bxh.Show();
        }
    }
}

