using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _customerHandler = handler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public ListCustomerQueryResult GetByID(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IList<Order> GetOrders(Guid id)
        {
            return null;
        }


        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand customer)
        {
            var result = (CreateCustomerCommandResult)_customerHandler.Handle(customer);

            if (_customerHandler.Valid)
                return result;

            return BadRequest(_customerHandler.Notifications);
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand customer, Guid id)
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