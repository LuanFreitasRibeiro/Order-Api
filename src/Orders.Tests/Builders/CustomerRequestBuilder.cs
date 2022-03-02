using Orders.Domain.Models.Request.Customer;

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

        public CustomerRequestBuilder WithoutName()
        {
            this._customerRequest.Email = "meu@gmail.com";

            return this;
        }

        public static CustomerRequestBuilder Instance()
            => new CustomerRequestBuilder();

        public CustomerRequest Build() => _customerRequest;
    }
}
