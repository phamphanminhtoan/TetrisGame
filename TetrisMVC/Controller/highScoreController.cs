using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMVC.Controller
{
    class HighScoreController
    {

        public void SetDataTable(highScore highScore)
        {
            string _str = ConfigurationManager.ConnectionStrings["TetrisMVC.Properties.Settings.DataTetrisConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);
            String _query = "SELECT fullname,score FROM ThanhVien ORDER BY score DESC";
            SqlCommand command = new SqlCommand(_query, connect);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable("ThanhVien");
            sda.Fill(dt);
            highScore.dataGrid.ItemsSource = dt.DefaultView;
        }

        public void ShowMainMenu(highScore highScore)
        {
            highScore.Equal += (object sender, EventArgs e) =>
            {
                Window1 mainmenu = new Window1(highScore.id, highScore.fullname);
                highScore.Close();
                mainmenu.Show();
            };
        }
    }
}
