using EducationForum.Domain;
using EducationForum.Repository.Interface;
using EducationForum.Services.Interface;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> AddUser(User user)
        {
            try
            {
                return await _userRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<MasterUserType>> GetUserType()
        {
            try
            {
                return await _userRepository.GetUserType();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
