using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookApi.Models
{
    public class booksqlImpl: IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public booksqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book (BookTitle,CatogeryId,Isbn,Price,Year,Description,BookStatus,ImageUrl) values('" + book.BookTitle + "', '" + book
                .CatogeryId + "','" + book.Isbn + "', '" + book.Price + "', '" + book.Year + "', '" + book.Description + "', '" + book.BookStatus + "', '" + book.ImageUrl + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public string DeleteBook(int id)
        {
            comm.CommandText = "delete from Book where Id='"+id+"'";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            string res = row+"item deleted!";
            return res;
        }

        public List<Book> GetAllBook()
        {
            List<Book> books = new List<Book>();
            comm.CommandText = "select * from Book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string booktitle = reader["BookTitle"].ToString();
                int catogeryid = Convert.ToInt32(reader["CatogeryId"]);
                string isbn = reader["Isbn"].ToString();
                int price = Convert.ToInt32(reader["Price"]);
                int year = Convert.ToInt32(reader["Year"]);
                string description = reader["Description"].ToString();
                string bookstatus = reader["BookStatus"].ToString();
                string imageurl = reader["ImageUrl"].ToString();
                books.Add(new Book(id, booktitle, catogeryid, isbn, price, year, description, bookstatus, imageurl));
            }
            conn.Close();
            return books;
        }

        public Book GetBookById(int id)
        {

            
            comm.CommandText = "select * from Book where Id='"+id+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string booktitle = reader["BookTitle"].ToString();
                int catogeryid = Convert.ToInt32(reader["CatogeryId"]);
                string isbn = reader["Isbn"].ToString();
                int price = Convert.ToInt32(reader["Price"]);
                int year = Convert.ToInt32(reader["Year"]);
                string description = reader["Description"].ToString();
                string bookstatus = reader["BookStatus"].ToString();
                string imageurl = reader["ImageUrl"].ToString();
               Book book = new Book(id, booktitle, catogeryid, isbn, price, year, description, bookstatus, imageurl);
                return book;
            }
            conn.Close();
            return null;
           
        }

        public Book UpdateBook(int id,Book book)
        {
            comm.CommandText = "update Book set BookTitle='"+book.BookTitle+ "',CatogeryId='"+book.CatogeryId+ "',Isbn='"+book.Isbn+ "',Price='"+book.Price+ "',Year='"+book.Year+ "',Description='"+book.Description+ "',BookStatus='"+book.BookStatus+ "',ImageUrl='"+book.ImageUrl+"' where Id='"+id+"'";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }
    }
}






