using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog.Models.Blog_posts> Blog_posts { get; set; } = default!;
        public DbSet<Blog.Models.Comments> Comments { get; set; } = default!;
        public DbSet<Blog.Models.Users> Users { get; set; } = default!;
    }
}
