using AutoMapper;
using CustomerInquiryWebApi.ViewModels;
using Repositories;
using System;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Task<CustomerViewModel> GetDataByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerViewModel> GetDataByIdAndEmailAsync(int id, string email)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerViewModel> GetDataByIdAsync(int id)
        {
            return await _customerRepository.SingleOrDefaultAsync<CustomerViewModel>(x => x.CustomerID == id, _mapper.ConfigurationProvider);
        }
    }
}
