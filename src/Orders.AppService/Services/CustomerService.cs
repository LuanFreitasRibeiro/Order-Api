using AutoMapper;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Response.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.AppService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> CreateNewCustomer(CustomerRequest obj)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Email = obj.Email,
                Name = obj.Name
            };

            var responseAdd = await _repository.Add(customer);

            return _mapper.Map<CustomerResponse>(responseAdd);
        }

        public async Task<IEnumerable<CustomerResponse>> GetAll()
        {
            var response = await _repository.GetAll();

            return _mapper.Map<IEnumerable<CustomerResponse>>(response);
        }

        public async Task<CustomerOrdersResponse> GetById(Guid id)
        {
            var resp = await _repository.GetById(id);

            return _mapper.Map<CustomerOrdersResponse>(resp);
        }
    }
}
