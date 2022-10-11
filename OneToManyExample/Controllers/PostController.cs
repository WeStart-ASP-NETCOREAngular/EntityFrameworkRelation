using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneToManyExample.Data;
using OneToManyExample.Models;
using OneToManyExample.ViewModels;

namespace OneToManyExample.Controllers
{
    public class PostController : Controller
    {
        private readonly PostDbContext _context;

        public PostController(PostDbContext postDbContext)
        {
            _context = postDbContext;
        }
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.Include(x => x.Category).ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = _context.Categories.ToList();

            AddPostVM addPostVM = new AddPostVM();
            addPostVM.categories = new SelectList(categories, "Id", "Name");


            return View(addPostVM);
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
    }
}
