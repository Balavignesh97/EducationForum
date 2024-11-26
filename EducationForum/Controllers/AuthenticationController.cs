using EducationForum.Domain;
using EducationForum.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EducationForum.Controllers
{
    public class AuthenticationController : Controller
    {
        protected IUserServices _UserServices;
        public AuthenticationController(IUserServices UserServices)
        {
            _UserServices = UserServices;
        }
        public async Task<IActionResult> Login()
        {
            User user =await _UserServices.GetUserByID(1);
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
