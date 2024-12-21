using EducationForum.Filters;
using Microsoft.AspNetCore.Mvc;
using EducationForum.Services.Interface;
using EducationForum.Domain;
using EducationForum.Domain.ViewModels;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EducationForum.Controllers
{
    //[TypeFilter(typeof(AuthFilter))]
    public class AdminController : Controller
    {
        public IDashboardServices _dashboardServices;
        public AdminController(IDashboardServices dashboardServices)
        {
            _dashboardServices = dashboardServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EnquiryQueue()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<List<EnquiryQueue>>> GetEnquiryQueueData(string name = "", string email = "", string phone = "",
            byte classtypeid = 0, string? orderby = null, string sortOrder = "ASC", string? startdate = null, string? enddate = null, int page = 1)
        {
            List<EnquiryQueue> studernenquiry = new List<EnquiryQueue>();
            try
            {

                DashboardParam dashboardParam = new DashboardParam()
                {
                    Name = name,
                    Email = email,
                    Phone = phone,
                    ClassTypeID = classtypeid,
                    StartDate = startdate != null ? Convert.ToDateTime(startdate) : null,
                    EndDate = startdate != null ? Convert.ToDateTime(enddate) : null,
                    Orderby = orderby,
                    Skip = page == 1 ? 0 : Convert.ToInt16((page - 1).ToString() + '0'),
                    Take = 10,
                    SortOrder = sortOrder,
                };
                studernenquiry = await _dashboardServices.GetEnquiryQueueData(dashboardParam);
                if (studernenquiry != null && studernenquiry.Count > 0 && studernenquiry.FirstOrDefault().EnquiryID > 0)
                {
                    return Json(new
                    {
                        recordsTotal = studernenquiry.FirstOrDefault().TotalCount,
                        data = studernenquiry
                    });
                }
                return Json(new
                {
                    recordsTotal = 0,
                    data = new List<StudentEnquiry>()
                });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<StudentEnquiry>> GetEnquiryByID(int enquiryid)
        {
            try
            {
                StudentEnquiry enquiry = await _dashboardServices.GetEnquiryByID(enquiryid);
                if (enquiry.EnquiryID > 0)
                {
                    return await Task.FromResult(Json(enquiry));
                }
                return Json(new { });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<bool> SubmitEnquiryResponse(string Name, string Email,string Phone,bool IsResponded,
            bool IsOnHold,bool IsRequestCallBack,bool IsCallAttemptFailed,string ResponderNote)
        {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
