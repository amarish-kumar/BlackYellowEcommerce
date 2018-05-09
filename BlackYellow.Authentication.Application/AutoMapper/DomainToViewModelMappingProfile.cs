using AutoMapper;
using BlackYellow.Authentication.Application.ViewModels;
using BlackYellow.Authentication.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.Email,
                opts => opts.MapFrom(src => src.User.Email));
        }
    }
}
