using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookApi.Models;

namespace BookApi.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository repository;
        public BookController()
        {
            repository = new booksqlImpl();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var data = repository.DeleteBook(id);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetBookById(id);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Put(int id,Book book)
        {
            var data = repository.UpdateBook(id, book);
            return Ok(data);
        }

    }
}
