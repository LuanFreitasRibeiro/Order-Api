using AutoMapper;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models;
using Orders.Domain.Models.Request.User;
using Orders.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Orders.AppService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> CreateUser(UserRequest user)
        {
            Hash hash = new Hash(SHA256.Create());

            var obj = new User()
            {
                Id = Guid.NewGuid(),
                Username = user.Username,
                Password = hash.EncryptPassword(user.Password),
            };

            var addEntity = await _userRepository.Add(obj);

            return _mapper.Map<UserResponse>(addEntity);
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var response = await _userRepository.GetUserById(id);

            var result = _mapper.Map<UserResponse>(response);

            return result;
        }

        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var response = await _userRepository.GetUsers();

            var result = _mapper.Map<IEnumerable<UserResponse>>(response);

            return result;
        }
    }
}
