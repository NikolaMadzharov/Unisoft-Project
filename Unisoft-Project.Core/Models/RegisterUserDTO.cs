
using System.ComponentModel.DataAnnotations;

namespace Unisoft_Project.Core.Models
{
    public class RegisterUserDTO
    {

        [Required]
        [StringLength(15)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(40)]
        public string Email { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;


        [Required]
        [StringLength(200)]
        public string Avatar { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string WebsiteUrl { get; set; } = string.Empty;
    }
}
