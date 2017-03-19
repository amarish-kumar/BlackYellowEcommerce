


using System.ComponentModel.DataAnnotations;

namespace BlackYellow.MVC.Domain.Entites
{

    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string Street { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string Number { get; set; }     
        [Required]
        public string  ZipCode { get; set; }     
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
    }
}