using Microsoft.AspNetCore.Mvc;

namespace OneToManyExample.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
