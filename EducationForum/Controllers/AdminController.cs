using Microsoft.AspNetCore.Mvc;

namespace EducationForum.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
