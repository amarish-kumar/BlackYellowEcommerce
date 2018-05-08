using AutoMapper;
using BlackYellow.Authentication.Application.ViewModels;
using BlackYellow.Authentication.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.FirstName, c.LastName, c.Cpf, c.Phone, c.Birthday, null, null));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.FirstName,c.LastName, c.Cpf, c.Phone, c.Birthday, null , null));
        }
    }
}
