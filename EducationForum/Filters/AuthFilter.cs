using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EducationForum.Helpers;
using EducationForum.Domain;
using EducationForum.Common;

namespace EducationForum.Filters
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string encryptedAdminData = context.HttpContext.Request.Cookies[AppConfig.AdminCookieKey];

            if (string.IsNullOrEmpty(encryptedAdminData))
            {
                // Redirect to AdminLogin if no cookie is found
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "Logout", controller = "Authentication" }));
                return;
            }

            try
            {
                // Decrypt the cookie value (assuming it's encrypted)
                string userData = EncryptionHelper.Decrypt(encryptedAdminData);

                // Deserialize the decrypted data
                var userInfo = System.Text.Json.JsonSerializer.Deserialize<User>(userData);

                // Example: Check if AdminID is present
                int adminID = userInfo?.UserID ?? 0;

                if (adminID == 0)
                {
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "Logout", controller = "Authentication" }));
                }
                else
                {
                    context.HttpContext.Session.Clear();
                    context.HttpContext.Session.SetString("UserCode", userInfo.UserCode.ToString());
                    context.HttpContext.Session.SetString("FirstName", userInfo.FirstName);
                    context.HttpContext.Session.SetString("LastName", userInfo.LastName ?? "");
                }
            }
            catch
            {
                // Handle decryption errors or invalid cookie data
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { action = "Logout", controller = "Authentication" }));
            }
        }
    }
}
