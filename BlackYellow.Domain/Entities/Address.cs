using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace BlackYellow.Domain.Entites
{
     [Table("Adresses")]
    public class Address
    {
        [Dapper.Contrib.Extensions.Key]
        public long AddressId { get; set; }

        [Required(ErrorMessage = "Por favor digite a Rua")]
        public string Street { get; set; }
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Por favor digite o número")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Por favor digite o CEP")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Por favor digite o Estado (UF)")]
        [MaxLength(2, ErrorMessage = "A UF contém apenas 2 caracteres, ex.: SP, RJ, MG")]
        public string State { get; set; }

        [Required(ErrorMessage = "Por favor digite a data de nascimento")]
        public string City { get; set; }

        public long CustomerId { get; set; }


    }
}