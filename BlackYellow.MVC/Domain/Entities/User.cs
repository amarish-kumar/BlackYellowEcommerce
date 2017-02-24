
using BlackYellow.MVC.Domain.Enum;

namespace BlackYellow.MVC.Domain.Entites
{
    public class User
    {
        public int UserId { get; set; }

        public string Email{get; set;}

        public string Password { get; set; }

        public Profile Profile { get; set; }
    }
}