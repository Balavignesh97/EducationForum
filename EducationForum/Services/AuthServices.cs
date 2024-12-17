using EducationForum.Domain;
using EducationForum.Repository;
using EducationForum.Repository.Interface;
using EducationForum.Services.Interface;

namespace EducationForum.Services
{
    public class AuthServices : IAuthServices
    {
        public IAuthRepository _authRepository;
        public AuthServices(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public Task<User> AuthenticateUser(string Email, string Password)
        {
            try
            {
                return _authRepository.AuthenticateUser(Email, Password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
