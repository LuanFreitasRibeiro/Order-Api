using System;

namespace Orders.Domain.Models.Response.OrderResponse
{
    public class CreateOrderResponse : OrderResponse
    {
        public Guid CustomerId { get; set; }
    }
}
