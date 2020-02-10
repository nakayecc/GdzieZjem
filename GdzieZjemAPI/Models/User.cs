using System.ComponentModel.DataAnnotations;

namespace GdzieZjemAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}