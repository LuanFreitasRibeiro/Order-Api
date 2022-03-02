using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Models.Response.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
