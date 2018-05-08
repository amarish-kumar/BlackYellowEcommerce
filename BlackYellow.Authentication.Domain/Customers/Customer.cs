using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Users;
using BlackYellow.Core.Domain.Models;
using System;

namespace BlackYellow.Authentication.Domain.Customers
{
    public class Customer : Entity
    { 
        public Guid UserId { get; set; }
        public string FirstName { get;  set; }
   
        public string LastName { get;  set; }
        
        public DateTime Birthday { get;  set; }
       
        public string Cpf { get;  set; }
        
        public string Phone { get; set; }

        public Address Address { get; set; }
       
        public User User { get; set; }



        public Customer(Guid id, string firstName, string lastName, DateTime birthday, string cpf, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Cpf = cpf;
            Phone = phone;
        }

        public void FillAddress(Address address)
        {
            Address = address;
        } 
    }
}
