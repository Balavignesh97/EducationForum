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
        private IContactServices _contactservices;
        public HomeController(ILogger<HomeController> logger, ICoursesServices coursesServices, IContactServices contactservices)
        {
            _logger = logger;
            _coursesServices = coursesServices;
            _contactservices = contactservices;
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
        public IActionResult Contact(int subjectId = 0)
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitEnquiry(Contact obj)
        {
            DataCreationReturnMessage message = new DataCreationReturnMessage();

            StudentEnquiry studentEnquiry = new StudentEnquiry();
            studentEnquiry.Name = obj.fullname;
            studentEnquiry.Email = obj.email;
            studentEnquiry.Phone = obj.Mobile;
            studentEnquiry.ClassTypeID = Convert.ToInt16(obj.choiceofclass);
            studentEnquiry.EnquirerNote = obj.message;
            studentEnquiry.studentEnquiryGradeSubjectMaps = new List<StudentEnquiryGradeSubjectMap>{
                new StudentEnquiryGradeSubjectMap()
                {
                    EnquiryID = studentEnquiry.EnquiryID,
                    GradeID = Convert.ToInt16(obj.Class),
                    SubjectID = Convert.ToInt16(obj.subject)
                }
            };
            _contactservices.SubmitEnquiry(studentEnquiry);

            message.Status = "success";
            message.RedirectTo = "/Home/Contact";
            message.ReturnMessage = "Message Submited Successfully";
            message.SpinnerID = "#smspin";
            return Json(message);
        }
        [HttpGet]
        public async Task<ActionResult<List<TemplateCourses>>> GetTemplateCourseDetails()
        {
            List<TemplateCourses> Courses = new List<TemplateCourses>();
            Courses = await _coursesServices.GetTemplateCourseDetails();
            if (Courses != null && Courses.Count() > 0)
            {
                return Json(Courses);
            }
            else
            {
                return Json(new List<TemplateCourses>());
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<Subjects>>> GetSubjects(short gradeID)
        {
            try
            {
                var Subjects = await _contactservices.GetSubjectsByGrade(gradeID);
                return Json(Subjects);
            }
            catch
            {
                return Json(new List<Subjects>());
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Grades>>> GetGrades()
        {
            try
            {
                var Grades = await _contactservices.GetGrades();
                return Json(Grades);
            }
            catch
            {
                return Json(new List<Grades>());
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ClassTypes>>> GetClassTypes()
        {
            try
            {
                var classtypes = await _contactservices.GetClassTypes();
                return Json(classtypes);
            }
            catch
            {
                return Json(new List<ClassTypes>());
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
