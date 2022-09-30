using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IWishlistRepository
    {
        List<Wishlist> GetWishlist();
        void AddWishlist(Wishlist wishlist);
        void DeleteWishlist(int wishlistId);
        void UpdateWishlist(Wishlist wishlist);
        void UpdateWishlistQty(int id, int qty);
    }
}
