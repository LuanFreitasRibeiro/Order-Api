using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Add(Customer obj);
        Task<Customer> GetById(Guid id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
