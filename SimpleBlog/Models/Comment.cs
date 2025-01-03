using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
        [ValidateNever]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public int PostId{ get; set; }
        [ForeignKey("PostId")]
        [ValidateNever]
        public Post Post { get; set; }

        public int Blog { get; set; }
    }
}
