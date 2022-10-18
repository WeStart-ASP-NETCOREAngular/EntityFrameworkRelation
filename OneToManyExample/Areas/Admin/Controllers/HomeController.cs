using Microsoft.AspNetCore.Mvc;

namespace OneToManyExample.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
