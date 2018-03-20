using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
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
        [Route("v1/customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public ListCustomerQueryResult GetByID(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IList<Order> GetOrders(Guid id)
        {
            return null;
        }


        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody]CreateCustomerCommand customer)
        {
            var result = (CreateCustomerCommandResult)_customerHandler.Handle(customer);

            if (_customerHandler.Valid)
                return result;

            return BadRequest(_customerHandler.Notifications);
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public object Put([FromBody]CreateCustomerCommand customer, Guid id)
        {
            var resul = _customerHandler.Handle(customer, id);

            if (_customerHandler.Valid)
                return resul;

            return BadRequest(_customerHandler.Notifications);
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public void Delet(Guid id)
        {
            _customerHandler.Delet(id);
        }
    }
}