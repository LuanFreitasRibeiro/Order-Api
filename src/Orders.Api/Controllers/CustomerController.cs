using Microsoft.AspNetCore.Mvc;
using Orders.AppService.Validators;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest request)
        {
            var createCustomerValidator = new CreateCustomerValidator().Validate(request);

            if (!createCustomerValidator.IsValid)
            {
                foreach(var error in createCustomerValidator.Errors)
                {
                    return BadRequest(new { Error = error.ErrorMessage, Property = error.PropertyName });
                }
            }

            var obj = await _customerService.CreateNewCustomer(request);
            return Created(nameof(CreateCustomer), obj);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), 200)]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customerService.GetAll();

            return Ok(response);
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(CustomerOrdersResponse), 200)]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid customerId)
        {
            var result = await _customerService.GetById(customerId);

            if(result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
