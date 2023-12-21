using Microsoft.AspNetCore.Identity;

namespace FPTWeb.Data
{
    public partial class FptBookUser : IdentityUser
    {
            public string? Name { get; set; }

            public string? ProfilePicture { get; set; }
    }
}
