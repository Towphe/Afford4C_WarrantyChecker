using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Repo
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string VerificationCode { get; set; } = string.Empty;
    }
}
