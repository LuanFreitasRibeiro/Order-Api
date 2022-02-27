using System;

namespace Orders.Domain.Models.Response.CustomerResponse
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
