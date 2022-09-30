using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class CartSQLImpl : ICartRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddCart(Cart cart)
        {
            comm.CommandText = "insert into cart values (" + cart.UserId + ", " + cart.BookId + ", " + cart.Quantity + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCart(int cartId)
        {
            comm.CommandText = "delete from cart where cartid = " + cartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Cart> GetCart()
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select * from cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CartId"]);
                int userId = Convert.ToInt32(reader["UserId"]);
                int bookId = Convert.ToInt32(reader["BookId"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                list.Add(new Cart(id, userId, bookId, quantity));
            }
            conn.Close();
            return list;
        }

        public void UpdateCart(Cart cart)
        {
            comm.CommandText = "update cart set userid = " + cart.UserId + ", bookid = " + cart.BookId +
                ", quantity = " + cart.Quantity + " where cartid = " + cart.CartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateCartQty(int id, int qty)
        {
            comm.CommandText = "update cart set quantity = " + qty + " where cartid = " + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}