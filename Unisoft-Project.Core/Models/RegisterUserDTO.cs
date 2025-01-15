
using System.ComponentModel.DataAnnotations;

namespace Unisoft_Project.Core.Models
{
    public class RegisterUserDTO
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;


        [Required]
        public string Avatar { get; set; } = string.Empty;

        [Required]
        public string WebsiteUrl { get; set; } = string.Empty;
    }
}
