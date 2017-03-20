using System;
using System.ComponentModel.DataAnnotations;

namespace BlackYellow.MVC.Domain.Entites
{

    public class Customer
    {
        public int CustomerId { get; set; }
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
        
        public Address Address { get; set; }

        public User User { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


    }
}