using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class AddressSQLImpl : IAddressRepository
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();

        public void AddAddress(Addresses address)
        {
            comm.CommandText = "insert into address values (" + address.UserId + ", '" + address.HouseNo + "', '" + address.Street +
                "', '" + address.City + "', '" + address.State + "', " + address.Pincode + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteAddress(int AddressId)
        {
            comm.CommandText = "delete from address where addressid = " + AddressId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Addresses> GetAllAddresses()
        {
            List<Addresses> list = new List<Addresses>();
            comm.CommandText = "select * from address";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int addressId = Convert.ToInt32(reader["AddressId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                string houseNo = reader["HouseNo"].ToString();
                string street = reader["Street"].ToString();
                string city = reader["City"].ToString();
                string state = reader["State"].ToString();
                int pincode = Convert.ToInt32(reader["Pincode"]);
                list.Add(new Addresses(addressId, userId, houseNo, street, city, state, pincode));
            }
            conn.Close();
            return list;
        }

        public List<Addresses> GetAddressByUser(int userId)
        {
            List<Addresses> list = new List<Addresses>();
            comm.CommandText = "select * from address where userid = " + userId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int addressId = Convert.ToInt32(reader["AddressId"]);
                string houseNo = reader["HouseNo"].ToString();
                string street = reader["Street"].ToString();
                string city = reader["City"].ToString();
                string state = reader["State"].ToString();
                int pincode = Convert.ToInt32(reader["Pincode"]);
                list.Add(new Addresses(addressId, userId, houseNo, street, city, state, pincode));
            }
            conn.Close();
            return list;
        }

        public void UpdateAddress(Addresses address)
        {
            comm.CommandText = "update address set userid = " + address.UserId + ", houseno = '" + address.HouseNo + 
                "', street = '" + address.Street + "', city = '" + address.City + "', state = '" + address.State + 
                "', pincode = " + address.Pincode + " where addressid = " + address.AddressId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}