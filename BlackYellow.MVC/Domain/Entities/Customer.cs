using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Domain.Entites
{

    public class Customer
    {

        [Dapper.Contrib.Extensions.Key]
        public long CustomerId { get; set; }

        [Required(ErrorMessage = "Por favor digite o nome")]
        [DisplayName("Primeiro Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Por favor digite o sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Por favor digite a data de nascimento")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Por favor digite o CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor digite o telefone")]
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