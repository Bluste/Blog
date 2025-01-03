using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SimpleBlog.Models;

namespace SimpleBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);  // or DeleteBehavior.NoAction

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.IdentityUserId)
                .OnDelete(DeleteBehavior.Restrict);  // or DeleteBehavior.NoAction
            var userId = Guid.NewGuid().ToString(); // Simulating a new user ID

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = userId,
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    NormalizedUserName = "TESTUSER",
                    NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEFe/f9+27rbfF68RzZlQ1VNm/U4QxkCuB9sSO1vScxF5npGHlfc4U4FZPA9Zj65+Gg==" // Example hash, replace with actual hash in real use
                }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "First Post",
                    Content = "This is the content of the first post.",
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now,
                    IdentityUserId = userId  // Replace with actual User ID if needed
                },
                new Post
                {
                    Id = 2,
                    Title = "Second Post",
                    Content = "This is the content of the second post.",
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now,
                    IdentityUserId = userId  // Replace with actual User ID if needed
                }
            );

            // Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Content = "This is the first comment.",
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now,
                    PostId = 1,
                    IdentityUserId = userId,
                    Blog = 1
                },
                new Comment
                {
                    Id = 2,
                    Content = "This is the second comment.",
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now,
                    PostId = 1,
                    IdentityUserId = userId,
                    Blog = 1
                }
            );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Suppress the warning for pending model changes
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
