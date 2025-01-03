using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class Blog_postsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Blog_postsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blog_posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog_posts.ToListAsync());
        }

        // GET: Blog_posts/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Blog_posts/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Blog_posts.Where(x => x.Title.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Blog_posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog_posts = await _context.Blog_posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog_posts == null)
            {
                return NotFound();
            }

            return View(blog_posts);
        }

        // GET: Blog_posts/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog_posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Created_at,Updated_at,User_id")] Blog_posts blog_posts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog_posts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog_posts);
        }

        // GET: Blog_posts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog_posts = await _context.Blog_posts.FindAsync(id);
            if (blog_posts == null)
            {
                return NotFound();
            }
            return View(blog_posts);
        }

        // POST: Blog_posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Created_at,Updated_at,User_id")] Blog_posts blog_posts)
        {
            if (id != blog_posts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog_posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Blog_postsExists(blog_posts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog_posts);
        }

        // GET: Blog_posts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog_posts = await _context.Blog_posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog_posts == null)
            {
                return NotFound();
            }

            return View(blog_posts);
        }

        // POST: Blog_posts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog_posts = await _context.Blog_posts.FindAsync(id);
            if (blog_posts != null)
            {
                _context.Blog_posts.Remove(blog_posts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Blog_postsExists(int id)
        {
            return _context.Blog_posts.Any(e => e.Id == id);
        }
    }
}
