using System.Collections.Generic;

namespace Orders.Domain.Models.Response.CustomerResponse
{
    public class CustomerOrdersResponse : CustomerResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
