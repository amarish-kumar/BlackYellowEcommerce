using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.Authentication.Application.Interfaces;
using BlackYellow.Authentication.Application.ViewModels;
using BlackYellow.Authentication.Domain.Customers;
using BlackYellow.Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackYellow.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ApiController
    {

        private readonly ICustomerAppService _customerAppService;

        public AccountController(ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return _customerAppService.Get(1);
        }
        
        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody]CustomerViewModel customer)
        {
            _customerAppService.Add(customer);

            return Response(customer);
        }
        
        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
