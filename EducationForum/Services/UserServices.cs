using EducationForum.Domain;
using EducationForum.Repository.Interface;
using EducationForum.Services.Interface;

namespace EducationForum.Services
{
    public class UserServices : IUserServices
    {
        public IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserByID(int ID)
        {
            try
            {
                return await _userRepository.GetUserByID(ID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
