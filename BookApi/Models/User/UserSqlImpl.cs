using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class UserSqlImpl : IUserRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddUser(Users user)
        {
            comm.CommandText = "insert into [User] values ('" + user.Name + "', '" + user.Username + "', '" + user.Password +
                "', '" + user.Email + "', " + user.Mobile + ", 1)";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteUser(int userId)
        {
            comm.CommandText = "delete from [User] where userid = " + userId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Users> GetUsers()
        {
            List<Users> list = new List<Users>();
            comm.CommandText = "select * from [User]";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["UserId"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                Int64 mobile = Convert.ToInt64(reader["Mobile"]);
                int status = Convert.ToInt32(reader["AccountStatus"]);
                list.Add(new Users(id, name, null, null, email, mobile, status));
            }
            conn.Close();
            return list;
        }

        public bool Login(string username, string password)
        {
            comm.CommandText = "select count(*) count from [User] where Username = '" + username + "' and Password = '" + password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            int count = Convert.ToInt32(reader["count"]);
            conn.Close();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UpdateUser(Users user)
        {
            comm.CommandText = "update [User] set Name = '" + user.Name + "', Username = '" + user.Username + "', Password = '" +
                user.Password + "', Email = '" + user.Email + "', Mobile = " + user.Mobile + " where Userid = " + user.UserId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void AdminUpdateUser(int id, int status)
        {
            comm.CommandText = "update [User] set Accountstatus = " + status + " where Userid = " + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

    }
}