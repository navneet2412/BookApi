using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int UserId{ get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public Wishlist(int wishlistId, int userId, int bookId, int quantity)
        {
            WishlistId = wishlistId;
            UserId = userId;
            BookId = bookId;
            Quantity = quantity;
        }
    }
}