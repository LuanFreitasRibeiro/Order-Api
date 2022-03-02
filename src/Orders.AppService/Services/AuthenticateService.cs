﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Orders.AppService.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly StoreDataContext _context;
        private readonly IMapper _mapper;

        public AuthenticateService(StoreDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<dynamic> Authenticate(AuthenticateRequest authenticate)
        {
            Hash hash = new Hash(SHA256.Create());

            var encripPassRequest = hash.EncryptPassword(authenticate.Password);

            var user = await _context.Users
                   .AsNoTracking()
                   .Where(x => x.Username == authenticate.Username && x.Password == encripPassRequest)
                   .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception(message: "Username or Password is invalid");

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
