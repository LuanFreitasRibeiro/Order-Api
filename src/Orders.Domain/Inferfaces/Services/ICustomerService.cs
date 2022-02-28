using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateNewCustomer(CustomerRequest obj);
        Task<CustomerOrdersResponse> GetById(Guid id);
        Task<IEnumerable<CustomerResponse>> GetAll();
    }
}
