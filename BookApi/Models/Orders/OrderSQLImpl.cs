using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class OrderSQLImpl : IOrderRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddOrder(Orders order, int orderId)
        {
            comm.CommandText = "insert into order values (" + orderId + ", " + order.UserId + ", " + order.BookId + ", " + order.Quantity + ", "
                + order.AddressId + ", '" + order.Date + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteOrder(int orderId)
        {
            comm.CommandText = "delete from order where orderid = " + orderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Orders> GetOrder()
        {
            List<Orders> list = new List<Orders>();
            comm.CommandText = "select * from order";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["OrderId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                int addressId = Convert.ToInt32(reader["Quantity"]);
                string date = reader["Quantity"].ToString();
                list.Add(new Orders(id, userId, bookId, quantity, addressId, date));
            }
            conn.Close();
            return list;
        }

        public int GetOrderId()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Orders order)
        {
            comm.CommandText = "update order set userid = " + order.UserId + ", bookid = " + order.BookId +
                ", quantity = " + order.Quantity + " where orderid = " + order.OrderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}