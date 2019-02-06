using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiryWebApi.ViewModels;

namespace CustomerInquiryWebApi.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.CustomerID,
                    opts => opts.MapFrom(src => src.CustomerID))
            .ForMember(dest => dest.Name,
                opts => opts.MapFrom(src => src.CustomerName))
            .ForMember(dest => dest.Email,
                opts => opts.MapFrom(src => src.CustomerContactEmail))
            .ForMember(dest => dest.Mobile,
                opts => opts.MapFrom(src => src.CustomerMobileNumer))
            .ForMember(dest => dest.Transactions,
                opts => opts.Ignore());
        }
    }
}
