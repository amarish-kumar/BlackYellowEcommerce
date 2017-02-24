using System;



namespace BlackYellow.MVC.Domain.Entites
{

    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public DateTime Birthday {get; set;}

        public string Cpf { get; set; }

        public Address Address{get; set;}

        public User User{get; set;}


        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }


    }
}