using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IAuthServices
    {
        Task<User> AuthenticateUser(string Email, string Password);
    }
}
