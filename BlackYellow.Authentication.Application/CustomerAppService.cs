using AutoMapper;
using BlackYellow.Authentication.Application.Interfaces;
using BlackYellow.Authentication.Application.ViewModels;
using BlackYellow.Authentication.Domain.Commands;
using BlackYellow.Authentication.Domain.Customers;
using BlackYellow.Authentication.Domain.Customers.Interfaces;
using BlackYellow.Core.Domain.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
       // private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(IMapper mapper,
                                 ICustomerRepository customerRepository,
                                 IMediatorHandler bus)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public void Add(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Guid id)
        {
           return _customerRepository.GetById(id);
        }

        public Customer Get(long id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Customer GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
