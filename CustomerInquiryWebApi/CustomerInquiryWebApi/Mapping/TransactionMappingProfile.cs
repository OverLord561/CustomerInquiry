using AutoMapper;
using CustomerInquiryWebApi.Extensions;
using CustomerInquiryWebApi.ViewModels;
using Models;

namespace CustomerInquiryWebApi.Mapping
{
    public class TransactionMappingProfile: Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<Transaction, TransactionViewModel>()
                .ForMember(dest => dest.Id,
                    opts => opts.MapFrom(src => src.TransactionID))
                .ForMember(dest => dest.Date,
                    opts => opts.MapFrom(src => src.TransactionDate.DateTimeTo_ddMMyyyy_hhmm()))
                .ForMember(dest => dest.Amount,
                    opts => opts.MapFrom(src => src.TransactionAmount))
                .ForMember(dest => dest.Currency,
                    opts => opts.MapFrom(src => src.Currency.CurrencyName))
                .ForMember(dest => dest.Status,
                    opts => opts.MapFrom(src=>src.Status.StatusName));
        }
    }
}
