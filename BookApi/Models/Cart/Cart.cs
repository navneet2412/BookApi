using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public Cart(int cartId, int userId, int bookId, int quantity)
        {
            CartId = cartId;
            UserId = userId;
            BookId = bookId;
            Quantity = quantity;
        }
    }
}