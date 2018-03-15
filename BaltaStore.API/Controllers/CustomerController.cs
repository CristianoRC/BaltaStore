using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public IList<Customer> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetByID(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IList<Order> GetOrders(Guid id)
        {
            return null;
        }


        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]Customer customer, Guid id)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public void Delet(Guid id)
        {
            
        }
    }
}