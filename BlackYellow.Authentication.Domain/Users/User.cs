using BlackYellow.Authentication.Domain.Users.Enums;
using BlackYellow.Core.Domain.Models;

namespace BlackYellow.Authentication.Users
{
    public class User : Entity
    {   
        public string Email { get; set; }

        public string Password { get; set; }

        public EProfile Profile { get; set; }


        public bool EmailIsValid()
        {
            return this.Email.Contains("@");
        }
    }
}