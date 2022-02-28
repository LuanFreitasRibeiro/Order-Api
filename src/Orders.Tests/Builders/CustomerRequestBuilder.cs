using Orders.Domain.Models.Request.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Builders
{
    public class CustomerRequestBuilder
    {
        private readonly CustomerRequest _customerRequest;

        public CustomerRequestBuilder()
        {
            this._customerRequest = new CustomerRequest();
        }

        public CustomerRequestBuilder WithFullData()
        {
            this._customerRequest.Name = "Meu customer";
            this._customerRequest.Email = "meu@gmail.com";

            return this;
        }

        public static CustomerRequestBuilder Instance()
            => new CustomerRequestBuilder();

        public CustomerRequest Build() => _customerRequest;
    }
}
