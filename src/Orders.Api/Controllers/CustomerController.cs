using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Request.Order;
using System;
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
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest request)
        {
            var obj = await _customerService.Add(request);
            return Created(nameof(CreateCustomer), obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid customerId)
        {
            var result = await _customerService.GetById(customerId);
            return Ok(result);
        }
    }
}
