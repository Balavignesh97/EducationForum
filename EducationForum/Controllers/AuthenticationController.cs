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
        public IActionResult Login()
        {
            //User user =await _UserServices.GetUserByID(1);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AuthenticateLogin(string Email,string Password)
        {
            DataCreationReturnMessage message = new DataCreationReturnMessage();
            message.ErrorType = "toster";
            message.Status = "success";
            message.RedirectTo = "";
            message.title = "";
            message.ReturnMessage = "Login Authenticated !";
            message.SpinnerID = "#LoginSpinner";
            message.ButtonID = "#Loginbtn";
            return Json(message);
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
