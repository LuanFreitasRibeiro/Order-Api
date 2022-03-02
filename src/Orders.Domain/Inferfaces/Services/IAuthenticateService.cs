using Orders.Domain.Models.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Inferfaces.Services
{
    public interface IAuthenticateService
    {
        Task<dynamic> Authenticate(AuthenticateRequest authenticate);
    }
}
