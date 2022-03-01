using Orders.Domain.Models;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Builders
{
    public class CustomerOrdersResponseBuilder
    {
        private readonly CustomerOrdersResponse _response;

        public CustomerOrdersResponseBuilder()
        {
            this._response = new CustomerOrdersResponse();
        }

        public CustomerOrdersResponseBuilder WithFullData()
        {
            this._response.Id = Guid.NewGuid();
            this._response.Name = "My Customer Mock";
            this._response.Email = "customermock@gmail.com";
            this._response.Orders = new List<Order>()
            {
                new Order()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Price = 77,
                    CustomerId = Guid.NewGuid(),
                },
                new Order()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Price = 1655.59m,
                    CustomerId = Guid.NewGuid(),
                },
            };

            return this;
        }

        public static CustomerOrdersResponseBuilder Instance()
            => new CustomerOrdersResponseBuilder();

        public CustomerOrdersResponse Build() => _response;
    }
}
