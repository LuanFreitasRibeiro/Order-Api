using System;
using System.Text.Json.Serialization;

namespace Orders.Domain.Models
{
    public class Order : Base
    {
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public Guid CustomerId { get; set; }
    }
}