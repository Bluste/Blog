using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data;
using Microsoft.AspNetCore.Authorization;
using SimpleBlog.Data;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")] 
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string username, string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = username, Email = email };
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string username, string email)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = username;
            user.Email = email;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var commentsMadeByUser = _context.Comments.Where(c => c.IdentityUserId == user.Id).ToList();
            _context.Comments.RemoveRange(commentsMadeByUser);

            var postsMadeByUser = _context.Posts.Where(p => p.IdentityUserId == user.Id).ToList();
            var postIds = postsMadeByUser.Select(p => p.Id).ToList();
            var allCommentsOnUserPosts = _context.Comments.Where(c => postIds.Contains(c.PostId)).ToList();
            _context.Comments.RemoveRange(allCommentsOnUserPosts);


            _context.Posts.RemoveRange(postsMadeByUser);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

    }
}
