using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

namespace CurrencyChallenge.Infrastructure
{

    public class AutoMappingConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Infrastructure.AutoMappingProfile());
            });

            return config;
        }
    }

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Entities.Currency, Models.CurrencyModel>().ReverseMap().ForMember(dst => dst.Id, opt => opt.SetMappingOrder(0));
            CreateMap<Entities.DolarExchangeRate, Models.DolarExchangeRateModel>().ReverseMap();
            CreateMap<Entities.CurrencyTransaction, Models.CurrencyTransactionModel>().ReverseMap();
        }
    }




}
