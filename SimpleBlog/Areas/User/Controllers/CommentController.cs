using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SimpleBlog.Data;
using SimpleBlog.Models;
using System.Security.Claims;

namespace SimpleBlog.Areas.User.Controllers
{

    [Area("User")]
    public class CommentController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {

                comment.Create_At = DateTime.Now;
                comment.Update_At = DateTime.Now;
                comment.IdentityUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? User.FindFirst("sub")?.Value; 

                _db.Comments.Add(comment);
                _db.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return RedirectToAction("Index", "Home");
            }
        }

    }
}
