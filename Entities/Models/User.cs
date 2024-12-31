using Microsoft.AspNetCore.Identity;


namespace Entities.Models
{

    //For Ientity
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
