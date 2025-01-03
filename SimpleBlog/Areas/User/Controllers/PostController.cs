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

            if (!string.IsNullOrEmpty(searchQuery))
            {
                posts = posts.Where(p => p.Title.Contains(searchQuery));
            }

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
                     ?? User.FindFirst("sub")?.Value;

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
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound(); 
            }
            // Ensure the logged-in user is the author of the post
            if (post.IdentityUserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized(); 
            }
            return View(post); 
        }

        // Edit [POST] Action
        [HttpPost]
        public IActionResult Edit(int id, Post post)
        {
            var originalPost = _db.Posts.FirstOrDefault(p => p.Id == id);

            if (originalPost == null)
            {
                return NotFound();
            }
            
            if (originalPost.IdentityUserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized(); 
            }

            if (ModelState.IsValid)
            {
                
                originalPost.Title = post.Title;
                originalPost.Content = post.Content;
                originalPost.Update_At = DateTime.Now;

                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(post); 
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var post = _db.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            if (post.IdentityUserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }

            if (post.Comments != null)
            {
                _db.Comments.RemoveRange(post.Comments); 
            }

            _db.Posts.Remove(post);  
            _db.SaveChanges();  

            return RedirectToAction("Index", "Home");
        }
    }
}
