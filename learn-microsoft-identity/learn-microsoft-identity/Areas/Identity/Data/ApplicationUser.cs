using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace learn_microsoft_identity.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
