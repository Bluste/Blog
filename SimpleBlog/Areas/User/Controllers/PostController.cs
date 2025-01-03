using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models;
using System.Security.Claims;

namespace SimpleBlog.Areas.User.Controllers
{

    [Area("User")]
    public class PostController : Controller
    {

        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string searchQuery)
        {
            var posts = _db.Posts.Include(p => p.IdentityUser).AsQueryable();

            // Handle search query if it's provided
            if (!string.IsNullOrEmpty(searchQuery))
            {
                posts = posts.Where(p => p.Title.Contains(searchQuery));
            }

            // Pass the searchQuery to the view using ViewData
            ViewData["SearchQuery"] = searchQuery;

            return View(posts.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                post.Create_At = DateTime.Now;
                post.Update_At = DateTime.Now;
                post.IdentityUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                     ?? User.FindFirst("sub")?.Value; ; // Assuming you store user ID in Identity

                _db.Posts.Add(post);
                _db.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            else 
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(post);
            }

            return View(post);
        }

    }
}
