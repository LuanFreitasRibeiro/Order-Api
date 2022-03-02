using Orders.Domain.Models.Request.User;
using Orders.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> CreateUser(UserRequest user);
        Task<IEnumerable<UserResponse>> GetUsers();
        Task<UserResponse> GetUserById(Guid id);
    }
}
