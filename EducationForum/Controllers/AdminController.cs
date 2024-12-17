using EducationForum.Filters;
using Microsoft.AspNetCore.Mvc;
using EducationForum.Services.Interface;
using EducationForum.Domain;
using EducationForum.Domain.ViewModels;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<List<StudentEnquiry>>> GetDashboardData(string name = "", string email = "", string phone = "",
            byte classtypeid = 0, string? orderby = null, string sortOrder = "ASC", DateTime? startdate = null, DateTime? enddate = null, int page = 1)
        {
            List<StudentEnquiry> studernenquiry = new List<StudentEnquiry>();
            try
            {

                DashboardParam dashboardParam = new DashboardParam()
                {
                    Name = name,
                    Email = email,
                    Phone = phone,
                    ClassTypeID = classtypeid,
                    StartDate = startdate,
                    EndDate = enddate,
                    Orderby = orderby,
                    Skip = page == 1 ? 0 : Convert.ToInt16((page - 1).ToString() + '0'),
                    Take = 10,
                    SortOrder = sortOrder,
                };
                studernenquiry = await _dashboardServices.GetDashboardData(dashboardParam);
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

    }
}
