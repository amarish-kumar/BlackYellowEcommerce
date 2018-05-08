using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application.ViewModels
{
    public class CustomerViewModel
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Cpf { get; set; }

        public string Phone { get; set; }

    }
}
