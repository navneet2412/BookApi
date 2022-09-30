using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookApi.Models;

namespace BookApi.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryRepo repository;
        public CategoryController()
        {
            repository = new CategorySqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            return Ok(data);
        }
        [HttpPut]
        public IHttpActionResult Put(int id, Category category)
        {
            var data = repository.UpdateCategory(id, category);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var data = repository.DeleteCategory(id);
            return Ok(data);
        }
    }
}
