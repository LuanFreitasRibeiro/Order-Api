using System.Collections.Generic;

namespace Orders.Domain.Models
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
