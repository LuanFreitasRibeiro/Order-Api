using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            try
            {
                var result = _context.Users.Add(user).Entity;
                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    Username = x.Username,
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
