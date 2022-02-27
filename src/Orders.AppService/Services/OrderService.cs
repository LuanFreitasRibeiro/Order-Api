using AutoMapper;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using Orders.Domain.Models.Response.OrderResponse;
using System;
using System.Threading.Tasks;

namespace Orders.AppService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> AddNewOrder(Guid customerId, OrderRequest obj)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Price = obj.Price,
                CustomerId = customerId,
            };

            await _repository.Add(order);

            return _mapper.Map<CreateOrderResponse>(order);
        }
    }
}
