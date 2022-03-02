using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.AppService.Validators;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;


        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost("{customerId}")]
        [ProducesResponseType(typeof(CustomerOrdersResponse), 200)]
        public async Task<IActionResult> AddNewOrder([FromRoute] Guid customerId, OrderRequest request)
        {
            var findCustomerId = await _customerService.GetById(customerId);

            if (findCustomerId == null)
                return BadRequest(new { Message = "The customerId provided was not found." });

            var createOrderValidator = new CreateOrderValidator().Validate(request);

            if (!createOrderValidator.IsValid)
            {
                foreach (var error in createOrderValidator.Errors)
                {
                    return BadRequest(new { Error = error.ErrorMessage, Property = error.PropertyName });
                }
            }

            var createOrder = await _orderService.AddNewOrder(customerId, request);
            return Created(nameof(AddNewOrder), createOrder);
        }
    }
}
