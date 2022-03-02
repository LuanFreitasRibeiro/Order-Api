using Orders.Domain.Models;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order obj);
    }
}
