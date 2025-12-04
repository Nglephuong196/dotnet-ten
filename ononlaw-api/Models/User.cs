using Microsoft.AspNetCore.Identity;

namespace ononlaw_api.Models
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; }
    }
}
