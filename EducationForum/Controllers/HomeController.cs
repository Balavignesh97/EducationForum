using EducationForum.Domain;
using EducationForum.Models;
using EducationForum.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace EducationForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICoursesServices _coursesServices;
        public HomeController(ILogger<HomeController> logger, ICoursesServices coursesServices)
        {
            _logger = logger;
            _coursesServices = coursesServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult CourseDetails()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact(int subjectId=0)
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult<List<TemplateCourses>>> GetTemplateCourseDetails()
        {
            List<TemplateCourses> Courses = new List<TemplateCourses>();
            Courses = await _coursesServices.GetTemplateCourseDetails();
            if(Courses!=null && Courses.Count() > 0)
            {
                return Json(Courses);
            }
            else
            {
                return Json(new List<TemplateCourses>());
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
