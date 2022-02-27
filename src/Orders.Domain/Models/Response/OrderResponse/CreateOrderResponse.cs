using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Models.Response.OrderResponse
{
    public class CreateOrderResponse : OrderResponse
    {
        public Guid CustomerId { get; set; }
    }
}
