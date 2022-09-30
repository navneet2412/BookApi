using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Book
    {
        
        
            public int BookId { get; set; }
            public string BookTitle { get; set; }
            public int CatogeryId { get; set; }
            public string Isbn { get; set; }
            public int Price { get; set; }
            public int Year { get; set; }
            public string Description { get; set; }
            public string BookStatus { get; set; }
            public string ImageUrl { get; set; }

            public Book() { }

            public Book(int id, string booktitle, int catogeryid, string isbn, int price, int year, string description, string bookstatus, string imageurl)
            {
                BookId = id;
                BookTitle = booktitle;
                CatogeryId = catogeryid;
                Isbn = isbn;
                Price = price;
                Year = year;
                Description = description;
                BookStatus = bookstatus;
                ImageUrl = imageurl;
            }

        

    }
}