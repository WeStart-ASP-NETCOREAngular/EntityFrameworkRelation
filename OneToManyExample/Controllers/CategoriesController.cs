using Microsoft.AspNetCore.Mvc;
using OneToManyExample.Data;
using OneToManyExample.Models;
using Microsoft.EntityFrameworkCore;

namespace OneToManyExample.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly PostDbContext _context;

        public CategoriesController(PostDbContext postDbContext)
        {
            _context = postDbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories =
                _context.Categories.Include(x => x.Posts).ToList();

            return View(categories);
        }
    }
}
