using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }

    }
}