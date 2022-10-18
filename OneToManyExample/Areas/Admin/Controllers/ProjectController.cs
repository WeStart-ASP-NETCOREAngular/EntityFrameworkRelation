using Microsoft.AspNetCore.Mvc;

namespace OneToManyExample.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
