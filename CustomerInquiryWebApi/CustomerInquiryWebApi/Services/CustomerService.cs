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

        public async Task<CustomerViewModel> GetDataByEmailAsync(string email)
        {
            return await _customerRepository
                .SingleOrDefaultAsync<CustomerViewModel>
                (
                    x => x.CustomerContactEmail.ToLower().Equals(email.ToLower()),
                    _mapper.ConfigurationProvider
                );

        }

        public async Task<CustomerViewModel> GetDataByIdAndEmailAsync(int id, string email)
        {
            return await _customerRepository
                .SingleOrDefaultAsync<CustomerViewModel>
                (
                    x => x.CustomerContactEmail.ToLower().Equals(email.ToLower())
                        && x.CustomerID == id,
                    _mapper.ConfigurationProvider
                );
        }

        public async Task<CustomerViewModel> GetDataByIdAsync(int id)
        {
            return await _customerRepository.SingleOrDefaultAsync<CustomerViewModel>(x => x.CustomerID == id, _mapper.ConfigurationProvider);
        }

        public bool IsCustomerIdValid(int id)
        {
            return id > 0 && id.ToString().Length <= 10;
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Length <= 25;
        }
    }
}
