using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class AdminSQLImpl : IAdminRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddAdmin(Admins admin)
        {
            comm.CommandText = "insert into [admin] values ('" + admin.Name + "', '" + admin.Username + "', '" + admin.Password +
                "', '" + admin.Email + "', " + admin.Mobile + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteAdmin(int adminId)
        {
            comm.CommandText = "delete from [admin] where adminid = " + adminId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Admins> GetAdmins()
        {
            List<Admins> list = new List<Admins>();
            comm.CommandText = "select * from [admin]";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["AdminId"]);
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                string mobile = reader["Mobile"].ToString();
                list.Add(new Admins(id, name, null, null, email, mobile));
            }
            conn.Close();
            return list;
        }

        public bool Login(string username, string password)
        {
            comm.CommandText = "select count(*) count from [admin] where username = '" + username + "' and password = '" + password + "'";
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

        public void UpdateAdmin(Admins admin)
        {
            comm.CommandText = "update [admin] set name = '" + admin.Name + "', username = '" + admin.Username + "', password = '" +
                admin.Password + "', email = '" + admin.Email + "', mobile = " + admin.Mobile + " where adminid = " + admin.AdminId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}