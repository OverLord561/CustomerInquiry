using AutoMapper;
using CustomerInquiryWebApi.ViewModels;
using Models;

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
                opts => opts.MapFrom(src => src.CustomerMobileNumber))
            .ForMember(dest => dest.Transactions,
                opts => opts.MapFrom(src => src.Transactions));
        }
    }
}
