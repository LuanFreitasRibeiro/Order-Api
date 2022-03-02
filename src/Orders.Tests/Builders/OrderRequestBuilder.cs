using Orders.Domain.Models.Request.Order;

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
