using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class AdminController : ApiController
    {
        private IAdminRepository repository;

        public AdminController()
        {
            repository = new AdminSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetAdmins();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            bool data = repository.Login(username, password);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Admins admin)
        {
            repository.AddAdmin(admin);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteAdmin(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Admins admin)
        {
            repository.UpdateAdmin(admin);
            return Ok();
        }
    }
}
