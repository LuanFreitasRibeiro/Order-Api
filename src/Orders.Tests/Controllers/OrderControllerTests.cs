using Microsoft.AspNetCore.Mvc;
using Moq;
using Orders.Api.Controllers;
using Orders.Domain.Models.Request.Order;
using Orders.Tests.Builders;
using Orders.Tests.Mocks;
using System;
using Xunit;

namespace Orders.Tests.Controllers
{
    public class OrderControllerTests
    {
        const string BEHAVIOR = "Validation methods of OrderController";
        const string TRAIT = "OrderController";

        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 1: Given a CreateOrder command on OrderController
                                      SHOULD create the order successfully.")]
        public static async void When_CreatingNewOrder_Should_CreateSuccessfully()
        {
            //Arrange
            var customerResponse = new CustomerOrdersResponseBuilder().WithFullData().Build();
            var orderRequest = new OrderRequestBuilder().WithFullData().Build();
            var orderResponse = new CreateOrderResponseBuilder().WithFullData().Build();
            var customerServiceMock = new CustomerServiceMock().GetCustomerById(customerResponse);
            var orderServiceMock = new OrderServiceMock().CreateOrder(orderResponse);

            var sut = new OrderController(orderServiceMock.Object, customerServiceMock.Object);

            //Act
            var result = await sut.AddNewOrder(customerResponse.Id, orderRequest);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedResult>(result);
            customerServiceMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            orderServiceMock.Verify(x => x.AddNewOrder(It.IsAny<Guid>(), It.IsAny<OrderRequest>()), Times.Once);
        }

        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 2: Given a CreateOrder command on OrderController
                                      WHERE the given customerId was not found 
                                      SHOULD retorn BadRequest.")]
        public static async void When_CreatingNewOrder_Should_ReturnBadRequest()
        {
            //Arrange
            var customerResponse = new CustomerOrdersResponseBuilder().Build();
            var orderRequest = new OrderRequestBuilder().WithFullData().Build();
            var orderResponse = new CreateOrderResponseBuilder().WithFullData().Build();
            var customerServiceMock = new CustomerServiceMock().GetCustomerById(null);
            var orderServiceMock = new OrderServiceMock().CreateOrder(orderResponse);

            var sut = new OrderController(orderServiceMock.Object, customerServiceMock.Object);

            //Act
            var result = await sut.AddNewOrder(Guid.NewGuid(), orderRequest);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            customerServiceMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            orderServiceMock.Verify(x => x.AddNewOrder(It.IsAny<Guid>(), It.IsAny<OrderRequest>()), Times.Never);
        }
    }
}
