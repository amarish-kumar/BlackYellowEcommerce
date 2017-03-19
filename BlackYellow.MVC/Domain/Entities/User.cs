
using System.ComponentModel.DataAnnotations;
using BlackYellow.MVC.Domain.Enum;

namespace BlackYellow.MVC.Domain.Entites
{
    public class User
    {

        public int UserId { get; set; }

        [Required]
        public string Email{get; set;}

        [Required]
        public string Password { get; set; }

        public Profile Profile { get; set; }

        //public bool isAdministrator()
        //{
            
        //}
    }
}