using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface ICartRepository
    {
        List<Cart> GetCart();
        void AddCart(Cart cart);
        void DeleteCart(int cartId);
        void UpdateCart(Cart cart);
        void UpdateCartQty(int id, int qty);

    }
}
