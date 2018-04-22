
using System.ComponentModel.DataAnnotations;
using BlackYellow.Domain.Enum;

namespace BlackYellow.Domain.Entites
{
    public class User
    {
        [Dapper.Contrib.Extensions.Key]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Por favor digite um e-mail.")]
        [EmailAddress(ErrorMessage = "Por favor digite um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha.")]
        public string Password { get; set; }

        public Profile Profile { get; set; }


        public bool EmailIsValid()
        {
            return this.Email.Contains("@");
        }
    }
}