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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Get the post by ID
            var post = _db.Posts.FirstOrDefault(p => p.Id == id);

            // Check if the post exists
            if (post == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Ensure the logged-in user is the author of the post
            if (post.IdentityUserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized(); // Return 401 if the user is not the author
            }

            return View(post); // Return the post to the view for editing
        }

        // Edit [POST] Action
        [HttpPost]
        public IActionResult Edit(int id, Post post)
        {
            // Get the original post
            var originalPost = _db.Posts.FirstOrDefault(p => p.Id == id);

            // Check if the post exists
            if (originalPost == null)
            {
                return NotFound();
            }

            // Ensure the logged-in user is the author of the post
            if (originalPost.IdentityUserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            {
                return Unauthorized(); // Return 401 if the user is not the author
            }

            if (ModelState.IsValid)
            {
                // Update the original post with new values
                originalPost.Title = post.Title;
                originalPost.Content = post.Content;
                originalPost.Update_At = DateTime.Now; // Update the timestamp

                // Save the changes to the database
                _db.SaveChanges();

                return RedirectToAction("Index", "Home"); // Redirect after successful update
            }

            return View(post); // Return the updated post to the view in case of errors
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

            // Ensure the logged-in user is the one who created the post
            if (post.IdentityUserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }

            // Delete all associated comments before deleting the post
            if (post.Comments != null)
            {
                _db.Comments.RemoveRange(post.Comments);  // Removes all comments related to the post
            }

            _db.Posts.Remove(post);  // Removes the post itself
            _db.SaveChanges();  // Save the changes to the database

            return RedirectToAction("Index", "Home");
        }

    }
}
