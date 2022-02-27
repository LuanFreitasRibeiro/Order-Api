using System;

namespace Orders.Domain.Models.Response.OrderResponse
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
