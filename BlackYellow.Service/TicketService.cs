using System;
using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;

namespace BlackYellow.Service
{
    public class TicketService : IPayment
    {

        private Customer _customer;
        private double _value;
        private DateTime _dueDate;

        public TicketService(Customer customer, double value, DateTime dueDate)
        {
            _customer = customer;
            _value = value;
            _dueDate = dueDate;
        }

        string IPayment.HtmlResult
        {
            get
            {
                return null;
            }
        }

        void IPayment.ExecutePay()
        {
            throw new NotImplementedException();
        }
    }
}
