using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class AddressController : ApiController
    {
        private IAddressRepository repository;

        public AddressController()
        {
            repository = new AddressSQLImpl();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = repository.GetAllAddresses();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var data = repository.GetAddressByUser(id);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Add(Addresses address)
        {
            repository.AddAddress(address);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Addresses address)
        {
            repository.UpdateAddress(address);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteAddress(id);
            return Ok();
        }
    }
}
