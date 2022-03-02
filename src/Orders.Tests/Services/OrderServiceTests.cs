using AutoMapper;
using Moq;
using Orders.AppService.Services;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Models;
using Orders.Domain.Models.Response.OrderResponse;
using Orders.Tests.Builders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Orders.Tests.Services
{
    public class OrderServiceTests
    {
        const string BEHAVIOR = "Validation methods of OrderSerice";
        const string TRAIT = "CustomerSerice";


        [Trait(BEHAVIOR, TRAIT)]
        [Fact(DisplayName = @"Case 1: Given a CreateOrder command on OrderController
                                      WHERE there is no problem with the request
                                      SHOULD create the order successfully.")]
        public static async void When_CreatingNewOrderForCustomer_Should_CreateSuccessfully()
        {
            //Arrange
            var orderCustomerReponse = new OrderResponseBuilder().WithFullData().Build();
            var orderCustomerRequest = new OrderRequestBuilder().WithFullData().Build();

            var mapperMock = MapperOrderMock(orderCustomerReponse);
            var orderRepositoryMock = CreateOrderMock(orderCustomerReponse);

            var sut = new OrderService(orderRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = await sut.AddNewOrder(Guid.NewGuid(), orderCustomerRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(orderCustomerReponse, result);
            Assert.IsType<CreateOrderResponse>(result);
            mapperMock.Verify(x => x.Map<OrderResponse>(It.IsAny<Order>()), Times.Once);
            orderRepositoryMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
        }

        private static Mock<IOrderRepository> CreateOrderMock(CreateOrderResponse expectedOrderResponse)
        {
            var orderRepositorMock = new Mock<IOrderRepository>();

            var objResponse = new Order()
            {
                Id = expectedOrderResponse.Id,
                CreatedAt = expectedOrderResponse.CreatedAt,
                Price = expectedOrderResponse.Price,
                CustomerId = Guid.NewGuid(),
            };

            orderRepositorMock.Setup(x => x.Add(It.IsAny<Order>()))
                .Returns(Task.FromResult(objResponse));

            return orderRepositorMock;
        }

        private static Mock<IMapper> MapperOrderMock(OrderResponse expectedOrderResponse)
        {
            var mapperMock = new Mock<IMapper>();

            mapperMock.Setup(x => x.Map<OrderResponse>(It.IsAny<Order>()))
                .Returns(expectedOrderResponse);

            return mapperMock;
        }
    }
}
