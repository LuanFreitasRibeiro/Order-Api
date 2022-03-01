using Microsoft.AspNetCore.Mvc;
using Moq;
using Orders.Api.Controllers;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Response.CustomerResponse;
using Orders.Tests.Builders;
using Orders.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Tests.Controllers
{
    public class CustomerControllerTests
    {
        const string BEHAVIOR = "Validation methods of CustomerController";
        const string TRAIT = "CustomerController";


        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 1: Given a CreateCustomer command on CustomerController
                                      WHERE there is no problem with the request
                                      SHOULD create the customer successfully.")]
        public static async void When_CreatingNewCustomer_Should_CreateSuccessfully()
        {
            //Arrange
            var customerResponse = new CustomerResponseBuilder().WithFullData().Build();
            var customerRequest = new CustomerRequestBuilder().WithFullData().Build();
            var customerServiceMock = new CustomerServiceMock().CreateCustomer(customerResponse);

            var sut = new CustomerController(customerServiceMock.Object);

            //Act
            var result = await sut.CreateCustomer(customerRequest);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedResult>(result);
            customerServiceMock.Verify(x => x.CreateNewCustomer(It.IsAny<CustomerRequest>()), Times.Once);
        }
        
        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 2: Given a CreateCustomer command on CustomerController
                                      WHERE the Name property was not informed
                                      SHOULD return error message.")]
        public static async void When_CreatingNewCustomer_Should_ReturnBadRequest()
        {
            //Arrange
            var customerRequest = new CustomerRequestBuilder().WithoutName().Build();
            var customerServiceMock = new Mock<ICustomerService>();

            var sut = new CustomerController(customerServiceMock.Object);

            //Act
            var result = await sut.CreateCustomer(customerRequest);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            customerServiceMock.Verify(x => x.CreateNewCustomer(It.IsAny<CustomerRequest>()), Times.Never);
        }

        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 3: Given a GetCustomerById command on CustomerController
                                      SHOULD return successfully.")]
        public static async void When_GettingCustomerById_Should_ReturnCustomerData()
        {
            //Arrange
            var customerResponse = new CustomerOrdersResponseBuilder().WithFullData().Build();
            var customerServiceMock = new CustomerServiceMock().GetCustomerById(customerResponse);

            var sut = new CustomerController(customerServiceMock.Object);

            //Act
            var result = await sut.GetCustomerById(customerResponse.Id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            customerServiceMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 4: Given a GetCustomerById command on CustomerController
                                      WHERE the given id was not found
                                      SHOULD return NotFound.")]
        public static async void When_GettingCustomerById_Should_ReturnNotFound()
        {
            //Arrange
            var customerResponse = new CustomerOrdersResponseBuilder().Build();
            var customerServiceMock = new CustomerServiceMock().GetCustomerById(null);

            var sut = new CustomerController(customerServiceMock.Object);

            //Act
            var result = await sut.GetCustomerById(customerResponse.Id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
            customerServiceMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
        }
    }
}
