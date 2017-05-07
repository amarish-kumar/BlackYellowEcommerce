


using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Domain.Entites
{
    [Table("Adresses")]
    public class Address
    {
        [Dapper.Contrib.Extensions.Key]
        public long AddressId { get; set; }
        [Required]
        public string Street { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }

       
        public long CustomerId { get; set; }
       

    }
}