using Moq;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.OrderResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Tests.Mocks
{
    public class OrderServiceMock
    {
        public OrderServiceMock()
        {
        }
        
        public Mock<IOrderService> CreateOrder(CreateOrderResponse expectedOrderResponse)
        {
            var orderServiceMock = new Mock<IOrderService>();

            orderServiceMock.Setup(x => x.AddNewOrder(It.IsAny<Guid>(), It.IsAny<OrderRequest>()))
                .Returns(Task.FromResult(expectedOrderResponse));

            return orderServiceMock;
        }

        public static OrderServiceMock Instance()
            => new OrderServiceMock();
    }
}
