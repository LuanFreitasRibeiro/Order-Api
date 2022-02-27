using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Respository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(StoreDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(Customer obj)
        {
            try
            {
                _context.Customers.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                return await _context.Customers
                    .Select(x => new Customer
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email
                    })
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> GetById(Guid id)
        {
            try
            {
                var customerResult =  await _context.Customers
                    .Where(x => x.Id == id)
                    .AsNoTracking()
                    .FirstAsync();

                var ordersResult = await _context.Orders
                    .Where(x => x.CustomerId == id)
                    .ToListAsync();

                var orderList = new List<Order>();

                foreach (var order in ordersResult)
                {
                    orderList.Add(new Order()
                    {
                        Id=order.Id,
                        Price = order.Price,
                        CreatedAt = order.CreatedAt,
                    });
                }

                var obj = new Customer()
                {
                    Id = customerResult.Id,
                    Email = customerResult.Email,
                    Name = customerResult.Name,
                    Orders = orderList
                };

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
