using EducationForum.Common;
using EducationForum.Domain;
using EducationForum.Helpers;
using EducationForum.Repository;
using EducationForum.Repository.Interface;
using EducationForum.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EducationForum.Controllers
{

    public class AuthenticationController : Controller
    {
        protected IUserServices _UserServices;
        public IAuthServices _authservices;
        public AuthenticationController(IUserServices UserServices, IAuthServices authservices)
        {
            _UserServices = UserServices;
            _authservices = authservices;
        }
        public async Task<IActionResult> Login()
        {
            User userdata = new User();
            string ExistingCookiData = HttpContext.Request.Cookies[AppConfig.AdminCookieKey];
            if (string.IsNullOrEmpty(ExistingCookiData)) return View();

            string Data = EncryptionHelper.Decrypt(ExistingCookiData);
            var Userinfo = System.Text.Json.JsonSerializer.Deserialize<User>(Data);
            if (Userinfo == null) return View();

            userdata = await _UserServices.GetUserByID(Userinfo.UserID);
            if (userdata != null && !string.IsNullOrEmpty(userdata.UserCode))
            {
                return RedirectToAction("EnquiryQueue", "Admin");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AuthenticateLogin(string Email, string Password)
        {
            User userdata = new User();
            try
            {
                userdata = await _authservices.AuthenticateUser(Email, Password);


                if (userdata != null && userdata.UserID > 0)
                {
                    User userdataincookie = new User()
                    {
                        UserID = userdata.UserID,
                        UserCode = userdata.UserCode,
                        Email = userdata.Email,
                        FirstName = userdata.FirstName,
                        LastName = userdata.LastName
                    };
                    string jsonData = System.Text.Json.JsonSerializer.Serialize(userdataincookie);
                    string encryptedData = EncryptionHelper.Encrypt(jsonData);

                    // Set cookie
                    CookieOptions options = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, // Use HTTPS
                        Expires = DateTimeOffset.Now.AddMinutes(30)
                    };

                    Response.Cookies.Append(AppConfig.AdminCookieKey, encryptedData, options);

                    return Json(new DataCreationReturnMessage()
                    {ErrorType = "toster",Status = "success", RedirectTo = "/Admin/EnquiryQueue", ReturnMessage = "Login Authenticated!",SpinnerID = "#LoginSpinner",ButtonID = "#Loginbtn",});
                }
                return Json(new DataCreationReturnMessage()
                { ErrorType = "toster",Status = "error",ReturnMessage = "Login failed!",SpinnerID = "#LoginSpinner",ButtonID = "#Loginbtn",});
            }
            catch (Exception ex)
            {
                return Json(new DataCreationReturnMessage()
                {ErrorType = "toster",Status = "error",ReturnMessage = "Login failed!",SpinnerID = "#LoginSpinner", ButtonID = "#Loginbtn",
                });
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Append(AppConfig.AdminCookieKey, "", new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1)
            });
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
