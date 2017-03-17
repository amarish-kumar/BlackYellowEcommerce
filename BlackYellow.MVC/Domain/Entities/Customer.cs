using System;



namespace BlackYellow.MVC.Domain.Entites
{

    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Cpf { get; set; }
        public string Phone { get; set; }


        public Address Address { get; set; }

        public User User { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


    }
}