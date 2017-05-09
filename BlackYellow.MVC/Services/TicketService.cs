using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Interfaces.Services;

namespace BlackYellow.MVC.Services
{
    public class TicketService : IPayment
    {
        string IPayment.HtmlResult
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void IPayment.ExecutePay()
        {
            throw new NotImplementedException();
        }
    }
}
