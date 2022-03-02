using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.OrderResponse;
using System;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Services
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> AddNewOrder(Guid customerId, OrderRequest obj);
    }
}
