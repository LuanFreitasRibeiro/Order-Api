using Moq;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Threading.Tasks;

namespace Orders.Tests.Mocks
{
    public class CustomerServiceMock
    {
        public CustomerServiceMock()
        {
        }

        public Mock<ICustomerService> CreateCustomer(CustomerResponse expectedCustomerResponse)
        {
            var customerServiceMock = new Mock<ICustomerService>();

            customerServiceMock.Setup(x => x.CreateNewCustomer(It.IsAny<CustomerRequest>()))
                .Returns(Task.FromResult(expectedCustomerResponse));

            return customerServiceMock;
        }

        public Mock<ICustomerService> GetCustomerById(CustomerOrdersResponse expectedCustomerResponse)
        {
            var customerServiceMock = new Mock<ICustomerService>();

            customerServiceMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(expectedCustomerResponse));

            return customerServiceMock;
        }

        public static CustomerServiceMock Instance()
            => new CustomerServiceMock();
    }
}
