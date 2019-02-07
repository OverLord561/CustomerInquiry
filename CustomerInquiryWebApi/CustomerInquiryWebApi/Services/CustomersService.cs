using AutoMapper;
using CustomerInquiryWebApi.ViewModels;
using Repositories;
using System;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersService(ICustomerRepository customerRepository, IMapper mapper)
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

        public bool IsCustomerIdValid(string id)
        {
            if (String.IsNullOrEmpty(id) || id.Length >= 10)
            {
                return false;
            }

            return int.TryParse(id, out var idResult);
            
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Length <= 25;
        }
    }
}
