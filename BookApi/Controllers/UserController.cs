using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new UserSqlImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetUsers();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            bool data = repository.Login(username, password);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Users user)
        {
            repository.AddUser(user);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteUser(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Users user)
        {
            repository.UpdateUser(user);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AdminUpdate(int id, int status)
        {
            repository.AdminUpdateUser(id, status);
            return Ok();
        }
    }
}
