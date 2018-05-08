using System;
using BlackYellow.Core.Domain.Bus;
using MediatR;
using BlackYellow.Authentication.Domain.Commands;
using BlackYellow.Core.Domain.Interfaces;
using BlackYellow.Core.Domain.Notifications;
using BlackYellow.Authentication.Domain.Customers;
using BlackYellow.Authentication.Domain.Customers.Interfaces;
using BlackYellow.Authentication.Domain.Events;

namespace Equinox.Domain.CommandHandlers
{
    public class CustomerCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewCustomerCommand>,
        INotificationHandler<UpdateCustomerCommand>,
        INotificationHandler<RemoveCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(Guid.NewGuid(), message.FirstName, message.LastName, message.Birthday, message.Cpf, message.Phone);

            if (_customerRepository.GetByEmail(customer.User.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
                return;
            }
            
            _customerRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRegisteredEvent(Guid.NewGuid(), message.FirstName, message.LastName, message.Phone, message.Cpf, message.Birthday, message.User, message.Address));
            }
        }

        public void Handle(UpdateCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Customer(message.Id, message.FirstName, message.LastName, message.Birthday, message.Cpf, message.Phone);
            var existingCustomer = _customerRepository.GetByEmail(customer.User.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType,"The customer e-mail has already been taken."));
                    return;
                }
            }

            _customerRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, message.FirstName, message.LastName, message.Phone, message.Cpf, message.Birthday, message.User, message.Address));
            }
        }

        public void Handle(RemoveCustomerCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _customerRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}