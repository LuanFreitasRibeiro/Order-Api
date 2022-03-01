using Orders.Domain.Models.Response.OrderResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Builders
{
    public class CreateOrderResponseBuilder
    {
        private readonly CreateOrderResponse _createOrderResponse;

        public CreateOrderResponseBuilder()
        {
            this._createOrderResponse = new CreateOrderResponse();
        }

        public CreateOrderResponseBuilder WithFullData()
        {
            this._createOrderResponse.Id = Guid.NewGuid();
            this._createOrderResponse.Price = 41;
            this._createOrderResponse.CreatedAt = DateTime.Now;

            return this;
        }
        public static CreateOrderResponseBuilder Instance()
            => new CreateOrderResponseBuilder();

        public CreateOrderResponse Build() => _createOrderResponse;
    }
}
