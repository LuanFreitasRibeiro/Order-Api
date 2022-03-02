using Orders.Domain.Models.Response.CustomerResponse;
using System;

namespace Orders.Tests.Builders
{
    public class CustomerResponseBuilder
    {
        private readonly CustomerResponse _response;

        public CustomerResponseBuilder()
        {
            this._response = new CustomerResponse();
        }

        public CustomerResponseBuilder WithFullData()
        {
            this._response.Id = Guid.NewGuid();
            this._response.Name = "My Customer Mock";
            this._response.Email = "customermock@gmail.com";

            return this;
        }

        public static CustomerResponseBuilder Instance()
            => new CustomerResponseBuilder();

        public CustomerResponse Build() => _response;
    }
}
