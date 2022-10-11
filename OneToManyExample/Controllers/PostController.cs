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
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostController(PostDbContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
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
        public IActionResult Add(AddPostVM post)
        {

            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(post.Image.FileName);
            // ->0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            var filePath = Path.Combine(uploadFolder, uniqueName);

            //webserver/Images/0f8fad5b-d9cb-469f-a165-70867728950e.jpg
            post.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            _context.Posts.Add(new Post
            {
                Title = post.Title,
                Body = post.Body,
                CategoryId = post.CategoryId,
                ImageName = uniqueName
            });
            _context.SaveChanges();

            TempData["success"] = "Successfully Added";
            return RedirectToAction(nameof(Index));
        }
    }
}
