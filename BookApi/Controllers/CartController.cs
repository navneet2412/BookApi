using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace BookApi.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetCart();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Cart cart)
        {
            repository.AddCart(cart);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCart(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Cart cart)
        {
            repository.UpdateCart(cart);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateQty(int id, int qty)
        {
            repository.UpdateCartQty(id, qty);
            return Ok();
        }
    }
}
