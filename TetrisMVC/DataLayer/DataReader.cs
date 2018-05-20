using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using TetrisMVC.DTO;

namespace TetrisMVC.DataLayer
{
    class DataReader
    {
        static string connectString = "TetrisMVC.Properties.Settings.DataTetrisConnectionString";
        public bool checkTV(string username)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "SELECT 1 FROM ThanhVien WHERE username ='" + username + "'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();
            try
            {
                int KetQua = (int)command.ExecuteScalar();
                if (KetQua == 1)
                    return false;
                return true;
                connect.Close();
            }
            catch (NullReferenceException ex)
            {
                return true;
                connect.Close();
            }
        }

        public bool login(string username, string password)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "SELECT 1 FROM ThanhVien WHERE username ='" + username + "' AND password ='"+password+"'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();
            try
            {
                int KetQua = (int)command.ExecuteScalar();
                if (KetQua == 1)
                    return false;
                return true;
                connect.Close();
            }
            catch (NullReferenceException ex)
            {
                return true;
                connect.Close();
            }
        }

        public string getfullname(string username, string password)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "SELECT fullname FROM ThanhVien WHERE username ='" + username + "' AND password ='" + password + "'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();
            
                string KetQua = (string)command.ExecuteScalar();                     
            return KetQua;
            connect.Close();
   
        }

        public int getid(string username, string password)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "SELECT id FROM ThanhVien WHERE username ='" + username + "' AND password ='" + password + "'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();

            int KetQua = (int)command.ExecuteScalar();
            return KetQua;
            connect.Close();
        }

        public int getScore(int id)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);
            // Tạo câu lệnh
            String _query = "SELECT score FROM ThanhVien WHERE id ='" + id+"'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();
            int KetQua = (int)command.ExecuteScalar();
            return KetQua;
            connect.Close();
        }

        public bool insertTV(User user)
        {
            // Tạo kết nối
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "INSERT INTO dbo.ThanhVien VALUES (@username, @password,@score, @fullname)";
            SqlCommand command = new SqlCommand(_query, connect);

            command.Parameters.AddWithValue("@username", user.getUsername());
            command.Parameters.AddWithValue("@password", user.getPassword());
            command.Parameters.AddWithValue("@score", user.getScore());
            command.Parameters.AddWithValue("@fullname", user.getFullname());
            connect.Open();

            int KetQuaTruyVan = command.ExecuteNonQuery();
            if (KetQuaTruyVan <= 0)
            {
                return false;
                connect.Close();
            }
            else
            {
                return true;
                connect.Close();
            }

        }

        public bool updateScore(int id, int score)
        {
            string _str = ConfigurationManager.ConnectionStrings[connectString].ConnectionString;
            SqlConnection connect = new SqlConnection(_str);

            // Tạo câu lệnh
            String _query = "UPDATE ThanhVien SET score='"+score.ToString()+"' WHERE id='" + id.ToString()+ "'";
            SqlCommand command = new SqlCommand(_query, connect);
            connect.Open();
            int KetQuaTruyVan = command.ExecuteNonQuery();
            if (KetQuaTruyVan <= 0)
            {
                return false;
                connect.Close();
            }
            else
            {
                return true;
                connect.Close();
            }

        }


    }
}
