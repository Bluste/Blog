using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Create_At{ get; set; }
        public DateTime Update_At { get; set; }
        [ValidateNever]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        [ValidateNever]
        public IdentityUser IdentityUser { get; set; }
        public IEnumerable<Comment>? Comments { get; set; } 
    }
}
