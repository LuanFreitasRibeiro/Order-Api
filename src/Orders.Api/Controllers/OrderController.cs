using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{customerId}")]
        [ProducesResponseType(typeof(CustomerOrdersResponse), 200)]
        public async Task<IActionResult> AddNewOrder([FromRoute] Guid customerId, OrderRequest request)
        {
            var createOrder = await _orderService.AddNewOrder(customerId, request);
            return Created(nameof(AddNewOrder), createOrder);
        }
    }
}
