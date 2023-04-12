using Microsoft.AspNetCore.Identity;

namespace AnliseHospitais.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserCompleteName { get; set; }
    }
}
