using EducationForum.Domain;
using EducationForum.Models;
using EducationForum.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Contact(int subjectId=0)
        {
            setviewbag();
            return View();
        }
        [HttpPost]
        public IActionResult GetContact(Contact obj)
        {
            DataCreationReturnMessage message = new DataCreationReturnMessage();
            //bool Iupdated = false;

            StudentEnquiry studentEnquiry = new StudentEnquiry();
            StudentEnquiryGradeSubjectMap studentEnquiryGradeSubjectMap =   new StudentEnquiryGradeSubjectMap();
            studentEnquiry.Name = obj.fullname;
            studentEnquiry.Email = obj.email;
            studentEnquiry.Phone = obj.Mobile;
            studentEnquiry.ClassTypeID =Convert.ToInt16(obj.choiceofclass);
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

        public void setviewbag()
        {
            var getsubject=_subjectservices.GetSubjects().Result;
            var getgrade=_subjectservices.GetGrades().Result;
            var getclasstype=_subjectservices.GetClassTypes().Result;
            ViewBag.subject = new SelectList(getsubject.Where(x=>x.IsActive).ToList(), "SubjectID", "SubjectName");
            ViewBag.grade = new SelectList(getgrade.Where(x => x.IsActive).ToList(), "GradeID", "Grade");
            ViewBag.classtype = new SelectList(getclasstype.Where(x => x.IsActive).ToList(), "ClassTypeID", "ClassType");
        }
    }
}
