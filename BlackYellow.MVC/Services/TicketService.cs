using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Interfaces.Services;

namespace BlackYellow.MVC.Services
{
    public class TicketService : IPayment
    {

        private Domain.Entites.Customer _customer;
        private double _value;
        private DateTime _dueDate;

        public TicketService(Domain.Entites.Customer customer, double value, DateTime dueDate)
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
