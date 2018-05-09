
using BlackYellow.Core.Domain.Models;
using System;

namespace BlackYellow.Authentication.Domain.Addresses
{ 
    public class Address : Entity
    { 

        public string Street { get; set; }

       
        public string Number { get; set; }

      
        public string ZipCode { get; set; }

      
        public string State { get; set; }

      
        public string City { get; set; }

       
    }
}
