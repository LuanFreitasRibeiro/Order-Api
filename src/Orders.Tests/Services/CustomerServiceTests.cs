using AutoMapper;
using Moq;
using Orders.AppService.Services;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Models;
using Orders.Domain.Models.Response.CustomerResponse;
using Orders.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Tests.Services
{
    public class CustomerServiceTests
    {
        const string BEHAVIOR = "Validation methods of CustomerSerice";
        const string TRAIT = "CustomerSerice";

        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 1: Given a CreateCustomer command on CustomerController
                                      WHERE there is no problem with the request
                                      SHOULD create the customer successfully.")]
        public static async void When_CreatingNewCustomer_Should_CreateSuccessfully()
        {
            //Arrange
            var createCustomerReponse = new CustomerResponseBuilder().WithFullData().Build();
            var createCustomerRequest = new CustomerRequestBuilder().WithFullData().Build();

            var mapperMock = MapperMock(createCustomerReponse);
            var customerRepositoryMock = CreateCustomerMock(createCustomerReponse);

            var sut = new CustomerService(customerRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = await sut.CreateNewCustomer(createCustomerRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createCustomerReponse, result);
            Assert.IsType<CustomerResponse>(result);
            mapperMock.Verify(x => x.Map<CustomerResponse>(It.IsAny<Customer>()), Times.Once);
            customerRepositoryMock.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
        }

        private static Mock<ICustomerRepository> CreateCustomerMock(CustomerResponse expectedCustomerResponse)
        {
            var customerRepositorMock = new Mock<ICustomerRepository>();

            var objResponse = new Customer()
            {
                Id = expectedCustomerResponse.Id,
                Email = expectedCustomerResponse.Email,
                Name = expectedCustomerResponse.Name,
            };

            customerRepositorMock.Setup(x => x.Add(It.IsAny<Customer>()))
                .Returns(Task.FromResult(objResponse));

            return customerRepositorMock;
        }

        private static Mock<IMapper> MapperMock(CustomerResponse expectedCustomerResponse)
        {
            var mapperMock = new Mock<IMapper>();

            mapperMock.Setup(x => x.Map<CustomerResponse>(It.IsAny<Customer>()))
                .Returns(expectedCustomerResponse);

            return mapperMock;
        }
    }
}
