using EducationForum.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EducationForum.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
