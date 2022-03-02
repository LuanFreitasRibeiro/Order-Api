using Orders.Domain.Models.Response.OrderResponse;
using System;

namespace Orders.Tests.Builders
{
    public class OrderResponseBuilder
    {
        private readonly CreateOrderResponse _orderResponse;

        public OrderResponseBuilder()
        {
            this._orderResponse = new CreateOrderResponse();
        }

        public OrderResponseBuilder WithFullData()
        {
            this._orderResponse.Id = Guid.NewGuid();
            this._orderResponse.Price = 41;
            this._orderResponse.CreatedAt = DateTime.Now;

            return this;
        }

        public static OrderResponseBuilder Instance()
            => new OrderResponseBuilder();

        public CreateOrderResponse Build() => _orderResponse;
    }
}
