using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Domain.Entites
{

    public class Customer
    {
        public long CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public DateTime Birthday { get; set; }
        [Required]

        public string Cpf { get; set; }
        [Required]

        public string Phone { get; set; }

        public long UserId { get; set; }
        [Write(false)]
        public Address Address { get; set; }
        [Write(false)]
        public User User { get; set; }

        [Write(false)]
                public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


    }
}