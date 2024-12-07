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
        private ISubjectServices _subjectservices;
        public HomeController(ILogger<HomeController> logger, ICoursesServices coursesServices, ISubjectServices subjectservices)
        {
            _logger = logger;
            _coursesServices = coursesServices;
            _subjectservices = subjectservices;
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
        public IActionResult GetContact(Contact obj)
        {
            DataCreationReturnMessage message = new DataCreationReturnMessage();
            //bool Iupdated = false;

            StudentEnquiry studentEnquiry = new StudentEnquiry();
            StudentEnquiryGradeSubjectMap studentEnquiryGradeSubjectMap = new StudentEnquiryGradeSubjectMap();
            studentEnquiry.Name = obj.fullname;
            studentEnquiry.Email = obj.email;
            studentEnquiry.Phone = obj.Mobile;
            studentEnquiry.ClassTypeID = Convert.ToInt16(obj.choiceofclass);
            studentEnquiry.EnquirerNote = obj.message;
            studentEnquiry.DateAdded = DateTime.Now;
            _subjectservices.Create(studentEnquiry);

            studentEnquiryGradeSubjectMap.EnquiryID = studentEnquiry.EnquiryID;
            studentEnquiryGradeSubjectMap.GradeID = Convert.ToInt16(obj.Class);
            studentEnquiryGradeSubjectMap.SubjectID = Convert.ToInt16(obj.subject);
            studentEnquiryGradeSubjectMap.DateAdded = DateTime.Now;
            _subjectservices.Create(studentEnquiryGradeSubjectMap);

            //if (Iupdated)
            //{
            //    message.IscreatedSucessfully = true;
            //    message.ErrorDisplayType = "ErrorStrip";
            //    message.ReturnMessage = "Sucess:Orders Confirmed";
            //    return Json(message);
            //}
            //message.IscreatedSucessfully = false;
            //message.ErrorDisplayType = "ErrorStrip";
            //message.ReturnMessage = "Failed:Problem With Order Conformation";
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
        [HttpGet]
        public async Task<ActionResult<List<Subjects>>> GetSubjects()
        {
            try
            {
                var Subjects = await _subjectservices.GetSubjects();
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
                var Grades = await _subjectservices.GetGrades();
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
                var classtypes = await _subjectservices.GetClassTypes();
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
