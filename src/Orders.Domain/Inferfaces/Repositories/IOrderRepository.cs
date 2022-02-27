using Orders.Domain.Models;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order obj);
    }
}
