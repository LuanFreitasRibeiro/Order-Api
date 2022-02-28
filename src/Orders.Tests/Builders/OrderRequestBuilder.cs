using Orders.Domain.Models.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Builders
{
    public class OrderRequestBuilder
    {
        private readonly OrderRequest _orderRequest;

        public OrderRequestBuilder()
        {
            this._orderRequest = new OrderRequest();
        }

        public OrderRequestBuilder WithFullData()
        {
            this._orderRequest.Price = 35;

            return this;
        }

        public static CustomerRequestBuilder Instance()
            => new CustomerRequestBuilder();

        public OrderRequest Build() => _orderRequest;
    }
}
