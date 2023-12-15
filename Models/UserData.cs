using Microsoft.AspNetCore.Identity;

namespace IdentityUserCustom.Models
{
    public class UserData : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
