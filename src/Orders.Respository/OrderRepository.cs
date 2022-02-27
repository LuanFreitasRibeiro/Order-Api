using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Models;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Respository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDataContext _context;

        public OrderRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task Add(Order obj)
        {
            try
            {
                _context.Orders.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
