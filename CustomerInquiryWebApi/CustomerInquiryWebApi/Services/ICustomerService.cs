using CustomerInquiryWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.Services
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetDataByIdAsync(int id);

        Task<CustomerViewModel> GetDataByEmailAsync(string email);

        Task<CustomerViewModel> GetDataByIdAndEmailAsync(int id, string email);

        bool IsEmailValid(string email);

        bool IsCustomerIdValid(int id);
    }
}
